using System.Collections.Generic;

namespace KitOnline.Models.SendCheck
{
    public static class SendCheckErrors
    {
        public static Dictionary<int, string> Errors = new Dictionary<int, string>
        {
            { 0, "" },
            { 1, "Неизвестная ошибка сервиса" },
            { 2, "Неверная структура JSON" },
            { 3, "Ошибка чтения данных запроса" },
            { 4, "Неверный формат запроса. Объект Request не может быть пустым" },
            { 5, "Неверный формат запроса. Объект Check не может быть пустым" },
            { 6, "Неверный формат запроса. Массив Subjects не может быть пустым" },
            { 7, "Неверный формат запроса. Объект Pay не может быть пустым" },
            { 8, "Неверный формат запроса. Значение CompanyId должно быть числом" },
            { 9, "Неверный формат запроса. Значение RequestId должно быть числом" },
            { 10, "Неверный формат запроса. Значение UserLogin не может быть пустым" },
            { 11, "Неверный формат запроса. Значение Sign не может быть пустым" },
            { 12, "Неверный формат запроса. Значение TaxSystemType должно быть числом" },
            { 13, "Неверный формат запроса. Значение CalculationType должно быть числом" },
            { 14, "Неверный формат запроса. Значение Sum должно быть числом" },
            { 15, "Неверный формат запроса. Недопустимое значение TaxSystemType" },
            { 16, "Неверный формат запроса. Недопустимое значение CalculationType" },
            { 17, "Неверный формат запроса. Объект Pay не содержит ни одного элемента" },
            { 18, "Неверный формат запроса. Значение CashSum должно быть числом" },
            { 19, "Неверный формат запроса. Значение EMoneySum должно быть числом" },
            { 20, "Неверный формат запроса. Значение PostpaySum должно быть числом" },
            { 21, "Неверный формат запроса. Значение PrepaymentSum должно быть числом" },
            { 22, "Неверный формат запроса. Значение ProvidingSum должно быть числом" },
            { 23, "Неверный формат запроса. Значение Price в предмете расчета должно быть числом" },
            { 24, "Неверный формат запроса. Значение Tax в предмете расчета должно быть числом" },
            { 25, "Неверный формат запроса. Недопустимое значение Quantity в предмете расчета" },
            { 26, "Неверный формат запроса. Значение SubjectName в предмете расчета не может быть пустым" },
            { 27, "Неверный формат запроса. Недопустимое значение PayAttribute в предмете расчета" },
            { 28, "Неверный формат запроса. Значение OrganizationId должно быть числом" },
            { 29, "Неверный формат запроса. Значение CashregisterSerial должно быть числом" },
            { 30, "Неверный формат запроса. Значение MaxWaitingTime должно быть числом" },
            { 31, "Компания с таким id не найдена" },
            { 32, "Компания заблокирована" },
            { 33, "Пользователь с таким логином не найден" },
            { 34, "Пользователь заблокирован" },
            { 35, "У пользователя нет прав на данную операцию" },
            { 36, "Неверное значение RequestId" },
            { 37, "Неверная подпись" },
            { 38, "Суммарная стоимость предметов расчета не равна итогу чека" },
            { 39, "Сумма оплат(ы) не равна итогу чека" },
            { 40, "Организация/субкомпания с таким id не найдена" },
            { 41, "Касса с таким номером не найдена" },
            { 42, "Неверный формат запроса. Значение CheckQueueId должно быть числом" },
            { 43, "Чек с таким id не найден" },
            { 44, "Неверный формат запроса. Значение CheckId должно быть числом" },
            { 45, "Чек с таким CheckId уже существует" },
            { 46, "Касса с таким id не найдена" },
            { 47, "Организация с таким id не найдена" },
            { 48, "Касса заблокирована" },
            { 49, "Организация заблокирована" },
            { 50, "Неверная связка кассы и организации" },
            { 51, "Неверный формат запроса. Недопустимо одновременное указание почты и номера телефона" },
            { 52, "Неверный формат запроса. Значение AgentFlag должно быть числом" },
            { 53, "Неверный формат запроса. Недопустимое значение AgentFlag" },
            { 54, "Неверный формат запроса. Недопустимая связка значений для торгового автомата" },
            { 55, "Статус чека не позволяет совершить данную операцию" },
            { 56, "Неверный формат запроса. Значение DocumentNumber не может быть пустым" },
            { 57, "Неверный формат запроса. Значение FiscalSign не может быть пустым" },
            { 58, "Неверный формат запроса. Значение SessionNumber не может быть пустым" },
            { 59, "Неверный формат запроса. Значение ReceiptNumber не может быть пустым" },
            { 60, "Неверный формат запроса. Значение CheckDate не может быть пустым" },
            { 61, "Неверный формат запроса. Значение CheckDate должно быть датой со временем" },
            { 62, "Неверный формат запроса. Значение SessionNumber должно быть числом" },
            { 63, "Неверный формат запроса. Значение ReceiptNumber должно быть числом" },

            { 100, "Неверный формат запроса. Некорректная структура JSON" },
            { 101, "Неверный формат запроса. Недопустимое значение GoodsAttribute в предмете расчета" },


            { 109, "Пакетная обработка. Значение RequestId не может быть пустым" },
            { 110, "Некоторые чеки пакетного запроса не прошли валидацию" },
            { 111, "Некоторые идентификаторы пакетного запроса статуса не прошли валидацию" },
            { 112, "В пакетном запросе отсутствуют элементы CheckNumber" },
            { 113, "В пакетном запросе не должно быть повторяющихся элементов CheckNumber" },
            {
                114,
                "Пакетный запрос статусов. Ошибка запроса для некоторых элементов CheckNumber. Подробности по ErrorCode"
            },
            { 115, "Пакетная вставка чеков. Некоторые чеки не были вставлены в БД. Подробности по ErrorCode" }
        };
    }
}