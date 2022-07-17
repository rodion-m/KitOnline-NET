namespace KitOnline.Models.StateCheck
{
    public class RequestBody
    {
        // ReSharper disable once NotAccessedField.Global
        public Request Request;

        public RequestBody(Request request, string checkNumber)
        {
            Request = request;
            CheckNumber = checkNumber;
        }

        public string CheckNumber { get; set; }
    }
}