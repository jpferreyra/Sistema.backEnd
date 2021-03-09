using Sistema.BackEnd.Models.Base;

namespace Sistema.BackEnd.Models.Dtos
{
    public class CategoriaDto 
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
    }
}
