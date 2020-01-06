using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model.Common
{
    public class OutgoingConsts
    {
        /// <summary>
        /// 服务地址
        /// </summary>
        public static string PlatPath { get; set; }

        /// <summary>
        /// 获取平台人员
        /// </summary>
        public static string WapUserInfoByUId { get; set; }

        /// <summary>
        /// 获取平台组织
        /// </summary>
        public static string WapUserInfoByOrgId { get; set; }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        public static string WapUserAll { get; set; }

        /// <summary>
        /// 巡查人角色key
        /// </summary>
        public static string PatrolstaffRoleId { get; set; }

        /// <summary>
        /// 驾驶员角色key
        /// </summary>
        public static string PatrolDiverRoleId { get; set; }


        static OutgoingConsts()
        {
            try
            {
                PlatPath = TryGet<string>("WAP_PLAT_PATH");
                WapUserInfoByUId = TryGet<string>("WAP_GET_USER_BY_ID");
                WapUserInfoByOrgId = TryGet<string>("WAP_GET_USERS_BY_ORGID");
                WapUserAll = TryGet<string>("WAP_GET_USER_ALL");
                PatrolstaffRoleId = TryGet<string>("WAP_PATROLSTAFF_ROLE");
                PatrolDiverRoleId = TryGet<string>("WAP_DRIVER_ROLE");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="configName"></param>
        /// <returns></returns>
        private static T1 TryGet<T1>(string configName, T1 defaultValue = default(T1))
        {
            string config = System.Configuration.ConfigurationManager.AppSettings[configName];
            if (string.IsNullOrEmpty(config))
            {
                return defaultValue;
            }

            var obj = Convert.ChangeType(config, typeof(T1));

            if (obj == null)
            {
                return defaultValue;
            }
            return (T1)obj;
        }
    }
}
