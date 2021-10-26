using System;
using System.Reflection;
using System.Text;
using Serilog;

namespace ModularRestaurant.Shared.Api
{
    public static class AssemblyProvider
    {
        public static Assembly GetInfrastructure(this Assembly assembly)
            => GetAssembly(assembly, "Infrastructure");
        
        public static Assembly GetApplication(this Assembly assembly)
            => GetAssembly(assembly, "Application");
        
        public static Assembly GetDomain(this Assembly assembly)
            => GetAssembly(assembly, "Domain");
        
        private static Assembly GetAssembly(Assembly assembly, string layerName)
        {
            try
            {
                var stringBuilder = new StringBuilder();

                var dotIndex = assembly.GetName().Name!.LastIndexOf(".", StringComparison.Ordinal);

                var assemblyName = stringBuilder.Append(assembly.GetName().Name)
                                                .RemoveToEnd(dotIndex + 1)
                                                .Append(layerName)
                                                .ToString();

                return Assembly.Load(assemblyName);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
                throw;
            }
        }

        private static StringBuilder RemoveToEnd(this StringBuilder stringBuilder, int index)
            => stringBuilder.Remove(index, stringBuilder.Length - index);
    }
}