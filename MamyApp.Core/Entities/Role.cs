using MamyApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class Role : BaseEntity
{
    public string Name { get; set; } // Rol ismi, örneğin: Admin, User, Moderator

    public string Description { get; set; } // Rol açıklaması

    public ICollection<UserRole> UserRoles { get; set; } // Kullanıcı-Rol ilişkisi

    public ICollection<RolePermission> RolePermissions { get; set; } // Rol-Permission ilişkisi
}
