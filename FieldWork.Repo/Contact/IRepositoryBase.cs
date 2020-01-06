using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo.Contact
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class,new()
    {
        TEntity Insert(TEntity entity);

        bool Update(TEntity entity);

        IEnumerable<TEntity> Query();
    }
}
