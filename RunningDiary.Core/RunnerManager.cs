using RunningDiary.Database;
using System.Collections.Generic;
using System.Linq;

namespace RunningDiary.Core
{
    public class RunnerManager : IRunnerManager
    {
        private readonly IRunnerRepository mRunnerRepository;
        private readonly IWorkoutRepository mWorkoutRepository;
        private readonly IExerciseRepository mExerciseRepository;
        private readonly DtoMapper mDtoMapper;

        public RunnerManager(IRunnerRepository runnerRepository,
                             IWorkoutRepository workoutRepository,
                             IExerciseRepository exerciseRepository,
                             DtoMapper dtoMapper)
        {
            mRunnerRepository = runnerRepository;
            mWorkoutRepository = workoutRepository;
            mExerciseRepository = exerciseRepository;
            mDtoMapper = dtoMapper;
        }

        public List<RunnerDto> GetAllRunners(string filterString)
        {
            var runnerEntities = mRunnerRepository.GetAllRunners().ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                runnerEntities = runnerEntities
                    .Where(x => x.FirstName.Contains(filterString) || x.LastName.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(runnerEntities);
        }

        public List<WorkoutDto> GetAllWorkoutsForARunner(int runnerId, string filterString)
        {
            var workoutEntities = mWorkoutRepository.GetAllWorkouts().Where(x => x.RunnerId == runnerId).ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                workoutEntities = workoutEntities
                    .Where(x => x.TypeOfWorkout.Contains(filterString) || x.Description.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(workoutEntities);
        }
        public WorkoutDto GetWorkout(int workoutId)
        {
            var workoutEntitie = mWorkoutRepository.GetAllWorkouts().FirstOrDefault(x => x.Id == workoutId);

            return mDtoMapper.Map(workoutEntitie);
        }

        public List<ExerciseDto> GetAllExercisesForAWorkout(int workoutId, string filterString)
        {
            var exerciseEntities = mExerciseRepository.GetAllExercises().Where(x => x.WorkoutId == workoutId).ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                exerciseEntities = exerciseEntities
                .Where(a => a.Name.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(exerciseEntities);
        }

        public void AddNewExercise(ExerciseDto exercise, int workoutId)
        {
            var entity = mDtoMapper.Map(exercise);

            entity.WorkoutId = workoutId;

            mExerciseRepository.AddNew(entity);
        }


        public void AddNewWorkout(WorkoutDto workout, int runnerId)
        {
            var entity = mDtoMapper.Map(workout);

            entity.RunnerId = runnerId;

            mWorkoutRepository.AddNew(entity);
        }

        public void EditRunner(RunnerDto runner, int runnerId)
        {
            var entity = mDtoMapper.Map(runner);
            entity.Id = runnerId;

            mRunnerRepository.Edit(entity);
        }

        public void EditWorkout(WorkoutDto workout, int runnerId)
        {
            var entity = mDtoMapper.Map(workout);

           entity.RunnerId = runnerId;

            mWorkoutRepository.Edit(entity);
        }

        public void EditExercise(ExerciseDto exercise, int workoutId)
        {
            var entity = mDtoMapper.Map(exercise);

            entity.WorkoutId = workoutId;

            mExerciseRepository.Edit(entity);
        }

        public void AddNewRunner(RunnerDto runner)
        {
            var entity = mDtoMapper.Map(runner);

            mRunnerRepository.AddNew(entity);
        }


        public bool DeleteExercise(ExerciseDto exercise)
        {
            var entity = mDtoMapper.Map(exercise);

            return mExerciseRepository.Delete(entity);
        }


        public bool DeleteWorkout(WorkoutDto workout)
        {
            var entity = mDtoMapper.Map(workout);

            return mWorkoutRepository.Delete(entity);
        }

        public bool DeleteRunner(RunnerDto runner)
        {
            var entity = mDtoMapper.Map(runner);

            return mRunnerRepository.Delete(entity);
        }
    }
}
