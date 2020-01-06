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
    /// 巡查对象Model
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolObject
    {
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public String Name { get; set; }

        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember]
        public int PatrolType { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public String Address { get; set; }

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
        /// 巡查等级
        /// </summary>
        [DataMember]
        public int Grade { get; set; }

        /// <summary>
        /// 所属网格
        /// </summary>
        [DataMember]
        public int GridId { get; set; }

        /// <summary>
        /// 所在道路
        /// </summary>
        [DataMember]
        public String Road { get; set; }

        /// <summary>
        /// 必达周期
        /// </summary>
        [DataMember]
        public String Period { get; set; }

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
        public String Extend { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public String Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// gis图层对象
        /// </summary>
        [DataMember]
        public String GisObjectId { get; set; }

        /// <summary>
        /// gis图层编号
        /// </summary>
        [DataMember]
        public String GisLayerId { get; set; }

        /// <summary>
        /// 地图图层编号
        /// </summary>
        [DataMember]
        public String MapLayerId { get; set; }

        /// <summary>
        /// 便于用户识别的编号
        /// </summary>
        [DataMember]
        public String DisplayId { get; set; }
    }
}
