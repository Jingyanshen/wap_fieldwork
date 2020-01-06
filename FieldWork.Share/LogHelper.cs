using Newtonsoft.Json;
using SH3H.SDK.Infrastructure.Logging;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace SH3H.WAP.FieldWork.Share
{
    public class ServiceLogHelper
    {

        private static string input = "ServiceName: {0}\r\nActionName: {1}\r\nParams: {2}";
        private static string output = "ServiceName: {0}\r\nActionName: {1}\r\nResult: {2}";

        /// <summary>
        /// 记录调用日志
        /// </summary>
        /// <param name="paraArry"></param>
        public static void LogServiceBegin(params object[] paraArry)
        {
            LogServiceInfo(input, true, paraArry);
        }

        /// <summary>
        /// 记录反馈日志
        /// </summary>
        /// <param name="paraArry"></param>
        public static void LogServiceEnd(params object[] paraArry)
        {
            LogServiceInfo(output, false, paraArry);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="temple"></param>
        /// <param name="isIn"></param>
        /// <param name="paraArry"></param>
        public static void LogServiceInfo(string temple, bool isIn, params object[] paraArry)
        {
            string serviceName = "";
            string actionName = "";

            StackTrace stackTrace = new StackTrace();
            if (stackTrace.FrameCount == 0)
            {
                return;
            }

            //获取方法名及其所属类
            StackFrame lastStackFrame = null;
            MethodBase method = null;
            Type type = null;

            //获取所有堆栈
            StackFrame[] frames = stackTrace.GetFrames();

            if (frames == null)
            {
                return;
            }

            //按照堆栈排序(后入在前)遍历获取最后调用记录方法的方法 及其所在类
            foreach (var item in frames)
            {
                method = item.GetMethod();
                type = method.ReflectedType;
                if (type == typeof(ServiceLogHelper))
                {
                    continue;
                }
                lastStackFrame = item;
                break;
            }
            if (lastStackFrame == null)
            {
                //未能找到可以记录的类
                return;
            }

            //拼接需要记录的参数
            ParameterInfo[] paramInfos = method.GetParameters();
            StringBuilder sb = new StringBuilder();

            actionName = method.Name;
            serviceName = type.Name;
            int pcount = paramInfos.Length;

            if (isIn)
            {
                for (int i = 0; i < pcount; i++)
                {
                    var paramInfo = paramInfos[i];

                    sb.Append(paramInfo.Name).Append("=");

                    if (paraArry != null && paraArry.Length > i)
                    {
                        sb.Append(GetValue(paraArry[i]));
                    }
                    else
                    {
                        sb.Append("null");
                    }

                    sb.Append(',');
                }
            }
            else if (paraArry.Length > 0)
            {
                foreach (var item in paraArry)
                {
                    if (item == null)
                    {
                        sb.Append("null").Append(",");
                    }
                    else
                    {
                        sb.Append(GetValue(item)).Append(",");
                    }
                }
            }

            if (sb.Length > 0 && sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }

            //组装消息
            string info = string.Format(temple, serviceName, actionName, sb.ToString());

            //记录消息
            LogManager.Get().Trace(info);
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

            return JsonConvert.SerializeObject(p);
        }
    }
}
