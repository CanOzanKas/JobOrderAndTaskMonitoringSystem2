﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Repositories.GenericRepo {
    public interface IGenericRepository<T> where T : class {
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public List<T> GetAll();
        public T GetById(int id);

    }
}
