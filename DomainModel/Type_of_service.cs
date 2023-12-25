namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Type_of_service
    {
        public int Id { get; set; }

        [Required]
        public string description_of_service { get; set; }

        public int? cost_of_m { get; set; }

        public int? cost_of_m2 { get; set; }

        public int? Order_Id { get; set; }

        public virtual Order Order { get; set; }
    }
}
