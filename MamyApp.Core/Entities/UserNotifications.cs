using MamyApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class UserNotifications : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public NotificationType NotificationType { get; set; }

    public string Message { get; set; }

    public bool IsRead { get; set; } = false;

    public DateTime? ReadDate { get; set; }
}
