using Microsoft.AspNetCore.Identity;

namespace Accounting.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
