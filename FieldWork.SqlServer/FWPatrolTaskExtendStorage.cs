using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;
using SH3H.SDK.DataAccess.Db;
using SH3H.SharpFrame.Data;
using SH3H.SDK.Infrastructure.Logging;
using SH3H.SDK.Definition.Exceptions;
using SH3H.WAP.FieldWork.Share;
using System.Data;

namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class FWPatrolTaskExtendStorage : BaseAccess<FWPatrolTaskSummary>, IFWPatrolTaskExtendStorage
    {
        /// <summary>
        /// 
        /// </summary>
        public FWPatrolTaskExtendStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override FWPatrolTaskSummary Build(System.Data.IDataReader reader, FWPatrolTaskSummary instance)
        {
            try
            {
                instance.CruiseType = reader.GetReaderValue<int>("CRUISE_TYPE");
                instance.PatrolTime = reader.GetReaderValue<string>("PATROL_TIME");
                instance.Issues = reader.GetReaderValue<int>("ISSUES");
                //instance.IssueEvents = reader.GetReaderValue<int>("ISSUES_EVENTS", default(int), true);
                //instance.IssueEquipment = reader.GetReaderValue<int>("ISSUE_EQUIPMENT", default(int), true);
                instance.ClockPoint = reader.GetReaderValue<int>("CLOCK_POINT");
                instance.ClockOn = reader.GetReaderValue<int>("CLOCK_ON");
                instance.UnClockOn = reader.GetReaderValue<int>("UNCLOCK_ON");
                instance.Mileage = reader.GetReaderValue<decimal>("MILEAGE", default(decimal), true);
                return base.Build(reader, instance);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "任务小结模型转换失败！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FWPatrolTaskSummary GetFWPatrolTaskSummary(string taskid)
        {
            try
            {
                //string sqltext = @" WITH    CTE
                //                          AS ( SELECT   fwtask.CRUISE_TYPE ,
                //                                        fwtask.ID ,
                //                                        fwtask.PATROL_STAFF ,
                //                                        dbo.fnQueryUserOdo(fwtask.OPERATOR, fwtask.START_TIME,
                //                                                           fwtask.END_TIME) AS Mileage ,
                //                                        ( dbo.fnQueryCountTime(DATEDIFF(SECOND,
                //                                                                        fwtask.START_TIME,
                //                                                                        CASE ISNULL(fwtask.END_TIME,
                //                                                                              0)
                //                                                                          WHEN 0
                //                                                                          THEN GETDATE()
                //                                                                          ELSE fwtask.END_TIME
                //                                                                        END), 0) ) AS PatrolTimes ,
                //                                        ( SELECT    COUNT(*)
                //                                          FROM      WS_ISSUE
                //                                          WHERE     WS_ID = fwtask.ID
                //                                                    AND WS_ISSUE.STATUS <> -1
                //                                        ) AS IssuesCount ,
                //                                        ( SELECT    COUNT(*)
                //                                          FROM      FW_PATROL_CKPOINT
                //                                          WHERE     FW_PATROL_CKPOINT.GRID_ID = ( SELECT
                //                                                                              FW_USER.GRID_ID
                //                                                                              FROM
                //                                                                              FW_USER
                //                                                                              WHERE
                //                                                                              FW_USER.ID = fwtask.OPERATOR
                //                                                                              )
                //                                        ) AS ClockPointCount ,
                //                                        ( SELECT    COUNT(*)
                //                                          FROM      FW_PATROL_TASK_CKPOINT
                //                                          WHERE     TASK_ID = fwtask.ID
                //                                                    AND STATUS = 1
                //                                        ) AS ClockOnCount
                //                               FROM     ( SELECT    *
                //                                          FROM      FW_PATROL_TASK
                //                                          WHERE     1 = 1
                //                                                    AND FW_PATROL_TASK.ID = @TASK_ID
                //                                        ) fwtask
                //                             )
                //                    SELECT  Mileage AS MILEAGE ,
                //                            CRUISE_TYPE ,
                //                            PatrolTimes AS PATROL_TIME ,
                //                            IssuesCount AS ISSUES ,
                //                            ClockPointCount AS CLOCK_POINT ,
                //                            ClockOnCount AS CLOCK_ON ,
                //                            ( ClockPointCount - ClockOnCount ) AS UNCLOCK_ON
                //                    FROM    CTE;";

                string sqltext = @" DECLARE @distance DECIMAL(18, 5);
                                    DECLARE @task_start DATETIME;
                                    DECLARE @task_end DATETIME;
                                    DECLARE @task_operator VARCHAR(50);
                                    DECLARE @rdistance DECIMAL(18, 5);
                                    SELECT  @task_operator = CAST (OPERATOR AS INT) ,
                                            @task_start = START_TIME ,
                                            @task_end = END_TIME
                                    FROM    FW_PATROL_TASK
                                    WHERE   1 = 1
                                            AND FW_PATROL_TASK.ID = @TASK_ID;
                                    EXEC dbo.uspQueryDistance @task_operator, @task_start, @task_end,
                                        @distance OUTPUT;                        
                                    WITH    CTE
                                              AS ( SELECT   fwtask.CRUISE_TYPE ,
                                                            fwtask.ID ,
                                                            fwtask.PATROL_STAFF ,
                                                            @distance AS Mileage ,
                                                            ( dbo.fnQueryCountTime(DATEDIFF(SECOND,
                                                                                            fwtask.START_TIME,
                                                                                            CASE ISNULL(fwtask.END_TIME,
                                                                                                  0)
                                                                                              WHEN 0
                                                                                              THEN GETDATE()
                                                                                              ELSE fwtask.END_TIME
                                                                                            END), 0) ) AS PatrolTimes ,
                                                            ( SELECT    COUNT(*)
                                                              FROM      WS_ISSUE
                                                              WHERE     WS_ID = fwtask.ID
                                                                        AND WS_ISSUE.STATUS <> -1
                                                            ) AS IssuesCount ,
                                                            ( SELECT    COUNT(*)
                                                              FROM      FW_PATROL_CKPOINT
                                                              WHERE     FW_PATROL_CKPOINT.GRID_ID = ( SELECT
                                                                                                  FW_USER.GRID_ID
                                                                                                  FROM
                                                                                                  FW_USER
                                                                                                  WHERE
                                                                                                  FW_USER.ID = fwtask.OPERATOR
                                                                                                  )
                                                            ) AS ClockPointCount ,
                                                            ( SELECT    COUNT(*)
                                                              FROM      FW_PATROL_TASK_CKPOINT
                                                              WHERE     TASK_ID = fwtask.ID
                                                                        AND STATUS = 1
                                                            ) AS ClockOnCount
                                                   FROM     ( SELECT    *
                                                              FROM      FW_PATROL_TASK
                                                              WHERE     1 = 1
                                                                        AND FW_PATROL_TASK.ID = @TASK_ID
                                                            ) fwtask
                                                 )
                                        SELECT  Mileage AS MILEAGE ,
                                                CRUISE_TYPE ,
                                                PatrolTimes AS PATROL_TIME ,
                                                IssuesCount AS ISSUES ,
                                                ClockPointCount AS CLOCK_POINT ,
                                                ClockOnCount AS CLOCK_ON ,
                                                ( ClockPointCount - ClockOnCount ) AS UNCLOCK_ON
                                        FROM    CTE; ";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@TASK_ID", DbType.String, taskid);
                    return SelectSingle(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询任务小结失败！");
            }
        }

        /// <summary>
        /// /获取个人巡查概况
        /// </summary>
        /// <param name="user"></param>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolIndivDto> GetFWPatrolIndivDto(string user, string timeDim)
        {
            try
            {
                var patrolRoleId = System.Configuration.ConfigurationSettings.AppSettings["WAP_PATROLSTAFF_ROLE"];
                if (string.IsNullOrWhiteSpace(patrolRoleId)) {
                    throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取巡查人员角色配置信息失败，请检查配置文件！");
                }
                string sqltext = @"  exec uspPatrolTaskCount @RoleIds=" + patrolRoleId + ";";
                        sqltext+=@" SELECT  *
                                    INTO    #table_patrol
                                    FROM    FW_COUNT_PATROL_SUMMARY
                                    WHERE   USER_ID = @userId
                                            AND TASK_START_TIME >= @start
                                            AND TASK_END_TIME <= @end;
                                    DECLARE @patrolNum INT;
                                    DECLARE @odo DECIMAL(18, 3);
                                    DECLARE @issueNum INT; 
                                    SET @patrolNum = 0;
                                    SET @odo = 0.0;
                                    WITH    CTE
                                              AS ( SELECT   1 AS patrolNum ,
                                                            MAX(taskpatrol.ODO) AS odo
                                                   FROM     #table_patrol taskpatrol
                                                   WHERE    1 = 1
                                                   GROUP BY taskpatrol.TASK_ID
                                                 )
                                        SELECT  @patrolNum = COUNT(*) ,
                                                @odo = SUM(CTE.odo)
                                        FROM    CTE;
                                    SELECT  @patrolNum AS patrolNum ,
                                            @odo AS odo ,
                                            taskpatrol.ISSUE AS issue ,
                                            taskpatrol.USER_ID AS userId ,
                                            COUNT(*) AS num
                                    FROM    #table_patrol taskpatrol
                                    WHERE   1 = 1
                                    GROUP BY taskpatrol.ISSUE ,
                                            taskpatrol.USER_ID;
                                    DROP TABLE #table_patrol; ";
                DateTime nowdate = DateTime.Now;
                DateTime starttime = new DateTime();
                DateTime endtime = new DateTime();
                if (timeDim.ToLower() == "day")
                {
                    //endtime = nowdate;
                    //starttime = DateTypeManager.GetTimeStartByType(PatrolDateTypeEnum.Day, nowdate);
                    //当天查询需要单独时时查询
                    using (var cmd = Database.GetSqlStringCommand("uspDayInDiv"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        Database.AddInParameter(cmd, "@userId", DbType.Int32, Convert.ToInt32(user));
                        return SelectList<FWPatrolIndivDto>(cmd, reader => new FWPatrolIndivDto
                        {
                            //IssueNum = reader.GetReaderValue<Int32>("issueNum"),
                            Odo = reader.GetReaderValue<decimal>("odo"),
                            PatrolNum = reader.GetReaderValue<Int32>("patrolNum"),
                            Issue = reader.GetReaderValue<string>("issue", default(string), true),
                            Num = reader.GetReaderValue<Int32>("num", default(Int32), true),
                        });
                    }

                }
                else
                {
                    using (var cmd = Database.GetSqlStringCommand(sqltext))
                    {
                        Database.AddInParameter(cmd, "@userId", DbType.Int32, Convert.ToInt32(user));

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
                        Database.AddInParameter(cmd, "@start", DbType.DateTime, starttime);
                        Database.AddInParameter(cmd, "@end", DbType.DateTime, endtime);

                        return SelectList<FWPatrolIndivDto>(cmd, reader => new FWPatrolIndivDto
                        {
                            //IssueNum = reader.GetReaderValue<Int32>("issueNum"),
                            Odo = reader.GetReaderValue<decimal>("odo"),
                            PatrolNum = reader.GetReaderValue<Int32>("patrolNum"),
                            Issue = reader.GetReaderValue<string>("issue", default(string), true),
                            Num = reader.GetReaderValue<Int32>("num", default(Int32), true),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取个人巡查概况失败！");
            }
        }

        /// <summary>
        /// 获取巡查概况（管理者）
        /// </summary>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolManageDto> GetFWPatrolManageDto(int userId, string timeDim)
        {
            try
            {

                var patrolRoleId = System.Configuration.ConfigurationSettings.AppSettings["WAP_PATROLSTAFF_ROLE"];
                if (string.IsNullOrWhiteSpace(patrolRoleId))
                {
                    throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取巡查人员角色配置信息失败，请检查配置文件！");
                }

                var viewedRoles = System.Configuration.ConfigurationSettings.AppSettings["WAP_COUNT_PATROLSTAFF_ROLE"].ToString();

                string sqltext = @"  exec uspPatrolTaskCount @RoleIds=" + patrolRoleId + ";";

                         sqltext += @" WITH    CTE
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

                        return SelectList<FWPatrolManageDto>(cmd, reader =>
                        {
                            var instance = new FWPatrolManageDto();
                            instance.IssueNum = reader.GetReaderValue<int>("issueNum", default(int), true);
                            instance.Odo = reader.GetReaderValue<decimal>("odo", default(decimal), true);
                            instance.PatrolNum = reader.GetReaderValue<int>("patrolNum", default(int), true);
                            instance.PatrolStaff = reader.GetReaderValue<string>("patrolStaff", default(string), true);
                            return instance;
                        });
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
                        return SelectList<FWPatrolManageDto>(cmd, reader =>
                        {
                            var instance = new FWPatrolManageDto();
                            instance.IssueNum = reader.GetReaderValue<int>("issueNum", default(int), true);
                            instance.Odo = reader.GetReaderValue<decimal>("odo", default(decimal), true);
                            instance.PatrolNum = reader.GetReaderValue<int>("patrolNum", default(int), true);
                            instance.PatrolStaff = reader.GetReaderValue<string>("patrolStaff", default(string), true);
                            return instance;
                        });
                    }
                }


            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取全部人员巡查概况失败！");
            }

        }

        /// <summary>
        /// 获取计划任务计划小结
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolPlanSummaryDto> GetFWPatrolPlanSummaryDto(string taskid)
        {
            try
            {
                string sqltext = @" SELECT  *  FROM    dbo.fnQueryPatrolPlanCount(@taskid); ";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@taskid", DbType.String, taskid);
                    return SelectList<FWPatrolPlanSummaryDto>(cmd, reader =>
                    {
                        return new FWPatrolPlanSummaryDto()
                        {
                            ComplateNum = reader.GetReaderValue<int>("TablePatrolComplateNum", default(int), true),
                            GridId = reader.GetReaderValue<int>("TablePatrolGridId", default(int), true),
                            InspectNum = reader.GetReaderValue<int>("TablePatrolInspectNum", default(int), true),
                            PatrolType = reader.GetReaderValue<int>("TablePatrolType", default(int), true),
                            PlanEndTime = reader.GetReaderValue<DateTime>("TablePatrolEnd", default(DateTime), true),
                            PlanId = reader.GetReaderValue<string>("TablePatrolPlanId", default(string), true),
                            PlanStartTime = reader.GetReaderValue<DateTime>("TablePatrolStart", default(DateTime), true),
                        };
                    });
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取巡查计划小结失败！");
            }

        }
    }
}
