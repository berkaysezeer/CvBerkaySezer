using CvBerkaySezer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CvBerkaySezer.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context db = new Context();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().Where(where).ToList();
        }

        public void Add(T t)
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

        public void Update()
        {
            db.SaveChanges();
        }
    }
}