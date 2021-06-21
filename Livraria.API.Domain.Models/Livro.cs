using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.API.Domain.Models
{
    public class Livro
    {
        [Key]
        public int ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string DataPublicacao { get; set; }
        public string ImagemCapa { get; set; }
    }
}
