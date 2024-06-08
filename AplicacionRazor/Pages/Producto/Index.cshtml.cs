using AplicacionRazor.modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AplicacionRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [TempData]
        public string Mensaje { get; set; }

        public IList<Curso> Cursos { get; set; }

        public async Task OnGet()
        {
            Cursos = await _contexto.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            var curso = await _contexto.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _contexto.Curso.Remove(curso);
            await _contexto.SaveChangesAsync();
            Mensaje = "Curso Borrado";
            return RedirectToPage("Index");
        }
    }
}
