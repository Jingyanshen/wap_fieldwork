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
    public class FWConstructionSiteServiceImpl : BaseService, IFWConstructionSiteService
    {
        private IFWConstructionSiteRepository _iFWConstructionSiteRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridRepository"></param>
        public FWConstructionSiteServiceImpl(IFWConstructionSiteRepository iFWConstructionSiteRepository)
        {
            _iFWConstructionSiteRepository = iFWConstructionSiteRepository;
        }

        /// <summary>
        /// 新增工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWConstructionSiteDto CreateFWConstructionSite(FWConstructionSiteDto entity)
        {
            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();

            return FWConstructionSiteDto.FromModel(_iFWConstructionSiteRepository.CreateFWConstructionSite(entity.ToModel()));
        }

        /// <summary>
        /// 根据编号更新工地
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWConstructionSiteDto UpdateFWConstructionSite(int id, FWConstructionSiteDto entity)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            if (id != entity.ID)
                throw new WapException(StateCode.CODE_ARGUMENT_NOT_EQUAL, "参数不一致！");

            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();

            return FWConstructionSiteDto.FromModel(_iFWConstructionSiteRepository.UpdateFWConstructionSite(id, entity.ToModel()));
        }

        /// <summary>
        /// 根据编号删除工地
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWConstructionSiteById(int id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            return _iFWConstructionSiteRepository.DeleteFWConstructionSiteById(id);
        }

        /// <summary>
        /// 根据编号获取工地
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWConstructionSiteDto GetFWConstructionSiteById(Int32 id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            return FWConstructionSiteDto.FromModel(_iFWConstructionSiteRepository.GetFWConstructionSiteById(id));
        }

        /// <summary>
        /// 获取全部工地
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWConstructionSiteDto> GetFWConstructionSites()
        {
            var result = _iFWConstructionSiteRepository.GetFWConstructionSites();
            return result.Select(p => FWConstructionSiteDto.FromModel(p)).ToList();
        }
    }
}
