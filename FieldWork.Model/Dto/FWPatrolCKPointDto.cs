using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model.Dto
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolCKPointDto : DtoBase<FWPatrolCKPoint, FWPatrolCKPointDto>
    {

        [DataMember(Name = "id")]
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 类型 -- 1:明点; 2:暗桩
        /// </summary>
        [DataMember(Name = "type")]
        public int Type { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// X坐标
        /// </summary>
        [DataMember(Name = "x")]
        public decimal X { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        [DataMember(Name = "y")]
        public decimal Y { get; set; }

        /// <summary>
        /// 允许误差 -- 默认20米
        /// </summary>
        [DataMember(Name = "tolerence")]
        public int Tolerence { get; set; }

        /// <summary>
        /// 所属网格
        /// </summary>
        [DataMember(Name = "gridId")]
        public int GridId { get; set; }

        /// <summary>
        /// 所在道路
        /// </summary>
        [DataMember(Name = "road")]
        public string Road { get; set; }

        /// <summary>
        /// 必达周期
        /// </summary>
        [DataMember(Name = "period")]
        public string Period { get; set; }

        /// <summary>
        /// 必达频次
        /// </summary>
        [DataMember(Name = "frequency")]
        public int Frequency { get; set; }

        /// <summary>
        /// 自定义周期
        /// </summary>
        [DataMember(Name = "periodId")]
        public int PeriodId { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        [DataMember(Name = "extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [DataMember(Name = "grade")]
        public int Grade { get; set; }

        [DataMember(Name = "creator")]
        public string Creator { get; set; }

        [DataMember(Name = "createTime")]
        public DateTime CreateTime { get; set; }



        /// <summary>
        /// 周期编号
        /// </summary>
        [DataMember(Name = "patrolPeriodId")]
        public int PatrolPeriodId { get; set; }

        /// <summary>
        /// 周期
        /// </summary>
        [DataMember(Name = "periodBase")]
        public int PeriodBase { get; set; }

        /// <summary>
        /// 周期间隔
        /// </summary>
        [DataMember(Name = "interval")]
        public int Interval { get; set; }
    }
}
