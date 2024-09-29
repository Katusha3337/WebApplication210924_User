using Microsoft.AspNetCore.Mvc;
using WebApplication210924_User.Models;

namespace WebApplication210924_User.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>
    {
        new User { Id = 1, Name = "Alice", Position = "Developer", Age = 30, Salary = 60000 },
        new User { Id = 2, Name = "Bob", Position = "Manager", Age = 45, Salary = 80000 },
        new User { Id = 3, Name = "Charlie", Position = "Designer", Age = 25, Salary = 50000 },
        
    };

        public IActionResult Index(string searchName, string searchPosition, string sortOrder)
        {
            var filteredUsers = users.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                filteredUsers = filteredUsers.Where(u => u.Name.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchPosition))
            {
                filteredUsers = filteredUsers.Where(u => u.Position.Contains(searchPosition));
            }

            switch (sortOrder)
            {
                case "age_asc":
                    filteredUsers = filteredUsers.OrderBy(u => u.Age);
                    break;
                case "age_desc":
                    filteredUsers = filteredUsers.OrderByDescending(u => u.Age);
                    break;
                case "salary_asc":
                    filteredUsers = filteredUsers.OrderBy(u => u.Salary);
                    break;
                case "salary_desc":
                    filteredUsers = filteredUsers.OrderByDescending(u => u.Salary);
                    break;
                default:
                    filteredUsers = filteredUsers.OrderBy(u => u.Name);
                    break;
            }

            return View(filteredUsers.ToList());
        }
    }
}
