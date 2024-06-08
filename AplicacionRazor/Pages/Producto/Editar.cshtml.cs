using AplicacionRazor.modelos; // Corregido el nombre del espacio de nombres
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks; // Agregado para usar Task

namespace AplicacionRazor.Pages.Cursos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Curso Curso { get; set; }
        [TempData]
        public string Mensaje { get; set; }
        public async Task OnGet(int id)
        {
            Curso = await _contexto.Curso.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoDesdeBD = await _contexto.Curso.FindAsync(Curso.Id); 
                CursoDesdeBD.NombreProducto = Curso.NombreProducto; 
                CursoDesdeBD.Descripcion = Curso.Descripcion; 
                CursoDesdeBD.Stock = Curso.Stock; 
                CursoDesdeBD.Precio = Curso.Precio;

                await _contexto.SaveChangesAsync();
                Mensaje = "Curso Editado";
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
