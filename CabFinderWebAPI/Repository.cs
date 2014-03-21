using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CabFinderDomain;
using NHibernate;
using NHibernate.Linq;

namespace CabFinderWebAPI
{
    public class Repository:IRepository
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public T First<T>(Expression<Func<T, bool>> query) where T : class, IEntity
        {
            T firstOrDefault = _session.Query<T>().FirstOrDefault(query);
            return firstOrDefault;
        }

        public T GetById<T>(long id) where T : class, IEntity
        {
            var item = _session.Get<T>(id);
            return item;
        }

        public T Create<T>(T itemToCreate) where T : class, IEntity
        {
            _session.Save(itemToCreate);
            return itemToCreate;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class, IEntity
        {
            return _session.Query<T>().Where(expression);
        }

        public T Update<T>(T itemToUpdate) where T : class, IEntity
        {
            _session.Update(itemToUpdate);
            _session.Flush();


            return itemToUpdate;
        }

        public T Update2<T>(T itemToUpdate)
        {
            _session.Update(itemToUpdate);
            _session.Flush();
            return itemToUpdate;
        }

        public void Delete<T>(T itemToDelete)
        {
            _session.Delete(itemToDelete);
        }

        public T Inactivate<T>(T itemToUpdate) where T : class, IEntity
        {
            _session.Update(itemToUpdate);
            _session.Flush();

            return itemToUpdate;
        }

    }
}