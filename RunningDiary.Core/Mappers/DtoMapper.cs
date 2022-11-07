using AutoMapper;
using RunningDiary.Database;
using System.Collections.Generic;

namespace RunningDiary.Core
{
    public class DtoMapper
    {
        private IMapper mMapper;

        public DtoMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Exercise, ExerciseDto>()
                      //.ForMember(x => x.PriceInTotal, opt => opt.MapFrom(y => y.Price * y.Amount))
                      .ReverseMap();
                config.CreateMap<Workout, WorkoutDto>()
                      .ReverseMap();
                config.CreateMap<Runner, RunnerDto>()
                      .ReverseMap();

            }).CreateMapper();
        }

        #region Exercise Maps

        public ExerciseDto Map(Exercise exercise)
            => mMapper.Map<ExerciseDto>(exercise);

        public List<ExerciseDto> Map(List<Exercise> exercises)
            => mMapper.Map<List<ExerciseDto>>(exercises);

        public Exercise Map(ExerciseDto exercise)
            => mMapper.Map<Exercise>(exercise);

        public List<Exercise> Map(List<ExerciseDto> exercises)
            => mMapper.Map<List<Exercise>>(exercises);

        #endregion

        #region Workout Maps
        public WorkoutDto Map(Workout workout)
            => mMapper.Map<WorkoutDto>(workout);

        public List<WorkoutDto> Map(List<Workout> workouts)
            => mMapper.Map<List<WorkoutDto>>(workouts);

        public Workout Map(WorkoutDto workout)
            => mMapper.Map<Workout>(workout);

        public List<Workout> Map(List<WorkoutDto> workouts)
            => mMapper.Map<List<Workout>>(workouts);

        #endregion

        #region Runner Maps
        public RunnerDto Map(Runner runner)
            => mMapper.Map<RunnerDto>(runner);

        public List<RunnerDto> Map(List<Runner> runners)
            => mMapper.Map<List<RunnerDto>>(runners);

        public Runner Map(RunnerDto runner)
            => mMapper.Map<Runner>(runner);

        public List<Runner> Map(List<RunnerDto> runners)
            => mMapper.Map<List<Runner>>(runners);

        #endregion
    }
}
