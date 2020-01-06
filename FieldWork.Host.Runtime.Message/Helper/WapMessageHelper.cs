
using SH3H.SDK.WebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Helper
{
    public class WapMessageHelper
    {
        /// <summary>
        /// 私有域名字段
        /// </summary>
        private string domain = "";

        /// <summary>
        /// 接口的域名
        /// </summary>
        public string Domain
        {
            get
            {
                if (!domain.StartsWith("http"))
                {
                    domain = "http://" + domain;
                }
                if (!domain.EndsWith("/"))
                {
                    domain = domain + "/";
                }
                return domain;
            }
            set
            {
                if (!domain.StartsWith("http"))
                {
                    domain = "http://" + value;
                }
                if (!domain.EndsWith("/"))
                {
                    domain = value + "/";
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public WapMessageHelper()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domain">接口的域名</param>
        public WapMessageHelper(string domain)
        {
            this.domain = domain;
        }

        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="messageDto">消息DTO</param>
        /// <returns></returns>
        public WapResponse<SendMessageOutDto> SendMessage(SendMessageInDto messageDto)
        {
            try
            {
                var result = ServiceHelper.Post<SendMessageInDto, WapResponse<SendMessageOutDto>>(this.Domain + Const.MessageUrl, messageDto);
                return result;
            }
            catch
            {
                throw new Exception("消息推送失败");
            }
        }

        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="messageDto">消息DTO</param>
        /// <returns></returns>
        public WapResponse<SendMessageOutDto> SendTemplateMessage(SendTemplateMessageInDto messageDto)
        {
            try
            {
                var result = ServiceHelper.Post<SendTemplateMessageInDto, WapResponse<SendMessageOutDto>>(this.Domain + Const.TemplateMessageUrl, messageDto);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("模板消息推送失败" + this.Domain + Const.TemplateMessageUrl + ex.Message + "" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 发送SignalR（Web网页）消息
        /// </summary>
        /// <param name="webMessageDto">SignalR消息DTO</param>
        /// <returns></returns>
        public WapResponse<SendSignalRMessageOutDto> SendWebMessage(SendSignalRMessageInDto webMessageDto)
        {
            try
            {
                var result = ServiceHelper.Post<SendSignalRMessageInDto, WapResponse<SendSignalRMessageOutDto>>(this.Domain + Const.SignalRMessageUrl, webMessageDto);
                return result;
            }
            catch
            {
                throw new Exception("SignalR消息推送失败");
            }
        }

        /// <summary>
        /// 发送App（手机客户端）消息
        /// </summary>
        /// <param name="appMessageDto">App消息DTO</param>
        /// <returns></returns>
        public WapResponse<SendRabbitMqMessageOutDto> SendAppMessage(SendRabbitMqMessageInDto appMessageDto)
        {
            try
            {
                var result = ServiceHelper.Post<SendRabbitMqMessageInDto, WapResponse<SendRabbitMqMessageOutDto>>(this.Domain + Const.RabbitMqMessageUrl, appMessageDto);
                return result;
            }
            catch
            {
                throw new Exception("RabbitMq消息推送失败");
            }
        }

        /// <summary>
        /// 发送Sms（手机短信）消息
        /// </summary>
        /// <param name="smsMessageDto">App消息DTO</param>
        /// <returns></returns>
        public WapResponse<SendSmsMessageOutDto> SendSmsMessage(SendSmsMessageInDto smsMessageDto)
        {
            try
            {
                var result = ServiceHelper.Post<SendSmsMessageInDto, WapResponse<SendSmsMessageOutDto>>(this.Domain + Const.SmsMessageUrl, smsMessageDto);
                return result;
            }
            catch
            {
                throw new Exception("Sms消息推送失败");
            }
        }

        /// <summary>
        /// 发送Email（邮件）消息
        /// </summary>
        /// <param name="emailMessageDto">Email消息DTO</param>
        /// <returns></returns>
        public WapResponse<SendEmailMessageOutDto> SendEmailMessage(SendEmailMessageInDto emailMessageDto)
        {
            try
            {
                var result = ServiceHelper.Post<SendEmailMessageInDto, WapResponse<SendEmailMessageOutDto>>(this.Domain + Const.EmailMessageUrl, emailMessageDto);
                return result;
            }
            catch
            {
                throw new Exception("Email消息推送失败");
            }
        }
    }
}
