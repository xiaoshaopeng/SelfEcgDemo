using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEcgDemo.Models.EF
{
    public class t_signature
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int doctorId { get; set; }
        [Required]
        public string signatureFile { get; set; }
    }
}