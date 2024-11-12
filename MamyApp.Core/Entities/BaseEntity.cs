using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamyApp.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  
        public DateTime? DeletedAt { get; set; }  
        public bool IsDeleted { get; set; } = false;  
        public string CreatedBy { get; set; }  
        public string UpdatedBy { get; set; } 
        public string DeletedBy { get; set; } 
        public string RowVersion { get; set; }  
    }
}
