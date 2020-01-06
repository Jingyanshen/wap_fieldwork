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
using SH3H.WAP.FieldWork.Model.ViewModels;
using Newtonsoft.Json;

namespace SH3H.WAP.FieldWork.Service
{
    public class FWPatrolObjectServiceImpl : BaseService, IFWPatrolObjectService
    {
        private IFWPatrolObjectRepository _patrolObjectRepository;
        private IFWPatrolPeriodRepository _patrolPeriodRepository;
        public FWPatrolObjectServiceImpl(IFWPatrolObjectRepository patrolObjectRepository, IFWPatrolPeriodRepository patrolPeriodRepository)
        {
            _patrolObjectRepository = patrolObjectRepository;
            _patrolPeriodRepository = patrolPeriodRepository;
        }
        /// <summary>
        /// 新增FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolObjectDto CreateFWPatrolObject(FWPatrolObjectDto entity)
        {
            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();

            return FWPatrolObjectDto.FromModel(_patrolObjectRepository.CreateFWPatrolObject(entity.ToModel()));
        }

        /// <summary>
        /// 批量新增巡查对象
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolObjectDto> AddFWPatrolObjects(List<FWPatrolObjectDto> entitys)
        {
            if (entitys.Count == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");
            List<FWPatrolObjectDto> fWPatrolObjectDtos = new List<FWPatrolObjectDto>();
            foreach (var entity in entitys)
            {
                var Obj = entity.Validate();
                if (!Obj.IsValid) continue;

                var ObjMod = entity.ToModel();
                var fWPatrolObjectDto = FWPatrolObjectDto.FromModel(_patrolObjectRepository.CreateFWPatrolObject(ObjMod));
                fWPatrolObjectDtos.Add(fWPatrolObjectDto);
            }
            return fWPatrolObjectDtos;
        }

        /// <summary>
        /// 根据编号修改FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolObjectDto UpdateFWPatrolObjectById(Int32 id, FWPatrolObjectDto entity)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            if (id != entity.ID)
                throw new WapException(StateCode.CODE_ARGUMENT_NOT_EQUAL, "参数不一致！");

            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();

            return FWPatrolObjectDto.FromModel(_patrolObjectRepository.UpdateFWPatrolObjectById(id, entity.ToModel()));
        }

        /// <summary>
        /// 根据编号删除FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolObject(Int32 id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            return _patrolObjectRepository.DeleteFWPatrolObject(id);
        }

        /// <summary>
        /// 获取所有FWPatrolObject模型实体对象
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolObjectDto> GetFWPatrolObjectAll()
        {
            return _patrolObjectRepository.GetFWPatrolObjectAll().Select(p => FWPatrolObjectDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 根据编号获取指定FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWPatrolObjectDto GetFWPatrolObjectById(Int32 id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");

            return FWPatrolObjectDto.FromModel(_patrolObjectRepository.GetFWPatrolObjectById(id));
        }

        /// <summary>
        /// 根据网格编号获取对应FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="GridId"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolObjectDto> GetFWPatrolObjectByGridId(Int32 GridId)
        {
            if (GridId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "网格编号为空！");

            List<FWPatrolObjectDto> fWPatrolObjectDtos = new List<FWPatrolObjectDto>();
            IEnumerable<FWPatrolObject> fWPatrolObjects = _patrolObjectRepository.GetFWPatrolObjectByGridId(GridId);
            foreach (var fWPatrolObject in fWPatrolObjects)
            {
                fWPatrolObjectDtos.Add(FWPatrolObjectDto.FromModel(fWPatrolObject));
            }

            return fWPatrolObjectDtos;
        }

        /// <summary>
        /// 根据网格编号及巡查类型获取对应巡查对象
        /// </summary>
        /// <param name="GridId">网格编号</param>
        /// <param name="Type">巡查类型</param>
        /// <returns></returns>
        public IEnumerable<FWPatrolObjectDto> GetFWPatrolObjectByGridIdAndType(Int32 GridId, Int32 Type)
        {
            if (GridId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "网格编号为空！");
            if (Type <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查类型号为空！");

            List<FWPatrolObjectDto> fWPatrolObjectDtos = new List<FWPatrolObjectDto>();
            IEnumerable<FWPatrolObject> fWPatrolObjects = _patrolObjectRepository.GetFWPatrolObjectByGridIdAndType(GridId, Type);
            foreach (var fWPatrolObject in fWPatrolObjects)
            {
                fWPatrolObjectDtos.Add(FWPatrolObjectDto.FromModel(fWPatrolObject));
            }

            return fWPatrolObjectDtos;
        }

        /// <summary>
        /// 满足 自定义周期设置、批量选择 的巡查对象新增服务
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolObjectDto> CreateFWPatrolObjectBase(FWPatrolObjectViewModel viewModel)
        {
            if (viewModel == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            var _dtos = new List<FWPatrolObjectDto>();

            // 自定义周期
            viewModel.PeriodId = DefineCustomizePeriod(viewModel);

            if (viewModel.IsBatch)
            {
                // 批量选择
                if (!string.IsNullOrEmpty(viewModel.GISObjectString))
                {
                    var gisObjects = JsonConvert.DeserializeObject<List<GISObjectViewModel>>(viewModel.GISObjectString);
                    gisObjects.ForEach(item =>
                    {
                        if (null != item)
                        {
                            // data source reorganization
                            var patrolObjectDto = new FWPatrolObjectDto
                            {
                                X = item.X,
                                Y = item.Y,
                                Name = item.Name,
                                Address = item.Address,
                                Road = item.Road,
                                GisObjectId = item.GisObjectId,
                                GisLayerId = item.GisLayerId,
                                MapLayerId = item.MapLayerId,
                                DisplayId = item.DisplayId,

                                ID = viewModel.ID,
                                CreateTime = viewModel.CreateTime,
                                Creator = viewModel.Creator,
                                Extend = viewModel.Extend,
                                Frequency = viewModel.Frequency,
                                Grade = viewModel.Grade,
                                GridId = viewModel.GridId,
                                PatrolType = viewModel.PatrolType,
                                Period = viewModel.Period,
                                PeriodId = viewModel.PeriodId
                            };

                            var target =
                                GetFWPatrolObjectAll()
                                .FirstOrDefault(x => x.GisObjectId == patrolObjectDto.GisObjectId && x.MapLayerId == patrolObjectDto.MapLayerId && x.GisLayerId == patrolObjectDto.GisLayerId);

                            if (target == null)
                            {
                                var result = FWPatrolObjectDto.FromModel(_patrolObjectRepository.CreateFWPatrolObject(patrolObjectDto.ToModel()));
                                _dtos.Add(result);
                            }
                            else
                            {
                                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "当前已存在根据GIS对象编号、GIS图层编号、地图服务编号确定的一条记录！");
                            }
                        }
                    });
                }
            }
            else
            {
                // 绘点
                var result = _patrolObjectRepository.CreateFWPatrolObject(viewModel.ToModel());
                if (null != result)
                {
                    _dtos.Add(FWPatrolObjectDto.FromModel(result));
                }
            }
            return _dtos;
        }

        /// <summary>
        /// 根据网格编号及巡查类型模糊搜索巡查对象
        /// </summary>
        /// <param name="gridId"></param>
        /// <param name="patrolType"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolObjectDto> Search(int gridId, int patrolType)
        {
            var objects = GetFWPatrolObjectAll();
            if (gridId != -1)
            {
                objects = objects.Where(p => p.GridId == gridId).ToList();
            }
            if (patrolType != -1)
            {
                objects = objects.Where(p => p.PatrolType == patrolType).ToList();
            }
            return objects;
        }

        /// <summary>
        /// 满足自定义周期设置的根据巡查对象Id获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWPatrolObjectViewModel GetFWPatrolObjectBaseById(int id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "编号为空！");
            var viewModel = new FWPatrolObjectViewModel();
            var patrolObject = _patrolObjectRepository.GetFWPatrolObjectById(id);
            if (patrolObject != null)
            {
                viewModel.ID = patrolObject.ID;
                viewModel.DisplayId = patrolObject.DisplayId;
                viewModel.Name = patrolObject.Name;
                viewModel.Address = patrolObject.Address;
                viewModel.Road = patrolObject.Road;
                viewModel.X = patrolObject.X;
                viewModel.Y = patrolObject.Y;
                viewModel.Extend = patrolObject.Extend;
                viewModel.Frequency = patrolObject.Frequency;
                viewModel.GisLayerId = patrolObject.GisLayerId;
                viewModel.GisObjectId = patrolObject.GisObjectId;
                viewModel.MapLayerId = patrolObject.MapLayerId;
                viewModel.Grade = patrolObject.Grade;
                viewModel.GridId = patrolObject.GridId;
                viewModel.PatrolType = patrolObject.PatrolType;
                viewModel.Period = patrolObject.Period;
                viewModel.PeriodId = patrolObject.PeriodId;
                viewModel.CreateTime = patrolObject.CreateTime;
                viewModel.Creator = patrolObject.Creator;
            }
            if (patrolObject.Period.Equals("customize", StringComparison.InvariantCultureIgnoreCase))
            {
                // 自定义
                var patrolPeriod = _patrolPeriodRepository.GetFWPatrolPeriodById(patrolObject.PeriodId);
                if (patrolPeriod != null)
                {
                    viewModel.PatrolPeriodId = patrolPeriod.PeriodId;
                    viewModel.PeriodBase = patrolPeriod.PeriodBase;
                    viewModel.Interval = patrolPeriod.Interval;
                }
            }
            return viewModel;
        }

        /// <summary>
        /// 满足自定义周期设置的巡查对象修改方法
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public bool UpdateFWPatrolObjectBase(FWPatrolObjectViewModel viewModel)
        {
            if (viewModel == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");


            if (viewModel.Period.Equals("customize", StringComparison.InvariantCultureIgnoreCase))
            {
                var patrolPeriod = new FWPatrolPeriodDto
                {
                    PeriodId = viewModel.PatrolPeriodId,
                    PeriodBase = viewModel.PeriodBase,
                    Interval = viewModel.Interval
                };
                var _patrolPeriod = _patrolPeriodRepository.CreateFWPatrolPeriod(patrolPeriod.ToModel());
                viewModel.PeriodId = _patrolPeriod.PeriodId;
            }
            else
            {
                viewModel.PeriodId = 0;
            }

            return _patrolObjectRepository.UpdateFWPatrolObjectById(viewModel.ID, viewModel.ToModel()) == null ? false : true;
        }

        private int DefineCustomizePeriod(FWPatrolObjectViewModel viewModel)
        {
            if (viewModel.Period.Equals("customize", StringComparison.InvariantCultureIgnoreCase))
            {
                var patrolPeriod = new FWPatrolPeriodDto
                {
                    PeriodId = viewModel.PatrolPeriodId,
                    PeriodBase = viewModel.PeriodBase,
                    Interval = viewModel.Interval
                };

                var _patrolPeriod = _patrolPeriodRepository.CreateFWPatrolPeriod(patrolPeriod.ToModel());

                return _patrolPeriod == null ? 0 : _patrolPeriod.PeriodId;
            }

            return viewModel.PeriodId;
        }
    }


    public class GISObjectViewModel
    {
        public decimal X { get; set; }

        public decimal Y { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Road { get; set; }

        public string GisObjectId { get; set; }

        public string GisLayerId { get; set; }

        public string MapLayerId { get; set; }

        public string DisplayId { get; set; }
    }
}
