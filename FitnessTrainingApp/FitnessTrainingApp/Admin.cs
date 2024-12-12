namespace FitnessApp;

public class Admin {
    public static string Username { get; private set; } = "Administrator";
    public static string Password { get; private set; } = "admin12345";
    
    public static void IsAdmin() {
        Console.WriteLine("Please enter admin username: ");
        string name = Console.ReadLine();

        if (name != Username) {
            Console.WriteLine("Invalid username.");
            return;
        }
        
        Console.WriteLine("Enter admin password to login: ");

        while (true) {
            string password = Console.ReadLine();

            if (password == Password) {
                Start.LogedAsAdmin = true;
                break;
            }
            
            Console.WriteLine("Please enter valid admin password: ");
        }
        
        Start.AdminMenu();
    }

    public static void ChangeAdminData() {
        Console.WriteLine("Enter what you want to change: [Name, Password] ");
        string type = Console.ReadLine();

        if (type != "Name" && type != "Password") {
            Console.WriteLine("Invalid choice.");
            return;
        }
        Console.WriteLine("Enter the new data: ");
        string newData = Console.ReadLine();

        switch (type) {
            case "Name":
                Username = newData;
                break;
            case "Password":
                Password = newData;
                break;
        }
        
        Console.WriteLine("Successfully changed data.");
    }

    public static void ViewAllAdminData() {
        Console.WriteLine("Admin Profile Data: ");
        Console.WriteLine(" Admin Username: " + Username);
        Console.WriteLine(" Admin Password: " + Password);
    }

    public static void DeleteAllUsers() {
        Console.WriteLine("Are you sure you want to delete all users? [Y/N]");
        
        string input = Console.ReadLine();

        if (input.ToLower() == "n") {
            return;
        }
        
        Start.Users = new();
        Console.WriteLine("You deleted all users.");
    }

    public static void ChangeUserData() {
        Console.WriteLine("Enter the name of the user: ");
        string name = Console.ReadLine();

        int index = User.GetUserId(name);
        if (index == -1) {
            Console.WriteLine("Invalid user name.");
            return;
        }
        
        Start.Users[index].ChangeUserData();
    }

    public static void DeleteUser() {
        Console.WriteLine("Enter the name of the user: ");
        string name = Console.ReadLine();
        
        int index = User.GetUserId(name);
        if (index == -1) {
            Console.WriteLine("Invalid user name.");
            return;
        }
        
        Console.WriteLine("Are you sure you want to delete user? [Y/N]");
        string input = Console.ReadLine();

        if (input.ToLower() == "n") {
            return;
        }
        
        Start.Users.RemoveAt(index);
        Console.WriteLine("User deleted.");
    }

    public static void AddUser() {
        while (true) {
            Console.WriteLine("Enter user name: ");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter user age: ");
            int age = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter user weight: ");
            int weight = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter user height: ");
            int height = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter user goal [Build muscle | Lose weight | Gain weight]: ");
            string goal = Console.ReadLine();
            
            Start.Users.Add(new(name, age, weight, height, goal, new List<Workout>()));
            break;
        }
        
        Console.WriteLine("User added.");
    }

    public static void ViewAllUsers() {
        Console.WriteLine("All users: ");
        foreach (User user in Start.Users) {
            Console.WriteLine(string.Join(", ", user));
        }
    }

    public static void DeleteUserHistory() {
        Console.WriteLine("Enter user name: ");
        string name = Console.ReadLine();
        
        int index = User.GetUserId(name);
        if (index == -1) {
            Console.WriteLine("Invalid user name.");
            return;
        }
        
        Workout.DeleteAllWorkoutHistory(index);
    }

    public static void DeleteUsersHistory() {
        Console.WriteLine("Are you sure you want to delete all users? [Y/N]");
        
        string input = Console.ReadLine();
        if (input.ToLower() == "n" && input.ToLower() != "y") {
            return;
        }
        
        for (int i = 0; i < Start.Users.Count; i++) {
            Workout.DeleteAllWorkoutHistory(i);
        }
        
        Console.WriteLine("Users History are deleted.");
    }

    public static void ExitFromAdminProfile() {
        Console.WriteLine("Are you sure you want to exit? [Y/N]");
        char input = Console.ReadLine().ToUpper()[0];

        if (input == 'Y') {
            Start.LogedAsAdmin = false;
            Console.WriteLine("You exited admin profile.");
        }
    }
}