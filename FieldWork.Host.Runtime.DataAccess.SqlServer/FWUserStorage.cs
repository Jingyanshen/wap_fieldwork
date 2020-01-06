using FieldWork.Host.Runtime.DataAccess.SqlServer.IStorage;
using SH3H.SDK.DataAccess.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.SharpFrame.Data;
using FieldWork.Host.Runtime.Helper;
using SH3H.SDK.Infrastructure.Logging;
using SH3H.SDK.Definition.Exceptions;
using System.Data;


namespace FieldWork.Host.Runtime.DataAccess.SqlServer
{
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
                throw new WapException(-1, "用户模型转换失败！");
            }
        }

        /// <summary>
        /// 获取指定角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserByRoleId(string roleId)
        {
            try
            {
                string sqltext = @" SELECT DISTINCT  ID ,
                                                    NAME ,
                                                    STATION_ID ,
                                                    STATION_NAME ,
                                                    ACTIVE ,
                                                    GRID_ID
                                            FROM    FW_USER feuser
                                                    INNER JOIN dbo.wapUserAndRole wapuserrole ON feuser.ID = wapuserrole.USER_ID
                                                                                                 AND wapuserrole.ROLE_ID IN (" + roleId + ");  ";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    return SelectList(cmd);
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(-1, "获取管理人员模型失败！");
            }
        }
    }
}
