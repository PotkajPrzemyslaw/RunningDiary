using Microsoft.AspNetCore.Mvc;
using RunningDiary.Core;
using System.Linq;

namespace RunningDiary.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IRunnerManager mRunnerManager;
        private readonly ViewModelMapper mViewModelMapper;

        public WorkoutController(IRunnerManager runnerManager,
                                 ViewModelMapper viewModelMapper)
        {
            mRunnerManager = runnerManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int runnerId, string filterString)
        {
            TempData["RunnerId"] = runnerId;
            TempData["RunnerId3"] = runnerId;

            var runnerDto = mRunnerManager.GetAllRunners(null)
                                          .FirstOrDefault(x => x.Id == runnerId);

            var workoutDto = mRunnerManager.GetAllWorkoutsForARunner(runnerId, filterString);

            var runnerViewModel = mViewModelMapper.Map(runnerDto);
            runnerViewModel.Workouts = mViewModelMapper.Map(workoutDto);


            return View(runnerViewModel);
        }
        public IActionResult Add()
        {
            return View(new WorkoutViewModel());
        }
        public IActionResult Edit(int workoutId)
        {
            var workoutDto = mRunnerManager.GetAllWorkoutsForARunner(int.Parse(TempData["RunnerId"].ToString()), null).FirstOrDefault(x => x.Id == workoutId);
            var workoutVm = mViewModelMapper.Map(workoutDto);
            workoutVm.Runner = new RunnerViewModel { Id = int.Parse(TempData["RunnerId"].ToString()) };
            TempData["WorkoutId"] = workoutId;
            return View(workoutVm);
        }
        [HttpPost]
        public IActionResult Edit(WorkoutViewModel workoutVm, int runnerId)
        {
            WorkoutViewModel newVm = new WorkoutViewModel { Id = int.Parse(TempData["WorkoutId"].ToString()) };
            newVm.TypeOfWorkout = workoutVm.TypeOfWorkout;
            newVm.Description = workoutVm.Description;
            newVm.DateOfWorkout = workoutVm.DateOfWorkout;

            var updateDto = mViewModelMapper.Map(newVm);

            mRunnerManager.EditWorkout(updateDto, runnerId);

            return RedirectToAction("Index", new { runnerId = runnerId });
        }
        [HttpPost]
        public IActionResult Add(WorkoutViewModel workoutVm)
        {
            var dto = mViewModelMapper.Map(workoutVm);

            mRunnerManager.AddNewWorkout(dto, int.Parse(TempData["RunnerId"].ToString()));

            return RedirectToAction("Index", new { runnerId = int.Parse(TempData["RunnerId"].ToString()) });
        }
        public IActionResult View(int workoutId)
        {
            return RedirectToAction("Index", "Exercise", new { runnerId = int.Parse(TempData["RunnerId"].ToString()), workoutId = workoutId }); //nazwa kontrolera, nazwa akcji, model
        }

        public IActionResult Delete(int workoutId)
        {
            mRunnerManager.DeleteWorkout(new WorkoutDto { Id = workoutId });

            return RedirectToAction("Index", new { runnerId = int.Parse(TempData["RunnerId"].ToString()) });
        }
    }
}