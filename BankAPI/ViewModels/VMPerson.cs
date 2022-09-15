using System.ComponentModel.DataAnnotations;

namespace BankAPI.ViewModels
{
    public class VMPerson
    {
        public string UserName { get; set; }         
        public string UserEmail { get; set; }         
        public string Password { get; set; }         
        public string Cedula { get; set; }

        public static Models.Person ToEntity(VMPerson oVMPerson)
        {
            return new Models.Person 
            {
                UserName = oVMPerson.UserName,
                UserEmail = oVMPerson.UserEmail,
                Password = oVMPerson.Password,
                Cedula = oVMPerson.Cedula
            };
        }
    }
}
