using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrafficWeb.Models
{
    public class DriversAdd
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public string? VechineType { get; set; }
        public string VechileNumber { get; set; }

        public string LicenseNumber { get; set; }

        
        public string? Address { get; set; }


    }
}
