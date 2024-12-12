namespace FitnessApp;

public class ExerciseDetails : Exercise {
    public int Sets { get; private set; }
    public int Reps { get; private set; }
    public int RestTime { get; private set; }

    public ExerciseDetails(Exercise exercise, int sets, int reps, int restTime) 
        : base (exercise.Name, exercise.Description, exercise.Difficulty) {
        Sets = sets;
        Reps = reps;
        RestTime = restTime;
    }

    public static ExerciseDetails AddExerciseDetails(string name) {
        Console.WriteLine("Enter how many sets you make: ");
        int sets = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter how many reps you make: ");
        int reps = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter rest time between sets (in seconds): ");
        int restTime = int.Parse(Console.ReadLine());

        if (sets < 0 || reps < 0 || restTime < 0) {
            Console.WriteLine("Invalid input. All values must be positive.");
            return null;
        }
        
        Exercise exercise = Start.Exercises[FindExercise(name)];
        if (exercise != null) {
            return new ExerciseDetails(exercise, sets, reps, restTime);
        } 
        
        Console.WriteLine("Exercise not found in the list.");
        return null;
    }


    // public void DisplayExerciseDetails() {
    //     DisplayExercise();
    //     Console.WriteLine($"Sets: {Sets}, Reps: {Reps}, Rest Time: {RestTime} seconds");
    // }
}
