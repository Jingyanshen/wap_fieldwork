using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Helper
{
    /// <summary>
    /// 服务调用封装类
    /// </summary>
    public class ServiceHelper
    {
        /// <summary>
        /// Get调用 
        /// </summary>
        /// <typeparam name="TInput">输入参数类型</typeparam>
        /// <typeparam name="TOutput">输出参数类型</typeparam>
        /// <param name="url">调用地址</param>
        /// <param name="obj">输入参数</param>
        /// <returns></returns>
        public static TOutput Get<TInput, TOutput>(string url, TInput obj)
            where TInput : class
            where TOutput : class
        {
            string data = "";
            if (obj != null)
            {
                data = JsonConvert.SerializeObject(obj);
            }
            string josn = HttpHelper.SendGet(url);
            TOutput result = JsonConvert.DeserializeObject<TOutput>(josn);

            return result;
        }

        /// <summary>
        /// Get调用 返回列表
        /// </summary>
        /// <typeparam name="TInput">输入参数类型</typeparam>
        /// <typeparam name="TOutput">输出列表中参数类型</typeparam>
        /// <param name="url">调用地址</param>
        /// <param name="obj">输入参数</param>
        /// <returns></returns>
        public static List<TOutput> GetList<TInput, TOutput>(string url, TInput obj)
            where TInput : class
            where TOutput : class
        {
            string data = null;
            if (obj != null)
            {
                data = JsonConvert.SerializeObject(obj);
            }
            string josn = HttpHelper.Send(url, "Get", data, null);
            List<TOutput> result = JsonConvert.DeserializeObject<List<TOutput>>(josn);
            return result;
        }

        /// <summary>
        /// Post调用
        /// </summary>
        /// <typeparam name="TInput">输入参数类型</typeparam>
        /// <typeparam name="TOutput">输出参数类型</typeparam>
        /// <param name="url">调用地址</param>
        /// <param name="obj">输入参数</param>
        /// <returns></returns>
        public static TOutput Post<TInput, TOutput>(string url, TInput obj)
        {
            string data = null;
            if (obj != null)
            {
                data = JsonConvert.SerializeObject(obj);
            }
            HttpConfig config = new HttpConfig() { ContentType = "application/json; charset=utf-8" };

            string josn = HttpHelper.Send(url, "Post", data, config);
            TOutput result = JsonConvert.DeserializeObject<TOutput>(josn);
            return result;
        }

        /// <summary>
        /// Delete调用
        /// </summary>
        /// <typeparam name="TInput">输入参数类型</typeparam>
        /// <typeparam name="TOutput">输出参数类型</typeparam>
        /// <param name="url">调用地址</param>
        /// <param name="obj">输入参数</param>
        /// <returns></returns>
        public static TOutput Delete<TInput, TOutput>(string url, TInput obj)
        {
            string data = null;
            if (obj != null)
            {
                data = JsonConvert.SerializeObject(obj);
            }
            HttpConfig config = new HttpConfig() { ContentType = "application/json; charset=utf-8" };

            string josn = HttpHelper.Send(url, "Delete", data, config);
            TOutput result = JsonConvert.DeserializeObject<TOutput>(josn);
            return result;
        }

        /// <summary>
        /// Put调用
        /// </summary>
        /// <typeparam name="TInput">输入参数类型</typeparam>
        /// <typeparam name="TOutput">输出参数类型</typeparam>
        /// <param name="url">调用地址</param>
        /// <param name="obj">输入参数</param>
        /// <returns></returns>
        public static TOutput Put<TInput, TOutput>(string url, TInput obj)
        {
            string data = null;
            if (obj != null)
            {
                data = JsonConvert.SerializeObject(obj);
            }
            HttpConfig config = new HttpConfig() { ContentType = "application/json; charset=utf-8" };

            string josn = HttpHelper.Send(url, "Put", data, config);
            TOutput result = JsonConvert.DeserializeObject<TOutput>(josn);
            return result;
        }

    }
}
