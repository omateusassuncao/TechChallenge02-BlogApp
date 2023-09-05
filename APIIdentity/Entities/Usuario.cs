using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace APIIdentity.Entities
{
    public class Usuario
    {
        public Usuario(int id, string? nome, string? email, int idade)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Idade = idade;
        }


        [Key]
        [Required]
        [DataMember]
        public int Id { get; protected set; }

        [Required, MaxLength(80, ErrorMessage = "Não pode exceder 80 caractéres")]
        public string? Nome { get; set; }
        
        [EmailAddress]
        [Required, MaxLength(120)]
        public string? Email { get; set; }

        public int Idade { get; set; }


    }
}
