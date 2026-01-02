
using service.Interfaces;
using domain.Entities;
using infra;
using Microsoft.EntityFrameworkCore;


namespace service
{
    public class PlanoContaService: IPlanoContaService
    {
        private readonly MyFinanceDBContext _dbContext;
        public PlanoContaService(MyFinanceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Cadastrar(PlanoConta Entidade)
        {
            var dbSet = _dbContext.PlanoConta;
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
            var PlanoConta = new PlanoConta() {ID = ID};
            _dbContext.Attach(PlanoConta);
            _dbContext.Remove(PlanoConta);
            _dbContext.SaveChanges();

        }
                public List<PlanoConta> ListarRegistros()
        {
            var dbSet = _dbContext.PlanoConta;
            return dbSet.ToList();
        }
                public PlanoConta RetornarRegistro(int ID)
        {
            return _dbContext.PlanoConta.Where(planoConta => planoConta.ID == ID).First();
        }
    }
}