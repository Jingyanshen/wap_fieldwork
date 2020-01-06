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
    public class PaginationBaseDto
    {
        [DataMember(Name="pageIndex")]
        public int pageIndex { get; set; }

        [DataMember(Name="pageSize")]
        public int pageSize { get; set; }

        public PaginationBaseDto()
        {
            pageIndex = 1;
            pageSize = 10;
        }

        public static T BuildDefault<T>(T model) where T : PaginationBaseDto, new()
        {
            if (model == null)
            {
                model = new T();
            }
            if (model.pageIndex < 0)
            {
                model.pageIndex = 1;
            }
            if (model.pageSize <= 0)
            {
                model.pageSize = 10;
            }
            return model;
        }
    }
}
