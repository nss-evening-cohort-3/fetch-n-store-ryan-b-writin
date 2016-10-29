using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FetchNStore.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public int ResponseTime { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public DateTime SendDate { get; set; }
    }
}