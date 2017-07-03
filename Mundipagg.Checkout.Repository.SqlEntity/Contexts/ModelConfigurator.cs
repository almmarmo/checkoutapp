using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Mundipagg.Checkout.Repository.SqlEntity.Contexts
{
    public class ModelConfigurator
    {
        ModelBuilder modelBuilder;
        public ModelConfigurator(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public ModelConfigurator Configure<T>() where T : class
        {
            Activator.CreateInstance(typeof(T), modelBuilder);
            return this;
        }
    }
}
