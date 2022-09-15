namespace BankAPI.ViewModels
{
    public class VMAccount
    {
        public int PersonId { get; set; }
        public int Balance { get; set; }    

        public static Models.Account ToEntity(VMAccount oVMAccount)
        {
            return new Models.Account
            {
                PersonId = oVMAccount.PersonId,
                balance = oVMAccount.Balance
            };
        }
    }
}
