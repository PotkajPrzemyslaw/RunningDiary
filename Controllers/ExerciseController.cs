using Microsoft.AspNetCore.Mvc;
using RunningDiary.Core;
using System.Linq;

namespace RunningDiary.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IRunnerManager mRunnerManager;
        private readonly ViewModelMapper mViewModelMapper;

        public ExerciseController(IRunnerManager runnerManager,
                                  ViewModelMapper viewModelMapper)
        {
            mRunnerManager = runnerManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int runnerId, int workoutId, string filterString)
        {
            TempData["RunnerId"] = runnerId;
            TempData["RunnerId2"] = runnerId;
            TempData["WorkoutId2"] = workoutId;
            TempData["RunnerId3"] = runnerId;
            TempData["WorkoutId3"] = workoutId;

            var workoutDto = mRunnerManager.GetAllWorkoutsForARunner(runnerId, null)
                                                 .FirstOrDefault(x => x.Id == workoutId);

            var exerciseDtos = mRunnerManager.GetAllExercisesForAWorkout(workoutId, filterString);

            var workoutViewModel = mViewModelMapper.Map(workoutDto);
            workoutViewModel.Exercises = mViewModelMapper.Map(exerciseDtos);


            return View(workoutViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(ExerciseViewModel exerciseVm, int workoutId)
        {
            ExerciseViewModel newVm = new ExerciseViewModel { Id = int.Parse(TempData["ExerciseId"].ToString()) };
            newVm.Name = exerciseVm.Name;
            newVm.Distance = exerciseVm.Distance;

            var dto = mViewModelMapper.Map(newVm);

            mRunnerManager.EditExercise(dto, workoutId);

            return RedirectToAction("Index", new {runnerId = int.Parse(TempData["RunnerId2"].ToString()),
                                                  workoutId = workoutId });
        }

        public IActionResult Edit(int exerciseId)
        {
            var exerciseDto = mRunnerManager.GetAllExercisesForAWorkout(int.Parse(TempData["WorkoutId2"].ToString()), null).FirstOrDefault(x => x.Id == exerciseId);
            var exerciseVm = mViewModelMapper.Map(exerciseDto);
            exerciseVm.Workout = new WorkoutViewModel { Id = int.Parse(TempData["WorkoutId2"].ToString()) };
            TempData["ExerciseId"] = exerciseId;
            return View(exerciseVm);
        }
        [HttpPost]
        public IActionResult Add(ExerciseViewModel exerciseVm)
        {
            var dto = mViewModelMapper.Map(exerciseVm);

            mRunnerManager.AddNewExercise(dto, int.Parse(TempData["WorkoutId2"].ToString()));

            var workoutId = int.Parse(TempData["WorkoutId2"].ToString());
            var runnerId = int.Parse(TempData["RunnerId2"].ToString());
            
            return RedirectToAction("Index", new
            {
                runnerId = runnerId,
                workoutId = workoutId
            });
        }
        public IActionResult Delete(int exerciseId)
        {
            mRunnerManager.DeleteExercise(new ExerciseDto { Id = exerciseId });

            return RedirectToAction("Index", new
            {
                runnerId = int.Parse(TempData["RunnerId2"].ToString()),
                workoutId = int.Parse(TempData["WorkoutId2"].ToString())
            });
        }
    }
}
