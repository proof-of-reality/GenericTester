using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Tester
{
    public static class Tester
    {
        public static object Test()
        {
            var snapshot = new Dictionary<string, object>();
            try
            {
                var assembly = Assembly.LoadFile(@"C:\Users\noctavel\source\repos\App\API\bin\Debug\netcoreapp2.2\API.dll");
                var types = assembly.GetTypes().Where(x => x.Name.EndsWith("Controller"));
                foreach (var @class in types)
                {
                    var controller = Activator.CreateInstance(@class);
                    var methods = controller.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    foreach (var method in methods)
                    {
                        var parameters = method.GetParameters();

                        var @params = parameters.Select(param =>
                        {
                            var stringType = typeof(string);
                            if (param.ParameterType == stringType) return "teste";
                            else if (param.ParameterType == typeof(int)) return 1;
                            else if (param.ParameterType.IsArray)
                            {
                                var typeofElement = param.ParameterType.GetElementType();
                                var returnObject = new[] { 1, 2, 31218 };
                                if (typeofElement == stringType) return returnObject.Select(x => x.ToString()).ToArray();
                                return returnObject;
                            }
                            else if (param.ParameterType.IsClass)
                                return Activator.CreateInstance(param.ParameterType);

                            return new object();
                        }).ToArray();
                        var methodInfo = @class.Name + "." + method.Name + "(" + string.Join(",", parameters.Select(x => x.ParameterType + " " + x.Name)) + ")";
                        var result = method.Invoke(controller, @params);
                        snapshot.Add(methodInfo, result);
                    }
                }
                return snapshot;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
