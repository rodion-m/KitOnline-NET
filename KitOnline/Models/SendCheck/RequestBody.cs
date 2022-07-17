namespace KitOnline.Models.SendCheck
{
    public class RequestBody
    {
        public RequestBody(Request request, Check check)
        {
            Request = request;
            Check = check;
        }

        public Request Request { get; set; }
        public Check Check { get; set; }
    }
}