using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Rpg.Models;
namespace Rpg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : Controller
    {
        private static List<Personagem> lista = new List<Personagem>
            {
                new Personagem
                {
                    Id = 1,
                    Nome = "Peter",
                    Sobrenome = "Parker",
                    Fantasia = "Homem-aranha",
                    Local = "NY city"
                },
                new Personagem
                {
                    Id = 2,
                    Nome = "Wade",
                    Sobrenome = "Wilson",
                    Fantasia = "Deadpool",
                    Local = "NY city"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Personagem>>> LerTodosPersonagens()
        {
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Personagem>>> LerUnicoPersonagem(int id)
        {
            var unico = lista.Find(x => x.Id == id);

            if (unico is null)
                return NotFound("Personagem não encontrado");

            return Ok(unico);
        }

        [HttpPost]
        public async Task<ActionResult<List<Personagem>>> AdicionarPersonagem(Personagem novo)
        {
            lista.Add(novo);
            return Ok(lista);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Personagem>>> AlteraPersonagem(int id, Personagem alterar)
        {
            var unico = lista.Find(x => x.Id == id);
            if (unico is null)
                return NotFound("Personagem não existe");

            unico.Nome = alterar.Nome;
            unico.Sobrenome = alterar.Sobrenome;
            unico.Fantasia = alterar.Fantasia;
            unico.Local = alterar.Local;

            return Ok(unico);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Personagem>>> RemovePersonagem(int id)
        {
            var unico = lista.Find(x => x.Id ==id);

            if (unico is null)
                return NotFound("Personagem não existe");

            lista.Remove(unico);

            return Ok(lista);
        }
    }
}
