using System.Threading;
using System.Threading.Tasks;
using KitOnline.Models.SendCheck;
using Refit;

namespace KitOnline
{
    [Headers("Content-Type: application/json; charset=utf-8")]
    internal interface IKitOnlineClient
    {
        [Post("/WebService.svc/SendCheck")]
        Task<ResponseBody> SendCheck(RequestBody request, CancellationToken cancellationToken);

        [Post("/WebService.svc/StateCheck")]
        Task<Models.StateCheck.ResponseBody> StateCheck(
            Models.StateCheck.RequestBody request, CancellationToken cancellationToken);
    }
}