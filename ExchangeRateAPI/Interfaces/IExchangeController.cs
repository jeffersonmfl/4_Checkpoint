using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Interfaces
{
    public interface IExchangeController
    {
        Task<JsonResult> GetExchangeRate();
    }
}