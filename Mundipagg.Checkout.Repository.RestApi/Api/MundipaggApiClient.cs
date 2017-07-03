using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Mundipagg.Checkout.Repository.RestApi.Messages;
using Newtonsoft.Json;

namespace Mundipagg.Checkout.Repository.RestApi
{
	public class MundipaggApiClient : IDisposable
	{
		HttpClient httpClient;
		bool disposed = false;

		const string baseUrlAccessToken = "http://private-anon-0bd478aaf1-mundipaggportal.apiary-mock.com";
		const string baseUrlMerchants = "https://private-anon-6e599ea9bc-mundipaggportal.apiary-mock.com";
		const string baserUrlTransactions = "https://sandbox.mundipaggone.com";

		public MundipaggApiClient()
		{
			httpClient = new HttpClient();
		}

		public T Authenticate<T>(string username, string password) where T : class
		{
			var result = Authenticate(username, password);
			var content = result.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<T>(content);
		}

		public HttpResponseMessage Authenticate(string username, string password)
		{
			httpClient.BaseAddress = new Uri(baseUrlAccessToken);
			using (StringContent jsonRequest = new StringContent($"{{\"username\" : \"{username}\", \"password\" : \"{password}\"}}"))
			{
				return httpClient.PostAsync("/users/accesstokens", jsonRequest).Result;
			}
		}

		public T GetMerchants<T>(string customerKey) where T : class
		{
			var result = GetMerchants(customerKey);
			var content = result.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<T>(content);
		}


		public HttpResponseMessage GetMerchants(string customerKey)
		{
			httpClient.BaseAddress = new Uri(baseUrlMerchants);
			return httpClient.GetAsync($"/{customerKey}/merchants?merchant=merchant&pageNumber=1&pageSize=100&isDeleted=false").Result;
		}

		public SaleResponseMessage Sale(string merchantKey, SaleRequestMessage request)
		{
			httpClient.BaseAddress = new Uri(baserUrlTransactions);
			httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			httpClient.DefaultRequestHeaders.Add("MerchantKey", merchantKey);

			StringContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
			//content.Headers.Add("MechantKey", merchantKey);
			//content.Headers.Add("Accept", "application/json");

			var response = httpClient.PostAsync("/Sale", content).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return JsonConvert.DeserializeObject<SaleResponseMessage>(response.Content.ReadAsStringAsync().Result);
            else
                throw new HttpRequestException(response.ReasonPhrase);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
					httpClient.Dispose();

				disposed = true;
			}
		}
	}
}
