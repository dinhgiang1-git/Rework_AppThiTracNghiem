create table GIANGVIEN (
	MaGiangVien Varchar(20) primary key,
	HoTen nvarchar(50),
	GioiTinh nvarchar(10),
	NgaySinhh DATE,
	QueQuan nvarchar(100),
	MatKhau varchar(50)
);

create table SINHVIEN (
	MaSinhVien varchar(20) primary key,
	HoTen nvarchar(50),
	GioiTinh nvarchar(10),
	NgaySinh DATE,
	QueQuan nvarchar(100),
	MatKhau varchar(50),
	MaLopHoc varchar(20),
	CreateAt Date,
	UpdateAt Date
);

insert into GIANGVIEN(MaGiangVien, HoTen, GioiTinh, NgaySinhh, QueQuan, MatKhau) values 
	('123', N'Nguyen Giang Vien', 'Nam', '1995-05-20', N'Hà Nội', '123');

create table LOPHOC (
	MaLopHoc varchar(20) primary key,
	TenLopHoc nvarchar(50),
	CreateAt Date,
	UpdateAt Date,
	MaGiangVien varchar(20)
);

create table NGANHANGCAUHOI (
	MaNganHang int identity(1,1) primary key,
	TenNganHang nvarchar(100),
	CreateAt Date,
	UpdateAt Date,
	MaGiangVien varchar(20)
);

create table CAUHOI (
	MaCauHoi int identity(1,1) primary key,
	NoiDungCauHoi nvarchar(500),
	DapAnA nvarchar(100),
	DapAnB nvarchar(100),
	DapAnC nvarchar(100),
	DapAnD nvarchar(100),
	DapAnDung varchar(5),
	MaNganHang int,
	CreateAt Date,
	UpdateAt Date
);

SELECT 
    N.MaNganHang,
    N.TenNganHang,
    COUNT(C.MaCauHoi) AS SoLuongCauHoi
FROM 
    NGANHANGCAUHOI N
LEFT JOIN 
    CAUHOI C ON C.MaNganHang = N.MaNganHang
WHERE 
    N.MaGiangVien = '123'
GROUP BY 
    N.MaNganHang, N.TenNganHang
ORDER BY 
    N.MaNganHang

select * from NGANHANGCAUHOI
select * from CAUHOI
drop table SINHVIEN

select LOPHOC.MALOPHOC, LOPHOC.TenLopHoc, count(SINHVIEN.MaSinhVien) as SoLuongThanhVien 
from LOPHOC join SINHVIEN on SINHVIEN.MaLopHoc = LOPHOC.MaLopHoc 
where LOPHOC.MaGiangVien = '123' group by LOPHOC.TenLopHoc



select HoTen from GIANGVIEN where MaGiangVien = '123'

select * from SINHVIEN
select * from LOPHOC


