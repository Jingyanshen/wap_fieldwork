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
    /// 巡查小结
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolTaskSummaryOut
    {
        /// <summary>
        /// 
        /// </summary>
        public PatrolTaskSummaryOut()
        {
            CheckInPoints = new List<CheckInPoints>();
            PatrolPlanCounts = new List<PatrolPlanCount>();
        }
        /// <summary>
        /// 耗时
        /// </summary>
        [DataMember(Name = "elapsedTime")]
        public string ElapsedTime { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        [DataMember(Name = "odo")]
        public string Odo { get; set; }

        /// <summary>
        /// 上报数
        /// </summary>
        [DataMember(Name = "issueNum")]
        public string IssueNum { get; set; }

        /// <summary>
        /// 必达点列表
        /// </summary>
        [DataMember(Name = "checkInPoints")]
        public IEnumerable<CheckInPoints> CheckInPoints { get; set; }

        /// <summary>
        /// 巡查计划
        /// </summary>
        [DataMember(Name = "patrolPlanCounts")]
        public IEnumerable<PatrolPlanCount> PatrolPlanCounts { get; set; }
    }

    /// <summary>
    /// 必达点
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class CheckInPoints
    {

        /// <summary>
        /// 必达点编号
        /// </summary>
        [DataMember(Name = "ckPointId")]
        public string CKPointId { get; set; }

        /// <summary>
        /// 打卡状态  0:未打卡；1:已打卡
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// 打卡次数
        /// </summary>
        [DataMember(Name = "checkInNum")]
        public string CheckInNum { get; set; }

        /// <summary>
        /// 必达点名称
        /// </summary>
        [DataMember(Name = "ckPointName")]
        public string CkPointName { get; set; }

        /// <summary>
        /// x坐标
        /// </summary>
        [DataMember(Name = "x")]
        public string X { get; set; }

        /// <summary>
        /// y坐标
        /// </summary>
        [DataMember(Name = "y")]
        public string Y { get; set; }

        /// <summary>
        /// 等级  参见巡查等级词语
        /// </summary>
        [DataMember(Name = "grade")]
        public string Grade { get; set; }

        /// <summary>
        /// 类型  1:明点; 2:暗桩
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }


    /// <summary>
    /// 巡查计划
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolPlanCount
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember(Name = "startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember(Name = "endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// 计划巡查次数
        /// </summary>
        [DataMember(Name = "inspectNum")]
        public string InspectNum { get; set; }

        /// <summary>
        /// 已巡查次数
        /// </summary>
        [DataMember(Name = "complateNum")]
        public string ComplateNum { get; set; }

    }
}
