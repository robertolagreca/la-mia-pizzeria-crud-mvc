namespace LaMiaPizzeriaCategoriaETag.Models
{
    public class Tag
    {

        public int Id { get; set; }
        public string Title { get; set; }



        public List<Pizza> Pizza { get; set; }


        public Tag() { }

    }
}
