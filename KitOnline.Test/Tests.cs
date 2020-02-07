using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using KitOnline.Enums;
using KitOnline.Models;
using KitOnline.Models.StateCheck;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace KitOnline.Test
{
	public class Tests
	{
		/// <summary>
		/// Тестовые данные можно получить, обратившись по адресу info@kit-invest.ru
		/// </summary>
		private const string TestLogin = null; 
		private const string TestPassword = null;
		private const int TestCompanyId = -1;

		private readonly ITestOutputHelper output;
		private readonly KitOnlineClient client;

		public Tests(ITestOutputHelper output)
		{
			if(TestLogin == null) throw new Exception($"Сперва задайте {nameof(TestLogin)}!");
			if(TestPassword == null) throw new Exception($"Сперва задайте {nameof(TestPassword)}!");
			if(TestCompanyId == -1) throw new Exception($"Сперва задайте {nameof(TestCompanyId)}!");
			
			var authorization = new KitOnlineAuthorization(TestLogin, TestPassword, TestCompanyId);
			this.output = output;
			client = new KitOnlineClient(authorization, requireLink: true);
		}
		
		/// <summary>
		/// Тестирует запрос <see cref="KitOnlineClient.SendCheckAndWaitResult"/>
		/// </summary>
		[Fact]
		public async void SendCheckAndWaitResult_Success()
		{
			var check = CreateTestCheck();
			var response = await client.SendCheckAndWaitResult(check);
			
			output.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
			response.Exception.Should().Be(null, "Исключения быть не должно");
			response.StateCheckResponse.ErrorMessage.Should().Be(null, "Ошибки быть не должно");
		}
		
		/// <summary>
		/// Тестирует запрос <see cref="KitOnlineClient.SendCheck"/>
		/// </summary>
		[Fact]
		public async Task<string> SendCheck_Success()
		{
			var check = CreateTestCheck();
			var response = await client.SendCheck(check);
			
			output.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
			response.ErrorMessage.Should().Be(null, "Ошибки быть не должно");

			return check.CheckId;
		}
		
		/// <summary>
		/// Тестирует запрос <see cref="KitOnlineClient.StateCheck"/>
		/// </summary>
		[Fact]
		public async void StateCheck_Success()
		{
			var checkId = await SendCheck_Success();
			var response = await client.StateCheck(checkId);
			
			response.ErrorMessage.Should().Be(null, "Ошибки быть не должно");
		}
		
		/// <summary>
		/// Тестирует алгоритм генерации подписи
		/// </summary>
		[Fact]
		public void TestSign()
		{
			var kitOnlineClient = new KitOnlineClient("tlogin", "tpass42", 7);
			kitOnlineClient.GetSign("101").Should().Be("A8F447DB87C96957B60F0996AF16A086");
		}
		
		/// <summary>
		/// Тестирует факт удаления null полей при сериализации в Json
		/// </summary>
		[Fact]
		public void TestJsonSerializer()
		{
			var check = CreateTestCheck();
			var body = new RequestBody(client.CreateRequest(check.CheckId), check.CheckId);

			var settings = KitOnlineClient.GetJsonSerializerSettings();
			settings.Formatting = Formatting.Indented;
			output.WriteLine(JsonConvert.SerializeObject(body, settings));
		}

		/// <summary>
		/// Создает тестовый чек
		/// </summary>
		private static Check CreateTestCheck(string? checkId = null)
		{
			checkId ??= Guid.NewGuid().ToString();
			const decimal sumRub = 112.34m;
			return new Check(checkId, 
				sumRub: sumRub,
				pay: new Pay(cashRub: sumRub),
				email: "noreply@yandex.ru",
				phone: null,
				calculationType: CalculationTypeEnum.Incoming,
				taxSystemType: TaxSystemTypeEnum.OSN,
				subjects: Subject.ListOf(TaxTypeEnum.NoTax, 
					PayAttributeTypeEnum.FullPayment, GoodsAttributeTypeEnum.Commodity,
					("Маракуйя", 25m, 2), 
					("Сахар", 50m, 0.5m)
					).Concat(
					Subject.ListOf(TaxTypeEnum.NoTax, 
						PayAttributeTypeEnum.FullPayment, 
						GoodsAttributeTypeEnum.Service,
						("Курьерская доставка", 37.34m, 1m), 
						("Нулевой сервис", 0m, 1m)
					)).ToList());
		}
	}
}