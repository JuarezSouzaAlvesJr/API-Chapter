namespace ChapterFST2.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public string? Tipo { get; set; }

    }
}

//sequência: 1.classe - 2.interface - 3.repository - 4.controller