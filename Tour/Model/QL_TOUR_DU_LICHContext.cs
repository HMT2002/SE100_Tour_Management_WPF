using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tour.Model
{
    public partial class QL_TOUR_DU_LICHContext : DbContext
    {
        public QL_TOUR_DU_LICHContext()
        {
        }

        public QL_TOUR_DU_LICHContext(DbContextOptions<QL_TOUR_DU_LICHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Chiphi> Chiphis { get; set; } = null!;
        public virtual DbSet<Diadiem> Diadiems { get; set; } = null!;
        public virtual DbSet<Doan> Doans { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Khachsan> Khachsans { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Phuongtien> Phuongtiens { get; set; } = null!;
        public virtual DbSet<TbDiadiemDulich> TbDiadiemDuliches { get; set; } = null!;
        public virtual DbSet<TbKhachsan> TbKhachsans { get; set; } = null!;
        public virtual DbSet<TbNhiemvu> TbNhiemvus { get; set; } = null!;
        public virtual DbSet<TbPhuongtien> TbPhuongtiens { get; set; } = null!;
        public virtual DbSet<TbPhutrach> TbPhutraches { get; set; } = null!;
        public virtual DbSet<Tinh> Tinhs { get; set; } = null!;
        public virtual DbSet<Tour> Tours { get; set; } = null!;
        public virtual DbSet<Ve> Ves { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Initial Catalog=QL_TOUR_DU_LICH;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Acc)
                    .HasMaxLength(50)
                    .HasColumnName("ACC");

                entity.Property(e => e.Idnhanvien)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDNHANVIEN")
                    .IsFixedLength();

                entity.Property(e => e.Pass).HasColumnName("PASS");

                entity.HasOne(d => d.IdnhanvienNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Idnhanvien)
                    .HasConstraintName("LK_NHANVIEN_ACCOUNT");
            });

            modelBuilder.Entity<Chiphi>(entity =>
            {
                entity.ToTable("CHIPHI");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Phian)
                    .HasColumnType("money")
                    .HasColumnName("PHIAN");

                entity.Property(e => e.Phichoi)
                    .HasColumnType("money")
                    .HasColumnName("PHICHOI");

                entity.Property(e => e.Phikhac)
                    .HasColumnType("money")
                    .HasColumnName("PHIKHAC");

                entity.Property(e => e.Tong)
                    .HasColumnType("money")
                    .HasColumnName("TONG");
            });

            modelBuilder.Entity<Diadiem>(entity =>
            {
                entity.ToTable("DIADIEM");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Chitiet)
                    .HasMaxLength(500)
                    .HasColumnName("CHITIET");

                entity.Property(e => e.Gia)
                    .HasColumnType("money")
                    .HasColumnName("GIA");

                entity.Property(e => e.Idtinh)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDTINH")
                    .IsFixedLength();

                entity.Property(e => e.Picbi).HasColumnName("PICBI");

                entity.Property(e => e.Ten)
                    .HasMaxLength(40)
                    .HasColumnName("TEN");

                entity.HasOne(d => d.IdtinhNavigation)
                    .WithMany(p => p.Diadiems)
                    .HasForeignKey(d => d.Idtinh)
                    .HasConstraintName("LK_TINH");
            });

            modelBuilder.Entity<Doan>(entity =>
            {
                entity.ToTable("DOAN");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Chitietchuongtrinh)
                    .HasMaxLength(500)
                    .HasColumnName("CHITIETCHUONGTRINH");

                entity.Property(e => e.Idchiphi)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDCHIPHI")
                    .IsFixedLength();

                entity.Property(e => e.Idtour)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDTOUR")
                    .IsFixedLength();

                entity.Property(e => e.Ngayketthuc)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("NGAYKETTHUC");

                entity.Property(e => e.Ngaykhoihanh)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("NGAYKHOIHANH");

                entity.Property(e => e.Ten)
                    .HasMaxLength(40)
                    .HasColumnName("TEN");

                entity.HasOne(d => d.IdchiphiNavigation)
                    .WithMany(p => p.Doans)
                    .HasForeignKey(d => d.Idchiphi)
                    .HasConstraintName("LK_CHIPHI_DOAN");

                entity.HasOne(d => d.IdtourNavigation)
                    .WithMany(p => p.Doans)
                    .HasForeignKey(d => d.Idtour)
                    .HasConstraintName("LK_TOUR_DOAN");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(13)
                    .HasColumnName("CMND");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(15)
                    .HasColumnName("GIOITINH");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.Picbi).HasColumnName("PICBI");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(30)
                    .HasColumnName("TENKH");
            });

            modelBuilder.Entity<Khachsan>(entity =>
            {
                entity.ToTable("KHACHSAN");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Chitiet)
                    .HasMaxLength(500)
                    .HasColumnName("CHITIET");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Gia)
                    .HasColumnType("money")
                    .HasColumnName("GIA");

                entity.Property(e => e.Idtinh)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDTINH")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.Picbi).HasColumnName("PICBI");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .HasColumnName("SDT");

                entity.Property(e => e.Ten)
                    .HasMaxLength(50)
                    .HasColumnName("TEN");

                entity.HasOne(d => d.IdtinhNavigation)
                    .WithMany(p => p.Khachsans)
                    .HasForeignKey(d => d.Idtinh)
                    .HasConstraintName("LK_KHACHSAN_TINH");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .HasColumnName("MAIL");

                entity.Property(e => e.Picbi).HasColumnName("PICBI");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("SDT");

                entity.Property(e => e.Sldi).HasColumnName("SLDI");

                entity.Property(e => e.Ten)
                    .HasMaxLength(50)
                    .HasColumnName("TEN");
            });

            modelBuilder.Entity<Phuongtien>(entity =>
            {
                entity.ToTable("PHUONGTIEN");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Gia)
                    .HasColumnType("money")
                    .HasColumnName("GIA");

                entity.Property(e => e.Idtinh)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDTINH")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.Loai)
                    .HasMaxLength(30)
                    .HasColumnName("LOAI");

                entity.Property(e => e.Picbi).HasColumnName("PICBI");

                entity.Property(e => e.Ten)
                    .HasMaxLength(30)
                    .HasColumnName("TEN");

                entity.HasOne(d => d.IdtinhNavigation)
                    .WithMany(p => p.Phuongtiens)
                    .HasForeignKey(d => d.Idtinh)
                    .HasConstraintName("LK_PHUONGTIEN_TINH");
            });

            modelBuilder.Entity<TbDiadiemDulich>(entity =>
            {
                entity.ToTable("tb_DIADIEM_DULICH");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Iddiadiem)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDDIADIEM")
                    .IsFixedLength();

                entity.Property(e => e.Idtour)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDTOUR")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IddiadiemNavigation)
                    .WithMany(p => p.TbDiadiemDuliches)
                    .HasForeignKey(d => d.Iddiadiem)
                    .HasConstraintName("LK_DIADIEM_DULICH");

                entity.HasOne(d => d.IdtourNavigation)
                    .WithMany(p => p.TbDiadiemDuliches)
                    .HasForeignKey(d => d.Idtour)
                    .HasConstraintName("LK_TOUR_DULICH");
            });

            modelBuilder.Entity<TbKhachsan>(entity =>
            {
                entity.ToTable("tb_KHACHSAN");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Iddoan)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDDOAN")
                    .IsFixedLength();

                entity.Property(e => e.Idkhachsan)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDKHACHSAN")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IddoanNavigation)
                    .WithMany(p => p.TbKhachsans)
                    .HasForeignKey(d => d.Iddoan)
                    .HasConstraintName("LK_DOAN_KHACHSAN");

                entity.HasOne(d => d.IdkhachsanNavigation)
                    .WithMany(p => p.TbKhachsans)
                    .HasForeignKey(d => d.Idkhachsan)
                    .HasConstraintName("LK_KHACHSAN_KHACHSAN");
            });

            modelBuilder.Entity<TbNhiemvu>(entity =>
            {
                entity.ToTable("tb_NHIEMVU");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Iddoan)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDDOAN")
                    .IsFixedLength();

                entity.Property(e => e.Idnhanvien)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDNHANVIEN")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nhiemvu)
                    .HasMaxLength(20)
                    .HasColumnName("NHIEMVU");

                entity.HasOne(d => d.IddoanNavigation)
                    .WithMany(p => p.TbNhiemvus)
                    .HasForeignKey(d => d.Iddoan)
                    .HasConstraintName("LK_DOAN_NHIEMVU");

                entity.HasOne(d => d.IdnhanvienNavigation)
                    .WithMany(p => p.TbNhiemvus)
                    .HasForeignKey(d => d.Idnhanvien)
                    .HasConstraintName("LK_NHANVIEN_NHIEMVU");
            });

            modelBuilder.Entity<TbPhuongtien>(entity =>
            {
                entity.ToTable("tb_PHUONGTIEN");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Iddoan)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDDOAN")
                    .IsFixedLength();

                entity.Property(e => e.Idphuongtien)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDPHUONGTIEN")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IddoanNavigation)
                    .WithMany(p => p.TbPhuongtiens)
                    .HasForeignKey(d => d.Iddoan)
                    .HasConstraintName("LK_DOAN_PHUONGTIEN");

                entity.HasOne(d => d.IdphuongtienNavigation)
                    .WithMany(p => p.TbPhuongtiens)
                    .HasForeignKey(d => d.Idphuongtien)
                    .HasConstraintName("LK_PHUONGTIEN_PHUONGTIEN");
            });

            modelBuilder.Entity<TbPhutrach>(entity =>
            {
                entity.ToTable("tb_PHUTRACH");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Iddoan)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDDOAN")
                    .IsFixedLength();

                entity.Property(e => e.Idnhanvien)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDNHANVIEN")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.Phutrach)
                    .HasMaxLength(20)
                    .HasColumnName("PHUTRACH");

                entity.HasOne(d => d.IddoanNavigation)
                    .WithMany(p => p.TbPhutraches)
                    .HasForeignKey(d => d.Iddoan)
                    .HasConstraintName("LK_DOAN_PHUTRACH");

                entity.HasOne(d => d.IdnhanvienNavigation)
                    .WithMany(p => p.TbPhutraches)
                    .HasForeignKey(d => d.Idnhanvien)
                    .HasConstraintName("LK_NHANVIEN_PHUTRACH");
            });

            modelBuilder.Entity<Tinh>(entity =>
            {
                entity.ToTable("TINH");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.Ten)
                    .HasMaxLength(30)
                    .HasColumnName("TEN");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("TOUR");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Dacdiem)
                    .HasMaxLength(50)
                    .HasColumnName("DACDIEM");

                entity.Property(e => e.Gia)
                    .HasColumnType("money")
                    .HasColumnName("GIA");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.Loai)
                    .HasMaxLength(30)
                    .HasColumnName("LOAI");

                entity.Property(e => e.Ten)
                    .HasMaxLength(30)
                    .HasColumnName("TEN");
            });

            modelBuilder.Entity<Ve>(entity =>
            {
                entity.ToTable("VE");

                entity.Property(e => e.Id)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Gia)
                    .HasColumnType("money")
                    .HasColumnName("GIA");

                entity.Property(e => e.Iddoan)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDDOAN")
                    .IsFixedLength();

                entity.Property(e => e.Idkhach)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("IDKHACH")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.Ngaymua)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("NGAYMUA");

                entity.HasOne(d => d.IddoanNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.Iddoan)
                    .HasConstraintName("LK_VE_DOAN");

                entity.HasOne(d => d.IdkhachNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.Idkhach)
                    .HasConstraintName("LK_VE_KHACH");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
