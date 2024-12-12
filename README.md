# 🏋️‍♂️ Fitness Training App

The **Fitness Training App** is a comprehensive C# project that facilitates the management of fitness profiles, workout plans, exercises, and user progress. Originating from an educational Python task, this project has been significantly expanded and implemented in C# to demonstrate advanced Object-Oriented Programming (OOP) concepts, as well as practical applications for fitness management systems. It includes a robust console interface and additional functionalities to enhance the user experience.

This project aims to provide a structured and scalable solution for fitness enthusiasts, trainers, and administrators, offering features like user role management, progress tracking, and workout customization. With a modular design, it ensures code maintainability, reusability, and future extensibility.


## 🎯 Goals and Features

### Original Task Objectives
1. **User Profile Management**:
   - Create, update, and view fitness profiles.
   - Log workout history.
2. **Workout Plans**:
   - Build, edit, and view workout routines.
3. **Exercise Library**:
   - Maintain a list of exercises with descriptions and difficulty levels.
4. **Progress Tracking**:
   - Monitor workout completion and track user progress.
5. **Report Generation**:
   - Generate workout history and progress reports.
     

### Additional Features
- 🛡️ **Role-Based Access**:
  - Separate menus and functionalities for admins and users.
- 🗂️ **Enhanced Data Structures**:
  - Classes and properties expanded to include detailed exercise and workout management.
- 🎛️ **Robust Input Handling**:
  - Ensures valid user input with retries.
- 📋 **Dynamic Data Management**:
  - Maintains an interactive list of users, workouts, and exercises.
- 🎨 **Menus and Navigation**:
  - A user-friendly console interface for seamless navigation.


## 📂 Project Structure

```plaintext
FitnessApp/
│
├── Admin.cs           # Handles admin-specific functionality
├── Exercise.cs        # Manages individual exercises
├── ExerciseDetails.cs # Manages details of each exercise
├── ProgressTracker.cs # Tracks and reports user progress
├── User.cs            # Represents user profiles and their data
├── Workout.cs         # Manages workout plans and history
├── Main.cs            # Entry point with menu system
```


## 🔍 Class Details

### 1. `User` Class

- #### 🔑 **Purpose**
  Represents individual user profiles with personal details, fitness goals, and workout history.

- #### 📋 **Attributes**
  - `Name`: User's name.
  - `Age`: User's age.
  - `Weight`: User's weight in kilograms.
  - `Height`: User's height in centimeters.
  - `Goal`: Fitness goal (e.g., "Build muscle").
  - `WorkoutHistory`: List of completed workouts.

- #### 🛠️ **Methods**
  - `ProfileCreationManage()`: Creates user or admin profiles.
  - `ChangeUserData()`: Updates user profile details.
  - `DeleteProfileData()`: Deletes user profile data.
  - `DisplayInfo()`: Shows profile details.
  - `PrintAllUserData()`: Combines profile and progress details.


### 2. `Workout` Class

- #### 🔑 **Purpose**
  Handles workout plans and their histories for users.

- #### 📋 **Attributes**
  - `Name`: Name of the workout.
  - `Exercises`: List of exercises included in the workout.

- #### 🛠️ **Methods**
  - `LogWorkout()`: Logs a new workout.
  - `DeleteWorkoutHistory()`: Removes a specific workout by name.
  - `DeleteAllWorkoutHistory()`: Clears all workout history for a user.
  - `ViewWorkoutHistory()`: Displays all workout history.


### 3. `Exercise` Class

- #### 🔑 **Purpose**
  Maintains a library of exercises with details.

- #### 📋 **Attributes**
  - `Name`: Name of the exercise.
  - `Description`: How to perform the exercise.
  - `Difficulty`: Exercise difficulty level.

- #### 🛠️ **Methods**
  - `DisplayAllExercise()`: Lists all available exercises.
  - `AddExercise()`: Adds a new exercise to the library.
  - `ChangeExerciseData()`: Edits existing exercise details.
  - `RemoveExercise()`: Deletes an exercise from the library.
  - `RemoveAllExercises()`: Clears the exercise library.


### 4. `ExerciseDetails` Class

- #### 🔑 **Purpose**
  Adds details to exercises, such as sets, reps, and rest times.


### 5. `ProgressTracker` Class

- #### 🔑 **Purpose**
  Tracks user progress based on workout history.

- #### 🛠️ **Methods**
  - `GetProgress()`: Calculates percentage completion towards the user's fitness goal.
  - `HasAchievedGoal()`: Checks if the fitness goal has been reached.
  - `DisplayProgressMessage()`: Displays a brief progress summary.
  - `DisplayAllAboutProgressAndProfile()`: Combines progress and profile information.


### 6. `Admin` Class

- #### 🔑 **Purpose**
  Provides administrative functionality.

- #### 🛠️ **Methods**
  - `IsAdmin()`: Authenticates admin access.
  - `ChangeAdminData()`: Updates admin credentials.
  - `ViewAllAdminData()`: Displays admin profile details.
  - `DeleteAllUsers()`: Removes all users.
  - `DeleteUserHistory()`: Clears workout history for a specific user.
  - `AddUser()`: Adds new user profiles.
  - `ViewAllUsers()`: Lists all registered users.



## 🔗 Relationships Between Classes

- **User ↔ Workout**:
  - Users maintain a history of workouts.
- **Workout ↔ Exercise**:
  - Workouts consist of multiple exercises.
- **Admin ↔ User**:
  - Admins can manage user profiles and their data.
- **ProgressTracker ↔ User**:
  - Tracks user workout data to monitor progress.


## 🛠️ Design Principles

1. **Encapsulation**:
   - All attributes are private or protected.
   - Getter and setter methods provide controlled access.
2. **Modularity**:
   - Each class is responsible for a specific aspect of the app.
3. **Reusability**:
   - Methods and classes can be reused for scalability.
4. **Separation of Concerns**:
   - Clear distinction between user, admin, exercise, and workout functionality.


## ⚙️ Complexity Analysis

- **Scalability**:
  - Designed to handle multiple users, workouts, and exercises efficiently.
- **Maintenance**:
  - Modular structure ensures easy updates and debugging.
- **User-Friendliness**:
  - Intuitive console menus simplify navigation.


## 📌 Highlights

- 🛡️ **Role-Based Access**:
  - Separate menus and functionalities for admins and users.
- 🛠️ **Robust Input Handling**:
  - Ensures valid user input with retries.
- 📋 **Data Management**:
  - Maintains a dynamic list of users, workouts, and exercises with validation features.


## ✨ Future Improvements

- 🔒 **Enhanced Security**:
  - Encrypt admin and user passwords.
- 📊 **Advanced Reporting**:
  - Add visual and statistical workout reports.
- 🖥️ **Graphical User Interface**:
  - Implement a GUI for improved user experience.



## 🛠 Technologies Used

- **C# .NET**:
  - For backend logic and OOP implementation 🖥️
- **Visual Studio**:
  - IDE used for development 👨‍💻
- **Collections and LINQ**:
  - Efficient handling of lists and data queries 📋


## 🗒️ How to Use

1. Clone the repository:
   ```bash
   git clone https://github.com/KadirYazadzhi/SoftUni---FitnessTrainingApp
   cd FitnessTrainingApp
   ```
2. Run the application:
   ```bash
   dotnet run
   ```

   
## 🎓 **Credits**

This project is based on the **"Fitness Training App"** exercise created by [Mario Zahariev](https://github.com/zahariev-webbersof/) for Python developers. However, I adapted the task and implemented it in C#. You can view the original task [here](https://github.com/zahariev-webbersof/python-fundamentals-09-2024-/blob/main/Fitness%20Training%20App.md).

Special thanks to Mario Zahariev for providing a great foundational exercise.

## 💾 **Contribution**

Feel free to fork this repository and submit pull requests! Contributions are welcome if you have ideas for additional patterns, new features, or improved functionality.

## 📞 **Contact**

If you have any questions or suggestions, feel free to reach out at:

- 📧 Email: kadiryazadzhi@gmail.com
- 🌍 Portfolio: [Kadir Yazadzhi](https://kadiryazadzhi.github.io/portfolio/)

