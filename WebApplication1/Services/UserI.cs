namespace WebApplication1.Services
{
    using System.Collections.Generic;
    using WebApplication1.Models;
    public interface UserI
    {

        public void AddUser(User user);
        public void DeleteUser(string name);
        public void UpdateUser(User user);
        public User SearchUser(string name);
        public List<User> UserList();
        public bool Login(string email, string password);
    }
}
