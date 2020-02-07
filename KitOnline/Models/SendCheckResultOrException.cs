using System;
using System.Threading.Tasks;
using KitOnline.Enums;

namespace KitOnline.Models
{
	/// <summary>
	/// Структура, содержащая ответы отправки и проверки чека,
	/// либо Exception, если во время отправки чека произошла ошибка
	/// </summary>
	public readonly struct SendCheckResultOrException
	{
		public SendCheckResultOrException(
			SendCheck.ResponseBody? sendCheckResponse = null, 
			StateCheck.ResponseBody? stateCheckResponse = null, 
			Exception? exception = null)
		{
			SendCheckResponse = sendCheckResponse;
			StateCheckResponse = stateCheckResponse;
			Exception = exception;
		}

		/// <summary> Ответ на операцию отправки чека </summary>
		public SendCheck.ResponseBody? SendCheckResponse { get; }
		
		/// <summary> Ответ на запрос состояния чека </summary>
		public StateCheck.ResponseBody? StateCheckResponse { get; }
		
		/// <summary> Ошибка при отправке или проверке чека </summary>
		public Exception? Exception { get; }

		
		/// <summary> Состояние чека </summary>
		public CheckStateEnum? State => StateCheckResponse?.CheckState?.State;
		
		/// <summary> Чек успешно отправлен </summary>
		public bool Succeeded => State == CheckStateEnum.Succeeded;
		
		/// <summary> Отправка чека отменена или время истекло </summary>
		public bool CanceledOrTimedOut => Exception?.GetType() == typeof(TaskCanceledException);
	}
}