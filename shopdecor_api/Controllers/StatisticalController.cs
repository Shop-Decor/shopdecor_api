using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Repositories.StatisticalRepositories;
using shopdecor_api.Models.DTO.StatisticalDTO;
using System;
using System.Collections.Generic;

namespace shopdecor_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalController : ControllerBase
    {
        private readonly StatisticalRepository _statisticalRepository;

        public StatisticalController(StatisticalRepository statisticalRepository)
        {
            _statisticalRepository = statisticalRepository;
        }

        [HttpGet("GetOrderStatistics")]
        public ActionResult<IEnumerable<StatisticalDTO>> GetStatistics(DateTime startDate, DateTime endDate)
        {
            var statistics = _statisticalRepository.GetOrderStatistics(startDate, endDate);
            return Ok(statistics);
        }
    }
}
