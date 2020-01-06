using SH3H.SDK.Share;
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
    /// 巡查任务对象
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolTaskDto
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        [DataMember(Name = "id")]
        public String ID { get; set; }

        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember(Name = "patrolType")]
        public int PatrolType { get; set; }

        /// <summary>
        /// 巡查方式
        /// </summary>
        [DataMember(Name = "cruiseType")]
        public int CruiseType { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember(Name = "operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 巡查人，英文逗号分隔
        /// </summary>
        [DataMember(Name = "patrolStaff")]
        public string PatrolStaff { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember(Name = "startTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember(Name = "endTime")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 结束原因
        /// </summary>
        [DataMember(Name = "endReason")]
        public String EndReason { get; set; }

        /// <summary>
        /// 所属网格
        /// </summary>
        [DataMember(Name = "gridId")]
        public int GridId { get; set; }

        /// <summary>
        /// 所属计划
        /// </summary>
        [DataMember(Name = "planId")]
        public String PlanId { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        [DataMember(Name = "driver")]
        public string Driver { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        [DataMember(Name = "vehicleNo")]
        public string VehicleNo { get; set; }


        //网格信息

        /// <summary>
        /// 网格名称
        /// </summary>
        [DataMember(Name = "gridName")]
        public String GridName { get; set; }



        /// <summary>
        /// 模型转对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FWPatrolTaskDto FromModel(FWPatrolTask model)
        {
            if (model == null)
            {
                return null;
            }
            return new FWPatrolTaskDto()
            {
                EndReason = model.EndReason,
                EndTime = model.EndTime,
                GridId = model.GridId,
                ID = model.ID,
                PatrolType = model.PatrolType,
                PlanId = model.PlanId,
                StartTime = model.StartTime,
                CruiseType = model.CruiseType,
                Driver = model.Driver,
                Operator = model.Operator,
                PatrolStaff = model.PatrolStaff,
                VehicleNo = model.VehicleNo,

                GridName = model.GridName,
            };
        }

        /// <summary>
        /// 对象转模型
        /// </summary>
        /// <returns></returns>
        public FWPatrolTask ToModel()
        {
            return new FWPatrolTask()
            {
                EndReason = this.EndReason,
                EndTime = this.EndTime,
                GridId = this.GridId,
                ID = this.ID,
                PatrolType = this.PatrolType,
                PlanId = this.PlanId,
                StartTime = this.StartTime,
                CruiseType = this.CruiseType,
                Driver = this.Driver,
                Operator = this.Operator,
                PatrolStaff = this.PatrolStaff,
                VehicleNo = this.VehicleNo,

                GridName = this.GridName,
            };
        }

        /// <summary>
        /// 字段验证
        /// </summary>
        /// <returns></returns>
        public ValidateResult Validate()
        {
            var result = new ValidateResult();

            if (this.PatrolType <= 0)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查类型不能为空！");
            if (string.IsNullOrWhiteSpace(this.Operator))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "操作人不能为空！");
            if (string.IsNullOrWhiteSpace(this.PatrolStaff))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查人不能为空！");
            if (this.StartTime == default(DateTime))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "开始时间不能为空！");
            if (!string.IsNullOrWhiteSpace(this.EndReason) && this.EndReason.Length > 50)
                result.AddError(StateCode.CODE_ARGUMENT_LENGTH, "结束原因字符长度不能大于50！");
            if (this.GridId <= 0)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "所属网格不能为空！");
            if (!string.IsNullOrWhiteSpace(this.PlanId) && this.PlanId.Length > 20)
                result.AddError(StateCode.CODE_ARGUMENT_LENGTH, "所属计划字符长度不能大于20！");
            if (this.CruiseType <= 0)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查方式不能为空！");

            var patrolStaffArray = this.PatrolStaff.Split(',');
            patrolStaffArray.Where(p => p == this.Operator.Trim()).ToList();
            if (patrolStaffArray == null || patrolStaffArray.Count() == 0)
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "操作人不属于本次任务的巡查人员！");
            }

            return result;
        }
    }
}
