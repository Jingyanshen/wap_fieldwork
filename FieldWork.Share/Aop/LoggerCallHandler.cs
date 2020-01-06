using Microsoft.Practices.Unity.InterceptionExtension;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SH3H.SDK.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SH3H.WAP.FieldWork.Share.Aop
{
    /// <summary>
    /// 日志记录管道
    /// </summary>
    public class LoggerCallHandler : ICallHandler
    {

        private static List<string> _ignoreList;

        private static string _inputTemple = "ServiceName: {0}\r\nActionName: {1}\r\nParams: {2}";
        private static string _outputTemple = "ServiceName: {0}\r\nActionName: {1}\r\nResult: {2}";

        private static JsonSerializerSettings _setting ;


        static LoggerCallHandler()
        {
            InitSetting();
            InitIgnore();
        }


        /// <summary>
        /// 管道拦截处理
        /// </summary>
        /// <param name="input">入参拦截</param>
        /// <param name="getNext">执行的下一个管道</param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {


            LogBegin(input);

            IMethodReturn result = getNext()(input, getNext);

            LogEnd(result, input);

            return result;
        }

        /// <summary>
        /// 记录调用开始
        /// </summary>
        /// <param name="input"></param>
        private void LogBegin(IMethodInvocation input)
        {
            MethodBase method = input.MethodBase;
            Type type = method.ReflectedType;
            var args = input.Arguments;

            if (IsIgnore(method, type))
            {
                return;
            }

            string serviceName = "";
            string actionName = "";

            //拼接需要记录的参数
            ParameterInfo[] paramInfos = method.GetParameters();
            StringBuilder sb = new StringBuilder();

            actionName = method.Name;
            serviceName = type.Name;
            int pcount = paramInfos.Length;

            for (int i = 0; i < pcount; i++)
            {
                var paramInfo = paramInfos[i];

                sb.Append(paramInfo.Name).Append("=");

                if (input.Inputs != null && input.Inputs.Count > i)
                {
                    sb.Append(GetValue(input.Inputs[i]));
                }
                else
                {
                    sb.Append("null");
                }

                sb.Append(',');
            }


            if (sb.Length > 0 && sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }

            //组装消息
            string info = string.Format(_inputTemple, serviceName, actionName, sb.ToString());

            //记录消息
            LogManager.Get().Trace(info);
        }

        /// <summary>
        /// 记录调用结果
        /// </summary>
        /// <param name="result"></param>
        /// <param name="input"></param>
        private void LogEnd(IMethodReturn result, IMethodInvocation input)
        {
            if (result.Exception != null)
            {
                return;
            }

            MethodBase method = input.MethodBase;
            Type type = method.ReflectedType;
            var args = input.Arguments;

            if (IsIgnore(method, type))
            {
                return;
            }

            string serviceName = "";
            string actionName = "";

            //拼接需要记录的参数
            ParameterInfo[] paramInfos = method.GetParameters();
            StringBuilder sb = new StringBuilder();

            actionName = method.Name;
            serviceName = type.Name;
            int pcount = paramInfos.Length;


            if (result.ReturnValue == null)
            {
                sb.Append("null");
            }
            else
            {
                sb.Append(GetValue(result.ReturnValue));
            }

            //组装消息
            string info = string.Format(_outputTemple, serviceName, actionName, sb.ToString());

            //记录消息
            LogManager.Get().Trace(info);
        }

        public int Order { get; set; }

        /// <summary>
        /// 过滤列表
        /// </summary>
        /// <param name="method"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool IsIgnore(MethodBase method, Type type)
        {
            return method != null && _ignoreList.Contains(method.Name);
        }

        private static void InitIgnore()
        {
            _ignoreList = new List<string>();

            string ignoreStr = Consts.LOG_METHOD_NAME_IGNORE;

            if (!string.IsNullOrWhiteSpace(ignoreStr))
            {
                _ignoreList.AddRange(ignoreStr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            }
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        private static void InitSetting()
        {
            _setting = new JsonSerializerSettings();
            _setting.Error = delegate(object sender, ErrorEventArgs args)
            {
                args.ErrorContext.Handled = true;
            };
        }


        /// <summary>
        /// 获取复杂对象表述形式
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static string GetValue(object p)
        {
            if (p == null)
            {
                return null;
            }

            var type = p.GetType();
            if (type.IsValueType || type == typeof(string))
            {
                return p.ToString();
            }

            return JsonConvert.SerializeObject(p, _setting);
        }
    }
}
