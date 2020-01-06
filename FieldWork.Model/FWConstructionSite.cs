using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 工地Model
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWord")]
    public class FWConstructionSite
    {
        /// <summary>
        /// 工地编号
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 工地名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 工地级别
        /// </summary>
        [DataMember]
        public int Level { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// X坐标
        /// </summary>
        [DataMember]
        public decimal X { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        [DataMember]
        public decimal Y { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        [DataMember]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 终止日期
        /// </summary>
        [DataMember]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 建设单位名称
        /// </summary>
        [DataMember]
        public string ConstructorName { get; set; }

        /// <summary>
        /// 建设单位负责人
        /// </summary>
        [DataMember]
        public string ConstructorPic { get; set; }


        /// <summary>
        /// 建设单位联系电话
        /// </summary>
        [DataMember]
        public string ConstructorPhone { get; set; }

        /// <summary>
        /// 施工单位名称
        /// </summary>
        [DataMember]
        public string BuilderName { get; set; }

        /// <summary>
        /// 施工单位负责人
        /// </summary>
        [DataMember]
        public string BuilderPic { get; set; }


        /// <summary>
        /// 施工单位联系电话
        /// </summary>
        [DataMember]
        public string BuilderPhone { get; set; }

        /// <summary>
        /// 监理单位名称
        /// </summary>
        [DataMember]
        public string SupervisorName { get; set; }

        /// <summary>
        /// 监理单位负责人
        /// </summary>
        [DataMember]
        public string SupervisorPic { get; set; }


        /// <summary>
        /// 监理单位联系电话
        /// </summary>
        [DataMember]
        public string SupervisorPhone { get; set; }
    }
}
