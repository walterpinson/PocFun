namespace Infrastructure.PocFunApi.Models
{
    public interface IMetadata
    {
        string ItemsType { get; set; }
        string DateTimeFormat { get; set; }
        string MsgFormatVer { get; set; }
    }
}
