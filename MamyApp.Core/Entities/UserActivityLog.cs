using MamyApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class UserActivityLog : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public ActivityType ActivityType { get; set; }

    public string Description { get; set; }

    public DateTime ActivityDate { get; set; } = DateTime.UtcNow;
}
