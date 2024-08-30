using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Interfaces.FeatureInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.FeatureRepositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly CarBookContext _carBookContext;

        public FeatureRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<List<GetFeatureByCarIdQueryResult>> GetFeatureListByCarIdDto(int id)
        {

            var FeatureList = await _carBookContext.Features.Include(t => t.CarFeatures).ToListAsync();
            List<GetFeatureByCarIdQueryResult> features = new List<GetFeatureByCarIdQueryResult>();
            foreach (var item in FeatureList)
            {
                bool check = false;

                var result = item.CarFeatures.FirstOrDefault(t => t.CarId == id && t.FeatureId == item.FeatureId);
                if (result != null)
                {
                    check = result.Available;
      
                }
                features.Add(new GetFeatureByCarIdQueryResult
                {
                    Available = check,
                    FeatureName = item.Name,
                    FeatureId=item.FeatureId,

                    CarId = id,

                });
            }

            return features;
        }
    }
}
