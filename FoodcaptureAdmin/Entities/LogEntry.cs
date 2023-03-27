using System;
namespace FoodcaptureAdmin.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using FoodcaptureAdmin.Common.Enums;
    using Volo.Abp.Domain.Entities.Auditing;


    [Table("LogEntry")]
    public class LogEntry : AuditedAggregateRoot<Guid>
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        public string? Message { get; set; }

        public string? Exception { get; set; }

        public string? StackTrace { get; set; }

        public ELogLevel LogLevel { get; set; }

        public DateTime? DateTime { get; set; }
    }
}

