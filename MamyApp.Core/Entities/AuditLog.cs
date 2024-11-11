using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamyApp.Core.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }  
        public int EntityId { get; set; }  
        public string EntityName { get; set; }  
        public string Action { get; set; }  
        public string OldValue { get; set; }  
        public string NewValue { get; set; }  
        public string PerformedBy { get; set; }  
        public DateTime PerformedAt { get; set; } = DateTime.UtcNow; 
    }
}
