using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Helper
{
    /// <summary>
    /// 消息服务接口的相对路径
    /// </summary>
    public class Const
    {
        //发送模板消息
        public static string MessageUrl = "wap/push/v1/message";
        public static string TemplateMessageUrl = "wap/push/v1/templatemessage";

        public static string SignalRMessageUrl = "wap/web_push/v1/message";
        public static string RabbitMqMessageUrl = "wap/app_push/v1/message";
        public static string SmsMessageUrl = "wap/sms_push/v1/message";
        public static string EmailMessageUrl = "wap/email_push/v1/message";



    }
}
