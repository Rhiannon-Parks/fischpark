using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using FischPark.Models;

namespace FischPark.Controllers
{
    public class PkmnBiomesController : Controller
    {

        public ActionResult Index()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["FischParkConnectionString"].ConnectionString;
            IDbConnection conn = new SqlConnection(ConnectionString);

            List<PkmnBiomesModel> castResults;

            castResults = conn.Query<PkmnBiomesModel>("pkmn.Biomes_List", commandType: CommandType.StoredProcedure).ToList();

            PkmnBiomesViewModel viewModel = new PkmnBiomesViewModel(castResults);

            return View(viewModel);
        }
    }
}