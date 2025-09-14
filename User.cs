using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDproject
{
    internal class User
    {
        private static int nextId =1;
        private readonly int id;
        private string name;
        private string email;
        private string phonenumber;

        public User( string name , string email, string phonenumber)
        {
            this.id=nextId++; 
            this.Name=name;
            this.Email=email;
            this.PhoneNumber = phonenumber;
        }


        public int ID 
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                    throw new ArgumentException("Name cannot be empty.");
            }
        }
        
        
       
        public string Email
        {
            get { return email; }

            set
            {
                if (!string.IsNullOrEmpty(value) && value.Contains("@"))
                {
                    email = value;
                }
                else
                    throw new ArgumentException("Invalid email format.");
            }
        }


        public string PhoneNumber
        {
            get { return phonenumber; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 10 && value.All(char.IsDigit)) // تحقق إضافي: أرقام بس
                    phonenumber = value;
                else
                    throw new ArgumentException("Phone number must be at least 10 digits and contain only numbers.");
            }
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Email: {Email}, Phone: {PhoneNumber}";
        }
    }
}
