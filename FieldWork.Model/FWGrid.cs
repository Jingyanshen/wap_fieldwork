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
    /// 网格Model
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWord")]
    public class FWGrid
    {
        /// <summary>
        /// 网格编号
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 网格名称
        /// </summary>
        [DataMember]
        public String Name { get; set; }

        /// <summary>
        /// 上级编号
        /// </summary>
        [DataMember]
        public int ParentId { get; set; }

        /// <summary>
        /// 所属组织
        /// </summary>
        [DataMember]
        public int StationId { get; set; }

        /// <summary>
        /// 所属组织名称
        /// </summary>
        [DataMember]
        public string StationName { get; set; }

        /// <summary>
        /// 级别 --用于图层分层展示
        /// </summary>
        [DataMember]
        public int Hierarchy { get; set; }

        /// <summary>
        /// gis图层对象
        /// </summary>
        [DataMember]
        public string GisObjectId { get; set; }

        /// <summary>
        /// gis图层编号
        /// </summary>
        [DataMember]
        public string GisLayerId { get; set; }

        /// <summary>
        /// 地图图层编号
        /// </summary>
        [DataMember]
        public string MapLayerId { get; set; }

        /// <summary>
        /// GIS图形
        /// </summary>
        [DataMember]
        public string Geometry { get; set; }

        /// <summary>
        /// 网格范围(矩形)
        /// </summary>
        [DataMember]
        public string Extend { get; set; }
    }
}
