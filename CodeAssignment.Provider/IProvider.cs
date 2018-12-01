using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.Provider
{
   public interface IProvider<T> where T : class
    {
        List<T> GetAll();

        T Get(int id);

        int AddUpdate(T model);
    }
}
