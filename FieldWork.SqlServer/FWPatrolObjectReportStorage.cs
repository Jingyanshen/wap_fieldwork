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
using SH3H.WAP.FieldWork.Model.ViewModels;

namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    public class FWPatrolObjectReportStorage : BaseAccess<FWPatrolObjectReport>, IFWPatrolObjectReportStorage
    {
        public FWPatrolObjectReportStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }
        public FWPatrolObjectReport Insert(FWPatrolObjectReport entity)
        {
            try
            {
                var sql = @"INSERT INTO [dbo].[FW_PATROL_OBJECT_REPORT]
                                                ( OBJECT_ID,
                                                  ISSUE_ID,
                                                  TASK_ID,
                                                  RESULT
                                                )
                                        VALUES  ( 
                                                  @OBJECT_ID,
                                                  @ISSUE_ID,
                                                  @TASK_ID,
                                                  @RESULT
                                                );";
                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@OBJECT_ID", DbType.Int32, entity.ObjectId);
                    Database.AddInParameter(command, "@ISSUE_ID", DbType.String, entity.IssueId);
                    Database.AddInParameter(command, "@TASK_ID", DbType.String, entity.TaskId);
                    Database.AddInParameter(command, "@RESULT", DbType.Int32, entity.Result);
                    return ExecuteNonQuery(command) > 0 ? entity : null;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增模型失败！");
            }
        }

        public bool Update(FWPatrolObjectReport entity)
        {
            // TODO
            throw new NotImplementedException();
        }

        public IEnumerable<FWPatrolObjectReport> Query()
        {
            // TODO
            throw new NotImplementedException();
        }

        public IEnumerable<BatchReportDetailsViewModel> GetIssueObjectsByIssueId(string issueId)
        {
            try
            {
                var sql = @"SELECT 
                                t1.[OBJECT_ID], t1.RESULT, t2.X, t2.Y, t2.[ADDRESS], t2.[NAME]
                            FROM [dbo].[FW_PATROL_OBJECT_REPORT] t1
                            	LEFT JOIN [dbo].[FW_PATROL_OBJECT] t2 ON t1.[OBJECT_ID] = t2.ID
                            WHERE t1.ISSUE_ID = @ISSUE_ID";
                using (var cmd = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(cmd, "ISSUE_ID", DbType.String, issueId);
                    return SelectList<BatchReportDetailsViewModel>(cmd, reader => new BatchReportDetailsViewModel
                    {
                        ObjectId = reader.GetReaderValue<int>("OBJECT_ID").ToString(),
                        ObjectName = reader.GetReaderValue<string>("NAME"),
                        Address = reader.GetReaderValue<string>("ADDRESS", default(String), true),
                        X = reader.GetReaderValue<decimal>("X", default(decimal), true).ToString(),
                        Y = reader.GetReaderValue<decimal>("Y", default(decimal), true).ToString(),
                        Result = reader.GetReaderValue<int>("RESULT").ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取巡查上报列表失败！");
            }
        }
    }
}
