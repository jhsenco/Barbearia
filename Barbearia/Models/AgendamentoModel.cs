using System;
using System.Collections.Generic;
using System.Linq;

public class AgendamentoModel
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public int ClienteId { get; set; }
    public int BarbeariaId{ get; set; }
    public int BarbeiroId { get; set; }
    public int ServicoId { get; set; }

    public static implicit operator List<object>(AgendamentoModel v)
    {
        throw new NotImplementedException();
    }
}