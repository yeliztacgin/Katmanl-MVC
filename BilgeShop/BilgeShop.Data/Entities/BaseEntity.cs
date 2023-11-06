using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Data.Entities
{
    public  abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime  CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

    public abstract class BaseConfiguration<TEntity> :
        IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        ///Virtual tanımlıyorum ki derived classlar  ezebilsin
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.Property(x => x.ModifiedDate).IsRequired(false);

            //modified kolonuna null değer atanabilir .
        }
    }
     //where TEntity : BaseEntity bu clasın sadece baseentity tipindeki yapılarla kullanılableceğini söylüyor

}
