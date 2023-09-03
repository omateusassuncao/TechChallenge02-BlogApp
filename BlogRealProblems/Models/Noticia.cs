using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BlogRealProblems.Models
{
    public class Noticia
    {
        public Noticia(string titulo, string descricao, string chapeu, /*DateTime dataPublicacao,*/ string autor)
        {
            Titulo = titulo;
            Descricao = descricao;
            Chapeu = chapeu;
            DataPublicacao = DateTime.UtcNow;
            Autor = autor;
        }


        [Key]
        [Required]
        [DataMember]
        public int Id { get; protected set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Chapeu { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get; set; }
    }
}
