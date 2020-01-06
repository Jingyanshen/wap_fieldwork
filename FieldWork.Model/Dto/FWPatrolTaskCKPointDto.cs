using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolTaskCKPointDto
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        [DataMember(Name = "taskId")]
        public String TaskId { get; set; }

        /// <summary>
        /// 必达点编号
        /// </summary>
        [DataMember(Name = "ckponitId")]
        public int CKPonitId { get; set; }

        /// <summary>
        /// 打卡状态
        /// </summary>
        [DataMember(Name = "status")]
        public bool Status { get; set; }

        /// <summary>
        /// 打卡次数
        /// </summary>
        [DataMember(Name = "checkInNum")]
        public int CheckInNum { get; set; }

        /// <summary>
        /// 打卡时间
        /// </summary>
        [DataMember(Name = "checkInTime")]
        public DateTime CheckInTime { get; set; }

        /// <summary>
        /// 打卡点X坐标
        /// </summary>
        [DataMember(Name = "checkInX")]
        public decimal CheckInX { get; set; }

        /// <summary>
        /// 打卡点Y坐标
        /// </summary>
        [DataMember(Name = "checkInY")]
        public decimal CheckInY { get; set; }

        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember(Name = "patrolType")]
        public int PatrolType { get; set; }

        /// <summary>
        /// 必达点名称
        /// </summary>
        [DataMember(Name = "ckpointName")]
        public string CKPointName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FWPatrolTaskCKPointDto FromModel(FWPatrolTaskCKPoint model)
        {
            if (model == null)
            {
                return null;
            }
            return new FWPatrolTaskCKPointDto()
            {
                CheckInNum = model.CheckInNum,
                CheckInTime = model.CheckInTime,
                CheckInX = model.CheckInX,
                CheckInY = model.CheckInY,
                CKPonitId = model.CKPonitId,
                Status = model.Status,
                TaskId = model.TaskId,

                CKPointName = model.CKPointName,
                PatrolType = model.PatrolType,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FWPatrolTaskCKPoint ToModel()
        {
            return new FWPatrolTaskCKPoint()
            {
                CheckInNum = this.CheckInNum,
                CheckInTime = this.CheckInTime,
                CheckInX = this.CheckInX,
                CheckInY = this.CheckInY,
                CKPonitId = this.CKPonitId,
                Status = this.Status,
                TaskId = this.TaskId,


                CKPointName = this.CKPointName,
                PatrolType = this.PatrolType,
            };
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public ValidateResult Validate()
        {
            var result = new ValidateResult();
            if (string.IsNullOrWhiteSpace(this.TaskId))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "任务编号为空！");
            if (this.TaskId.Length > 20)
                result.AddError(StateCode.CODE_ARGUMENT_LENGTH, "任务编号字符长度大于20！");
            if (this.CKPonitId <= 0)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "必达点编号为空！");

            return result;
        }
    }
}
