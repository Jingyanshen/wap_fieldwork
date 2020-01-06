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
    public class FWVehicleStorage : BaseAccess<FWVehicle>, IFWVehicleStorage
    {
        public FWVehicleStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }


        public override FWVehicle Build(IDataReader reader, FWVehicle instance)
        {
            try
            {
                instance.VehicleNo = reader.GetReaderValue<string>("VEHICLE_NO");
                instance.Type = reader.GetReaderValue<int>("TYPE");
                instance.StationId = reader.GetReaderValue<int>("STATION_ID");
                instance.StationName = reader.GetReaderValue<string>("STATION_NAME");
                instance.Driver = reader.GetReaderValue<string>("DRIVER", default(string), true);
                instance.DriverName = reader.GetReaderValue<string>("DRIVER_NAME", default(string), true);
                instance.Active = reader.GetReaderValue<bool>("ACTIVE");
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "模型转换失败！");
            }

            return base.Build(reader, instance);
        }

        public FWVehicle Insert(FWVehicle entity)
        {
            try
            {
                var sql = @"INSERT INTO [dbo].[FW_VEHICLE]
                                                ( VEHICLE_NO,
                                                  TYPE,
                                                  STATION_ID,
                                                  STATION_NAME,
                                                  DRIVER,
                                                  DRIVER_NAME,
                                                  ACTIVE
                                                )
                                        VALUES  ( @VEHICLE_NO,
                                                  @TYPE,
                                                  @STATION_ID,
                                                  @STATION_NAME,
                                                  @DRIVER,
                                                  @DRIVER_NAME,
                                                  @ACTIVE
                                                );";
                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@VEHICLE_NO", DbType.String, entity.VehicleNo);
                    Database.AddInParameter(command, "@TYPE", DbType.Int32, entity.Type);
                    Database.AddInParameter(command, "@STATION_ID", DbType.Int32, entity.StationId);
                    Database.AddInParameter(command, "@STATION_NAME", DbType.String, entity.StationName);
                    Database.AddInParameter(command, "@DRIVER", DbType.String, entity.Driver);
                    Database.AddInParameter(command, "@DRIVER_NAME", DbType.String, entity.DriverName);
                    Database.AddInParameter(command, "@ACTIVE", DbType.Boolean, entity.Active);
                    return ExecuteNonQuery(command) > 0 ? entity : null;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增模型失败！");
            }
        }

        public bool SetFlag(string vehicleNo, int flag)
        {
            try
            {
                var sql = @"UPDATE [dbo].[FW_VEHICLE] SET ACTIVE = @ACTIVE WHERE VEHICLE_NO = @VEHICLE_NO";
                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@ACTIVE", DbType.Int32, flag == 0 ? (int)DeletedStatus.Disable : (int)DeletedStatus.Enable);
                    Database.AddInParameter(command, "@VEHICLE_NO", DbType.String, vehicleNo);
                    return ExecuteNonQuery(command) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除模型失败！");
            }
        }

        public bool Update(string prevVehicleNo, FWVehicle entity)
        {
            try
            {
                if (!prevVehicleNo.Equals(entity.VehicleNo, StringComparison.InvariantCultureIgnoreCase))
                {
                    var validateSql = "SELECT * FROM [dbo].[FW_VEHICLE] WHERE VEHICLE_NO = '" + entity.VehicleNo + "'";

                    var target = SelectSingle(validateSql);

                    if (null != target)
                    {
                        return false;
                    }
                }

                var sql = @"UPDATE [dbo].[FW_VEHICLE] SET
                                   VEHICLE_NO = @VEHICLE_NO,
                                   [TYPE] = @TYPE,
                                   STATION_ID = @STATION_ID,
                                   STATION_NAME = @STATION_NAME,
                                   DRIVER = @DRIVER,
                                   DRIVER_NAME = @DRIVER_NAME
                                   WHERE VEHICLE_NO = @prevVehicleNo";
                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@VEHICLE_NO", DbType.String, entity.VehicleNo);
                    Database.AddInParameter(command, "@TYPE", DbType.Int32, entity.Type);
                    Database.AddInParameter(command, "@STATION_ID", DbType.Int32, entity.StationId);
                    Database.AddInParameter(command, "@STATION_NAME", DbType.String, entity.StationName);
                    Database.AddInParameter(command, "@DRIVER", DbType.String, entity.Driver);
                    Database.AddInParameter(command, "@DRIVER_NAME", DbType.String, entity.DriverName);
                    Database.AddInParameter(command, "@prevVehicleNo", DbType.String, prevVehicleNo);
                    return ExecuteNonQuery(command) > 0 ? true : false;
                }


            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "修改模型失败！");
            }
        }

        private IEnumerable<FWVehicle> MapEntities(string sql)
        {
            return SelectList(sql,
                   reader => new FWVehicle
                   {
                       VehicleNo = reader.GetReaderValue<string>("VEHICLE_NO"),
                       Type = reader.GetReaderValue<int>("TYPE"),
                       StationId = reader.GetReaderValue<int>("STATION_ID"),
                       StationName = reader.GetReaderValue<string>("STATION_NAME"),
                       Driver = reader.GetReaderValue<string>("DRIVER", default(string), true),
                       DriverName = reader.GetReaderValue<string>("DRIVER_NAME", default(string), true),
                       Active = reader.GetReaderValue<bool>("ACTIVE"),
                   });
        }

        public IEnumerable<FWVehicle> Query()
        {
            try
            {
                var sql = "SELECT * FROM [dbo].[FW_VEHICLE]";
                return MapEntities(sql);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取模型集合失败");
            }
        }


        /// <summary>
        /// 根据站点编码获取车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWVehicle> GetVehicleByStationId(int stationId)
        {
            try
            {
                string sqltext = @" SELECT  VEHICLE_NO ,
                                            TYPE ,
                                            STATION_ID ,
                                            STATION_NAME ,
                                            DRIVER ,
                                            DRIVER_NAME ,
                                            ACTIVE
                                    FROM    FW_VEHICLE
                                    WHERE   STATION_ID = @STATION_ID;";

                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@STATION_ID", DbType.Int32, stationId);
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "根据站点编码获取模型集合失败");
            }
        }

        /// <summary>
        /// 根据站点编号获取子集站点的车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWVehicle> GetVehicleByStationId(List<FWGridDto> stationIds)
        {
            try
            {
                string sqltext = @" SELECT  VEHICLE_NO ,
                                            TYPE ,
                                            STATION_ID ,
                                            STATION_NAME ,
                                            DRIVER ,
                                            DRIVER_NAME ,
                                            ACTIVE
                                    FROM    FW_VEHICLE
                                    WHERE   STATION_ID IN (";
                foreach (var stationId in stationIds)
                {
                    sqltext += stationId.StationId + ","; 
                }
                sqltext = sqltext.Substring(0, sqltext.Length - 1);
                sqltext += ")";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "根据站点编码获取模型集合失败");
            }
        }


        public IEnumerable<FWVehicle> QueryFWVehiclesByVehicleNo(string vehicleNo)
        {
            try
            {
                var sql = "SELECT * FROM [dbo].[FW_VEHICLE] WHERE VEHICLE_NO LIKE '%" + vehicleNo + "%'";
                return MapEntities(sql);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取根据车牌号码获取车辆信息集合失败");
            }
        }

        /// <summary>
        /// 获取指定站点下的司机
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWVehicle> GetFWVehicleDriversByStationId(int stationId = 0)
        {
            try
            {
                string sqltext = @" SELECT  VEHICLE_NO ,
                                            TYPE ,
                                            STATION_ID ,
                                            STATION_NAME ,
                                            DRIVER ,
                                            DRIVER_NAME ,
                                            ACTIVE
                                    FROM    FW_VEHICLE
                                    WHERE   VEHICLE_NO IN ( SELECT  MAX(VEHICLE_NO)
                                                            FROM    FW_VEHICLE
                                                            WHERE   1 = 1
                                                                    AND ACTIVE = 1  ";
                if (stationId > 0)
                {
                    sqltext += " AND STATION_ID=@STATION_ID ";
                }
                sqltext += "   GROUP BY DRIVER );";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    if (stationId > 0)
                    {
                        Database.AddInParameter(cmd, "@STATION_ID", DbType.Int32, stationId);
                    }
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取指定站点下的司机失败！");
            }
        }


        public bool Update(FWVehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}
