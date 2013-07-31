namespace Infrastructure.PocFunApi.Models
{
    public interface IApiMessage<T> where T : class
    {
        Message<T> Message { get; set; }
    }
}