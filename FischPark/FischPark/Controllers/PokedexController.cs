using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using PokeAPI;
using FischPark.Models;
using System.Threading.Tasks;
using System.Globalization;

namespace FischPark.Controllers
{
    public class PokedexController : Controller
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["FischParkConnectionString"].ConnectionString;
        IDbConnection conn = new SqlConnection(ConnectionString);
        
        public async Task<ActionResult> Index()
        {
            List<PokedexModel> pokedex;

            pokedex = conn.Query<PokedexModel>("pkmn.Pokedex_List", commandType: CommandType.StoredProcedure).ToList();
            PokedexViewModel viewModel = new PokedexViewModel(pokedex);

            foreach (var pokemon in viewModel.pokedex)
            {
                PokemonSpecies p = await DataFetcher.GetApiObject<PokemonSpecies>(pokemon.Pokedex_ID.Value);
                pokemon.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.Name);
            }

            foreach (var pokemon in viewModel.pokedex)
            {
                if (pokemon.Percentage == "0")
                {
                    pokemon.BackgroundColor = "#FFFFFF";
                }
                else if (pokemon.Percentage == "25")
                {
                    pokemon.BackgroundColor = "#C1C7F9";
                }
                else if (pokemon.Percentage == "50")
                {
                    pokemon.BackgroundColor = "#979EEE";
                }
                else if (pokemon.Percentage == "75")
                {
                    pokemon.BackgroundColor = "#6871D5";
                }
                else if (pokemon.Percentage == "100")
                {
                    pokemon.BackgroundColor = "#384498";
                }
            }

                return View(viewModel);
        }

        public ActionResult UpdateIndex()
        {
            return View();
        }

        public ActionResult UpdateGetID(PokedexModel model)
        {
            return PartialView("_UpdateGetID", model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateGet(PokedexModel model)
        {
            if (model.Pokedex_ID > 0)
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@Pokedex_ID", model.Pokedex_ID.Value, DbType.Int32);

                model = conn.Query<PokedexModel>("pkmn.Pokedex_Get", param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                PokemonSpecies pkmn = await DataFetcher.GetApiObject<PokemonSpecies>(model.Pokedex_ID.Value);
                model.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pkmn.Name);
            }
            
            return PartialView("_UpdateForm", model);
        }

        [HttpPost]
        public ActionResult UpdateFinal(PokedexModel model)
        {
            if (model.Pokedex_ID > 0)
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@Pokedex_ID", model.Pokedex_ID.Value, DbType.Int32);
                p.Add("@Male", model.Male, DbType.String);
                p.Add("@Female", model.Female, DbType.String);
                p.Add("@Shiny", model.Shiny, DbType.String);
                p.Add("@Lucky", model.Lucky, DbType.String);

                model = conn.Query<PokedexModel>("pkmn.Pokedex_Update", param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            ModelState.Clear();

            return PartialView("_UpdateGetID", model);
        }


        public async Task<string> GetPokemonName(int pokedex_ID)
        {
            PokemonSpecies p = await DataFetcher.GetApiObject<PokemonSpecies>(pokedex_ID);
            string Return = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.Name);

            return Return;
        }
    }
}