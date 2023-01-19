namespace LaMiaPizzeriaConCategoriaEOrdini.Models
{
    public class Order
    {

        public int Id { get; set; }
        public string Name { get; set; }


        public int PizzaId { get; set; }
        public Pizza Pizza { get; set;}

        
        public Order()
        {

        }
    }


}
