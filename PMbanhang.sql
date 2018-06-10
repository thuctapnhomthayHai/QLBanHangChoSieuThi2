
USE [master]
GO
/****** Object:  Database PMBanHangSieuThi******/
CREATE DATABASE PMBanHangSieuThi
Use  PMBanHangSieuThi
Go
/****** Object:  Table KhachHang    ******/
Create table KhachHang
(
MaKH char (10) primary key not null,
TenKH nvarchar(50) not null,
Diachi nvarchar(50),
SDT varchar(20),
Email nvarchar(50),
)
/******* Object: Table NhanVien******/
Create table NhanVien
(
	MaNV char(10) primary key not null,
	TenNV nvarchar(50) not null,
	NgaySinh datetime not null,
	GT nchar(20) null,
	Diachi nvarchar(50) null,
	SDT varchar(20) null,
	Email nchar(20) null,
)
/**** Object: Table NhaSanXuat*****/
Create table NhaSanXuat
(
	MaNhaSX char(10) primary key not null,
	TenNhaSX nvarchar(50) not null,
)
/***** Object: Table NhaCungCap ****/
Create table NhaCungCap
(
	MaNhaCC char(10) primary key not null,
	TenNhaCC nvarchar(50) not null,
)
/****** Object: Table LoaiHang ********/
Create table LoaiHang
(
	MaLoai char(10) primary key not null,
	TenLoai nvarchar (50) not null,

)
/***** Object: Table KhoHang****/
Create table KhoHang
(
	MaKho char(10) primary key not null,
	TenKho nvarchar(50) not null,
	Chuthich nvarchar(50),
)
/***** Object: Table DanhMucHang****/
Create table DanhMucHang
(
	MaHang char(10) primary key not null,
	TenHang nvarchar(50) not null,
	DVT nvarchar(20) not null,
	MaNhaSX char(10) not null,
	MaLoai char(10) not null,
)
alter table DanhMucHang add foreign key (MaNhaSX) references NhaSanXuat(MaNhaSX)
alter table DanhMucHang add foreign key (MaLoai) references LoaiHang(MaLoai)
/***** Object: Table HangTrongKho *****/
Create table HangTrongKho
(
	MaKho char(10) not null,
	MaHang char(10) not null,
	SoLuong int not null,
	
)
alter table HangTrongKho add foreign key (MaHang) references DanhMucHang(MaHang)
alter table HangTrongKho add foreign key (MaKho) references KhoHang(MaKho)
/***** Object: Table HoaDonNhap ****/
Create table HoaDonNhap
(
	MaHDN char(10) primary key not null,
	MaNhaCC char(10) not null,
	NgayNhap datetime not null,
	TongTien money not null,
	GhiChu nvarchar(50),
	MaNV char(10) not null,
)
alter table HoaDonNhap add foreign key (MaNV) references NhanVien(MaNV)
alter table HoaDonNhap add foreign key (MaNhaCC) references NhaCungCap(MaNhaCC)
/***** Object: Table ChiTietHoaDonNhap ****/
Create table ChiTietHoaDonNhap
(
	MaHDN char(10) primary key not null,
	MaHang char(10) not null,
	SoLuong int not null,
	DonGia money not null,
	ThanhTien money not null,
)
alter table ChiTietHoaDonNhap add foreign key (MaHang) references DanhMucHang(MaHang)
alter table ChiTietHoaDonNhap add foreign key (MaHDN) references HoaDonNhap(MaHDN)
/***** Object: Table HoaDonXuat ****/
Create table HoaDonXuat
(
	MaHDX char(10) primary key not null,
	NgayXuat datetime not null,
	TongTien money not null,
	GhiChu nvarchar(50),
	MaNV char(10) not null,
)
alter table HoaDonXuat add MaKH char(10)
alter table HoaDonXuat add MaNV char(10)
alter table HoaDonXuat add foreign key (MaNV) references NhanVien(MaNV)
alter table HoaDonXuat add foreign key (MaKH) references KhachHang(MaKH)
/***** Object: Table ChiTietHoaDonXuat****/
Create table ChiTietHoaDonXuat
(
	MaHDX char(10) primary key not null,
	MaHang char(10) not null,
	SoLuong int not null,
	DonGia money not null,
	ThanhTien money not null,
)
alter table ChiTietHoaDonXuat add foreign key (MaHDX) references HoaDonXuat(MaHDX)
alter table ChiTietHoaDonXuat add foreign key (Mahang) references DanhMucHang(MaHang)

/**** Them du lieu vao bang NhaSanXuat*****/ 
insert into NhaSanXuat(MaNhaSX,TenNhaSX)
values ('1',N'Sun house')
insert into NhaSanXuat(MaNhaSX,TenNhaSX)
values ('2',N'Kangaroo')
insert into NhaSanXuat(MaNhaSX,TenNhaSX)
values ('3',N'Unilever')
insert into NhaSanXuat(MaNhaSX,TenNhaSX)
values ('4',N'Everpia')
insert into NhaSanXuat(MaNhaSX,TenNhaSX)
values ('5',N'Channel')
/**** Them du lieu vao bang NhaCungCap *****/
insert into NhaCungCap(MaNhaCC,TenNhaCC)
values ('1','A')
insert into NhaCungCap(MaNhaCC,TenNhaCC)
values ('2','B')
insert into NhaCungCap(MaNhaCC,TenNhaCC)
values ('3','C')
insert into NhaCungCap(MaNhaCC,TenNhaCC)
values ('4','D')
insert into NhaCungCap(MaNhaCC,TenNhaCC)
values ('5','E')
/**** Them du lieu vao bang LoaiHang *****/
insert into LoaiHang(MaLoai,TenLoai)
values ('1',N'Nồi cơm điện')
insert into LoaiHang(MaLoai,TenLoai)
values ('2',N'Dầu gội')
insert into LoaiHang(MaLoai,TenLoai)
values ('3',N'Bột giặt')
insert into LoaiHang(MaLoai,TenLoai)
values ('4',N'Chăn ga gối đệm')
insert into LoaiHang(MaLoai,TenLoai)
values ('5',N'Quần áo')
/**** Them du lieu vao bang KhoHang ***/
insert into KhoHang (MaKho,TenKho)
values ('1',N'Hoàng Mai')
insert into KhoHang (MaKho,TenKho)
values ('2',N'Hoàn Kiếm')
insert into KhoHang (MaKho,TenKho)
values ('3',N'Cầu Giấy')
/**** Them du lieu vao bang HangTrongKho ****/
insert into HangTrongKho(MaKho,MaHang,SoLuong)
values ('1','1','1000')
insert into HangTrongKho(MaKho,MaHang,SoLuong)
values ('1','2','1000')
insert into HangTrongKho(MaKho,MaHang,SoLuong)
values ('2','3','1000')
insert into HangTrongKho(MaKho,MaHang,SoLuong)
values ('3','4','1000')
insert into HangTrongKho(MaKho,MaHang,SoLuong)
values ('3','5','1000')
/**** Them du lieu vao bang DanhMucHang ****/
insert into DanhMucHang(MaHang,TenHang,MaLoai,MaNhaSX,DVT)
values('1',N'Omo','3','3',N'Túi')
insert into DanhMucHang(MaHang,TenHang,MaLoai,MaNhaSX,DVT)
values('2',N'Sunsilk','3','3',N'Chai')
insert into DanhMucHang(MaHang,TenHang,MaLoai,MaNhaSX,DVT)
values('3',N'Nồi cơm điện Kangaroo','1','2',N'Chiếc')
insert into DanhMucHang(MaHang,TenHang,MaLoai,MaNhaSX,DVT)
values('4',N'Túi xách Channel','5','5',N'Chiếc')
insert into DanhMucHang(MaHang,TenHang,MaLoai,MaNhaSX,DVT)
values('5',N'Chăn Everpia','4','4',N'Chiếc')
/**** Them du lieu vao bang KhachHang ****/
insert into KhachHang(MaKH,TenKH,SDT,Diachi)
values ('1',N'Lê Hồ Bá Quang','123',N'Hoàng Quốc Việt')
insert into KhachHang(MaKH,TenKH,SDT,Diachi)
values ('2',N'Nguyễn Huy Hùng','111',N'Cầu Giấy')
insert into KhachHang(MaKH,TenKH,SDT,Diachi)
values ('3',N'Mai Thị Linh','113',N'Xuân Thủy')
insert into KhachHang(MaKH,TenKH,SDT,Diachi)
values ('4',N'Ngô Thùy Dung','112',N'Mai Dịch')
insert into KhachHang(MaKH,TenKH,SDT,Diachi)
values ('5',N'Đỗ Huy Hùng','312',N'Trần Cung')

/**** Them du lieu vao bang NhanVien ****/
insert into NhanVien(MaNV,TenNV,NgaySinh,GT,SDT)
values ('1','A','01/01/1997',N'Nam','111')
insert into NhanVien(MaNV,TenNV,NgaySinh,GT,SDT)
values ('2','B','03/04/1997',N'Nam','112')
insert into NhanVien(MaNV,TenNV,NgaySinh,GT,SDT)
values ('3','C','05/13/1992',N'Nam','113')
