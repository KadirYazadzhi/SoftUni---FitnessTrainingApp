namespace FitnessApp;

public class Exercise {
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Difficulty { get; private set; }
    
    public Exercise() {}

    public Exercise(string name, string description, string difficulty) {
        Name = name;
        Description = description;
        Difficulty = difficulty;
    }

    public static void AddStartedExercise() {
        Start.Exercises = new List<Exercise> {
            new Exercise("Squat", "A lower-body exercise focusing on the thighs, hips, and buttocks. Stand with feet shoulder-width apart and lower your body as if sitting on a chair.", "Medium"),
            new Exercise("Push-Up", "A bodyweight exercise that targets the chest, shoulders, and triceps. Start in a plank position and lower your body to the ground, then push back up.", "Easy"),
            new Exercise("Plank", "A core-strengthening exercise. Hold your body straight while resting on your forearms and toes.", "Medium"),
            new Exercise("Burpee", "A full-body exercise that involves a squat, jump, and push-up sequence.", "Hard"),
            new Exercise("Lunge", "A lower-body exercise focusing on the quads and glutes. Step one leg forward and lower your hips until both knees are bent at a 90-degree angle.", "Medium"),
            new Exercise("Deadlift", "A strength exercise targeting the posterior chain. Lift a weighted barbell off the ground while keeping your back straight.", "Hard"),
            new Exercise("Pull-Up", "An upper-body exercise that targets the back and biceps. Hang from a bar and pull your body upward until your chin passes the bar.", "Hard"),
            new Exercise("Sit-Up", "A core exercise that strengthens the abdominal muscles. Lie on your back with knees bent and lift your torso toward your knees.", "Easy"),
            new Exercise("Jumping Jack", "A cardio exercise that involves jumping with legs and arms moving outward and inward simultaneously.", "Easy"),
            new Exercise("Mountain Climber", "A dynamic bodyweight exercise targeting the core and cardio endurance. Alternate pulling your knees toward your chest in a plank position.", "Medium")
        };
    }

    public void AddExercise() {
        Console.WriteLine("Enter the name of the exercise you would like to add: ");
        string name = Console.ReadLine();

        if (FindExerciseIndex(name) != -1) {
            Console.WriteLine("The exercise you would like to add is already in the list.");
            return;
        }
        
        Console.WriteLine("Enter the description of the exercise you would like to add: ");
        string description = Console.ReadLine();
        
        Console.WriteLine("Enter the difficulty of the exercise you would like to add: ");
        string difficulty = Console.ReadLine();
        
        Start.Exercises.Add(new Exercise(name, description, difficulty));
        Console.WriteLine("Successfully added exercise.");
    }

    public void RemoveExercise() {
        Console.WriteLine("Enter the name of the exercise you would like to remove: ");
        string name = Console.ReadLine();
        
        int index = FindExerciseIndex(name);
        
        if (index == -1) {
            Console.WriteLine("The exercise you would like to remove was not found.");
            return;
        }
        
        Start.Exercises.RemoveAt(index);
        Console.WriteLine($"{name} was removed from exercises.");
    }

    public void RemoveAllExercises() {
        Console.WriteLine("Are you sure you want to remove all exercises? [Y/N]");
        string input = Console.ReadLine();

        if (input.ToLower() == "y") {
            Start.Exercises.Clear();
            Console.WriteLine("All exercises were removed.");
        }
    }

    public void ChangeExerciseData() {
        Console.WriteLine("Enter the name of the exercise you would like to change data: ");
        string name = Console.ReadLine();
        
        int index = FindExerciseIndex(name);
        
        if (index == -1) {
            Console.WriteLine("The exercise you would like to change was not found.");
            return;
        }
        
        Console.WriteLine("Enter what you would like to change [Description, Difficulty]: ");
        string property = Console.ReadLine();

        if (!property.Equals("Description") && !property.Equals("Difficulty")) {
            Console.WriteLine("The data you would like to change was not valid.");
            return;
        }
        
        Console.WriteLine("Enter the data you would like to change with: ");
        string newData = Console.ReadLine();

        switch (property) {
            case "Description":
                Start.Exercises[index].Description = newData;
                break;
            case "Difficulty":
                Start.Exercises[index].Difficulty = newData;
                break;
        }
        
        Console.WriteLine("Successfully changed exercise.");
    }

    public static int FindExercise(string name) {
        return Start.Exercises.FindIndex(e => e.Name == name);
    }

    public void DisplayAllExercise() {
        if (Start.Exercises.Count == 0) {
            Console.WriteLine("There are no exercises.");
            return;
        }
        
        Console.WriteLine("These are all exercises: ");
        foreach (var exercise in Start.Exercises) {
            Console.WriteLine($"Name: {exercise.Name}, Description: {exercise.Description}, Difficulty: {exercise.Difficulty}");
        }
    }
    
    private int FindExerciseIndex(string name) {
        for (int i = 0; i < Start.Exercises.Count; i++) {
            if (Start.Exercises[i].Name == name) {
                return i;
            }
        }
        
        return -1;
    }
}
