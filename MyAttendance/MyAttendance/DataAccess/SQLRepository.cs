using MyAttendance.Models;
using MyAttendance.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyAttendance.DataAccess
{
    public class SQLRepository<T> : IRepository<T> where T : class
    {
        internal DataContext Context;
        internal DbSet<T> dbset;
       public SQLRepository(DataContext context)
        {
            this.Context = context;
            this.dbset = Context.Set<T>();//dbset from datacontext
        }

        public   IQueryable<T> Collection()
        {
            return  dbset;
        }
        public async Task<List<T>> GetListAsync()
        {
            return await Collection().ToListAsync();
        }


        public  void Commit()
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
            dbset.Attach(t);
            Context.Entry(t).State = EntityState.Modified;

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