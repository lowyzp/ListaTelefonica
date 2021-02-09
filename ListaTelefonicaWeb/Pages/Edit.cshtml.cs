using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaTelefonicaWeb.Pages
{
    public class EditModel : PageModel
    {
        public Contato Contato { get; set; }
        public List<CountryCode> CountryCodes { get; set; }

        public EditModel()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponseMessage = client.GetAsync($"https://localhost:44371/api/contacts/countrycodes").Result;

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                HttpContent httpContent = httpResponseMessage.Content;

                string resultString = httpContent.ReadAsStringAsync().Result;

                this.CountryCodes = JsonSerializer.Deserialize<List<CountryCode>>(resultString);
            }

        }
        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(Request.Form["act"]))
            {
                string id = Request.Form["contact-id"];
                HttpClient client = new HttpClient();

                HttpResponseMessage httpResponseMessage = client.GetAsync($"https://localhost:44371/api/contacts/{id}").Result;

                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    HttpContent httpContent = httpResponseMessage.Content;

                    string resultString = httpContent.ReadAsStringAsync().Result;

                    this.Contato = JsonSerializer.Deserialize<Contato>(resultString);
                }
                return Page();
            }
            else
            {
                IFormCollection form = Request.Form;
                HttpClient client = new HttpClient();
                int contactId = int.Parse(form["contactId"]);
                Contato contato = new Contato
                {
                    id = contactId,
                    name = form["editName"],
                    email = form["editEmail"]
                };
                if (form["phoneid"].Count > 0)
                {
                    List<Phone> phones = new List<Phone>();
                    for (int i = 0; i < form["phoneid"].Count; i++)
                    {
                        phones.Add(new Phone
                        {
                            number = form["editNumber"][i],
                            countryCodeId = int.Parse(form["countryCodeId"][i]),
                            marker = form["editMarker"][i]
                            
                        });
                    }
                    contato.phones = phones;
                }
                if (form["addressid"].Count > 0)
                {
                    List<Address> addresses = new List<Address>();
                    for (int i = 0; i < form["addressid"].Count; i++)
                    {
                        addresses.Add(new Address
                        {
                            country = form["editCountry"][i],
                            state = form["editState"][i],
                            city = form["editCity"][i],
                            zip = form["editZip"][i],
                            street = form["editStreet"][i],
                            number = form["editNumber"][i],
                            complement = form["editComplement"][i],
                            marker = form["editMarker"][i]


                        });
                    }
                    contato.addresses = addresses;
                }
                string json = JsonSerializer.Serialize<Contato>(contato);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = client.PutAsync($"https://localhost:44371/api/contacts", content).Result;
                return Redirect("/");
            }
        }

    }
}
