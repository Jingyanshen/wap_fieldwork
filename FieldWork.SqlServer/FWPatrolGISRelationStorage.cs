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
    public class FWPatrolGISRelationStorage : BaseAccess<FWPatrolGISRelation>, IFWPatrolGISRelationStorage
    {
        public FWPatrolGISRelationStorage() : base(SH3H.SDK.Share.Consts.CONFIGURE_DATABASE_CONNECTION_STRING) { }

        public FWPatrolGISRelation Insert(FWPatrolGISRelation entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(FWPatrolGISRelation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWPatrolGISRelation> Query()
        {
            try
            {
                var sql = "SELECT * FROM [dbo].[FW_PATROL_GIS_RELATION]";
                return MapEntities(sql);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取模型集合失败");
            }
        }

        public IEnumerable<FWPatrolGISRelation> GetFWPatrolGISRelationsByPatrolType(int PatrolType)
        {
            try
            {
                var sql = "SELECT * FROM [dbo].[FW_PATROL_GIS_RELATION] WHERE [PATROL_TYPE] = " + PatrolType;
                return MapEntities(sql);
            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
                throw new WapException(StateCode.CODE_SQL_EXECUTE_ERROR, "获取模型集合失败");
            }
        }


        private IEnumerable<FWPatrolGISRelation> MapEntities(string sql)
        {
            return SelectList(sql,
                   reader => new FWPatrolGISRelation
                   {
                       PatrolType = reader.GetReaderValue<int>("PATROL_TYPE"),
                       GISLayerId = reader.GetReaderValue<string>("GIS_LAYERID", default(string), true),
                       GISLayerName = reader.GetReaderValue<string>("GIS_LAYERNAME", default(string), true),
                       MapLayerId = reader.GetReaderValue<string>("MAP_LAYERID", default(string), true),
                       MapLayerName = reader.GetReaderValue<string>("MAP_LAYERNAME", default(string), true),
                       FieldMapSchema = reader.GetReaderValue<string>("FIELD_MAP_SCHEMA", default(string), true)
                   });
        }
    }
}
