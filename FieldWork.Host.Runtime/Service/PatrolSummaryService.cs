using Dapper;
using FieldWork.Host.Runtime.DataAccess.SqlServer;
using FieldWork.Host.Runtime.Helper;
using Newtonsoft.Json;
using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Service
{
    /// <summary>
    ///             LogManager.Get().Debug("Debug");
    ///             LogManager.Get().Error("Error");
    ///             LogManager.Get().Info("Info");
    ///             LogManager.Get().Warn("Warn");
    /// </summary>
    public class PatrolSummaryService
    {
        ManagerService _managerService = new ManagerService();

        /// <summary>
        /// 可接收消息的管理员角色
        /// </summary>
        private readonly string _roleids = System.Configuration.ConfigurationManager.AppSettings["WAP_PATROLTASK_MANAGE_ROLE"];


        public void Run(string strparam)
        {
            if (string.IsNullOrWhiteSpace(_roleids))
            {
                LogManager.Get().Warn("AppSetting配置项【WAP_PATROLTASK_MANAGE_ROLE】为空！本次执行结束。");
                return;
            }

            if (string.IsNullOrWhiteSpace(strparam))
            {
                LogManager.Get().Warn("参数为空！本次执行结束。");
                return;
            }

            if (strparam.ToLower() != "day" && strparam.ToLower() != "week" && strparam.ToLower() != "month")
            {
                LogManager.Get().Warn("参数错误！本次执行结束。");
                return;
            }


            try
            {
                WapMessageHelper sh3hmh = new WapMessageHelper();
                sh3hmh.Domain = WapPlatConsts.NotificationDomain;

                string[] roleids_str_array = _roleids.Split(new String[','], StringSplitOptions.RemoveEmptyEntries);

                //模板的基础配置获取
                var messageEntity = BuildSendTemplateMessageInDto();
                //数据组成如下
                List<ItemDto> items = new List<ItemDto>();
                //相同网格下的管理人员收到的信息是一样的，所以把gridId作为key，userId的集合作为value
                Dictionary<int, List<string>> grid_userBase = new Dictionary<int, List<string>>();
                //发送给哪些应用
                if (!string.IsNullOrWhiteSpace(WapPlatConsts.NotificationTaskToUserType))
                {
                    string[] toapplications = WapPlatConsts.NotificationTaskToUserType.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    if (toapplications != null && toapplications.Length > 0)
                    {
                        if (roleids_str_array != null && roleids_str_array.Length > 0)
                        {
                            //配置角色下的所有人员
                            var getusers = GetFWUserByRoleId(String.Join(",", roleids_str_array));
                            //查找同一网格的管理人员归集
                            if (getusers != null && getusers.Count() > 0)
                            {
                                grid_userBase = GetGridUser(getusers.ToList());
                            }
                            if (grid_userBase.Count() <= 0)
                            {
                                LogManager.Get().Error("配置的角色下没有对应的管理人员！本次执行结束。");
                                return;
                            }
                            foreach (var toapplication in toapplications)
                            {
                                foreach (KeyValuePair<int, List<string>> keyvalueitem in grid_userBase)
                                {
                                    var thisValue = keyvalueitem.Value;
                                    List<string> Identify = new List<string>();
                                    Identify.AddRange(thisValue);

                                    //这里的key是要发送的目标应用如 app,uids 等；
                                    Dictionary<string, List<string>> toPoints = new Dictionary<string, List<string>>();

                                    //用当前网格下集合中的第一个人去查询巡查数据
                                    int _user = 0;
                                    int.TryParse(Identify[0].Remove(0, "uid://".Length), out _user);
                                    //如果第一个数据是错的，那么尝试第二条，
                                    //第二条仍是错的则继续下一次循环
                                    if (_user == 0 && Identify.Count() > 1)
                                    {
                                        int.TryParse(Identify[1].Remove(0, "uid://".Length), out _user);
                                    }
                                    if (_user == 0)
                                    {
                                        LogManager.Get().Error("当前网格下的管理人员异常：" + JsonConvert.SerializeObject(Identify));
                                        continue;
                                    }

                                    toPoints.Add(toapplication, Identify);

                                    //当前角色下可以发送的巡查数据
                                    var summaryData = GetPatrolManage(_user, strparam);
                                    if (summaryData != null && summaryData.Count() > 0)
                                    {
                                        var list = GetNotifyMessageBase(summaryData.ToList());
                                        items.Add(new ItemDto()
                                        {
                                            Data = DataToBase64(list),
                                            ToPoints = toPoints
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
                messageEntity.Items = items;
                if (messageEntity.Items == null || messageEntity.Items.Count() == 0)
                {
                    LogManager.Get().Info("本次无数据可发送，执行结束。");
                    return;
                }

                var result = sh3hmh.SendTemplateMessage(messageEntity);

                if (result == null || result.Code != 0)
                {
                    LogManager.Get().Info("通知发送失败！返回为空 请检查日志。");
                    LogManager.Get().Info("【发送数据】："+JsonConvert.SerializeObject(messageEntity));
                }
                else if (result.Code != 0)
                {
                    LogManager.Get().Info(string.Format("通知发送失败！返回消息Code：{0}； Messgae：{1}", result.Code, result.Message));
                    LogManager.Get().Info("【发送数据】：" + JsonConvert.SerializeObject(messageEntity));
                }

                LogManager.Get().Info("本次推送完成，运行结束！");

            }
            catch (Exception ex)
            {
                LogManager.Get().Error("Message:" + ex.Message + "；StackTrace：" + ex.StackTrace);
                throw new WapException(-1, "代码异常！");
            }
        }

        /// <summary>
        /// 模板基础配置build
        /// </summary>
        /// <returns></returns>
        private SendTemplateMessageInDto BuildSendTemplateMessageInDto()
        {
            SendTemplateMessageInDto messageEntity = new SendTemplateMessageInDto();
            messageEntity.FromPointId = WapPlatConsts.NotificationFromPointId;
            messageEntity.MessageType = WapPlatConsts.NotificationTaskMessageType;

            int method = 1; int.TryParse(WapPlatConsts.NotificationMethod, out method);
            int retryinterval = 30; int.TryParse(WapPlatConsts.NotificationRetryInterval, out retryinterval);
            int retrytime = 3; int.TryParse(WapPlatConsts.NotificationRetryTimes, out retrytime);
            DateTime planningtime = DateTime.Now;

            if (!DateTime.TryParse(WapPlatConsts.PlanningTime, out planningtime))
                planningtime = DateTime.Now;
            messageEntity.Config = new SendConfigDto()
            {
                SendType = method,
                RetryInterval = retryinterval,
                RetryTime = retrytime,
                SendTime = planningtime
            };
            return messageEntity;
        }

        /// <summary>
        /// 人员按照网格分组管理人员
        /// </summary>
        /// <param name="getusers"></param>
        /// <returns></returns>
        private Dictionary<int, List<string>> GetGridUser(List<FWUser> getusers)
        {
            Dictionary<int, List<string>> grid_userBase = new Dictionary<int, List<string>>();
            List<string> grid_users = null;
            foreach (var itemUser in getusers)
            {
                if (!grid_userBase.ContainsKey(itemUser.GridId))
                {//不存在当前的网格
                    grid_users = new List<string>();
                    grid_users.Add("uid://" + itemUser.Id);
                    grid_userBase.Add(itemUser.GridId, grid_users);
                }
                else
                {//存在当前循环的网格
                    grid_userBase[itemUser.GridId].Add("uid://" + itemUser.Id);
                }
            }
            return grid_userBase;
        }

        /// <summary>
        /// 消息的content--》build
        /// </summary>
        /// <param name="summaryData"></param>
        /// <returns></returns>
        private NotifyMessageBase GetNotifyMessageBase(List<FWPatrolManageDto> summaryData)
        {
            NotifyMessageBase list = new NotifyMessageBase()
            {
                Type = Convert.ToInt32(WapPlatConsts.NotificationMobileType)
            };
            foreach (var itemData in summaryData)
            {
                var _content = new NotifyContent
                {
                    IssueNum = itemData.issueNum.ToString(),
                    Odo = (itemData.odo > 0 ? (itemData.odo / 1000) : 0).ToString("#0.00"),
                    PatrolNum = itemData.patrolNum.ToString(),
                    PatrolStaff = itemData.patrolStaff,
                };
                list.DataList.Add(_content);
            }
            return list;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string DataToBase64(NotifyMessageBase list)
        {
            var message = JsonConvert.SerializeObject(list);
            byte[] output = Encoding.UTF8.GetBytes(message);
            return Convert.ToBase64String(output);
        }

        /// <summary>
        /// 获取巡查概况数据
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        private IEnumerable<FWPatrolManageDto> GetPatrolManage(int userId, string timeDim)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConfigureConnectionString"].ConnectionString))
                {
                    connection.Open();

                    var viewedRoles = System.Configuration.ConfigurationSettings.AppSettings["WAP_COUNT_PATROLSTAFF_ROLE"].ToString();

                    string sqltext = @" WITH    CTE
                                          AS ( SELECT   taskpatrol.USER_ID AS userId ,
                                                        taskpatrol.USER_NAME AS userName ,
                                                        taskpatrol.TASK_ID AS taskId ,
                                                        SUM(taskpatrol.ISSUE_NUM) AS issueNum,
                                                        MAX(taskpatrol.ODO) AS odo ,
                                                        1 AS patrolNum
                                               FROM     FW_COUNT_PATROL_SUMMARY taskpatrol  with(nolock)
                                                        LEFT JOIN dbo.wapUserAndRole waprole with(nolock) ON waprole.USER_ID = taskpatrol.USER_ID
                                               WHERE    1 = 1 
                                                        AND taskpatrol.USER_ID IN (
                                                                            SELECT  tabuserA.ID
                                                                            FROM    dbo.FW_USER tabuserA
                                                                            WHERE   tabuserA.GRID_ID = ( SELECT tabuserB.GRID_ID
                                                                                                            FROM   dbo.FW_USER tabuserB
                                                                                                            WHERE  tabuserB.ID = @USER_ID
                                                                                                        ) )
                                                                            AND taskpatrol.TASK_START_TIME >= @START_TIME
                                                                            AND taskpatrol.TASK_END_TIME <= @END_TIME ";
                    if (!string.IsNullOrWhiteSpace(viewedRoles))
                    {
                        sqltext += @"  AND waprole.ROLE_ID IN ( " + viewedRoles.ToString() + " )  ";
                    }
                    sqltext += @"               GROUP BY taskpatrol.USER_ID ,
                                            taskpatrol.TASK_ID ,
                                            taskpatrol.USER_NAME
                                             )
                                            SELECT  CTE.userName AS patrolStaff ,
                                                    SUM(CTE.issueNum) AS issueNum ,
                                                    SUM(CTE.odo) AS odo ,
                                                    SUM(CTE.patrolNum) AS patrolNum
                                            FROM    CTE
                                            WHERE   1 = 1
                                            GROUP BY CTE.userId ,
                                                    CTE.userName;";
                    DateTime nowdate = DateTime.Now;
                    DateTime starttime = new DateTime();
                    DateTime endtime = new DateTime();
                    if (timeDim.ToLower() == "day")
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@RoleIds", viewedRoles.ToString(), DbType.String, ParameterDirection.Input);
                        parameters.Add("@RoleUserId", userId, DbType.Int32, ParameterDirection.Input);

                        var list = connection.Query<FWPatrolManageDto>("uspDayManage", parameters, null, true, null, CommandType.StoredProcedure);
                        if (list == null || list.Count() == 0)
                        {
                            return new List<FWPatrolManageDto>();
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        if (timeDim.ToLower() == "week")
                        {
                            endtime = DateTypeManager.GetTimeEndByType(PatrolDateTypeEnum.Week, nowdate);
                            starttime = DateTypeManager.GetTimeStartByType(PatrolDateTypeEnum.Week, nowdate);
                        }
                        if (timeDim.ToLower() == "month")
                        {
                            endtime = DateTypeManager.GetTimeEndByType(PatrolDateTypeEnum.Month, nowdate);
                            starttime = DateTypeManager.GetTimeStartByType(PatrolDateTypeEnum.Month, nowdate);
                        }
                        var list = connection.Query<FWPatrolManageDto>(sqltext, new { START_TIME = starttime, END_TIME = endtime, USER_ID = userId });
                        if (list == null || list.Count() == 0)
                        {
                            return new List<FWPatrolManageDto>();
                        }
                        else
                        {
                            return list;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.Get().Info(" 巡查概况——> 查询失败！获取当前管理`" + userId + "`下的巡查人员的巡查记录失败...");
                LogManager.Get().Error(e);
                return null;
            }

        }

        /// <summary>
        /// 获取当前角色下人员
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        private IEnumerable<FWUser> GetFWUserByRoleId(string roleId)
        {
            try
            {
                string sqltext = @" SELECT DISTINCT  ID  as Id,
                                                    NAME  as Name,
                                                    STATION_ID as StationId,
                                                    STATION_NAME as StationName,
                                                    ACTIVE as Active,
                                                    GRID_ID as GridId
                                            FROM    FW_USER feuser
                                                    INNER JOIN dbo.wapUserAndRole wapuserrole ON feuser.ID = wapuserrole.USER_ID
                                                                                                 AND wapuserrole.ROLE_ID IN (" + roleId + ");  ";


                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConfigureConnectionString"].ConnectionString))
                {
                    connection.Open();
                    var result = connection.Query<FWUser>(sqltext);
                    return (result == null || result.Count() == 0) ? new List<FWUser>() : result;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(-1, "获取管理人员模型失败！");
            }
        }

        /// <summary>
        ///测试消息发送
        //var _content = new NotifyMessageBase
        //{
        //    Type = 602
        //};
        //_content.NContent.Add(new NotifyContent() {  IssueNum="1", Odo="2", PatrolNum="3", PatrolStaff="张三" });
        //_content.NContent.Add(new NotifyContent() { IssueNum = "1", Odo = "21", PatrolNum = "31", PatrolStaff = "里斯" });
        //List<string> dd = new List<string>();
        //dd.Add("uid://2");
        //dd.Add("uid://14");
        //Send(dd, _content);
        /// </summary>
        /// <param name="touid"></param>
        /// <param name="message"></param>
        /// <param name="messagetype"></param>
        /// <returns></returns>
        private async Task Send(List<string> touid, NotifyMessageBase message, string messagetype = null)
        {
            string msgstr = JsonConvert.SerializeObject(message);
            byte[] output = Encoding.UTF8.GetBytes(msgstr);
            string str = Convert.ToBase64String(output);
            await Send(touid, str, messagetype);
        }

        public async Task Send(List<string> touid, string message, string messagetype = null)
        {
            try
            {
                if (touid == null)
                {
                    return;
                }

                WapMessageHelper sh3hmh = new WapMessageHelper();
                sh3hmh.Domain = WapPlatConsts.NotificationDomain;

                SendTemplateMessageInDto messageEntity = new SendTemplateMessageInDto();
                messageEntity.FromPointId = WapPlatConsts.NotificationFromPointId;
                messageEntity.MessageType = string.IsNullOrEmpty(messagetype) ? WapPlatConsts.NotificationTaskMessageType : messagetype;

                int method = 1; int.TryParse(WapPlatConsts.NotificationMethod, out method);
                int retryinterval = 30; int.TryParse(WapPlatConsts.NotificationRetryInterval, out retryinterval);
                int retrytime = 3; int.TryParse(WapPlatConsts.NotificationRetryTimes, out retrytime);
                DateTime planningtime = DateTime.Now;

                if (!DateTime.TryParse(WapPlatConsts.PlanningTime, out planningtime))
                    planningtime = DateTime.Now;

                messageEntity.Config = new SendConfigDto()
                {
                    SendType = method,
                    RetryInterval = retryinterval,
                    RetryTime = retrytime,
                    SendTime = planningtime
                };

                List<ItemDto> items = new List<ItemDto>();
                Dictionary<string, List<string>> toPoints = new Dictionary<string, List<string>>();
                List<string> Identify = new List<string>();

                Identify.AddRange(touid);

                if (!string.IsNullOrWhiteSpace(WapPlatConsts.NotificationTaskToUserType))
                {
                    string[] tousers = WapPlatConsts.NotificationTaskToUserType.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    if (tousers != null && tousers.Length > 0)
                    {
                        foreach (var touser in tousers)
                        {
                            toPoints.Add(touser, Identify);
                        }
                    }
                }
                items.Add(new ItemDto()
                {
                    Data = message,
                    ToPoints = toPoints
                });

                messageEntity.Items = items;

                var result = sh3hmh.SendTemplateMessage(messageEntity);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
            }
        }


    }
}
