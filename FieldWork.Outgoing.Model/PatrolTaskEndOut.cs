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
    /// 巡查结束
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolTaskEndOut
    {
        /// <summary>
        /// 巡查编号
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 结束原因
        /// </summary>
        [DataMember(Name = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember(Name = "endTime")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValidateResult Validate()
        {
            var result = new ValidateResult();
            if (string.IsNullOrWhiteSpace(this.Id))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查任务编码为空！");
            if (string.IsNullOrWhiteSpace(this.Reason))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "结束原因为空！");
            if (this.EndTime == null || this.EndTime == default(DateTime))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "结束时间为空！");

            return result;
        }
    }
}
