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
    public class AuthStorage : BaseAccess<string>, IAuthStorage
    {
        /// <summary>
        /// 构造
        /// </summary>
        public AuthStorage()
            : base(SH3H.SDK.Share.Consts.AUTH_DATABASE_CONNECTION_STRING) { }


        /// <summary>
        /// 根据用户编号获取联系方式
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public string GetPhoneByuserId(int userId)
        {
            try
            {
                string result = null;
                string sqltext = @" SELECT USER_CELLPHONE FROM AUTH_USER WHERE USER_ID = @USER_ID";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@USER_ID", DbType.Int32, userId);
                    using (IDataReader reader = ExecuteReader(cmd))
                    {
                        while (reader.Read())
                            result = reader.GetReaderValue<string>("USER_CELLPHONE", default(string), true);
                        return result;
                    }

                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取联系方式失败");
            }
        }

        /// <summary>
        /// 获取所有组织
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWGridDto> GetOrganization()
        {
            try
            {
                List<FWGridDto> results = new List<FWGridDto>();
                string sqltext = @" SELECT * FROM AUTH_ORGANIZATION";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    using (IDataReader reader = ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            FWGridDto result = new FWGridDto()
                            {
                                StationId = reader.GetReaderValue<int>("ORGANIZATION_ID", default(int), true),
                                ParentId = reader.GetReaderValue<int>("PARENT_ORGANIZATION_ID", default(int), true),
                                Name = reader.GetReaderValue<string>("ORGANIZATION_NAME", default(string), true)
                            };
                            results.Add(result);
                        }
                            
                        return results;
                    }

                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取组织失败");
            }
        }
    }
}
