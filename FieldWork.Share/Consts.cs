using SDKConsts = SH3H.SDK.Share.Consts;

namespace SH3H.WAP.FieldWork.Share
{
    /// <summary>
    /// 定义敏捷平台基础配置系统常量
    /// </summary>
    public static class Consts
    {
        /// <summary>
        /// 定义RESTful服务WAP地址前缀
        /// </summary>
        public const string URL_PREFIX_WAP = SDKConsts.APP_NAME + "/fw/v1";


        #region 缓存相关

        /// <summary>
        /// 应用缓存key
        /// </summary>
        public const string URL_PREFIX_WAP_APP = "urn:wap:app";
        

        #endregion

        #region 日志相关
        /// <summary>
        /// 不记录日志方法名列表
        /// </summary>
        public const string LOG_METHOD_NAME_IGNORE = "GetUserByToken,AddAudit,TokenValid,Ping";

        #endregion
    }
}
