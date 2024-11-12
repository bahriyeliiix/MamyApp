using MamyApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public bool IsEmailVerified { get; set; } = false;
    public DateTime? LastLoginDate { get; set; }
}
