using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.DataAccess
{
    public interface IMiscStorage
    {
        /// <summary>
        /// 根据工单编号获取到场时间
        /// </summary>
        /// <param name="TaskId">工单编号</param>
        /// <returns></returns>
        string GetArriveTimeById(string TaskId);

        /// <summary>
        /// 获取换表失败工单
        /// </summary>
        /// <returns></returns>
        List<string> GetBWFPLHB();

        /// <summary>
        /// 根据换表失败工单编号更换状态
        /// </summary>
        /// <returns></returns>
        bool UpdateBWFPLHB(string TaskId);

        /// <summary>
        /// 根据换表工单编号获取所需字段
        /// </summary>
        /// <returns></returns>
        MeterNew GetFields(string TaskId, string Table);
        
        /// <summary>
        /// 根据工单编号获取工单类型
        /// </summary>
        /// <returns></returns>
        int GetTaskType(string TaskId);

        /// <summary>
        /// 根据工单类型获取表单
        /// </summary>
        /// <returns></returns>
        string GetTable(int TypeId);

    }
}
