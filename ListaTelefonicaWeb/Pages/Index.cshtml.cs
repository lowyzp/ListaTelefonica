using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ListaTelefonicaWeb.Pages
{
    public class IndexModel : PageModel
    {
        public List<Contato> Resultado { get; set; }

        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponseMessage = client.GetAsync("https://localhost:44371/api/contacts").Result;

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                HttpContent httpContent = httpResponseMessage.Content;

                string resultString = httpContent.ReadAsStringAsync().Result;

                this.Resultado = JsonSerializer.Deserialize<List<Contato>>(resultString);
            }
        }

        public void OnPost()
        {
            string action = Request.Form["action"];
            string contactId = Request.Form["contact-id"];
            switch (action)
            {
                case "edit":
                    break;
                case "delete":
                    break;
                default:
                    break;
            }
        }
    }
}
