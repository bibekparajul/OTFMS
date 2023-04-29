using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrafficWeb.Models
{
    public class FinePay
    {
        public int Id { get; set; }

        public int FineId { get; set; }

        [ForeignKey("FineId")]
        [ValidateNever]
        public FineModel FineModel { get; set; }

        public string UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        [ValidateNever]
        public UserModel UserModel { get; set; }

        public double Price { get; set; }
    }
}
