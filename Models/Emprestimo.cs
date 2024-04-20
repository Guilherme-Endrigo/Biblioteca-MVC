using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BibliotecaImpacta.Models
{
    public class Emprestimo
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A confirmação de empréstimo é obrigatória")]
        public bool? Confirmado { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public  DateTime? DataDevolucao { get; set; }
       
        [DisplayName("Selecione o Livro")]
        public int LivroId { get; set; }

        [DisplayName("Selecione o nome do livro")]
        public Livro Livro { get; set; }

       


    }
}
