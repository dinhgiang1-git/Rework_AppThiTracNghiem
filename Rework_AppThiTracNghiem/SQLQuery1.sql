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
	'asd', N'Nguyen H G', 'Nu', '2004-01-29', N'Quảng Ninh', 'asd', '73DCHT23', '2025-04-13'
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


CREATE TABLE CT_DETHI (
    Id INT IDENTITY PRIMARY KEY,
    MaDeThi INT,
    MaCauHoi INT,    
);

CREATE TABLE BAITHI (
    Id INT IDENTITY PRIMARY KEY,
    MaDeThi INT NOT NULL,
    MaCauHoi INT NOT NULL,
    MaSinhVien NVARCHAR(20) NOT NULL,
    DapAnChon NVARCHAR(1) NULL,
);

create table DETHI (
	MaDeThi int identity(1,1) primary key,
	TenDeThi nvarchar(100),
	MaNganHang int,
	MaGiangVien varchar(20),
	MaLop varchar(20),
	TongSoCau int,
	ThoiGianLamBai int,
	NgayBatDau DateTime,
	NgayKetThuc DateTime,
	CreateAt Date,
	UpdateAt Date
);


ALTER TABLE CT_BAITHI
ADD KhoiTao INT DEFAULT 0;

drop table DETHI
drop table CT_DETHI
delete  DETHI

select * from GIANGVIEN
select * from NGANHANGCAUHOI
delete CAUHOI
select * from LOPHOC
select * from CAUHOI
select * from CT_DETHI
delete BAITHI_KETQUA
select * from DETHI
select * from BAITHI
select * from SINHVIEN
select * from BAITHI_KETQUA
select * from DETHI


delete BAITHI_KETQUA where BAITHI_KETQUA.MaSinhVien = 'qwe'

select SINHVIEN.MaSinhVien, HoTen, TenDeThi, Diem, ThoiGianNop
from BAITHI_KETQUA
left join SINHVIEN on SINHVIEN.MaSinhVien = BAITHI_KETQUA.MaSinhVien
left join DETHI on DETHI.MaDeThi = BAITHI_KETQUA.MaDeThi

SELECT 
    SINHVIEN.MaSinhVien,
    SINHVIEN.HoTen,
    DETHI.TenDeThi,
    Diem,
    BAITHI_KETQUA.ThoiGianNop
FROM 
    SINHVIEN
    LEFT JOIN BAITHI_KETQUA ON SINHVIEN.MaSinhVien = BAITHI_KETQUA.MaSinhVien 
        AND BAITHI_KETQUA.MaDeThi = '2'
    LEFT JOIN DETHI ON BAITHI_KETQUA.MaDeThi = DETHI.MaDeThi
WHERE 
    SINHVIEN.MaLopHoc = '73DCHT23'
    AND (DETHI.MaDeThi = '2' OR DETHI.MaDeThi IS NULL)
ORDER BY 
     SINHVIEN.HoTen ASC;


select MaDeThi, TenDeThi from DETHI where MaLop = '73DCHT23'

select MaLopHoc, TenLopHoc, MaDeThi, TenDeThi 
from LOPHOC 
join DETHI on DETHI.MaLop = LOPHOC.MaLopHoc
where MaDeThi = '2'

select DETHI.TenDeThi, DETHI.NgayBatDau, DETHI.NgayKetThuc, count(BAITHI_KETQUA.MaSinhVien) as SoLuongSVLamBai 
from DETHI 
join LOPHOC on DETHI.MaLop = LOPHOC.MaLopHoc 
left join BAITHI_KETQUA on DETHI.MaDeThi = BAITHI_KETQUA.MaDeThi 
where LOPHOC.MaLopHoc = '73DCHT23' 
group by  DETHI.TenDeThi, DETHI.NgayBatDau, DETHI.NgayKetThuc


delete CT_DETHI
delete BAITHI_KETQUA

select CAUHOI.MaCauHoi, NoiDungCauHoi, DangCauHoi from CAUHOI join CT_DETHI on CT_DETHI.MaCauHoi = CAUHOI.MaCauHoi where MaDeThi = '4'

select MaSinhVien, BAITHI_KETQUA.MaDeThi, DETHI.TenDeThi, Diem, ThoiGianNop  from BAITHI_KETQUA  join DETHI on DETHI.MaDeThi = BAITHI_KETQUA.MaDeThi where MaSinhVien = 'qwe'

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

