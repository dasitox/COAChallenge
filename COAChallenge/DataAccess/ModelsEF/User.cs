using System.ComponentModel.DataAnnotations;

namespace COAChallenge.DataAccess.ModelsEF
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]        
        [MaxLength(20)]
        public string Telephone { get; set; }

        public bool IsActive { get; set; }
    }
}
