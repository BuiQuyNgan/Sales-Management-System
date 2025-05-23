﻿USE master;  
GO  
IF DB_ID (N'QLQTKD1') IS NOT NULL  
DROP DATABASE QLQTKD1;  
GO  
CREATE DATABASE QLQTKD1  
go
use QLQTKD1
go
--

--Tạo bảng Hóa đơn nợ NPP
go
create table HDNoNPP
(
	MaDNo nchar(9) not null,
	HGD	date not null,
	STTT float not null,
	TTGD nvarchar(30) not null,
	primary key(MaDNo)
)
go
-- Tạo bảng NPP
go
create table NhaPhanPhoi
( 
	MaNPP nChar(9) not null,
	TenNPP nVarchar (50) not null, 
	SDT_NPP nchar(10) not null,
	DC_NPP nVarchar(100) not null, 
	Primary key (MaNPP)
) 
go 
-- Tạo bảng Sản Phẩm
go
create table SanPham
(  	
	MaSP nChar(9) not null,
   	TenSP nVarchar(50) not null,
	DonVi nVarchar(10) not null,
	LoaiHang nvarchar(5) not null,
   	Primary key (MaSP)
)
go

-- Tạo bảng Nhân viên
Create table NhanVien
(
	MaNV nchar(9)  not null,
	TenNV nvarchar(30) not null,
	SDT_NV nchar(10) not null,
	ViTri nvarchar(30) not null,
	MatKhau char(9) not null,
	primary key(MaNV)
)
go
--Tạo bảng khách hàng
Create table KhachHang 
(
	MaKH nchar(9)  not null,
	TenKH nvarchar(30) not null,
	SDT_KH nchar(10) not null,
	DC_KH nvarchar(50) not null,
	primary key(MaKH)
)
go
--Tạo bảng Kho
create table Kho
(
	MaLH nchar(9) not null,
	HSD nvarchar(40) not null,
	SLHT int not null,
	primary key(MaLH)
)
go
-- Tạo bảng Nhập
create table Nhap
(
	MaHDN nchar(9) not null,
	MaNPP nchar(9) not null,
	MaNV nchar(9) not null,
	MaDNo nchar(9) not null,
	NgayNH date not null,
	TongTienNH float not null,
	primary key(MaHDN),
	foreign key (MaNPP) references NhaPhanPhoi(MaNPP),
	foreign key (MaNV) references NhanVien(MaNV),
	foreign key (MaDNo) references HDNoNPP(MaDNo)
)
go
-- Tạo bảng nhập chi tiết
create table Nhap_chitiet 
(
	MaHDN nchar(9) not null, 
	MaSP nchar(9) not null, 
	SLNH int not null, 
	ThanhTienNH float not null,
	GiaNhap float not null,
	primary key (MaHDN,MaSP),
	foreign key (MaSP) references SanPham(MaSP),
	foreign key (MaHDN) references Nhap(MaHDN)
)
go
-- Tạo bảng Xuất
create table Xuat
(
	MaHDX nchar(9) not null,
	NgayXH date not null,
	TongTienXH float not null,
	MaKH nchar(9) not null,
	MaNV nchar(9) not null,
	primary key (MaHDX),
	foreign key (MaKH) references KhachHang (MaKH),
	foreign key (MaNV) references NhanVien (MaNV)
)
go
--Tạo bảng xuất chi tiết
create table Xuat_chitiet 
( 
	MaHDX nchar(9) not null, 
	MaSP nchar(9) not null, 
	ThanhtienXH float not null,
	SLXH int not null, KM float null,
	GiaXuat float not null,
	primary key (MaHDX,MaSP),
	foreign key (MaSP) references SanPham(MaSP),
	foreign key (MaHDX) references Xuat(MaHDX)
) 
go 
-- Tạo bảng chứa
create table Chua
(
	MaLH nchar(9) not null,
	MaSP nchar(9) not null,
	primary key (MaLH,MaSP),
	foreign key (MaLH) references Kho(MaLH),
foreign key (MaSP) references SanPham(MaSP)
)
go
-- Chèn dữ liệu vào bảng--
--2 Nhà phân phối----
go
create or alter proc sp_NhaPhanPhoi 
as
begin
    declare @i int =1;
	declare @ma nvarchar(10),@ten nvarchar(30),@sdt nvarchar(10),@dc nvarchar(100)
    --ten:nhaphanphoi+i
	--sdt: đầu số
	--DC_NPP+i
	select @i = isnull(cast(right(max(MaNPP), 6) as int), 0) + 1 from NhaPhanPhoi
	declare @DauSo table (DauSo char(3));
    insert into @DauSo values 
        ('086'), ('096'), ('097'), ('098'), 
        ('039'), ('038'), ('037'), ('036'), 
        ('035'), ('034'), ('033'), ('032'), 
        ('091'), ('094'), ('088'), ('083'), 
        ('084'), ('085'), ('081'), ('082'), 
        ('070'), ('079'), ('077'), ('076'), 
        ('078'), ('089'), ('090'), ('093');

    while @i<=1000
    begin
		set @ma= 'NPP_'+ right('00000' + CAST(@i AS VARCHAR(5)), 5)
		set @ten='NhaPhanPhoi'+cast(@i as varchar(7))
		select @sdt = (select top 1 DauSo from @DauSo order by newid()) 
            + cast((1000000 + abs(checksum(newid())) % 9000000) as char(7));
        
        while exists (select 1 from NhanVien where SDT_NV = @sdt)
        begin
            select @sdt = (select top 1 DauSo from @DauSo order by newid()) 
                + cast((1000000 + abs(checksum(newid())) % 9000000) as char(7));
        end
		set @dc= 'DC_NPP' +cast(@i as varchar(7))
        insert into NhaPhanPhoi (MaNPP, TenNPP, SDT_NPP, DC_NPP)
        values(@ma,@ten,@sdt,@dc);
        set @i = @i + 1;
	end
end
go
exec sp_NhaPhanPhoi
select * from NhaPhanPhoi
delete NhaPhanPhoi
drop proc sp_NhaPhanPhoi
----- 3 Khách hàng ---
go
create or alter proc sp_KhachHang
as
begin
    declare @i int =1;
    declare @MaKH nchar(9)
    declare @TenKH nvarchar(30)
    declare @SDT_KH char(10)
    declare @DC_KH nvarchar(50)

    declare @DauSo table (DauSo char(3));
    insert into @DauSo values 
        ('086'), ('096'), ('097'), ('098'), ('039'), ('038'), ('037'), ('036'), ('035'), ('034'), ('033'), ('032'), 
        ('091'), ('094'), ('088'), ('083'), ('084'), ('085'), ('081'), ('082'), 
        ('070'), ('079'), ('077'), ('076'), ('078'), ('089'), ('090'), ('093');

    select @i = isnull(cast(right(max(MaKH), 6) as int), 0) + 1 from KhachHang;

    while @i<=1000
    begin
        set @MaKH = 'KH_' + right('000000' + cast(@i as varchar(6)), 6);

        set @TenKH = N'Khách hàng ' + cast(@i as varchar(10));

        select @SDT_KH = (select top 1 DauSo from @DauSo order by newid()) 
            + cast((1000000 + abs(checksum(newid())) % 9000000) as char(7));

        while exists (select 1 from KhachHang where SDT_KH = @SDT_KH)
        begin
            select @SDT_KH = (select top 1 DauSo from @DauSo order by newid()) 
                + cast((1000000 + abs(checksum(newid())) % 9000000) as char(7));
        end

        set @DC_KH = 'DC_KH' + cast(@i as varchar(10)) 
        insert into KhachHang (MaKH, TenKH, SDT_KH, DC_KH)
        values (@MaKH, @TenKH, @SDT_KH, @DC_KH);

        set @i = @i + 1;
    end
end
go
exec sp_KhachHang 
select * from KhachHang;
delete KhachHang

---- 4: sản phẩm---
go
create or alter proc sp_SanPham 
as
begin
	declare @i int =1;
	declare @ma nvarchar(9),@ten nvarchar(50),@dv nvarchar(20),
			@LH nvarchar (50),@KH nvarchar(30)
	select @i = isnull(cast(right(max(MaSP), 6) as int), 0) + 1 from SanPham
	declare @H table (H nvarchar(50));
    insert into @H values 
				(N'AV'),(N'Sữa'),(N'ĐH'),(N'GV'),(N'LT');
	declare @d table (D nvarchar (30));
	insert into @D values
				(N'Hộp'),(N'Thùng');
	WHILE @i<=1000
	BEGIN
		set @ma= 'SP_'+ right('000000' + CAST(@i AS VARCHAR(6)), 6)
		select @LH= (select top 1 h from @H order by newid()) 
		set @ten='SP_'+@LH+ cast(@i as nvarchar (7))
		SElect @dv =(select top 1 D from @D order by newid()) 
		-- Chèn dữ liệu vào bảng tạm
		INSERT INTO SanPham(MaSP, TenSP, DonVi, LoaiHang)
		VALUES (@ma, @ten, @dv, @LH);
		SET @i = @i + 1;
	end;
end;
go
exec sp_SanPham 
select * from SanPham
delete SanPham

-- 5 Nhân viên ---
go
CREATE OR ALTER PROC sp_NhanVien 
AS
BEGIN
    DECLARE @i INT = 1;
    DECLARE @sdt CHAR(10);
    DECLARE @vitri_nv NVARCHAR(30);
    DECLARE @tennv NVARCHAR(30);
    DECLARE @manv CHAR(9);
    DECLARE @vitriQuanLyCount INT = 0;
    DECLARE @password CHAR(9);

    -- Lấy giá trị tiếp theo cho mã nhân viên
    SELECT @i = ISNULL(CAST(RIGHT(MAX(manv), 6) AS INT), 0) + 1 FROM NhanVien;

    -- Bảng tạm lưu các vị trí
    DECLARE @ViTriTable TABLE (ViTri NVARCHAR(30), MaViTri CHAR(2));  
    INSERT INTO @ViTriTable VALUES 
        (N'Quản lý', 'QL'),
        (N'Nhân viên kho', 'NK'),
        (N'Nhân viên thu ngân', 'TN'),
        (N'Nhân viên bán hàng', 'BH');

    -- Bảng tạm lưu các đầu số điện thoại
    DECLARE @DauSo TABLE (DauSo CHAR(3));
    INSERT INTO @DauSo VALUES 
        ('086'), ('096'), ('097'), ('098'), ('039'), ('038'), ('037'), ('036'), ('035'), ('034'), ('033'), ('032'), 
        ('091'), ('094'), ('088'), ('083'), ('084'), ('085'), ('081'), ('082'), 
        ('070'), ('079'), ('077'), ('076'), ('078'), ('089'), ('090'), ('093');

    -- Vòng lặp để chèn 1000 nhân viên
    WHILE @i <= 1000
    BEGIN
        -- Sinh mã nhân viên
        SET @manv = 'NV_' + RIGHT('000000' + CAST(@i AS NVARCHAR(6)), 6);

        -- Sinh tên nhân viên
        SET @tennv = 'Nhân viên ' + CAST(@i AS NVARCHAR(10));

        -- Sinh số điện thoại ngẫu nhiên
        SELECT @sdt = (SELECT TOP 1 DauSo FROM @DauSo ORDER BY NEWID()) 
            + CAST((1000000 + ABS(CHECKSUM(NEWID())) % 9000000) AS CHAR(7));

        -- Đảm bảo số điện thoại không bị trùng
        WHILE EXISTS (SELECT 1 FROM NhanVien WHERE SDT_NV = @sdt)
        BEGIN
            SELECT @sdt = (SELECT TOP 1 DauSo FROM @DauSo ORDER BY NEWID()) 
                + CAST((1000000 + ABS(CHECKSUM(NEWID())) % 9000000) AS CHAR(7));
        END

        -- Sinh vị trí ngẫu nhiên
        IF @vitriQuanLyCount < 2
        BEGIN
            SELECT TOP 1 @vitri_nv = ViTri FROM @ViTriTable ORDER BY NEWID();
            IF @vitri_nv = N'Quản lý'
            BEGIN
                SET @vitriQuanLyCount = @vitriQuanLyCount + 1;
            END
        END
        ELSE
        BEGIN
            SELECT TOP 1 @vitri_nv = ViTri FROM @ViTriTable WHERE ViTri != N'Quản lý' ORDER BY NEWID();
        END

        -- Sinh mật khẩu ngẫu nhiên (2 chữ cái đầu là mã vị trí, 7 chữ số còn lại)
        SELECT TOP 1 @password = MaViTri + CAST(1000000 + ABS(CHECKSUM(NEWID())) % 9000000 AS CHAR(7))
        FROM @ViTriTable WHERE ViTri = @vitri_nv;

        -- Chèn dữ liệu vào bảng NhanVien
        INSERT INTO NhanVien (MaNV, TenNV, SDT_NV, ViTri, MatKhau)
        VALUES (@manv, @tennv, @sdt, @vitri_nv, @password);

        SET @i = @i + 1;
    END
END;
GO

exec sp_NhanVien
select * from NhanVien
delete NhanVien

--- HDN+N+NCT
go
create or alter procedure sp_Nhap
as
begin
    declare @i int = 1;
    declare @MaHDN char(9); -- mã hóa đơn nhập
    declare @NgayNH date; -- ngày nhập
    declare @TongTienNH float = 0; -- tổng tiền nhập
    declare @MaNPP char(9); -- mã nhà phân phối
    declare @MaNV char(9); -- mã nhân viên
    declare @MaDNo char(9); -- mã đơn nợ
    declare @MaSP char(9); -- mã sản phẩm
    declare @ThanhTienNH float; -- thành tiền nhập
    declare @SLNH int; -- số lượng nhập
    declare @GiaNhap float; -- giá nhập
    declare @hgd date; -- hạn giao dịch
    declare @ttgd nvarchar(30); -- tình trạng giao dịch
    declare @sttt float = 0; -- số tiền thanh toán trước

    while @i <= 1000
    begin
        set @MaHDN = 'HDN_' + right('00000' + cast(@i as varchar(5)),5);
        set @MaDNo = right('000000000' + cast(@i as varchar(9)), 9);

        -- Lấy mã nhà phân phối và nhân viên ngẫu nhiên
        select top 1 @MaNPP = MaNPP from NhaPhanPhoi order by newid();
        select top 1 @MaNV = MaNV from NhanVien where ViTri like N'%kho' order by newid();

        -- Tạo ngày nhập và hạn giao dịch
        set @NgayNH = dateadd(day, abs(checksum(newid()) % datediff(day, '2023-01-01', getdate())), '2023-01-01');
        set @hgd = dateadd(month, 6, @NgayNH);

        -- Xác định tình trạng giao dịch
        if @hgd < getdate()
            set @ttgd = N'Hoàn thành';
        else
            set @ttgd = case when abs(checksum(newid())) % 2 = 0 then N'Hoàn thành' else N'Chưa hoàn thành' end;

        set @sttt = 0

        -- Thêm dữ liệu vào bảng HDNoNPP
        insert into HDNoNPP (MaDNo, HGD, STTT, TTGD)
        values (@MaDNo, @hgd, @sttt, @ttgd);

        -- Thêm dữ liệu vào bảng Nhap
        insert into Nhap (MaHDN, MaNPP, MaNV, MaDNo, NgayNH, TongTienNH)
        values (@MaHDN, @MaNPP, @MaNV, @MaDNo, @NgayNH, @TongTienNH);

        -- Đặt lại tổng tiền nhập
        set @TongTienNH = 0;

        -- Số sản phẩm trong mỗi hóa đơn nhập
        declare @soSanPham int = abs(checksum(newid()) % 5) + 1;
        while @soSanPham > 0
        begin
            -- Kiểm tra số lượng bản ghi trong bảng Nhap_ChiTiet
            declare @y int;
            select @y = count(*) from Nhap_ChiTiet;

            if @y < 1000
            begin
                -- Random mã sản phẩm nếu đã tồn tại trong Nhap_ChiTiet thì random lại
                declare @x int = 1;
                while @x = 1
                begin
                    select top 1 @MaSP = MaSP from SanPham order by newid();
                    if exists (select 1 from Nhap_ChiTiet where MaSP = @MaSP)
                        set @x = 1; -- Nếu mã sản phẩm tồn tại thì random lại
                    else
                        set @x = 0; -- Nếu mã không tồn tại, thoát khỏi vòng lặp
                end;
            end
            else
            begin
                -- Chọn ngẫu nhiên mã sản phẩm nếu số bản ghi > 1000
                select top 1 @MaSP = MaSP from SanPham order by newid();
            end;

            -- Lấy giá nhập từ bảng Nhap_ChiTiet hoặc tự tạo ngẫu nhiên nếu không có giá
            if not exists (select GiaNhap from Nhap_ChiTiet where MaSP = @MaSP)
                set @GiaNhap = cast((rand() * (500000 - 10000) + 10000) as numeric);
            else
                select @GiaNhap = GiaNhap from Nhap_ChiTiet where MaSP = @MaSP;

            -- Lấy số lượng nhập ngẫu nhiên
            set @SLNH = cast((rand() * (500 - 200) + 200) as numeric);

            -- Tính thành tiền nhập
            set @ThanhTienNH = @SLNH * @GiaNhap;

            -- Cộng dồn tổng tiền nhập
            set @TongTienNH = @TongTienNH + @ThanhTienNH;

            -- Thêm chi tiết nhập vào bảng Nhap_ChiTiet
            insert into Nhap_ChiTiet (MaHDN, MaSP, SLNH, ThanhTienNH, GiaNhap)
            values (@MaHDN, @MaSP, @SLNH, @ThanhTienNH, @GiaNhap);

            -- Giảm số lượng sản phẩm cần thêm
            set @soSanPham = @soSanPham - 1;
        end;

        -- Cập nhật tổng tiền nhập trong bảng Nhap
        update Nhap
        set TongTienNH = @TongTienNH
        where MaHDN = @MaHDN;

        set @sttt = round(0.3 * @TongTienNH, 2);

        -- Cập nhật số tiền thanh toán trước trong bảng HDNoNPP
        update HDNoNPP
        set STTT = @sttt
        where MaDNo = @MaDNo;

        -- Tăng biến đếm và tiếp tục
        set @i = @i + 1;
    end
end;
go

exec sp_Nhap
--
select * from Nhap
select * from Nhap_chitiet
select * from HDNoNPP

--
delete Nhap
delete HDNoNPP
delete Nhap_chitiet
-- Xuất và Xuất_ChiTiet
go
create or alter procedure sp_Xuat 
as
begin
    declare @i int = 1;
    declare @MaHDX char(9);
    declare @NgayXH date;
    declare @TongTienXH float;
    declare @MaKH char(9);
    declare @MaNV char(9);
    declare @MaSP char(9);
    declare @ThanhTienXH float;
    declare @SLXH int;
    declare @KM float;
    declare @MaxDate date = getdate();  -- Ngày hiện tại
    declare @GiaXuat float;

    while @i <= 1000
    begin
        -- Tạo mã hóa đơn xuất
        set @MaHDX = 'HDX_' + right('000000' + cast(@i as varchar(5)), 5);

        -- Lấy mã khách hàng và mã nhân viên ngẫu nhiên
        select top 1 @MaKH = MaKH from KhachHang order by newid();
        select top 1 @MaNV = MaNV from NhanVien where ViTri like N'%[bán hàng,thu ngân]' order by newid();

        -- Tạo ngày xuất ngẫu nhiên
        set @NgayXH = dateadd(day, abs(checksum(newid()) % datediff(day, '2023-01-01', @MaxDate)), '2023-01-01');

        -- Khởi tạo tổng tiền xuất = 0
        set @TongTienXH = 0;

        -- Thêm dữ liệu vào bảng Xuất
        insert into Xuat (MaHDX, NgayXH, TongTienXH, MaKH, MaNV)
        values (@MaHDX, @NgayXH, @TongTienXH, @MaKH, @MaNV);

        -- Sinh dữ liệu chi tiết cho hóa đơn xuất
        declare @soSanPham int = abs(checksum(newid()) % 5) + 1;  -- Số sản phẩm trong mỗi hóa đơn xuất
        while @soSanPham > 0
        begin
            -- Lấy mã sản phẩm ngẫu nhiên
            declare @y int;
            select @y = count(*) from Xuat_chitiet;

            if @y < 1000
            begin
                -- Random mã sản phẩm nếu đã tồn tại
                declare @x int = 1;
                while @x = 1
                begin
                    select top 1 @MaSP = MaSP from SanPham order by newid();
                    if exists (select 1 from Xuat_chitiet where MaSP = @MaSP)
                        set @x = 1;
                    else
                        set @x = 0;
                        set @SLXH = CAST((RAND() * (200 - 1) + 1) AS int);
                end;
            end
            else
            begin
                declare @g int = 1;
                while @g = 1
                begin
                    select top 1 @MaSP = MaSP from SanPham order by newid();

                    -- Kiểm tra tồn kho
                    declare @xuat int, @nhap int;
                    select @xuat = isnull(sum(SLXH), 0) from Xuat_chitiet where MaSP = @MaSP;
                    select @nhap = isnull(sum(SLNH), 0) from Nhap_chitiet where MaSP = @MaSP;

                    if @nhap > @xuat
                    begin
                        set @SLXH = CAST((RAND() * (@nhap - @xuat - 1) + 1) AS int);
                        set @g = 0;
                    end
                    else
                    begin
                        set @g = 1;
                    end;
                end;
            end;

            -- Tính giá xuất
            declare @gn numeric;
            select @gn = GiaNhap from Nhap_chitiet where MaSP = @MaSP;
            set @GiaXuat = round(@gn / 0.7, 2);

            -- Tính khuyến mãi và thành tiền
            set @KM = round(abs(checksum(newid()) % 10) / 100.0, 2);
            set @ThanhTienXH = @SLXH * @GiaXuat - (@KM * @SLXH * @GiaXuat);
            set @TongTienXH = @TongTienXH + @ThanhTienXH;

            -- Thêm vào bảng Xuất_Chi tiết
            insert into Xuat_chitiet(MaHDX, MaSP, ThanhTienXH, GiaXuat, SLXH, KM)
            values (@MaHDX, @MaSP, @ThanhTienXH, @GiaXuat, @SLXH, @KM);

            set @soSanPham = @soSanPham - 1;
        end;

        -- Cập nhật tổng tiền xuất cho hóa đơn
        update Xuat
        set TongTienXH = @TongTienXH
        where MaHDX = @MaHDX;

        set @i = @i + 1;
    end;
end;
go

exec sp_Xuat;
select * from Xuat;
select * from Xuat_chitiet;
delete Xuat;
delete Xuat_chitiet;

drop proc sp_Xuat
--- 6: Kho + Chứa ---
go
create or alter procedure sp_LoHang
as
begin
    declare @i int = 1;
    declare @MaLH char(9);
    declare @MaSP char(9);
    declare @HSD nvarchar(40);
    declare @SLHT int = 0;
    declare @GiaNhap float;
    declare @GiaXuat float;
    declare @lh nvarchar(40);
    declare @nn date;
    declare @a int;
    declare @b int;

    while @i <= 1000
    begin
        -- Tạo mã lô hàng
        set @MaLH = 'LH_' + right('000000' + cast(@i as varchar(6)), 6);

        -- Lấy mã sản phẩm ngẫu nhiên từ bảng SanPham, nếu mã đã tồn tại trong bảng Chua thì random lại
        declare @x int = 1;
        while @x = 1
        begin
            select top 1 @MaSP = MaSP from SanPham order by newid();
            -- Kiểm tra xem mã sản phẩm có tồn tại trong bảng Chua hay không
            if exists (select 1 from Chua where MaSP = @MaSP)
                set @x = 1;
            else
                set @x = 0;
        end;

        -- Lấy số lượng hiện tại bằng hiệu giữa số lượng nhập và xuất
        select @a = isnull(sum(SLNH), 0) from Nhap_ChiTiet where MaSP = @MaSP;
        select @b = isnull(sum(SLXH), 0) from Xuat_ChiTiet where MaSP = @MaSP;
        set @SLHT = @a - @b;

        -- Tạo hạn sử dụng ngẫu nhiên dựa trên loại hàng
        select @lh = LoaiHang from SanPham where MaSP = @MaSP;
        set @HSD = case when @lh like N'AV' then N'6 tháng'
                        when @lh like N'GV' then N'6 tháng'
                        when @lh like N'LT' then N'2 năm'
                        when @lh like N'Sữa' then N'6 tháng'
                        else N'1 năm'
                    end;

        -- Thêm dữ liệu vào bảng Kho
        insert into Kho (MaLH, HSD, SLHT)
        values (@MaLH, @HSD, @SLHT);

        -- Thêm dữ liệu vào bảng Chua
        insert into Chua (MaLH, MaSP)
        values (@MaLH, @MaSP);

        -- Tăng biến đếm
        set @i = @i + 1;
    end
end
go

exec sp_LoHang
select * from Chua
select * from Kho
delete Chua
delete Kho

drop proc sp_LoHang
-----
DECLARE @UserName NVARCHAR(128);
SET @UserName = 'NVBH';  -- Thay 'NVTN' bằng tên người dùng mà bạn muốn kiểm tra

SELECT 
    o.name AS TableName,
    CASE 
        WHEN p.permission_name IS NOT NULL THEN 1
        ELSE 0
    END AS HasPermission,
    p.permission_name AS Permission
FROM 
    sys.objects o
LEFT JOIN 
    sys.database_permissions p ON o.object_id = p.major_id 
    AND p.grantee_principal_id = USER_ID(@UserName)
LEFT JOIN 
    sys.database_principals dp ON dp.principal_id = p.grantee_principal_id
WHERE 
    o.type = 'U'
ORDER BY 
    o.name;
	select * from KhachHang
	go
---------------------


use QLQTKD;
-----------------------------\MODULE\-----------------------------------------------------------
--Module 1 : TaoMa---
go
create or alter function TaoMa(@TenBang nvarchar(50))
returns nvarchar(30)
as
begin
	declare @MaCu nvarchar(20), @ma nvarchar(20),@MaMoi nvarchar(30)
	if @TenBang like N'SanPham'
	begin
		set @MaCu=(select max(MaSP) from SanPham)
		SET @MaCu = CAST(SUBSTRING(@MaCu, 4, 6) AS INT);

        -- T?ng ph?n s? lên 1
        SET @ma = @MaCu + 1;

        -- ??nh d?ng mã m?i v?i ti?n t? 'SP_' và ph?n s? có ?? dài 6 ch? s?
        SET @MaMoi = 'SP_' + RIGHT('000000' + CAST(@ma AS NVARCHAR(6)), 6);
	end
	else if @TenBang like N'KhachHang'
	begin
		set @MaCu=(select max(MaKH) from KhachHang)
		SET @MaCu = CAST(SUBSTRING(@MaCu, 4, 6) AS INT);

        -- T?ng ph?n s? lên 1
        SET @ma = @MaCu + 1;

        -- ??nh d?ng mã m?i v?i ti?n t? 'SP_' và ph?n s? có ?? dài 6 ch? s?
        SET @MaMoi = 'KH_' + RIGHT('000000' + CAST(@ma AS NVARCHAR(6)), 6);
	end
	else if @TenBang like N'HDNoNPP'
		begin
		set @MaCu=(select max(MaDNo) from HDNoNPP)
        -- T?ng ph?n s? lên 1
        SET @ma = @MaCu + 1;

        -- ??nh d?ng mã m?i v?i ti?n t? 'SP_' và ph?n s? có ?? dài 6 ch? s?
        SET @MaMoi = RIGHT('000000000' + CAST(@ma AS NVARCHAR(9)), 9);
	end
	else if @TenBang like N'Kho'
	begin
		set @MaCu=(select max(MaLH) from Kho)
		SET @MaCu = CAST(SUBSTRING(@MaCu, 4, 6) AS INT);

        -- T?ng ph?n s? lên 1
        SET @ma = @MaCu + 1;

        -- ??nh d?ng mã m?i v?i ti?n t? 'SP_' và ph?n s? có ?? dài 6 ch? s?
        SET @MaMoi = 'LH_' + RIGHT('000000' + CAST(@ma AS NVARCHAR(6)), 6);
	end
		else if @TenBang like N'NhanVien'
	begin
			set @MaCu=(select max(MaNV) from NhanVien)
		SET @MaCu = CAST(SUBSTRING(@MaCu, 4, 6) AS INT);

        -- T?ng ph?n s? lên 1
        SET @ma = @MaCu + 1;

        -- ??nh d?ng mã m?i v?i ti?n t? 'SP_' và ph?n s? có ?? dài 6 ch? s?
        SET @MaMoi = 'NV_' + RIGHT('000000' + CAST(@ma AS NVARCHAR(6)), 6);
	end
	else if @TenBang like N'Nhap' or @TenBang like N'Nhap_chitiet'
	begin
		set @MaCu=(select max(MaHDN) from Nhap)
		SET @MaCu = CAST(SUBSTRING(@MaCu, 5, 6) AS INT);
        -- T?ng ph?n s? lên 1
        SET @ma = @MaCu + 1;
        -- ??nh d?ng mã m?i v?i ti?n t? 'SP_' và ph?n s? có ?? dài 6 ch? s?
        SET @MaMoi = 'HDN_' + RIGHT('00000' + CAST(@ma AS NVARCHAR(5)),5);
	end
	else if @TenBang like N'Xuat' or @TenBang like N'Xuat_chitiet'
	begin
			set @MaCu=(select max(MaHDX) from Xuat)
		SET @MaCu = CAST(SUBSTRING(@MaCu, 5, 6) AS INT);

        -- T?ng ph?n s? lên 1
        SET @ma = @MaCu + 1;

        -- ??nh d?ng mã m?i v?i ti?n t? 'SP_' và ph?n s? có ?? dài 6 ch? s?
        SET @MaMoi = 'HDX_' + RIGHT('00000' + CAST(@ma AS NVARCHAR(5)),5);
	end
	else if @TenBang like N'NhaPhanPhoi'
	begin
		set @MaCu=(select max(MaNPP) from NhaPhanPhoi)
		SET @MaCu = CAST(SUBSTRING(@MaCu, 5, 6) AS INT);
        -- T?ng ph?n s? lên 1
        SET @ma = @MaCu + 1;
        -- ??nh d?ng mã m?i v?i ti?n t? 'SP_' và ph?n s? có ?? dài 6 ch? s?
        SET @MaMoi = 'NPP_' + RIGHT('00000' + CAST(@ma AS NVARCHAR(5)),5);
	end
	return @MaMoi
end

select dbo.TaoMa('Xuat_chitiet')
--Module2 CapNhatTTNV---

go
CREATE OR ALTER TRIGGER Trg_CapnhatTTNV
ON NhanVien
AFTER UPDATE
AS
BEGIN
    -- Ki?m tra s? t?n t?i c?a b?n ghi ???c c?p nh?t
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        -- Ki?m tra và c?p nh?t s? ?i?n tho?i
        IF EXISTS (SELECT 1 FROM inserted i JOIN NhanVien n ON i.MaNV = n.MaNV 
							 WHERE i.SDT_NV <> n.SDT_NV)
        BEGIN
            DECLARE @sdt CHAR(10);
            DECLARE @manv CHAR(9);

            SELECT @sdt = i.SDT_NV, @manv = i.MaNV 
            FROM inserted i;
            -- Ki?m tra n?u s? ?i?n tho?i ?ã t?n t?i trong h? th?ng
            IF EXISTS (SELECT 1 FROM NhanVien WHERE SDT_NV = @sdt)
            BEGIN
                PRINT N'S? ?i?n tho?i ?ã t?n t?i trong h? th?ng';
                ROLLBACK;
                RETURN;
            END
            DECLARE @dauso TABLE (dauso CHAR(3));
            INSERT INTO @dauso VALUES ('086'), ('096'), ('097'), ('098'), ('039'), ('038'), ('037'), 
                                       ('036'), ('035'), ('034'), ('033'), ('032'), ('091'), ('094'), 
                                       ('088'), ('083'), ('084'), ('085'), ('081'), ('082'), ('070'), 
                                       ('079'), ('077'), ('076'), ('078'), ('089'), ('090'), ('093');

            -- Ki?m tra ??u s? h?p l?
            IF EXISTS (SELECT 1 FROM @dauso WHERE dauso = LEFT(@sdt, 3))
            BEGIN
                PRINT N'C?p nh?t s? ?i?n tho?i m?i thành công';
            END
            ELSE
            BEGIN
                PRINT N'S? ?i?n tho?i không h?p l?';
                ROLLBACK; 
                RETURN;
            END
        END
        -- Ki?m tra và c?p nh?t v? trí công vi?c
        IF EXISTS (SELECT 1 FROM inserted i JOIN NhanVien n ON i.MaNV = n.MaNV 
							WHERE i.ViTri <> n.ViTri)
        BEGIN
            DECLARE @vitri NVARCHAR(50);
            SELECT @vitri = i.ViTri 
									FROM inserted i;
            DECLARE @bangvitri TABLE (vitri NVARCHAR(50));
            INSERT INTO @bangvitri VALUES (N'Qu?n lý'), (N'Nhân viên thu ngân'), 
                                          (N'Nhân viên bán hàng'), (N'Nhân viên kho');
            IF EXISTS (SELECT 1 FROM @bangvitri WHERE vitri = @vitri)
            BEGIN
                PRINT N'C?p nh?t v? trí m?i thành công';
            END
            ELSE
            BEGIN
                PRINT N'V? trí này không có trong h? th?ng';
                ROLLBACK;  -- H?y b? giao d?ch n?u có s? c?
                RETURN;
            END
        END
    END
END
GO
select * from NhanVien
UPDATE NhanVien
SET SDT_NV = '0817347562', ViTri = N'Qu?n lý'
WHERE MaNV = 'NV_000001';

---Module 3 C?p nh?t giá bán , giá nh?p
go
CREATE or alter TRIGGER Trg_CapNhatGia
ON Nhap_ChiTiet
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @MaSP NCHAR(9), @GiaNhapMoi FLOAT, @SLNH INT;
    SELECT @MaSP = MaSP, @GiaNhapMoi = GiaNhap, @SLNH = SLNH
    FROM inserted;
    -- Ki?m tra MaSP có t?n t?i trong SanPham
    IF EXISTS (SELECT 1 FROM SanPham WHERE MaSP = @MaSP)
    BEGIN
        -- N?u s?n ph?m ?ã t?n t?i
        -- C?p nh?t SLHT trong Kho
        UPDATE Kho
        SET SLHT = SLHT + @SLNH
        WHERE MaLH IN (SELECT MaLH FROM Chua WHERE MaSP = @MaSP);

        -- L?y GiaNhapCu t? Nhap_ChiTiet
        DECLARE @GiaNhapCu FLOAT;
        SELECT TOP 1 @GiaNhapCu = GiaNhap
        FROM Nhap_ChiTiet
        WHERE MaSP = @MaSP
        ORDER BY MaHDN DESC; 

        -- So sánh GiaNhapMoi và GiaNhapCu
        IF @GiaNhapMoi <> @GiaNhapCu
        BEGIN
            -- C?p nh?t GiaNhapMoi trong Nhap_ChiTiet
            UPDATE Nhap_ChiTiet
            SET GiaNhap = @GiaNhapMoi
            WHERE MaSP = @MaSP and GiaNhap = @GiaNhapCu;

            -- C?p nh?t GiaXuatMoi trong Xuat_ChiTiet
            UPDATE Xuat_ChiTiet
            SET GiaXuat = 1.3 * @GiaNhapMoi
            WHERE MaSP = @MaSP;
        END
    END
    ELSE
    BEGIN
        -- N?u s?n ph?m ch?a t?n t?i
        -- Thêm s?n ph?m m?i vào SanPham, ??m b?o cung c?p giá tr? cho MaSP
        INSERT INTO SanPham (MaSP, TenSP, DonVi, LoaiHang)
        VALUES (@MaSP, 'Ten SP Moi', 'Don Vi', 'Loai Hang'); 

        -- C?p nh?t SLHT trong Kho (gi? ??nh ?ã có MaLH)
        UPDATE Kho
        SET SLHT = @SLNH
        WHERE MaLH IN (SELECT MaLH FROM Chua WHERE MaSP = @MaSP);
		declare @maxNgayNH date,@maxNgayXH date
		SELECT @MaxNgayNH = MAX(NgayNH)
		FROM Nhap;
		SELECT @MaxNgayXH = MAX(NgayXH)
		FROM Xuat;
        -- C?p nh?t GiaNhapMoi và GiaXuatMoi vào Nhap_ChiTiet và Xuat_ChiTiet
        UPDATE Nhap_ChiTiet
        SET GiaNhap = @GiaNhapMoi
        WHERE MaSP = @MaSP 
		AND MaHDN IN (SELECT MaHDN FROM Nhap WHERE NgayNH = @MaxNgayNH);

        UPDATE Xuat_ChiTiet
        SET GiaXuat = 1.3 * @GiaNhapMoi
        WHERE MaSP = @MaSP
		AND MaHDX IN (SELECT MaHDX FROM Xuat WHERE NgayXH = @MaxNgayXH);
    END
END
DROP TRIGGER Trg_CapNhatGia
GO

-- Test---
INSERT INTO Nhap_ChiTiet (MaHDN, MaSP, SLNH, ThanhTienNH, GiaNhap)
VALUES ('HDN_01001', 'SP_000128', 50, 60000, 10000); 
INSERT INTO Nhap_ChiTiet (MaHDN, MaSP, SLNH, ThanhTienNH, GiaNhap)
VALUES ('', 'SP_000004', 50, 650000, 10000);
insert into Xuat_chitiet (MaHDX, MaSP, SLXH, ThanhTienXH, GiaXuat)
VALUES ('HDN_01001', 'SP_000128', 50, 60000, 10000);
insert into Xuat(MaHDX,NgayXH,TongTienXH,MaKH,MaNV)
values ('HDX_01001','2024-10-20',0,'KH_01001','NV_00005')
select * from Nhap
SELECT *
FROM Nhap_ChiTiet
WHERE MaHDN = 'HDN_01001' AND MaSP = 'SP_00000'
select * from Nhap_chitiet
where masp='SP_000128'
select * from Xuat_chitiet
where masp='SP_000128'

--- Module 4 Bán hàng---
go
create or alter proc BanHang(@MaSP nvarchar(10),@SLYC numeric)
as
begin
	declare @SLHT numeric, @tt nvarchar(60)
	if @MaSP is null or @MaSP=' ' and @SLYC is null or @SLYC<=0
		print N'Giao d?ch không h?p l?' 
    if not exists (select 1 from SanPham where MaSP = @MaSP )
    begin
        print N'Không có s?n ph?m này này trong h? th?ng'
        return
    end
	else
	begin
		set @SLHT= (select sum(SLHT) from kho join Chua on kho.MaLH=Chua.MaLH
									 where MaSP=@MaSP)
		if @SLHT <@SLYC
		begin
			print N'Không ?? s? l??ng hàng ?? bán'
			print N'Yêu c?u nh?p hàng'
		end
		else
			print N'Có ?? s? l??ng hàng'
			update Kho
			set SLHT=@SLHT-@SLYC
			from chua join Kho on Chua.MaLH=Kho.MaLH
			where @MaSP=MaSP
	end
end
go 

--Module 5 inHDNO---
go
create or alter proc InHDNo
as
begin
    declare @ngayhethan date
    set @ngayhethan = dateadd(month,1,getdate())
    select HDNoNPP.MaDNo, HGD, TTGD, (TongTienNH-STTT) as SoTienConNo
    from HDNoNPP join Nhap on HDNoNPP.MaDNo=Nhap.MaDNo
    where (HGD between getdate() and @ngayhethan)
        and TTGD = N'Ch?a hoàn thành'
end
exec InHDNo

--- Module6 Th?ng kê--
go
create or alter function ThongKe()
returns @bangthongke table (Ngay date,
                            DoanhThu float,
                            ChiPhi float,
                            LoiNhuan float
                            )
as
begin
    declare @ngay date = getdate()
    declare @doanhthu float
    set @doanhthu = isnull((select sum(TongTienXH) 
                    from Xuat
                    where month(NgayXH) = month(@ngay)
                    and year(NgayXH) = year(@ngay)
                    ),0)
    declare @chiphi float
    set @chiphi = isnull((select sum(TongTienNH) 
                    from Nhap
                    where month(NgayNH) = month(@ngay)
                    and year(NgayNH) = year(@ngay)
                    ),0)
    declare @loinhuan float
    set @loinhuan = @doanhthu - @chiphi
    
    insert into @bangthongke (Ngay, DoanhThu, ChiPhi, LoiNhuan)
    values (@ngay, @doanhthu, @chiphi, @loinhuan)
    return
end
go

select * from dbo.ThongKe()


---Module 9 Them HDNhap--
go
create or alter proc ThemHDN
(
    @sdt nvarchar(10),
    @manv nvarchar(10),
    @manpp nchar(9),
    @tennpp nvarchar(50),
    @dcnpp nvarchar(50)
)
as
begin
    declare @tongtiennh float = 0
    declare @ngaynh date,
            @mahdn nchar(19),
            @madno nchar(9) -- ??i thành nchar(9) cho nh?t quán v?i b?ng HDNoNPP
    declare @vitri nvarchar(50);
    select @vitri = vitri from nhanvien where manv = @manv;
    if not exists (select 1 from nhanvien where manv = @manv) 
    begin
        print N'Không có nhân viên này';
        return;
    end
    else if @vitri not like '%kho'
    begin
        print N'Không hợp lệ';
        return;
    end
    if exists (select 1 from NhaPhanPhoi where SDT_NPP = @sdt)
    begin
        set @manpp = (select manpp from NhaPhanPhoi where SDT_NPP = @sdt);
    end
    else 
    begin
        set @manpp = dbo.Taoma('NhaPhanPhoi'); 
        insert into NhaPhanPhoi (MaNPP, TenNPP, SDT_NPP, DC_NPP)
        values (@manpp, @tennpp, @sdt, @dcnpp);
    end

    -- Thêm hóa ??n nh?p
    set @mahdn = dbo.Taoma('Nhap'); 
    set @ngaynh = getdate();
    declare @hgd date
    set @hgd = dateadd(month, 6, @ngaynh)
    
    -- T?o mã ??n n? m?i
    set @madno = dbo.TaoMa('HDNoNPP');
    
    -- Chèn d? li?u vào b?ng HDNoNPP
    insert into HDNoNPP (MaDNo, HGD, STTT, TTGD)
    values (@madno, @hgd, @tongtiennh, N'Chưa hoàn thành'); -- Thay ??i TTGD n?u c?n

    -- Chèn d? li?u vào b?ng Nhap
    insert into nhap (mahdn, manpp, manv, madno, ngaynh, tongtiennh)
    values (@mahdn, @manpp, @manv, @madno, @ngaynh, @tongtiennh);
end
--Test---
exec ThemHDN 
    @sdt = '0386823004',
    @manv = 'NV_000002',
    @manpp = 'NPP_00101',
    @tennpp = 'NhaPhanPhoi1001',
    @dcnpp = 'DC_NPP1001'


select * from NhaPhanPhoi
select * from Nhap
select * from HDNoNPP
select * from nhanvien

---Module 10 Thêm Hóa ?on xu?t
go
create or alter proc ThemHDX
(		
			@sdt nvarchar(10),@Manv nvarchar(10),
			@ten nvarchar(50), @diachi nvarchar(50)
)
as
begin
	declare @NgayXH date,
			@MaHDX nvarchar(10),
			@TongtienXH float=0,
			@thanhtien float;
	declare @makh nvarchar(10)
	declare @ViTri nvarchar(50);
    select @ViTri = ViTri from NhanVien where MaNV = @MaNV;
	IF not EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @Manv) 
	BEGIN
		PRINT N'Không có nhân viên này';
	END
	else if @ViTri not like N'%[thu ngân,bán hàng]'
	begin
		print N'Không hợp lệ'
	end
	if  EXISTS (SELECT 1 FROM KhachHang WHERE SDT_KH = @SDT)
	begin
		set @makh = (select MaKH from KhachHang where SDT_KH = @SDT);
		set @MaHDX=dbo.TaoMa('Xuat')
		set @NgayXH=getdate()
	end
	else 
	begin
			set @makh=dbo.TaoMa('KhachHang')
			insert into KhachHang( MaKH,TenKH,SDT_KH,DC_KH)
			values (@makh,@ten,@sdt,@diachi)
			--Hóa ??n m?i
			set @MaHDX=dbo.TaoMa('Xuat')
			set @NgayXH=getdate()
       end
	   insert into Xuat (MaHDX,NgayXH,MaKH,MaNV,TongTienXH)
	   values (@MaHDX,@NgayXH,@makh,@Manv,@TongtienXH)
end
go
--Test
	
exec ThemHDX @sdt ='0386823504',
			 @Manv ='NV_000003',
             @ten = 'Khách 1002',
             @diachi = '123 ??a ch?'
	
delete  from xuat
where MaHDX  like 'HDX_01001'
select * from NhanVien
select * from KhachHang
select * from xuat


----Module 11 Thêm XCT--
go
CREATE OR ALTER PROCEDURE ThemXuatCT
    @mahdx NVARCHAR(10),
    @SLXH INT,
    @masp NVARCHAR(10)
AS
BEGIN
    DECLARE @thanhtien FLOAT;
    DECLARE @gx FLOAT;
    DECLARE @km FLOAT;

    -- Ki?m tra các ?i?u ki?n ??u vào
    IF @mahdx IS NULL OR LTRIM(RTRIM(@mahdx)) = '' 
        OR @SLXH <= 0 OR @SLXH IS NULL
        OR @masp IS NULL OR LTRIM(RTRIM(@masp)) = ''
    BEGIN
        PRINT N'Lỗi'
    END
    IF NOT EXISTS (SELECT 1 FROM SanPham WHERE MaSP = @masp)
    BEGIN
        PRINT N'Không tồn tại sản phẩm'
        RETURN;  
    END
    -- L?y giá xu?t và khuy?n mãi
    SELECT @km = KM, @gx = GiaXuat FROM Xuat_chitiet WHERE MaSP = @masp;
    -- Tính thành ti?n
    SET @thanhtien = @SLXH * @gx;

    -- Thêm vào b?ng Xuat_chitiet
    INSERT INTO Xuat_chitiet (MaHDX, MaSP, ThanhtienXH, SLXH, KM, GiaXuat)
    VALUES (@mahdx, @masp, @thanhtien, @SLXH, @km, @gx);

    -- C?p nh?t t?ng ti?n trong b?ng Xuat
    UPDATE Xuat
    SET TongTienXH = ISNULL(TongTienXH, 0) + @thanhtien
    WHERE MaHDX = @mahdx;
	declare @SLHT float
	exec BanHang @masp=@masp,@slyc=@slxh
    PRINT N'Thêm hóa đơn xuất thành công';
END
GO

---Test--
go
select * from Kho join Chua on chua.MaLH=kho.MaLH
where  MaSP ='SP_000006'
exec ThemXuatCT
    @mahdx ='HDX_01001',
    @SLXH =2,
    @masp ='SP_000006'
exec ThemXuatCT
    @mahdx ='HDX_01001',
    @SLXH =8,
    @masp ='SP_000006'
exec ThemXuatCT
    @mahdx ='HDX_01001',
    @SLXH =2,
    @masp ='SP_000010'
	select * from Xuat_chitiet
	where MaHDX='HDX_01001'
	select * from xuat
	where MaHDX='HDX_01001'



--Thêm s?n ph?m
go 
create or alter proc ThemSP
(
    @masp char(9),
    @tensp nvarchar(50),
    @donvi nvarchar(20),
    @loaihang nvarchar(5)
)
as 
begin
    if exists (select 1 from SanPham where MaSP = @masp)
    begin
        print N'Sản phẩm đã tồn tại'
        return
    end
    set @masp = dbo.TaoMa('SanPham')
    if @tensp is null or @tensp = ''
        or @donvi is null or @donvi = ''
        or @loaihang is null or @loaihang = ''
        return
    if exists (select 1 from SanPham where TenSP = @tensp)
    begin
        print N'Sản phẫm đã tồn tại'
        return
    end
    insert into SanPham (MaSP, TenSP, DonVi, LoaiHang)
    values (@masp, @tensp, @donvi, @loaihang)
end

exec ThemSP @masp = '', @tensp = N'SP_LT254', @donvi = N'H?p', @loaihang = N'LT'

--NhapHang
go
create or alter proc NhapHang(@MaSP nvarchar(10),@SLN numeric)
as
begin
	if @MaSP is null or @MaSP=' ' and @SLN is null or @SLN<=0
		print N'Giao dịch không hợp lệ'
	declare @SLHT numeric, @tt nvarchar(60) 
    if not exists (select 1 from SanPham where MaSP = @MaSP )
    begin
        print N'Không có sản phẩm này này trong hệ thống'
        return
    end
	else
	begin
		set @SLHT= (select sum(SLHT) from kho join Chua on kho.MaLH=Chua.MaLH
										where MaSP=@MaSP)

		if @SLHT >30
		begin
			print N'Còn hàng'
		end
		else
			print N'Nhâp hàng'
			update Kho
			set SLHT=@SLHT+@SLN
			from chua join Kho on Chua.MaLH=Kho.MaLH
			where @MaSP=MaSP
	end
end
go 
--test---
exec NhapHang @MaSP='SP_000006',@SLN= 5
select * from Kho
join Chua on kho.MaLH=Chua.MaLH
where MaSP='SP_000006'


----Nh?p chi ti?t
go
CREATE OR ALTER PROCEDURE ThemNhapCT
(   
	@mahdn NVARCHAR(10),
    @SLNH INT,
    @masp NVARCHAR(10)
)
AS
BEGIN
    DECLARE @thanhtien FLOAT;
    DECLARE @gn FLOAT;
    IF @mahdn IS NULL OR LTRIM(RTRIM(@mahdn)) = '' 
        OR @SLNH <= 0 OR @SLNH IS NULL
        OR @masp IS NULL OR LTRIM(RTRIM(@masp)) = ''
    BEGIN
        PRINT N'Lỗi'
    END
    IF  EXISTS (SELECT 1 FROM SanPham WHERE MaSP = @masp)
    BEGIN
		SELECT @gn = GiaNhap FROM Nhap_chitiet WHERE MaSP = @masp;
		-- Tính thành ti?n
		SET @thanhtien = @SLNH * @gn;

		-- Thêm vào b?ng Xuat_chitiet
		INSERT INTO Nhap_chitiet(MaHDN, MaSP, ThanhtienNH, SLNH,GiaNhap)
		VALUES (@mahdn, @masp, @thanhtien, @SLNH,@gn);

		
		UPDATE Nhap
		SET TongTienNH = ISNULL(TongTienNH, 0) + @thanhtien
		WHERE MaHDN = @mahdn;
		exec NhapHang @MaSP=@masp, @SLN=@SLNH 
		PRINT N'Thêm hóa đơn xuất thành công';
		end
END
GO

--Test--
go
select * from Nhap_chitiet
where masp ='SP_000006' 
select * from Kho join Chua on chua.MaLH=kho.MaLH
where  MaSP ='SP_000006'
exec ThemNhapCT
    @maHDN='HDN_01001',
    @SLNH =4,
    @masp ='SP_000128'

------------------------------
--Tạo key
CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'QLcsdl@123'; 
GO
CREATE CERTIFICATE Certificate_test
WITH SUBJECT = 'Protect my data';
GO
CREATE SYMMETRIC KEY SymKey_test WITH ALGORITHM = AES_128 
ENCRYPTION BY CERTIFICATE Certificate_test;

--- Mã hóa số điện thoại khách hàng---
ALTER TABLE KhachHang
ADD SDT_MH varbinary(MAX)
--
OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

UPDATE KhachHang
SET SDT_MH = EncryptByKey(Key_GUID('SymKey_test'), SDT_KH);

CLOSE SYMMETRIC KEY SymKey_test;
--
ALTER TABLE KhachHang
DROP COLUMN SDT_KH
GO
select * from KhachHang

-------------------------------------
go
CREATE OR ALTER PROCEDURE MHKH (
    @Ten NVARCHAR(30),
    @SDT NCHAR(10),
    @DC NVARCHAR(50)
)
AS
BEGIN
        -- Gọi thủ tục ThemKH để kiểm tra dữ liệu đầu vào
        EXEC ThemKH @Ten, @SDT, @DC;
		if @@ROWCOUNT>0
		begin
        -- Tiến hành mã hóa và thêm khách hàng nếu không có lỗi
			DECLARE @SDT_MH VARBINARY(MAX);
			DECLARE @Ma NCHAR(9);

			-- Mở khóa đối xứng để mã hóa dữ liệu
			OPEN SYMMETRIC KEY SymKey_test
			DECRYPTION BY CERTIFICATE Certificate_test;

			-- Tạo mã khách hàng
			SET @Ma = dbo.TaoMa(N'KhachHang');

			-- Mã hóa số điện thoại
			SET @SDT_MH = ENCRYPTBYKEY(KEY_GUID('SymKey_test'), @SDT);

			-- Đóng khóa đối xứng
			CLOSE SYMMETRIC KEY SymKey_test;
			-- Thêm khách hàng vào bảng KhachHang
			INSERT INTO KhachHang (MaKH, TenKH, DC_KH, SDT_MH)
			VALUES (@Ma, @Ten, @DC, @SDT_MH);

			PRINT N'Đã thêm khách hàng thành công';
		end
		else
		begin
        -- Xử lý lỗi, hiển thị thông báo
			PRINT N'Dữ liệu không hợp lệ ';
			RETURN;
		end
END;

---Test
EXEC MHKH 
    @Ten = N'Nguyễn Thị Lan', 
    @SDT = '0912345678', 
    @DC = N'123 Nguyễn Trãi, Hà Nội';

delete  from KhachHang
where MaKH='KH_001001'
select * from KhachHang
where MaKH='KH_001001'
------------------------------------------------------------------
---- Mã hóa số điện thoại nhà phân phối ----
select * from NhaPhanPhoi
ALTER TABLE NhaPhanPhoi
ADD SDT_MH varbinary(MAX)
--
OPEN SYMMETRIC KEY SymKey_test
DECRYPTION BY CERTIFICATE Certificate_test;
UPDATE NhaPhanPhoi
        SET SDT_MH = EncryptByKey (Key_GUID('SymKey_test'), SDT_NPP)
        FROM NhaPhanPhoi;
GO
CLOSE SYMMETRIC KEY SymKey_test;
--
alter table NhaPhanPhoi
drop column SDT_NPP
GO
select * from NhaPhanPhoi
ALTER TABLE NhaPhanPhoi
ADD SDT_NPP nchar(10)
alter table NhaPhanPhoi
drop column SDT_MH
-----------------------------------
GO
CREATE OR ALTER PROC MHNPP
							@Ten nvarchar(30),
							@SDT nchar(10),
							@DC nvarchar(50)
AS
BEGIN
        -- Gọi thủ tục ThemKH để kiểm tra dữ liệu đầu vào
        EXEC ThemNPP @Ten, @SDT, @DC;
		if @@ROWCOUNT>0
		begin
			DECLARE @SDT_MH VARBINARY(MAX)
			declare  @Ma nchar(9)
			OPEN SYMMETRIC KEY SymKey_test
			DECRYPTION BY CERTIFICATE Certificate_test

			SET @SDT_MH = ENCRYPTBYKEY(KEY_GUID('SymKey_test'),@SDT)
			set @Ma=dbo.TaoMa(N'NhaPhanPhoi')
			CLOSE SYMMETRIC KEY SymKey_test

			INSERT INTO NhaPhanPhoi(MaNPP,TenNPP,DC_NPP,SDT_MH)
			VALUES (@Ma,@Ten,@DC,@SDT_MH)
					PRINT N'Đã thêm nhà phân phối thành công';
		end
		else 
			begin
			-- Xử lý lỗi, hiển thị thông báo
			PRINT N'Dữ liệu không hợp lệ ';
			RETURN;
			end
END
--
EXEC MHNPP 
    @Ten = N' ',
    @SDT = '0912345663',
    @DC = N'DC_NPP1'
---Test
	select* from NhaPhanPhoi
	where MaNPP='NPP_01001'
	delete from NhaPhanPhoi
	where MaNPP='NPP_01001'
---------------------------------------------------------------
----Mã hoá nhân viên----

ALTER TABLE NhanVien
ADD SDT_MH varbinary(MAX)
alter table NhanVien
add MatKhau_MH varbinary(Max)
--
OPEN SYMMETRIC KEY SymKey_test
DECRYPTION BY CERTIFICATE Certificate_test;
UPDATE NhanVien
        SET SDT_MH = EncryptByKey (Key_GUID('SymKey_test'), SDT_NV)
        FROM NhanVien;
GO
CLOSE SYMMETRIC KEY SymKey_test;


OPEN SYMMETRIC KEY SymKey_test
DECRYPTION BY CERTIFICATE Certificate_test;
UPDATE NhanVien
        SET MatKhau_MH = EncryptByKey (Key_GUID('SymKey_test'), MatKhau)
        FROM NhanVien;
GO
CLOSE SYMMETRIC KEY SymKey_test;
--
alter table NhanVien
drop column SDT_NV
alter table NhanVien
drop column MatKhau
GO
select * from NhanVien
-----------------------------------
GO
CREATE OR ALTER PROC MHNV 
							@Ten nvarchar(30),
							@SDT nchar(10),
							@ViTri nvarchar(50),
							@mk nvarchar(50)
AS
BEGIN
	
        -- Gọi thủ tục ThemKH để kiểm tra dữ liệu đầu vào
        EXEC ThemNV @Ten, @SDT, @ViTri,@mk
		if @@ROWCOUNT>0
		begin
			DECLARE @SDT_MH VARBINARY(MAX)
			declare @MatKhau_MH varbinary(max)

			OPEN SYMMETRIC KEY SymKey_test
			DECRYPTION BY CERTIFICATE Certificate_test
			declare @Ma nchar(9)
			set @Ma=dbo.TaoMa(N'NhanVien')
			SET @SDT_MH = ENCRYPTBYKEY(KEY_GUID('SymKey_test'),@SDT)
			SET @MatKhau_MH = ENCRYPTBYKEY(KEY_GUID('SymKey_test'),@mk)

			CLOSE SYMMETRIC KEY SymKey_test

			INSERT INTO NhanVien(MaNV,TenNV,ViTri,SDT_MH,MatKhau_MH)
			VALUES (@Ma,@Ten,@ViTri,@SDT_MH,@MatKhau_MH)
				PRINT N'Đã thêm khách hàng thành công';
			end
			else
			begin
			-- Xử lý lỗi, hiển thị thông báo
				PRINT N'Dữ liệu không hợp lệ ';
				RETURN;
			end
		
END
--
EXEC MHNV
    @Ten = N'Nhân viên 1',
    @SDT = '0912345768',
    @ViTri = N'Nhân viên bán hàng',
	@mk='BH9475843'
--- Test
select * from NhanVien
where MaNV='NV_001001'
delete from NhanVien
where MaNV='NV_001001'

----------------------------------------------------------------Giải mã KH_--
GO
CREATE OR ALTER PROC GiaiMaKhachHang @MaKH nchar(9) = NULL
AS
BEGIN
    OPEN SYMMETRIC KEY SymKey_test
    DECRYPTION BY CERTIFICATE Certificate_test;

    SELECT MaKH, TenKH, DC_KH, 
               CONVERT(nchar(10), DecryptByKey(SDT_MH)) AS SDT_KH
        FROM KhachHang
        WHERE MaKH = @MaKH or @MaKH is null

    CLOSE SYMMETRIC KEY SymKey_test;
END
SELECT * FROM KhachHang
EXEC GiaiMaKhachHang;
EXEC GiaiMaKhachHang @MAKH = 'KH_000116'
-----------




---Giải mã NPP--
GO
CREATE OR ALTER PROC GiaiMaNhaPhanPhoi @MaNPP nchar(9) = NULL
AS
BEGIN
    OPEN SYMMETRIC KEY SymKey_test
    DECRYPTION BY CERTIFICATE Certificate_test;

    SELECT MaNPP, TenNPP, DC_NPP, 
               CONVERT(nchar(10), DecryptByKey(SDT_MH)) AS SDT_NPP
        FROM NhaPhanPhoi
        WHERE MaNPP = @MaNPP or @MaNPP is null

    CLOSE SYMMETRIC KEY SymKey_test;
END
SELECT * FROM NhaPhanPhoi
EXEC GiaiMaNhaPhanPhoi;
EXEC GiaiMaNhaPhanPhoi @MANPP = 'NPP_00002'
-----------------

-------Giải mã NV
go
CREATE OR ALTER PROC GiaiMaNhanVien @MaNV nchar(9) = NULL
AS
BEGIN
    OPEN SYMMETRIC KEY SymKey_test
    DECRYPTION BY CERTIFICATE Certificate_test;

    SELECT MaNV, TenNV, ViTri, 
               CONVERT(nchar(10), DecryptByKey(SDT_MH)) AS SDT_NV,
               CONVERT(char(9), DecryptByKey(MatKhau_MH)) AS MatKhau
        FROM NhanVien
        WHERE MaNV = @MaNV or @MaNV is null

    CLOSE SYMMETRIC KEY SymKey_test;
END;
GO

SELECT * FROM NhanVien
EXEC GiaiMaNhanVien
EXEC GiaiMaNhanVien @MANV = 'NV_000010'

select  * from NhanVien
---------------



go
CREATE or alter PROCEDURE spTimKiemNV
    @TimKiemNV NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
	if @TimKiemNV like 'NV%'
	begin
	    -- Kiểm tra nếu  @TimKiem có tồn tại trong bảng NhanVien
		IF EXISTS (SELECT 1 FROM NhanVien WHERE MaNV =  @TimKiemNV)
			BEGIN
				SELECT * FROM NhanVien WHERE MaNV =  @TimKiemNV;
			END
		ELSE
			BEGIN
				PRINT N'Thông tin không tồn tại';
		END
	end
END;
exec spTimKiemNV @TimKiemNV='NV_000001'



---Tìm kiếm SP
go
create or alter Proc spTimKiemSP
@TimKiemSP nvarchar(50)
as
begin
	 -- Kiểm tra nếu  @TimKiem có tồn tại trong bảng SanPham
        IF EXISTS (SELECT 1 FROM SanPham WHERE MaSP = @TimKiemSP)
        BEGIN
            SELECT 
			SanPham.MaSP ,
			SanPham.TenSP,
			Chua.MaLH,
			Kho.MaLH ,
			Kho.HSD,
			Kho.SLHT
            FROM SanPham
			left JOIN Chua ON SanPham.MaSP = Chua.MaSP
           left JOIN Kho ON Chua.MaLH = Kho.MaLH
            WHERE SanPham.MaSP = @TimKiemSP;
        END
        ELSE
        BEGIN
            PRINT 'Thông tin sản phẩm không tồn tại';
        END
end

go
exec spTimKiemSP 
@TimKiemSP='SP_000008'



-------Tìm kiếm KH
go
create or alter proc spTimKiemKH
@TimKiemKH nvarchar(50)
as
begin
	OPEN SYMMETRIC KEY SymKey_test 
	DECRYPTION BY CERTIFICATE Certificate_test;
	  IF EXISTS (SELECT 1 FROM KhachHang WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @TimKiemKH)
        BEGIN
            SELECT KhachHang.MaKH,
					KhachHang.TenKH,
					KhachHang.DC_KH,
					CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) as SDT_KH,
					Xuat.MaHDX,
					Xuat.NgayXH,
					Xuat.TongTienXH,
					Xuat.MaNV
            FROM KhachHang
            JOIN Xuat ON KhachHang.MaKH = Xuat.MaKH
            WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @TimKiemKH;
        END
        ELSE
        BEGIN
            PRINT N'Thông tin khách hàng không tồn tại';
        END
	 CLOSE SYMMETRIC KEY SymKey_test;
end
exec spTimKiemKH
@TimKiemKH='0812184044'

-------------Tìm kiếm NPP
go
create or alter proc spTimKiemNPP
@TimKiemNPP nvarchar(50)
as
begin
	OPEN SYMMETRIC KEY SymKey_test
    DECRYPTION BY CERTIFICATE Certificate_test;
	    IF EXISTS (SELECT 1 FROM NhaPhanPhoi WHERE CONVERT(nchar(10), DecryptByKey(SDT_MH)) = @TimKiemNPP)
        BEGIN
            SELECT  NhaPhanPhoi.MaNPP,
					NhaPhanPhoi.TenNPP,
				    NhaPhanPhoi.DC_NPP,
				    CONVERT(nchar(10), DecryptByKey(SDT_MH)) as SDT_NPP,
					Nhap.MaHDN,
					Nhap.MaNV,
					HDNoNPP.MaDNo,
					Nhap.NgayNH,
					Nhap.TongTienNH,
					HDNoNPP.HGD,
					HDNoNPP.STTT,
					HDNoNPP.TTGD
            FROM NhaPhanPhoi
			join Nhap on NhaPhanPhoi.MaNPP=Nhap.MaNPP
            JOIN HDNoNPP ON Nhap.MaDNo = HDNoNPP.MaDNo
            WHERE CONVERT(nchar(10), DecryptByKey(SDT_MH)) = @TimKiemNPP;
        END
        ELSE
        BEGIN
            PRINT 'Thông tin nhà phân phối không tồn tại';
        ENd
	 CLOSE SYMMETRIC KEY SymKey_test;
end
----Test
exec spTimKiemNPP
@TimKiemNPP='0391940806'
select * from Chua
select * from HDNoNPP
select * from KhachHang
select * from Kho
select * from NhanVien
select * from Nhap
select * from Nhap_chitiet
select * from NhaPhanPhoi
select * from SanPham
select * from Xuat
select * from Xuat_chitiet



select  * from NhanVien

---Module 7 ThemKH---
go
Create  or alter procedure ThemKH (
    @tenkh nvarchar(30),
    @sdt nchar(10),
    @diachi nvarchar(50)
)
As
Begin
    -- ki?m tra d? li?u ??u vào
    If @tenkh is null or @tenkh = ' ' or
       @sdt is null or @sdt = ' ' or
       @diachi is null or @diachi = ' ' or
       Len(@sdt) <> 10 
    Begin
        
        Return
    End
    -- ki?m tra s?t ?ã t?n t?i ch?a
    If exists (select 1 from khachhang where CONVERT(NCHAR(10), DECRYPTBYKEY(SDT_MH)) = @sdt)
    Begin
        Return
    End
	else
        begin
			declare @makh nvarchar(10)
			declare @dauso table (dauso char(3));
			IF @makh IS NULL OR @makh = ' '
			BEGIN
				SET @makh = dbo.TaoMa(N'KhachHang'); -- G?i hàm ?? t?o mã m?i
			END
            insert into @dauso values ('086'), ('096'), ('097'), ('098'), ('039'), ('038'), ('037'), 
                                           ('036'), ('035'), ('034'), ('033'), ('032'), ('091'), ('094'), 
                                           ('088'), ('083'), ('084'), ('085'), ('081'), ('082'), ('070'), 
                                           ('079'), ('077'), ('076'), ('078'), ('089'), ('090'), ('093');

                -- Ki?m tra ??u s? h?p l?
			IF NOT EXISTS (SELECT 1 FROM @dauso WHERE dauso = LEFT(@sdt, 3))
				BEGIN
					
					RETURN;
				END
			END
    -- thêm khách hàng m?i
End
---Test
go
Exec ThemKH  @tenkh = N'Huynh Tan Phát', @sdt = '0386823804', 
@diachi = N'123 ???ng a, qu?n b';
Exec ThemKH  @tenkh = ' ', @sdt = ' ', @diachi = ' ';
delete from KhachHang
where TenKH like  N'Huynh Tan Phát'

-- Module 8 Them NV--
go
create or alter proc ThemNV @sdt char(10),
                            @vitri nvarchar(50),
                            @ten nvarchar(50),
							@Mk nvarchar(13)
as
begin
    if exists (select 1 from NhanVien where CONVERT(nchar(10), DecryptByKey(SDT_MH)) = @sdt)
    begin
       
        return
    end
	if exists (select 1 from NhanVien where CONVERT(char(9), DecryptByKey(MatKhau_MH)) = @mk)
    begin
       
        return
    end
    else
    begin
        -- B?ng t?m ch?a các ??u s? h?p l?
        declare @dauso table (dauso char(3));
        insert into @dauso values ('086'), ('096'), ('097'), ('098'), ('039'), ('038'), ('037'), 
                                   ('036'), ('035'), ('034'), ('033'), ('032'), ('091'), ('094'), 
                                   ('088'), ('083'), ('084'), ('085'), ('081'), ('082'), ('070'), 
                                   ('079'), ('077'), ('076'), ('078'), ('089'), ('090'), ('093');

        -- Ki?m tra ??u s? h?p l?
        if not exists (select 1 from @dauso where dauso = left(@sdt,3))
        begin
           
            return
        end
    end
        DECLARE @ViTriTable TABLE (ViTri NVARCHAR(50), MaViTri CHAR(2));  
    INSERT INTO @ViTriTable VALUES 
        (N'Quản lý', 'QL'),
        (N'Nhân viên kho', 'NK'),
        (N'Nhân viên thu ngân', 'TN'),
        (N'Nhân viên bán hàng', 'BH');
    
    -- Kiểm tra vị trí chức vụ hợp lệ
    IF NOT EXISTS (SELECT 1 FROM @ViTriTable WHERE ViTri = @vitri)
    BEGIN
       
        RETURN
    END

    if @ten is null or @ten = ' '
    begin
        return
    end
	DECLARE @MaViTri CHAR(2);
    SELECT @MaViTri = MaViTri FROM @ViTriTable WHERE ViTri = @vitri;

    -- Kiểm tra mật khẩu: Phải có đúng 2 ký tự chức vụ + 7 số
    IF @mk IS NULL OR @mk = ' ' OR LEN(@mk) != 9 OR LEFT(@mk, 2) != @MaViTri OR ISNUMERIC(SUBSTRING(@mk, 3, 7)) = 0
    BEGIn
	
        RETURN;
    END
    declare @manv char(9)
    set @manv = (select dbo.TaoMa('NhanVien'))


end

--Test--
exec ThemNV @ten = 'Nhân viên 1002', @sdt = '0863456889', @vitri = 'Nhân viên kho',@mk='NK3452637'
select * from NhanVien

----------------------------------------------------------------------------------
----  Them NV
go
CREATE OR ALTER PROCEDURE ThemNV
(
    @tennv NVARCHAR(50),
    @sdt_nv NCHAR(10),
    @vitri NVARCHAR(100),
    @matkhau NCHAR(9),
    @Message NVARCHAR(200) OUTPUT -- Thêm tham số OUTPUT để trả về thông báo
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra dữ liệu đầu vào
    IF @tennv IS NULL OR @tennv = ' ' OR
       @sdt_nv IS NULL OR @sdt_nv = ' ' OR
       @matkhau IS NULL OR @matkhau = ' ' OR
       LEN(@sdt_nv) <> 10
    BEGIN
        SET @Message = N'Dữ liệu nhập vào không hợp lệ.';
        RETURN;
    END

    -- Mở khóa đối xứng để giải mã và kiểm tra số điện thoại đã tồn tại
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    IF EXISTS (SELECT 1 FROM nhanvien WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @sdt_nv)
    BEGIN
        SET @Message = N'Đã tồn tại nhân viên với số điện thoại này.';
        CLOSE SYMMETRIC KEY SymKey_test;
        RETURN;
    END

    CLOSE SYMMETRIC KEY SymKey_test;

    -- Tạo mã nhà phân phối mới nếu chưa có
    DECLARE @manv NVARCHAR(10);
    SET @manv = dbo.TaoMa(N'NhanVien'); -- Gọi hàm tạo mã mới

    -- Mở khóa đối xứng để mã hóa số điện thoại và mật khẩu
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    DECLARE @sdt_mh VARBINARY(MAX);
    SET @sdt_mh = EncryptByKey(Key_GUID('SymKey_test'), @sdt_nv);

    DECLARE @matkhau_mh VARBINARY(MAX);
    -- Đảm bảo mật khẩu có chiều dài phù hợp
    SET @matkhau = LEFT(@matkhau, 9); -- Giới hạn chiều dài mật khẩu là 13 ký tự (nếu cần)
    SET @matkhau_mh = EncryptByKey(Key_GUID('SymKey_test'), @matkhau);

    CLOSE SYMMETRIC KEY SymKey_test;

    -- Thêm nhân viên vào bảng
    INSERT INTO NhanVien(MaNV, TenNV, Vitri, SDT_MH, MatKhau_MH)
    VALUES (@manv, @tennv, @vitri, @sdt_mh, @matkhau_mh);

    -- Thông báo thành công
    SET @Message = N'Đã thêm nhân viên thành công.';
END;

--Test-- 
DECLARE @Message NVARCHAR(200);  -- Khai báo biến @Message

-- Gọi thủ tục và truyền tham số
EXEC ThemNV
    @tennv = N'Nhân Viên',
    @sdt_nv = N'0912345789',
    @vitri = N'Nhân viên kho',
    @matkhau = '123456789',
    @Message = @Message OUTPUT;   -- Truyền biến @Message làm tham số OUTPUT

-- In ra thông báo kết quả
PRINT @Message;

-- Giải mã thông tin nhân viên
exec GiaiMaNhanVien;

delete NhanVien
where MaNV = 'NV_001002'
-------SuaNV-----------
go
CREATE OR ALTER PROCEDURE SuaNV
(
    @manv NVARCHAR(10), -- Mã nhà phân phối cần sửa (không thay đổi)
    @tennv NVARCHAR(50),
    @sdt_nv NCHAR(10),
    @vitri NVARCHAR(100),
	@matkhau nchar(9),
    @Message NVARCHAR(200) OUTPUT -- Thêm tham số OUTPUT để trả về thông báo
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra dữ liệu đầu vào
    IF @tennv IS NULL OR @tennv = ' ' OR
       @sdt_nv IS NULL OR @sdt_nv = ' ' OR
       @matkhau IS NULL OR @matkhau = ' ' OR
       LEN(@sdt_nv) <> 10
    BEGIN
        SET @Message = N'Dữ liệu nhập vào không hợp lệ.';
        RETURN;
    END

    -- Mở khóa đối xứng để giải mã
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    -- Kiểm tra số điện thoại đã tồn tại trong bảng khác ngoài nhà phân phối đang sửa
    IF EXISTS (SELECT 1 FROM nhanvien WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @sdt_nv AND MaNV != @manv)
    BEGIN
        SET @Message = N'Đã tồn tại nhân viên với số điện thoại này.';
        CLOSE SYMMETRIC KEY SymKey_test;
        RETURN;
    END

    -- Mã hóa số điện thoại mới
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;
    DECLARE @sdt_mh VARBINARY(MAX);
    SET @sdt_mh = EncryptByKey(Key_GUID('SymKey_test'), @sdt_nv);
	declare @matkhau_mh varbinary(max)
	SET @matkhau_mh = EncryptByKey(Key_GUID('SymKey_test'), RTRIM(@matkhau));
    CLOSE SYMMETRIC KEY SymKey_test;

    -- Cập nhật thông tin nhà phân phối
    UPDATE NhanVien
    SET TenNV = @tennv, Vitri = @vitri, SDT_MH = @sdt_mh, MatKhau_MH = @matkhau_mh
    WHERE MaNV = @manv;

    -- Thông báo thành công
    SET @Message = N'Thông tin nhà phân phối đã được cập nhật thành công.';
END;


DECLARE @Message NVARCHAR(200);  -- Khai báo biến @Message

-- Gọi thủ tục và truyền tham số
EXEC SuaNV
	@manv = 'NV_000001',
    @tennv = N'Trần Văn A',
	@vitri = N'Quản lý',
    @sdt_nv = N'0912345688',
    @matkhau = 'QL3456789',
    @Message = @Message OUTPUT;   -- Truyền biến @Message làm tham số OUTPUT

-- In ra thông báo kết quả
PRINT @Message;

exec GiaiMaNhanVien
select * from NhanVien

/*
---------------------------------------------------------------------------------------------
---- Module 13 Them NPP

go
CREATE OR ALTER PROCEDURE ThemNPP
(
    @tennpp NVARCHAR(50),
    @sdt_npp NCHAR(10),
    @dc_npp NVARCHAR(100),
    @Message NVARCHAR(200) OUTPUT -- Thêm tham số OUTPUT để trả về thông báo
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra dữ liệu đầu vào
    IF @tennpp IS NULL OR @tennpp = ' ' OR
       @sdt_npp IS NULL OR @sdt_npp = ' ' OR
       @dc_npp IS NULL OR @dc_npp = ' ' OR
       LEN(@sdt_npp) <> 10
    BEGIN
        SET @Message = N'Dữ liệu nhập vào không hợp lệ.';
        RETURN;
    END

    -- Mở khóa đối xứng để giải mã
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    -- Kiểm tra số điện thoại đã tồn tại
    IF EXISTS (SELECT 1 FROM nhaphanphoi WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @sdt_npp)
    BEGIN
        SET @Message = N'Đã tồn tại nhà phân phối với số điện thoại này.';
        CLOSE SYMMETRIC KEY SymKey_test;
        RETURN;
    END

    CLOSE SYMMETRIC KEY SymKey_test;

    -- Tạo mã nhà phân phối
    DECLARE @manpp NVARCHAR(10);
    IF @manpp IS NULL OR @manpp = ' '
    BEGIN
        SET @manpp = dbo.TaoMa(N'NhaPhanPhoi'); -- Gọi hàm tạo mã mới
    END

    -- Kiểm tra đầu số hợp lệ
    DECLARE @dauso TABLE (dauso CHAR(3));
    INSERT INTO @dauso VALUES ('086'), ('096'), ('097'), ('098'), ('039'), ('038'), ('037'), 
                              ('036'), ('035'), ('034'), ('033'), ('032'), ('091'), ('094'), 
                              ('088'), ('083'), ('084'), ('085'), ('081'), ('082'), ('070'), 
                              ('079'), ('077'), ('076'), ('078'), ('089'), ('090'), ('093');

    IF NOT EXISTS (SELECT 1 FROM @dauso WHERE dauso = LEFT(@sdt_npp, 3))
    BEGIN
        SET @Message = N'Đầu số điện thoại không hợp lệ.';
        RETURN;
    END

    -- Mã hóa số điện thoại và thêm vào bảng
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;
    DECLARE @sdt_mh VARBINARY(MAX);
    SET @sdt_mh = EncryptByKey(Key_GUID('SymKey_test'), @sdt_npp);
    CLOSE SYMMETRIC KEY SymKey_test;

    INSERT INTO NhaPhanPhoi(MaNPP, TenNPP, DC_NPP, SDT_MH)
    VALUES (@manpp, @tennpp, @dc_npp, @sdt_mh);

    -- Thông báo thành công
    SET @Message = N'Đã thêm nhà phân phối thành công.';
END;


--Test--
DECLARE @Message NVARCHAR(200);  -- Khai báo biến @Message

-- Gọi thủ tục và truyền tham số
EXEC ThemNPP
    @tennpp = N'Tên Nhà Phân Phối',
    @sdt_npp = N'0912345678',
    @dc_npp = N'Địa chỉ Nhà Phân Phối',
    @Message = @Message OUTPUT;   -- Truyền biến @Message làm tham số OUTPUT

-- In ra thông báo kết quả
PRINT @Message;

---
select * from NhaPhanPhoi
exec GiaiMaNhaPhanPhoi

-------SuaNPP-----------
go
CREATE OR ALTER PROCEDURE SuaNPP
(
    @manpp NVARCHAR(10), -- Mã nhà phân phối cần sửa (không thay đổi)
    @tennpp NVARCHAR(50),
    @sdt_npp NCHAR(10),
    @dc_npp NVARCHAR(100),
    @Message NVARCHAR(200) OUTPUT -- Thêm tham số OUTPUT để trả về thông báo
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra dữ liệu đầu vào
    IF @tennpp IS NULL OR @tennpp = ' ' OR
       @sdt_npp IS NULL OR @sdt_npp = ' ' OR
       @dc_npp IS NULL OR @dc_npp = ' ' OR
       LEN(@sdt_npp) <> 10
    BEGIN
        SET @Message = N'Dữ liệu nhập vào không hợp lệ.';
        RETURN;
    END

    -- Mở khóa đối xứng để giải mã
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    -- Kiểm tra số điện thoại đã tồn tại trong bảng khác ngoài nhà phân phối đang sửa
    IF EXISTS (SELECT 1 FROM nhaphanphoi WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @sdt_npp AND MaNPP != @manpp)
    BEGIN
        SET @Message = N'Đã tồn tại nhà phân phối với số điện thoại này.';
        CLOSE SYMMETRIC KEY SymKey_test;
        RETURN;
    END

    -- Mã hóa số điện thoại mới
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;
    DECLARE @sdt_mh VARBINARY(MAX);
    SET @sdt_mh = EncryptByKey(Key_GUID('SymKey_test'), @sdt_npp);
    CLOSE SYMMETRIC KEY SymKey_test;

    -- Cập nhật thông tin nhà phân phối
    UPDATE NhaPhanPhoi
    SET TenNPP = @tennpp, DC_NPP = @dc_npp, SDT_MH = @sdt_mh
    WHERE MaNPP = @manpp;

    -- Thông báo thành công
    SET @Message = N'Thông tin nhà phân phối đã được cập nhật thành công.';
END;


DECLARE @Message NVARCHAR(200);  -- Khai báo biến @Message

-- Gọi thủ tục và truyền tham số
EXEC SuaNPP
	@manpp = 'NPP_00001',
    @tennpp = N'Tên Nhà Phân Phối',
    @sdt_npp = N'0912345688',
    @dc_npp = N'Địa chỉ Nhà Phân Phối',
    @Message = @Message OUTPUT;   -- Truyền biến @Message làm tham số OUTPUT

-- In ra thông báo kết quả
PRINT @Message;
exec GiaiMaNhaPhanPhoi

-------------------------------------------------------------------------
-- Tạo hoặc sửa stored procedure
CREATE OR ALTER PROCEDURE spDangNhap
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(50),
    @ReturnMessage NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Mở khóa đối xứng
    OPEN SYMMETRIC KEY SymKey_test 
    DECRYPTION BY CERTIFICATE Certificate_test;

    -- Kiểm tra đầu vào chống SQL Injection
    IF @TenDangNhap LIKE N'%UNION%' OR @MatKhau LIKE N'%UNION%'
        OR CHARINDEX('=', @TenDangNhap) > 0 OR CHARINDEX('=', @MatKhau) > 0
        OR CHARINDEX('--', @TenDangNhap) > 0 OR CHARINDEX('--', @MatKhau) > 0
        OR @TenDangNhap LIKE N'%1=1%' OR @MatKhau LIKE N'%1=1%'
        OR PATINDEX(N'%[;''/*]%--%', @TenDangNhap) > 0
        OR PATINDEX(N'%[;''/*]%--%', @MatKhau) > 0
    BEGIN
        SET @ReturnMessage = N'Tên đăng nhập hoặc mật khẩu không hợp lệ.';
        CLOSE SYMMETRIC KEY SymKey_test;
        RETURN;
    END

    -- Xác thực người dùng
    IF EXISTS (
        SELECT 1
        FROM NhanVien
        WHERE MaNV = @TenDangNhap 
          AND CONVERT(CHAR(50), DecryptByKey(MatKhau_MH)) = @MatKhau
    )
    BEGIN
        SET @ReturnMessage = N'Đăng nhập thành công!';
    END
    ELSE
    BEGIN
        SET @ReturnMessage = N'Tên đăng nhập hoặc mật khẩu không hợp lệ.';
    END

    -- Đóng khóa đối xứng
    CLOSE SYMMETRIC KEY SymKey_test;
END;

-- Kiểm tra stored procedure
DECLARE @Result NVARCHAR(255);

-- Trường hợp đăng nhập đúng
EXEC spDangNhap @TenDangNhap = 'NV_000010', @MatKhau = 'QL8517479', @ReturnMessage = @Result OUTPUT;
PRINT @Result;

-- Trường hợp đăng nhập sai
EXEC spDangNhap @TenDangNhap = 'user1', @MatKhau = 'wrongpassword', @ReturnMessage = @Result OUTPUT;
PRINT @Result;

-- Trường hợp SQL Injection
EXEC spDangNhap @TenDangNhap = 'user1 UNION SELECT 1', @MatKhau = 'password123', @ReturnMessage = @Result OUTPUT;
PRINT @Result;

select * from NhanVien
exec GiaiMaNhanVien
drop proc spDangNhap
---
--Thêm s?n ph?m
create or alter proc ThemSP
(
    @tensp nvarchar(50),
    @donvi nvarchar(20),
    @loaihang nvarchar(5),
    @hsd nvarchar(10),  -- Thay đổi kiểu dữ liệu của HSD thành nvarchar
    @slht int = 0,      -- Biến SLHT với giá trị mặc định là 0
    @message nvarchar(100) output  -- Biến output để trả về thông báo
)
as 
begin
    -- Tạo mã sản phẩm mới
	declare @masp nchar(9)
    set @masp = dbo.TaoMa('SanPham')

    -- Kiểm tra các trường thông tin nhập vào có hợp lệ không
    if @tensp is null or @tensp = ''
        or @donvi is null or @donvi = ''
        or @loaihang is null or @loaihang = ''
    begin
        set @message = N'Thông tin nhập vào không hợp lệ'
        return
    end

    -- Kiểm tra nếu tên sản phẩm đã tồn tại
    if exists (select 1 from SanPham where TenSP = @tensp)
    begin
        set @message = N'Sản phẩm đã tồn tại'
        return
    end

    -- Thêm thông tin sản phẩm vào bảng SanPham
    insert into SanPham (MaSP, TenSP, DonVi, LoaiHang)
    values (@masp, @tensp, @donvi, @loaihang)

    -- Tạo mã loại hàng (MaLH) mới
	declare @malh nchar(9)
    set @malh = dbo.TaoMa('Kho')

    -- Insert dữ liệu vào bảng Chua và Kho

    insert into Kho (MaLH, HSD, SLHT)
    values (@malh, @hsd, @slht)

	insert into Chua (MaLH, MaSP)
    values (@malh, @masp)

    set @message = N'Thêm sản phẩm thành công'
end

declare @message nvarchar(100)
exec ThemSP @tensp = N'SP_LT274', @donvi = N'Hộp', @loaihang = N'LT', @hsd = N'2 tháng', @message = @message output
select @message as Message

select * from SanPham
select * from Chua
select * from Kho

-----------------------------------------------------------------------------------
go
CREATE OR ALTER PROCEDURE ThemKH
(
    @tenkh NVARCHAR(50),
    @sdt_kh NCHAR(10),
    @dc_kh NVARCHAR(100),
    @Message NVARCHAR(200) OUTPUT -- Thêm tham số OUTPUT để trả về thông báo
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra dữ liệu đầu vào
    IF @tenkh IS NULL OR @tenkh = ' ' OR
       @sdt_kh IS NULL OR @sdt_kh = ' ' OR
       @dc_kh IS NULL OR @dc_kh = ' ' OR
       LEN(@sdt_kh) <> 10
    BEGIN
        SET @Message = N'Dữ liệu nhập vào không hợp lệ.';
        RETURN;
    END

    -- Mở khóa đối xứng để giải mã
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    -- Kiểm tra số điện thoại đã tồn tại
    IF EXISTS (SELECT 1 FROM KhachHang WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @sdt_kh)
    BEGIN
        SET @Message = N'Đã tồn tại khách hàng với số điện thoại này.';
        CLOSE SYMMETRIC KEY SymKey_test;
        RETURN;
    END

    CLOSE SYMMETRIC KEY SymKey_test;

    -- Tạo mã nhà phân phối
    DECLARE @makh NVARCHAR(10);
    SET @makh = dbo.TaoMa(N'KhachHang'); -- Gọi hàm tạo mã mới

    -- Mã hóa số điện thoại và thêm vào bảng
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;
    DECLARE @sdt_mh VARBINARY(MAX);
    SET @sdt_mh = EncryptByKey(Key_GUID('SymKey_test'), @sdt_kh);
    CLOSE SYMMETRIC KEY SymKey_test;

    INSERT INTO KhachHang(MaKH, TenKH, DC_KH, SDT_MH)
    VALUES (@makh, @tenkh, @dc_kh, @sdt_mh);

    -- Thông báo thành công
    SET @Message = N'Đã thêm khách hàng thành công.';
END;


--Test--
DECLARE @Message NVARCHAR(200);  -- Khai báo biến @Message

-- Gọi thủ tục và truyền tham số
EXEC ThemKH
    @tenkh = N'Nguyễn Văn',
    @sdt_kh = N'0912345678',
    @dc_kh = N'Địa chỉ Nhà Phân Phối',
    @Message = @Message OUTPUT;   -- Truyền biến @Message làm tham số OUTPUT

-- In ra thông báo kết quả
PRINT @Message;

exec GiaiMaKhachHang

-------SuaKH-----------
go
CREATE OR ALTER PROCEDURE SuaKH
(
    @makh NVARCHAR(10), -- Mã nhà phân phối cần sửa (không thay đổi)
    @tenkh NVARCHAR(50),
    @sdt_kh NCHAR(10),
    @dc_kh NVARCHAR(100),
    @Message NVARCHAR(200) OUTPUT -- Thêm tham số OUTPUT để trả về thông báo
)
AS
BEGIN
    SET NOCOUNT ON;

    IF @tenkh IS NULL OR @tenkh = ' ' OR
       @sdt_kh IS NULL OR @sdt_kh = ' ' OR
       @dc_kh IS NULL OR @dc_kh = ' ' OR
       LEN(@sdt_kh) <> 10
    BEGIN
        SET @Message = N'Dữ liệu nhập vào không hợp lệ.';
        RETURN;
    END

    -- Mở khóa đối xứng để giải mã
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    -- Kiểm tra số điện thoại đã tồn tại trong bảng khác ngoài nhà phân phối đang sửa
    IF EXISTS (SELECT 1 FROM KhachHang WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @sdt_kh AND MaKH != @makh)
    BEGIN
        SET @Message = N'Đã tồn tại khách hàng với số điện thoại này.';
        CLOSE SYMMETRIC KEY SymKey_test;
        RETURN;
    END

    -- Mã hóa số điện thoại mới
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;
    DECLARE @sdt_mh VARBINARY(MAX);
    SET @sdt_mh = EncryptByKey(Key_GUID('SymKey_test'), @sdt_kh);
    CLOSE SYMMETRIC KEY SymKey_test;

    -- Cập nhật thông tin nhà phân phối
    UPDATE KhachHang
    SET TenKH = @tenkh, DC_KH = @dc_kh, SDT_MH = @sdt_mh
    WHERE MaKH = @makh;

    -- Thông báo thành công
    SET @Message = N'Thông tin khách hàng đã được cập nhật thành công.';
END;

DECLARE @Message NVARCHAR(200);  -- Khai báo biến @Message

-- Gọi thủ tục và truyền tham số
EXEC SuaKH
	@makh = 'KH_000001',
    @tenkh = N'Khách hàng',
    @sdt_kh = N'0912345688',
    @dc_kh = N'Địa chỉ ',
    @Message = @Message OUTPUT;   -- Truyền biến @Message làm tham số OUTPUT

-- In ra thông báo kết quả
PRINT @Message;

exec GiaiMaKhachHang
*/
---------------------------------------------------------------------------------


----  Them NV
go
CREATE OR ALTER PROCEDURE ThemNV
(
    @tennv NVARCHAR(50),
    @sdt_nv NCHAR(10),
    @vitri NVARCHAR(100),
    @matkhau NCHAR(9),
    @Message NVARCHAR(200) OUTPUT -- Thêm tham số OUTPUT để trả về thông báo
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra dữ liệu đầu vào
    IF @tennv IS NULL OR @tennv = ' ' OR
       @sdt_nv IS NULL OR @sdt_nv = ' ' OR
       @matkhau IS NULL OR @matkhau = ' ' OR
       LEN(@sdt_nv) <> 10
    BEGIN
        SET @Message = N'Dữ liệu nhập vào không hợp lệ.';
        RETURN;
    END

    -- Mở khóa đối xứng để giải mã và kiểm tra số điện thoại đã tồn tại
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    IF EXISTS (SELECT 1 FROM nhanvien WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @sdt_nv)
    BEGIN
        SET @Message = N'Đã tồn tại nhân viên với số điện thoại này.';
        CLOSE SYMMETRIC KEY SymKey_test;
        RETURN;
    END

    CLOSE SYMMETRIC KEY SymKey_test;

    -- Tạo mã nhà phân phối mới nếu chưa có
    DECLARE @manv NVARCHAR(10);
    SET @manv = dbo.TaoMa(N'NhanVien'); -- Gọi hàm tạo mã mới

    -- Mở khóa đối xứng để mã hóa số điện thoại và mật khẩu
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    DECLARE @sdt_mh VARBINARY(MAX);
    SET @sdt_mh = EncryptByKey(Key_GUID('SymKey_test'), @sdt_nv);

    DECLARE @matkhau_mh VARBINARY(MAX);
    -- Đảm bảo mật khẩu có chiều dài phù hợp
    SET @matkhau = LEFT(@matkhau, 9); -- Giới hạn chiều dài mật khẩu là 13 ký tự (nếu cần)
    SET @matkhau_mh = EncryptByKey(Key_GUID('SymKey_test'), @matkhau);

    CLOSE SYMMETRIC KEY SymKey_test;

    -- Thêm nhân viên vào bảng
    INSERT INTO NhanVien(MaNV, TenNV, Vitri, SDT_MH, MatKhau_MH)
    VALUES (@manv, @tennv, @vitri, @sdt_mh, @matkhau_mh);

    -- Thông báo thành công
    SET @Message = N'Đã thêm nhân viên thành công.';
END;

--Test-- 
DECLARE @Message NVARCHAR(200);  -- Khai báo biến @Message

-- Gọi thủ tục và truyền tham số
EXEC ThemNV
    @tennv = N'Nhân Viên',
    @sdt_nv = N'0912345789',
    @vitri = N'Nhân viên kho',
    @matkhau = '123456789',
    @Message = @Message OUTPUT;   -- Truyền biến @Message làm tham số OUTPUT

-- In ra thông báo kết quả
PRINT @Message;

-- Giải mã thông tin nhân viên
exec GiaiMaNhanVien;

delete NhanVien
where MaNV = 'NV_001002'
-------SuaNV-----------
go
CREATE OR ALTER PROCEDURE SuaNV
(
    @manv NVARCHAR(10), -- Mã nhà phân phối cần sửa (không thay đổi)
    @tennv NVARCHAR(50),
    @sdt_nv NCHAR(10),
    @vitri NVARCHAR(100),
	@matkhau nchar(9),
    @Message NVARCHAR(200) OUTPUT -- Thêm tham số OUTPUT để trả về thông báo
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra dữ liệu đầu vào
    IF @tennv IS NULL OR @tennv = ' ' OR
       @sdt_nv IS NULL OR @sdt_nv = ' ' OR
       @matkhau IS NULL OR @matkhau = ' ' OR
       LEN(@sdt_nv) <> 10
    BEGIN
        SET @Message = N'Dữ liệu nhập vào không hợp lệ.';
        RETURN;
    END

    -- Mở khóa đối xứng để giải mã
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    -- Kiểm tra số điện thoại đã tồn tại trong bảng khác ngoài nhà phân phối đang sửa
    IF EXISTS (SELECT 1 FROM nhanvien WHERE CONVERT(NCHAR(10), DecryptByKey(SDT_MH)) = @sdt_nv AND MaNV != @manv)
    BEGIN
        SET @Message = N'Đã tồn tại nhân viên với số điện thoại này.';
        CLOSE SYMMETRIC KEY SymKey_test;
        RETURN;
    END

    -- Mã hóa số điện thoại mới
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;
    DECLARE @sdt_mh VARBINARY(MAX);
    SET @sdt_mh = EncryptByKey(Key_GUID('SymKey_test'), @sdt_nv);
	declare @matkhau_mh varbinary(max)
	SET @matkhau_mh = EncryptByKey(Key_GUID('SymKey_test'), RTRIM(@matkhau));
    CLOSE SYMMETRIC KEY SymKey_test;

    -- Cập nhật thông tin nhà phân phối
    UPDATE NhanVien
    SET TenNV = @tennv, Vitri = @vitri, SDT_MH = @sdt_mh, MatKhau_MH = @matkhau_mh
    WHERE MaNV = @manv;

    -- Thông báo thành công
    SET @Message = N'Thông tin nhà phân phối đã được cập nhật thành công.';
END;


DECLARE @Message NVARCHAR(200);  -- Khai báo biến @Message

-- Gọi thủ tục và truyền tham số
EXEC SuaNV
	@manv = 'NV_000001',
    @tennv = N'Trần Văn A',
	@vitri = N'Quản lý',
    @sdt_nv = N'0912345688',
    @matkhau = 'QL3456789',
    @Message = @Message OUTPUT;   -- Truyền biến @Message làm tham số OUTPUT

-- In ra thông báo kết quả
PRINT @Message;

exec GiaiMaNhanVien
select * from NhanVien
