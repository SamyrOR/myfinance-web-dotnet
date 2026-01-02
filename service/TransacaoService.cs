
using service.Interfaces;
using domain.Entities;
using infra;
using Microsoft.EntityFrameworkCore;


namespace service
{
    public class TransacaoService: ITransacaoService
    {
        private readonly MyFinanceDBContext _dbContext;
        public TransacaoService(MyFinanceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Cadastrar(Transacao Entidade)
        {
            var dbSet = _dbContext.Transacao;
            if(Entidade.ID == null)
            {
                dbSet.Add(Entidade);
            } else
            {
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }
                public void Excluir(int ID)
        {
            var Transacao = new Transacao() {ID = ID};
            _dbContext.Attach(Transacao);
            _dbContext.Remove(Transacao);
            _dbContext.SaveChanges();

        }
                public List<Transacao> ListarRegistros()
        {
            var dbSet = _dbContext.Transacao;
            return dbSet.ToList();
        }
                public Transacao RetornarRegistro(int ID)
        {
            return _dbContext.Transacao.Where(transacao => transacao.ID == ID).First();
        }
    }
}