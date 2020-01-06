using SH3H.SDK.DataAccess.Db;
using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Infrastructure.Logging;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.SharpFrame.Data;
using System.Data;
using SH3H.WAP.FieldWork.Share.FieldWork;

namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class FWWapUserAndRoleStorage : BaseAccess<FWWapUserAndRoleDto>, IFWWapUserAndRoleStorage
    {
        /// <summary>
        /// 
        /// </summary>
        public FWWapUserAndRoleStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        public override FWWapUserAndRoleDto Build(System.Data.IDataReader reader, FWWapUserAndRoleDto instance)
        {
            try
            {
                instance.UserKey = reader.GetReaderValue<Guid>("USER_KEY").ToString();
                instance.UserId = reader.GetReaderValue<int>("USER_ID");
                instance.UserName = reader.GetReaderValue<string>("USER_NAME");
                instance.JobNumber = reader.GetReaderValue<string>("USER_WORKNO");
                instance.Account = reader.GetReaderValue<string>("USER_ACCOUNT");
                instance.DomainAccount = reader.GetReaderValue<string>("USER_DOMAIN_ACCOUNT");
                instance.PyCode = reader.GetReaderValue<string>("USER_PYCODE");
                instance.SortSn = reader.GetReaderValue<int>("USER_SORTSN");
                instance.Active = reader.GetReaderValue<bool>("USER_ACTIVE");
                instance.Comment = reader.GetReaderValue<string>("USER_COMMENT", default(string), true);
                instance.Phone = reader.GetReaderValue<string>("USER_PHONE", default(string), true);
                instance.Cellphone = reader.GetReaderValue<string>("USER_CELLPHONE", default(string), true);
                instance.Email = reader.GetReaderValue<string>("USER_EMAIL", default(string), true);
                instance.IdCard = reader.GetReaderValue<string>("USER_IDCARD", default(string), true);
                instance.Birthday = Utils.DateTimeToUTC(reader.GetReaderValue<DateTime>("USER_BIRTHDATE", default(DateTime), true));
                instance.Address = reader.GetReaderValue<string>("USER_ADDRESS", default(string), true);
                instance.PostNo = reader.GetReaderValue<string>("USER_POSTNUM", default(string), true);
                instance.IsFieldStaff = reader.GetReaderValue<bool>("USER_IS_FIELDSTAFF");
                instance.FileHash = reader.GetReaderValue<string>("FILE_HASH", default(string), true);
                instance.RoleName = reader.GetReaderValue<string>("ROLE_NAME", default(string), true);
                instance.RoleId = reader.GetReaderValue<int>("ROLE_ID", default(int), true);
                instance.Extend = reader.GetReaderValue<string>("EXTEND", default(string), true);
                instance.OrganizationId = reader.GetReaderValue<int>("ORGANIZATION_ID", default(int), true);
                instance.OrganizationCode = reader.GetReaderValue<string>("ORGANIZATION_CODE", default(string), true);
                instance.OrganizationName = reader.GetReaderValue<string>("ORGANIZATION_NAME", default(string), true);


                try
                {
                    instance.RoleKey = reader.GetReaderValue<Guid>("ROLE_KEY").ToString();
                }
                catch (Exception ex)
                {
                    instance.RoleKey = "";
                }
                try
                {
                    instance.ParentRoleKey = reader.GetReaderValue<Guid>("PARENT_ROLE_KEY").ToString();
                }
                catch (Exception ex)
                {
                    instance.ParentRoleKey = "";
                }
                try
                {
                    instance.OrganizationKey = reader.GetReaderValue<Guid>("ORGANIZATION_KEY").ToString();

                }
                catch (Exception ex)
                {
                    instance.OrganizationKey = "";
                }

                return base.Build(reader, instance);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "模型转换失败！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWWapUserAndRoleDto> GetFWWapUserAndRoleDtoAll(string rolestr = "")
        {
            try
            {
                string sqltext = @" SELECT  * FROM    wapUserAndRole  WHERE  1=1 ";
                if (!string.IsNullOrWhiteSpace(rolestr))
                {
                    sqltext += "  AND  ROLE_ID IN ( " + rolestr + "  ) ";
                }
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取人员组织角色关系模型失败！");
            }
        }


        /// <summary>
        /// 获取巡查人员
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWWapUserAndRoleDto> GetFWPatrolUserRoleByUserId(int id, int type, int roleId = 0)
        {
            try
            {
                string sqltext = @" DECLARE @STATION_ID INT;  ";

                if (type == (int)UserRoleTypeEnum.ByUserSearch)
                {
                    sqltext += @" SELECT  @STATION_ID = STATION_ID
                                    FROM    FW_USER
                                    WHERE   ID = @Param_Id; ";
                }
                if (type == (int)UserRoleTypeEnum.ByStationSearch)
                {
                    sqltext += @" SET  @STATION_ID = @Param_Id ; ";
                }

                sqltext += @"     CREATE TABLE #table_cache
                                        (
                                          ID INT ,
                                          NAME NVARCHAR(50) ,
                                          PARENT_ID INT ,
                                          STATION_ID INT ,
                                          STATION_NAME NVARCHAR(50)
                                        );

                                    IF EXISTS ( SELECT  *
                                                FROM    FW_GRID
                                                WHERE   STATION_ID = @STATION_ID )
                                        BEGIN
                                            INSERT  #table_cache
                                                    ( ID ,
                                                      NAME ,
                                                      PARENT_ID ,
                                                      STATION_ID ,
                                                      STATION_NAME 
	                                                )
                                                    SELECT  ID ,
                                                      NAME ,
                                                      PARENT_ID ,
                                                      STATION_ID ,
                                                      STATION_NAME 
                                                    FROM    dbo.fnQueryRecursionGridDown(@STATION_ID);
                                        END;
                                    ELSE
                                        BEGIN
                                            INSERT  #table_cache
                                                    ( ID ,
                                                      NAME ,
                                                      PARENT_ID ,
                                                      STATION_ID ,
                                                      STATION_NAME 
	                                                )
                                                    SELECT   ID ,
                                                      NAME ,
                                                      PARENT_ID ,
                                                      STATION_ID ,
                                                      STATION_NAME 
                                                    FROM    dbo.fnQueryRecursionGridUp(@STATION_ID);
                                        END;
                                    SELECT  table1.*
                                    FROM    dbo.wapUserAndRole table1
                                            INNER JOIN dbo.FW_USER table2 ON table1.USER_ID = table2.ID
                                    WHERE   table2.GRID_ID IN ( SELECT  ID
                                                                FROM    #table_cache )";
                if (roleId > 0)
                {
                    sqltext += @" AND table1.ROLE_ID = @ROLE_ID ";
                }
                sqltext += "  DROP TABLE #table_cache ";

                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@Param_Id", DbType.Int32, id);
                    Database.AddInParameter(cmd, "@ROLE_ID", DbType.Int32, roleId);
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "查询指定角色人员失败！");
            }
        }
    }
}
