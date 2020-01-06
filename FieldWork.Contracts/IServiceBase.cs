using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IServiceBase<TDto>
        where TDto : class,new()
    {
        TDto Insert(TDto dto);

        bool Update(TDto dto);

        IEnumerable<TDto> Query();
    }
}
