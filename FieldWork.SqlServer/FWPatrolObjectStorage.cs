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

namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    /// <summary>
    /// 定义模型SqlServer数据访问对象
    /// </summary>
    public class FWPatrolObjectStorage : BaseAccess<FWPatrolObject>, IFWPatrolObjectStorage
    {
        /// <summary>
        /// 构造
        /// </summary>
        public FWPatrolObjectStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolObject CreateFWPatrolObject(FWPatrolObject entity)
        {
            try
            {
                string sqltext = @" INSERT  INTO    FW_PATROL_OBJECT
                                                    ( 
                                                        DISPLAY_ID ,
                                                        NAME ,
                                                        PATROL_TYPE ,
                                                        ADDRESS ,
                                                        X ,
                                                        Y ,
                                                        GRID_ID ,
                                                        ROAD ,
                                                        PERIOD ,
                                                        FREQUENCY ,
                                                        PERIOD_ID ,
                                                        EXTEND ,
                                                        CREATOR ,
                                                        CREATE_TIME ,
                                                        GIS_OBJECTID ,
                                                        GIS_LAYERID ,
                                                        MAP_LAYERID,
                                                        GRADE
                                                    )
                                            VALUES  ( 
                                                        @DISPLAY_ID ,
                                                        @NAME ,
                                                        @PATROL_TYPE ,
                                                        @ADDRESS ,
                                                        @X ,
                                                        @Y ,
                                                        @GRID_ID ,
                                                        @ROAD ,
                                                        @PERIOD ,
                                                        @FREQUENCY ,
                                                        @PERIOD_ID ,
                                                        @EXTEND ,
                                                        @CREATOR ,
                                                        @CREATE_TIME ,
                                                        @GIS_OBJECTID ,
                                                        @GIS_LAYERID ,
                                                        @MAP_LAYERID,
                                                        @GRADE
                                                    );
                                            SELECT  @@IDENTITY;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@DISPLAY_ID", DbType.String, entity.DisplayId);
                    Database.AddInParameter(cmd, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(cmd, "@PATROL_TYPE", DbType.Int32, entity.PatrolType);
                    Database.AddInParameter(cmd, "@ADDRESS", DbType.String, entity.Address);
                    Database.AddInParameter(cmd, "@X", DbType.Decimal, entity.X);
                    Database.AddInParameter(cmd, "@Y", DbType.Decimal, entity.Y);
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, entity.GridId);
                    Database.AddInParameter(cmd, "@ROAD", DbType.String, entity.Road);
                    Database.AddInParameter(cmd, "@PERIOD", DbType.String, entity.Period);
                    Database.AddInParameter(cmd, "@FREQUENCY", DbType.Int32, entity.Frequency);
                    Database.AddInParameter(cmd, "@PERIOD_ID", DbType.Int32, entity.PeriodId);
                    Database.AddInParameter(cmd, "@EXTEND", DbType.String, entity.Extend);
                    Database.AddInParameter(cmd, "@CREATOR", DbType.String, entity.Creator);
                    Database.AddInParameter(cmd, "@CREATE_TIME", DbType.DateTime, entity.CreateTime == default(DateTime) ? DateTime.Now : entity.CreateTime);
                    Database.AddInParameter(cmd, "@GIS_OBJECTID", DbType.String, entity.GisObjectId);
                    Database.AddInParameter(cmd, "@GIS_LAYERID", DbType.String, entity.GisLayerId);
                    Database.AddInParameter(cmd, "@MAP_LAYERID", DbType.String, entity.MapLayerId);
                    Database.AddInParameter(cmd, "@GRADE", DbType.Int32, entity.Grade);

                    int id = ExecuteScalar<int>(cmd);
                    entity.ID = id;
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增巡查对象模型失败");
            }
        }

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="patrolPeriodid"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolObject UpdateFWPatrolObjectById(int id, FWPatrolObject entity)
        {
            try
            {
                string sqltext = @" UPDATE  FW_PATROL_OBJECT
                                            SET     DISPLAY_ID = @DISPLAY_ID ,
                                                    NAME = @NAME ,
                                                    PATROL_TYPE = @PATROL_TYPE ,
                                                    ADDRESS = @ADDRESS ,
                                                    X = @X ,
                                                    Y = @Y ,
                                                    GRID_ID = @GRID_ID ,
                                                    ROAD = @ROAD ,
                                                    PERIOD = @PERIOD ,
                                                    FREQUENCY = @FREQUENCY ,
                                                    PERIOD_ID = @PERIOD_ID ,
                                                    EXTEND = @EXTEND ,
                                                    GIS_OBJECTID = @GIS_OBJECTID ,
                                                    GIS_LAYERID = @GIS_LAYERID ,
                                                    MAP_LAYERID = @MAP_LAYERID,
                                                    GRADE=@GRADE
                                            WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@DISPLAY_ID", DbType.String, entity.DisplayId);
                    Database.AddInParameter(cmd, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(cmd, "@PATROL_TYPE", DbType.Int32, entity.PatrolType);
                    Database.AddInParameter(cmd, "@ADDRESS", DbType.String, entity.Address);
                    Database.AddInParameter(cmd, "@X", DbType.Decimal, entity.X);
                    Database.AddInParameter(cmd, "@Y", DbType.Decimal, entity.Y);
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, entity.GridId);
                    Database.AddInParameter(cmd, "@ROAD", DbType.String, entity.Road);
                    Database.AddInParameter(cmd, "@PERIOD", DbType.String, entity.Period);
                    Database.AddInParameter(cmd, "@FREQUENCY", DbType.Int32, entity.Frequency);
                    Database.AddInParameter(cmd, "@PERIOD_ID", DbType.Int32, entity.PeriodId);
                    Database.AddInParameter(cmd, "@EXTEND", DbType.String, entity.Extend);
                    Database.AddInParameter(cmd, "@GIS_OBJECTID", DbType.String, entity.GisObjectId);
                    Database.AddInParameter(cmd, "@GIS_LAYERID", DbType.String, entity.GisLayerId);
                    Database.AddInParameter(cmd, "@MAP_LAYERID", DbType.String, entity.MapLayerId);
                    Database.AddInParameter(cmd, "@GRADE", DbType.Int32, entity.Grade);


                    Database.AddInParameter(cmd, "@ID", DbType.Int32, id);

                    ExecuteNonQuery(cmd);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "修改巡查对象模型失败");
            }
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="patrolPeriodid"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolObject(int id)
        {
            try
            {
                string sqltext = @" DELETE  FROM FW_PATROL_OBJECT  WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, id);
                    ExecuteNonQuery(cmd);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除巡查对象模型失败");
            }
        }

        /// <summary>
        /// 获取全部模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolObject> GetFWPatrolObjectAll()
        {
            try
            {
                string sqltext = @" SELECT  ID ,
                                            DISPLAY_ID ,
                                            NAME ,
                                            PATROL_TYPE ,
                                            ADDRESS ,
                                            X ,
                                            Y ,
                                            GRID_ID ,
                                            ROAD ,
                                            PERIOD ,
                                            FREQUENCY ,
                                            PERIOD_ID ,
                                            EXTEND ,
                                            CREATOR ,
                                            CREATE_TIME ,
                                            GIS_OBJECTID ,
                                            GIS_LAYERID ,
                                            MAP_LAYERID,GRADE
                                    FROM    FW_PATROL_OBJECT
                                    ORDER BY ID DESC;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    var result = SelectList(cmd);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取所有巡查对象模型失败");
            }
        }

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="patrolPeriodid"></param>
        /// <returns></returns>
        public FWPatrolObject GetFWPatrolObjectById(int id)
        {
            try
            {
                string sqltext = @" SELECT  ID ,
                                            DISPLAY_ID ,
                                            NAME ,
                                            PATROL_TYPE ,
                                            ADDRESS ,
                                            X ,
                                            Y ,
                                            GRID_ID ,
                                            ROAD ,
                                            PERIOD ,
                                            FREQUENCY ,
                                            PERIOD_ID ,
                                            EXTEND ,
                                            CREATOR ,
                                            CREATE_TIME ,
                                            GIS_OBJECTID ,
                                            GIS_LAYERID ,
                                            MAP_LAYERID,GRADE
                                    FROM    FW_PATROL_OBJECT
                                    WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, id);
                    return SelectSingle(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取指定巡查对象模型失败");
            }
        }

        /// <summary>
        /// 根据网格编号获取对应FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="GridId"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolObject> GetFWPatrolObjectByGridId(int GridId)
        {
            try
            {
                string sqltext = @" SELECT  *
                                    FROM    FW_PATROL_OBJECT
                                    WHERE   GRID_ID = @GRID_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, GridId);
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取相应巡查对象模型失败");
            }
        }

        /// <summary>
        /// 根据网格编号及巡查类型获取对应巡查对象
        /// </summary>
        /// <param name="GridId">网格编号</param>
        /// <param name="Type">巡查类型</param>
        /// <returns></returns>
        public IEnumerable<FWPatrolObject> GetFWPatrolObjectByGridIdAndType(Int32 GridId, Int32 Type)
        {
            try
            {
                string sqltext = @" SELECT  *
                                    FROM    FW_PATROL_OBJECT
                                    WHERE   GRID_ID = @GRID_ID AND PATROL_TYPE = @TYPE;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, GridId);
                    Database.AddInParameter(cmd, "@TYPE", DbType.Int32, Type);
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取相应巡查对象模型失败");
            }
        }

        public override FWPatrolObject Build(System.Data.IDataReader reader, FWPatrolObject instance)
        {
            try
            {
                instance.ID = reader.GetReaderValue<Int32>("ID");
                instance.DisplayId = reader.GetReaderValue<String>("DISPLAY_ID");
                instance.Name = reader.GetReaderValue<String>("NAME");
                instance.PatrolType = reader.GetReaderValue<Int32>("PATROL_TYPE");
                instance.Address = reader.GetReaderValue<String>("ADDRESS");
                instance.X = reader.GetReaderValue<Decimal>("X");
                instance.Y = reader.GetReaderValue<Decimal>("Y");
                instance.GridId = reader.GetReaderValue<Int32>("GRID_ID");
                instance.Road = reader.GetReaderValue<String>("ROAD");
                instance.Period = reader.GetReaderValue<String>("PERIOD");
                instance.Frequency = reader.GetReaderValue<Int32>("FREQUENCY");
                instance.PeriodId = reader.GetReaderValue<Int32>("PERIOD_ID");
                instance.Extend = reader.GetReaderValue<String>("EXTEND", default(String), true);
                instance.Creator = reader.GetReaderValue<String>("CREATOR");
                instance.CreateTime = reader.GetReaderValue<DateTime>("CREATE_TIME");
                instance.GisObjectId = reader.GetReaderValue<String>("GIS_OBJECTID", default(String), true);
                instance.GisLayerId = reader.GetReaderValue<String>("GIS_LAYERID", default(String), true);
                instance.MapLayerId = reader.GetReaderValue<String>("MAP_LAYERID", default(String), true);
                instance.Grade = reader.GetReaderValue<Int32>("GRADE");


                return base.Build(reader, instance);

            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "模型转换失败");
            }
        }
    }
}
