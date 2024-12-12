namespace FitnessApp;

public class Workout {
    public string Name { get; private set; }
    public List<ExerciseDetails> Exercises { get; private set; }  
    
    public Workout() {}

    public Workout(string name, List<ExerciseDetails> exercises) {
        Name = name;
        Exercises = exercises;
    }

    public void LogWorkout() {
        Console.WriteLine("Enter workout name: ");
        string workoutName = Console.ReadLine();

        Console.WriteLine("Enter number of exercises: ");
        int numberOfExercises = int.Parse(Console.ReadLine());

        List<ExerciseDetails> exercises = new List<ExerciseDetails>();

        for (int i = 0; i < numberOfExercises; i++) {
            Console.WriteLine($"Enter exercise {i + 1} name: ");
            string exerciseName = Console.ReadLine();

            int index = Exercise.FindExercise(exerciseName);

            if (index == -1) {
                Console.WriteLine($"Exercise {exerciseName} not found in the exercise list.");
                i--;
                continue;
            }
            
            ExerciseDetails exerciseDetails = ExerciseDetails.AddExerciseDetails(exerciseName);

            if (exerciseDetails == null) {
                Console.WriteLine($"Failed to add details for exercise {exerciseName}. Skipping.");
                return;
            } 
            
            exercises.Add(exerciseDetails);  
            Console.WriteLine($"Exercise {exerciseName} added to workout.");
        }

        if (exercises.Count == 0) {
            Console.WriteLine("Workout doesn't have any exercises.");
            return;
        }

        Workout workout = new Workout(workoutName, exercises);
        
        Start.Users[User.GetUserId(Start.CurrentUserName)].WorkoutHistory.Add(workout);

        Console.WriteLine($"Workout '{workoutName}' added to your history.");
    }
    
    public static void DeleteAllWorkoutHistory(int index) {
        Console.WriteLine("Are you sure you want to delete workout history data?");
        Console.WriteLine("Enter your choice [Y/N]:");
        
        char choice = Console.ReadLine().ToUpper()[0];

        if (choice == 'N' || choice != 'Y') {
            return;
        }

        if (index == -1) {
            index = User.GetUserId(Start.CurrentUserName);
        }

        Start.Users[index].WorkoutHistory.Clear();
        
        Console.WriteLine("You deleted your workout history.");
    }

    public void DeleteWorkoutHistory() {
        Console.WriteLine("Enter the name of the workout you want to delete: ");
        string workoutName = Console.ReadLine();
        
        int index = FindWorkoutIndex(workoutName);
        if (index == -1) {
            Console.WriteLine("There is no workout with that name.");
            return;
        }
        
        Start.Users[User.GetUserId(Start.CurrentUserName)].WorkoutHistory.RemoveAt(index);
    }

    public static void ViewWorkoutHistory() {
        Console.WriteLine("This is your workout history: ");

        foreach (var workoutHistory in Start.Users[User.GetUserId(Start.CurrentUserName)].WorkoutHistory) {
            Console.WriteLine($"{workoutHistory.Name}: ");
            Console.WriteLine($"    {string.Join(", ", workoutHistory.Exercises)}");
        }
    }

    private int FindWorkoutIndex(string name) {
        return Start.Users[User.GetUserId(Start.CurrentUserName)].WorkoutHistory.FindIndex(x => x.Name == name);
    }
}

 