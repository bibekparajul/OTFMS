using System.ComponentModel.DataAnnotations;

namespace OnlineTrafficWeb.Models
{
    public class TrafficAdd
    {
        [Key]
        public int Id { get; set; }

        public string OfficerId { get; set; }

        public string Name { get; set; }

        public string Post { get; set; }

        public string Address { get; set; }
    }

}
