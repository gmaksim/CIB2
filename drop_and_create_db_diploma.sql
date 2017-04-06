use CredDogCIB
drop table dbo.Name, dbo.KredDog, dbo.Zaemwik, dbo.KredDocum, dbo.OsnSdelkVdch, dbo.ZalogPoruch, dbo.OsnovnSd, dbo.DopSogZalPor, dbo.GrpObject, dbo.ObjData, dbo.DocsZalPor;
GO

use CredDogCIB
drop procedure dbo.sp_Name, dbo.sp_KredDog, dbo.sp_Zaemwik, dbo.sp_KredDocum, dbo.sp_OsnSdelkVdch, dbo.sp_ZalogPoruch, dbo.sp_OsnovnSd, dbo.sp_DopSogZalPor, dbo.sp_GrpObject, dbo.sp_ObjData, dbo.sp_DocsZalPor;
GO

CREATE PROCEDURE [dbo].[sp_Name]
    @������������ nvarchar(50),
    @������ date,
    @idName int output
AS
    INSERT INTO Name (������������, ������)
    VALUES (@������������, @������)
 
    SET @idName=SCOPE_IDENTITY()
GO


CREATE PROCEDURE [dbo].[sp_KredDog]
    @������� nvarchar(50),
    @������ date,
	@id int,
    @idKredDog int output
AS
    INSERT INTO KredDog (�������, ������, id)
    VALUES (@�������, @������, @id)
 
    SET @idKredDog=SCOPE_IDENTITY()
GO


CREATE PROCEDURE [dbo].[sp_Zaemwik]
	@id int,
	@������� nvarchar(max),
	@����� nvarchar(max),
	@��������� nvarchar(max),
	@������ nvarchar(max),
	@������ nvarchar(max)
AS
    INSERT INTO Zaemwik (id, �������, �����, ���������, ������, ������)
    VALUES (@id, @�������, @�����, @���������, @������, @������)
GO


CREATE PROCEDURE [dbo].[sp_KredDocum]
	@id int,
	@��_��������� nvarchar(max),
	@��������_������� nvarchar(max)
AS
    INSERT INTO KredDocum(id, ��_���������, ��������_�������)
    VALUES (@id, @��_���������, @��������_�������)

GO


CREATE PROCEDURE [dbo].[sp_OsnSdelkVdch]
	@id int,
	@���������_��� nvarchar(max),
	@���������_������ nvarchar(max),
	@�����_��_����_���� nvarchar(max),
	@������_������_��_���� nvarchar(max)
AS
    INSERT INTO OsnSdelkVdch (id, ���������_���, ���������_������, �����_��_����_����, ������_������_��_����)
    VALUES (@id, @���������_���, @���������_������, @�����_��_����_����, @������_������_��_����)

GO



CREATE PROCEDURE [dbo].[sp_ZalogPoruch]
    @������������ nvarchar(50),
	@���_�_� nvarchar(50),
    @�������_��� nvarchar(50),
    @idZalPor int output,
	@id int
AS
    INSERT INTO ZalogPoruch (������������, ���_�_�, �������_���, id)
    VALUES (@������������, @���_�_�, @�������_���, @id)
 
    SET @idZalPor=SCOPE_IDENTITY()
GO



CREATE PROCEDURE [dbo].[sp_OsnovnSd]
	@id int,
	@���_�����_������ nvarchar(max),
	@���������_������ nvarchar(max),
	@�����_��_����_���� nvarchar(max),
	@������_������_��_���� nvarchar(max),
	@��������_��_������� nvarchar(max)
AS
    INSERT INTO OsnovnSd (id, ���_�����_������, ���������_������, �����_��_����_����, ������_������_��_����, ��������_��_�������)
    VALUES (@id, @���_�����_������, @���������_������, @�����_��_����_����, @������_������_��_����, @��������_��_�������)
GO


CREATE PROCEDURE [dbo].[sp_DopSogZalPor]
	@id int,
	@���_�����_������ nvarchar(max),
	@���������_������ nvarchar(max),
	@�����_��_����_���� nvarchar(max),
	@������_������_��_���� nvarchar(max)
AS
    INSERT INTO DopSogZalPor (id, ���_�����_������, ���������_������, �����_��_����_����, ������_������_��_����)
    VALUES (@id, @���_�����_������, @���������_������, @�����_��_����_����, @������_������_��_����)
GO


CREATE PROCEDURE [dbo].[sp_GrpObject]
	@������_�������� nvarchar(50),
    @idGrObj int output,
	@id int
AS
    INSERT INTO GrpObject (������_��������, id)
    VALUES (@������_��������, @id)
 
    SET @idGrObj=SCOPE_IDENTITY()
GO


CREATE PROCEDURE [dbo].[sp_ObjData]
	@id int,
	@�������_���� nvarchar(max),
	@����_�����_����� nvarchar(max),
	@��������_���_����_����� nvarchar(max),
	@�����������_���� nvarchar(max),
	@���������� nvarchar(max),
	@��������_��_������� nvarchar(max)
AS
    INSERT INTO ObjData (id, �������_����, ����_�����_�����, ��������_���_����_�����, �����������_����, ����������, ��������_��_�������)
    VALUES (@id, @�������_����, @����_�����_�����, @��������_���_����_�����, @�����������_����, @����������, @��������_��_�������)
GO


CREATE PROCEDURE [dbo].[sp_DocsZalPor]
	@id int,
	@������� nvarchar(max),
	@����� nvarchar(max),
	@��������� nvarchar(max),
	@������ nvarchar(max),
	@������ nvarchar(max)
AS
    INSERT INTO DocsZalPor (id, �������, �����, ���������, ������, ������)
    VALUES (@id, @�������, @�����, @���������, @������, @������)
GO


use CredDogCIB
CREATE TABLE dbo.Name
(  
 ������������ nvarchar(50),
 ������ date,  
 idName int IDENTITY(1,1),   
);  

use CredDogCIB
CREATE TABLE dbo.KredDog
(  
 ������� nvarchar(50),
 ������ date,  
 idKredDog int IDENTITY(1,1),  
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.Zaemwik
(   
 ������� nvarchar(max),
 ����� nvarchar(max),
 ���������  nvarchar(max),
 ������ nvarchar(max),
 ������ nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.KredDocum
(   
 ��_��������� nvarchar(max),
 ��������_������� nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.OsnSdelkVdch
(   
 ���������_��� nvarchar(max),
 ���������_������ nvarchar(max),
 �����_��_����_����  nvarchar(max),
 ������_������_��_���� nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.ZalogPoruch
(   
 ������������ nvarchar(50),
 ���_�_� nvarchar(50),
 �������_��� nvarchar(50),  
 idZalPor int IDENTITY(1,1), 
 id int,
);  

use CredDogCIB
CREATE TABLE dbo.OsnovnSd
(   
 ���_�����_������ nvarchar(max),
 ���������_������ nvarchar(max),
 �����_��_����_����  nvarchar(max),
 ������_������_��_���� nvarchar(max),
 ��������_��_������� nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.DopSogZalPor
(   
 ���_�����_������ nvarchar(max),
 ���������_������ nvarchar(max),
 �����_��_����_����  nvarchar(max),
 ������_������_��_���� nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.GrpObject
(   
 ������_�������� nvarchar(50),
 idGrObj int IDENTITY(1,1),  
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.ObjData
(   
 �������_���� nvarchar(max),
 ����_�����_����� nvarchar(max),
 ��������_���_����_�����  nvarchar(max),
 �����������_���� nvarchar(max),
 ���������� nvarchar(max),
 ��������_��_������� nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.DocsZalPor
(   
 ������� nvarchar(max),
 ����� nvarchar(max),
 ���������  nvarchar(max),
 ������ nvarchar(max),
 ������ nvarchar(max),
 id int,
);  