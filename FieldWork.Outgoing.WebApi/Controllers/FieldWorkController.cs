using FieldWork.Outgoing.Model;
using FieldWork.Outgoing.Model.Common;
using FieldWork.Outgoing.WebApi.Response;
using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SH3H.SDK.Definition.Exceptions;
using SH3H.WAP.FieldWork.Share;
using SH3H.SDK.WebApi.Controllers;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using SH3H.WAP.FieldWork.Model.ViewModels;
using SH3H.WAP.FieldWork.Model;
using SH3H.SDK.Infrastructure.Logging;

namespace FieldWork.Outgoing.WebApi.Controllers
{
    /// <summary>
    /// 外业系统标准API服务
    /// </summary>
    [RoutePrefix("fw/v1")]
    public class FieldWorkController : BaseController
    {
        #region =============================巡查相关=============================

        #region 巡查开始
        /// <summary>
        /// 巡查开始
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("patrol/start")]
        public WapOutgoingResponse<PatrolTaskResult> StartPatrolTask([FromBody]PatrolTaskStartOut model)
        {
            //验证
            var validate = model.Validate();
            if (!validate.IsValid)
                throw validate.BuildException();

            //提交
            var result = ServiceFactory.GetService<IFWPatrolTaskService>().CreateFWPatrolTask(model.ToDto());

            //赋值
            PatrolTaskResult patrolTaskOut = new PatrolTaskResult()
            {
                Id = result.ID,
            };

            //返回任务Id
            return new WapOutgoingResponse<PatrolTaskResult>(patrolTaskOut);
        }
        #endregion

        #region 巡查结束

        /// <summary>
        /// 巡查结束
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        [Route("patrol/end")]
        public WapOutgoingResponse<DBNull> StartPatrolTask([FromBody]PatrolTaskEndOut model)
        {
            if (model == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "参数为空！");
            var validate = model.Validate();
            if (!validate.IsValid)
                throw validate.BuildException();

            ServiceFactory.GetService<IFWPatrolTaskService>().EndPatrolTask(model.Id, model.Reason,model.EndTime);
            return new WapOutgoingResponse<DBNull>(null);
        }

        #endregion

        #region 获取巡查上报列表

        /// <summary>
        /// 获取巡查上报列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/{id}/issue")]
        public WapOutgoingResponse<List<IssueOut>> GetIssuesByTaskId(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "上报列表编码为空！");

            var issues = ServiceFactory.GetService<IFWPatrolTaskService>().GetIssuesByTaskId(id);
            var outs = new List<IssueOut>();
            issues.ToList().ForEach(x =>
            {
                if (null != x)
                {
                    var _out = new IssueOut
                    {
                        Id = x.Id,
                        Type = x.Type.ToString(),
                        TypeName = x.TypeName,
                        IsBatch = x.IsBatch.ToString(),
                        Address = x.Address,
                        Comment = x.Comment,
                        Location = JsonConvert.DeserializeObject<Location>(x.Location),
                        Status = x.Status.ToString(),
                        Time = x.Time.ToString()
                    };
                    outs.Add(_out);
                }
            });
            return new WapOutgoingResponse<List<IssueOut>>(outs);
        }

        #endregion

        #region 获取巡查小结

        /// <summary>
        /// 获取巡查小结
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/{id}/summary")]
        public WapOutgoingResponse<PatrolTaskSummaryOut> GetPatrolTaskSummary(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查任务编号为空！");
            PatrolTaskSummaryOut patrolTaskSummaryOut = new PatrolTaskSummaryOut();

            //必达点,必达点打卡
            var getTaskCKPoint = ServiceFactory.GetService<IFWPatrolTaskService>().GetFWCKPointDtoAll(id);
            //巡查计划
            var planCount = ServiceFactory.GetService<IFWPatrolTaskExtendService>().GetFWPatrolPlanSummaryDto(id);
            //巡查小结
            var getTaskSummary = ServiceFactory.GetService<IFWPatrolTaskExtendService>().GetFWPatrolTaskSummary(id);
            if (getTaskSummary != null)
            {
                patrolTaskSummaryOut.ElapsedTime = getTaskSummary.PatrolTime;
                patrolTaskSummaryOut.IssueNum = getTaskSummary.Issues.ToString();
                patrolTaskSummaryOut.Odo = getTaskSummary.Mileage.ToString();
                List<CheckInPoints> list = new List<CheckInPoints>();
                List<PatrolPlanCount> listPlan = new List<PatrolPlanCount>();
                if (getTaskCKPoint != null)
                {
                    foreach (var item in getTaskCKPoint)
                    {
                        CheckInPoints checkInPoints = new CheckInPoints()
                        {
                            Type = item.CKPoint.Type.ToString(),
                            Grade = item.CKPoint.Grade.ToString(),
                            CkPointName = item.CKPoint.Name,
                            CKPointId = item.CKPoint.Id.ToString(),
                        };
                        if (item.TaskCKPoint != null)
                        {
                            checkInPoints.CheckInNum = item.TaskCKPoint.CheckInNum.ToString();
                            checkInPoints.Status = item.TaskCKPoint.Status ? "1" : "0";
                            checkInPoints.X = item.TaskCKPoint.CheckInX.ToString();
                            checkInPoints.Y = item.TaskCKPoint.CheckInY.ToString();
                        }
                        else
                        {
                            checkInPoints.CheckInNum = "0";
                            checkInPoints.Status = "0";
                            checkInPoints.X = "";
                            checkInPoints.Y = "";
                        }
                        list.Add(checkInPoints);
                    }
                }
                if (planCount != null && planCount.Count() > 0)
                {

                    foreach (var item in planCount)
                    {
                        PatrolPlanCount patrolPlanCount = new PatrolPlanCount()
                        {
                            ComplateNum = item.ComplateNum.ToString(),
                            EndTime = item.PlanEndTime.ToString("yyyy-MM-dd hh:mm:ss"),
                            InspectNum = item.InspectNum.ToString(),
                            StartTime = item.PlanStartTime.ToString("yyyy-MM-dd hh:mm:ss"),
                        };
                        listPlan.Add(patrolPlanCount);
                    }
                }
                patrolTaskSummaryOut.CheckInPoints = list;
                patrolTaskSummaryOut.PatrolPlanCounts = listPlan;

                return new WapOutgoingResponse<PatrolTaskSummaryOut>(patrolTaskSummaryOut);
            }
            else
            {
                patrolTaskSummaryOut.ElapsedTime = "";
                patrolTaskSummaryOut.IssueNum = "";
                patrolTaskSummaryOut.Odo = "";
                return new WapOutgoingResponse<PatrolTaskSummaryOut>(null);
            }


        }
        #endregion

        #region 获取巡查概况(个人）

        /// <summary>
        /// 获取巡查概况（个人）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/indiv_summary")]
        public WapOutgoingResponse<PatrolIndivOut> GetPatrolSummaryPersonal(string user, string timeDim)
        {
            int _user = 0;
            int.TryParse(user, out _user);
            if (_user == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "用户编码为空！");

            if (string.IsNullOrWhiteSpace(timeDim))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "时间维度取值为空！");
            if (timeDim.ToLower() != "day" && timeDim.ToLower() != "week" && timeDim.ToLower() != "month")
                throw new WapException(StateCode.CODE_ARGUMENT_LIMIT_ERROR, "时间维度取值范围错误！");

            PatrolIndivOut patrolIndivOut = new PatrolIndivOut();
            var result = ServiceFactory.GetService<IFWPatrolTaskExtendService>().GetFWPatrolIndivDto(user, timeDim);
            if (result != null && result.Count() > 0)
            {
                patrolIndivOut.PatrolNum = result.First().PatrolNum.ToString();

                patrolIndivOut.Odo = (result.First().Odo > 0 ? (result.First().Odo / 1000) : 0).ToString("#0.00");
                var issueNum = 0;

                foreach (var item in result)
                {
                    if (item.Num > 0)
                    {
                        issueNum += item.Num;
                        var issueDetail = new IssueDetailOut()
                        {
                            Issue = string.IsNullOrEmpty(item.Issue) ? "" : item.Issue,
                            Num = item.Num.ToString()
                        };
                        patrolIndivOut.IssueDetail.Add(issueDetail);
                    }
                }

                patrolIndivOut.IssueNum = issueNum.ToString();

                return new WapOutgoingResponse<PatrolIndivOut>(patrolIndivOut);

            }
            else
            {
                patrolIndivOut.IssueNum = "";
                patrolIndivOut.Odo = "";
                patrolIndivOut.PatrolNum = "";

                return new WapOutgoingResponse<PatrolIndivOut>(null);

            }
        }
        #endregion

        #region 获取巡查概况(管理者）

        /// <summary>
        /// 获取巡查概况（管理）
        /// </summary>
        /// <param name="user"></param>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/manage_summary")]
        public WapOutgoingResponse<List<PatrolManageOut>> GetPatrolManageOut(string user, string timeDim)
        {
            int _user = 0;
            int.TryParse(user, out _user);

            if (_user == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "用户标识为空！");

            if (string.IsNullOrWhiteSpace(timeDim))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "时间维度取值为空！");
            if (timeDim.ToLower() != "day" && timeDim.ToLower() != "week" && timeDim.ToLower() != "month")
                throw new WapException(StateCode.CODE_ARGUMENT_LIMIT_ERROR, "时间维度取值范围错误！");

            var result = ServiceFactory.GetService<IFWPatrolTaskExtendService>().GetFWPatrolManageDto(user, timeDim);
            List<PatrolManageOut> list = new List<PatrolManageOut>();

            if (result != null && result.Count() > 0)
            {
                foreach (var item in result)
                {
                    PatrolManageOut patrolManageOut = new PatrolManageOut();
                    patrolManageOut.IssueNum = item.IssueNum.ToString();
                    patrolManageOut.Odo = (item.Odo > 0 ? (item.Odo / 1000) : 0).ToString("#0.00");
                    patrolManageOut.PatrolNum = item.PatrolNum.ToString();
                    patrolManageOut.PatrolStaff = item.PatrolStaff;
                    list.Add(patrolManageOut);
                }
            }

            return new WapOutgoingResponse<List<PatrolManageOut>>(list);
        }

        #endregion

        #region 获取巡查历史

        /// <summary>
        /// 获取巡查历史
        /// </summary>
        /// <param name="user"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count"></param>
        /// <param name="since"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/history")]
        public WapOutgoingResponse<List<PatrolTaskOut>> GetTaskPatrolHistory(string user, DateTime? start = null, DateTime? end = null, int? count = null, int? since = null)
        {
            if (string.IsNullOrEmpty(user))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "人员编号为空！");

            DateTime _start = new DateTime();
            DateTime _end = new DateTime();
            if (start != null)
            {
                _start = start.Value;
            }
            if (end != null)
            {
                _end = end.Value;
            }
            int _count = 0;
            int _since = 0;
            if (count != null)
            {
                _count = count.Value;
            }
            if (since != null)
            {
                _since = since.Value;
            }

            var result = ServiceFactory.GetService<IFWPatrolTaskService>().GetFWPatrolTaskHistory(user, _start, _end, _count, _since);
            List<PatrolTaskOut> list = new List<PatrolTaskOut>();
            foreach (var item in result)
            {
                PatrolTaskOut patrolTaskOut = new PatrolTaskOut()
                {
                    CruiseType = item.CruiseType.ToString(),
                    Driver = string.IsNullOrEmpty(item.Driver) ? "" : item.Driver,
                    EndTime = item.EndTime.ToString("yyyy-MM-dd hh:mm:ss"),
                    Grid = item.GridId.ToString(),
                    Id = item.ID,
                    Operator = item.Operator,
                    PatrolStaff = item.PatrolStaff,
                    PatrolType = item.PatrolType.ToString(),
                    StartTime = item.StartTime.ToString("yyyy-MM-dd hh:mm:ss"),
                    VehicleNo = string.IsNullOrEmpty(item.VehicleNo) ? "" : item.VehicleNo,
                };
                list.Add(patrolTaskOut);
            }
            return new WapOutgoingResponse<List<PatrolTaskOut>>(list);
        }

        #endregion

        #region 批量设施上报

        /// <summary>
        /// 批量设施上报
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("issue/batch")]
        public WapOutgoingResponse<string> BatchReport([FromBody]BatchReportViewModel entity)
        {
            if (null == entity)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "批量上报模型对象为空！");

            var issueId = ServiceFactory.GetService<IFWPatrolObjectReportService>().BatchReport(entity);

            return new WapOutgoingResponse<string>(issueId);
        }
        #endregion

        #region 必达点打卡

        /// <summary>
        /// 必达点打卡
        /// </summary>
        [HttpPost]
        [Route("patrol/ckpoint")]
        public WapOutgoingResponse<DBNull> PatrolCKPoint([FromBody]CheckInPointOut entity)
        {


            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "必达点打卡对象为空！");

            var validate = entity.Validate();

            if (!validate.IsValid)
                throw validate.BuildException();

            var ckpointId = Convert.ToInt32(entity.CKpId);
            var getPatrolTaskCKPoint = ServiceFactory.GetService<IFWPatrolTaskCKPointService>().GetFWPatrolTaskCKPointByTidAndCkPId(entity.Id, ckpointId);
            FWPatrolTaskCKPointDto dto = new FWPatrolTaskCKPointDto();

            if (getPatrolTaskCKPoint != null)
            {
                //update
                dto.TaskId = getPatrolTaskCKPoint.TaskId;
                dto.CheckInNum = getPatrolTaskCKPoint.CheckInNum + 1;
                dto.CheckInTime = Convert.ToDateTime(entity.Time);
                dto.CheckInX = Convert.ToDecimal(entity.X);
                dto.CheckInY = Convert.ToDecimal(entity.Y);
                dto.CKPonitId = getPatrolTaskCKPoint.CKPonitId;
                dto.Status = true;

                ServiceFactory.GetService<IFWPatrolTaskCKPointService>().UpdateFWPatrolTaskCKPointById(entity.Id, ckpointId, dto);
            }
            else
            {
                //insert
                dto.TaskId = entity.Id;
                dto.CheckInNum = 1;
                dto.CheckInTime = Convert.ToDateTime(entity.Time);
                dto.CheckInX = Convert.ToDecimal(entity.X);
                dto.CheckInY = Convert.ToDecimal(entity.Y);
                dto.CKPonitId = Convert.ToInt32(entity.CKpId);
                dto.Status = true;

                ServiceFactory.GetService<IFWPatrolTaskCKPointService>().CreateFWPatrolTaskCKPoint(dto);
            }
            return new WapOutgoingResponse<DBNull>(null);
        }

        #endregion

        #region 获取巡查对象列表

        /// <summary>
        ///  获取巡查对象列表
        /// </summary>
        /// <param name="gridId">网格编号</param>
        /// <param name="type">巡查类型</param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/object")]
        public WapOutgoingResponse<List<PatrolObjOut>> GetPatrolObjectList(string gridId, string type)
        {
            int _gridId = 0;
            int _type = 0;
            int.TryParse(gridId, out _gridId);
            int.TryParse(type, out _type);
            if (_gridId == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "网格编号为空！");
            if (_type == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查类型为空！");

            var result = ServiceFactory.GetService<IFWPatrolObjectService>().GetFWPatrolObjectByGridIdAndType(_gridId, _type);
            return new WapOutgoingResponse<List<PatrolObjOut>>(result.Select(p => PatrolObjOut.FromDto(p)).ToList());
        }

        #endregion

        #region 获取巡查网格必达点列表

        /// <summary>
        ///  获取巡查网格必达点列表
        /// </summary>
        /// <param name="gridId">网格编号</param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/ckpoint")]
        public WapOutgoingResponse<List<PatrolCkpointOut>> GetCKPointList(string gridId)
        {
            int _gridId = 0;
            int.TryParse(gridId, out _gridId);
            if (_gridId == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "网格编号为空！");

            var result = ServiceFactory.GetService<IFWPatrolCKPointService>().GetPointByGridId(_gridId);
            return new WapOutgoingResponse<List<PatrolCkpointOut>>(result.Select(p => PatrolCkpointOut.FromDto(p)).ToList());
        }

        #endregion

        #region 获取批量设施上报对象详情
        /// <summary>
        /// 获取批量设施上报对象详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("issues/{id}/object")]
        public WapOutgoingResponse<List<BatchReportDetailsOut>> GetIssueObjectsByIssueId(string id)
        {
            var entities = ServiceFactory.GetService<IFWPatrolObjectReportService>().GetIssueObjectsByIssueId(id);
            var outs = new List<BatchReportDetailsOut>();
            entities.ToList().ForEach(e =>
            {
                var _out = new BatchReportDetailsOut
                {
                    ObjectId = e.ObjectId,
                    ObjectName = e.ObjectName,
                    Address = e.Address,
                    X = e.X,
                    Y = e.Y,
                    Result = e.Result
                };
                outs.Add(_out);
            });
            return new WapOutgoingResponse<List<BatchReportDetailsOut>>(outs);
        }
        #endregion


        #region 获取巡查类型与上报类型关联API接口

        /// <summary>
        /// 获取巡查类型与上报类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/relation/issue")]
        public WapOutgoingResponse<List<PatrolIssueRelationOut>> GetPatrolIssueRelation()
        {
            var entities = ServiceFactory.GetService<IFWIssueService>().GetPatrolIssueRelation();
            var outs = new List<PatrolIssueRelationOut>();
            entities.ToList().ForEach(e =>
            {
                if (null != e)
                {
                    var _out = new PatrolIssueRelationOut
                    {
                        PatrolType = e.PatrolType.ToString(),
                        IssueTypeId = e.IssueTypeId.ToString()
                    };
                    outs.Add(_out);
                }
            });
            return new WapOutgoingResponse<List<PatrolIssueRelationOut>>(outs);
        }


        #endregion

        #endregion

        #region =============================用户与组织接口=======================

        #region 获取用户网格信息
        /// <summary>
        ///  获取用户网格信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{userId}/grid")]
        public WapOutgoingResponse<UserGridOut> GetUserGrid(string userId)
        {
            int _userId = 0;
            int.TryParse(userId, out _userId);
            //先获取人员
            if (_userId == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "用户编号为空！");
            //获取用户
            var resultUser = ServiceFactory.GetService<IFWUserService>().GetFWUserById(_userId);

            if (resultUser == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "不存在此用户信息！");
            if (resultUser.GridId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "此用户无对应网格配置信息！");


            //在获取人员所在的网格
            var resultGrid = ServiceFactory.GetService<IFWGridService>().GetFWGridById(resultUser.GridId);

            return new WapOutgoingResponse<UserGridOut>(UserGridOut.FromDto(resultGrid, resultUser));
        }
        #endregion

        #region 获取车辆信息

        /// <summary>
        /// 获取车辆信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("vehicle")]
        public WapOutgoingResponse<List<VehicleOut>> GetVehicles(string stationId)
        {
            int _stationId = 0;
            int.TryParse(stationId, out _stationId);
            if (_stationId == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "站点编号为空！");
            var allStations = ServiceFactory.GetService<IAuthService>().GetOrganization().ToList() ;
            var currentStation = allStations.FirstOrDefault(x => x.StationId == _stationId);
            var Stations = new List<FWGridDto>();
            if (null != currentStation)
            {
                if (currentStation.ParentId == -1)
                {
                    Stations = allStations;
                }
                else
                {
                    Stations = allStations.Where(x => x.ParentId == _stationId).ToList();
                    Stations.Add(currentStation);
                }
            }
            //平台获取车辆信息
            var result = ServiceFactory.GetService<IFWVehicleService>().GetVehicleByStationId(Stations);

            return new WapOutgoingResponse<List<VehicleOut>>(result.Select(p => VehicleOut.FromDto(p)).ToList());
        }

        #endregion

        #region 获取司机

        /// <summary>
        /// 司机信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("driver")]
        public WapOutgoingResponse<List<DriverOut>> GetDrivers(string stationId)
        {
            int _stationId = 0;
            int.TryParse(stationId, out _stationId);
            List<DriverOut> driverOuts = new List<DriverOut>();


            //获取所有司机人员信息
            var wapUsers = ServiceFactory.GetService<IFWWapUserAndRoleService>().GetFWWapUserAndRoleDtoAll();
            if (wapUsers == null || wapUsers.Count() <= 0)
                return new WapOutgoingResponse<List<DriverOut>>(driverOuts);

            if (_stationId == 0)
            {

                var users = wapUsers.Where(p => p.RoleId == Convert.ToInt32(OutgoingConsts.PatrolDiverRoleId)).ToList();//过滤司机角色

                if (users != null && users.Count() > 0)
                {
                    foreach (var user in wapUsers)
                    {
                        DriverOut driverOut = new DriverOut()
                        {
                            Driver = user.UserId.ToString(),
                            DriverName = user.UserName,
                            StationId = user.OrganizationId.ToString(),
                            StationName = user.OrganizationName,
                        };
                        driverOuts.Add(driverOut);
                    }
                }

            }
            else
            {
                //获取指定网格及以下递归网格的司机
                var users = ServiceFactory.GetService<IFWUserService>().GetFWUserByRoleAndOrgId(Convert.ToInt32(OutgoingConsts.PatrolDiverRoleId), _stationId);
                if (users != null && users.Count() > 0)
                {
                    foreach (var item in users)
                    {
                        DriverOut driverOut = new DriverOut()
                        {
                            Driver = item.Id.ToString(),
                            DriverName = item.Name,
                            StationId = item.StationId.ToString(),
                            StationName = item.StationName,
                        };
                        driverOuts.Add(driverOut);
                    }
                }
                

                //获取指定网格下的司机

                //var users = wapUsers.Where(p => p.RoleId == Convert.ToInt32(OutgoingConsts.PatrolDiverRoleId) && p.OrganizationId == _stationId).ToList();//过滤司机角色

                //if (users != null && users.Count() > 0)
                //{
                //    foreach (var user in users)
                //    {
                //        DriverOut driverOut = new DriverOut()
                //        {
                //            Driver = user.UserId.ToString(),
                //            DriverName = user.UserName,
                //            StationId = user.OrganizationId.ToString(),
                //            StationName = user.OrganizationName,
                //        };
                //        driverOuts.Add(driverOut);
                //    }
                //}
            }
            return new WapOutgoingResponse<List<DriverOut>>(driverOuts);
        }

        #endregion

        #region 获取巡查人

        /// <summary>
        /// 巡查人信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol_staff")]
        public WapOutgoingResponse<List<PatrolstaffOut>> GetPatrolstaffs(string gridId)
        {
            //
            List<PatrolstaffOut> driverOuts = new List<PatrolstaffOut>();
            int _grid = 0;
            int.TryParse(gridId, out _grid);

            //获取所有巡查人员信息
            var wapUsers = ServiceFactory.GetService<IFWWapUserAndRoleService>().GetFWWapUserAndRoleDtoAll();
            if (wapUsers == null || wapUsers.Count() <= 0)
                return new WapOutgoingResponse<List<PatrolstaffOut>>(driverOuts);

            //获取网格信息
            if (_grid == 0)
            {
                var users = wapUsers.Where(p => p.RoleId == Convert.ToInt32(OutgoingConsts.PatrolstaffRoleId)).ToList();//获取巡查人角色
                foreach (var user in users)
                {
                    PatrolstaffOut patrolstaffOut = new PatrolstaffOut()
                    {
                        StaffId = user.UserId.ToString(),
                        StaffName = user.UserName,
                        StationId = user.OrganizationId.ToString(),
                        StationName = user.OrganizationName,
                    };
                    driverOuts.Add(patrolstaffOut);
                }
            }
            else
            {
                //获取当前登陆人员网格及递归向下网格的巡查人员
                //var grid = ServiceFactory.GetService<IFWGridService>().GetFWGridById(_grid);
                //if (grid != null)
                //{
                //    var users = ServiceFactory.GetService<IFWUserService>().GetFWUserByRoleAndOrgId(Convert.ToInt32(OutgoingConsts.PatrolstaffRoleId), grid.StationId);
                //    if (users != null && users.Count() > 0)
                //    {
                //        foreach (var user in users)
                //        {
                //            PatrolstaffOut patrolstaffOut = new PatrolstaffOut()
                //            {
                //                StaffId = user.Id.ToString(),
                //                StaffName = user.Name,
                //                StationId = user.StationId.ToString(),
                //                StationName = user.StationName,
                //            };
                //            driverOuts.Add(patrolstaffOut);
                //        }
                //    }
                //}

                var users = ServiceFactory.GetService<IFWUserService>().GetFWUserByRoleAndGridId(Convert.ToInt32(OutgoingConsts.PatrolstaffRoleId), _grid);
                if (users != null && users.Count() > 0)
                {
                    foreach (var user in users)
                    {
                        PatrolstaffOut patrolstaffOut = new PatrolstaffOut()
                        {
                            StaffId = user.Id.ToString(),
                            StaffName = user.Name,
                            StationId = user.StationId.ToString(),
                            StationName = user.StationName,
                        };
                        driverOuts.Add(patrolstaffOut);
                    }
                }

            }
            return new WapOutgoingResponse<List<PatrolstaffOut>>(driverOuts);
        }

        #endregion

        #region 获取当前在线人员

        #endregion

        #endregion


    }


}