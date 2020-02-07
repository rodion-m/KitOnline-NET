# KitOnline-NET
API-клиент для взаимодействия с сервисом аренды онлайн касс KitOnline на .NET Standard 2.0 (.NET Core 2.1+, ASP.NET Core 2.1+, .NET Framework 4.6.1+). Null-safety.

# Установка
Добавить к проекту NuGet пакет KitOnline.NET: `Install-Package KitOnline.NET` или `dotnet add package KitOnline.NET`

# Использование
Создайте клиент:
```csharp
var authorization = new KitOnlineAuthorization(login, password, companyId);
client = new KitOnlineClient(authorization, requireLink: true);
```
`requireLink` означает, что при каждой отправке чека у сервиса будет запрошена ссылка на этот чек
Для отправки чека и получения результата рекомендуется использовать метод `SendCheckAndWaitResult`:
```csharp
//1. Создаем позиции чека:
var subjects = Subject.ListOf(
	TaxTypeEnum.NoTax /* Ставка НДС */, PayAttributeTypeEnum.FullPayment, GoodsAttributeTypeEnum.Commodity,
	("Хлеб", 35m, 2m),
	("Сахар", 21m, 0.5m),
	("Маракуйя", 230.50m, 1m)
).ToList());

//2. Создаем чек:
return new Check(Guid.NewGuid().ToString(), 
	sumRub: 286.50m,
	pay: new Pay(cashRub: 286.50m),
	email: "noreply@gmail.com",
	phone: null,
	calculationType: CalculationTypeEnum.Incoming,
	taxSystemType: TaxSystemTypeEnum.OSN, //Ваша СНО
	subjects: subjects
);
  
//3. Отправляем чек и дожидаемся результата:
var response = await client.SendCheckAndWaitResult(check);
if(response.Succeeded)
{
	var checkUri = response.StateCheckResponse.Link;
	Console.WriteLine($"Ссылка на чек: {checkUri}");
}
else
{
	Console.WriteLine("Ошибка при отправке чека: " + 
		response.Exception?.Message 
		?? response.SendCheckResponse?.ErrorMessage
		?? response.StateCheckResponse?.ErrorMessage
	);
}
```
Больше примеров доступно в тестах: https://github.com/rodion-m/KitOnline-NET/blob/master/KitOnline.Test/Tests.cs
