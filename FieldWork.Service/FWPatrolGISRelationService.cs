using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.SDK.Definition.Exceptions;
using SH3H.WAP.FieldWork.Share;
using SH3H.WAP.FieldWork.Model.Dto;

namespace SH3H.WAP.FieldWork.Service
{
    public class FWPatrolGISRelationService : BaseService, IFWPatrolGISRelationService
    {
        private IFWPatrolGISRelationRepository _fwPatrolGISRelationRepository;
        public FWPatrolGISRelationService(IFWPatrolGISRelationRepository fwPatrolGISRelationRepository)
        {
            _fwPatrolGISRelationRepository = fwPatrolGISRelationRepository;
        }
        public FWPatrolGISRelationDto Insert(FWPatrolGISRelationDto dto)
        {
            throw new NotImplementedException();
        }

        public bool Update(FWPatrolGISRelationDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWPatrolGISRelationDto> Query()
        {
            return _fwPatrolGISRelationRepository.Query().Select(x => FWPatrolGISRelationDto.FromModel(x));
        }

        public IEnumerable<FWPatrolGISRelationDto> GetFWPatrolGISRelationsByPatrolType(int PatrolType)
        {
            return _fwPatrolGISRelationRepository.GetFWPatrolGISRelationsByPatrolType(PatrolType).Select(x => FWPatrolGISRelationDto.FromModel(x));
        }
    }
}
