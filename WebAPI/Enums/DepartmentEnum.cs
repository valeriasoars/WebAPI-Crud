using System.Text.Json.Serialization;

namespace WebAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        RH,
        Finanças,
        Atendimento
    }
}
