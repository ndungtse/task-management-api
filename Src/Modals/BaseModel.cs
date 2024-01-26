using System.ComponentModel.DataAnnotations;

namespace task_management_api.Modals;

public abstract class BaseModel
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // timestamp for concurrency control
    // [Timestamp]
    // public byte[] RowVersion { get; set; } 
}