using Microsoft.AspNetCore.Mvc;
using RunningDiary.Core;
using System.Linq;

namespace RunningDiary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRunnerManager mRunnerManager;
        private readonly ViewModelMapper mViewModelMapper;
        public HomeController(IRunnerManager runnerManager,
                                 ViewModelMapper viewModelMapper)
        {
            mRunnerManager = runnerManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(string filterString)
        {

            var runnerDtos = mRunnerManager.GetAllRunners(filterString);

            var runnerViewModels = mViewModelMapper.Map(runnerDtos);

            return View(runnerViewModels);
            
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(RunnerViewModel runnerVm)
        {
            var dto = mViewModelMapper.Map(runnerVm);

            mRunnerManager.AddNewRunner(dto);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int runnerId)
        {
            var runnerDto = mRunnerManager.GetAllRunners(null).FirstOrDefault(x => x.Id == runnerId);
            var runnerVm = mViewModelMapper.Map(runnerDto);
            TempData["RunnerId"] = runnerId;
            return View(runnerVm);
        }
        [HttpPost]
        public IActionResult Edit(RunnerViewModel runnerVm)
        {
            runnerVm.Id = int.Parse(TempData["RunnerId"].ToString());
           /* RunnerViewModel newVm = new RunnerViewModel { Id = int.Parse(TempData["RunnerId"].ToString()) };
            newVm.FirstName = runnerVm.FirstName;
            newVm.LastName = runnerVm.LastName;
            newVm.PhoneNumber = runnerVm.PhoneNumber;
            newVm.Address = runnerVm.Address;
            newVm.DateOfBirth = runnerVm.DateOfBirth;
           */
            var dto = mViewModelMapper.Map(runnerVm);

            mRunnerManager.EditRunner(dto, int.Parse(TempData["RunnerId"].ToString()));

            return RedirectToAction("Index");
        }
        public IActionResult View(int runnerId)
        {
            return RedirectToAction("Index", "Workout", new { runnerId = runnerId }); //nazwa kontrolera, nazwa akcji, model
        }

        public IActionResult Delete(int runnerId)
        {
            mRunnerManager.DeleteRunner(new RunnerDto { Id = runnerId });

            var runnerDtos = mRunnerManager.GetAllRunners(null);

            var runnerViewModels = mViewModelMapper.Map(runnerDtos);

            return RedirectToAction("Index", runnerViewModels);  //View?
        }
    }
}
