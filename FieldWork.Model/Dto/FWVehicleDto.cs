using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace SH3H.WAP.FieldWork.Model.Dto
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWVehicleDto : DtoBase<FWVehicle, FWVehicleDto>
    {
        [DataMember(Name = "vehicleNo")]
        public string VehicleNo { get; set; }

        [DataMember(Name = "type")]
        public int Type { get; set; }

        [DataMember(Name = "stationId")]
        public int StationId { get; set; }

        [DataMember(Name = "stationName")]
        public string StationName { get; set; }

        [DataMember(Name = "driver")]
        public string Driver { get; set; }

        [DataMember(Name = "driverName")]
        public string DriverName { get; set; }

        [DataMember(Name = "active")]
        public bool Active { get; set; }
    }
}
