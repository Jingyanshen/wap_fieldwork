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
using Newtonsoft.Json;


namespace SH3H.WAP.FieldWork.Service
{
    public class FWGridServiceImpl : BaseService, IFWGridService
    {
        private IFWGridRepository _gridRepository;
        private IFWUserRepository _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridRepository"></param>
        /// <param name="userRepository"></param>
        public FWGridServiceImpl(IFWGridRepository gridRepository, IFWUserRepository userRepository)
        {
            _gridRepository = gridRepository;

            _userRepository = userRepository;
        }


        /// <summary>
        /// 新增网格
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWGridDto CreateFWGrid(FWGridDto entity)
        {
            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();

            return FWGridDto.FromModel(_gridRepository.CreateFWGrid(entity.ToModel()));
        }

        /// <summary>
        /// 根据编号更新网格
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWGridDto UpdateFWGridById(Int32 id, FWGridDto entity)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            if (id != entity.ID)
                throw new WapException(StateCode.CODE_ARGUMENT_NOT_EQUAL, "参数不一致！");

            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();

            return FWGridDto.FromModel(_gridRepository.UpdateFWGridById(id, entity.ToModel()));
        }

        /// <summary>
        /// 根据编号删除网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWGridById(Int32 id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            return _gridRepository.DeleteFWGridById(id);
        }

        /// <summary>
        /// 根据编号获取网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWGridDto GetFWGridById(Int32 id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            return FWGridDto.FromModel(_gridRepository.GetFWGridById(id));
        }

        /// <summary>
        /// 获取全部网格
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWGridDto> GetFWGridAll()
        {
            var result = _gridRepository.GetFWGridAll();
            return result.Select(p => FWGridDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 获取网格geoJson
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetGeoJsonById(int id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            return _gridRepository.GetGeoJsonById(id);
        }
        /// <summary>
        /// 获取人员所在组织以及子组织网格
        /// </summary>
        /// <returns></returns>
        public FWGridBuildTreeDto GetFWGridByUserId(int userid)
        {
            if (userid <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "人员编号为空！");
            var getuser = _userRepository.GetFWUserById(userid);
            var result = _gridRepository.GetFWGridByUserId(userid);

            if (getuser == null || result == null)
                return null;



            FWGridBuildTreeDto dto = new FWGridBuildTreeDto()
            {
                ParentId = result.Where(p => p.StationId == getuser.StationId).First().ParentId,
                GridDtos = result.Select(p => FWGridDto.FromModel(p)).ToList()
            };
            return dto;
        }


        /// <summary>
        ///  根据当前登录用户组织信息获取其下网格
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWGridDto> GetFWGridsByOrgId(int orgId)
        {
            var allGrids = GetFWGridAll().ToList();
            var currentUserGrid = allGrids.FirstOrDefault(x => x.StationId == orgId);
            var result = new List<FWGridDto>();
            if (null != currentUserGrid)
            {
                if (currentUserGrid.ParentId == -1)
                {
                    result = allGrids;
                }
                else
                {
                    result = allGrids.Where(x => x.ParentId == currentUserGrid.ID).ToList();
                    result.Add(currentUserGrid);
                }
            }
            return result;
        }

        public bool updateGeo()
        {
            var grids = GetFWGridAll().ToList();
            try
            {
                foreach (var grid in grids)
                {
                    GeoJson geo = JsonConvert.DeserializeObject<GeoJson>(grid.Geometry);
                    var Coos = geo.Geometry.Coordinates[0];
                    string text = "POLYGON((";
                    foreach (var Coo in Coos)
                    {
                        text += Coo[0] + " " + Coo[1] + ",";
                    }
                    text = text.Substring(0, text.Length - 1);
                    text += "))";
                    _gridRepository.updateGeo(text ,grid.ID);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public class GeoJson
        {
            /// <summary>
            /// 类型
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// 几何属性
            /// </summary>
            public Geometry Geometry { get; set; }
            /// <summary>
            /// 属性
            /// </summary>
            public Properties Properties { get; set; }
        }

        public class Geometry
        {
            /// <summary>
            /// 类型
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// 属性
            /// </summary>
            public List<List<List<double>>> Coordinates { get; set; }
        }

        public class Properties
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }
        }
    }
}
