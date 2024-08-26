using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.StatisticInteraces
{
    public interface IStatisticRepository
    {
        Task<int> CarCountAsync();
        Task<int> GetLocationCountAsync();
        Task<int> GetAuthorCountAsync();
        Task<int> GetBlogCountAsync();
        Task<int> GetBrandCountAsync();
        Task<decimal> GetAvgRentForDailyAsync();
        Task<decimal> GetAvgRentForWeeklyAsync();
        Task<decimal> GetAvgRentForMonthlyAsync();
        Task<int> GetCarCountByTranmissionIsAutoAsync();
        Task<string> GetBrandNameByMaxCarAsync();
        Task<string> GetBlogTitleMaxBlogCommentAsync();
        Task<int> GetCarCountByKmSmallarThen1000Async();
        Task<int> GetCarCountByFuelGasolineOrDiselAsync();
        Task<int> GetCarCountFuelElectircAsync();
        Task<string> GetBrandAndModelByRentPriceDailyMaxAsync();
        Task<string> GetBrandAndModelByRentPriceDailyMinAsync();
    }
}
