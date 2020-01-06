using SH3H.SDK.Share;
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
    /// 必达点打卡
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class CheckInPointOut
    {
        /// <summary>
        /// 巡查编号
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 必达点Id
        /// </summary>
        [DataMember(Name = "ckpId")]
        public string CKpId { get; set; }

        /// <summary>
        /// x坐标
        /// </summary>
        [DataMember(Name = "x")]
        public string X { get; set; }

        /// <summary>
        /// x坐标
        /// </summary>
        [DataMember(Name = "time")]
        public string Time { get; set; }

        /// <summary>
        /// y坐标
        /// </summary>
        [DataMember(Name = "y")]
        public string Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValidateResult Validate()
        {
            var result = new ValidateResult();

            int _ckpid = 0;
            int.TryParse(this.CKpId, out _ckpid);

            DateTime _date = new DateTime();
            DateTime.TryParse(this.Time, out _date);

            if (string.IsNullOrWhiteSpace(Id))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "任务编码为空！");
            if (_ckpid <= 0)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "必达点编码为空！");
            if (string.IsNullOrWhiteSpace(this.X))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "X坐标轴为空！");
            if (string.IsNullOrWhiteSpace(this.Y))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "Y坐标轴为空！");
            if (default(DateTime) == _date)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "Y时间为空！");

            return result;
        }
    }
}
