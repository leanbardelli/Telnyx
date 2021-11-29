using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public ActionResult InboundFax(myDeserializedClass json)
        {
            try
            {
                //Just dummy test
                if (json.meta.attempt == 1)
                {
                    return Content("OK");
                }
                else {
                    return Content("NO");
                }
                //Work directly with json as object, forget "root" is: myDeserializedClass
              
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }


    }




    public class Payload
    {
        public int call_duration_secs { get; set; }
        public string connection_id { get; set; }
        public string direction { get; set; }
        public string fax_id { get; set; }
        public string from { get; set; }
        public string media_url { get; set; }
        public int page_count { get; set; }
        public bool? partial_content { get; set; }
        public string status { get; set; }
        public string to { get; set; }
        public string user_id { get; set; }
    }

    public class Data
    {
        public string event_type { get; set; }
        public string id { get; set; }
        public DateTime occurred_at { get; set; }
        public Payload payload { get; set; }
        public string record_type { get; set; }
    }

    public class Meta
    {
        public int attempt { get; set; }
        public string delivered_to { get; set; }
    }

    public class myDeserializedClass
    {
        public Data data { get; set; }
        public Meta meta { get; set; }
    }



}
