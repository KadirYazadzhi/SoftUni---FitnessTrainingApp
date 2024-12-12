namespace FitnessApp;

public class User {
    public string Name { get; private set; }
    public int Age { get; private set; }
    public int Weight { get; private set; }
    public int Height { get; private set; }
    public string Goal { get; private set; }
    public List<Workout> WorkoutHistory { get; private set; }

    public User(string name, int age, int weight, int height, string goal, List<Workout> history) {
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
        Goal = goal;
        WorkoutHistory = history;
    }

    public static void ProfileCreationManage() {
        int choice = PrintUserTypeMessage();

        switch (choice) {
            case 1:
                CreateUser();
                break;
            case 2:
                Admin.IsAdmin();
                break;
        }
    }
    
    private static int PrintUserTypeMessage() {
        Console.WriteLine("Choose the type of user you want to register as.");
        Console.WriteLine("   1. User");
        Console.WriteLine("   2. Admin");
        Console.WriteLine("Enter your choice: ");
        
        return int.Parse(Console.ReadLine());;
    }

    private static void CreateUser() {
        while (true) {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter your age: ");
            int age = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter your weight: ");
            int weight = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter your height: ");
            int height = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter your goal [Build muscle | Lose weight | Gain weight]: ");
            string goal = Console.ReadLine();
            
            if (!ValidateData(age, weight, height, goal)) {
                Console.WriteLine("Please enter valid data.");
                continue;
            }
            
            Start.Users.Add(new(name, age, weight, height, goal, new List<Workout>()));
            Start.CurrentUserName = name;
            break;
        }
    }

    private string Change(string oldData, string newData, string type) {
        if (oldData == newData) {
            Console.WriteLine($"The {type} you want to change with is current {type}.");
            return oldData;
        }
        
        Console.WriteLine($"Your {type} is changed successfully.");
        Console.WriteLine($"Your {type} {oldData} is changed to {newData}.");
        return newData;
    }

    public void DeleteProfileData() {
        Console.WriteLine("Are you sure you want to delete profile data?");
        Console.WriteLine("Enter your choice [Y/N]:");
        
        char choice = Console.ReadLine().ToUpper()[0];

        if (choice == 'N' || choice != 'Y') {
            return;
        }
        
        Start.Users.Remove(Start.Users[GetUserId(Name)]);
        Start.CurrentUserName = null;
        
        Console.WriteLine("You deleted profile data.");
    }

    public void PrintAllUserData() {
        ProgressTracker.DisplayAllAboutProgressAndProfile();
        Console.WriteLine();
        Workout.ViewWorkoutHistory();
            
    }

    public void ChangeUserData() {
        Console.WriteLine("What you want to change (Name, Age, Weight, Height, Goal): ");
        string type = Console.ReadLine();
        
        Console.WriteLine("Enter your new user data: ");
        string userData = Console.ReadLine();
        
        switch (type) {
            case "Name":
                Name = Change(Name, userData, type);
                Start.CurrentUserName = Name;
                break;
            case "Age":
                Age = int.Parse(Change(Age.ToString(), userData, type));
                break;
            case "Weight":
                Weight = int.Parse(Change(Weight.ToString(), userData, type));
                break;
            case "Height":
                Height = int.Parse(Change(Height.ToString(), userData, type));
                break;
            case "Goal":
                Goal = Change(Goal, userData, type);
                break;
            default:
                throw new Exception("Invalid property to change.");
        }
        Console.WriteLine("You changed your profile data successfully.");
    }

    public void DisplayInfo() {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Weight: {Weight}kg, Height: {Height}cm, Goal: {Goal}");

        if (WorkoutHistory.Count == 0) {
            return;
        }
        
        Console.WriteLine($"Current workout history: {string.Join(", ", WorkoutHistory)}");
    }

    public static void ExitFromUserProfile() {
        Console.WriteLine("Are you sure you want to exit? [Y/N]");
        char choice = Console.ReadLine().ToUpper()[0];

        if (choice == 'Y') {
            Start.CurrentUserName = null;
            Console.WriteLine("You exited from your profile.");
        }
    }
    
    private static bool ValidateData(int age, int weight, int height, string goal) {
        if (age < 1 || age > 100 || weight < 0 || height < 0 || 
            (goal != "Build muscle" && goal != "Lose weight" && goal != "Gain weight")) {
            return false;
        }
        
        return true;
    }
    
    public static int GetUserId(string name) {
        for (int i = 0; i < Start.Users.Count; i++) {
            if (Start.Users[i].Name == name) {
                return i;
            }
        }

        return -1;
    }
}
