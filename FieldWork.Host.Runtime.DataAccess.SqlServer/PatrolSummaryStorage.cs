using SH3H.SDK.DataAccess.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.SharpFrame.Data;
using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Infrastructure.Logging;
using System.Data;

namespace FieldWork.Host.Runtime.DataAccess.SqlServer
{
    public class PatrolSummaryStorage : BaseAccess<FWPatrolManageDto>, IPatrolSummaryStorage
    {

        public PatrolSummaryStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// 模型转换
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override FWPatrolManageDto Build(System.Data.IDataReader reader, FWPatrolManageDto instance)
        {
            try
            {
                instance.issueNum = reader.GetReaderValue<int>("issueNum", default(int), true);
                instance.odo = reader.GetReaderValue<decimal>("odo", default(decimal), true);
                instance.patrolNum = reader.GetReaderValue<int>("patrolNum", default(int), true);
                instance.patrolStaff = reader.GetReaderValue<string>("patrolStaff", default(string), true);
                return base.Build(reader, instance);

            }
            catch (Exception ex)
            {
                LogManager.Get().Error("Message：" + ex.Message + "；StackTrace：" + ex.StackTrace);
                throw new WapException(-1, "数据模型转换失败！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">当前管理员，所在网格下巡查人员的巡查概况</param>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolManageDto> GetPatrolManage(int userId, string timeDim)
        {
            try
            {
                var viewedRoles = System.Configuration.ConfigurationSettings.AppSettings["WAP_COUNT_PATROLSTAFF_ROLE"].ToString();

                string sqltext = @" WITH    CTE
                                          AS ( SELECT   taskpatrol.USER_ID AS userId ,
                                                        taskpatrol.USER_NAME AS userName ,
                                                        taskpatrol.TASK_ID AS taskId ,
                                                        SUM(taskpatrol.ISSUE_NUM) AS issueNum,
                                                        MAX(taskpatrol.ODO) AS odo ,
                                                        1 AS patrolNum
                                               FROM     FW_COUNT_PATROL_SUMMARY taskpatrol
                                                        LEFT JOIN dbo.wapUserAndRole waprole ON waprole.USER_ID = taskpatrol.USER_ID
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
                    //endtime = nowdate;
                    //starttime = DateTypeManager.GetTimeStartByType(PatrolDateTypeEnum.Day, nowdate);


                    using (var cmd = Database.GetSqlStringCommand("uspDayManage"))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        Database.AddInParameter(cmd, "@RoleIds", DbType.Int32, viewedRoles.ToString());
                        Database.AddInParameter(cmd, "@RoleUserId", DbType.Int32, userId);

                        return SelectList(cmd);
                    }
                }
                else
                {
                    using (var cmd = Database.GetSqlStringCommand(sqltext))
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
                        Database.AddInParameter(cmd, "@START_TIME", DbType.DateTime, starttime);
                        Database.AddInParameter(cmd, "@END_TIME", DbType.DateTime, endtime);
                        Database.AddInParameter(cmd, "@USER_ID", DbType.Int32, userId);
                        return SelectList(cmd);
                    }
                }


            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(-1, "获取全部人员巡查概况失败！");
            }
        }
    }
}
