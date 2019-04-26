using System;
using System.ComponentModel;

namespace BiFi.Project.Common.Functions
{
    public static class EnumFunctions
    {
        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            if (value == null) return null;//if the incoming value is empty, do the following if it is not null again
            var memberInfo = value.GetType().GetMember(value.ToString());//ignore future value record type
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);//We'll find the description of attribute s
            return (T)attributes[0];//sending back
        }
        public static string ToName(this Enum value)
        {
            if (value == null) return null;
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
