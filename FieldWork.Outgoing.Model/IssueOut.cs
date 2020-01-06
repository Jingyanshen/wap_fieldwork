using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model
{
    /// <summary>
    /// 问题上报
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class IssueOut
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
        public string Type { get; set; }

        /// <summary>
        /// 上报名称
        /// </summary>
        [DataMember(Name = "typeName")]
        public string TypeName { get; set; }

        /// <summary>
        /// 是否批量上报
        /// </summary>
        [DataMember(Name = "isBatch")]
        public string IsBatch { get; set; }

        /// <summary>
        /// 上报时间
        /// </summary>
        [DataMember(Name = "time")]
        public string Time { get; set; }

        /// <summary>
        /// 发生地址
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// 提交位置
        /// </summary>
        [DataMember(Name = "location")]
        public Location Location { get; set; }

        /// <summary>
        /// 上报说明
        /// </summary>
        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        /// <summary>
        /// 状态【 0:待审核; 1:有效; -1:无效; 2:生成工单;-2:已处理】
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class Location
    {
        /// <summary>
        /// 坐标系类型【WGS84:GPS坐标系; BD09:百度坐标系; CUSTOM:自定义 坐标系】
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 坐标值【格式如：'120.000,30.000'。保留三位小数】
        /// </summary>
        [DataMember(Name = "coordinates")]
        public string Coordinates { get; set; }
    }
}
