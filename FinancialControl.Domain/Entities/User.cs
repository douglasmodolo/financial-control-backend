using Microsoft.AspNetCore.Identity;

namespace FinancialControl.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; private set; }

        public ICollection<Category> Categories { get; private set; } = new List<Category>();
        public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();

        public User(string fullName, string email, string userName)
        {
            FullName = fullName;
            Email = email;
            UserName = userName;
        }
    }
}
