using System;
using System.Collections.Generic;
using System.Reflection;

namespace AttendanceTools
{
    public static class Extensions
    {
        private static Dictionary<Type, MethodInfo> methodsCache = new Dictionary<Type, MethodInfo>();

        public static T ConvertTo<T>(this string value) 
            where T : struct
        {
            var type = typeof(T);

            if (!methodsCache.ContainsKey(type))
                methodsCache[type] = type.GetMethod("TryParse", new Type[] { typeof(string), type.MakeByRefType() });

            var method = methodsCache[type];
            var parameters = new object[] { value, default(T) };

            if (!(bool)method.Invoke(null, parameters))
                return default(T);

            return (T)parameters[1];

        }

        public static bool In(this string value, params string[] collection)
        {
            foreach (var item in collection)
                if (value.Equals(item)) return true;
            return false;
        }

    
    }
}
