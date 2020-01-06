using SH3H.WAP.FieldWork.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 当前任务的必达点和打卡信息
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWCKPointDto
    {
        /// <summary>
        /// 
        /// </summary>
        public FWCKPointDto() {
            CKPoint = new FWPatrolCKPointDto();
            TaskCKPoint = new FWPatrolTaskCKPointDto();
        }

        /// <summary>
        /// 必达点Id用来排序
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "cKPoint")]
        public FWPatrolCKPointDto CKPoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "taskCKPoint")]
        public FWPatrolTaskCKPointDto TaskCKPoint { get; set; }
    }
}
