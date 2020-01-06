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
    /// 全要素设备数据访问对象
    /// </summary>
    public class FWQYSFacilityStorage : BaseAccess<FWQYSFacility>, IFWQYSFacilityStorage
    {
        /// <summary>
        /// 构造
        /// </summary>
        public FWQYSFacilityStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override FWQYSFacility Build(IDataReader reader, FWQYSFacility instance)
        {
            try
            {
                instance.FacilityId = reader.GetReaderValue<string>("FACILITY_ID");
                instance.FacilityName = reader.GetReaderValue<string>("FACILITY_NAME");
                instance.UserName = reader.GetReaderValue<string>("USER_NAME", default(String), true);
                instance.Type = reader.GetReaderValue<int>("TYPE",default(int), true);

                return base.Build(reader, instance);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "网格模型转换失败！");
            }
        }

        /// <summary>
        /// 根据编号获取全要素设备
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<FWQYSFacility> GetFWQYSFacilityById(int userId)
        {
            try
            {
                string sqltext = @" SELECT  *
                                    FROM    FW_FACILITY_QYS
                                    WHERE   USER_ID = @USER_ID;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@USER_ID", DbType.Int32, userId);

                    var result = SelectList(cmd);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取全要素设备对象失败");
            }
        }

        /// <summary>
        /// 获取所有全要素设备
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<FWQYSFacility> GetFWQYSFacility()
        {
            try
            {
                string sqltext = @" SELECT  DISTINCT(FACILITY_ID),FACILITY_NAME
                                    FROM    FW_FACILITY_QYS ;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    var result = SelectList(cmd);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取全要素设备对象失败");
            }
        }
    }
}
