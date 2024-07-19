﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shopdecor_api.Data;

#nullable disable

namespace shopdecor_api.Migrations
{
    [DbContext(typeof(SeabugDbContext))]
    partial class SeabugDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("shopdecor_api.Models.Domain.DonHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KhuyenMaiMaGiamGia")
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("LyDoHuy")
                        .HasColumnType("Nvarchar(max)");

                    b.Property<DateTime>("NgayHuy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<byte>("TTDonHang")
                        .HasColumnType("tinyint");

                    b.Property<bool>("TTThanhToan")
                        .HasColumnType("bit");

                    b.Property<int?>("TaiKhoanId")
                        .HasColumnType("int");

                    b.Property<int>("ThanhTien")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KhuyenMaiMaGiamGia");

                    b.HasIndex("TaiKhoanId");

                    b.ToTable("DonHang");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.DonHang_ChiTiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DonHangId")
                        .HasColumnType("int");

                    b.Property<int>("GiaSP")
                        .HasColumnType("int");

                    b.Property<int?>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonHangId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("DonHang_ChiTiet");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.Hinh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<string>("TenHinh")
                        .HasColumnType("Varchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SanPhamId");

                    b.ToTable("Hinh");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.HoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DonHangId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayXuatHD")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DonHangId");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.KhuyenMai", b =>
                {
                    b.Property<string>("MaGiamGia")
                        .HasColumnType("Varchar(20)");

                    b.Property<DateTime>("HSD")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LoaiGiam")
                        .HasColumnType("bit");

                    b.Property<bool>("LoaiKM")
                        .HasColumnType("bit");

                    b.Property<int>("MenhGia")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("Nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.HasKey("MaGiamGia");

                    b.ToTable("KhuyenMai");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.KichThuoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenKichThuoc")
                        .HasColumnType("Varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("KichThuoc");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.LoaiSP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenLoai")
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LoaiSP");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.MauSac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenMauSac")
                        .HasColumnType("Nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("MauSac");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KhuyenMaiMaGiamGia")
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("MoTa")
                        .HasColumnType("Nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ten")
                        .HasColumnType("Nvarchar(200)");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KhuyenMaiMaGiamGia");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.SanPham_ChiTiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Gia")
                        .HasColumnType("int");

                    b.Property<int?>("KichThuocId")
                        .HasColumnType("int");

                    b.Property<int?>("MauSacId")
                        .HasColumnType("int");

                    b.Property<int?>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KichThuocId");

                    b.HasIndex("MauSacId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("SanPham_ChiTiet");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.SanPham_Loai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LoaiSPId")
                        .HasColumnType("int");

                    b.Property<int?>("SanPhamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoaiSPId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("SanPham_Loai");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.TaiKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LoaiTK")
                        .HasColumnType("bit");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.DonHang", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.KhuyenMai", "KhuyenMai")
                        .WithMany("DonHangs")
                        .HasForeignKey("KhuyenMaiMaGiamGia");

                    b.HasOne("shopdecor_api.Models.Domain.TaiKhoan", "TaiKhoan")
                        .WithMany("DonHangs")
                        .HasForeignKey("TaiKhoanId");

                    b.Navigation("KhuyenMai");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.DonHang_ChiTiet", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.DonHang", "DonHang")
                        .WithMany("DonHang_ChiTiets")
                        .HasForeignKey("DonHangId");

                    b.HasOne("shopdecor_api.Models.Domain.SanPham", "SanPham")
                        .WithMany("DonHang_ChiTiets")
                        .HasForeignKey("SanPhamId");

                    b.Navigation("DonHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.Hinh", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.SanPham", "SanPham")
                        .WithMany("Hinhs")
                        .HasForeignKey("SanPhamId");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.HoaDon", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.DonHang", "DonHang")
                        .WithMany("HoaDons")
                        .HasForeignKey("DonHangId");

                    b.Navigation("DonHang");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.SanPham", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.KhuyenMai", "KhuyenMai")
                        .WithMany("SanPhams")
                        .HasForeignKey("KhuyenMaiMaGiamGia");

                    b.Navigation("KhuyenMai");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.SanPham_ChiTiet", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.KichThuoc", "KichThuoc")
                        .WithMany("SanPham_ChiTiets")
                        .HasForeignKey("KichThuocId");

                    b.HasOne("shopdecor_api.Models.Domain.MauSac", "MauSac")
                        .WithMany("SanPham_ChiTiets")
                        .HasForeignKey("MauSacId");

                    b.HasOne("shopdecor_api.Models.Domain.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamId");

                    b.Navigation("KichThuoc");

                    b.Navigation("MauSac");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.SanPham_Loai", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.LoaiSP", "LoaiSP")
                        .WithMany("SanPham_Loais")
                        .HasForeignKey("LoaiSPId");

                    b.HasOne("shopdecor_api.Models.Domain.SanPham", "SanPham")
                        .WithMany("SanPham_Loais")
                        .HasForeignKey("SanPhamId");

                    b.Navigation("LoaiSP");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.DonHang", b =>
                {
                    b.Navigation("DonHang_ChiTiets");

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.KhuyenMai", b =>
                {
                    b.Navigation("DonHangs");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.KichThuoc", b =>
                {
                    b.Navigation("SanPham_ChiTiets");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.LoaiSP", b =>
                {
                    b.Navigation("SanPham_Loais");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.MauSac", b =>
                {
                    b.Navigation("SanPham_ChiTiets");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.SanPham", b =>
                {
                    b.Navigation("DonHang_ChiTiets");

                    b.Navigation("Hinhs");

                    b.Navigation("SanPham_Loais");
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.TaiKhoan", b =>
                {
                    b.Navigation("DonHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
