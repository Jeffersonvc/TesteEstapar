using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using Estapar.Core.Repository.Database.Annotations;

namespace Estapar.Core.Repository.Database
{
    public class ScriptGenerator<TModel>
    {
        private const string _prefixParameter = "@";
        public string SelectAll(TModel model)
        {
            StringBuilder select = new StringBuilder();

            select.Append("SELECT ");

            PropertyInfo[] pi = GetPropertyInfo(model);
            PropertyInfo propertyPk = GetKeyField(model);
            string pKey = GetFieldName(propertyPk);

            string tableName = GetTableName(model);

            if (pi.Count() > 0)
                select.Append(string.Join(", ", pi.Select(p => tableName + "." + GetFieldName(p)).ToList()));
            else
                select.Append(tableName + ".* ");

            select.AppendFormat(" FROM {0} (NOLOCK)", tableName);


            return FormatScript(select.ToString());
        }

        public string Select(TModel model, ref Dictionary<string, object> parameters)
        {
            StringBuilder select = new StringBuilder();
            StringBuilder innerJoin = new StringBuilder();
            select.Append("SELECT ");

            PropertyInfo[] propertyInfos = GetPropertyInfo(model);
            PropertyInfo propertyPk = GetKeyField(model);
            string pKey = GetFieldName(propertyPk);

            Type t = typeof(TModel);

            PropertyInfo[] pi = t.GetProperties();

            string tableName = GetTableName(model);

            if (propertyInfos.Count() > 0)
                select.Append(string.Join(", ", propertyInfos.Select(p => tableName + "." + this.GetFieldName(p)).ToList()));
            else
                select.Append(" * ");

            select.AppendFormat(" FROM {0} (NOLOCK)", tableName);

            select.AppendFormat(" WHERE {0}.{1} = {2}", tableName, pKey, GetFieldNameWithPrefix(propertyPk));
            AddParameter(ref parameters, propertyPk, model);

            return FormatScript(select.ToString());
        }

        public string SelectWithFilter(TModel model, object filters, ref Dictionary<string, object> parameters)
        {
            StringBuilder select = new StringBuilder();
            StringBuilder innerJoin = new StringBuilder();

            select.Append("SELECT ");

            PropertyInfo[] pi = GetPropertyInfo(model);
            PropertyInfo propertyPk = GetKeyField(model);
            string pKey = GetFieldName(propertyPk);

            string tableName = GetTableName(model);

            if (pi.Count() > 0)
                select.Append(string.Join(", ", pi.Select(p => tableName + "." + GetFieldName(p)).ToList()));
            else
                select.Append(tableName + ".* ");

            
            select.AppendFormat(" FROM {0} (NOLOCK)", tableName);

            Type t = filters.GetType();

            PropertyInfo[] paramInfo = t.GetProperties();

            if (paramInfo.Count() > 0)
            {
                select.AppendFormat(" WHERE ");
            }

            int count = paramInfo.Count();

            foreach (PropertyInfo p in paramInfo)
            {
                if (count > 1)
                {
                    select.AppendFormat(" {0}.{1} = {2} AND ", tableName, p.Name, GetFieldNameWithPrefix(p));
                    AddParameter(ref parameters, p, filters);
                }
                else
                {
                    select.AppendFormat(" {0}.{1} = {2} ", tableName, p.Name, GetFieldNameWithPrefix(p));
                    AddParameter(ref parameters, p, filters);
                }
                count--;
            }

            return FormatScript(select.ToString());
        }

        public string Update(TModel model, ref Dictionary<string, object> parameters)
        {
            StringBuilder update = new StringBuilder();
            string tableName = GetTableName(model);
            update.AppendFormat("UPDATE {0} SET ", tableName);

            PropertyInfo[] pi = GetPropertyInfo(model, true, true);
            PropertyInfo propertyPk = GetKeyField(model);
            string pKey = GetFieldName(propertyPk);

            int count = pi.Count();

            foreach (var dbTable in pi)
            {
                if (count > 1)
                {
                    update.AppendFormat(" {0}.{1} = {2}, ", tableName, GetFieldName(dbTable), GetFieldNameWithPrefix(dbTable));
                    AddParameter(ref parameters, dbTable, model);
                }
                else
                {
                    update.AppendFormat(" {0}.{1} = {2} ", tableName, GetFieldName(dbTable), GetFieldNameWithPrefix(dbTable));
                    AddParameter(ref parameters, dbTable, model);
                }
                count--;
            }

            update.AppendFormat(" WHERE {0}.{1} = {2}", tableName, pKey, GetFieldNameWithPrefix(propertyPk));
            AddParameter(ref parameters, propertyPk, model);

            return FormatScript(update.ToString());
        }

        public string Update(TModel model, ref Dictionary<string, object> parameters, object updateFilters = null, object updateKeys = null)
        {
            StringBuilder update = new StringBuilder();
            string tableName = GetTableName(model);
            update.AppendFormat("UPDATE {0} SET ", tableName);

            Type t = typeof(TModel);

            PropertyInfo propertyPk = GetKeyField(model);
            string pKey = GetFieldName(propertyPk);
            int count;

            PropertyInfo[] pi;
            if (updateFilters == null)
            {
                pi = GetPropertyInfo(model, true, true);
                count = pi.Count();

                foreach (var dbTable in pi)
                {
                    if (count > 1)
                    {
                        update.AppendFormat(" {0}.{1} = {2}, ", tableName, GetFieldName(dbTable), GetFieldNameWithPrefix(dbTable));
                        AddParameter(ref parameters, dbTable, model);
                    }
                    else
                    {
                        update.AppendFormat(" {0}.{1} = {2} ", tableName, GetFieldName(dbTable), GetFieldNameWithPrefix(dbTable));
                        AddParameter(ref parameters, dbTable, model);
                    }
                    count--;
                }
            }
            else
            {
                Type tf = updateFilters.GetType();
                pi = tf.GetProperties();
                count = pi.Count();

                foreach (var dbTable in pi)
                {
                    if (count > 1)
                    {
                        update.AppendFormat(" {0}.{1} = {2}, ", tableName, dbTable.Name, GetFieldNameWithPrefix(dbTable));
                        AddParameter(ref parameters, dbTable, model);
                    }
                    else
                    {
                        update.AppendFormat(" {0}.{1} = {2} ", tableName, dbTable.Name, GetFieldNameWithPrefix(dbTable));
                        AddParameter(ref parameters, dbTable, model);
                    }
                    count--;
                }
            }

            if (updateKeys == null)
            {
                update.AppendFormat(" WHERE {0}.{1} = {2}", tableName, pKey, GetFieldNameWithPrefix(propertyPk));
                AddParameter(ref parameters, propertyPk, model);
            }
            else
            {
                update.Append(" WHERE ");
                t = updateKeys.GetType();
                pi = t.GetProperties();
                count = pi.Count();

                foreach (PropertyInfo p in pi)
                {
                    if (count > 1)
                    {
                        update.AppendFormat(" {0}.{1} = {2} AND ", tableName, p.Name, GetFieldNameWithPrefix(p));
                        AddParameter(ref parameters, p, updateKeys);
                    }
                    else
                    {
                        update.AppendFormat(" {0}.{1} = {2} ", tableName, p.Name, GetFieldNameWithPrefix(p));
                        AddParameter(ref parameters, p, updateKeys);
                    }
                    count--;
                }
            }

            return FormatScript(update.ToString());
        }

        public string Delete(TModel model, ref Dictionary<string, object> parameters)
        {
            StringBuilder delete = new StringBuilder();
            string tableName = GetTableName(model);
            delete.AppendFormat("DELETE FROM {0} ", tableName);

            PropertyInfo propertyPk = GetKeyField(model);
            string pKey = GetFieldName(propertyPk);

            delete.AppendFormat(" WHERE {0}.{1} = {2}", tableName, pKey, GetFieldNameWithPrefix(propertyPk));
            AddParameter(ref parameters, propertyPk, model);

            return FormatScript(delete.ToString());
        }

        public string Delete(TModel model, object deleteKeys, ref Dictionary<string, object> parameters)
        {
            if (deleteKeys == null)
                return Delete(model, ref parameters);

            StringBuilder delete = new StringBuilder();
            string tableName = GetTableName(model);
            delete.AppendFormat("DELETE FROM {0} ", tableName);

            if (deleteKeys == null)
                return delete.ToString();

            Type t = deleteKeys.GetType();

            PropertyInfo[] pi = t.GetProperties();

            int count = pi.Count();

            if (count > 0)
                delete.AppendFormat(" WHERE ");

            foreach (PropertyInfo p in pi)
            {
                if (count > 1)
                {
                    delete.AppendFormat(" {0}.{1} = {2} AND ", tableName, GetFieldName(p), GetFieldNameWithPrefix(p));
                    AddParameter(ref parameters, p, deleteKeys);
                }
                else
                {
                    delete.AppendFormat(" {0}.{1} = {2} ", tableName, GetFieldName(p), GetFieldNameWithPrefix(p));
                    AddParameter(ref parameters, p, deleteKeys);
                }
                count--;
            }

            return FormatScript(delete.ToString());
        }

        public string Insert(TModel model, ref Dictionary<string, object> parameters)
        {
            StringBuilder insert = new StringBuilder();
            StringBuilder values = new StringBuilder();
            string tableName = GetTableName(model);
            insert.AppendFormat("INSERT INTO {0} (", tableName);

            var primaryKeyProperty = GetKeyField(model);
            var identityProperty = primaryKeyProperty.GetCustomAttribute<PrimaryKeyAttribute>();

            PropertyInfo[] pi = GetPropertyInfo(model, (identityProperty == null ? false : identityProperty.IsIdentity));
            pi = pi.Where(p => p.GetType() != typeof(RemoveMapAttribute)).ToArray();
            int count = pi.Count();

            foreach (PropertyInfo p in pi)
            {
                if (count > 1)
                {
                    insert.AppendFormat(" {0} , ", GetFieldName(p));
                    values.AppendFormat(" {0} , ", GetFieldNameWithPrefix(p));
                    AddParameter(ref parameters, p, model);
                }
                else
                {
                    insert.AppendFormat(" {0} ", GetFieldName(p));
                    values.AppendFormat(" {0} ", GetFieldNameWithPrefix(p));
                    AddParameter(ref parameters, p, model);
                }
                count--;
            }

            insert.Append(" ) VALUES (");

            insert.Append(values.ToString());

            insert.Append(" )");

            return FormatScript(insert.ToString());
        }

        public string InsertWithFilter(TModel model, object insertValues, ref Dictionary<string, object> parameters)
        {
            StringBuilder insert = new StringBuilder();
            StringBuilder values = new StringBuilder();
            string tableName = GetTableName(model);
            insert.AppendFormat("INSERT INTO {0} (", tableName);

            Type t = insertValues.GetType();
            PropertyInfo[] pi = t.GetProperties();
            pi = pi.Where(p => p.GetType() != typeof(RemoveMapAttribute)).ToArray();
            int count = pi.Count();

            foreach (PropertyInfo p in pi)
            {
                if (count > 1)
                {
                    insert.AppendFormat(" {0} , ", p.Name);
                    values.AppendFormat(" {0} , ", GetFieldNameWithPrefix(p));
                    AddParameter(ref parameters, p, insertValues);
                }
                else
                {
                    insert.AppendFormat(" {0} ", p.Name);
                    values.AppendFormat(" {0} ", GetFieldNameWithPrefix(p));
                    AddParameter(ref parameters, p, insertValues);
                }
                count--;
            }

            insert.Append(" ) VALUES (");

            insert.Append(values.ToString());

            insert.Append(" )");

            return FormatScript(insert.ToString());
        }

        #region Aux Methods
        private void AddParameter(ref Dictionary<string, object> parameters, PropertyInfo pi, object model)
        {
            parameters.Add(GetFieldNameWithPrefix(pi), PrepareValue(pi.GetValue(model)));
        }

        private string GetTableName(object model)
        {
            var tableProperty = GetAttributeFrom<TableAttribute>(model);

            if (tableProperty == null)
                return model.GetType().Name;
            else
                return tableProperty.TableName;
        }

        private string GetFieldName(PropertyInfo field)
        {
            var fieldProperty = field.GetCustomAttribute<FieldAttribute>();

            if (fieldProperty == null)
                return string.Format("{0}", field.Name);
            else
                return string.Format("{0}", fieldProperty.FieldName);
        }

        private string GetFieldNameWithPrefix(PropertyInfo field, string prefix = _prefixParameter)
        {
            var fieldProperty = field.GetCustomAttribute<FieldAttribute>();

            if (fieldProperty == null)
                return string.Format("{0}{1}", prefix, field.Name);
            else
                return string.Format("{0}{1}", prefix, fieldProperty.FieldName);
        }

        private PropertyInfo[] GetPropertyInfo(TModel t, bool removePK = false, bool isUpdate = false)
        {
            PropertyInfo[] propertyInfos;
            List<PropertyInfo> propertyInfosReturn = new List<PropertyInfo>();
            propertyInfos = t.GetType().GetProperties();
            foreach (var p in propertyInfos)
            {
                var rm = p.GetCustomAttribute<RemoveMapAttribute>();
                if(isUpdate)
                {
                    var updt = p.GetCustomAttribute<RemoveFromUpdateAttribute>();
                    if (updt != null)
                        continue;
                }

                if (removePK)
                {
                    var pk = p.GetCustomAttribute<PrimaryKeyAttribute>();
                    if (rm == null && pk == null)
                    {
                        propertyInfosReturn.Add(p);
                    }
                }
                else
                {
                    if (rm == null)
                    {
                        propertyInfosReturn.Add(p);
                    }
                }
            }

            return propertyInfosReturn.ToArray();
        }

        private object GetPropertyValue(object src, string propName)
        {
            if (src == null) throw new ArgumentException("Value cannot be null.", "src");
            if (propName == null) throw new ArgumentException("Value cannot be null.", "propName");

            if (propName.Contains("."))//complex type nested
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
            }
            else
            {
                var prop = src.GetType().GetProperties(); //.GetProperty(propName);
                return prop != null ? prop : null; //.GetValue(src, null) : null;
            }
        }

        private PropertyInfo[] GetInnerJoinPropertiInfo(TModel t)
        {
            PropertyInfo[] propertyInfos;
            List<PropertyInfo> propertyInfosReturn = new List<PropertyInfo>();
            propertyInfos = t.GetType().GetProperties();
            foreach (var p in propertyInfos)
            {
                var rm = p.GetCustomAttribute<RemoveMapAttribute>();
                if (rm == null)
                {
                    propertyInfosReturn.Add(p);
                }
            }

            return propertyInfosReturn.ToArray();
        }

        private PropertyInfo[] GetLeftJoinPropertiInfo(TModel t)
        {
            PropertyInfo[] propertyInfos;
            List<PropertyInfo> propertyInfosReturn = new List<PropertyInfo>();
            propertyInfos = t.GetType().GetProperties();
            foreach (var p in propertyInfos)
            {
                var rm = p.GetCustomAttribute<RemoveMapAttribute>();
                if (rm == null)
                {
                    propertyInfosReturn.Add(p);
                }
            }

            return propertyInfosReturn.ToArray();
        }

        private PropertyInfo GetKeyField(TModel t)
        {
            PropertyInfo[] propertyInfos;
            List<PropertyInfo> propertyInfosReturn = new List<PropertyInfo>();
            propertyInfos = t.GetType().GetProperties();
            foreach (var p in propertyInfos)
            {
                var pk = p.GetCustomAttribute<PrimaryKeyAttribute>();
                if (pk != null)
                {
                    return p;
                }
            }

            throw new Exception("Primary key not found");
        }

        private List<DBTable> GetFields(PropertyInfo[] properties)
        {
            List<DBTable> fields = new List<DBTable>();

            if (properties != null && properties.Length > 0)
            {
                Type[] types = properties.Select(s => s.PropertyType).Distinct().ToArray();

                foreach (var t in types)
                {
                    var instance = Activator.CreateInstance(t);
                    var tableName = GetTableName(instance);
                    var fieldNames = GetPropertyValue(instance, "");

                    if (fieldNames != null)
                    {
                        var propertyFieldNames = (PropertyInfo[])fieldNames;
                        if (propertyFieldNames != null)
                        {
                            List<DBField> f = new List<DBField>();

                            foreach (var item in propertyFieldNames)
                            {
                                f.Add(new DBField()
                                {
                                    FieldName = GetFieldName(item),
                                    FieldValue = TryGetValue(item, propertyFieldNames)
                                });
                            }

                            if (f.Count > 0)
                                fields.Add(new DBTable()
                                {
                                    TableName = tableName,
                                    Fields = f
                                });
                        }
                    }
                }
            }

            return fields;
        }

        private object TryGetValue(PropertyInfo pi, PropertyInfo[] arr)
        {
            try
            {
                return pi.GetValue(arr);
            }
            catch
            {
                return null;
            }
        }

        private T GetAttributeFrom<T>(object instance) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetCustomAttribute(typeof(T));
            if (property == null)
                return null;
            else
                return (T)property;
        }

        private object PrepareValue(object value)
        {
            if (value == null)
                return DBNull.Value;

            Type t = value.GetType();

            if (t == typeof(DateTime))
            {
                return string.Format("{0}", ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (t == typeof(decimal) || t == typeof(float) || t == typeof(double) || t == typeof(long) || t == typeof(short))
            {
                //var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                return value;
                //return ((decimal)(value)).ToString("C" + culture.NumberFormat.NumberDecimalDigits, culture);
            }
            else if (t == typeof(string) || t == typeof(char))
            {
                return string.Format("{0}", value);
            }
            else if (t == typeof(bool))
            {
                return string.Format("{0}", ((bool)value) ? 1 : 0);
            }
            else
            {
                return value;
            }
        }

        private string FormatScript(string script)
        {
            script = script.Replace("  ", " ");
            script = script.Replace(" ,  ", ", ");

            return script;
        }
        #endregion
    }
}
