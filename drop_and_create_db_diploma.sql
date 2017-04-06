use CredDogCIB
drop table dbo.Name, dbo.KredDog, dbo.Zaemwik, dbo.KredDocum, dbo.OsnSdelkVdch, dbo.ZalogPoruch, dbo.OsnovnSd, dbo.DopSogZalPor, dbo.GrpObject, dbo.ObjData, dbo.DocsZalPor;
GO

use CredDogCIB
drop procedure dbo.sp_Name, dbo.sp_KredDog, dbo.sp_Zaemwik, dbo.sp_KredDocum, dbo.sp_OsnSdelkVdch, dbo.sp_ZalogPoruch, dbo.sp_OsnovnSd, dbo.sp_DopSogZalPor, dbo.sp_GrpObject, dbo.sp_ObjData, dbo.sp_DocsZalPor;
GO

CREATE PROCEDURE [dbo].[sp_Name]
    @Наименование nvarchar(50),
    @Принят date,
    @idName int output
AS
    INSERT INTO Name (Наименование, Принят)
    VALUES (@Наименование, @Принят)
 
    SET @idName=SCOPE_IDENTITY()
GO


CREATE PROCEDURE [dbo].[sp_KredDog]
    @Договор nvarchar(50),
    @Принят date,
	@id int,
    @idKredDog int output
AS
    INSERT INTO KredDog (Договор, Принят, id)
    VALUES (@Договор, @Принят, @id)
 
    SET @idKredDog=SCOPE_IDENTITY()
GO


CREATE PROCEDURE [dbo].[sp_Zaemwik]
	@id int,
	@Паспорт nvarchar(max),
	@ЕГРЮЛ nvarchar(max),
	@Участники nvarchar(max),
	@Заявка nvarchar(max),
	@Анкета nvarchar(max)
AS
    INSERT INTO Zaemwik (id, Паспорт, ЕГРЮЛ, Участники, Заявка, Анкета)
    VALUES (@id, @Паспорт, @ЕГРЮЛ, @Участники, @Заявка, @Анкета)
GO


CREATE PROCEDURE [dbo].[sp_KredDocum]
	@id int,
	@Оф_переписка nvarchar(max),
	@Судебные_решения nvarchar(max)
AS
    INSERT INTO KredDocum(id, Оф_переписка, Судебные_решения)
    VALUES (@id, @Оф_переписка, @Судебные_решения)

GO


CREATE PROCEDURE [dbo].[sp_OsnSdelkVdch]
	@id int,
	@Кредитный_дог nvarchar(max),
	@Одобрение_сделки nvarchar(max),
	@ЕГРЮЛ_на_дату_подп nvarchar(max),
	@Список_участн_на_дату nvarchar(max)
AS
    INSERT INTO OsnSdelkVdch (id, Кредитный_дог, Одобрение_сделки, ЕГРЮЛ_на_дату_подп, Список_участн_на_дату)
    VALUES (@id, @Кредитный_дог, @Одобрение_сделки, @ЕГРЮЛ_на_дату_подп, @Список_участн_на_дату)

GO



CREATE PROCEDURE [dbo].[sp_ZalogPoruch]
    @Наименование nvarchar(50),
	@Тип_З_П nvarchar(50),
    @Паспорт_ИНН nvarchar(50),
    @idZalPor int output,
	@id int
AS
    INSERT INTO ZalogPoruch (Наименование, Тип_З_П, Паспорт_ИНН, id)
    VALUES (@Наименование, @Тип_З_П, @Паспорт_ИНН, @id)
 
    SET @idZalPor=SCOPE_IDENTITY()
GO



CREATE PROCEDURE [dbo].[sp_OsnovnSd]
	@id int,
	@Дог_поруч_залога nvarchar(max),
	@Одобрение_сделки nvarchar(max),
	@ЕГРЮЛ_на_дату_подп nvarchar(max),
	@Список_участн_на_дату nvarchar(max),
	@Согласие_на_обремен nvarchar(max)
AS
    INSERT INTO OsnovnSd (id, Дог_поруч_залога, Одобрение_сделки, ЕГРЮЛ_на_дату_подп, Список_участн_на_дату, Согласие_на_обремен)
    VALUES (@id, @Дог_поруч_залога, @Одобрение_сделки, @ЕГРЮЛ_на_дату_подп, @Список_участн_на_дату, @Согласие_на_обремен)
GO


CREATE PROCEDURE [dbo].[sp_DopSogZalPor]
	@id int,
	@Дог_поруч_залога nvarchar(max),
	@Одобрение_сделки nvarchar(max),
	@ЕГРЮЛ_на_дату_подп nvarchar(max),
	@Список_участн_на_дату nvarchar(max)
AS
    INSERT INTO DopSogZalPor (id, Дог_поруч_залога, Одобрение_сделки, ЕГРЮЛ_на_дату_подп, Список_участн_на_дату)
    VALUES (@id, @Дог_поруч_залога, @Одобрение_сделки, @ЕГРЮЛ_на_дату_подп, @Список_участн_на_дату)
GO


CREATE PROCEDURE [dbo].[sp_GrpObject]
	@Группы_объектов nvarchar(50),
    @idGrObj int output,
	@id int
AS
    INSERT INTO GrpObject (Группы_объектов, id)
    VALUES (@Группы_объектов, @id)
 
    SET @idGrObj=SCOPE_IDENTITY()
GO


CREATE PROCEDURE [dbo].[sp_ObjData]
	@id int,
	@Выписки_ЕГРП nvarchar(max),
	@Свид_права_собст nvarchar(max),
	@Договоры_куп_прод_обрем nvarchar(max),
	@Кадастровый_пасп nvarchar(max),
	@Фотографии nvarchar(max),
	@Согласие_на_обремен nvarchar(max)
AS
    INSERT INTO ObjData (id, Выписки_ЕГРП, Свид_права_собст, Договоры_куп_прод_обрем, Кадастровый_пасп, Фотографии, Согласие_на_обремен)
    VALUES (@id, @Выписки_ЕГРП, @Свид_права_собст, @Договоры_куп_прод_обрем, @Кадастровый_пасп, @Фотографии, @Согласие_на_обремен)
GO


CREATE PROCEDURE [dbo].[sp_DocsZalPor]
	@id int,
	@Паспорт nvarchar(max),
	@ЕГРЮЛ nvarchar(max),
	@Участники nvarchar(max),
	@Заявка nvarchar(max),
	@Анкета nvarchar(max)
AS
    INSERT INTO DocsZalPor (id, Паспорт, ЕГРЮЛ, Участники, Заявка, Анкета)
    VALUES (@id, @Паспорт, @ЕГРЮЛ, @Участники, @Заявка, @Анкета)
GO


use CredDogCIB
CREATE TABLE dbo.Name
(  
 Наименование nvarchar(50),
 Принят date,  
 idName int IDENTITY(1,1),   
);  

use CredDogCIB
CREATE TABLE dbo.KredDog
(  
 Договор nvarchar(50),
 Принят date,  
 idKredDog int IDENTITY(1,1),  
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.Zaemwik
(   
 Паспорт nvarchar(max),
 ЕГРЮЛ nvarchar(max),
 Участники  nvarchar(max),
 Заявка nvarchar(max),
 Анкета nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.KredDocum
(   
 Оф_переписка nvarchar(max),
 Судебные_решения nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.OsnSdelkVdch
(   
 Кредитный_дог nvarchar(max),
 Одобрение_сделки nvarchar(max),
 ЕГРЮЛ_на_дату_подп  nvarchar(max),
 Список_участн_на_дату nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.ZalogPoruch
(   
 Наименование nvarchar(50),
 Тип_З_П nvarchar(50),
 Паспорт_ИНН nvarchar(50),  
 idZalPor int IDENTITY(1,1), 
 id int,
);  

use CredDogCIB
CREATE TABLE dbo.OsnovnSd
(   
 Дог_поруч_залога nvarchar(max),
 Одобрение_сделки nvarchar(max),
 ЕГРЮЛ_на_дату_подп  nvarchar(max),
 Список_участн_на_дату nvarchar(max),
 Согласие_на_обремен nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.DopSogZalPor
(   
 Дог_поруч_залога nvarchar(max),
 Одобрение_сделки nvarchar(max),
 ЕГРЮЛ_на_дату_подп  nvarchar(max),
 Список_участн_на_дату nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.GrpObject
(   
 Группы_объектов nvarchar(50),
 idGrObj int IDENTITY(1,1),  
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.ObjData
(   
 Выписки_ЕГРП nvarchar(max),
 Свид_права_собст nvarchar(max),
 Договоры_куп_прод_обрем  nvarchar(max),
 Кадастровый_пасп nvarchar(max),
 Фотографии nvarchar(max),
 Согласие_на_обремен nvarchar(max),
 id int,
);  


use CredDogCIB
CREATE TABLE dbo.DocsZalPor
(   
 Паспорт nvarchar(max),
 ЕГРЮЛ nvarchar(max),
 Участники  nvarchar(max),
 Заявка nvarchar(max),
 Анкета nvarchar(max),
 id int,
);  