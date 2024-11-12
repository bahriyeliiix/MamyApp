using MamyApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class Permission : BaseEntity
{
    public string Name { get; set; } // İzin ismi, örneğin: "ViewReports", "EditUsers", "DeletePosts"

    public string Description { get; set; } // İzin açıklaması
}
