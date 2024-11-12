using MamyApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class UserProfile : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string Address { get; set; }
}
