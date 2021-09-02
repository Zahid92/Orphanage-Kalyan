using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Orphanage_Kalyan.Models;
using Newtonsoft.Json;
using System.Text;

namespace Orphanage_Kalyan.Controllers
{
    public class OrphanageController : Controller
    {
        // GET: Orphanage
        public ActionResult Index()
        {
            return View();
        }

        // GET: Orphanage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orphanage/Create
        public ActionResult Registration()
        {
            return View();
        }

        // POST: Orphanage/Create
        [HttpPost]
        public ActionResult Registration(FormCollection collection)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    Orphanage o = new Orphanage
                    {
                        Address = collection["Address"],
                        Contact = Convert.ToInt32(collection["Contact"]),
                        Country = collection["Country"],
                        District = collection["District"],
                        Email = collection["Email"],
                        Name = collection["Name"],
                        Password = collection["Password"],
                        Pincode = Convert.ToInt32(collection["Pincode"]),
                        RegistrationId = Convert.ToInt32(collection["RegistrationId"]),
                        State = collection["State"]
                    };
                    Console.WriteLine("Something Happende");
                    

                    //var Data = new HttpClient();
                    //var endpoint = "/api/registration";
                    //var response = await client.PostAsJsonAsync(endpoint, o);
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    return RedirectToAction("Index");
                    //}
                    using(var cnt= new HttpClient())
                    {
                        cnt.BaseAddress = new Uri("");
                        cnt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage msg = cnt.PostAsync("api/Register", new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json")).Result;
                        if (msg.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here

            }
            catch
            {
                return View();
            }
        }

     
    }
}
