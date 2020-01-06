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
    /// 巡查小结
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolTaskSummaryDto
    {
        /// <summary>
        /// 巡查方式
        /// </summary>
        [DataMember]
        public int CruiseType { get; set; }

        /// <summary>
        /// 用时
        /// </summary>
        [DataMember]
        public string PatrolTime { get; set; }

        /// <summary>
        /// 公里数
        /// </summary>
        [DataMember]
        public string Mileage { get; set; }

        /// <summary>
        /// 发现问题数
        /// </summary>
        [DataMember]
        public int Issues { get; set; }

        /// <summary>
        /// 事件数
        /// </summary>
        [DataMember]
        public int IssueEvents { get; set; }

        /// <summary>
        /// 设施数
        /// </summary>
        [DataMember]
        public int IssueEquipment { get; set; }

        /// <summary>
        /// 必达点数
        /// </summary>
        [DataMember]
        public int ClockPoint { get; set; }

        /// <summary>
        /// 必达点已签到
        /// </summary>
        [DataMember]
        public int ClockOn { get; set; }

        /// <summary>
        /// 必达点未签到
        /// </summary>
        [DataMember]
        public int UnClockOn { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FWPatrolTaskSummaryDto FromModel(FWPatrolTaskSummary model)
        {
            if (model == null)
            {
                return null;
            }
            FWPatrolTaskSummaryDto dto = new FWPatrolTaskSummaryDto()
            {
                ClockOn = model.ClockOn,
                ClockPoint = model.ClockPoint,
                CruiseType = model.CruiseType,
                IssueEquipment = model.IssueEquipment,
                IssueEvents = model.IssueEvents,
                Issues = model.Issues,
                PatrolTime = model.PatrolTime,
                UnClockOn = model.UnClockOn,
            };
            if (model.Mileage > 0)
            {
                dto.Mileage = (model.Mileage / 1000).ToString("#0.00");
            }
            else
            {
                dto.Mileage = "0";
            }
            return dto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FWPatrolTaskSummary ToModel()
        {
            FWPatrolTaskSummary model = new FWPatrolTaskSummary()
            {
                ClockOn = this.ClockOn,
                ClockPoint = this.ClockPoint,
                CruiseType = this.CruiseType,
                IssueEquipment = this.IssueEquipment,
                IssueEvents = this.IssueEvents,
                Issues = this.Issues,
                PatrolTime = this.PatrolTime,
                UnClockOn = this.UnClockOn,
            };
            decimal _Mileage = 0;
            decimal.TryParse(this.Mileage, out _Mileage);
            model.Mileage = _Mileage;
            return model;
        }
    }
}
