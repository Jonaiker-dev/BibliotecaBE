using BibliotecaBE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LibroDetallesController : ControllerBase
	{
		private readonly BibliotecaContext context;

		public LibroDetallesController(BibliotecaContext context)
		{
			this.context = context;
		}
		// GET: api/<LibroDetallesController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DetalleLibro>>> GetLibrosdetalle()
		{
			return await context.DetalleLibros.ToListAsync();
		}


		[HttpGet("{idlibro}")]
		public async Task<ActionResult<IEnumerable<DetalleLibro>>> GetLibroId(string idlibro) {
			return await context.DetalleLibros.Where(x=>x.Idlibro == idlibro).ToListAsync();

		}
		
	}
}
