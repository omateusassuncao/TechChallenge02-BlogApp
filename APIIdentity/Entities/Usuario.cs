using System.ComponentModel.DataAnnotations;

namespace APIIdentity.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, MaxLength(80, ErrorMessage = "Não pode exceder 80 caractéres")]
        public string? Nome { get; set; }
        
        [EmailAddress]
        [Required, MaxLength(120)]
        public string? Email { get; set; }

        public int Idade { get; set; }


    }
}
