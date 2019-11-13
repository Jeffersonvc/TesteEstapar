using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using Estapar.Core.Repository.Database.Annotations;

namespace Estapar.Core.Repository.Helper
{
    public class RepositoryHelper<TModel>
    {
        public IEnumerable<TModel> DataReaderMapToList(IDataReader dr)
        {
            List<TModel> list = new List<TModel>();
            TModel obj = default(TModel);
            while (dr.Read())
            {
                obj = CastReaderToObject(dr);
                list.Add(obj);
            }
            return list;
        }
        public TModel DataReaderMapToObject(IDataReader dr)
        {
            TModel obj = default(TModel);
            if (dr.Read())
            {
                obj = CastReaderToObject(dr);
            }
            return obj;
        }
        public TModel CastReaderToObject(IDataReader dr)
        {
            TModel obj = default(TModel);
            obj = Activator.CreateInstance<TModel>();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                var removeMappingAttr = prop.GetCustomAttribute<RemoveMapAttribute>();
                if (removeMappingAttr != null)
                    continue;

                var fieldName = GetFieldName(prop);

                bool hasColumnName = (dr.GetSchemaTable().Select($"ColumnName = '{fieldName}'").Count() == 1);

                if (hasColumnName && !dr.IsDBNull(dr.GetOrdinal(fieldName)))
                {
                    prop.SetValue(obj, dr[fieldName], null);
                }
            }
            return obj;
        }
        public string GetFieldName(PropertyInfo field)
        {
            var fieldProperty = field.GetCustomAttribute<FieldAttribute>();

            if (fieldProperty == null)
                return field.Name;
            else
                return fieldProperty.FieldName;
        }
        public IEnumerable<TResult> DataReaderMapToList<TResult>(IDataReader dr) where TResult : class
        {
            List<TResult> list = new List<TResult>();
            TResult obj = default(TResult);
            while (dr.Read())
            {
                obj = CastReaderToObject<TResult>(dr);
                list.Add(obj);
            }
            return list;
        }
        public TResult CastReaderToObject<TResult>(IDataReader dr) where TResult : class
        {
            TResult obj = default(TResult);
            obj = Activator.CreateInstance<TResult>();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                var removeMappingAttr = prop.GetCustomAttribute<RemoveMapAttribute>();
                if (removeMappingAttr != null)
                    continue;

                var fieldName = GetFieldName(prop);

                bool hasColumnName = (dr.GetSchemaTable().Select($"ColumnName = '{fieldName}'").Count() == 1);

                if (hasColumnName && !dr.IsDBNull(dr.GetOrdinal(fieldName)))
                {
                    prop.SetValue(obj, dr[fieldName], null);
                }
            }
            return obj;
        }
        public TResult DataReaderMapToObject<TResult>(IDataReader dr) where TResult : class
        {
            TResult obj = default(TResult);
            if (dr.Read())
            {
                obj = CastReaderToObject<TResult>(dr);
            }
            return obj;
        }
    }
}
