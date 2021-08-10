﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AS.BL.IServices;
using AS.DAL.IRepositories;
namespace AS.BL.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public readonly IBaseRepository<T> _TRepository;
        public BaseService(IBaseRepository<T> TRepository)
        {
            this._TRepository = TRepository;
        }

        public int Create(T T)
        {
            _TRepository.Add(T);
            int result = _TRepository.SaveChanges();
            return result;
        }

        public int Update(T T)
        {
            _TRepository.Update(T);
            int result = _TRepository.SaveChanges();
            return result;
        }

        public void Delete(T T)
        {
            _TRepository.Delete(T);
            _TRepository.SaveChanges();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return _TRepository.Filter(predicate, includes);
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return _TRepository.GetAll(includes);
        }
    }
}