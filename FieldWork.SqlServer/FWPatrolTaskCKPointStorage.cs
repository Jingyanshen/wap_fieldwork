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
    /// 必达点打卡数据操作模型接口实现
    /// </summary>
    public class FWPatrolTaskCKPointStorage : BaseAccess<FWPatrolTaskCKPoint>, IFWPatrolTaskCKPointStorage
    {
        /// <summary>
        /// 
        /// </summary>
        public FWPatrolTaskCKPointStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override FWPatrolTaskCKPoint Build(System.Data.IDataReader reader, FWPatrolTaskCKPoint instance)
        {
            try
            {
                instance.TaskId = reader.GetReaderValue<string>("TASK_ID");
                instance.CKPonitId = reader.GetReaderValue<int>("CKPOINT_ID");
                instance.Status = reader.GetReaderValue<bool>("STATUS");
                instance.CheckInNum = reader.GetReaderValue<int>("CHECKIN_NUM");
                instance.CheckInTime = reader.GetReaderValue<DateTime>("CHECKIN_TIME");
                instance.CheckInX = reader.GetReaderValue<decimal>("CHECKIN_X", default(decimal), true);
                instance.CheckInY = reader.GetReaderValue<decimal>("CHECKIN_Y", default(decimal), true);

                //关联表
                instance.PatrolType = reader.GetReaderValue<int>("PATROL_TYPE");
                instance.CKPointName = reader.GetReaderValue<string>("CKPOINT_NAME",default(string),true);

                return base.Build(reader, instance);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "模型转换失败！");
            }
        }
        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTaskCKPoint CreateFWPatrolTaskCKPoint(FWPatrolTaskCKPoint entity)
        {
            try
            {
                string sqltext = @" INSERT  INTO    FW_PATROL_TASK_CKPOINT
                                                            ( TASK_ID ,
                                                              CKPOINT_ID ,
                                                              STATUS ,
                                                              CHECKIN_NUM ,
                                                              CHECKIN_TIME ,
                                                              CHECKIN_X ,
                                                              CHECKIN_Y
                                                            )
                                                    VALUES  ( @TASK_ID ,
                                                              @CKPOINT_ID ,
                                                              @STATUS ,
                                                              @CHECKIN_NUM ,
                                                              @CHECKIN_TIME ,
                                                              @CHECKIN_X ,
                                                              @CHECKIN_Y
                                                            );";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@TASK_ID", DbType.String, entity.TaskId);
                    Database.AddInParameter(cmd, "@CKPOINT_ID", DbType.Int32, entity.CKPonitId);
                    Database.AddInParameter(cmd, "@STATUS", DbType.Boolean, entity.Status);
                    Database.AddInParameter(cmd, "@CHECKIN_NUM", DbType.Int32, entity.CheckInNum);
                    Database.AddInParameter(cmd, "@CHECKIN_TIME", DbType.DateTime, entity.CheckInTime);
                    Database.AddInParameter(cmd, "@CHECKIN_X", DbType.Decimal, entity.CheckInX);
                    Database.AddInParameter(cmd, "@CHECKIN_Y", DbType.Decimal, entity.CheckInY);
                    ExecuteScalar(cmd);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增必达点打卡模型失败！");
            }
        }

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTaskCKPoint UpdateFWPatrolTaskCKPointById(string tid, int ckpid, FWPatrolTaskCKPoint entity)
        {
            try
            {
                string sqltext = @" UPDATE  FW_PATROL_TASK_CKPOINT
                                            SET     STATUS = @STATUS ,
                                                    CHECKIN_NUM = @CHECKIN_NUM ,
                                                    CHECKIN_TIME = @CHECKIN_TIME ,
                                                    CHECKIN_X = @CHECKIN_X ,
                                                    CHECKIN_Y = @CHECKIN_Y
                                            WHERE   TASK_ID = @TASK_ID
                                                    AND CKPOINT_ID = @CKPOINT_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@TASK_ID", DbType.String, entity.TaskId);
                    Database.AddInParameter(cmd, "@CKPOINT_ID", DbType.Int32, entity.CKPonitId);
                    Database.AddInParameter(cmd, "@STATUS", DbType.Boolean, entity.Status);
                    Database.AddInParameter(cmd, "@CHECKIN_NUM", DbType.Int32, entity.CheckInNum);
                    Database.AddInParameter(cmd, "@CHECKIN_TIME", DbType.DateTime, entity.CheckInTime);
                    Database.AddInParameter(cmd, "@CHECKIN_X", DbType.Decimal, entity.CheckInX);
                    Database.AddInParameter(cmd, "@CHECKIN_Y", DbType.Decimal, entity.CheckInY);
                    ExecuteNonQuery(cmd);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "修改必达点打卡模型失败！");
            }
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolTaskCKPointById(string tid, int ckpid)
        {
            try
            {
                string sqltext = @" DELETE  FROM FW_PATROL_TASK_CKPOINT
                                            WHERE   TASK_ID = @TASK_ID
                                                    AND CKPOINT_ID = @CKPOINT_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@TASK_ID", DbType.String, tid);
                    Database.AddInParameter(cmd, "@CKPOINT_ID", DbType.Int32, ckpid);
                    return ExecuteNonQuery(cmd) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除指定必达点打卡模型失败！");
            }
        }

        /// <summary>
        /// 查询全部模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointAll()
        {
            try
            {
                string sqltext = @" SELECT  fwtaskckpoint.TASK_ID ,
                                            fwtaskckpoint.CKPOINT_ID ,
                                            fwtaskckpoint.STATUS ,
                                            fwtaskckpoint.CHECKIN_NUM ,
                                            fwtaskckpoint.CHECKIN_TIME ,
                                            fwtaskckpoint.CHECKIN_X ,
                                            fwtaskckpoint.CHECKIN_Y ,
                                            fwtask.PATROL_TYPE AS PATROL_TYPE ,
                                            fwckpoint.NAME AS CKPOINT_NAME
                                    FROM    FW_PATROL_TASK_CKPOINT fwtaskckpoint
                                            LEFT JOIN FW_PATROL_TASK fwtask ON fwtaskckpoint.TASK_ID = fwtask.ID
                                            LEFT JOIN dbo.FW_PATROL_CKPOINT fwckpoint ON fwtaskckpoint.CKPOINT_ID = fwckpoint.ID";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取全部必达点打卡模型失败！");
            }
        }

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        public FWPatrolTaskCKPoint GetFWPatrolTaskCKPointByTidAndCkPId(string tid, int ckpid)
        {
            try
            {
                string sqltext = @" SELECT  fwtaskckpoint.TASK_ID ,
                                            fwtaskckpoint.CKPOINT_ID ,
                                            fwtaskckpoint.STATUS ,
                                            fwtaskckpoint.CHECKIN_NUM ,
                                            fwtaskckpoint.CHECKIN_TIME ,
                                            fwtaskckpoint.CHECKIN_X ,
                                            fwtaskckpoint.CHECKIN_Y ,
                                            fwtask.PATROL_TYPE AS PATROL_TYPE ,
                                            fwckpoint.NAME AS CKPOINT_NAME
                                    FROM    FW_PATROL_TASK_CKPOINT fwtaskckpoint
                                            LEFT JOIN FW_PATROL_TASK fwtask ON fwtaskckpoint.TASK_ID = fwtask.ID
                                            LEFT JOIN dbo.FW_PATROL_CKPOINT fwckpoint ON fwtaskckpoint.CKPOINT_ID = fwckpoint.ID
                                    WHERE   TASK_ID = @TASK_ID
                                            AND CKPOINT_ID = @CKPOINT_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@TASK_ID", DbType.String, tid);
                    Database.AddInParameter(cmd, "@CKPOINT_ID", DbType.Int32, ckpid);
                    return SelectSingle(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询指定必达点打卡模型失败！");
            }
        }

        /// <summary>
        /// 根据指定任务编号获取模型列表
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointByTid(string tid)
        {
            try
            {
                string sqltext = @" SELECT  fwtaskckpoint.TASK_ID ,
                                            fwtaskckpoint.CKPOINT_ID ,
                                            fwtaskckpoint.STATUS ,
                                            fwtaskckpoint.CHECKIN_NUM ,
                                            fwtaskckpoint.CHECKIN_TIME ,
                                            fwtaskckpoint.CHECKIN_X ,
                                            fwtaskckpoint.CHECKIN_Y ,
                                            fwtask.PATROL_TYPE AS PATROL_TYPE ,
                                            fwckpoint.NAME AS CKPOINT_NAME
                                    FROM    FW_PATROL_TASK_CKPOINT fwtaskckpoint
                                            LEFT JOIN FW_PATROL_TASK fwtask ON fwtaskckpoint.TASK_ID = fwtask.ID
                                            LEFT JOIN dbo.FW_PATROL_CKPOINT fwckpoint ON fwtaskckpoint.CKPOINT_ID = fwckpoint.ID
                                    WHERE   TASK_ID = @TASK_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@TASK_ID", DbType.String, tid);
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "根据指定任务编号获取必达点打卡模型列表失败！");
            }
        }

        /// <summary>
        /// 根据必达点编号获取模型列表
        /// </summary>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointByCKid(int ckpid)
        {
            try
            {
                string sqltext = @" SELECT  fwtaskckpoint.TASK_ID ,
                                            fwtaskckpoint.CKPOINT_ID ,
                                            fwtaskckpoint.STATUS ,
                                            fwtaskckpoint.CHECKIN_NUM ,
                                            fwtaskckpoint.CHECKIN_TIME ,
                                            fwtaskckpoint.CHECKIN_X ,
                                            fwtaskckpoint.CHECKIN_Y ,
                                            fwtask.PATROL_TYPE AS PATROL_TYPE ,
                                            fwckpoint.NAME AS CKPOINT_NAME
                                    FROM    FW_PATROL_TASK_CKPOINT fwtaskckpoint
                                            LEFT JOIN FW_PATROL_TASK fwtask ON fwtaskckpoint.TASK_ID = fwtask.ID
                                            LEFT JOIN dbo.FW_PATROL_CKPOINT fwckpoint ON fwtaskckpoint.CKPOINT_ID = fwckpoint.ID
                                    WHERE   CKPOINT_ID = @CKPOINT_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@CKPOINT_ID", DbType.Int32, ckpid);
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "根据必达点编号获取模型列表失败！");
            }
        }

        /// <summary>
        /// 获取模型分页列表
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        public PaginationDto<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointPage(FWPatrolTaskCKPointPageDto queryPageDto)
        {
            try
            {


                string sqlconnecttable = @" FW_PATROL_TASK_CKPOINT fwtaskckpoint
                                            LEFT JOIN FW_PATROL_TASK fwtask ON fwtaskckpoint.TASK_ID = fwtask.ID
                                            LEFT JOIN dbo.FW_PATROL_CKPOINT fwckpoint ON fwtaskckpoint.CKPOINT_ID = fwckpoint.ID";

                string sqlshowcolumns = @"  fwtaskckpoint.TASK_ID ,
                                            fwtaskckpoint.CKPOINT_ID ,
                                            fwtaskckpoint.STATUS ,
                                            fwtaskckpoint.CHECKIN_NUM ,
                                            fwtaskckpoint.CHECKIN_TIME ,
                                            fwtaskckpoint.CHECKIN_X ,
                                            fwtaskckpoint.CHECKIN_Y ,
                                            fwtask.PATROL_TYPE AS PATROL_TYPE ,
                                            fwckpoint.NAME AS CKPOINT_NAME";

                string sqlwhere = " ";
                if (queryPageDto.ckpointId > 0)
                {
                    sqlwhere += " AND   fwtaskckpoint.CKPOINT_ID = @CKPOINT_ID ";
                }
                if (!string.IsNullOrWhiteSpace(queryPageDto.key))
                {
                    sqlwhere += "  AND  ( ";
                    sqlwhere += "  fwckpoint.NAME        LIKE   @Key   OR  ";
                    sqlwhere += "  fwckpoint.TASK_ID     LIKE   @Key       ";
                    sqlwhere += "        ) ";
                }

                if (queryPageDto.ckpointTime != default(DateTime))
                {
                    sqlwhere += @"  AND   fwtaskckpoint.CHECKIN_TIME >= CONVERT(VARCHAR(10), @CHECKIN_TIME , 120)
                                          AND fwtaskckpoint.CHECKIN_TIME < CONVERT(VARCHAR(10), DATEADD(d, 1,
                                                                                                @CHECKIN_TIME ), 120)  ";
                }
                return PaginationHelper.SelectPage(Database,
                    sqlconnecttable,
                    "",
                    sqlwhere,
                    queryPageDto.pageSize,
                     queryPageDto.pageIndex,
                     (p) =>
                     {
                         if (queryPageDto.ckpointId > 0)
                         {
                             Database.AddInParameter(p, "@CKPOINT_ID", DbType.Int32, queryPageDto.ckpointId);
                         }
                         if (!string.IsNullOrWhiteSpace(queryPageDto.key))
                         {
                             Database.AddInParameter(p, "@Key", DbType.String, queryPageDto.key);
                         }
                         if (queryPageDto.ckpointTime != default(DateTime))
                         {
                             Database.AddInParameter(p, "@CHECKIN_TIME", DbType.DateTime, queryPageDto.ckpointTime);
                         }
                     },
                     SelectList,
                     ExecuteScalar<int>,
                     sqlshowcolumns);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取必达点打卡模型分页列表失败！");
            }
        }
    }
}
