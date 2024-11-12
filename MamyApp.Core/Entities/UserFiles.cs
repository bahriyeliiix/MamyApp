using MamyApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class UserFiles : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public string FileName { get; set; }

    public string FilePath { get; set; }

    public FileType FileType { get; set; }

    public long FileSize { get; set; }

    public DateTime? UploadDate { get; set; } = DateTime.UtcNow;
}
