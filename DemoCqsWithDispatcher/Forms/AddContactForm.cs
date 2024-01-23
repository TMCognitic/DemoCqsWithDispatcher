using System.ComponentModel.DataAnnotations;

namespace DemoCqsWithDispatcher.Forms
{
    public class AddContactForm
    {
        [Required]
        public string Nom { get; set; } = default!;
        [Required]
        public string Prenom { get; set; } = default!;
    }
}
