namespace WebApplication2.Entities
{
    public class Livrod
    {
        public int IdLivro{ get; set; }
        public String NomeLivro { get; set; }
        public String ISBN { get; set; }
        public int IdAutor { get; set; }
        public DateTime DataPub { get;set; }
        public Double PrecoLivro { get; set; }

        public int IdEditora { get; set; }
    }
}
