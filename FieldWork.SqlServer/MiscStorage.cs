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
using SH3H.WAP.FieldWork.Model;
using System.Data;
using Newtonsoft.Json;

namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    /// <summary>
    /// 定义杂项数据访问对象
    /// </summary>
    public class MiscStorage : BaseAccess<string>, IMiscStorage
    {
        /// <summary>
        /// 构造
        /// </summary>
        public MiscStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// 根据工单编号获取到场时间
        /// </summary>
        /// <param name="TaskId">工单编号</param>
        /// <returns></returns>
        public string GetArriveTimeById(string TaskId)
        {
            try
            {
                string result = null;
                string sqltext = @" SELECT MAX(OPERATE_TIME) AS OPERATE_TIME FROM [dbo].[WS_INST_STEP] WHERE NODE_ID = 'Arrive' AND WS_ID = @WS_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@WS_ID", DbType.String, TaskId);
                    using (IDataReader reader = ExecuteReader(cmd))
                    {
                        while (reader.Read())
                            result = reader.GetReaderValue<string>("OPERATE_TIME",default(string),true);
                        return result;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取到场时间失败");
            }
        }

        /// <summary>
        /// 获取换表失败工单
        /// </summary>
        /// <returns></returns>
        public List<string> GetBWFPLHB()
        {
            try
            {
                List<string> results = new List<string>();
                string sqltext = @" SELECT * from [dbo].[WS_SNAPSHOT] WHERE WS_TYPE_ID = 913 AND QUEUE_PROCESS = 41 AND VER_DESC = 'Submit';";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    using (IDataReader reader = ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            string result = reader.GetReaderValue<string>("WS_ID", default(string), true);
                            results.Add(result);
                        }
                        return results;
                    }

                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取失败");
            }
        }

        /// <summary>
        /// 根据换表失败工单编号更换状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateBWFPLHB(string TaskId)
        {
            try
            {
                string sqltext = @" UPDATE [dbo].[WS_SNAPSHOT] SET QUEUE_PROCESS = 0, TRY_COUNT = 0 WHERE QUEUE_PROCESS = 41 AND WS_ID = @WS_ID";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@WS_ID", DbType.String, TaskId);
                    return ExecuteNonQuery(cmd) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "更新失败");
            }
        }

        /// <summary>
        /// 根据换表工单编号获取所需字段
        /// </summary>
        /// <returns></returns>
        public MeterNew GetFields(string TaskId , string Table)
        {
            try
            {
                MeterNew meterNew = new MeterNew();
                string sqltext = @" SELECT * FROM " + Table + " WHERE WORK_SHEET_ID = @TaskId";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@TaskId", DbType.String, TaskId);
                    using (IDataReader reader = ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            meterNew.wsId = reader.GetReaderValue<string>("WORK_SHEET_ID", default(string), true);
                            meterNew.oldMeterNumber = reader.GetReaderValue<string>("WATER_METER_NUMBER", default(string), true);
                            meterNew.disposeSituation = reader.GetReaderValue<int>("DISPOSE_SITUATION", default(int), true);
                            meterNew.number = reader.GetReaderValue<string>("NEW_NUMBER", default(string), true);
                            meterNew.factory = reader.GetReaderValue<string>("NEW_MANUFACTURER", default(string), true);
                            meterNew.meterModule = reader.GetReaderValue<string>("NEW_MODEL_NUMBER", default(string), true);
                            meterNew.type = reader.GetReaderValue<int>("NEW_METER_TYPE", default(int), true);
                            meterNew.sealNumber = reader.GetReaderValue<string>("NEW_SEAL_NUMBER", default(string), true);
                            meterNew.caliber = reader.GetReaderValue<int>("NEW_CALIBER", default(int), true);
                        }
                        return meterNew;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取失败");
            }
        }

        /// <summary>
        /// 根据工单编号获取工单类型
        /// </summary>
        /// <returns></returns>
        public int GetTaskType(string TaskId)
        {
            try
            {
                int result = 0;
                string sqltext = @" SELECT * FROM [dbo].[WS_INST] WHERE ID = @ID";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.String, TaskId);
                    using (IDataReader reader = ExecuteReader(cmd))
                    {
                        while(reader.Read())
                        {
                            result = reader.GetReaderValue("WS_TYPE_ID", default(int), true);
                        }
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询类型失败");
            }
        }

        /// <summary>
        /// 根据工单类型获取表单
        /// </summary>
        /// <returns></returns>
        public string GetTable(int TypeId)
        {
            try
            {
                string result = "";
                string sqltext = @" SELECT * FROM [dbo].[WS_BIZDB_TABLE] WHERE [PRIMARY] = 1 AND TYPE_ID = @TYPE_ID";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@TYPE_ID", DbType.Int32, TypeId);
                    using (IDataReader reader = ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            result = reader.GetReaderValue("TABLE_NAME", default(string), true);
                        }
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询类型失败");
            }
        }
    }
}
