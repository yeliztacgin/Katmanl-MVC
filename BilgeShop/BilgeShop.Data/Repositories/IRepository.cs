using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Data.Repositories
{
      public interface IRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity,bool>>predicate =null);

        //bir sql sorgusunu paramatre olarak göndermek istiyorsanız  parametrenin tipi 
        //Expression<Func<TEntity, bool

        ///= null diyerek bu metodun parametre alarak veya almayarak çalışabileceğini, gösteriyorum
        ///parametre gönderilirse  o filtreleme ile butun yapılar
        ///parametre gönderilmezse filtrelemesiz bütün yapılar
        ///

        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        

    }
}
