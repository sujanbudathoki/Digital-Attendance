using System.Collections.Generic;

namespace MyAttendance.Repositories
{


    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Collection();
        void Commit();
        T Find(int Id);
        void Insert(T t);
        void Delete(int Id);
        void Edit(T t);
        void Detach(T t);
    }
}
