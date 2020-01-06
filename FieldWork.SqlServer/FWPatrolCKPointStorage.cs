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
    public class FWPatrolCKPointStorage : BaseAccess<FWPatrolCKPoint>, IFWPatrolCKPointStorage
    {
        public FWPatrolCKPointStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        public FWPatrolCKPoint Insert(FWPatrolCKPoint entity)
        {
            try
            {
                var sql = @"INSERT INTO [dbo].[FW_PATROL_CKPOINT]
                                                    ( [NAME],
                                                      [TYPE],
                                                      [ADDRESS],
                                                      X,
                                                      Y,
                                                      TOLERENCE,
                                                      GRID_ID,
                                                      ROAD,
                                                      [PERIOD],
                                                      FREQUENCY,
                                                      PERIOD_ID,
                                                      EXTEND,
                                                      CREATOR,
                                                      CREATE_TIME,
                                                      GRADE
                                                    )
                                            VALUES  ( @NAME,
                                                      @TYPE,
                                                      @ADDRESS,
                                                      @X,
                                                      @Y,
                                                      @TOLERENCE,
                                                      @GRID_ID,
                                                      @ROAD,
                                                      @PERIOD,
                                                      @FREQUENCY,
                                                      @PERIOD_ID,
                                                      @EXTEND,
                                                      @CREATOR,
                                                      @CREATE_TIME,
                                                      @GRADE
                                                    );";
                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(command, "@TYPE", DbType.Int32, entity.Type);
                    Database.AddInParameter(command, "@ADDRESS", DbType.String, entity.Address);
                    Database.AddInParameter(command, "@X", DbType.Decimal, entity.X);
                    Database.AddInParameter(command, "@Y", DbType.Decimal, entity.Y);
                    Database.AddInParameter(command, "@TOLERENCE", DbType.Int32, entity.Tolerence);
                    Database.AddInParameter(command, "@GRID_ID", DbType.Int32, entity.GridId);
                    Database.AddInParameter(command, "@ROAD", DbType.String, entity.Road);
                    Database.AddInParameter(command, "@PERIOD", DbType.String, entity.Period);
                    Database.AddInParameter(command, "@FREQUENCY", DbType.Int32, entity.Frequency);
                    Database.AddInParameter(command, "@PERIOD_ID", DbType.Int32, entity.PeriodId);
                    Database.AddInParameter(command, "@EXTEND", DbType.String, entity.Extend);
                    Database.AddInParameter(command, "@CREATOR", DbType.String, entity.Creator);
                    Database.AddInParameter(command, "@CREATE_TIME", DbType.DateTime, entity.CreateTime);
                    Database.AddInParameter(command, "@GRADE", DbType.Int32, entity.Grade);
                    return ExecuteNonQuery(command) > 0 ? entity : null;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增模型失败！");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var sql = @"DELETE FROM [dbo].[FW_PATROL_CKPOINT] WHERE ID = @ID";
                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@ID", DbType.Int32, id);
                    return ExecuteNonQuery(command) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "删除模型失败！");
            }
        }

        public bool Update(FWPatrolCKPoint entity)
        {
            try
            {
                var sql = @"UPDATE [dbo].[FW_PATROL_CKPOINT] SET [NAME] = @NAME, [TYPE] = @TYPE, [ADDRESS] = @ADDRESS, X = @X, Y = @Y, TOLERENCE = @TOLERENCE, GRID_ID = @GRID_ID, ROAD = @ROAD, [PERIOD] = @PERIOD, FREQUENCY = @FREQUENCY, PERIOD_ID = @PERIOD_ID, EXTEND = @EXTEND, GRADE = @GRADE WHERE ID = @ID";
                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@ID", DbType.Int32, entity.Id);
                    Database.AddInParameter(command, "@NAME", DbType.String, entity.Name);
                    Database.AddInParameter(command, "@TYPE", DbType.Int32, entity.Type);
                    Database.AddInParameter(command, "@ADDRESS", DbType.String, entity.Address);
                    Database.AddInParameter(command, "@X", DbType.Decimal, entity.X);
                    Database.AddInParameter(command, "@Y", DbType.Decimal, entity.Y);
                    Database.AddInParameter(command, "@TOLERENCE", DbType.Int32, entity.Tolerence);
                    Database.AddInParameter(command, "@GRID_ID", DbType.Int32, entity.GridId);
                    Database.AddInParameter(command, "@ROAD", DbType.String, entity.Road);
                    Database.AddInParameter(command, "@PERIOD", DbType.String, entity.Period);
                    Database.AddInParameter(command, "@FREQUENCY", DbType.Int32, entity.Frequency);
                    Database.AddInParameter(command, "@PERIOD_ID", DbType.Int32, entity.PeriodId);
                    Database.AddInParameter(command, "@EXTEND", DbType.String, entity.Extend);
                    Database.AddInParameter(command, "@GRADE", DbType.Int32, entity.Grade);
                    return ExecuteNonQuery(command) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "更新模型失败！");
            }
        }

        public IEnumerable<FWPatrolCKPoint> Query(int gridId, string name)
        {
            try
            {
                var sql = "SELECT * FROM [dbo].[FW_PATROL_CKPOINT] WHERE 1 = 1 ";
                if (!string.IsNullOrEmpty(name))
                {
                    sql += "AND [NAME] LIKE '%" + name + "%' ";
                }
                if (gridId != -1)
                {
                    sql += "AND GRID_ID = " + gridId + " ";
                }
                return MapEntities(sql);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取模型集合失败");
            }
        }

        /// <summary>
        /// 根据网格ID查询必达点
        /// </summary>
        /// <param name="GridId">网格ID</param>
        /// <returns></returns>
        public IEnumerable<FWPatrolCKPoint> GetPointByGridId(int GridId)
        {
            try
            {
                var sql = "SELECT * FROM FW_PATROL_CKPOINT WHERE GRID_ID =" + GridId;
                var result = MapEntities(sql);
                return result;

            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取模型集合失败");
            }
        }

        private IEnumerable<FWPatrolCKPoint> MapEntities(string sql)
        {
            return SelectList(sql,
                   reader => new FWPatrolCKPoint
                   {
                       Id = reader.GetReaderValue<int>("ID"),
                       Name = reader.GetReaderValue<string>("NAME", default(string), true),
                       Address = reader.GetReaderValue<string>("ADDRESS", default(string), true),
                       Type = reader.GetReaderValue<int>("TYPE"),
                       X = reader.GetReaderValue<decimal>("X", default(decimal), true),
                       Y = reader.GetReaderValue<decimal>("Y", default(decimal), true),
                       Tolerence = reader.GetReaderValue<int>("TOLERENCE"),
                       Road = reader.GetReaderValue<string>("ROAD", default(string), true),
                       GridId = reader.GetReaderValue<int>("GRID_ID"),
                       Frequency = reader.GetReaderValue<int>("FREQUENCY"),
                       Period = reader.GetReaderValue<string>("PERIOD", default(string), true),
                       PeriodId = reader.GetReaderValue<int>("PERIOD_ID"),
                       Extend = reader.GetReaderValue<string>("EXTEND", default(string), true),
                       Creator = reader.GetReaderValue<string>("CREATOR", default(string), true),
                       CreateTime = reader.GetReaderValue<DateTime>("CREATE_TIME"),
                       Grade = reader.GetReaderValue<int>("GRADE"),
                   });
        }
    }
}
