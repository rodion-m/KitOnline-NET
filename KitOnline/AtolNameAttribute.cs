using System;

namespace KitOnline.Misc
{
	/// <summary> Заглушка атрибута AtolName </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class AtolNameAttribute : Attribute
	{
		public string? Name { get; set; }
	}
}