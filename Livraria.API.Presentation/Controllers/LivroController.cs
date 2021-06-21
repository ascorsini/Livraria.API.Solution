using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.API.Domain.Models;
using Livraria.API.Infra.Repository.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livraria.API.Presentation.Controllers
{
    [ApiController]
    [Route("v1/livros")]
    public class LivroController : ControllerBase
    {       
        [Route("ObterTodos")]
        [HttpPost]
        public async Task<ActionResult<List<Livro>>> ObterTodos([FromServices] DataContext context)
        {
            var livros = await context.Livro.ToListAsync();
            return livros;
        }

        [Route("{ISBN:int}")]
        [HttpGet]
        public async Task<ActionResult<Livro>> GetById([FromServices] DataContext context, int ISBN)
        {
            var livro = await context.Livro.FirstOrDefaultAsync(x => x.ISBN == ISBN);
            return livro;
        }

        [Route("{campo}/{valor}")]
        [HttpPost]
        public async Task<ActionResult<List<Livro>>> GetByEntity([FromServices] DataContext context, string campo, string valor)
        {
            List<Livro> livros = null;

            if ((campo.ToUpper() == "ISBN") && (valor != "") && (valor != "0"))
                livros = await context.Livro.Where(x => x.ISBN == Convert.ToInt32(valor)).ToListAsync();
            else if ((campo == "Autor") && (valor != ""))
                livros = await context.Livro.Where(x => x.Autor == valor).ToListAsync();
            else if ((campo == "Nome") && (valor != ""))
                livros = await context.Livro.Where(x => x.Nome == valor).ToListAsync();
            else if ((campo == "Preco") && (valor != "") && (valor != "0"))
                livros = await context.Livro.Where(x => x.Preco == valor).ToListAsync();
            else if ((campo == "Data") && (valor != ""))
                livros = await context.Livro.Where(x => x.DataPublicacao == valor).ToListAsync();
            else if ((campo == "Imagem") && (valor != ""))
                livros = await context.Livro.Where(x => x.Autor == valor).ToListAsync();

            return livros;
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult<Livro>> Post([FromServices] DataContext context, Livro livro)
        {
            if (ModelState.IsValid)
            {
                context.Livro.Add(livro);
                await context.SaveChangesAsync();
                return livro;
            }
            else
                return BadRequest(ModelState);
        }

        [Route("")]
        [HttpPut]
        public async Task<ActionResult<Livro>> Update([FromServices] DataContext context, Livro livro)
        {
            if (ModelState.IsValid)
            {
                context.Livro.Update(livro);
                await context.SaveChangesAsync();
                return livro;
            }
            else
                return BadRequest(ModelState);
        }

        [Route("{ISBN:int}")]
        [HttpDelete]
        public async Task<ActionResult<Livro>> Delete([FromServices] DataContext context, int ISBN)
        {
            var livro = await context.Livro.FirstOrDefaultAsync(x => x.ISBN == ISBN);
            context.Livro.Remove(livro);
            await context.SaveChangesAsync();
            return livro;
        }
    }
}
