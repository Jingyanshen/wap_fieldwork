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
    /// 巡查必达点实体类
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolCKPoint : EntityBase
    {
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 类型 -- 1:明点; 2:暗桩
        /// </summary>
        [DataMember]
        public int Type { get; set; }

        /// <summary>
        /// 地址
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
        /// 允许误差 -- 默认20米
        /// </summary>
        [DataMember]
        public int Tolerence { get; set; }

        /// <summary>
        /// 所属网格
        /// </summary>
        [DataMember]
        public int GridId { get; set; }

        /// <summary>
        /// 所在道路
        /// </summary>
        [DataMember]
        public string Road { get; set; }

        /// <summary>
        /// 必达周期
        /// </summary>
        [DataMember]
        public string Period { get; set; }

        /// <summary>
        /// 必达频次
        /// </summary>
        [DataMember]
        public int Frequency { get; set; }

        /// <summary>
        /// 自定义周期
        /// </summary>
        [DataMember]
        public int PeriodId { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        [DataMember]
        public string Extend { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [DataMember]
        public int Grade { get; set; }
    }
}
