using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Toolkit.Core.Data
{
    public interface IDataBuilder<out TDataModel>
        where TDataModel : class
    {
        IEnumerable<TDataModel> Build(int count);
        TDataModel Build();
    }
}
