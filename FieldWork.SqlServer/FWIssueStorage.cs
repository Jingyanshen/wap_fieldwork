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
using SH3H.WAP.FieldWork.Model.Dto;

namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    public class FWIssueStorage : BaseAccess<FWIssue>, IFWIssueStorage
    {
        public FWIssueStorage()
            : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }
        public FWIssue Insert(FWIssue entity)
        {
            try
            {
                var sql = @"INSERT INTO [dbo].[WS_ISSUE]
                                                ( ID,
                                                  ISSUE_TYPE_ID,
                                                  IS_BATCH,
                                                  ADDRESS,
                                                  TIME,
                                                  REPORTPERSON,
                                                  LOCATION,
                                                  STATUS,
                                                  COMMENT,
                                                  ATTACHMENT,
                                                  EXTEND,
                                                  AUDITOR,
                                                  AUDIT_TIME,
                                                  AUDIT_COMMENT,
                                                  FORM_ID,
                                                  WS_ID,
                                                  URGENCY_LEVEL,
                                                  INSERT_TIME,
                                                  UPDATE_TIME
                                                )
                                        VALUES  ( 
                                                  @ID,
                                                  @ISSUE_TYPE_ID,
                                                  1,
                                                  NULL,
                                                  @TIME,
                                                  @REPORTPERSON,
                                                  NULL,
                                                  -2,
                                                  NULL,
                                                  NULL,
                                                  NULL,
                                                  NULL,
                                                  NULL,
                                                  NULL,
                                                  NULL,
                                                  @WS_ID,
                                                  1,
                                                  GETDATE(),
                                                  NULL
                                                );";
                using (var command = Database.GetSqlStringCommand(sql))
                {
                    Database.AddInParameter(command, "@ID", DbType.String, entity.Id);
                    Database.AddInParameter(command, "@ISSUE_TYPE_ID", DbType.Int32, entity.IssueTypeId);
                    Database.AddInParameter(command, "@TIME", DbType.DateTime, entity.Time);
                    Database.AddInParameter(command, "@REPORTPERSON", DbType.String, entity.ReportPerson);
                    Database.AddInParameter(command, "@WS_ID", DbType.String, entity.WSId);
                    return ExecuteNonQuery(command) > 0 ? entity : null;
                }
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "新增模型失败！");
            }
        }

        public bool Update(FWIssue entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWIssue> Query()
        {
            try
            {
                var sql = "SELECT * FROM [dbo].[WS_ISSUE]";
                return MapEntities(sql);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取模型集合失败");
            }
        }


        private IEnumerable<FWIssue> MapEntities(string sql)
        {
            return SelectList(sql,
                   reader => new FWIssue
                   {
                       Id = reader.GetReaderValue<string>("ID"),
                       IssueTypeId = reader.GetReaderValue<int>("ID"),
                       IsBatch = reader.GetReaderValue<int>("IS_BATCH"),
                       Address = reader.GetReaderValue<string>("ADDRESS", default(string), true),
                       Time = reader.GetReaderValue<DateTime>("TIME", default(DateTime), true),
                       ReportPerson = reader.GetReaderValue<string>("REPORTPERSON"),
                       Location = reader.GetReaderValue<string>("LOCATION", default(string), true),
                       Status = reader.GetReaderValue<int>("STATUS"),
                       Comment = reader.GetReaderValue<string>("COMMENT", default(string), true),
                       Attachment = reader.GetReaderValue<string>("ATTACHMENT", default(string), true),
                       Extend = reader.GetReaderValue<string>("EXTEND", default(string), true),
                       Auditor = reader.GetReaderValue<string>("AUDITOR", default(string), true),
                       AuditTime = reader.GetReaderValue<DateTime>("AUDIT_TIME", default(DateTime), true),
                       AuditComment = reader.GetReaderValue<string>("AUDIT_COMMENT", default(string), true),
                       FormId = reader.GetReaderValue<int>("FORM_ID", default(int), true),
                       WSId = reader.GetReaderValue<string>("WS_ID", default(string), true),
                       UrgencyLevel = reader.GetReaderValue<string>("URGENCY_LEVEL", default(string), true),
                       InsertTime = reader.GetReaderValue<DateTime>("INSERT_TIME"),
                       UpdateTime = reader.GetReaderValue<DateTime>("UPDATE_TIME", default(DateTime), true),
                   });
        }

        public IEnumerable<FWPatrolIssueRelation> GetPatrolIssueRelation()
        {
            try
            {
                var sql = "SELECT * FROM [dbo].[FW_PATROL_ISSUE_RELATION]";
                return SelectList(sql, reader => new FWPatrolIssueRelation
                {
                    PatrolType = reader.GetReaderValue<int>("PATROL_TYPE"),
                    IssueTypeId = reader.GetReaderValue<int>("ISSUE_TYPE_ID")
                });
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取模型集合失败");
            }
        }
    }
}
