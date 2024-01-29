using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using task_management_api.Enums;

namespace task_management_api.Dtos.Requests;

public class CreateTeamMemberDto
{
    // [EnumDataType(typeof(EMemberRole))]
    // [JsonConverter(typeof(JsonStringEnumConverter))]
    public string Role { get; set; } = EMemberRole.Member.ToString();
    public Guid TeamId { get; set; }
    public Guid UserId { get; set; }
}