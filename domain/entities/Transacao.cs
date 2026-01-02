namespace domain.Entities;

public class Transacao
{
    public int? ID {get; set;}
    public string Historico {get; set;}
    public DateTime Data {get; set;}
    public decimal Valor {get; set;}
    public int PlanoContaID {get; set;}
    public PlanoConta PlanoConta {get; set;}
}