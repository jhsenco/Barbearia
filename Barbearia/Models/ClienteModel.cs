namespace Barbearia.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; } //? usado para informar que o campo posso ser nulo 
        public string? Telefone { get; set; }
    }
}
