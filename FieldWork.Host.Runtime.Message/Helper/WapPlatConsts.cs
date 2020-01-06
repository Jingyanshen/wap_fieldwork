using SH3H.SDK.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Helper
{
    public static class WapPlatConsts
    {
        //发送模板消息
        public static string SendMessage = "wap/push/v1/message";
        public static string SendTemplateMessage = "wap/push/v1/templatemessage";


        public static string NotificationDomain { get; set; }
        public static string NotificationMethod { get; set; }
        public static string PlanningTime { get; set; }
        public static string NotificationRetryTimes { get; set; }
        public static string NotificationRetryInterval { get; set; }
        public static string NotificationTaskMessageType { get; set; }

        public static string NotificationTaskToUserType { get; set; }
        public static string NotificationMobileType { get; set; }

        /// <summary>
        /// 消息来源ID
        /// </summary>
        public static string NotificationFromPointId { get; set; }


        static WapPlatConsts()
        {
            try
            {
                var _WAP_MESSAGE_SEND = TryGet<string>("WAP_MESSAGE_SEND");
                var _WAP_MESSAGE_SEND_TEMPLATE = TryGet<string>("WAP_MESSAGE_SEND_TEMPLATE");

                if (!string.IsNullOrEmpty(_WAP_MESSAGE_SEND))
                {
                    SendMessage = _WAP_MESSAGE_SEND;
                }
                if (!string.IsNullOrEmpty(_WAP_MESSAGE_SEND_TEMPLATE))
                {
                    SendTemplateMessage = _WAP_MESSAGE_SEND_TEMPLATE;
                }

                //这里是通用配置
                NotificationDomain = TryGet<string>("WAP_MESSAGE_NOTIFICATION_DOMAIN");
                NotificationMethod = TryGet<string>("WAP_MESSAGE_NOTIFICATION_METHOD");
                PlanningTime = TryGet<string>("WAP_MESSAGE_NOTIFICATION_PLANNING_TIME");
                NotificationRetryTimes = TryGet<string>("WAP_MESSAGE_NOTIFICATION_RETRY_TIMES");
                NotificationRetryInterval = TryGet<string>("WAP_MESSAGE_NOTIFICATION_RETRY_INTERVAL");

                NotificationMobileType = TryGet<string>("WAP_MESSAGE_SUMMARY_MOBILE_TYPE");
                

                //消息类型标识
                NotificationTaskMessageType = TryGet<string>("WAP_MESSAGE_NOTIFICATION_TASK_MESSAGETYPE");
                //可发送给用户的哪些应用
                NotificationTaskToUserType = TryGet<string>("WAP_MESSAGE_NOTIFICATION_TASK_TO_USER_TYPE");
                //消息发送来源标识
                NotificationFromPointId = TryGet<string>("WAP_MESSAGE_NOTIFICATION_FROM_POINTID");


            }
            catch (Exception ex)
            {
                LogManager.Get().Throw(ex);
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
