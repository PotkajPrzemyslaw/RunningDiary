using AutoMapper;
using RunningDiary.Core;
using System.Collections.Generic;

namespace RunningDiary
{
    public class ViewModelMapper
    {
        private IMapper mMapper;

        public ViewModelMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<ExerciseDto, ExerciseViewModel>()
                      .ReverseMap();
                config.CreateMap<WorkoutDto, WorkoutViewModel>()
                      .ReverseMap();
                config.CreateMap<RunnerDto, RunnerViewModel>()
                      .ReverseMap();

            }).CreateMapper();
        }

        #region Exercise Maps

        public ExerciseViewModel Map(ExerciseDto exercise)
            => mMapper.Map<ExerciseViewModel>(exercise);

        public List<ExerciseViewModel> Map(List<ExerciseDto> exercises)
            => mMapper.Map<List<ExerciseViewModel>>(exercises);

        public ExerciseDto Map(ExerciseViewModel exercise)
            => mMapper.Map<ExerciseDto>(exercise);

        public List<ExerciseDto> Map(List<ExerciseViewModel> exercises)
            => mMapper.Map<List<ExerciseDto>>(exercises);

        #endregion

        #region Workout Maps
        public WorkoutViewModel Map(WorkoutDto workout)
            => mMapper.Map<WorkoutViewModel>(workout);

        public List<WorkoutViewModel> Map(List<WorkoutDto> workouts)
            => mMapper.Map<List<WorkoutViewModel>>(workouts);

        public WorkoutDto Map(WorkoutViewModel workout)
            => mMapper.Map<WorkoutDto>(workout);

        public List<WorkoutDto> Map(List<WorkoutViewModel> workouts)
            => mMapper.Map<List<WorkoutDto>>(workouts);

        #endregion

        #region Runner Maps
        public RunnerViewModel Map(RunnerDto runner)
            => mMapper.Map<RunnerViewModel>(runner);

        public List<RunnerViewModel> Map(List<RunnerDto> runners)
            => mMapper.Map<List<RunnerViewModel>>(runners);

        public RunnerDto Map(RunnerViewModel runner)
            => mMapper.Map<RunnerDto>(runner);

        public List<RunnerDto> Map(List<RunnerViewModel> runners)
            => mMapper.Map<List<RunnerDto>>(runners);

        #endregion
    }
}
