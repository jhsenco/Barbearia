namespace Barbearia.Models
{
    public class BarbeariaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; } //? usado para informar que o campo posso ser nulo 
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
    }
}
