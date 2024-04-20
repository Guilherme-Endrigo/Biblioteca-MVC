using System.Linq;

namespace BibliotecaImpacta.Models
{
   public interface IRepositorio
    {
        IQueryable<Emprestimo> Emprestimos { get; }
        void AdicionaEmprestimo(Emprestimo emprestimo);
        void Update(Emprestimo emprestimo);
        void Remove(Emprestimo emprestimo);
    }
}
