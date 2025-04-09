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
drop table SINHVIEN

select LOPHOC.MALOPHOC, LOPHOC.TenLopHoc, count(SINHVIEN.MaSinhVien) as SoLuongThanhVien 
from LOPHOC join SINHVIEN on SINHVIEN.MaLopHoc = LOPHOC.MaLopHoc 
where LOPHOC.MaGiangVien = '123' group by LOPHOC.TenLopHoc



select HoTen from GIANGVIEN where MaGiangVien = '123'

select * from SINHVIEN
select * from LOPHOC


