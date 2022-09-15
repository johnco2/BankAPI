
using BankAPI.Models;

namespace BankAPI.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetPersonById(int id);
        Task<Person> InsertPerson(Person objPerson);
        Task<Person> UpdatePerson(Person objPerson);
        bool DeletePerson(int id);
    }
}
