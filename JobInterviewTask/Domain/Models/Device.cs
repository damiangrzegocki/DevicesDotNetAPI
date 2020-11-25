using System;
using System.ComponentModel.DataAnnotations;

namespace JobInterviewTask.Domain.Models
{
    public class Device
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public bool Disabled { get; set; }
    }
}
