using MamyApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class UserPreferences : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public Language Language { get; set; } 
    public bool ReceiveEmails { get; set; } = true;
    public bool ReceiveNotifications { get; set; } = true;
    public Theme Theme { get; set; }
}
