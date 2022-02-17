using ConatctHubspot.Model;
using HubSpot.NET.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConatctHubspot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public ContactsController()
        {        
        }

        [HttpPost]
        public ActionResult CreateContact([FromBody] Contact contactObj)
        {
            var api = new HubSpotApi("2fd2c072-a32d-43fd-9485-f9c9ae435402");

            /*var contactObj = new Contact()
            {
                Email = "john@squaredup.com",
                FirstName = "John",
                LastName = "Smith",
                Phone = "00000 000000",
                Company = "Squared Up Ltd."
            };*/

            var contact = api.Contact.Create(contactObj);
            return Ok(contact);
        }

        [HttpGet]
        public IActionResult GetContact()
        {
            var api = new HubSpotApi("2fd2c072-a32d-43fd-9485-f9c9ae435402");
            var contacts = api.Contact.List<Contact>();
                /*List(
                new ListRequestOptions { PropertiesToInclude = new List<string> { "firstname", "lastname", "email" } });*/

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetByContact(string email)
        {
            var api = new HubSpotApi("2fd2c072-a32d-43fd-9485-f9c9ae435402");
            var contacts = api.Contact.GetByEmail<Contact>(email);

            return Ok(contacts);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(long id)
        {
            var api = new HubSpotApi("2fd2c072-a32d-43fd-9485-f9c9ae435402");
            api.Contact.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(long id, [FromBody] Contact contactObj)
        {
            var api = new HubSpotApi("2fd2c072-a32d-43fd-9485-f9c9ae435402");
            /*var contactObj = new Contact()
            {
                Id= id,
                Email = "john@squaredup.com",
                FirstName = "John",
                LastName = "Smith",
                Phone = "00000 000000",
                Company = "Squared Up Ltd."
            };*/
            api.Contact.Update(contactObj);
            return NoContent();
        }
    }
}
