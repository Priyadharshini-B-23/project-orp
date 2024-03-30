using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Crud_Operations.Models
{
    public class MailModel
    {

            public int id { get; set; }

            [Required]
            public string Date { get; set; }

            [Required]
            public string Time { get; set; }

            [Required]
            public string? Location { get; set; }

        public string Recruiter { get; set; }


        [Required]
        public long? Contact { get; set; }

        [DefaultValue("Pending")]
            public string? Status { get; set; }
        public string Mail { get; set; }


        }
    }

