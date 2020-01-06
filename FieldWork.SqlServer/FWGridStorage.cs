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
using Newtonsoft.Json;


namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    /// <summary>
    /// 定义网格数据访问对象
    /// </summary>
    public class FWGridStorage : BaseAccess<FWGrid>, IFWGridStorage
    {
        /// <summary>
        /// 构造
        /// </summary>
        public FWGridStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override FWGrid Build(IDataReader reader, FWGrid instance)
        {
            try
            {
                instance.ID = reader.GetReaderValue<int>("ID");
                instance.Name = reader.GetReaderValue<string>("NAME");
                instance.ParentId = reader.GetReaderValue<int>("PARENT_ID");
                instance.StationId = reader.GetReaderValue<int>("STATION_ID");
                instance.StationName = reader.GetReaderValue<string>("STATION_NAME");
                instance.Hierarchy = reader.GetReaderValue<int>("HIERARCHY");
                instance.GisObjectId = reader.GetReaderValue<string>("GIS_OBJECTID");
                instance.GisLayerId = reader.GetReaderValue<string>("GIS_LAYERID");
                instance.MapLayerId = reader.GetReaderValue<string>("MAP_LAYERID");
                instance.Geometry = reader.GetReaderValue<string>("GEOMETRY");
                instance.Extend = reader.GetReaderValue<string>("EXTEND");

                return base.Build(reader, instance);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "网格模型转换失败！");
            }
        }

        /// <summary>
        /// 新增网格
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWGrid CreateFWGrid(FWGrid entity)
        {
            try
            {
                string sqltext = @" INSERT  INTO  FW_GRID
                                                        ( ID
                                                            NAME ,
                                                            PARENT_ID ,
                                                            STATION_ID ,
                                                            STATION_NAME ,
                                                            HIERARCHY ,
                                                            GIS_OBJECTID ,
                                                            GIS_LAYERID ,
                                                            MAP_LAYERID,
                                                            GEOMETRY,
                                                            EXTEND
                                                        )
                                                VALUES  ( @ID
                                                            @NAME ,
                                                            @PARENT_ID ,
                                                            @STATION_ID ,
                                                            @STATION_NAME ,
                                                            @HIERARCHY ，
                                                            @GIS_OBJECTID ,
                                                            @GIS_LAYERID ,
                                                            @MAP_LAYERID ,
                                                            @GEOMETRY ,
                                                            @EXTEND
                                                         );";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, entity.ID);
                    Database.AddInParameter(cmd, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(cmd, "@PARENT_ID", DbType.Int32, entity.ParentId);
                    Database.AddInParameter(cmd, "@STATION_ID", DbType.Int32, entity.StationId);
                    Database.AddInParameter(cmd, "@STATION_NAME", DbType.String, entity.StationName);
                    Database.AddInParameter(cmd, "@HIERARCHY", DbType.String, entity.Hierarchy);
                    Database.AddInParameter(cmd, "@GIS_OBJECTID", DbType.String, entity.GisObjectId);
                    Database.AddInParameter(cmd, "@GIS_LAYERID", DbType.Int32, entity.GisLayerId);
                    Database.AddInParameter(cmd, "@MAP_LAYERID", DbType.Int32, entity.MapLayerId);
                    Database.AddInParameter(cmd, "@GEOMETRY", DbType.String, entity.Geometry);
                    Database.AddInParameter(cmd, "@EXTEND", DbType.String, entity.Extend);
                    ExecuteNonQuery(cmd);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增网格对象失败");
            }
        }

        /// <summary>
        /// 根据编号更新网格
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWGrid UpdateFWGridById(int id, FWGrid entity)
        {
            try
            {
                string sql = @" UPDATE FW_GRID
                             SET    NAME = @NAME ,
                                    PARENT_ID = @PARENT_ID ,
                                    STATION_ID = @STATION_ID ,
                                    STATION_NAME = @STATION_NAME ,
                                    HIERARCHY = @HIERARCHY ,
                                    GIS_OBJECTID = @GIS_OBJECTID ,
                                    GIS_LAYERID = @GIS_LAYERID ,
                                    MAP_LAYERID = @MAP_LAYERID ,
                                    GEOMETRY = @GEOMETRY ,
                                    EXTEND = @EXTEND
                             WHERE  ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(cmd, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(cmd, "@PARENT_ID", DbType.Int32, entity.ParentId);
                    Database.AddInParameter(cmd, "@STATION_ID", DbType.Int32, entity.StationId);
                    Database.AddInParameter(cmd, "@STATION_NAME", DbType.String, entity.StationName);
                    Database.AddInParameter(cmd, "@HIERARCHY", DbType.String, entity.Hierarchy);
                    Database.AddInParameter(cmd, "@GIS_OBJECTID", DbType.String, entity.GisObjectId);
                    Database.AddInParameter(cmd, "@GIS_LAYERID", DbType.Int32, entity.GisLayerId);
                    Database.AddInParameter(cmd, "@MAP_LAYERID", DbType.Int32, entity.MapLayerId);
                    Database.AddInParameter(cmd, "@GEOMETRY", DbType.String, entity.Geometry);
                    Database.AddInParameter(cmd, "@EXTEND", DbType.String, entity.Extend);
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, entity.ID);
                    return ExecuteNonQuery(cmd) > 0 ? entity : null;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "修改网格对象失败");
            }
        }

        /// <summary>
        /// 根据编号删除网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWGridById(int id)
        {
            try
            {
                string sqltext = @" DELETE  FROM FW_GRID  WHERE   ID = @ID;";
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
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除网格对象失败");
            }
        }

        /// <summary>
        /// 根据编号获取网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWGrid GetFWGridById(int id)
        {
            try
            {
                string sqltext = @" SELECT  *
                                    FROM    FW_GRID
                                    WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, id);

                    var result = SelectSingle(cmd);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取指定网格对象失败");
            }
        }

        /// <summary>
        /// 获取全部网格
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWGrid> GetFWGridAll()
        {
            try
            {
                string sqltext = @" SELECT  *
                                    FROM    FW_GRID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    var result = SelectList(cmd);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取全部网格数据模型失败！");
            }
        }

        /// <summary>
        /// 获取人员所在组织以及子组织网格
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWGrid> GetFWGridByUserId(int userid)
        {
            try
            {
                string sqltext = @" DECLARE @STATION_ID INT; 
                                    SELECT  @STATION_ID = STATION_ID
                                    FROM    FW_USER
                                    WHERE   ID = @USER_ID;

                                    IF EXISTS ( SELECT  ID ,
                                                      NAME ,
                                                      PARENT_ID ,
                                                      STATION_ID ,
                                                      STATION_NAME 
                                                FROM    FW_GRID
                                                WHERE   STATION_ID = @STATION_ID )
                                        BEGIN
                                            SELECT  ID ,
                                                      NAME ,
                                                      PARENT_ID ,
                                                      STATION_ID ,
                                                      STATION_NAME 
                                            FROM    dbo.fnQueryRecursionGridDown(@STATION_ID);
                                        END;
                                    ELSE
                                        BEGIN
                                            SELECT  ID ,
                                                      NAME ,
                                                      PARENT_ID ,
                                                      STATION_ID ,
                                                      STATION_NAME 
                                            FROM    dbo.fnQueryRecursionGridUp(@STATION_ID);
                                        END;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@USER_ID", DbType.Int32, userid);
                    return SelectList(cmd, reader =>
                    {
                        return new FWGrid()
                        {
                            ID = reader.GetReaderValue<int>("ID"),
                            Name = reader.GetReaderValue<string>("NAME"),
                            ParentId = reader.GetReaderValue<int>("PARENT_ID"),
                            StationId = reader.GetReaderValue<int>("STATION_ID"),
                            StationName = reader.GetReaderValue<string>("STATION_NAME"),
                        };
                    });
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取人员可查看网格模型失败！");
            }

        }

        /// <summary>
        /// 获取网格geoJson
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetGeoJsonById(int id)
        {
            try
            {
                string sqltext = @" SELECT  *
                                    FROM    FW_GRID
                                    WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, id);
                    FWGrid fWGrid = SelectSingle(cmd);
                    return fWGrid.Geometry;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取全部网格数据模型失败！");
            }
        }
        
        public bool updateGeo(string text, int id)
        {
            try
            {
                string sqltext = @" update FW_GRID
                                    set GEO = geometry::STGeomFromText('"+ text + "',4326) WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, id);
                    return ExecuteNonQuery(cmd) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "更新网格数据模型失败！");
            }
        }

        /// <summary>
        /// geometry转GeoJson
        /// </summary>
        /// <returns></returns>
        public string GetGeoJsonFromWkt(string geometry, string Name)
        {
            string wkt = geometry;
            string result = null;
            string coordinates = null;
            int index = wkt.IndexOf("(");
            string type = wkt.Substring(0, index);

            coordinates = GetMultiPointText(wkt);

            Geometry Geometry1 = new Geometry
            {
                Type = type,
                Coordinates = coordinates
            };
            Properties Properties1 = new Properties
            {
                Name = Name
            };
            GeoJson geoJson = new GeoJson
            {
                Type = "Feature",
                Geometry = Geometry1,
                Properties = Properties1
            };
            try
            {
                result = JsonConvert.SerializeObject(geoJson);
            }
            catch (Exception ex)
            {
                return null;
            }
            return result;
        }

        /// <summary>
        /// 根据wkt获得coordinates
        /// </summary>
        /// <returns></returns>
        public string GetMultiPointText(string wkt)
        {
            var startIndex = wkt.IndexOf('(');
            var endIndex = wkt.LastIndexOf(')');
            var coordinates = wkt.Substring(startIndex, endIndex - startIndex + 1);
            var coods = coordinates.Replace('(', '[').Replace(')', ']').Split(',');
            var result = "";
            foreach (var cood in coods)
            {
                var s = cood.TrimStart().Replace(' ', ',');
                result += string.Format("[" + s + "],");
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        public class GeoJson
        {
            /// <summary>
            /// 类型
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// 几何属性
            /// </summary>
            public Geometry Geometry { get; set; }
            /// <summary>
            /// 属性
            /// </summary>
            public Properties Properties { get; set; }
        }

        public class Geometry
        {
            /// <summary>
            /// 类型
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// 属性
            /// </summary>
            public string Coordinates { get; set; }
        }

        public class Properties
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }
        }
    }
}
