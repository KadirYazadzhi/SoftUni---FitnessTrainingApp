using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FitnessApp;

public static class Start {
    public static List<User> Users = new List<User>();
    public static List<Exercise> Exercises = new List<Exercise>();
    public static bool LogedAsAdmin = false;
    public static string CurrentUserName = string.Empty;
    public static Exercise exerciseManager = new();
    
    public static void Main() {
        Console.WriteLine("Welcome to Fitness Training App");
        User.ProfileCreationManage();
        Exercise.AddStartedExercise();

        while (true) {
            DisplayMainMenu();
            int choice = int.Parse(Console.ReadLine());

            switch (choice) {
                case 1:
                    UserMenu();
                    break;
                case 2:
                    ExerciseMenu();
                    break;
                case 3:
                    WorkoutMenu();
                    break;
                case 4:
                    ProgressMenu();
                    break;
                case 5:
                    User.ExitFromUserProfile();
                    break;
                case 6:
                    Console.WriteLine("Exiting application. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void DisplayMainMenu() {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Manage User Profile");
        Console.WriteLine("2. Manage Exercises");
        Console.WriteLine("3. Manage Workouts");
        Console.WriteLine("4. View Progress Tracker");
        Console.WriteLine("5. Exit From Your Profile");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
    }

    private static void UserMenu() {
        IsUserLogged();

        Console.WriteLine("\nUser Menu:");
        Console.WriteLine("1. View Profile");
        Console.WriteLine("2. Edit Profile");
        Console.WriteLine("3. View All Profile Data");
        Console.WriteLine("4. Delete Profile");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        var user = Users[User.GetUserId(CurrentUserName)];

        switch (choice) {
            case 1:
                user.DisplayInfo();
                break;
            case 2:
                user.ChangeUserData();
                break;
            case 3:
                user.PrintAllUserData();
                break;
            case 4:
                user.DeleteProfileData();
                break;
            default:
                Console.WriteLine("Invalid choice. Returning to main menu.");
                break;
        }
    }

    private static void ExerciseMenu() {
        Console.WriteLine("\nExercise Menu:");
        Console.WriteLine("1. View All Exercises");
        Console.WriteLine("2. Add New Exercise");
        Console.WriteLine("3. Edit Exercise");
        Console.WriteLine("4. Delete Exercise");
        Console.WriteLine("5. Delete All Exercises");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice) {
            case 1:
                exerciseManager.DisplayAllExercise();
                break;
            case 2:
                exerciseManager.AddExercise();
                break;
            case 3:
                exerciseManager.ChangeExerciseData();
                break;
            case 4:
                exerciseManager.RemoveExercise();
                break;
            case 5:
                exerciseManager.RemoveAllExercises();
                break;
            default:
                Console.WriteLine("Invalid choice. Returning to main menu.");
                break;
        }
    }

    private static void WorkoutMenu() {
        IsUserLogged();

        Console.WriteLine("\nWorkout Menu:");
        Console.WriteLine("1. Add Workout");
        Console.WriteLine("2. View Workout History");
        Console.WriteLine("3. Delete Workout");
        Console.WriteLine("4. Delete All Workout History");
        Console.Write("Enter your choice: ");
    
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice)) {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        Workout workout = new Workout();
        switch (choice) {
            case 1:
                workout.LogWorkout();
                break;
            case 2:
                Workout.ViewWorkoutHistory();
                break;  
            case 3:
                workout.DeleteWorkoutHistory();
                break;  
            case 4:
                Workout.DeleteAllWorkoutHistory(-1);
                break;
            default:
                Console.WriteLine("Invalid choice. Returning to main menu.");
                break;
        }
    }
    
    private static void ProgressMenu() {
        IsUserLogged();

        Console.WriteLine("\nWorkout Menu:");
        Console.WriteLine("1. View Progress");
        Console.WriteLine("2. Has Archive Your Goal");
        Console.WriteLine("3. View Short Progress Info");
        Console.WriteLine("4. View Your Data And Progress");
        Console.Write("Enter your choice: ");
    
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice)) {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        
        switch (choice) {
            case 1:
                ProgressTracker.GetProgress();
                break;
            case 2:
                ProgressTracker.HasAchievedGoal();
                break;
            case 3:
                ProgressTracker.DisplayProgressMessage();
                break;
            case 4:
                ProgressTracker.DisplayAllAboutProgressAndProfile();
                break;
            default:
                Console.WriteLine("Invalid choice. Returning to main menu.");
                break;
        }
    }

    public static void AdminMenu() {
        Console.WriteLine("\nAdmin Menu:");
        Console.WriteLine("Manage Admin: ");
        Console.WriteLine(" 1. Change Admin Data");
        Console.WriteLine(" 2. View All Admin Data");
        Console.WriteLine("3. Exit From Your Profile");
        
        Console.WriteLine("Manage User: ");
        Console.WriteLine(" 4. Add User");
        Console.WriteLine(" 5. Edit User");
        Console.WriteLine(" 6. Delete User");
        Console.WriteLine(" 7. Delete All Users");
        Console.WriteLine(" 8. Delete User Workout History");
        Console.WriteLine(" 9. Delete Workout History For All Users");
        Console.WriteLine(" 10. View All Users");
        
        Console.WriteLine("Manage Exercises: ");
        Console.WriteLine(" 11. Edit Exercise");
        Console.WriteLine(" 12. Add Exercise");
        Console.WriteLine(" 13. Delete Exercise");
        Console.WriteLine(" 14. Delete All Exercises");
        
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice)) {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        
        switch (choice) {
            case 1:
                Admin.ChangeAdminData();
                break;
            case 2:
                Admin.ViewAllAdminData();
                break;
            case 3:
                Admin.ExitFromAdminProfile();
                break;
            case 4:
                Admin.AddUser();
                break;
            case 5:
                Admin.ChangeUserData();
                break;
            case 6:
                Admin.DeleteUser();
                break;
            case 7:
                Admin.DeleteAllUsers();
                break;
            case 8:
                Admin.DeleteUserHistory();
                break;
            case 9:
                Admin.DeleteUsersHistory();
                break;
            case 10:
                Admin.ViewAllUsers();
                break;
            case 11:
                exerciseManager.ChangeExerciseData();
                break;
            case 12:
                exerciseManager.AddExercise();
                break;
            case 13:
                exerciseManager.RemoveExercise();
                break;
            case 14:
                exerciseManager.RemoveAllExercises();
                break;
            default:
                Console.WriteLine("Invalid choice. Returning to main menu.");
                break;
        }
    }

    private static void IsUserLogged() {
        if (string.IsNullOrEmpty(CurrentUserName)) {
            Console.WriteLine("No user logged in. Please create or log in first.");
            User.ProfileCreationManage();
        }
    }

}

