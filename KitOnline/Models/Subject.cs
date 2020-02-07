using System;
using System.Collections.Generic;
using System.Linq;
using KitOnline.Enums;

namespace KitOnline.Models
{
	/// <summary> Наименование в чеке </summary>
	public class Subject
	{
		public Subject() {}
		public Subject(
			string subjectName, 
			decimal priceRub, 
			decimal quantity,
			TaxTypeEnum tax, 
			PayAttributeTypeEnum payAttribute, 
			GoodsAttributeTypeEnum goodsAttribute)
		{
			SubjectName = subjectName;
			Price = priceRub.Kopeek();
			Quantity = quantity;
			Tax = tax;
			PayAttribute = payAttribute;
			GoodsAttribute = goodsAttribute;
		}

		/// <summary>
		/// Возвращает список из <see cref="Subject"/>
		/// </summary>
		/// <example>
		///	Subject.ListOf(TaxTypeEnum.NoTax, PayAttributeTypeEnum.FullPayment, GoodsAttributeTypeEnum.Commodity, ("Маракуйя", 25m, 2), ("Сахар", 50m, 0.5m))
		/// </example>
		public static IEnumerable<Subject> ListOf(
			TaxTypeEnum tax, PayAttributeTypeEnum payAttribute, GoodsAttributeTypeEnum goodsAttribute,
			params (string name, decimal priceRub, decimal quantity)[] subjects)
		{
			if (subjects == null) throw new ArgumentNullException(nameof(subjects));
			return subjects.Select(it => new Subject(it.name, it.priceRub, it.quantity, tax, payAttribute, goodsAttribute));
		}

		/// <summary> Название товара (максимум 128 символов) </summary>
		public string SubjectName { get; set; } = "";
		
		/// <summary> Цена в копейках </summary>
		public long Price { get; set; }
		
		/// <summary> Количество </summary>
		public decimal Quantity { get; set; }
		
		/// <summary> Налог </summary>
		public TaxTypeEnum Tax { get; set; }

		/// <summary>
		/// Признак способа расчета
		/// В случае, если данное поле не передается в запросе используется значение 4 (Полный расчет).
		/// </summary>
		public PayAttributeTypeEnum? PayAttribute { get; set; }

		/// <summary>
		/// Признак предмета расчета
		/// В случае, если данное поле не передается в запросе используется значение 4 (Услуга)
		/// </summary>
		public GoodsAttributeTypeEnum? GoodsAttribute { get; set; }

		/// <summary> Возвращает округленную сумму в копейках </summary>
		public long GetTotalPriceKp()
		{
			return (long) Math.Round(Price * Quantity, MidpointRounding.AwayFromZero);
		}
	}
}