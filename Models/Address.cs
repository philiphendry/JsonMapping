using System.ComponentModel.DataAnnotations;

namespace JsonMapping.Models
{
    public class Address
    {
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9 ,'`\-]*$")]
        public string AddressLine1 { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9 ,'`\-]*$")]
        public string Town { get; set; }

        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[a-zA-Z]{1,2}\d{1,2} ?\d{1,2}[a-zA-Z]{1,2}$")]
        public string PostCode { get; set; }
    }
}