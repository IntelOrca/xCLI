using System;
using System.Reflection;

namespace xCLI.Extensions
{
    public static class TypeExtensions
    {
        public static bool TryGetAttribute<T>(this Type type, out T attribute) where T : Attribute
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            attribute = typeInfo.GetCustomAttribute<T>();
            return attribute != null;
        }
    }
}
