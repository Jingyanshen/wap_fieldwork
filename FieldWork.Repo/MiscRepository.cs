using SH3H.SDK.DataAccess.Repo;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo
{
    public class MiscRepository : Repository<IMiscStorage>, IMiscRepository
    {
        public string GetArriveTimeById(string TaskId)
        {
            return Storage.GetArriveTimeById(TaskId);
        }

        public List<string> GetBWFPLHB()
        {
            return Storage.GetBWFPLHB();
        }

        public bool UpdateBWFPLHB(string TaskId)
        {
            return Storage.UpdateBWFPLHB(TaskId);
        }

        public MeterNew GetFields(string TaskId , string Table)
        {
            return Storage.GetFields(TaskId, Table);
        }

        /// <summary>
        /// 根据工单编号获取工单类型
        /// </summary>
        /// <returns></returns>
        public int GetTaskType(string TaskId)
        {
            return Storage.GetTaskType(TaskId);
        }

        /// <summary>
        /// 根据工单类型获取表单
        /// </summary>
        /// <returns></returns>
        public string GetTable(int TypeId)
        {
            return Storage.GetTable(TypeId);
        }
    }
}
