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
