using KitOnline.Enums;

namespace KitOnline.Models
{
	public class CheckState
	{
		/// <summary>
		/// Cтатус обработки чека
		/// </summary>
		public CheckStateEnum State { get; set; }
		
		/// <summary>
		/// Код ошибки обработки
		/// Присутствует только в случае если <see cref="State"/> равен <see cref="CheckStateEnum.Failed"/>
		/// </summary>
		public CheckErrorCodeEnum? ErrorCode { get; set; }
	}
}