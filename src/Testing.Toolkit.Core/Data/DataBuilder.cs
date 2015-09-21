using System;
using System.Collections.Generic;

namespace Testing.Toolkit.Core.Data
{
    public abstract class DataBuilder<TDataModel>
        where TDataModel : class
    {

        protected DataBuilder()
        {
            BuilderId = Guid.NewGuid();
        }

        protected Guid BuilderId { get; private set; }

        public virtual IEnumerable<TDataModel> Build(int count)
        {
            return FizzWare.NBuilder.Builder<TDataModel>
                .CreateListOfSize(count).Build();
        }

        public virtual TDataModel Build()
        {
            return FizzWare.NBuilder.Builder<TDataModel>
                .CreateNew().Build();
        }
    }
}
