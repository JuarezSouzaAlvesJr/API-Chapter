using System.ComponentModel.DataAnnotations;

namespace ChapterFST2.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Senha { get; set; }
    }
}
