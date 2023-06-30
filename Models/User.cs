using System.ComponentModel.DataAnnotations;

namespace norbit.crm.strashko.careertasks.backend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = "";

        [Required]
        public int Age { get; set; } = 0;
    }
}
