using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class FWPatrolTaskExtendImpl : BaseService, IFWPatrolTaskExtendService
    {
        /// <summary>
        /// 
        /// </summary>
        private IFWPatrolTaskExtendRepository _patrolTaskExtendRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patrolTaskExtendRepository"></param>
        public FWPatrolTaskExtendImpl(IFWPatrolTaskExtendRepository patrolTaskExtendRepository)
        {
            _patrolTaskExtendRepository = patrolTaskExtendRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public FWPatrolTaskSummaryDto GetFWPatrolTaskSummary(string taskid)
        {
            if (string.IsNullOrWhiteSpace(taskid))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "任务编号不能为空！");
            var result = _patrolTaskExtendRepository.GetFWPatrolTaskSummary(taskid);
            return FWPatrolTaskSummaryDto.FromModel(result);
        }

        /// <summary>
        /// /获取个人巡查概况
        /// </summary>
        /// <param name="user"></param>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolIndivDto> GetFWPatrolIndivDto(string user, string timeDim)
        {
            int _user = 0;
            int.TryParse(user, out _user);
            if (_user == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "用户编码为空！");

            if (string.IsNullOrWhiteSpace(timeDim))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "时间维度参数为空！");

            if (timeDim.ToLower() != "day" && timeDim.ToLower() != "week" && timeDim.ToLower() != "month")
                throw new WapException(StateCode.CODE_ARGUMENT_LIMIT_ERROR, "时间维度取值范围错误！");

            return _patrolTaskExtendRepository.GetFWPatrolIndivDto(user, timeDim);
        }

        /// <summary>
        /// 获取巡查概况（管理者）
        /// </summary>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolManageDto> GetFWPatrolManageDto(string user, string timeDim)
        {
            int _user = 0;
            int.TryParse(user, out _user);

            if (_user == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "管理用户编码为空！");
            if (string.IsNullOrWhiteSpace(timeDim))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "时间纬度参数为空！");

            if (timeDim.ToLower() != "day" && timeDim.ToLower() != "week" && timeDim.ToLower() != "month")
                throw new WapException(StateCode.CODE_ARGUMENT_LIMIT_ERROR, "时间维度取值范围错误！");

            //TODO:这判断用户是不是管理员，如果不是则不能查看
            var getappsetting = System.Configuration.ConfigurationSettings.AppSettings["WAP_PATROLTASK_MANAGE_ROLE"];
            var manageRole = "";
            if (getappsetting != null)
            {
                manageRole = getappsetting.ToString();
            }
            var getusers = ServiceFactory.GetService<IFWWapUserAndRoleService>().GetFWWapUserAndRoleDtoAll(manageRole);
            var checkUser = getusers.Where(p => p.UserId == _user).ToList();
            if (checkUser == null)
            {
                throw new WapException(StateCode.CODE_USER_NO_AUTHORITY, "该用户不在可查看数据的权限范围内！");
            }
            return _patrolTaskExtendRepository.GetFWPatrolManageDto(_user, timeDim);
        }

        /// <summary>
        /// 获取计划任务计划小结
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolPlanSummaryDto> GetFWPatrolPlanSummaryDto(string taskid)
        {
            if (string.IsNullOrWhiteSpace(taskid))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编码为空！");
            return _patrolTaskExtendRepository.GetFWPatrolPlanSummaryDto(taskid);
        }
    }
}
