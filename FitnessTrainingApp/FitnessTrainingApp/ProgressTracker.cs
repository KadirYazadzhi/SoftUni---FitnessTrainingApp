namespace FitnessApp;

public class ProgressTracker {
    public const int WorkoutsRequiredForGoal = 50;

    public static void GetProgress() {
        int completedWorkouts = Start.Users[User.GetUserId(Start.CurrentUserName)].WorkoutHistory.Count;
        
        Console.WriteLine($"You have completed {completedWorkouts} workouts.");
        Console.WriteLine($"Your progress is around {completedWorkouts / WorkoutsRequiredForGoal * 100} percent.");
        Console.WriteLine($"To archive your goal, you need {WorkoutsRequiredForGoal - completedWorkouts} more workouts.");
    }

    public static bool HasAchievedGoal() {
        return Start.Users[User.GetUserId(Start.CurrentUserName)].WorkoutHistory.Count >= WorkoutsRequiredForGoal;
    }

    public static void DisplayProgressMessage() {
        int completedWorkouts = Start.Users[User.GetUserId(Start.CurrentUserName)].WorkoutHistory.Count;
        
        Console.WriteLine($"To archive your goal, you need {WorkoutsRequiredForGoal - completedWorkouts} more workouts.");
    }

    public static void DisplayAllAboutProgressAndProfile() {
        Console.WriteLine("Your profile data and progress: ");
        
        Console.WriteLine($"    Name: {Start.CurrentUserName}");
        Console.WriteLine($"    Age: {Start.Users[User.GetUserId(Start.CurrentUserName)].Age}");
        Console.WriteLine($"    Weight: {Start.Users[User.GetUserId(Start.CurrentUserName)].Weight}");
        Console.WriteLine($"    Height: {Start.Users[User.GetUserId(Start.CurrentUserName)].Height}");
        Console.WriteLine($"    Goals: {Start.Users[User.GetUserId(Start.CurrentUserName)].Goal}");
        
        GetProgress();
    }
}
