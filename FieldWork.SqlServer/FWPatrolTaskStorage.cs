using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;
using SH3H.SDK.DataAccess.Db;
using SH3H.SharpFrame.Data;
using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Infrastructure.Logging;
using SH3H.WAP.FieldWork.Share;
using System.Data;
using SH3H.WAP.FieldWork.Model.ViewModels;

namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    public class FWPatrolTaskStorage : BaseAccess<FWPatrolTask>, IFWPatrolTaskStorage
    {
        /// <summary>
        /// 构造
        /// </summary>
        public FWPatrolTaskStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override FWPatrolTask Build(System.Data.IDataReader reader, FWPatrolTask instance)
        {
            try
            {
                instance.ID = reader.GetReaderValue<String>("ID");
                instance.PatrolType = reader.GetReaderValue<Int32>("PATROL_TYPE");
                instance.StartTime = reader.GetReaderValue<DateTime>("START_TIME");
                instance.EndTime = reader.GetReaderValue<DateTime>("END_TIME", default(DateTime), true);
                instance.EndReason = reader.GetReaderValue<String>("END_REASON", default(String), true);
                instance.GridId = reader.GetReaderValue<Int32>("GRID_ID");
                instance.PlanId = reader.GetReaderValue<String>("PLAN_ID", default(String), true);
                instance.CruiseType = reader.GetReaderValue<Int32>("CRUISE_TYPE");
                instance.Operator = reader.GetReaderValue<string>("OPERATOR");
                instance.PatrolStaff = reader.GetReaderValue<string>("PATROL_STAFF");
                instance.Driver = reader.GetReaderValue<string>("DRIVER", default(string), true);
                instance.VehicleNo = reader.GetReaderValue<string>("VEHICLE_NO", default(string), true);

                //关联字段展示用
                instance.GridName = reader.GetReaderValue<String>("GRID_NAME");
                //instance.ExecuteStation = reader.GetReaderValue<Int32>("EXECUTE_STATION", default(Int32), true);

                return base.Build(reader, instance);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "模型转换失败");
            }
        }

        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTask CreateFWPatrolTask(FWPatrolTask entity)
        {
            try
            {
                string sqltext = @" INSERT  INTO FW_PATROL_TASK
                                                    ( ID ,
                                                      PATROL_TYPE ,
                                                      START_TIME ,
                                                      END_TIME ,
                                                      END_REASON ,
                                                      GRID_ID ,
                                                      PLAN_ID ,
                                                      CRUISE_TYPE ,
                                                      OPERATOR ,
                                                      PATROL_STAFF ,
                                                      DRIVER ,
                                                      VEHICLE_NO
                                                    )
                                            VALUES  ( @ID ,
                                                      @PATROL_TYPE ,
                                                      @START_TIME ,
                                                      @END_TIME ,
                                                      @END_REASON ,
                                                      @GRID_ID ,
                                                      @PLAN_ID ,
                                                      @CRUISE_TYPE ,
                                                      @OPERATOR ,
                                                      @PATROL_STAFF ,
                                                      @DRIVER ,
                                                      @VEHICLE_NO
                                                    );";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.String, entity.ID);
                    Database.AddInParameter(cmd, "@PATROL_TYPE", DbType.Int32, entity.PatrolType);
                    Database.AddInParameter(cmd, "@START_TIME", DbType.DateTime, entity.StartTime == default(DateTime) ? DateTime.Now : entity.StartTime);
                    Database.AddInParameter(cmd, "@END_TIME", DbType.DateTime, DBNull.Value);
                    Database.AddInParameter(cmd, "@END_REASON", DbType.String, DBNull.Value);
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, entity.GridId);
                    Database.AddInParameter(cmd, "@PLAN_ID", DbType.String, entity.PlanId);
                    Database.AddInParameter(cmd, "@CRUISE_TYPE", DbType.Int32, entity.CruiseType);

                    Database.AddInParameter(cmd, "@OPERATOR", DbType.String, entity.Operator);
                    Database.AddInParameter(cmd, "@PATROL_STAFF", DbType.String, entity.PatrolStaff);
                    Database.AddInParameter(cmd, "@DRIVER", DbType.String, entity.Driver);
                    Database.AddInParameter(cmd, "@VEHICLE_NO", DbType.String, entity.VehicleNo);


                    ExecuteScalar(cmd);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增巡查任务模型失败！");
            }
        }

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTask UpdateFWPatrolTaskById(String id, FWPatrolTask entity)
        {
            try
            {
                string sqltext = @" UPDATE  FW_PATROL_TASK
                                            SET     PATROL_TYPE = @PATROL_TYPE ,
                                                    END_TIME = @END_TIME ,
                                                    END_REASON = @END_REASON ,
                                                    GRID_ID = @GRID_ID ,
                                                    PLAN_ID = @PLAN_ID ,
                                                    CRUISE_TYPE = @CRUISE_TYPE ,
                                                    OPERATOR = @OPERATOR ,
                                                    PATROL_STAFF = @PATROL_STAFF ,
                                                    DRIVER = @DRIVER ,
                                                    VEHICLE_NO = @VEHICLE_NO
                                            WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.String, entity.ID);
                    Database.AddInParameter(cmd, "@PATROL_TYPE", DbType.Int32, entity.PatrolType);
                    Database.AddInParameter(cmd, "@END_TIME", DbType.DateTime, entity.EndTime == default(DateTime) ? DateTime.Now : entity.EndTime);
                    Database.AddInParameter(cmd, "@END_REASON", DbType.String, entity.EndReason);
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, entity.GridId);
                    Database.AddInParameter(cmd, "@PLAN_ID", DbType.String, entity.PlanId);
                    Database.AddInParameter(cmd, "@CRUISE_TYPE", DbType.Int32, entity.CruiseType);

                    Database.AddInParameter(cmd, "@OPERATOR", DbType.String, entity.Operator);
                    Database.AddInParameter(cmd, "@PATROL_STAFF", DbType.String, entity.PatrolStaff);
                    Database.AddInParameter(cmd, "@DRIVER", DbType.String, entity.Driver);
                    Database.AddInParameter(cmd, "@VEHICLE_NO", DbType.String, entity.VehicleNo);

                    ExecuteNonQuery(cmd);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "修改巡查任务模型失败！");
            }
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolTaskById(String id)
        {
            try
            {
                string sqltext = @" DELETE  FROM  FW_PATROL_TASK WHERE   ID = @ID; ";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.String, id);
                    return ExecuteNonQuery(cmd) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除指定巡查任务模型失败！");
            }
        }

        /// <summary>
        /// 获取全部模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolTask> GetFWPatrolTaskAll()
        {
            try
            {
                string sqltext = @" SELECT  fwtask.ID ,
                                            fwtask.PATROL_TYPE ,
                                            fwtask.START_TIME ,
                                            fwtask.END_TIME ,
                                            fwtask.END_REASON ,
                                            fwtask.GRID_ID ,
                                            fwtask.PLAN_ID ,
                                            fwtask.CRUISE_TYPE,
                                            fwtask.OPERATOR ,
                                            fwtask.PATROL_STAFF ,
                                            fwtask.DRIVER ,
                                            fwtask.VEHICLE_NO,
                                            fwgrid.NAME AS GRID_NAME 
                                    FROM    FW_PATROL_TASK fwtask
                                            LEFT JOIN FW_GRID fwgrid ON fwtask.GRID_ID = fwgrid.ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询全部巡查任务模型失败！");
            }
        }

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWPatrolTask GetFWPatrolTaskById(String id)
        {
            try
            {
                string sqltext = @" SELECT  fwtask.ID ,
                                            fwtask.PATROL_TYPE ,
                                            fwtask.START_TIME ,
                                            fwtask.END_TIME ,
                                            fwtask.END_REASON ,
                                            fwtask.GRID_ID ,
                                            fwtask.PLAN_ID ,
                                            fwtask.CRUISE_TYPE,
                                            fwtask.OPERATOR ,
                                            fwtask.PATROL_STAFF ,
                                            fwtask.DRIVER ,
                                            fwtask.VEHICLE_NO,
                                            fwgrid.NAME AS GRID_NAME 
                                    FROM    FW_PATROL_TASK fwtask
                                            LEFT JOIN FW_GRID fwgrid ON fwtask.GRID_ID = fwgrid.ID
                                    WHERE   fwtask.ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.String, id);
                    return SelectSingle(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询指定巡查任务模型失败！");
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        public PaginationDto<FWPatrolTask> QueryFWPatrolTaskPage(FWPatrolTaskPageDto queryPageDto)
        {
            try
            {
                string sqlshowcolumn = @"   fwtask.ID ,
                                            fwtask.PATROL_TYPE ,
                                            fwtask.START_TIME ,
                                            fwtask.END_TIME ,
                                            fwtask.END_REASON ,
                                            fwtask.GRID_ID ,
                                            fwtask.PLAN_ID ,
                                            fwtask.CRUISE_TYPE,
                                            fwtask.OPERATOR ,
                                            fwtask.PATROL_STAFF ,
                                            fwtask.DRIVER ,
                                            fwtask.VEHICLE_NO,
                                            fwgrid.NAME AS GRID_NAME 
                                             ";

                string sqlconnectiontext = @" FW_PATROL_TASK fwtask
                                                LEFT JOIN FW_GRID fwgrid ON fwtask.GRID_ID = fwgrid.ID ";

                string sqlwhere = "";

                if (!string.IsNullOrWhiteSpace(queryPageDto.grids))
                {
                    sqlwhere += " AND ( ";
                    sqlwhere += "   fwtask.GRID_ID       IN   (  SELECT ID from dbo.fnQueryRecursionGridDown(" + queryPageDto.grids + "))    ";
                    sqlwhere += " ) ";
                }
                if (!string.IsNullOrWhiteSpace(queryPageDto.users))
                {
                    sqlwhere += " AND ( ";
                    var users = queryPageDto.users.Split(',');
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (i == users.Length - 1)
                        {
                            sqlwhere += "    fwtask.CALC_PATROL_STAFF    LIKE  '%," + users[i] + ",%'    ";
                        }
                        else
                        {
                            sqlwhere += "   fwtask.CALC_PATROL_STAFF  LIKE  '%," + users[i] + ",%'    OR ";
                        }
                    }
                    sqlwhere += "  ) ";
                }
                if (!string.IsNullOrWhiteSpace(queryPageDto.types))
                {
                    sqlwhere += " AND ( ";
                    sqlwhere += "   fwtask.PATROL_TYPE   IN   ( " + queryPageDto.types + " )    ";
                    sqlwhere += " ) ";
                }
                if (queryPageDto.startTime != default(DateTime))
                {
                    sqlwhere += " AND fwtask.START_TIME >= @StartTime ";
                }
                if (queryPageDto.endTime != default(DateTime))
                {
                    sqlwhere += " AND fwtask.START_TIME  <= @EndTime ";
                }

                return PaginationHelper.SelectPage<FWPatrolTask>(Database,
                    sqlconnectiontext,
                    " fwtask.ID  DESC ",
                    sqlwhere,
                    queryPageDto.pageSize,
                    queryPageDto.pageIndex,
                    (p) =>
                    {
                        if (queryPageDto.startTime != default(DateTime))
                        {
                            Database.AddInParameter(p, "@StartTime", DbType.DateTime, queryPageDto.startTime);
                        }
                        if (queryPageDto.endTime != default(DateTime))
                        {
                            Database.AddInParameter(p, "@EndTime", DbType.DateTime, queryPageDto.endTime);
                        }
                    },
                    SelectList,
                    ExecuteScalar<int>,
                    sqlshowcolumn,
                    false);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "分页查询巡查任务模型失败！");
            }
        }

        /// <summary>
        /// 结束巡查
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool EndPatrolTask(string id, string reason, DateTime dateTime)
        {
            try
            {
                string sqltext = @" UPDATE  FW_PATROL_TASK
                                    SET     END_REASON = @END_REASON ,
                                            END_TIME = @END_TIME
                                    WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "ID", DbType.String, id);
                    Database.AddInParameter(cmd, "END_REASON", DbType.String, reason);
                    Database.AddInParameter(cmd, "END_TIME", DbType.DateTime, dateTime == default(DateTime) ? DateTime.Now : dateTime);
                    return ExecuteNonQuery(cmd) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "结束巡查失败！");
            }
        }

        /// <summary>
        /// 获取巡查上报列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<FWIssueViewModel> GetIssuesByTaskId(string id)
        {
            try
            {
                var sql = @"SELECT 
                                t1.ID AS ISSUE_ID, t2.ID AS TYPE_ID, t2.[NAME], t1.IS_BATCH, t1.[TIME], t1.[ADDRESS], t1.[LOCATION], t1.COMMENT, t1.[STATUS]
                            FROM [dbo].[WS_ISSUE] t1
                            	LEFT JOIN [dbo].[WS_TYPE] t2 ON t1.ISSUE_TYPE_ID = t2.ID
                            WHERE t1.WS_ID = @TASK_ID";
                using (var cmd = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(cmd, "@TASK_ID", DbType.String, id);
                    return SelectList<FWIssueViewModel>(cmd, reader => new FWIssueViewModel
                    {
                        Id = reader.GetReaderValue<string>("ISSUE_ID", default(string), true),
                        Type = reader.GetReaderValue<int>("TYPE_ID", default(int), true),
                        TypeName = reader.GetReaderValue<string>("NAME", default(string), true),
                        IsBatch = reader.GetReaderValue<int>("IS_BATCH", default(int), true),
                        Time = reader.GetReaderValue<DateTime>("TIME", default(DateTime), true),
                        Address = reader.GetReaderValue<string>("ADDRESS", default(string), true),
                        Location = reader.GetReaderValue<string>("LOCATION", default(string), true),
                        Comment = reader.GetReaderValue<string>("COMMENT", default(string), true),
                        Status = reader.GetReaderValue<int>("STATUS", default(int), true)
                    });
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取巡查上报列表失败！");
            }
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
        public IEnumerable<FWPatrolTask> GetFWPatrolTaskHistory(string user, DateTime start, DateTime end, int count, int since)
        {
            try
            {
                string sqlwhere = "";
                string sqltext1 = @"     SELECT TOP  @count
                                            *
                                        FROM   ( SELECT    ROW_NUMBER() OVER ( ORDER BY fwtask.ID ) AS ROWID ,
                                                        *
                                                FROM      FW_PATROL_TASK fwtask
                                                WHERE     1 = 1  {0}
                                            ) AS tab
                                        WHERE  tab.ROWID > ( ( @since - 1 ) * @count );";

                if (start != default(DateTime))
                {
                    sqlwhere += " AND fwtask.START_TIME >= @StartTime ";
                }
                if (end != default(DateTime))
                {
                    sqlwhere += " AND fwtask.START_TIME  <= @EndTime ";
                }

                if (!string.IsNullOrWhiteSpace(user))
                {
                    sqlwhere += " AND ( ";
                    var users = user.Split(',');
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (i == users.Length - 1)
                        {
                            sqlwhere += "    fwtask.CALC_PATROL_STAFF    LIKE  '%," + users[i] + ",%'    ";
                        }
                        else
                        {
                            sqlwhere += "   fwtask.CALC_PATROL_STAFF    LIKE  '%," + users[i] + ",%'    OR ";
                        }
                    }
                    sqlwhere += "  ) ";
                }

                string sqltext2 = @" SELECT  *
                                            FROM    FW_PATROL_TASK  fwtask
                                            WHERE   1 = 1 {0}";

                string sqltext = "";

                if (count <= 0 || since <= 0)
                {
                    sqltext = sqltext2;
                }
                else
                {
                    sqltext = sqltext1;
                }
                sqltext = string.Format(sqltext, sqlwhere);
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    if (start != default(DateTime)) { Database.AddInParameter(cmd, "@StartTime", DbType.DateTime, start); }
                    if (end != default(DateTime)) { Database.AddInParameter(cmd, "@EndTime", DbType.DateTime, end); }

                    //if (count >= 10 && since > 0 && count <= 100)
                    if (count > 0 && since > 0)
                    {
                        Database.AddInParameter(cmd, "@count", DbType.Int32, count);
                        Database.AddInParameter(cmd, "@since", DbType.Int32, since);
                    }
                    return SelectList<FWPatrolTask>(cmd, reader =>
                    {
                        FWPatrolTask instance = new FWPatrolTask();
                        instance.ID = reader.GetReaderValue<String>("ID");
                        instance.PatrolType = reader.GetReaderValue<Int32>("PATROL_TYPE");
                        instance.StartTime = reader.GetReaderValue<DateTime>("START_TIME");
                        instance.EndTime = reader.GetReaderValue<DateTime>("END_TIME", default(DateTime), true);
                        instance.EndReason = reader.GetReaderValue<String>("END_REASON", default(String), true);
                        instance.GridId = reader.GetReaderValue<Int32>("GRID_ID");
                        instance.PlanId = reader.GetReaderValue<String>("PLAN_ID", default(String), true);
                        instance.CruiseType = reader.GetReaderValue<Int32>("CRUISE_TYPE");
                        instance.Operator = reader.GetReaderValue<string>("OPERATOR");
                        instance.PatrolStaff = reader.GetReaderValue<string>("PATROL_STAFF");
                        instance.Driver = reader.GetReaderValue<string>("DRIVER", default(string), true);
                        instance.VehicleNo = reader.GetReaderValue<string>("VEHICLE_NO", default(string), true);
                        return instance;
                    });
                }

            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询人员巡查历史失败！");
            }
        }


        /// <summary>
        /// 获取指定巡查任务的结束状态
        /// </summary>
        /// <returns></returns>
        public bool GetPatrolTaskState(string id)
        {
            try
            {
                string sqltext = @" SELECT  ( CASE ISNULL(END_TIME, 0)
                                                WHEN 0 THEN 0
                                                ELSE 1
                                              END ) AS STATE
                                    FROM    FW_PATROL_TASK
                                    WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.String, id);
                    return ExecuteScalar<int>(cmd) == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取任务状态失败！");
            }
        }

    }
}
