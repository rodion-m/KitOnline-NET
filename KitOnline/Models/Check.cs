using System;
using System.Collections.Generic;
using System.Linq;
using KitOnline.Enums;
using Newtonsoft.Json;

namespace KitOnline.Models
{
	public class Check
	{
		public Check(string checkId, 
			CalculationTypeEnum calculationType, 
			TaxSystemTypeEnum? taxSystemType, 
			string? email, 
			string? phone, 
			Pay pay,
			List<Subject> subjects, 
			decimal sumRub) 
			: this(checkId, calculationType, taxSystemType, email, phone, pay, subjects, 0)
		{
			SetSumRub(sumRub);
		}

		[JsonConstructor]
		protected Check(string checkId, 
			CalculationTypeEnum calculationType,
			TaxSystemTypeEnum? taxSystemType, 
			string? email, 
			string? phone, 
			Pay pay,
			List<Subject> subjects, 
			long sum)
		{
			CheckId = checkId ?? throw new ArgumentNullException(nameof(checkId));
			CalculationType = calculationType;
			TaxSystemType = taxSystemType;
			Sum = sum;
			Email = email;
			Phone = phone;
			Pay = pay ?? throw new ArgumentNullException(nameof(pay));
			Subjects = subjects ?? throw new ArgumentNullException(nameof(subjects));
		}

		/// <summary>
		/// Уникальный пользовательский идентификатор для каждого чека (максимум 64 символа) 
		/// </summary>
		public string CheckId { get; set; }

		/// <summary>
		/// Признак расчета
		/// </summary>
		public CalculationTypeEnum CalculationType { get; set; }

		/// <summary>
		/// Тип используемой в чеке СНО (необязательно)
		/// Данное поле является обязательным в случае,
		/// если при регистрации ККТ было указано несколько систем налогообложения.
		/// </summary>
		public TaxSystemTypeEnum? TaxSystemType { get; set; }

		/// <summary>
		/// Итоговая сумма чека в копейках
		/// </summary>
		public long Sum { get; set; }

		/// <summary>
		/// Адрес электронной почты пользователя (необязательно)
		/// Указывается в случае, если необходима отправка электронной формы чека покупателю.
		/// </summary>
		public string? Email { get; set; }

		/// <summary>
		/// Номер телефона пользователя в формате 10 цифр (необязательно).
		/// Указывается в случае, если необходима отправка электронной формы чека на телефон покупателю.
		/// </summary>
		public string? Phone { get; set; }

		/// <summary>
		/// Данные об оплате
		/// </summary>
		public Pay Pay { get; set; }

		/// <summary>
		/// Предметы расчета
		/// </summary>
		public List<Subject> Subjects { get; set; }

		/// <summary>
		/// Задает сумму в рублях
		/// </summary>
		/// <param name="sum">Сумма в рублях</param>
		public void SetSumRub(decimal sum)
		{
			Sum = sum.Kopeek();
		}

		/// <summary>
		/// Проверяет и корректирует сумму товаров в чеке
		/// </summary>
		/// <param name="toleranceKop">
		/// Допустимое расхождение в копейках, которое будет перенесена на самый дорогой товар
		/// Иначе будет выброшено исключение (по умолчанию 99 копеек) 
		/// </param>
		/// <returns>true если цены скорректированы и false если цены не изменены</returns>
		public bool CheckAndFixPricing(int toleranceKop = 99)
		{
			if(Subjects.Count == 0) throw new Exception("Невозможно скорректировать цены, т.к. в чеке нет ни одного товара");
			if (toleranceKop <= 0) throw new ArgumentOutOfRangeException(nameof(toleranceKop));
			
			var calculatedSum = Subjects.Sum(it => it.GetTotalPriceKp());
			var difference = (int) (Sum - calculatedSum);
			if (difference == 0)
				return false;

			if (difference > toleranceKop)
				throw new Exception("Слишком большое расхождение суммарной стоимости предметов расчета и итога чека");

			var oneSubject = Subjects.OrderByDescending(it => it.Price).FirstOrDefault(subject => subject.Quantity == 1m && subject.Price > Math.Abs(difference));
			if (oneSubject != null)
			{
				oneSubject.Price += difference;
				return true;
			}

			var maxPriceSubject = Subjects.Find(subject => subject.Price == Subjects.Max(it => it.Price));
			maxPriceSubject.Price += (long)((decimal) difference / maxPriceSubject.Quantity);
			
			return true;
		}

	}
}