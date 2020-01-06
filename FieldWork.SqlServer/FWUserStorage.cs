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
    public class FWUserStorage : BaseAccess<FWUser>, IFWUserStorage
    {
        /// <summary>
        /// 
        /// </summary>
        public FWUserStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// 模型转换
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override FWUser Build(System.Data.IDataReader reader, FWUser instance)
        {
            try
            {
                instance.Id = reader.GetReaderValue<int>("ID");
                instance.Name = reader.GetReaderValue<string>("NAME");
                instance.StationId = reader.GetReaderValue<int>("STATION_ID");
                instance.StationName = reader.GetReaderValue<string>("STATION_NAME");
                instance.Active = reader.GetReaderValue<bool>("ACTIVE");
                instance.GridId = reader.GetReaderValue<int>("GRID_ID");

                return base.Build(reader, instance);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "用户模型转换失败！");
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWUser CreateFWUser(FWUser entity)
        {
            try
            {
                string sqltext = @" DECLARE @newID INT;
                                    SELECT  @newID = CASE ISNULL(MAX(ID), 0)
                                                       WHEN 0 THEN 1
                                                       ELSE ( MAX(ID) + 1 )
                                                     END
                                    FROM    FW_USER;
                                    INSERT  INTO FW_USER
                                            ( ID ,
                                              NAME ,
                                              STATION_ID ,
                                              STATION_NAME ,
                                              ACTIVE ,
                                              GRID_ID
                                            )
                                    VALUES  ( @newID ,
                                              @NAME ,
                                              @STATION_ID ,
                                              @STATION_NAME ,
                                              @ACTIVE ,
                                              @GRID_ID
                                            );
                                    SELECT  @newID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(cmd, "@STATION_ID", DbType.Int32, entity.StationId);
                    Database.AddInParameter(cmd, "@STATION_NAME", DbType.String, entity.StationName);
                    Database.AddInParameter(cmd, "@ACTIVE", DbType.Boolean, entity.Active);
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, entity.GridId);
                    var result = ExecuteScalar<int>(cmd);
                    entity.Id = result;
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增用户模型失败！");
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWUser UpdateFWUser(int id, FWUser entity)
        {
            try
            {
                string sqltext = @" UPDATE  FW_USER
                                            SET     NAME = @NAME ,
                                                    STATION_ID = @STATION_ID ,
                                                    STATION_NAME = @STATION_NAME ,
                                                    ACTIVE = @ACTIVE ,
                                                    GRID_ID = @ACTIVE
                                            WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(cmd, "@STATION_ID", DbType.Int32, entity.StationId);
                    Database.AddInParameter(cmd, "@STATION_NAME", DbType.String, entity.StationName);
                    Database.AddInParameter(cmd, "@ACTIVE", DbType.Boolean, entity.Active);
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, entity.GridId);
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, entity.Id);
                    ExecuteNonQuery(cmd);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "修改用户模型失败！");
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWUser(int id)
        {
            try
            {
                string sqltext = @" DELETE  FROM  FW_USER  WHERE   ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, id);
                    return ExecuteNonQuery(cmd) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除用户模型失败！");
            }
        }

        /// <summary>
        /// 查询指定用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWUser GetFWUserById(int id)
        {
            try
            {
                string sqltext = @" SELECT  ID ,
                                            NAME ,
                                            STATION_ID ,
                                            STATION_NAME ,
                                            ACTIVE ,
                                            GRID_ID
                                    FROM    FW_USER
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
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询指定用户失败！");
            }
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserAll()
        {
            try
            {
                string sqltext = @" SELECT  ID ,
                                            NAME ,
                                            STATION_ID ,
                                            STATION_NAME ,
                                            ACTIVE ,
                                            GRID_ID
                                    FROM    FW_USER;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询全部用户模型失败！");
            }
        }

        /// <summary>
        /// 根据网格编号获取用户
        /// </summary>
        /// <param name="gridId"></param>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserByGridId(int gridId)
        {
            try
            {
                string sqltext = @" SELECT  ID ,
                                    NAME ,
                                    STATION_ID ,
                                    STATION_NAME ,
                                    ACTIVE ,
                                    GRID_ID
                            FROM    FW_USER
                            WHERE   GRID_ID = @GRID_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, gridId);
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "根据网格编号查询用户模型失败！");
            }
        }

        /// <summary>
        /// 根据组织编号获取用户
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserByStationId(int stationId)
        {
            try
            {
                string sqltext = @" SELECT  ID ,
                                    NAME ,
                                    STATION_ID ,
                                    STATION_NAME ,
                                    ACTIVE ,
                                    GRID_ID
                            FROM    FW_USER
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
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "根据组织编号获取用户模型失败！");
            }
        }

        /// <summary>
        /// 获取指定网格下指定角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserByRoleAndGridId(int roleId, int gridId)
        {
            try
            {
                string sqltext = @" SELECT  ID ,
                                            NAME ,
                                            STATION_ID ,
                                            STATION_NAME ,
                                            ACTIVE ,
                                            GRID_ID
                                    FROM    FW_USER tab1
                                            LEFT JOIN dbo.wapUserAndRole tab2 ON tab1.ID = tab2.USER_ID
                                    WHERE   tab2.ROLE_ID = @ROLE_ID
                                            AND tab1.GRID_ID = @GRID_ID;";

                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ROLE_ID", DbType.Int32, roleId);
                    Database.AddInParameter(cmd, "@GRID_ID", DbType.Int32, gridId);
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取指定站点下指定角色人员失败！");
            }
        }

        /// <summary>
        /// 获取指定网格下递归角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserByRoleAndOrgId(int roleId, int stationId)
        {
            try
            {
                string sqltext = @" SELECT  ID ,
                                            NAME ,
                                            STATION_ID ,
                                            STATION_NAME ,
                                            ACTIVE ,
                                            GRID_ID
                                    FROM    FW_USER tab1
                                            LEFT JOIN dbo.wapUserAndRole tab2 ON tab1.ID = tab2.USER_ID
                                    WHERE   tab2.ROLE_ID = @ROLE_ID
                                            AND tab1.STATION_ID IN ( SELECT    ID
                                                                  FROM      dbo.fnQueryRecursionGridDown(@STATION_ID) );";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ROLE_ID", DbType.Int32, roleId);
                    Database.AddInParameter(cmd, "@STATION_ID", DbType.Int32, stationId);
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取指定站点下指定角色人员失败！");
            }
        }
    }
}
