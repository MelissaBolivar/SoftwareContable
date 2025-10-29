

namespace Contable.Application.Dtos.Servicio

{
    public class CreateServicioDto
    {
        public int ServicioId { get; set; }

        public required int Codigo { get; set; }
        public required string Nombre { get; set; }
    }
}
