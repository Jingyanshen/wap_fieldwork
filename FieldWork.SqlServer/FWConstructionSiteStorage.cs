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
    public class FWConstructionSiteStorage : BaseAccess<FWConstructionSite>, IFWConstructionSiteStorage
    {
        /// <summary>
        /// 构造
        /// </summary>
        public FWConstructionSiteStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override FWConstructionSite Build(IDataReader reader, FWConstructionSite instance)
        {
            try
            {
                instance.ID = reader.GetReaderValue<int>("ID");
                instance.Name = reader.GetReaderValue<string>("NAME");
                instance.Level = reader.GetReaderValue<int>("LEVEL");
                instance.Address = reader.GetReaderValue<string>("ADDRESS");
                instance.X = reader.GetReaderValue<decimal>("X");
                instance.Y = reader.GetReaderValue<decimal>("Y");
                instance.StartDate = reader.GetReaderValue<DateTime>("START_DATE");
                instance.EndDate = reader.GetReaderValue("END_DATE",default(DateTime),true);
                instance.ConstructorName = reader.GetReaderValue("CONSTRUCTOR_NAME", default(string), true);
                instance.ConstructorPic = reader.GetReaderValue("CONSTRUCTOR_PIC", default(string), true);
                instance.ConstructorPhone = reader.GetReaderValue("CONSTRUCTOR_PHONE", default(string), true);
                instance.BuilderName = reader.GetReaderValue("BUILDER_NAME", default(string), true);
                instance.BuilderPic = reader.GetReaderValue("BUILDER_PIC", default(string), true);
                instance.BuilderPhone = reader.GetReaderValue("BUILDER_PHONE", default(string), true);
                instance.SupervisorName = reader.GetReaderValue("SUPERVISOR_NAME", default(string), true);
                instance.SupervisorPic = reader.GetReaderValue("SUPERVISOR_PIC", default(string), true);
                instance.SupervisorPhone = reader.GetReaderValue("SUPERVISOR_PHONE", default(string), true);

                return base.Build(reader, instance);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_MODEL_CONVERT_ERROR, "网格模型转换失败！");
            }
        }

        /// <summary>
        /// 新增工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWConstructionSite CreateFWConstructionSite(FWConstructionSite entity)
        {
            try
            {
                string sqltext = @" INSERT INTO [dbo].[FW_CONSTRUCTION_SITE]
                                                   ([ID]
                                                   ,[NAME]
                                                   ,[LEVEL]
                                                   ,[ADDRESS]
                                                   ,[X]
                                                   ,[Y]
                                                   ,[START_DATE]
                                                   ,[END_DATE]
                                                   ,[CONSTRUCTOR_NAME]
                                                   ,[CONSTRUCTOR_PIC]
                                                   ,[CONSTRUCTOR_PHONE]
                                                   ,[BUILDER_NAME]
                                                   ,[BUILDER_PIC]
                                                   ,[BUILDER_PHONE]
                                                   ,[SUPERVISOR_NAME]
                                                   ,[SUPERVISOR_PIC]
                                                   ,[SUPERVISOR_PHONE])
                                             VALUES
                                                   (@ID
                                                   ,@NAME
                                                   ,@LEVEL
                                                   ,@ADDRESS
                                                   ,@X
                                                   ,@Y
                                                   ,@START_DATE
                                                   ,@END_DATE
                                                   ,@CONSTRUCTOR_NAME
                                                   ,@CONSTRUCTOR_PIC
                                                   ,@CONSTRUCTOR_PHONE
                                                   ,@BUILDER_NAME
                                                   ,@BUILDER_PIC
                                                   ,@BUILDER_PHONE
                                                   ,@SUPERVISOR_NAME
                                                   ,@SUPERVISOR_PIC
                                                   ,@SUPERVISOR_PHONE)";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, entity.ID);
                    Database.AddInParameter(cmd, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(cmd, "@LEVEL", DbType.Int32, entity.Level);
                    Database.AddInParameter(cmd, "@ADDRESS", DbType.String, entity.Address);
                    Database.AddInParameter(cmd, "@X", DbType.String, entity.X);
                    Database.AddInParameter(cmd, "@Y", DbType.String, entity.Y);
                    Database.AddInParameter(cmd, "@START_DATE", DbType.Date, entity.StartDate);
                    Database.AddInParameter(cmd, "@END_DATE", DbType.Date, entity.EndDate);
                    Database.AddInParameter(cmd, "@CONSTRUCTOR_NAME", DbType.String, entity.ConstructorName);
                    Database.AddInParameter(cmd, "@CONSTRUCTOR_PIC", DbType.String, entity.ConstructorPic);
                    Database.AddInParameter(cmd, "@CONSTRUCTOR_PHONE", DbType.String, entity.ConstructorPhone);
                    Database.AddInParameter(cmd, "@BUILDER_NAME", DbType.String, entity.BuilderName);
                    Database.AddInParameter(cmd, "@BUILDER_PIC", DbType.String, entity.BuilderPic);
                    Database.AddInParameter(cmd, "@BUILDER_PHONE", DbType.String, entity.BuilderPhone);
                    Database.AddInParameter(cmd, "@SUPERVISOR_NAME", DbType.String, entity.SupervisorName);
                    Database.AddInParameter(cmd, "@SUPERVISOR_PIC", DbType.String, entity.SupervisorPic);
                    Database.AddInParameter(cmd, "@SUPERVISOR_PHONE", DbType.String, entity.SupervisorPhone);
                    ExecuteNonQuery(cmd);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增工地对象失败");
            }
        }

        /// <summary>
        /// 根据编号更新工地
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWConstructionSite UpdateFWConstructionSite(int id, FWConstructionSite entity)
        {
            try
            {
                string sql = @" UPDATE [dbo].[FW_CONSTRUCTION_SITE]
                                       SET [ID] = @ID
                                          ,[NAME] = @NAME
                                          ,[LEVEL] = @LEVEL
                                          ,[ADDRESS] = @ADDRESS
                                          ,[X] = @X
                                          ,[Y] = @Y
                                          ,[START_DATE] = @START_DATE
                                          ,[END_DATE] = @END_DATE
                                          ,[CONSTRUCTOR_NAME] = @CONSTRUCTOR_NAME
                                          ,[CONSTRUCTOR_PIC] = @CONSTRUCTOR_PIC
                                          ,[CONSTRUCTOR_PHONE] = @CONSTRUCTOR_PHONE
                                          ,[BUILDER_NAME] = @BUILDER_NAME
                                          ,[BUILDER_PIC] = @BUILDER_PIC
                                          ,[BUILDER_PHONE] = @BUILDER_PHONE
                                          ,[SUPERVISOR_NAME] = @SUPERVISOR_NAME
                                          ,[SUPERVISOR_PIC] = @SUPERVISOR_PIC
                                          ,[SUPERVISOR_PHONE] = @SUPERVISOR_PHONE
                                        WHERE  ID = @ID;";
                using (var cmd = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(cmd, "@ID", DbType.Int32, entity.ID);
                    Database.AddInParameter(cmd, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(cmd, "@LEVEL", DbType.Int32, entity.Level);
                    Database.AddInParameter(cmd, "@ADDRESS", DbType.String, entity.Address);
                    Database.AddInParameter(cmd, "@X", DbType.String, entity.X);
                    Database.AddInParameter(cmd, "@Y", DbType.String, entity.Y);
                    Database.AddInParameter(cmd, "@START_DATE", DbType.Date, entity.StartDate);
                    Database.AddInParameter(cmd, "@END_DATE", DbType.Date, entity.EndDate);
                    Database.AddInParameter(cmd, "@CONSTRUCTOR_NAME", DbType.String, entity.ConstructorName);
                    Database.AddInParameter(cmd, "@CONSTRUCTOR_PIC", DbType.String, entity.ConstructorPic);
                    Database.AddInParameter(cmd, "@CONSTRUCTOR_PHONE", DbType.String, entity.ConstructorPhone);
                    Database.AddInParameter(cmd, "@BUILDER_NAME", DbType.String, entity.BuilderName);
                    Database.AddInParameter(cmd, "@BUILDER_PIC", DbType.String, entity.BuilderPic);
                    Database.AddInParameter(cmd, "@BUILDER_PHONE", DbType.String, entity.BuilderPhone);
                    Database.AddInParameter(cmd, "@SUPERVISOR_NAME", DbType.String, entity.SupervisorName);
                    Database.AddInParameter(cmd, "@SUPERVISOR_PIC", DbType.String, entity.SupervisorPic);
                    Database.AddInParameter(cmd, "@SUPERVISOR_PHONE", DbType.String, entity.SupervisorPhone);
                    return ExecuteNonQuery(cmd) > 0 ? entity : null;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "修改工地对象失败");
            }
        }

        /// <summary>
        /// 根据编号删除工地
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWConstructionSiteById(int id)
        {
            try
            {
                string sqltext = @" DELETE  FROM FW_CONSTRUCTION_SITE  WHERE   ID = @ID;";
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
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除工地对象失败");
            }
        }

        /// <summary>
        /// 根据编号获取网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWConstructionSite GetFWConstructionSiteById(int id)
        {
            try
            {
                string sqltext = @" SELECT  *
                                    FROM    FW_CONSTRUCTION_SITE
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
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取指定工地对象失败");
            }
        }

        /// <summary>
        /// 获取全部工地
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWConstructionSite> GetFWConstructionSites()
        {
            try
            {
                string sqltext = @" SELECT  *
                                    FROM    FW_CONSTRUCTION_SITE;";
                using (var cmd = Database.GetSqlStringCommand(sqltext))
                {
                    var result = SelectList(cmd);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取全部工地数据模型失败！");
            }
        }
    }
}
