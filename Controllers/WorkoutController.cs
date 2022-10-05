using Microsoft.AspNetCore.Mvc;
using RunningDiary.Core;
using System.Linq;

namespace RunningDiary.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IRunnerManager mRunnerManager;
        private readonly ViewModelMapper mViewModelMapper;
       // public int RunnerId { get; set; }
        public WorkoutController(IRunnerManager runnerManager,
                                 ViewModelMapper viewModelMapper)
        {
            mRunnerManager = runnerManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int runnerId, string filterString)
        {
            TempData["RunnerId"] = runnerId;


            var runnerDto = mRunnerManager.GetAllRunners(null)
                                          .FirstOrDefault(x => x.Id == runnerId);

            var workoutDto = mRunnerManager.GetAllWorkoutsForARunner(runnerId, filterString);

            var runnerViewModel = mViewModelMapper.Map(runnerDto);
            runnerViewModel.Workouts = mViewModelMapper.Map(workoutDto);


            return View(runnerViewModel);
        }
        
       /* public IActionResult Filter(int runnerId, string filterString)
        {

            var runnerDto = mRunnerManager.GetAllDoctors(null)
                                          .FirstOrDefault(x => x.Id == runnerId);

            var workoutDto = mRunnerManager.GetAllPrescriptionForADoctor(runnerId, filterString);

            var doctorViewModel = mViewModelMapper.Map(runnerDto);
            doctorViewModel.Prescriptions = mViewModelMapper.Map(workoutDto);


            return View(doctorViewModel);
        }
       */
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int workoutId)
        {
            TempData["WorkoutId"] = workoutId;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(WorkoutViewModel workoutVm)
        {
            WorkoutViewModel newVm = new WorkoutViewModel { Id = int.Parse(TempData["WorkoutId"].ToString()) };
            newVm.Name = workoutVm.Name;
            newVm.DateOfWorkout = workoutVm.DateOfWorkout;

            var dto = mViewModelMapper.Map(newVm);

            mRunnerManager.EditWorkout(dto, int.Parse(TempData["RunnerId"].ToString()));

            return RedirectToAction("Index", new { runnerId = int.Parse(TempData["RunnerId"].ToString()) });
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