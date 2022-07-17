using System;

namespace KitOnline
{
    /// <summary> Заглушка атрибута AtolName </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class AtolNameAttribute : Attribute
    {
        public string? Name { get; set; }
    }
}