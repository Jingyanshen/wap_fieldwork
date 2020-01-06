using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dispatcher;

namespace FieldWork.Outgoing.WebApi
{
    public class UnityHttpControllerTypeResolver : IHttpControllerTypeResolver
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="container">Unity容器对象实例</param>
        public UnityHttpControllerTypeResolver(IUnityContainer container)
        {
            this.container = container;
        }


        private IUnityContainer container;

        /// <summary>
        /// 返回Unity容器中注册的控制器类型
        /// </summary>
        /// <param name="assembliesResolver"></param>
        /// <returns></returns>
        public ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver)
        {
            List<Type> types = new List<Type>();
            if (container != null)
            {
                foreach (var reg in container.Registrations)
                {
                    if (!types.Contains(reg.RegisteredType))
                        types.Add(reg.RegisteredType);

                    if (!types.Contains(reg.MappedToType))
                        types.Add(reg.MappedToType);
                }
            }
            return types;
        }
    }
}