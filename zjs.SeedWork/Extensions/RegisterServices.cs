using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using zjs.SeedWork.Attributes;
using zjs.SeedWork.Enum;

namespace zjs.SeedWork.Extensions
{
    public static class RegisterServices
    {
        public static void AddRegisterServices(this IServiceCollection services)
        {
            var dic = GetRegisterDic();

            //默认创建 Scoped.
            foreach (var @class in dic.Keys)
            {
                var registerType = @class.GetCustomAttribute<RegisterType>();
                if (registerType == null)
                {
                    services.AddScoped(dic[@class], @class);
                }
                else
                {
                    switch (registerType.Type)
                    {
                        case RegisterTypeEnum.Singleton:
                            services.AddSingleton(dic[@class], @class);
                            break;
                        case RegisterTypeEnum.Scoped:
                            services.AddScoped(dic[@class], @class);
                            break;
                        case RegisterTypeEnum.Transient:
                            services.AddTransient(dic[@class], @class);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 根据assemblyName 创建相应注册信息
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static Dictionary<Type, Type> GetRegisterDic(string assemblyName = "")
        {
            IEnumerable<KeyValuePair<Type, Type>> dics = new Dictionary<Type, Type>();

            var assemblies = GetAssemblies();

            foreach (var assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();

                //增加Entity注册
                dics = dics.Concat(GetEntityDic(types));

                //增加Repository注册
                dics = dics.Concat(GetRepositoryDic(types));

                //增加AppService注册
                dics = dics.Concat(GetAppServiceDic(types));
            }

            var result = dics.ToDictionary(k => k.Key, v => v.Value);
            return result;
        }

        /// <summary>
        /// 获取装配dll
        /// </summary>
        /// <returns></returns>
        private static Assembly[] GetAssemblies(string assemblyName = "")
        {
            var assemblies = new List<Assembly>();
            //IEnumerable<RuntimeLibrary> dependencies;
            if (string.IsNullOrWhiteSpace(assemblyName))
            {
                var dependencies = DependencyContext.Default.RuntimeLibraries.Where(d => d.Name.EndsWith("Module", StringComparison.OrdinalIgnoreCase)
                                || d.Name.EndsWith("Application", StringComparison.OrdinalIgnoreCase));
                foreach (var library in dependencies)
                {
                    assemblies.Add(Assembly.Load(library.Name));
                }
            }
            else
            {
                assemblies.Add(Assembly.Load(assemblyName));
            }

            return assemblies.ToArray();
        }


        /// <summary>
        /// 创建Entity注册词典
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        private static Dictionary<Type, Type> GetEntityDic(IEnumerable<Type> types)
        {
            Dictionary<Type, Type> dic = new Dictionary<Type, Type>();

            //获取仓库类
            var repository = types.Where(x => x.Name.Split('`')[0] == "Repository").FirstOrDefault();
            var interfaceType = repository?.GetInterfaces().Where(x => x.Name.EndsWith(repository.Name)).FirstOrDefault();
            //如果未找到,则不进行创建
            if (repository == null || interfaceType == null)
                return dic;

            //获取所有 Entity 类
            var entities = types.Where(x => x.BaseType != null && x.BaseType.Name == "Entity");

            //创建词典
            foreach (var entity in entities)
            {
                var repo = repository.MakeGenericType(entity);
                var irepo = interfaceType.GetGenericTypeDefinition().MakeGenericType(entity);

                dic[repo] = irepo;
            }

            return dic;
        }

        /// <summary>
        /// 创建个性化Repository注册词典
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        private static Dictionary<Type, Type> GetRepositoryDic(IEnumerable<Type> types)
        {
            //获取 个性化需要的 Repository 类
            var repositories = types.Where(x => !x.IsInterface && x.Name != "Repository" && x.Name.EndsWith("Repository"));

            return GetTypeDic(repositories);
        }

        /// <summary>
        /// 创建个性化AppService注册词典
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        private static Dictionary<Type, Type> GetAppServiceDic(IEnumerable<Type> types)
        {
            ////获取 AppService 对应的类
            var appServices = types.Where(x => !x.IsInterface && x.Name.EndsWith("AppService"));

            return GetTypeDic(appServices);
        }

        /// <summary>
        /// 创建注册词典
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        private static Dictionary<Type, Type> GetTypeDic(IEnumerable<Type> types)
        {
            Dictionary<Type, Type> dic = new Dictionary<Type, Type>();

            foreach (var item in types)
            {
                var interfaceType = item.GetInterfaces().Where(x => x.Name.EndsWith(item.Name)).FirstOrDefault();
                if (interfaceType != null)
                {
                    dic.Add(item, interfaceType);
                }
            }

            return dic;
        }
    }
}
