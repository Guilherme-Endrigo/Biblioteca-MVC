using BibliotecaImpacta.Models;
using System.Collections.Generic;
using System.ComponentModel;


namespace BibliotecaImpacta.ViewModels
{
    public class EmprestadosViewModel
    {
        [DisplayName("Digite o Nome para Busca")]
        public string Search { get; set; }

        public IEnumerable<Emprestimo> Emprestados { get; set; }
    }
}
