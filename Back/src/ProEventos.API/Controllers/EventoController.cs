using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    public IEnumerable<Evento>  _evento = new Evento[] {
            new Evento(){
                EventoId = 1,
                Local = "São Paulo",
                Tema = "Angular 11",
                Lote = "1º Lote",
                QtdPessoas = 200,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                ImagenURL = "localhost.png"
        },
        new Evento(){
                EventoId = 2,
                Local = "São Paulo",
                Tema = ".Net",
                Lote = "2º Lote",
                QtdPessoas = 600,
                DataEvento = DateTime.Now.AddDays(6).ToString("dd/MM/yyyy"),
                ImagenURL = "localhost.png"
        }
       };
    public EventoController()
    {

    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById( int id)
    {
        return _evento.Where(evento => evento.EventoId == id );
    }

    [HttpPost]
    public string Post()
    {
        return "johnatan Post";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"johnatan Put {id}";
    }


    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return $"johnatan Delete {id}";
    }
}
