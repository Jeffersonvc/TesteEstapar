namespace Estapar.Core.Repository.Database.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class TableAttribute : Attribute
    {
        public string TableName { get; set; }
        public TableAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class FieldAttribute : Attribute
    {
        public string FieldName { get; set; }
        public FieldAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class PrimaryKeyAttribute : Attribute
    {
        public bool IsIdentity { get; set; }
        public PrimaryKeyAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class RemoveMapAttribute : Attribute
    {
        public RemoveMapAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class RemoveFromUpdateAttribute : Attribute
    {
        public RemoveFromUpdateAttribute()
        {
        }
    }
}
