using Livraria.API.Domain.Models;
using Livraria.API.Infra.Repository;
using System.Collections.Generic;

namespace Livraria.API.Domain.Services
{
    public class LivroService
    {
        private readonly LivroRepository livroRepository;

        public LivroService()
        {
            livroRepository = new();
        }

        public IEnumerable<Livro> Selecionar(Livro livro)
        {
            return livroRepository.Selecionar(livro);
        }
    }
}
