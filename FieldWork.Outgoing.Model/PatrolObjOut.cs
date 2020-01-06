using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model
{
    /// <summary>
    /// 巡查对象
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolObjOut
    {
        /// <summary>
        /// 对象编号
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 对象名称
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

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
        /// 等级
        /// </summary>
        [DataMember(Name = "grade")]
        public string Grade { get; set; }

        /// <summary>
        /// 所在网格
        /// </summary>
        [DataMember(Name = "gridId")]
        public string GridId { get; set; }

        /// <summary>
        /// 巡查频次
        /// </summary>
        [DataMember(Name = "frequency")]
        public string Frequency { get; set; }

        /// <summary>
        /// 便于用户识别的编号
        /// </summary>
        [DataMember(Name = "displayId")]
        public string DisplayId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static PatrolObjOut FromDto(FWPatrolObjectDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new PatrolObjOut()
            {
                Id = dto.ID.ToString(),
                Name = dto.Name,
                Address = dto.Address,
                X = dto.X.ToString(),
                Y = dto.Y.ToString(),
                Grade = dto.Grade.ToString(),
                GridId = dto.GridId.ToString(),
                Frequency = dto.Frequency.ToString(),
                DisplayId = dto.DisplayId
            };
        }
    }
}
