using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UmbraMenu
{
    // shalzuth/RiskOfShame/Reflection.cs
    public static class Reflections
    {
        public static BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                                           BindingFlags.Static | BindingFlags.FlattenHierarchy;
        public static ConcurrentDictionary<String, FieldInfo> fields = new ConcurrentDictionary<String, FieldInfo>();
        public static FieldInfo GetFieldFast(this Type type, String fieldName, String fieldType, String baseType)
        {
            var key = type.FullName + "." + fieldName + "(" + fieldType + ")" + " " + baseType;
            if (fields.ContainsKey(key)) return fields[key];
            var field = type.GetField(fieldName, flags);
            if (!field.FieldType.Name.Contains(fieldType) || !field.DeclaringType.Name.Contains(baseType))
                field = type.GetFields(flags).FirstOrDefault(f => f.Name == fieldName
                                            && f.FieldType.ToString().Contains(fieldType)
                                            && f.DeclaringType.ToString().Contains(baseType));
            if (field != null) fields[key] = field;
            return field;
        }
        public static ConcurrentDictionary<String, PropertyInfo> properties = new ConcurrentDictionary<String, PropertyInfo>();
        public static PropertyInfo GetPropertyFast(this Type type, String propertyName, String propretyType, String baseType)
        {
            var key = type.FullName + "." + propertyName + "(" + propretyType + ")" + " " + baseType;
            if (properties.ContainsKey(key)) return properties[key];
            var property = type.GetProperty(propertyName, flags);
            if (!property.PropertyType.Name.Contains(propretyType) || !property.DeclaringType.Name.Contains(baseType))
                property = type.GetProperties(flags).FirstOrDefault(p => p.Name == propertyName
                                            && p.PropertyType.ToString().Contains(propretyType)
                                            && p.DeclaringType.ToString().Contains(baseType));
            if (property != null) properties[key] = property;
            return property;
        }
        public static Object GetField(this Object obj, String fieldName, String fieldType, String baseType)
        {
            if (obj == null) return null;
            var objType = obj is Type ? (Type)obj : obj.GetType();
            var field = objType.GetFieldFast(fieldName, fieldType, baseType);
            if (field != null) return obj is Type ? field.GetValue(null) : field.GetValue(obj);
            var property = objType.GetPropertyFast(fieldName, fieldType, baseType);
            if (property != null) return obj is Type ? property.GetValue(null) : property.GetValue(obj);
            return null;
        }
        public static T GetField<T>(this Object obj, String fieldName, String fieldType = "", String baseType = "")
        {
            if (String.IsNullOrEmpty(fieldType)) fieldType = typeof(T).Name;
            if (String.IsNullOrEmpty(baseType)) baseType = obj is Type ? ((Type)obj).Name : obj.GetType().Name;
            return (T)GetField(obj, fieldName, fieldType, baseType);
        }
        public static void SetField<T>(this Object obj, String fieldName, String fieldType, String baseType, T val)
        {
            if (obj == null) return;
            var objType = obj.GetType();
            var field = objType.GetFieldFast(fieldName, fieldType, baseType);
            if (field != null)
            {
                field.SetValue(obj, val);
                return;
            }
            var property = objType.GetPropertyFast(fieldName, fieldType, baseType);
            if (property != null) property.SetValue(obj, val);
        }
        public static void SetField<T>(this Object obj, String fieldName, T val, String fieldType = "", String baseType = "")
        {
            if (String.IsNullOrEmpty(fieldType))
                fieldType = typeof(T).Name;
            if (String.IsNullOrEmpty(baseType))
                baseType = obj is Type ? ((Type)obj).Name : obj.GetType().Name;
            SetField(obj, fieldName, fieldType, baseType, val);
        }
        public static List<Object> GetList(this Object obj)
        {
            var methods = obj.GetType().GetMethods(flags);
            var obj_get_Item = methods.First(m => m.Name == "get_Item");
            var obj_Count = obj.GetType().GetProperty("Count");
            var count = (Int32)obj_Count.GetValue(obj, new Object[0]);
            var elements = new List<Object>();
            for (Int32 i = 0; i < count; i++)
                elements.Add(obj_get_Item.Invoke(obj, new Object[] { i }));
            return elements;
        }
        public static Object Invoke(this Object obj, String methodName, params Object[] paramArray)
        {
            var type = obj is Type ? (Type)obj : obj.GetType();
            var method = type.GetMethod(methodName, flags);
            return obj is Type ? method.Invoke(null, paramArray) : method.Invoke(obj, paramArray);
        }
        public static T CreateInstance<T>(params Object[] paramArray)
        {
            return (T)Activator.CreateInstance(typeof(T), args: paramArray);
        }
    }
}