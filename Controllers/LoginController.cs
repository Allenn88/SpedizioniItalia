using Microsoft.Ajax.Utilities;
using SpedizioniItalia.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;

namespace SpedizioniItalia.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated) return RedirectToAction("Prova");
            return View();
        }
        [HttpGet]
        public ActionResult LoginCliente() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginCliente(Cliente cliente)
        {
            string connString = ConfigurationManager.ConnectionStrings["DbBlogConnection"].ToString();
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();

                var command = new SqlCommand(@"
                    SELECT *
                    FROM Clienti
                    WHERE Nome = @nome AND Cognome = @cognome AND CodiceFiscale = @codiceFiscale
                ", conn);

                command.Parameters.AddWithValue("@nome", cliente.Nome);
                command.Parameters.AddWithValue("@cognome", cliente.Cognome);
                command.Parameters.AddWithValue("@codiceFiscale", cliente.CodiceFiscale);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        FormsAuthentication.SetAuthCookie(reader["IDCliente"].ToString(), true);
                        return RedirectToAction("Admin", "Admin"); // TODO: alla pagina di pannello
                    }
                }
            }

            TempData["ErrorLogin"] = true;
            return RedirectToAction("LoginCliente");
        }
        [HttpGet]
        public ActionResult LoginAzienda() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAzienda(Azienda azienda)
        {
            string connString = ConfigurationManager.ConnectionStrings["DbBlogConnection"].ToString();
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();

                var command = new SqlCommand(@"
                    SELECT *
                    FROM Azienda
                    WHERE Nome = @nome AND PartitaIva = @partitaIva
                ", conn);

                command.Parameters.AddWithValue("@nome", azienda.Nome);
                command.Parameters.AddWithValue("@partitaIva", azienda.PartitaIva);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        FormsAuthentication.SetAuthCookie(reader["IDAzienda"].ToString(), true);
                        return RedirectToAction("Admin", "Admin"); // TODO: alla pagina di pannello
                    }
                }
            }

            TempData["ErrorLogin"] = true;
            return RedirectToAction("LoginAzienda");
        }
    }
}
