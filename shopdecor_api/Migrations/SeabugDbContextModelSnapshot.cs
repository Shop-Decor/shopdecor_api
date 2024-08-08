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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProductDetail", b =>
                {
                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DetailId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DiscountExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DiscountType")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.DonHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KhuyenMaiMaGiamGia")
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("LyDoHuy")
                        .HasColumnType("Nvarchar(max)");

                    b.Property<DateTime?>("NgayHuy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PTThanhToan")
                        .HasColumnType("bit");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("TTDonHang")
                        .HasColumnType("tinyint");

                    b.Property<bool>("TTThanhToan")
                        .HasColumnType("bit");

                    b.Property<int>("ThanhTien")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("KhuyenMaiMaGiamGia");

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

                    b.Property<string>("KichThuoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MauSac")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Link")
                        .HasColumnType("Varchar(max)");

                    b.Property<int?>("SanPhamId")
                        .HasColumnType("int");

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

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shopdecor_api.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("shopdecor_api.Models.Domain.DonHang", b =>
                {
                    b.HasOne("shopdecor_api.Models.Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("shopdecor_api.Models.Domain.KhuyenMai", "KhuyenMai")
                        .WithMany("DonHangs")
                        .HasForeignKey("KhuyenMaiMaGiamGia");

                    b.Navigation("ApplicationUser");

                    b.Navigation("KhuyenMai");
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
                        .WithMany("SanPham_ChiTiets")
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

                    b.Navigation("SanPham_ChiTiets");

                    b.Navigation("SanPham_Loais");
                });
#pragma warning restore 612, 618
        }
    }
}
