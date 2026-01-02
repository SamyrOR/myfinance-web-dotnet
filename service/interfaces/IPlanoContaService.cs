namespace service.Interfaces;

using domain.Entities;

public interface IPlanoContaService
{
    void Cadastrar(PlanoConta Entidade);
    void Excluir(int ID);
    List<PlanoConta> ListarRegistros();
    PlanoConta RetornarRegistro(int ID);

}
