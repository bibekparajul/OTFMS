using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrafficWeb.Models
{
    public class PaymentHeader
    {
        public int Id { get; set; }

        public string UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        [ValidateNever]

        public UserModel UserModel { get; set; }

 
        public double FineTotal { get; set; }
        public string? PaymentStatus { get; set; }


        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        [Required]
        public string LicenseNumber { get; set; }



        [Required]
        public string VehicleNumber { get; set; }

        [Required]
        public string City { get; set; }


        [Required]
        public string Address { get; set; }

        [Required]
        public string Name { get; set; }


    }
}
