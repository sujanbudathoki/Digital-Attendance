using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttendance.Repositories
{
    
 
  public  interface IRepository<T> where T:class
    {
        IEnumerable<T> Collection();
        void Commit();
        T Find(int Id);
        void Insert(T t);
        void Delete(int Id);
        void Edit(T t);
    }
}
