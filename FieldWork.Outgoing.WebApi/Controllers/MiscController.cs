using FieldWork.Outgoing.Model;
using FieldWork.Outgoing.WebApi.Response;
using SH3H.SDK.Service.Core;
using SH3H.SDK.Infrastructure.Logging;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Service;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SH3H.SDK.Definition.Exceptions;
using SH3H.WAP.FieldWork.Share;
using SH3H.SDK.WebApi.Controllers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SH3H.WAP.WorkSheet.Share.GIShelper;

namespace FieldWork.Outgoing.WebApi.Controllers
{
    /// <summary>
    /// 其他API服务
    /// </summary>
    [RoutePrefix("fw/v1")]
    public class MiscController : BaseController
    {
        #region 获取全要素设备
        /// <summary>
        ///  获取全要素设备
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        [HttpGet]
        [Route("qysfacility")]
        public List<QYSFacilityOut> GetQYSFacilityList(string userId)
        {
            List<QYSFacilityOut> qYSFacilityOuts = new List<QYSFacilityOut>();
            if (null == userId)
                return qYSFacilityOuts;
            int _userId = 0;
            int.TryParse(userId, out _userId);
            if (_userId <= 0)
                return qYSFacilityOuts;
            var result = ServiceFactory.GetService<IFWQYSFacilityService>().GetFWQYSFacilityById(_userId);
            qYSFacilityOuts = new List<QYSFacilityOut>(result.Select(p => QYSFacilityOut.FromDto(p)).ToList());
            if (qYSFacilityOuts.Count <= 0)
            {
                result = ServiceFactory.GetService<IFWQYSFacilityService>().GetFWQYSFacility();
                qYSFacilityOuts = new List<QYSFacilityOut>(result.Select(p => QYSFacilityOut.FromDto(p)).ToList());
            }
            
            return qYSFacilityOuts;
        }
        #endregion

        #region 获取到场时间
        /// <summary>
        ///  获取到场时间
        /// </summary>
        /// <param name="TaskId">工单编号</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ws/arrivetime")]
        public List<ArriveTimeOut> GetArriveTimeById(string TaskId)
        {
            List<ArriveTimeOut> arriveTimeOuts = new List<ArriveTimeOut>();
            try
            {
                if (null == TaskId)
                    return arriveTimeOuts;
                ArriveTimeOut arriveTimeOut = new ArriveTimeOut
                {
                    Time = ServiceFactory.GetService<IMiscService>().GetArriveTimeById(TaskId).Replace("/","-")
                };
                arriveTimeOuts.Add(arriveTimeOut);
                return arriveTimeOuts;
            }
            catch
            {
                return arriveTimeOuts;
            }
        }
        #endregion

        #region 获取联系方式
        /// <summary>
        ///  获取联系方式
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ws/phone")]
        public List<PhoneOut> GetPhoneById(string userId)
        {
            List<PhoneOut> phoneOuts = new List<PhoneOut>();
            try
            {
                if (null == userId)
                    return phoneOuts;
                int _userId = 0;
                int.TryParse(userId, out _userId);
                if (_userId <= 0)
                    return phoneOuts;
                PhoneOut phoneOut = new PhoneOut
                {
                    Phone = ServiceFactory.GetService<IAuthService>().GetPhoneByuserId(_userId)
                };
                phoneOuts.Add(phoneOut);
                return phoneOuts;
            }
            catch
            {
                return phoneOuts;
            }

        }
        #endregion

        #region 获取在线车辆
        /// <summary>
        /// 获取车辆
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("vehicle/online")]
        [ActionName("GetOnlineVehicle")]
        public WapOutgoingResponse<List<Vehicle>> GetVehicle(string stationId)
        {
            int _stationId = 0;
            var url = ConfigurationSettings.AppSettings["OnlineVehicleOut"];
            var wapTokenResponsText = RequestHelper.RequestUrl(url + "Token?token=SWJT", null);
            JObject wapTokenRespons = JObject.Parse(wapTokenResponsText);
            while (wapTokenRespons["Access_Token"].ToString().Count() == 0 && int.Parse((wapTokenRespons["Expires_In"]).ToString()) <= 300)
            {
                wapTokenResponsText = RequestHelper.RequestUrl(url + "Token?token=SWJT", null);
                wapTokenRespons = JObject.Parse(wapTokenResponsText);
            }
            string Access_Token = wapTokenRespons["Access_Token"].ToString();
            string wapVehicleResponsUrl = url + "Business/ReadRealTimeVeh?accessToken=" + Access_Token + "&tenantNo=深圳市水务集团有限公司";
            var wapVehicleResponsText = RequestHelper.RequestUrl(wapVehicleResponsUrl, null);
            JObject wapVehicleRespons = JObject.Parse(wapVehicleResponsText);
            List<Vehicle> vehicles = new List<Vehicle>();
            if (null != wapVehicleRespons["ResultData"] && wapVehicleRespons["ResultData"].ToString().Count() > 0 )
            {
                CoordinateTransformHelper coordinateTransformHelper = new CoordinateTransformHelper();
                var resultData = wapVehicleRespons["ResultData"].ToList();
                var results = resultData.Where(x => (DateTime.Now - Convert.ToDateTime(x["CurrentDateTime"].ToString())).TotalMinutes < 10).ToList();
                if(null != stationId)
                {
                    int.TryParse(stationId, out _stationId);
                    if (_stationId <= 0)
                        return new WapOutgoingResponse <List<Vehicle>>(vehicles);
                    else if(_stationId > 1)
                    {
                        var allStations = ServiceFactory.GetService<IAuthService>().GetOrganization().ToList();
                        var currentStation = allStations.FirstOrDefault(x => x.StationId == _stationId);
                        results = results.Where(x => x["CompanyName"].ToString() == currentStation.Name).ToList();
                    }
                }
                foreach (var result in results)
                {
                    var lon = Convert.ToDouble(result["Longitude"].ToString());
                    var lat = Convert.ToDouble(result["Latitude"].ToString());
                    double[] wgs84ll = coordinateTransformHelper.CoordinateTransform("WGS84", "CUSTOM", lon, lat);
                    Vehicle vehicle = new Vehicle
                    {
                        vehicleNo = result["VehNum"].ToString(),
                        datetime = Convert.ToDateTime(result["CurrentDateTime"].ToString()),
                        x = wgs84ll[0],
                        y = wgs84ll[1]
                    };
                    vehicles.Add(vehicle);
                }
            }
            return new WapOutgoingResponse<List<Vehicle>>(vehicles);
        }
        #endregion

        #region 根据一级排水户关联接户管信息
        /// <summary>
        /// 根据一级排水户关联接户管信息
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RelationPipe")]
        [ActionName("GetRelationPipe")]
        public List<RelationPipeOut> GetRelationPipe(string objectId)
        {
            string userName = "";
            List<RelationPipeOut> relationPipeOuts = new List<RelationPipeOut>();
            var url = ConfigurationSettings.AppSettings["GisQuery"];

            var wapUserUrl = url + "mobile/mobile_drain_all_N/MapServer/10/query?where=OBJECTID=" + objectId + "&text=&objectIds=&time=&geometry=&geometryType=esriGeometryEnvelope&inSR=&spatialRel=esriSpatialRelIntersects&relationParam=&outFields=USERONENAME&returnGeometry=false&maxAllowableOffset=&geometryPrecision=&outSR=&returnIdsOnly=false&returnCountOnly=false&orderByFields=&groupByFieldsForStatistics=&outStatistics=&returnZ=false&returnM=false&gdbVersion=&returnDistinctValues=false&f=pjson";
            var wapUserResponsText = RequestHelper.RequestUrl(wapUserUrl, null);
            JObject wapUserRespons = JObject.Parse(wapUserResponsText);
            if(null != wapUserRespons["features"] && wapUserRespons["features"].ToString().Count() > 0)
            {
                var userDatas = wapUserRespons["features"].ToList();
                var userData = userDatas[0];
                JObject jObject = JObject.Parse(userData["attributes"].ToString());
                userName = jObject["USERONENAME"] != null ? jObject["USERONENAME"].ToString() : "";
            }
            if(userName != "")
            {
                userName = "'" + userName + "'";
                var wapPipeUrl = url + "mobile/mobile_drain_all_N/MapServer/12/query?where=USERNAME=" + userName + "&text=&objectIds=&time=&geometry=&geometryType=esriGeometryEnvelope&inSR=&spatialRel=esriSpatialRelIntersects&relationParam=&outFields=*&returnGeometry=false&maxAllowableOffset=&geometryPrecision=&outSR=&returnIdsOnly=false&returnCountOnly=false&orderByFields=&groupByFieldsForStatistics=&outStatistics=&returnZ=false&returnM=false&gdbVersion=&returnDistinctValues=false&f=pjson";
                var wapPipeResponsText = RequestHelper.RequestUrl(wapPipeUrl, null);
                JObject wapPipeRespons = JObject.Parse(wapPipeResponsText);
                if (null != wapPipeRespons["features"] && wapPipeRespons["features"].ToString().Count() > 0)
                {
                    var resultDatas = wapPipeRespons["features"].ToList();
                    foreach (var resultData in resultDatas)
                    {
                        JObject result = JObject.Parse(resultData["attributes"].ToString());
                        RelationPipeOut relationPipeOut = new RelationPipeOut
                        {
                            PipeId = result["CONDUITID"] != null ? result["CONDUITID"].ToString() : "",
                            Address = result["ADDRESS"] != null && result["ADDRESS"].ToString().Count() > 0 ? result["ADDRESS"].ToString() : result["ROAD"] != null ? result["ROAD"].ToString() : "",
                            Diameter = result["DIAMETER"] != null ? result["DIAMETER"].ToString() : "",
                            Type = result["SUBTYPE"] != null ? result["SUBTYPE"].ToString() : null 
                    };
                        relationPipeOuts.Add(relationPipeOut);
                    }
                }
            }
            return relationPipeOuts;
        }
        #endregion

        #region 根据水表编码获取水表信息
        /// <summary>
        /// 根据水表编码获取水表信息
        /// </summary>
        /// <param name="meterCode"></param>
        /// <param name="meterId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Meter")]
        [ActionName("GetMeter")]
        public List<MeterInfoOut> GetMeterInformation(string meterCode , string meterId)
        {
            List<MeterInfoOut> meterInfoOuts = new List<MeterInfoOut>();
            try
            {
                if (String.IsNullOrEmpty(meterCode) || String.IsNullOrEmpty(meterId))
                    return meterInfoOuts;
                var url = ConfigurationSettings.AppSettings["MeterQuery"];
                string userCode = meterId.Substring(0, meterId.Length - 2);
                var wapUserUrl = url + "fieldWork/getUserInfo?userCode=" + userCode;
                var wapUserResponsText = RequestHelper.RequestUrl(wapUserUrl, null);
                JObject wapUserRespons = JObject.Parse(wapUserResponsText);
                if (null != wapUserRespons["data"] && wapUserRespons["data"].ToString().Count() > 0)
                {
                    JObject jObject = JObject.Parse(wapUserRespons["data"].ToString());
                    int deptId = int.Parse(jObject["deptId"].ToString());
                    var wapMeterUrl = url + "fieldWork/getIdleMeterInfo?meterCode=" + meterCode + "&deptId=" + deptId;
                    var wapMeterResponsText = RequestHelper.RequestUrl(wapMeterUrl, null);
                    JObject wapMeterRespons = JObject.Parse(wapMeterResponsText);
                    if (null != wapMeterRespons["data"] && wapMeterRespons["data"].ToString().Count() > 0)
                    {
                        JObject result = JObject.Parse(wapMeterRespons["data"].ToString());
                        MeterInfoOut meterInfoOut = new MeterInfoOut
                        {
                            meterId = result["waterMeterId"] != null ? result["waterMeterId"].ToString() : "",
                            deptId = result["deptId"] != null ? result["deptId"].ToString() : "",
                            meterCode = result["meterCode"] != null ? result["meterCode"].ToString() : "",
                            sealCode = result["sealCode"] != null ? result["sealCode"].ToString() : "",
                            meterTypeId = result["meterTypeId"] != null ? result["meterTypeId"].ToString() : "",
                            meterDiameterId = result["meterDiameterId"] != null ? result["meterDiameterId"].ToString() : "",
                            meterDiameterName = result["meterDiameterName"] != null ? result["meterDiameterName"].ToString() : "",
                            factoryId = result["factoryId"] != null ? result["factoryId"].ToString() : "",
                            factoryName = result["factoryName"] != null ? result["factoryName"].ToString() : "",
                            meterModuleId = result["meterModuleId"] != null ? result["meterModuleId"].ToString() : "",
                            meterModuleCode = result["meterModuleCode"] != null ? result["meterModuleCode"].ToString() : ""
                        };
                        meterInfoOuts.Add(meterInfoOut);
                    }
                }
                return meterInfoOuts;
            }
            catch
            {
                return meterInfoOuts;
            }

        }
        #endregion
        
        #region 根据工单编号新增水表并刷新快照表状态
        /// <summary>
        /// 根据工单编号新增水表并刷新快照表状态
        /// </summary>
        /// <param name="wsId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MeterNew")]
        [ActionName("Update")]
        public bool UpdateMeterNew(string wsId)
        {
            if (string.IsNullOrEmpty(wsId))
                return false;
            string Table = ServiceFactory.GetService<IMiscService>().GetTable(wsId);
            var url = ConfigurationSettings.AppSettings["MeterQuery"];
            var wapFactoryUrl = url + "fieldWork/getMeterFactory";
            var wapFactoryResponsText = RequestHelper.RequestUrl(wapFactoryUrl, null);
            JObject wapFactoryRespons = JObject.Parse(wapFactoryResponsText);
            if (null != wapFactoryRespons["data"] && wapFactoryRespons["data"].ToString().Count() > 0)
            {
                var Factorys = wapFactoryRespons["data"].ToList();
                string FactoryId = "";
                MeterNew meterNew = ServiceFactory.GetService<IMiscService>().GetFields(wsId, Table);
                foreach (var Factory in Factorys)
                {
                    if (Factory["factoryName"].ToString() == meterNew.factory)
                    {
                        FactoryId = Factory["factoryId"].ToString();
                        break;
                    }
                }
                if ((meterNew.disposeSituation == 26 || meterNew.disposeSituation == 30) && FactoryId != "")
                {
                    string userCode = meterNew.oldMeterNumber.Substring(0, meterNew.oldMeterNumber.Length - 2);
                    var wapUserUrl = url + "fieldWork/getUserInfo?userCode=" + userCode;
                    var wapUserResponsText = RequestHelper.RequestUrl(wapUserUrl, null);
                    JObject wapUserRespons = JObject.Parse(wapUserResponsText);
                    if (null != wapUserRespons["data"] && wapUserRespons["data"].ToString().Count() > 0)
                    {
                        JObject jObject = JObject.Parse(wapUserRespons["data"].ToString());
                        int deptId = int.Parse(jObject["deptId"].ToString());
                        var wapModuleUrl = url + "fieldWork/getFactoryMeterModule?factoryId=" + FactoryId;
                        var wapModuleResponsText = RequestHelper.RequestUrl(wapModuleUrl, null);
                        JObject wapModuleRespons = JObject.Parse(wapModuleResponsText);
                        string ModuleId = "";
                        if (null != wapModuleRespons["data"] && wapModuleRespons["data"].ToString().Count() > 0)
                        {
                            var Modules = wapModuleRespons["data"].ToList();
                            foreach (var Module in Modules)
                            {
                                if (Module["metermodulecode"].ToString() == meterNew.meterModule)
                                {
                                    ModuleId = Module["metermoduleId"].ToString();
                                    break;
                                }
                            }
                            try
                            {
                                Meter meter = new Meter
                                {
                                    meterCode = meterNew.number,
                                    meterDiameterId = meterNew.caliber,
                                    factoryId = int.Parse(FactoryId),
                                    meterTypeId = meterNew.type,
                                    meterModuleId = int.Parse(ModuleId),
                                    sealCode = meterNew.sealNumber,
                                    deptId = deptId
                                };
                                string data = JsonConvert.SerializeObject(meter);
                                HttpConfig httpConfig = new HttpConfig
                                {
                                    ContentType = "application/json"
                                };
                                var wapMeterUrl = url + "fieldWork/newWaterMeter";
                                var wapMeterResponsText = HttpHelper.SendPost(wapMeterUrl, data, httpConfig);
                                JObject wapMeterRespons = JObject.Parse(wapMeterResponsText);
                                if (int.Parse(wapMeterRespons["result"].ToString()) == 1)
                                {
                                    ServiceFactory.GetService<IMiscService>().UpdateBWFPLHB(wsId);
                                    LogManager.Get().Info(wsId + "已重置状态及次数");
                                    return true;
                                }
                                else
                                    return false;
                            }
                            catch (Exception ex)
                            {
                                LogManager.Get().Info(ex.ToString());
                                return false;
                            }
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        #endregion

        #region 新增水表
        /// <summary>
        /// 新增水表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Meter")]
        [ActionName("Create")]
        public WapOutgoingResponse<MeterInfoOut> CreateMeter(MeterOut meterOut)
        {
            var url = ConfigurationSettings.AppSettings["MeterQuery"];
            string userCode = meterOut.oldMeterId.Substring(0, meterOut.oldMeterId.Length - 2);
            var wapUserUrl = url + "fieldWork/getUserInfo?userCode=" + userCode;
            var wapUserResponsText = RequestHelper.RequestUrl(wapUserUrl, null);
            JObject wapUserRespons = JObject.Parse(wapUserResponsText);
            int deptId = 0;
            if (null != wapUserRespons["data"] && wapUserRespons["data"].ToString().Count() > 0)
            {
                JObject jObject = JObject.Parse(wapUserRespons["data"].ToString());
                deptId = int.Parse(jObject["deptId"].ToString());
            }
            else
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "获取用户信息失败");

            if (deptId != 0)
            {
                var wapMeterUrl = url + "fieldWork/getIdleMeterInfo?meterCode=" + meterOut.meterCode + "&deptId=" + deptId;
                var wapMeterResponsText = RequestHelper.RequestUrl(wapMeterUrl, null);
                JObject wapMeterRespons = JObject.Parse(wapMeterResponsText);
                if (null != wapMeterRespons["data"] && wapMeterRespons["data"].ToString().Count() > 0)
                {
                    JObject result = JObject.Parse(wapMeterRespons["data"].ToString());
                    MeterInfoOut meterInfoOut = new MeterInfoOut
                    {
                        meterId = result["waterMeterId"] != null ? result["waterMeterId"].ToString() : "",
                        deptId = result["deptId"] != null ? result["deptId"].ToString() : "",
                        meterCode = result["meterCode"] != null ? result["meterCode"].ToString() : "",
                        sealCode = result["sealCode"] != null ? result["sealCode"].ToString() : "",
                        meterTypeId = result["meterTypeId"] != null ? result["meterTypeId"].ToString() : "",
                        meterDiameterId = result["meterDiameterId"] != null ? result["meterDiameterId"].ToString() : "",
                        meterDiameterName = result["meterDiameterName"] != null ? result["meterDiameterName"].ToString() : "",
                        factoryId = result["factoryId"] != null ? result["factoryId"].ToString() : "",
                        factoryName = result["factoryName"] != null ? result["factoryName"].ToString() : "",
                        meterModuleId = result["meterModuleId"] != null ? result["meterModuleId"].ToString() : "",
                        meterModuleCode = result["meterModuleCode"] != null ? result["meterModuleCode"].ToString() : ""
                    };
                    return new WapOutgoingResponse<MeterInfoOut>(meterInfoOut);
                }
                else
                {
                    var wapFactoryUrl = url + "fieldWork/getMeterFactory";
                    var wapFactoryResponsText = RequestHelper.RequestUrl(wapFactoryUrl, null);
                    JObject wapFactoryRespons = JObject.Parse(wapFactoryResponsText);
                    string FactoryId = "";
                    if (null != wapFactoryRespons["data"] && wapFactoryRespons["data"].ToString().Count() > 0)
                    {
                        var Factorys = wapFactoryRespons["data"].ToList();
                        foreach (var Factory in Factorys)
                        {
                            if (Factory["factoryName"].ToString() == meterOut.factoryName)
                            {
                                FactoryId = Factory["factoryId"].ToString();
                                break;
                            }
                        }
                    }
                    else
                        throw new WapException(StateCode.CODE_ARGUMENT_NULL, "获取用户信息失败");

                    string ModuleId = "";
                    if (FactoryId != "")
                    {
                        var wapModuleUrl = url + "fieldWork/getFactoryMeterModule?factoryId=" + FactoryId;
                        var wapModuleResponsText = RequestHelper.RequestUrl(wapModuleUrl, null);
                        JObject wapModuleRespons = JObject.Parse(wapModuleResponsText);

                        if (null != wapModuleRespons["data"] && wapModuleRespons["data"].ToString().Count() > 0)
                        {
                            var Modules = wapModuleRespons["data"].ToList();
                            foreach (var Module in Modules)
                            {
                                if (Module["metermodulecode"].ToString() == meterOut.meterModuleCode)
                                {
                                    ModuleId = Module["metermoduleId"].ToString();
                                    break;
                                }
                            }
                        }
                        else
                            throw new WapException(StateCode.CODE_ARGUMENT_NULL, "获取水表型号失败");
                    }
                    else
                        throw new WapException(StateCode.CODE_ARGUMENT_NULL, "获取水表产家失败");

                    try
                    {
                        MeterInfoOut meterInfoOut = new MeterInfoOut
                        {
                            meterCode = meterOut.meterCode,
                            meterDiameterId = meterOut.meterDiameterId,
                            factoryName = meterOut.factoryName,
                            factoryId = FactoryId,
                            meterTypeId = meterOut.meterTypeId,
                            meterModuleCode = meterOut.meterModuleCode,
                            meterModuleId = ModuleId,
                            sealCode = meterOut.sealCode,
                            deptId = deptId.ToString()

                        };
                        Meter meter = new Meter
                        {
                            meterCode = meterOut.meterCode,
                            meterDiameterId = int.Parse(meterOut.meterDiameterId),
                            factoryId = int.Parse(FactoryId),
                            meterTypeId = int.Parse(meterOut.meterTypeId),
                            meterModuleId = int.Parse(ModuleId),
                            sealCode = meterOut.sealCode,
                            deptId = deptId
                        };
                        string data = JsonConvert.SerializeObject(meter);
                        HttpConfig httpConfig = new HttpConfig
                        {
                            ContentType = "application/json"
                        };
                        var wapNewMeterUrl = url + "fieldWork/newWaterMeter";
                        var wapNewMeterResponsText = HttpHelper.SendPost(wapNewMeterUrl, data, httpConfig);
                        JObject wapNewMeterRespons = JObject.Parse(wapNewMeterResponsText);
                        if (int.Parse(wapNewMeterRespons["result"].ToString()) != 1)
                        {
                            throw new WapException(StateCode.CODE_ARGUMENT_NULL, "新建水表失败");
                        }
                        else
                            return new WapOutgoingResponse<MeterInfoOut>(meterInfoOut);
                    }
                    catch (Exception ex)
                    {
                        LogManager.Get().Error(ex.ToString());
                        throw new WapException(StateCode.CODE_ARGUMENT_NULL, "新建水表失败");
                    }
                }
            }
            else
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "获取所属部门失败");
            
        }
        #endregion

        public class Meter
        {
            public string meterCode;
            public int meterDiameterId;
            public int factoryId;
            public int meterTypeId;
            public int meterModuleId;
            public string sealCode;
            public int deptId;
        }
    }
}