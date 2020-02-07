using System.ComponentModel;

namespace KitOnline
{
	public enum CheckErrorCodeEnum
	{
		[Description("OK")]
		OK = 0,

		[Description("Неверный формат команды")]
		WrongFormat = 1,

		[Description("Данная команда требует другого состояния ФН")]
		WrongState = 2,

		[Description("Ошибка ФН")]
		FiscalStorageError = 3,

		[Description("Ошибка KC")]
		CryptoprocessorError = 4,

		[Description("Закончен срок эксплуатации ФН")]
		FiscalStorageLifeTime = 5,

		[Description("Архив ФН переполнен")]
		ArchiveIsFull = 6,

		[Description("Дата и время операции не соответствуют логике работы ФН")]
		WrongTime = 7,

		[Description("Запрошенные данные отсутствуют в Архиве ФН")]
		NoData = 8,

		[Description("Параметры команды имеют правильный формат, но их значение не верно")]
		ParametersWrongFormat = 9,

		[Description("Превышение размеров TLV данных")]
		TLVDataExceeding = 10,

		[Description("Исчерпан ресурс КС. Требуется закрытие фискального режима")]
		CryptoprocessorResourceExhausted = 11,

		[Description("Ресурс хранения документов для ОФД исчерпан")]
		OFDResourceExhausted = 12,

		[Description("Превышено время ожидания передачи сообщения (30 дней)")]
		WaitingTimeExceeded = 13,

		[Description("Продолжительность смены более 24 часов")]
		Session24 = 14,

		[Description("Неверная разница во времени между 2 операциями (более 5 минут)")]
		WrongTimeDifference = 15,

		[Description("Сообщение от ОФД не может быть принято")]
		MessageCanNotBeAccepted = 16,

		[Description("Неверная структура команды, либо неверная контрольная сумма")]
		WrongCommand = 17,

		[Description("Неизвестная команда")]
		UnknownCommand = 18,

		[Description("Неверная длина параметров команды")]
		WrongLength = 19,

		[Description("Неверный формат или значение параметров команды")]
		WrongParametersFormat = 20,

		[Description("Нет связи с ФН")]
		FiscalStorageNoConnect = 21,

		[Description("Неверные дата/время в ККТ")]
		WrongDateTime = 22,

		[Description("Переданы не все необходимые данные")]
		NotFullData = 23,

		[Description("РНМ сформирован неверно, проверка на данной ККТ не прошла")]
		WrongRN = 24,

		[Description("Данные уже были переданы ранее")]
		AlreadyTransferred = 25,

		[Description("Аппаратный сбой ККТ")]
		HardwareError = 26,

		[Description("Неверно указан признак расчета, возможные значения: приход, расход, возврат прихода, возврат расхода")]
		WrongCalculationSign = 27,

		[Description("Указанный налог не может быть применен")]
		WrongTax = 28,

		[Description("Данные необходимы только для платежного агента (указано при регистрации)")]
		DataForAhentOnly = 29,

		[Description("Итоговая сумма оплаты не равна стоимости предметов расчета")]
		WrongSum = 30,

		[Description("Некорректный статус печатающего устройства")]
		WrongStatePrinter = 31,

		[Description("Ошибка сохранения настроек")]
		SavingSettingsError = 32,

		[Description("Передано некорректное значение времени")]
		WrongTimeValue = 33,

		[Description("В чеке не должны присутствовать иные предметы расчета помимо предмета расчета с признаком способа расчета Оплата кредита")]
		OtherCalculationSubject = 34,

		[Description("Переданы не все необходимые данные для агента")]
		FewDataForAgent = 35,

		[Description("Итоговая сумма чека не равна сумме оплаты всеми видами")]
		WrongSum2 = 36,

		[Description("Неверно указан признак расчета для чека коррекции, возможные значения: приход, расход")]
		WrongCalculationSignCorrection = 37,

		[Description("Неверная структура переданных данных для агента")]
		WrongDataForAgent = 38,

		[Description("Не указан режим налогообложения")]
		NoTaxMode = 39,

		[Description("Данная ставка НДС недопустима для агента. Агент не является плательщиком НДС")]
		WrongTaxForAgent = 40,

		[Description("Некорректно указано значение тэга Признак платежного агента")]
		WrongTaxValueSign = 41,

		[Description("Номер блока прошивки указан некорректно")]
		WrongBlockFirmware = 42,

		[Description("Присутствуют неотправленные в ОФД документы")]
		NotSendedDocuments = 43,

		[Description("Подключенный ФН не соответствует данным регистрации ККТ")]
		WrongRegistrationData = 44,

		[Description("Неизвестная ошибка ККТ")]
		UnknownErrorCashregister = 45,

		[Description("Неизвестная ошибка ККТ 2")]
		UnknownErrorCashregister2 = 46,

		[Description("Нет рабочих ККТ")]
		NoWorkingCashregisters = 50,

		[Description("Максимальное время фиксации превышено")]
		TimeLimitExceeded = 51,

		[Description("ККТ недоступна - время аренды исчерпано")]
		CashregisterRentTimeExceeded = 52,

		[Description("Указанная СНО не доступна на ККТ")]
		TaxSystemNotAvailable = 53,

		[Description("Не указана СНО для чека")]
		TaxSystemNotSelected = 54,

		[Description("Нет связи с ККТ")]
		CashregisterNotResponding = 55,

		[Description("Некорректно указаны параметры \"Реквизита пользователя\"")]
		WrongUserRequisites = 56,

		[Description("Не указаны значения Адрес-Место-Автомат(для ККТ используемых 1 ко многим)")]
		WrongAddressPlaceAutomat = 57,

		[Description("Неверное сочетание значений Адрес-Место-Автомат(вендинг)")]
		WrongAddressPlaceAutomatVending = 58


	}
}