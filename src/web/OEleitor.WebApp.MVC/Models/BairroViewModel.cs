using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OEleitor.WebApp.MVC.Models
{
    public class BairroViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Nome do Bairro")]
        public string BairroNome { get; set; }
    }
}