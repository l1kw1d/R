//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RawCMS.Library.Core.Helpers
{
    public class ReflectionManager
    {
        private static ILogger _logger = ApplicationLogger.CreateLogger<ReflectionManager>();

        public List<Assembly> AssemblyScope { get; set; } = new List<Assembly>();

        public ReflectionManager(List<Assembly> assemblies)
        {
            _logger.LogInformation("Creating reflectionManager");
            foreach (Assembly ass in assemblies)
            {
                if (!AssemblyScope.Any(x => x.FullName == ass.FullName))
                {
                    //_logger.LogInformation($" > Added {ass.FullName}");
                    AssemblyScope.Add(ass);
                }
            }
        }

        public void AppendAssembliesToScope(List<Assembly> assemblies)
        {
            foreach (var ass in assemblies)
            {
                AppendAssemblyToScope(ass);
            }
        }

        public void AppendAssemblyToScope(Assembly assembly)
        {
            if (!AssemblyScope.Contains(assembly))
            {
                AssemblyScope.Add(assembly);
            }
        }

        public List<Assembly> GetAssemblyWithInstance<T>()
        {
            _logger.LogDebug("Get all assembly with instance");

            List<Assembly> result = new List<Assembly>();
            Assembly[] assList = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ass in assList)
            {
                List<Type> implementors = GetImplementors(typeof(T), new List<Assembly>() { ass });
                if (implementors.Count > 0)
                {
                    result.Add(ass);
                }
            }
            return result;
        }

        public T GetInstance<T>(params object[] args) where T : class
        {
            return Activator.CreateInstance(typeof(T), args) as T;
        }

        public T GetInstance<T>(Type type, params object[] args) where T : class
        {
            return Activator.CreateInstance(type, args) as T;
        }

        public List<Type> GetAnnotatedBy<T>() where T : Attribute
        {
            _logger.LogDebug("Get all entries annotated by {0}", typeof(T).FullName);
            List<Type> result = new List<Type>();
            List<Assembly> bundledAssemblies = AssemblyScope;

            foreach (Assembly assembly in bundledAssemblies)
            {
                _logger.LogDebug("loading from" + assembly.FullName);

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (type.GetCustomAttributes(typeof(T), true).Length > 0)
                    {
                        result.Add(type);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Get  instances of all classes assignable from T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetAssignablesInstances<T>() where T : class
        {
            List<Type> types = GetImplementors<T>();
            return GetInstancesFromTypes<T>(types);
        }

        /// <summary>
        /// Get instanced of all classes annotated by T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetAnnotatedInstances<T>() where T : class
        {
            List<Type> types = GetImplementors<T>();
            return GetInstancesFromTypes<T>(types);
        }

        /// <summary>
        /// Get all types that implements T or inherit it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<Type> GetImplementors<T>() where T : class
        {
            return GetImplementors(typeof(T), AssemblyScope);
        }

        /// <summary>
        /// Get all types that implements T or inherit it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<Type> GetImplementors(Type type)
        {
            return GetImplementors(type, AssemblyScope);
        }

        /// <summary>
        /// give instances of a list of types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="types"></param>
        /// <returns></returns>
        public List<T> GetInstancesFromTypes<T>(List<Type> types) where T : class
        {
            List<T> result = new List<T>();

            types.ForEach(x =>
            {
                result.Add(GetInstance<T>(x));
            });

            return result;
        }

        public List<Type> GetImplementors(Type t, List<Assembly> bundledAssemblies)
        {
            _logger.LogDebug("Get implementors for {0} in {1}", t,
                string.Join(",", bundledAssemblies.Select(x => x.FullName).ToArray()));

            List<Type> result = new List<Type>();

            foreach (Assembly assembly in bundledAssemblies)
            {
                // _logger.LogDebug("loading from" + assembly.FullName);
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    try
                    {
                        if ((t.IsAssignableFrom(type) || (type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == t)))
                            && !type.IsAbstract && !type.IsInterface && !type.IsGenericType)
                        {
                            result.Add(type);
                        }
                    }
                    catch (Exception err)
                    {
                        _logger.LogError(err, "- (unable to create an instance for EXCEPTION skipped) - " + type.Name + " | " + type.GetType().FullName);
                    }
                }
            }
            return result;
        }
    }
}