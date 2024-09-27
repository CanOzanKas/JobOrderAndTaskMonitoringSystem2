using AppPersistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Repositories.GenericRepo {
    public class GenericRepository<T>:IGenericRepository<T> where T : class {

        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context) {
            _context = context;
        }

        public void Create(T entity) {
            _context.Add<T>(entity);
            _context.SaveChanges();
        }
        public T CreateAndReturn(T entity) {
            T createdEntity = _context.Add<T>(entity).Entity;
            _context.SaveChanges();
            return createdEntity;
        }

        public void Delete(T entity) {
            _context.Remove<T>(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll() {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id) {
            return _context.Find<T>(id);
        }

        public void Update(T entity) {
            _context.Update<T>(entity);
            _context.SaveChanges();
        }

    }
}
