using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDproject
{
    internal class UserService
    {
      private  List<User> users = new List<User>();

        public User AddUser(string username, string useremail, string userphonenumber)
        {
            try
            {
                var user = new User(username, useremail, userphonenumber);
                users.Add(user);
                return user;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return null;
            }
        }

        public void GetAllUsers()
        {
            if (users.Count == 0) { 
                Console.WriteLine("No users found.");
                return;
            }
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }


        public bool UpdateUser ( int id,string newname, string newemail, string newphonenumber)
        {
            var user = users.Find(u => u.ID == id);
                if (user == null)
            {
                Console.WriteLine("User not found. ");
                return false;
            }

          try
            {
                user.Name = newname;
                user.Email = newemail;
                user.PhoneNumber = newphonenumber;
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }
        public bool DeleteUser(int id)
        {
            var user = users.Find(u => u.ID == id);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return false;
            }
            users.Remove(user);
            return true;
        }
    }
}
