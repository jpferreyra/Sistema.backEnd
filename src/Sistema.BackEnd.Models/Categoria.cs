using Sistema.BackEnd.Models.Base;

namespace Sistema.BackEnd.Models
{
    public class Categoria : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
    }
}
