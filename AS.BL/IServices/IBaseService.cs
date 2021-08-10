﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace AS.BL.IServices
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        int Create(T t);
        int Update(T t);
        void Delete(T t);
    }
}