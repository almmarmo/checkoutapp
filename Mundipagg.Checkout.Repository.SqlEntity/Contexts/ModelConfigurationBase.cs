using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mundipagg.Checkout.Repository.SqlEntity.Contexts
{
    public abstract class ModelConfigurationBase<T> where T : class
    {
        EntityTypeBuilder<T> builder;
        public ModelConfigurationBase(ModelBuilder modelBuilder)
        {
            builder = modelBuilder.Entity<T>();
        }

        protected EntityTypeBuilder<T> Builder { get { return builder; } }
    }
}
