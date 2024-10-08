﻿using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.CategoryRepositories
{
    public class CategoryRepositetory : ICategoryRepnsitetory
    {
        private readonly SeabugDbContext _db;

        public CategoryRepositetory(SeabugDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<LoaiSP>> GetAllAsync()
        {
            return await _db.LoaiSP.ToListAsync();
        }

        public async Task<LoaiSP?> CreateAsync(LoaiSP loaisp)
        {
            await _db.LoaiSP.AddAsync(loaisp);
            await _db.SaveChangesAsync();
            return loaisp;
        }

        public async Task<LoaiSP> DeleteAync(int id)
        {
            var exiintLoai = await _db.LoaiSP.FindAsync(id);
            if (exiintLoai != null)
            {
                _db.LoaiSP.Remove(exiintLoai);
                await _db.SaveChangesAsync();
                return exiintLoai;
            }
            return null;
        }
        public async Task<LoaiSP> GetLoaiSPAsync(int id)
        {
            return await _db.LoaiSP.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<LoaiSP?> UpdatePType(LoaiSP loaisp)
        {
            var exiIntLoai = await _db.LoaiSP.FirstOrDefaultAsync(l => l.Id == loaisp.Id);
            if (exiIntLoai == null)
            {
                return null;
            }

            _db.Entry(exiIntLoai).CurrentValues.SetValues(loaisp);
            await _db.SaveChangesAsync();
            return loaisp;
        }
    }

}
