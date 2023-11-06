﻿using BilgeShop.Data.Context;
using BilgeShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Data.Repositories
{
    public class SqlRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly BilgeShopContext _db;
        private readonly DbSet<TEntity> _dbSet;
        public SqlRepository(BilgeShopContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.IsDeleted = true;
            _dbSet.Update(entity);
            _db.SaveChanges();

        }

        public void Delete(int id)
        {
             var entity = _dbSet.Find(id);

            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
            //todo first single first or default single  of default anlatılacak 
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is not null ? _dbSet.Where(predicate) : _dbSet;
        }

        public TEntity GetById(int id)
        {
            var entity = _dbSet.Find(id);
            return entity;
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
            _db.SaveChanges();
        }
    }
}
/////******veri bulma metodları****
///
//1-Find :ıd ile eşleşen veriyi bulur
 //2-First : İlk eşleşen veriyi döner  hiç veri bulamazsa hata verir
 //3-Firstordefoult : İlk eşleşen veriyi döner  hiç veri bulamazsa null döner
 //4-Single :İlk eşleşen veriyi döner başka eşleşen veya hiç veri yoksa error verir
 //5-SingleOrDefult:İlk eşleşen  veriyi döner başka eşleşen varsa error verir  hiç veri yoksa null döner.