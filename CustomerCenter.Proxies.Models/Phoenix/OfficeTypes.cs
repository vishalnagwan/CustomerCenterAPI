using System.Text.Json.Serialization;

namespace Uniban.GlassFileData.Proxies.Models.Phoenix
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OfficeTypes
    {
        Main = 1,
        Accounting = 2,
        CallCenter = 3,
        Undefined = 999
    };
}