using System.Text.Json.Serialization;

namespace WebAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        HR,
        Finance,
        CustomerService,
        Jailbreaking
    }
}
