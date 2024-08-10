using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using shopdecor_api.Data;
using shopdecor_api.Models.DTO.StatisticalDTO;

namespace shopdecor_api.Repositories.StatisticalRepositories
{
    public class StatisticalRepository
    {
        private readonly SeabugDbContext _context;
        private readonly IMapper _mapper;

        public StatisticalRepository(SeabugDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<StatisticalDTO> GetOrderStatistics(DateTime startDate, DateTime endDate)
        {
            var orders = _context.DonHang
                .Where(order => order.NgayTao >= startDate && order.NgayTao <= endDate)
                .ToList();

            var statistics = orders
                .GroupBy(order => order.NgayTao.Date) // Nhóm theo ngày
                .Select(g => new StatisticalDTO
                {
                    Ngay = g.Key,
                    SoDonHang = g.Count(),
                    TongDoanhThu = g.Sum(order => order.ThanhTien)
                })
                .ToList();

            return statistics;
        }
    }
}
