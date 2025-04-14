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
	NgaySinh Date,
	QueQuan nvarchar(100),
	MatKhau varchar(50),
	MaLopHoc varchar(20),
	CreateAt Date,
	UpdateAt Date
);

insert into GIANGVIEN(MaGiangVien, HoTen, GioiTinh, NgaySinhh, QueQuan, MatKhau) values 
	('123', N'Nguyen Giang Vien', 'Nam', '1995-05-20', N'Hà Nội', '123');
insert into SINHVIEN(MaSinhVien, HoTen, GioiTinh, NgaySinh, QueQuan, MatKhau, MaLopHoc, CreateAt) values (
	'qwe', N'Nguyen Sinh Vien', 'Nam', '2004-01-29', N'Quảng Ninh', 'qwe', '73DCHT23', '2025-04-13'
);
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

create table DETHI (
	MaDeThi int identity(1,1) primary key,
	TenDeThi nvarchar(100),
	MaNganHang int,
	MaGiangVien varchar(20),
	MaLop varchar(20),
	TongSoCau int,
	SoCauDe int,
	SoCauTrungBinh int,
	SoCauKho int,
	ThoiGianLamBai int,
	NgayBatDau DateTime,
	NgayKetThuc DateTime,
	CreateAt Date,
	UpdateAt Date
);
drop table DETHI

create table CAUHOI (
	MaCauHoi int identity(1,1) primary key,
	NoiDungCauHoi nvarchar(500),
	DapAnA nvarchar(100),
	DapAnB nvarchar(100),
	DapAnC nvarchar(100),
	DapAnD nvarchar(100),
	DapAnDung varchar(5),
	DangCauHoi nvarchar(20),
	MaNganHang int,
	CreateAt Date,
	UpdateAt Date
);

CREATE TABLE BAITHI_KETQUA (
    MaKetQua INT IDENTITY PRIMARY KEY,
    MaSinhVien NVARCHAR(50),
    MaDeThi INT,
    Diem FLOAT,
    ThoiGianBatDau DATETIME,
    ThoiGianNop DATETIME,
    SoCauDung INT,
    TongSoCau INT,
    CreateAt DATETIME DEFAULT GETDATE()
);


CREATE TABLE CT_BAITHI (
    MaBaiThi INT IDENTITY PRIMARY KEY,
    MaSinhVien NVARCHAR(50),
    MaDeThi INT,
    MaCauHoi INT,
    DapAnChon NVARCHAR(1),  -- Thí sinh chọn A/B/C/D
    ThoiGianTraLoi DATETIME NULL
);
ALTER TABLE CT_BAITHI
ADD KhoiTao INT DEFAULT 0;

delete CAUHOI
drop table CAUHOI

select * from NGANHANGCAUHOI
select * from LOPHOC
select * from CAUHOI
select * from CT_BAITHI
select * from DETHI
select * from SINHVIEN
select * from BAITHI_KETQUA




Select * from CT_BAITHI where MaDeThi = 5 and KhoiTao = 1

select CAUHOI.MaCauHoi, NoiDungCauHoi, DapAnA, DapAnB, DapAnC from CAUHOI join CT_BAITHI on CT_BAITHI.MaCauHoi = CAUHOI.MaCauHoi where CT_BAITHI.MaSinhVien = 'qwe'

delete CT_BAITHI

select MaDeThi, TenDeThi, NgayBatDau, NgayKetThuc, ThoiGianLamBai, TongSoCau 
from DETHI 
join SINHVIEN on SINHVIEN.MaLopHoc = DETHI.MaLop 
where SINHVIEN.MaSinhVien = 'qwe'


select DETHI.TenDeThi, NGANHANGCAUHOI.TenNganHang, DETHI.NgayBatDau, DETHI.NgayKetThuc  
from DETHI  
join NGANHANGCAUHOI on NGANHANGCAUHOI.MaNganHang = DETHI.MaNganHang 
where DETHI.MaDeThi = '1'

select DETHI.TenDeThi, NGANHANGCAUHOI.TenNganHang, DETHI.TongSoCau, DETHI.SoCauDe, DETHI.SoCauTrungBinh, DETHI.SoCauKho, LOPHOC.TenLopHoc, DETHI.NgayBatDau, DETHI.NgayKetThuc, DETHI.ThoiGianLamBai 
from DETHI
join NGANHANGCAUHOI on NGANHANGCAUHOI.MaNganHang = DETHI.MaNganHang 
join LOPHOC on LOPHOC.MaLopHoc = DETHI.MaLop 
where DETHI.MaDeThi = '3'

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

SELECT COUNT(*) FROM CAUHOI WHERE MaNganHang = '1'

