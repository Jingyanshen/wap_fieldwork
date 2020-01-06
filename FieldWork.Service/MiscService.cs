using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.SDK.Definition.Exceptions;
using SH3H.WAP.FieldWork.Share;

namespace SH3H.WAP.FieldWork.Service
{
    public class MiscService : BaseService, IMiscService
    {
        private IMiscRepository _miscRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="miscRepository"></param>
        public MiscService(IMiscRepository miscRepository)
        {
            _miscRepository = miscRepository;
        }

        /// <summary>
        /// 根据工单编号获取到场时间
        /// </summary>
        /// <param name="TaskId">工单编号</param>
        /// <returns></returns>
        public string GetArriveTimeById(string TaskId)
        {
            if (TaskId == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");
            return _miscRepository.GetArriveTimeById(TaskId);
        }


        public List<string> GetBWFPLHB()
        {
            return _miscRepository.GetBWFPLHB();
        }

        public bool UpdateBWFPLHB(string TaskId)
        {
            return _miscRepository.UpdateBWFPLHB(TaskId);
        }

        public MeterNew GetFields(string TaskId, string Table)
        {
            return _miscRepository.GetFields(TaskId, Table);
        }

        public string GetTable(string TaskId)
        {
            int TypeId = _miscRepository.GetTaskType(TaskId);
            return _miscRepository.GetTable(TypeId);
        }
    }
}
