namespace DomainModel
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Type_of_service = new HashSet<Type_of_service>();
        }

        public int Id { get; set; }

        public int? executor_ID { get; set; }

        public int client_ID { get; set; }

        [Required]
        public string description { get; set; }

        public DateTime time_order { get; set; }

        public int general_budget { get; set; }

        public int progress { get; set; }

        public int? feedback_ID { get; set; }

        public bool IsItFinished { get; set; }

        public bool canIdoIt { get; set; }

        public Position OrderPosition { get; set; }

        public virtual Client Client { get; set; }

        public virtual Executor Executor { get; set; }

        public virtual Feedback Feedback { get; set; }

        
        public virtual ICollection<Type_of_service> Type_of_service { get; set; }
    }
    public enum Position
    {
        InProgress,
        Applied,
        Rejected,
        Finished
    }
}
