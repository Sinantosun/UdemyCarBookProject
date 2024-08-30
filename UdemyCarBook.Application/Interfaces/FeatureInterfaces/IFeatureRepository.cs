using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.FeatureInterfaces
{
    public interface IFeatureRepository
    {
        Task<List<GetFeatureByCarIdQueryResult>> GetFeatureListByCarIdDto(int id);
    }
}
