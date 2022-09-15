using BankAPI.Repository;
using BankAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepository _person;

        public PeopleController(IPersonRepository person)
        {
            _person = person ?? throw new ArgumentNullException(nameof(person));
        }

        [HttpGet]
        [Route("GetPeople")]
        public async Task<IActionResult> GetAllPeople()
        {
            return Ok(await _person.GetPeople());
        }

        [HttpGet]
        [Route("GetPersonById/{id}")]
        public async Task<IActionResult> GetAPersonById(int id)
        {
            return Ok(await _person.GetPersonById(id));
        }

        [HttpPost]
        [Route("AddPerson")]
        public async Task<IActionResult> PostAddPerson(VMPerson vMPerson)
        {
            return Ok(await _person.InsertPerson(VMPerson.ToEntity(vMPerson)));
        }

        [HttpPut]
        [Route("UpdatePerson")]
        public async Task<IActionResult> UpdateAPerson(VMPerson vMPerson)
        {
            return Ok(await _person.UpdatePerson(VMPerson.ToEntity(vMPerson)));
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public JsonResult DeletePerson(int id)
        {
            _person.DeletePerson(id);
            return new JsonResult("Eliminado Exitosamente");
        }
    }
}
