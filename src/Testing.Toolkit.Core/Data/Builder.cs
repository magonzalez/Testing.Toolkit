using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Testing.Toolkit.Core.Data
{
    public abstract class Builder<TDataModel>
        where TDataModel : class
    {

        protected Builder(IContainer container)
        {
            Container = container;

            BuilderId = Guid.NewGuid();
        }

        protected IContainer Container { get; private set; }

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

        public virtual IEnumerable<TDataModel> BuildAndSave(int count)
        {
            throw new NotImplementedException("Save is not implemented by default.");
        }

        public virtual TDataModel BuildAndSave()
        {
            throw new NotImplementedException("Save is not implemented by default.");
        }
    }
}
