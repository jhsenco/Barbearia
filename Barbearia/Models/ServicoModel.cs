namespace Barbearia.Models
{
    public class ServicoModel
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Tipo { get; set;}

        public int? BarbeiroId { get; set; }

        public virtual BarbeiroModel? Barbeiro { get; set; }
    }
}
