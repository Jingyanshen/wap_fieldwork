using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Helper
{
    public class PatrolHostLog
    {

        public string SEND_TYPE { get; set; }
        public DateTime SEND_TIME { get; set; }
        public string SEND_DATA { get; set; }
        public int SEND_STATUS { get; set; }
        public string SEND_TOUSER { get; set; }
        public Guid SEND_GUID { get; set; }
        public string SEND_APPLICATION { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime END_TIME { get; set; }

    }
}
