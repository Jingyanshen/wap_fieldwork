using SH3H.SDK.DataAccess.Db;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.SharpFrame.Data;
using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Infrastructure.Logging;
using SH3H.WAP.FieldWork.Share;
using System.Data;
using SH3H.WAP.FieldWork.Model.ViewModels;
namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    public class FWPatrolPlanStorage : BaseAccess<FWPatrolPlan>, IFWPatrolPlanStorage
    {
        public FWPatrolPlanStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        public FWPatrolPlan Insert(FWPatrolPlan entity)
        {
            try
            {
                var validateSql = string.Format("SELECT * FROM [dbo].[FW_PATROL_PLAN] WHERE PATROL_TYPE = {0} AND (START_TIME BETWEEN '{1}' AND '{2}') AND EXECUTOR LIKE '%{3}%'", entity.PatrolType, entity.StartDate, entity.EndTime, entity.Executor);

                var target = SelectSingle(validateSql);

                if (null == target)
                {
                    var sql = @"INSERT INTO [dbo].[FW_PATROL_PLAN]
                                                    ( ID ,
                                                      PATROL_TYPE ,
                                                      START_TIME ,
                                                      END_TIME ,
                                                      INSPECT_NUM,
                                                      [STATUS] ,
                                                      GRID_ID ,
                                                      EXECUTOR,
                                                      EXECUTE_STATION,
                                                      LEADER,
                                                      REMARK,
                                                      CREATOR,
                                                      CREATE_TIME
                                                    )
                                            VALUES  ( @ID ,
                                                      @PATROL_TYPE ,
                                                      @START_TIME ,
                                                      @END_TIME ,
                                                      @INSPECT_NUM ,
                                                      @STATUS ,
                                                      @GRID_ID ,
                                                      @EXECUTOR ,
                                                      @EXECUTE_STATION ,
                                                      @LEADER ,
                                                      @REMARK ,
                                                      @CREATOR ,
                                                      @CREATE_TIME
                                                    );";
                    using (var command = Database.GetSqlStringCommand(sql))
                    {
                        Database.AddInParameter(command, "@ID", DbType.String, entity.Id);
                        Database.AddInParameter(command, "@PATROL_TYPE", DbType.Int32, entity.PatrolType);
                        Database.AddInParameter(command, "@START_TIME", DbType.DateTime, entity.StartDate);
                        Database.AddInParameter(command, "@END_TIME", DbType.DateTime, entity.EndTime);
                        Database.AddInParameter(command, "@INSPECT_NUM", DbType.Int32, entity.InspectNum);
                        Database.AddInParameter(command, "@STATUS", DbType.Int32, entity.Status);
                        Database.AddInParameter(command, "@GRID_ID", DbType.Int32, entity.GridId);
                        Database.AddInParameter(command, "@EXECUTOR", DbType.String, entity.Executor);
                        Database.AddInParameter(command, "@EXECUTE_STATION", DbType.Int32, entity.ExecuteStation);
                        Database.AddInParameter(command, "@LEADER", DbType.String, entity.Leader ?? "");
                        Database.AddInParameter(command, "@REMARK", DbType.String, entity.Remark ?? "");
                        Database.AddInParameter(command, "@CREATOR", DbType.String, entity.Creator);
                        Database.AddInParameter(command, "@CREATE_TIME", DbType.DateTime, entity.CreateTime);
                        return ExecuteNonQuery(command) > 0 ? entity : null;
                    }
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增模型失败！");
            }
        }

        public bool ChangeStatus(string id, int status)
        {
            try
            {
                var sql = @"UPDATE [dbo].[FW_PATROL_PLAN] SET [STATUS] = @STATUS WHERE ID = @ID";

                var flag = 1;

                switch (status)
                {
                    case -1:
                        flag = (int)DeletedStatus.Deleted;
                        break;
                    case 0:
                        flag = (int)DeletedStatus.Disable;
                        break;
                    default:
                        flag = (int)DeletedStatus.Enable;
                        break;
                }

                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@STATUS", DbType.Int32, flag);
                    Database.AddInParameter(command, "@ID", DbType.String, id);
                    return ExecuteNonQuery(command) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除模型失败！");
            }
        }

        public bool Update(FWPatrolPlan entity, string content)
        {
            try
            {
                var sql = @"UPDATE [dbo].[FW_PATROL_PLAN] SET PATROL_TYPE = @PATROL_TYPE, START_TIME = @START_TIME, END_TIME = @END_TIME, INSPECT_NUM = @INSPECT_NUM, [STATUS] = @STATUS, GRID_ID = @GRID_ID, EXECUTOR = @EXECUTOR, EXECUTE_STATION = @EXECUTE_STATION, LEADER = @LEADER, REMARK = @REMARK WHERE ID = @ID; INSERT INTO [dbo].[FW_PATROL_PLAN_CHANGELOG]( PLAN_ID, CONTENT, MODIFIER, MODIFY_TIME ) VALUES( @PLAN_ID, @CONTENT, @MODIFIER, @MODIFY_TIME )";
                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@ID", DbType.String, entity.Id);
                    Database.AddInParameter(command, "@PATROL_TYPE", DbType.Int32, entity.PatrolType);
                    Database.AddInParameter(command, "@START_TIME", DbType.DateTime, entity.StartDate);
                    Database.AddInParameter(command, "@END_TIME", DbType.DateTime, entity.EndTime);
                    Database.AddInParameter(command, "@INSPECT_NUM", DbType.Int32, entity.InspectNum);
                    Database.AddInParameter(command, "@STATUS", DbType.Int32, entity.Status);
                    Database.AddInParameter(command, "@GRID_ID", DbType.Int32, entity.GridId);
                    Database.AddInParameter(command, "@EXECUTOR", DbType.String, entity.Executor);
                    Database.AddInParameter(command, "@EXECUTE_STATION", DbType.Int32, entity.ExecuteStation);
                    Database.AddInParameter(command, "@LEADER", DbType.String, entity.Leader);
                    Database.AddInParameter(command, "@REMARK", DbType.String, entity.Remark);
                    //FW_PATROL_PLAN_CHANGELOG
                    Database.AddInParameter(command, "@PLAN_ID", DbType.String, entity.Id);
                    Database.AddInParameter(command, "@CONTENT", DbType.String, content);
                    Database.AddInParameter(command, "@MODIFIER", DbType.String, entity.Creator);
                    Database.AddInParameter(command, "@MODIFY_TIME", DbType.DateTime, DateTime.Now);
                    return ExecuteNonQuery(command) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "更新模型失败！");
            }
        }

        public IEnumerable<FWPatrolPlan> QueryAll()
        {
            try
            {
                var sql = "SELECT * FROM [dbo].[FW_PATROL_PLAN] WHERE [STATUS] != " + (int)DeletedStatus.Deleted + " ORDER BY ID DESC";
                return MapEntities(sql);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取模型集合失败");
            }
        }

        private IEnumerable<FWPatrolPlan> MapEntities(string sql)
        {
            return SelectList(sql,
                   reader => new FWPatrolPlan
                   {
                       Id = reader.GetReaderValue<string>("ID"),
                       PatrolType = reader.GetReaderValue<int>("PATROL_TYPE"),
                       StartDate = reader.GetReaderValue<DateTime>("START_TIME"),
                       EndTime = reader.GetReaderValue<DateTime>("END_TIME", default(DateTime), true),
                       InspectNum = reader.GetReaderValue<int>("INSPECT_NUM", default(int), true),
                       Status = reader.GetReaderValue<int>("STATUS"),
                       GridId = reader.GetReaderValue<int>("GRID_ID"),
                       Executor = reader.GetReaderValue<string>("EXECUTOR"),
                       ExecuteStation = reader.GetReaderValue<int>("EXECUTE_STATION", default(int), true),
                       Leader = reader.GetReaderValue<string>("LEADER"),
                       Remark = reader.GetReaderValue<string>("REMARK", default(string), true),
                       Creator = reader.GetReaderValue<string>("CREATOR"),
                       CreateTime = reader.GetReaderValue<DateTime>("CREATE_TIME"),
                   });
        }


        public IEnumerable<FWPatrolPlan> Search(FWPatrolPlanViewModel planViewModel)
        {
            try
            {
                var sql = "SELECT * FROM [dbo].[FW_PATROL_PLAN] WHERE [STATUS] != " + (int)DeletedStatus.Deleted + " ";

                if (planViewModel.PatrolTypes.Length > 0)
                {
                    sql += "AND (";
                    foreach (var type in planViewModel.PatrolTypes)
                    {
                        if (!string.IsNullOrEmpty(type))
                        {
                            sql += "PATROL_TYPE = " + int.Parse(type) + " OR ";
                        }
                    }
                    sql = sql.Substring(0, sql.Length - 3);
                    sql += ") ";
                }

                if (planViewModel.GridId != -1)
                {
                    sql += "AND GRID_ID = " + planViewModel.GridId + " ";
                }

                if (!string.IsNullOrEmpty(planViewModel.Executor))
                {
                    sql += "AND EXECUTOR LIKE '%" + planViewModel.Executor + "%' ";
                }

                if (!string.IsNullOrEmpty(planViewModel.StartDate.ToString("yyyy-MM-dd")) && !string.IsNullOrEmpty(planViewModel.EndTime.ToString("yyyy-MM-dd")))
                {
                    sql += "AND (START_TIME BETWEEN '" + planViewModel.StartDate + "' AND '" + planViewModel.EndTime + "') AND (END_TIME BETWEEN '" + planViewModel.StartDate + "' AND '" + planViewModel.EndTime + "') ";
                }

                sql += "ORDER BY ID DESC";

                return MapEntities(sql);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取模型集合失败");
            }
        }
    }

    public enum DeletedStatus
    {
        /// <summary>
        /// 删除
        /// </summary>
        Deleted = -1,
        /// <summary>
        /// 禁用
        /// </summary>
        Disable = 0,
        /// <summary>
        /// 启用
        /// </summary>
        Enable = 1
    }
}
