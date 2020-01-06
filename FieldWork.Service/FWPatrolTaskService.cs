using Newtonsoft.Json;
using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.Dto;
using SH3H.WAP.FieldWork.Model.ViewModels;
using SH3H.WAP.FieldWork.Share;
using SH3H.WAP.WorkSheet.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Service
{
    /// <summary>
    /// 巡查任务服务实现
    /// </summary>
    public class FWPatrolTaskServiceImpl : BaseService, IFWPatrolTaskService
    {
        private IFWPatrolTaskRepository _patrolTaskRepository;
        private IFWPatrolCKPointRepository _patrolCKPointRepository;
        private IFWPatrolTaskCKPointRepository _patrolTaskCKPointRepository;
        private IFWUserRepository _userRepository;
        private IWSSeqService _wsSeqService;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="patrolTaskRepository"></param>
        public FWPatrolTaskServiceImpl(IFWPatrolTaskRepository patrolTaskRepository,
            IWSSeqService wsSeqService,
            IFWPatrolCKPointRepository patrolCKPointRepository,
            IFWPatrolTaskCKPointRepository patrolTaskCKPointRepository,
            IFWUserRepository userRepository)
        {
            _patrolTaskRepository = patrolTaskRepository;
            _wsSeqService = wsSeqService;
            _patrolCKPointRepository = patrolCKPointRepository;
            _patrolTaskCKPointRepository = patrolTaskCKPointRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTaskDto CreateFWPatrolTask(FWPatrolTaskDto entity)
        {
            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务对象模型为空！");

            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();

            entity.ID = _wsSeqService.GetSeq("PT");

            if (string.IsNullOrWhiteSpace(entity.ID))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编号为空！");
            if (entity.ID.Length > 20)
                throw new WapException(StateCode.CODE_ARGUMENT_LENGTH, "巡查任务编号字符长度大于20！");

            return FWPatrolTaskDto.FromModel(_patrolTaskRepository.CreateFWPatrolTask(entity.ToModel()));
        }

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTaskDto UpdateFWPatrolTaskById(String id, FWPatrolTaskDto entity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编号为空！");
            if (id.Length > 20)
                throw new WapException(StateCode.CODE_ARGUMENT_LENGTH, "巡查任务编号字符长度大于20！");
            if (id != entity.ID)
                throw new WapException(StateCode.CODE_ARGUMENT_NOT_EQUAL, "巡查任务编号参数不一致！");

            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();

            return FWPatrolTaskDto.FromModel(_patrolTaskRepository.UpdateFWPatrolTaskById(id, entity.ToModel()));
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolTaskById(String id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编号为空！");
            }

            return _patrolTaskRepository.DeleteFWPatrolTaskById(id);
        }

        /// <summary>
        /// 获取全部模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskDto> GetFWPatrolTaskAll()
        {
            var result = _patrolTaskRepository.GetFWPatrolTaskAll();
            return result.Select(p => FWPatrolTaskDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWPatrolTaskDto GetFWPatrolTaskById(String id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编号为空！");
            }
            var result = _patrolTaskRepository.GetFWPatrolTaskById(id);
            return FWPatrolTaskDto.FromModel(result);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        public PaginationDto<FWPatrolTaskDto> QueryFWPatrolTaskPage(FWPatrolTaskPageDto queryPageDto)
        {
            if (queryPageDto == null)
            {
                queryPageDto = new FWPatrolTaskPageDto();
            }
            var result = _patrolTaskRepository.QueryFWPatrolTaskPage(queryPageDto);
            return new PaginationDto<FWPatrolTaskDto>()
            {
                DataList = result.DataList.Select(p => FWPatrolTaskDto.FromModel(p)).ToList(),
                TotalCount = result.TotalCount
            };
        }
        /// <summary>
        /// 获取当前任务的必达点和必达点状态
        /// </summary>
        /// <returns></returns>
        public PaginationDto<FWCKPointDto> GetFWCKPointDto(string id, FWCKPointPageDto queryDto)
        {

            if (queryDto == null)
            {
                queryDto = new FWCKPointPageDto();
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编号为空！");
            }
            var task = _patrolTaskRepository.GetFWPatrolTaskById(id);
            if (task == null)
            {
                return null;
            }
            var patrolStaff = task.PatrolStaff;
            if (string.IsNullOrEmpty(patrolStaff))
            {
                return null;
            }
            var patrolStaffArray = patrolStaff.Split(',');
            var usermodel = new FWUser();
            for (int i = 0; i < patrolStaffArray.Length; i++)
            {
                int usrId = 0;
                int.TryParse(patrolStaffArray[i], out usrId);

                if (usrId == 0)
                {
                    continue;
                }
                usermodel = _userRepository.GetFWUserById(usrId);
                if (usermodel != null)
                {
                    break;
                }
            }
            if (usermodel == null || usermodel.GridId <= 0)
            {
                return null;
            }
            var taskpoint = _patrolTaskCKPointRepository.GetFWPatrolTaskCKPointByTid(id);//当前任务必达点打卡数据
            if (taskpoint == null) return null;
            var ckpoint = _patrolCKPointRepository.GetPointByGridId(usermodel.GridId);//当前人员的所有必达点列表
            var result = new List<FWCKPointDto>();
            foreach (var item in ckpoint)
            {
                var getpoint = taskpoint.Where(p => p.CKPonitId == item.Id).FirstOrDefault();
                FWCKPointDto fckpointDto = new FWCKPointDto()
                {
                    CKPoint = new FWPatrolCKPointDto()
                    {
                        Address = item.Address,
                        CreateTime = item.CreateTime,
                        Creator = item.Creator,
                        Extend = item.Extend,
                        Frequency = item.Frequency,
                        Grade = item.Grade,
                        GridId = item.GridId,
                        Id = item.Id,
                        Name = item.Name,
                        Period = item.Period,
                        PeriodId = item.PeriodId,
                        Road = item.Road,
                        Tolerence = item.Tolerence,
                        Type = item.Type,
                        X = item.X,
                        Y = item.Y,
                    },
                    Id = item.Id
                };
                if (getpoint != null)
                {
                    fckpointDto.TaskCKPoint = new FWPatrolTaskCKPointDto()
                    {
                        CheckInNum = getpoint.CheckInNum,
                        CheckInTime = getpoint.CheckInTime,
                        CheckInX = getpoint.CheckInX,
                        CheckInY = getpoint.CheckInY,
                        CKPointName = getpoint.CKPointName,
                        CKPonitId = getpoint.CKPonitId,
                        PatrolType = getpoint.PatrolType,
                        Status = getpoint.Status,
                        TaskId = getpoint.TaskId,
                    };
                }
                else
                {
                    fckpointDto.TaskCKPoint = null;
                }
                result.Add(fckpointDto);
            }

            return new PaginationDto<FWCKPointDto>()
            {
                DataList = result.Where(p =>
                {
                    if (!string.IsNullOrWhiteSpace(queryDto.key))
                    {
                        return p.CKPoint.Name.Contains(queryDto.key);
                    }
                    return true;
                })
            .OrderByDescending(p => p.Id)
            .Skip(((queryDto.pageIndex - 1) * queryDto.pageSize))
            .Take(queryDto.pageSize).ToList(),
                TotalCount = ckpoint.Count()
            };
        }

        /// <summary>
        /// 结束巡查
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool EndPatrolTask(string id, string reason, DateTime dateTime)
        {
            var state = _patrolTaskRepository.GetPatrolTaskState(id);
            if (state)
                return true;
            else
                return _patrolTaskRepository.EndPatrolTask(id, reason,dateTime);

        }

        /// <summary>
        /// 获取巡查上报列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<FWIssueViewModel> GetIssuesByTaskId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编号为空！");
            return _patrolTaskRepository.GetIssuesByTaskId(id);
        }

        /// <summary>
        /// 获取当前任务的全部必达点和必达点状态
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWCKPointDto> GetFWCKPointDtoAll(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编号为空！");
            }
            var task = _patrolTaskRepository.GetFWPatrolTaskById(id);
            if (task == null)
            {
                return null;
            }
            int _Operator = 0;
            int.TryParse(task.Operator, out _Operator);
            if (_Operator == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务操作人为空！");

            var usermodel = _userRepository.GetFWUserById(_Operator);

            if (usermodel == null || usermodel.GridId <= 0)
            {
                return null;
            }
            var taskpoint = _patrolTaskCKPointRepository.GetFWPatrolTaskCKPointByTid(id);//当前任务必达点打卡数据
            if (taskpoint == null) return null;
            var ckpoint = _patrolCKPointRepository.GetPointByGridId(usermodel.GridId);//当前人员的所有必达点列表
            var result = new List<FWCKPointDto>();
            foreach (var item in ckpoint)
            {
                var getpoint = taskpoint.Where(p => p.CKPonitId == item.Id).FirstOrDefault();
                FWCKPointDto fckpointDto = new FWCKPointDto()
                {
                    CKPoint = new FWPatrolCKPointDto()
                    {
                        Address = item.Address,
                        CreateTime = item.CreateTime,
                        Creator = item.Creator,
                        Extend = item.Extend,
                        Frequency = item.Frequency,
                        Grade = item.Grade,
                        GridId = item.GridId,
                        Id = item.Id,
                        Name = item.Name,
                        Period = item.Period,
                        PeriodId = item.PeriodId,
                        Road = item.Road,
                        Tolerence = item.Tolerence,
                        Type = item.Type,
                        X = item.X,
                        Y = item.Y,
                    },
                    Id = item.Id
                };
                if (getpoint != null)
                {
                    fckpointDto.TaskCKPoint = new FWPatrolTaskCKPointDto()
                    {
                        CheckInNum = getpoint.CheckInNum,
                        CheckInTime = getpoint.CheckInTime,
                        CheckInX = getpoint.CheckInX,
                        CheckInY = getpoint.CheckInY,
                        CKPointName = getpoint.CKPointName,
                        CKPonitId = getpoint.CKPonitId,
                        PatrolType = getpoint.PatrolType,
                        Status = getpoint.Status,
                        TaskId = getpoint.TaskId,
                    };
                }
                else
                {
                    fckpointDto.TaskCKPoint = null;
                }
                result.Add(fckpointDto);
            }

            return result.OrderByDescending(p => p.Id).ToList();
        }


        /// <summary>
        /// 获取人员巡查历史
        /// </summary>
        /// <param name="user"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count"></param>
        /// <param name="since"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskDto> GetFWPatrolTaskHistory(string user, DateTime start, DateTime end, int count, int since)
        {

            if (string.IsNullOrWhiteSpace(user))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "人员编号为空！");
            var result = _patrolTaskRepository.GetFWPatrolTaskHistory(user, start, end, count, since);
            return result.Select(p => FWPatrolTaskDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 获取指定巡查任务的结束状态
        /// </summary>
        /// <returns></returns>
        public bool GetPatrolTaskState(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编码为空！");
            return _patrolTaskRepository.GetPatrolTaskState(id);
        }

    }
}
