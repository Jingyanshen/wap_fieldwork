using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class PaginationDto<T> where T : class
    {
        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        [DataMember(Name = "dataList")]
        public IEnumerable<T> DataList { get; set; }

        public PaginationDto()
        {
            DataList = new List<T>();
        }

        public PaginationDto(IEnumerable<T> list, int totals)
        {
            DataList = list;
            TotalCount = totals;
        }
    }
}
