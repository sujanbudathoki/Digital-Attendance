using MyAttendance.Models;
using MyAttendance.Repositories;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyAttendance.DataAccess
{
    public class SQLRepository<T> : IRepository<T> where T : class
    {
        internal DataContext Context;
        internal DbSet<T> dbset;

        public SQLRepository():this(new DataContext())
        {

        }
        public SQLRepository(DataContext context)
        {
            this.Context = context;
            this.dbset = context.Set<T>();//dbset from datacontext
        }

        public IEnumerable<T> Collection()
        {
           
            return dbset;
        }



        public void Commit()
        {
            Context.SaveChanges();
           
        }
        
        public void Delete(int Id)
        {

            var t = Find(Id);
            //Method1
            // dbset.Remove(t);
            //using safer method
            if (Context.Entry(t).State == EntityState.Detached)
                dbset.Attach(t);
            dbset.Remove(t);



        }

        public void Edit(T t)
        {
           

            Context.Entry(t).State = EntityState.Modified;
            dbset.Attach(t);

        }
        public void Detach(T t)
        {
            Context.Entry(t).State = EntityState.Detached;
            Context.SaveChanges();
        }

        public T Find(int Id)
        {
            var t = dbset.Find(Id);//search based on primary key value
            return t;
        }

        public void Insert(T t)
        {
            dbset.Add(t);


        }

    }
}