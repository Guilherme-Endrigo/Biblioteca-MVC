using System.ComponentModel.DataAnnotations;


namespace BibliotecaImpacta.Models
{
    public class Categoria
    {
        public int Id { get; set; } //Chave primária da tabela no BD


        [Display(Name = "Descrição")]
        [RequiredAttribute(ErrorMessage = "O campo descrição é obrigatório")]

        public string Descricao { get; set; }

    }
}
