using GameViewer.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameViewer.Repository
{
    internal class GeneralRepository
    {
        private readonly GameViewerContext _context;
        public GeneralRepository()
        {
            _context=new GameViewerContext();
        }
        public void Add<T>(T entity) where T : class
        {
            using (var context = _context)
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Update<T>(T entity) where T : class
        {
            using (var context = _context)
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            using (var context = _context)
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public T GetById<T>(int id) where T : class
        {
            using (var context = _context)
            {
                return context.Set<T>().Find(id);
            }
        }

        public List<T> GetAll<T>() where T : class
        {
            using (var context = _context)
            {
                return context.Set<T>().ToList();
            }
        }
    }
}
