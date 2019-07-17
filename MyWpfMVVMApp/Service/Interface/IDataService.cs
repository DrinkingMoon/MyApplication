
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfMVVMApp.Service
{
    public interface IDataService<T>
    {
        ICollection<T> GetList();

        T GetItem();

        void SaveInfo(T model);
    }
}
