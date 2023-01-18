namespace LaMiaPizzeriaModelConOrdini.Models
{
    public class PizzaCategoriesView
    {
        // Il post vuoto che il mio form dovrà compilare
        public Pizza Pizza { get; set; } 

        // Questa lista di categories servirà per la select nel from in modo che possa far visualizzare all'utente
        // tutte le categorie da cui poter selezionare un opzione per il Post
        public List<Category>? Categories { get; set; }
    }
}
