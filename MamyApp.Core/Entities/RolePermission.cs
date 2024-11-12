using MamyApp.Core.Entities;

public class RolePermission : BaseEntity
{
    public int RoleId { get; set; }
    public Role Role { get; set; } // Rol ile ilişki

    public int PermissionId { get; set; }
    public Permission Permission { get; set; } // İzin ile ilişki
}
