using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FischPark.Models
{
    public class PokedexModel
    {
        [Display(Name = "Pokedex Number")]
        public int? Pokedex_ID { get; set; }

        public string Male { get; set; }

        public string Female { get; set; }

        public string Shiny { get; set; }

        public string Lucky { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Percentage { get; set; }

        public string BackgroundColor { get; set; }

        public PokedexModel(int? pokedex_ID, string male, string female, string shiny, string lucky, string percentage)
        {
            this.Pokedex_ID = pokedex_ID;
            this.Male = male;
            this.Female = female;
            this.Shiny = shiny;
            this.Lucky = lucky;
            this.Percentage = percentage;
        }

        public PokedexModel() { }
    }

    public class PokedexViewModel
    {
        public List<PokedexModel> pokedex;

        public PokedexViewModel(List<PokedexModel> dataModel)
        {
            pokedex = new List<PokedexModel>();
            foreach (var item in dataModel)
            {
                pokedex.Add(new PokedexModel(item.Pokedex_ID, item.Male, item.Female, item.Shiny, item.Lucky, item.Percentage));
            }

        }
    }
}