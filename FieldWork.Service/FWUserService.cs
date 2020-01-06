using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Service
{
    /// <summary>
    /// /
    /// </summary>
    public class FWUserServiceImpl : BaseService, IFWUserService
    {
        private IFWUserRepository _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public FWUserServiceImpl(IFWUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWUserDto CreateFWUser(FWUserDto entity)
        {
            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "用户模型为空！");
            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();
            return FWUserDto.FromModel(_userRepository.CreateFWUser(entity.ToModel()));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWUserDto UpdateFWUser(int id, FWUserDto entity)
        {
            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "用户模型为空！");
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "用户编号为空！");
            if (id != entity.Id)
                throw new WapException(StateCode.CODE_ARGUMENT_NOT_EQUAL, "用户编号不一致！");
            var result = _userRepository.UpdateFWUser(id, entity.ToModel());
            return FWUserDto.FromModel(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWUser(int id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "用户编号为空！");
            return _userRepository.DeleteFWUser(id);
        }

        /// <summary>
        /// 查询指定用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWUserDto GetFWUserById(int id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "用户编号为空！");
            return FWUserDto.FromModel(_userRepository.GetFWUserById(id));
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWUserDto> GetFWUserAll()
        {
            var result = _userRepository.GetFWUserAll();
            return result.Select(p => FWUserDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 根据网格编号获取用户
        /// </summary>
        /// <param name="gridId"></param>
        /// <returns></returns>
        public IEnumerable<FWUserDto> GetFWUserByGridId(int gridId)
        {
            if (gridId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "网格编号为空！");
            var result = _userRepository.GetFWUserByGridId(gridId);
            return result.Select(p => FWUserDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 根据组织编号获取用户
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWUserDto> GetFWUserByStationId(int stationId)
        {
            if (stationId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "组织编号为空！");
            var result = _userRepository.GetFWUserByStationId(stationId);
            return result.Select(p => FWUserDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 获取指定网格下指定角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        public IEnumerable<FWUserDto> GetFWUserByRoleAndOrgId(int roleId, int stationId)
        {
            if (stationId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "站点编码为空！");

            if (roleId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查人员角色为空！");

            var result = _userRepository.GetFWUserByRoleAndOrgId(roleId, stationId);
            return result.Select(p => FWUserDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 获取指定网格下指定角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        public IEnumerable<FWUserDto> GetFWUserByRoleAndGridId(int roleId, int gridId) {
            if (gridId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "网格编码为空！");

            if (roleId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查人员角色为空！");

            var result = _userRepository.GetFWUserByRoleAndGridId(roleId,gridId);

            return result.Select(p => FWUserDto.FromModel(p)).ToList();

        }
    }
}
