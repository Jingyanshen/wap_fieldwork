using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWVehicle
    {
        public string VehicleNo { get; set; }
        public int Type { get; set; }
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string Driver { get; set; }
        public string DriverName { get; set; }
        public bool Active { get; set; }
    }
}
