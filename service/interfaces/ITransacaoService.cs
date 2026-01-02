namespace service.Interfaces;
using domain.Entities;

public interface ITransacaoService
{
    void Cadastrar(Transacao Entidade);
    void Excluir(int ID);
    List<Transacao> ListarRegistros();
    Transacao RetornarRegistro(int ID);
}