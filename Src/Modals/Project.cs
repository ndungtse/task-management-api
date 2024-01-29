using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_management_api.Modals;


public class Project: BaseModel
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid TeamId { get; set; } // Foreign key
    public virtual List<ToDo> Tasks { get; set; }
    public Team Team { get; set; }
    public virtual User CreatedBy { get; set; }
}