using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model.ViewModels
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWIssueViewModel
    {
        /// <summary>
        /// 上报编号
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 上报分类
        /// </summary>
        [DataMember(Name = "type")]
        public int Type { get; set; }

        /// <summary>
        /// 上报名称
        /// </summary>
        [DataMember(Name = "typeName")]
        public string TypeName { get; set; }

        /// <summary>
        /// 是否批量上报
        /// </summary>
        [DataMember(Name = "isBatch")]
        public int IsBatch { get; set; }

        /// <summary>
        /// 上报时间
        /// </summary>
        [DataMember(Name = "time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// 发生地址
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// 提交位置
        /// </summary>
        [DataMember(Name = "location")]
        public string Location { get; set; }

        /// <summary>
        /// 上报说明
        /// </summary>
        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        /// <summary>
        /// 状态【 0:待审核; 1:有效; -1:无效; 2:生成工单;-2:已处理】
        /// </summary>
        [DataMember(Name = "status")]
        public int Status { get; set; }
    }
}
