using BiFi.Project.Model.Entities.Base.Interfaces;
using System;
using System.Linq;

namespace BiFi.Project.Bll.Functions
{
    public static class Converts
    {
        public static TTarget EntityConvert<TTarget>(this IBaseEntity source)
        {
            if (source == null) return default(TTarget);// if the source is empty we send by default
            var target = Activator.CreateInstance<TTarget>();// We produce instance from TTarget
            var sourceProp = source.GetType().GetProperties();// we will move between the properties of the resource.
            var targetProp = typeof(TTarget).GetProperties();//we'll move between the properties of the target

            foreach (var sp in sourceProp)
            {
                var value = sp.GetValue(source);//We take the values of the source.
                var tp = targetProp.FirstOrDefault(x => x.Name == sp.Name);//search the target properties in the target properties
                if (tp != null)//if the result is not the same
                    tp.SetValue(target, ReferenceEquals(value, "") ? null : value);//If the data in the target e is not null if we are transferring the data, you pass the value
            }
            return target;//we complete and send the data.
        }
    }
}
