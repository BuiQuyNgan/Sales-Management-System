CREATE OR ALTER PROCEDURE InitEncryption
AS
BEGIN
    CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'QLcsdl@123'; 
	
	CREATE CERTIFICATE Certificate_test 
		WITH SUBJECT = 'Protect my data'

    CREATE SYMMETRIC KEY SymKey_test 
        WITH ALGORITHM = AES_128 
        ENCRYPTION BY CERTIFICATE Certificate_test
END
GO

-----MÃ HOÁ
CREATE OR ALTER PROCEDURE EncryptColumn 
    @TableName NVARCHAR(128),
    @SourceColumn NVARCHAR(128),
    @EncryptedColumn NVARCHAR(128) = 'SDT_MH' -- Cột mã hóa mặc định
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    -- Thêm cột mới để lưu dữ liệu mã hóa 
    SET @SQL = 'ALTER TABLE ' + @TableName + ' ADD ' + @EncryptedColumn + ' VARBINARY(MAX)';
    EXEC sp_executesql @SQL;

    -- Mở khóa đối xứng
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    -- Mã hóa dữ liệu
    SET @SQL = 'UPDATE ' + @TableName + ' SET ' + @EncryptedColumn + ' = EncryptByKey(Key_GUID(''SymKey_test''), CAST(' + @SourceColumn + ' AS NVARCHAR(MAX)))';
    EXEC sp_executesql @SQL;

    -- Đóng khóa đối xứng
    CLOSE SYMMETRIC KEY SymKey_test;

    SET @SQL = 'ALTER TABLE ' + @TableName + ' DROP COLUMN ' + @SourceColumn;
    EXEC sp_executesql @SQL;
END
GO

---- GIẢI MÃ
CREATE OR ALTER PROCEDURE DecryptColumn 
    @TableName NVARCHAR(128),
    @EncryptedColumn NVARCHAR(128) = 'SDT_MH', -- Cột mã hóa mặc định
    @DecryptedColumn NVARCHAR(128),
    @DecryptedDataType NVARCHAR(50)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    -- Thêm cột mới để lưu dữ liệu giải mã 
    SET @SQL = 'ALTER TABLE ' + @TableName + ' ADD ' + @DecryptedColumn + ' ' + @DecryptedDataType 
    EXEC sp_executesql @SQL;

    -- Mở khóa đối xứng
    OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Certificate_test;

    -- Giải mã dữ liệu
    SET @SQL = 'UPDATE ' + @TableName + 
               ' SET ' + @DecryptedColumn + 
               ' = CONVERT(' + @DecryptedDataType + 
               ', DecryptByKey(' + @EncryptedColumn + '))';
    EXEC sp_executesql @SQL;

    -- Đóng khóa đối xứng
    CLOSE SYMMETRIC KEY SymKey_test;

    -- Xóa cột mã hóa
    SET @SQL = 'ALTER TABLE ' + @TableName + ' DROP COLUMN ' + @EncryptedColumn;
    EXEC sp_executesql @SQL;
END
GO

-- Khởi tạo mã hóa
EXEC InitEncryption;

-- Mã hóa dữ liệu
EXEC EncryptColumn @TableName = 'KhachHang', @SourceColumn = 'SDT_KH';
EXEC EncryptColumn @TableName = 'NhaPhanPhoi', @SourceColumn = 'SDT_NPP';
EXEC EncryptColumn @TableName = 'NhanVien', @SourceColumn = 'SDT_NV';

-- Giải mã dữ liệu
EXEC DecryptColumn @TableName = 'KhachHang', @DecryptedColumn = 'SDT_KH', @DecryptedDataType = 'NCHAR(10)';
EXEC DecryptColumn @TableName = 'NhaPhanPhoi', @DecryptedColumn = 'SDT_NPP', @DecryptedDataType = 'NCHAR(10)';
EXEC DecryptColumn @TableName = 'NhanVien', @DecryptedColumn = 'SDT_NV', @DecryptedDataType = 'NCHAR(10)';

-- 
SELECT * FROM KHACHHANG;
SELECT * FROM NHAPHANPHOI;
SELECT * FROM NHANVIEN;
