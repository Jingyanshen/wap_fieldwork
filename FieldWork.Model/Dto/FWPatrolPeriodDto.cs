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
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWord")]
    public class FWPatrolPeriodDto
    {
        /// <summary>
        /// 周期编号
        /// </summary>
        [DataMember(Name = "periodId")]
        public int PeriodId { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FWPatrolPeriodDto FromModel(FWPatrolPeriod model)
        {
            if (model == null)
            {
                return null;
            }
            return new FWPatrolPeriodDto()
            {
                PeriodId = model.PeriodId,
                PeriodBase = model.PeriodBase,
                Interval = model.Interval,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FWPatrolPeriod ToModel()
        {
            return new FWPatrolPeriod()
            {
                PeriodId = this.PeriodId,
                PeriodBase = this.PeriodBase,
                Interval = this.Interval,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValidateResult Validate()
        {
            var result = new ValidateResult();

            if (this.PeriodBase < 0)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "周期编号为空！");
            if (this.Interval < 0)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "周期编号为空！");

            return result;
        }
    }
}
