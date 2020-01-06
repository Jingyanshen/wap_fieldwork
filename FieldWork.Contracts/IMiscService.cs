using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IMiscService
    {
        /// <summary>
        /// 根据工单编号获取到场时间
        /// </summary>
        /// <param name="TaskId">工单编号</param>
        /// <returns></returns>
        string GetArriveTimeById(string TaskId);

        List<string> GetBWFPLHB();

        bool UpdateBWFPLHB(string TaskId);

        MeterNew GetFields(string TaskId, string Table);

        string GetTable(string TaskId);
    }
}
