using System.Collections.Generic;

namespace RunningDiary.Core
{
    public interface IRunnerManager
    {
        void AddNewExercise(ExerciseDto exercise, int workoutId);
        void AddNewRunner(RunnerDto runner);
        void AddNewWorkout(WorkoutDto workout, int runnerId);
        void EditRunner(RunnerDto runner, int runnerId);
        void EditWorkout(WorkoutDto workout, int runnerId);
        void EditExercise(ExerciseDto exercise, int workoutId);
        bool DeleteExercise(ExerciseDto exercise);
        bool DeleteRunner(RunnerDto runner);
        bool DeleteWorkout(WorkoutDto workout);
        List<ExerciseDto> GetAllExercisesForAWorkout(int workoutId, string filterString);
        List<RunnerDto> GetAllRunners(string filterString);
        List<WorkoutDto> GetAllWorkoutsForARunner(int runnerId, string filterString);
        WorkoutDto GetWorkout(int workoutId);
    }
}