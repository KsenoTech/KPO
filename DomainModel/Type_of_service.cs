using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public partial class Type_of_service
    {
        public int Id { get; set; }

        [Required]
        public string description_of_service { get; set; }

        public int? cost_of_m { get; set; }

        public int? cost_of_m2 { get; set; }
    }
}
