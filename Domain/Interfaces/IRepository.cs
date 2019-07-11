﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomianDriving.Domains.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(Guid id);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// 根据对象进行更新
        /// </summary>
        /// <param name="obj"></param>
        void Update(TEntity obj);
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        void Remove(Guid id);
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
