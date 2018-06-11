CREATE PROC ShowNhanVien
AS
BEGIN
SELECT *FROM dbo.NhanVien
END
CREATE PROC InsertNhanVien
(@MaNV CHAR(10),
@TenNV NVARCHAR(50),
@NgaySinh DATETIME,
@GT NVARCHAR(50),
@DiaChi NVARCHAR(50),
@SDT VARCHAR(20),
@Email NVARCHAR(50)
)
AS
BEGIN
INSERT INTO dbo.NhanVien
(
    MaNV,
    TenNV,
    NgaySinh,
    GT,
    Diachi,
    SDT,
    Email
)
VALUES
(   @MaNV,@TenNV,@NgaySinh,@GT,@Diachi,@SDT,@Email)
END
GO
CREATE PROC UpdateNhanVien
(@MaNV CHAR(10),
@TenNV NVARCHAR(50),
@NgaySinh DATETIME,
@GT NVARCHAR(50),
@DiaChi NVARCHAR(50),
@SDT VARCHAR(20),
@Email NVARCHAR(50))
as
BEGIN
UPDATE dbo.NhanVien
SET  
    TenNV= @TenNV,
    NgaySinh= @NgaySinh,
    GT= @GT,
    Diachi= @DiaChi,
    SDT= @SDT,
    Email= @Email
	WHERE MaNV=@MaNV
END
CREATE PROC DeleteNhanVien(@MaNV CHAR(10))
AS
BEGIN
DELETE dbo.NhanVien
WHERE MaNV=@MaNV
end
    

  


