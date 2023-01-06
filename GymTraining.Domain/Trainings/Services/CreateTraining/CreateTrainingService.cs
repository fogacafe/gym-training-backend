﻿using GymTraining.Domain.Trainings.Entities;
using GymTraining.Domain.Trainings.Repositories;

namespace GymTraining.Domain.Trainings.Services.CreateTraining
{
    public class CreateTrainingService : ICreateTrainingService
    {

        private readonly ITrainingsRepository _trainingsRepository;
        public CreateTrainingService(ITrainingsRepository trainingsRepository)
        {
            _trainingsRepository = trainingsRepository;
        }

        public async Task<CreateTrainingOutput> Handle(CreateTrainingInput input, CancellationToken cancellationToken)
        {
            var training = new Training(Guid.Empty,
                name: input.Name,
                description: input.Description,
                startDate: input.StartDate,
                endDate: input.EndDate);

            await _trainingsRepository.Create(training);

            return CreateTrainingOutput.FromEntity(training);
        }
    }
}