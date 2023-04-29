using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrafficWeb.Models
{
    public class FineModel
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; }

        public string VehicleNumber { get;set; }
        public string FineType { get; set; }

        public string Price { get; set; }
           
        public int FineId { get; set; }

        [Required]
        [Display(Name = "DriversAdd")]
        public int DriverId{ get; set; }
        [ForeignKey("DriverId")]
        [ValidateNever]

        public DriversAdd DriversAdd { get; set; }     
        
    }
}
