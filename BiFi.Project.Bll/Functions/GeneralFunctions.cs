using BiFi.Dal.Base;
using BiFi.Dal.Interfaces;
using BiFi.Project.Model.Entities.Base;
using BiFi.Project.Model.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;

namespace BiFi.Project.Bll.Functions
{
    public static class GeneralFunctions
    {
        public static List<string> VariableFieldsSelect<T>(this T oldEntity, T currentEntity)
        {
            List<string> fields = new List<string>();

            foreach (var prop in currentEntity.GetType().GetProperties())//We are moving between the currententity properties.
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;//Entities to use ICollectin to reach between entities
                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;//we get the initial value in the database, but if it comes to null, we get string empty for our value comparison.
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty;//we'll use string.empty if it's null the same way we get the last added value.

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString()))
                        oldValue = new byte[] { 0 };
                    if (string.IsNullOrEmpty(currentValue.ToString()))
                        currentValue = new byte[] { 0 };

                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                        fields.Add(prop.Name);
                }
                else if (!currentValue.Equals(oldValue))
                    fields.Add(prop.Name);
            }
            return fields;
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ProjectContext"].ConnectionString;//it will return to the projectcontext attached to appconfig.
        }
        private static TContext CreateContext<TContext>() where TContext : DbContext
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), GetConnectionString());//parametrated intense and send back.
        }
        public static void CreateUnitIOfWork<T, TContext>(ref IUnitOfWork<T> uow) where T : class, IBaseEntity where TContext : DbContext//T class is a class of IBaseEntity implementer said
        {
            uow?.Dispose();
            uow = new UnitOfWork<T>(CreateContext<TContext>());
        }
        
        
    }
}
