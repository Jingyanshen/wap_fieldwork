using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model
{
    /// <summary>
    /// 巡查任务开始表单提交对象
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolTaskStartOut
    {
        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember(Name = "patrolType")]
        public string PatrolType { get; set; }

        /// <summary>
        /// 巡查方式
        /// </summary>
        [DataMember(Name = "cruiseType")]
        public string CruiseType { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember(Name = "operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 巡查人
        /// </summary>
        [DataMember(Name = "patrolStaff")]
        public string PatrolStaff { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember(Name = "startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// 网格
        /// </summary>
        [DataMember(Name = "grid")]
        public string Grid { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static PatrolTaskStartOut FromDto(FWPatrolTaskDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new PatrolTaskStartOut()
            {
                CruiseType = dto.CruiseType.ToString(),
                Driver = dto.Driver,
                Grid = dto.GridId.ToString(),
                VehicleNo = dto.VehicleNo,
                StartTime = dto.StartTime.ToString("yyyy-MM-dd hh:mm:ss"),
                PatrolType = dto.PatrolType.ToString(),
                PatrolStaff = dto.PatrolStaff,
                Operator = dto.Operator,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FWPatrolTaskDto ToDto()
        {
            return new FWPatrolTaskDto()
            {
                CruiseType = Convert.ToInt32(this.CruiseType),
                Driver = this.Driver,
                GridId = Convert.ToInt32(this.Grid),
                VehicleNo = this.VehicleNo,
                StartTime = Convert.ToDateTime(this.StartTime),
                PatrolType = Convert.ToInt32(this.PatrolType),
                PatrolStaff = this.PatrolStaff,
                Operator = this.Operator,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValidateResult Validate()
        {
            var result = new ValidateResult();
            if (string.IsNullOrWhiteSpace(this.CruiseType))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查方式为空！");
            //if (string.IsNullOrWhiteSpace(this.Driver))
            //    result.AddError(StateCode.CODE_ARGUMENT_NULL, "司机为空！");
            if (string.IsNullOrWhiteSpace(this.Grid))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "网格为空！");
            if (string.IsNullOrWhiteSpace(this.Operator))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "操作人为空！");
            if (string.IsNullOrWhiteSpace(this.PatrolStaff))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查人为空！");
            if (string.IsNullOrWhiteSpace(this.PatrolType))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查类型为空！");
            if (string.IsNullOrWhiteSpace(this.StartTime))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "开始时间为空！");
            //if (string.IsNullOrWhiteSpace(this.VehicleNo))
            //    result.AddError(StateCode.CODE_ARGUMENT_NULL, "车牌号为空！");

            return result;
        }

    }


    /// <summary>
    /// 返回对象
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/WorkSheet")]
    public class PatrolTaskResult
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }


}
