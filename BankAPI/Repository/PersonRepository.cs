using BankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Repository
{
    public class PersonRepository : IPersonRepository
    {
        readonly ApiDbContext _apiDbContext;

        public PersonRepository(ApiDbContext context)
        {
            _apiDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool DeletePerson(int id)
        {
            bool result = false;
            var person = _apiDbContext.People.Find(id);
            if(person != null)
            {
                result = true;
                _apiDbContext.Entry(person).State = EntityState.Deleted;
                _apiDbContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await _apiDbContext.People.ToListAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _apiDbContext.People.FindAsync(id);
        }

        public async Task<Person> InsertPerson(Person objPerson)
        {
            _apiDbContext.People.Add(objPerson);
            await _apiDbContext.SaveChangesAsync();
            return objPerson;
        }

        public async Task<Person> UpdatePerson(Person objPerson)
        {
            _apiDbContext.Entry(objPerson).State = EntityState.Modified;
            await _apiDbContext.SaveChangesAsync();
            return objPerson;
        }
    }
}
