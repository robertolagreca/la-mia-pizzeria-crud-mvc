namespace LaMiaPizzeriaModel.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Pizza> Pizza { get; set; }

        public Category() { }

    }
}
