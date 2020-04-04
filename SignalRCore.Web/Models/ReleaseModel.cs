using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRCore.Web.Models
{
    [Table("Release")]
    public class ReleaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Version { get; set; }
        public DateTime? VersionUpdate { get; set; }
    }
}