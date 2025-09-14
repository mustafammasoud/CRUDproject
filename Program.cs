namespace CRUDproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
           UserService u = new UserService();

            bool running = true;

            while (running)
            {
                Console.WriteLine(" \n ======== User Management System =======");
                Console.WriteLine("1. Add User .");
                Console.WriteLine("2. View All Users .");
                Console.WriteLine("3. Update User .");
                Console.WriteLine("4. Delete User .");
                Console.WriteLine("5. Exit .");
                Console.Write("Enter Your Choise :");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice ))
                {
                    Console.WriteLine("Invalid input . Please enter a choise .");
                    continue; 
                }

                switch(choice)

                {
                case 1: // Add user
                        Console.Write("Name :");
                        string name = Console.ReadLine();
                        Console.Write("Email :");
                        string email = Console.ReadLine();
                        Console.Write("Phone Number :");
                        string phoneInput = Console.ReadLine();

                        if (int.TryParse(phoneInput, out int _) || true) // بس عشان string، مش محتاج parse
                        {
                            var user = u.AddUser(name, email, phoneInput); 
                            if (user != null)
                            {
                                Console.WriteLine("User added successfully!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid phone number.");
                        }
                        break;
                    case 2: // view all users 
                        u.GetAllUsers();
                        break;
                case 3: // Update User
                        Console.Write("Enter user ID to update: ");
                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Invalid ID.");
                         break;
                        }
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new email: ");
                        string newEmail = Console.ReadLine();
                        Console.Write("Enter new phone number: ");
                        string newPhone = Console.ReadLine();

                        if (u.UpdateUser(updateId, newName, newEmail, newPhone))
                            Console.WriteLine("User updated successfully!");
                        break;

                case 4: // Delete User
                        Console.Write("Enter user ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }
                        if (u.DeleteUser(deleteId))
                            Console.WriteLine("User deleted successfully!");
                        break;

                case 5: // Exit
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }


            }
        }
    }
}
