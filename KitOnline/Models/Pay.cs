namespace KitOnline.Models
{
	/// <summary>
	///     Данные об оплате. Допускается указывать одновременно несколько значений:
	///     например, <see cref="CashSum" /> и <see cref="EMoneySum" />.
	/// </summary>
	public class Pay
    {
        public Pay()
        {
        }

        /// <summary>
        ///     Иницализирует объект, задавая сумму из заданных сумм в рублях
        /// </summary>
        /// <param name="cashRub">Наличные в рублях (необязательно)</param>
        /// <param name="eMoneyRub">Электронные деньги в рублях (необязательно)</param>
        public Pay(decimal? cashRub = null, decimal? eMoneyRub = null)
        {
            if (cashRub.HasValue)
                CashSum = cashRub.Value.Kopeek();

            if (eMoneyRub.HasValue)
                EMoneySum = eMoneyRub.Value.Kopeek();
        }

        /// <summary> сумма принятых от покупателя наличных денежных средств в копейках </summary>
        public long? CashSum { get; set; }

        /// <summary> сумма электронных денежных средств в копейках </summary>
        public long? EMoneySum { get; set; }

        /// <summary> сумма предоплаты (зачета аванса) в копейках </summary>
        public long? PrepaymentSum { get; set; }

        /// <summary> сумма постоплаты (в кредит) в копейках </summary>
        public long? PostpaySum { get; set; }

        /// <summary> сумма встречного предоставления в копейках </summary>
        public long? ProvidingSum { get; set; }
    }
}