using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model.Dto
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public abstract class DtoBase<TEntity, TDto>
        where TEntity : class,new()
        where TDto : class,new()
    {
        public TEntity ToModel(TDto dto)
        {
            var entity = new TEntity();
            var entityProps = typeof(TEntity).GetProperties();
            var dtoProps = dto.GetType().GetProperties();
            foreach (var entityProp in entityProps)
            {
                foreach (var dtoProp in dtoProps)
                {
                    if (entityProp.Name == dtoProp.Name)
                    {
                        entityProp.SetValue(entity, Convert.ChangeType(dtoProp.GetValue(dto), entityProp.PropertyType));
                        break;
                    }
                }
            }
            return entity;
        }

        public static TDto FromModel(TEntity entity)
        {
            if (entity == null)
                return null;
            var dto = new TDto();
            var entityProps = entity.GetType().GetProperties();
            var dtoProps = typeof(TDto).GetProperties();
            foreach (var dtoProp in dtoProps)
            {
                foreach (var entityProp in entityProps)
                {
                    if (dtoProp.Name == entityProp.Name)
                    {
                        dtoProp.SetValue(dto, Convert.ChangeType(entityProp.GetValue(entity), dtoProp.PropertyType));
                        break;
                    }
                }
            }
            return dto;
        }
    }
}
