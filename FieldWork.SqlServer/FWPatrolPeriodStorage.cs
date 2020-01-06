using SH3H.SDK.DataAccess.Db;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class FWPatrolPeriodStorage : BaseAccess<FWPatrolPeriod>, IFWPatrolPeriodStorage
    {
        public FWPatrolPeriodStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override FWPatrolPeriod Build(System.Data.IDataReader reader, FWPatrolPeriod instance)
        {
            try
            {
                instance.PeriodId = reader.GetReaderValue<int>("PERIOD_ID");
                instance.PeriodBase = reader.GetReaderValue<int>("PERIOD_BASE");
                instance.Interval = reader.GetReaderValue<int>("INTERVAL");

                return base.Build(reader, instance);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "巡查周期模型转换失败！");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolPeriod CreateFWPatrolPeriod(FWPatrolPeriod entity)
        {
            try
            {
                string sqltext = @" DECLARE @newID INT;
                                    SELECT  @newID = CASE ISNULL(MAX(PERIOD_ID), 0)
                                                       WHEN 0 THEN 1
                                                       ELSE ( MAX(PERIOD_ID) + 1 )
                                                     END
                                    FROM    FW_PATROL_PERIOD;
                                    INSERT  FW_PATROL_PERIOD
                                            ( PERIOD_ID, PERIOD_BASE, INTERVAL )
                                    VALUES  ( @newID, @PERIOD_BASE, @INTERVAL );
                                    SELECT  @newID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@PERIOD_BASE", DbType.Int32, entity.PeriodBase);
                    Database.AddInParameter(cmd, "@INTERVAL", DbType.Int32, entity.Interval);
                    var result = ExecuteScalar<int>(cmd);
                    entity.PeriodId = result;
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增巡查周期模型失败！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolPeriod(int id)
        {
            try
            {
                string sqltext = @" DELETE  FROM FW_PATROL_PERIOD WHERE   PERIOD_ID = @PERIOD_ID; ";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@PERIOD_ID", DbType.Int32, id);
                    return ExecuteNonQuery(cmd) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除巡查周期模型失败！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolPeriod UpdateFWPatrolPeriodById(int id, FWPatrolPeriod entity)
        {
            try
            {
                string sqltext = @" UPDATE  FW_PATROL_PERIOD
                                            SET     PERIOD_BASE = @PERIOD_BASE ,
                                                    INTERVAL = @INTERVAL
                                            WHERE   PERIOD_ID = @PERIOD_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@PERIOD_BASE", DbType.Int32, entity.PeriodBase);
                    Database.AddInParameter(cmd, "@INTERVAL", DbType.Int32, entity.Interval);
                    Database.AddInParameter(cmd, "@PERIOD_ID", DbType.Int32, entity.PeriodId);
                    ExecuteNonQuery(cmd);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "修改巡查周期模型失败！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWPatrolPeriod GetFWPatrolPeriodById(int id)
        {
            try
            {
                string sqltext = @" SELECT  PERIOD_ID ,
                                            PERIOD_BASE ,
                                            INTERVAL
                                    FROM    FW_PATROL_PERIOD
                                    WHERE   PERIOD_ID = @PERIOD_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@PERIOD_ID", DbType.Int32, id);
                    return SelectSingle(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询指定巡查周期模型失败！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolPeriod> GetFWPatrolPeriodAll()
        {
            try
            {
                string sqltext = @" SELECT  PERIOD_ID ,
                                            PERIOD_BASE ,
                                            INTERVAL
                                    FROM    FW_PATROL_PERIOD;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取全部巡查模型失败！");
            }
        }
    }
}
