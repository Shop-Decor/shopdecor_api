﻿using Microsoft.EntityFrameworkCore;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Data
{
    public class SeabugDbContext : DbContext
    {
        public SeabugDbContext(DbContextOptions<SeabugDbContext> options) : base(options)
        {

        }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<DonHang_ChiTiet> DonHang_ChiTiet { get; set; }
        public DbSet<Hinh> Hinh { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<KhuyenMai> KhuyenMai { get; set; }
        public DbSet<KichThuoc> KichThuoc { get; set; }
        public DbSet<LoaiSP> LoaiSP { get; set; }
        public DbSet<MauSac> MauSac { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<SanPham_ChiTiet> SanPham_ChiTiet { get; set; }
        public DbSet<SanPham_Loai> SanPham_Loai { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
    }
}