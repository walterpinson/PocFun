namespace Infrastructure.PocFunApi.Models
{
    public class ApiMessage<T> : IApiMessage<T> where T : class
    {
        public Message<T> Message  { get; set; }
    }
}