using MamyApp.Core.Entities;

public class UserRole : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } // Kullanıcı ile ilişki

    public int RoleId { get; set; }
    public Role Role { get; set; } // Rol ile ilişki
}
