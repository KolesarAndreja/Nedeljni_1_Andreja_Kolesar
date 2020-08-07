IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'dbFirm')
CREATE DATABASE dbFirm;
GO
USE dbFirm
--dropping tables
IF OBJECT_ID('vwEmployee') IS NOT NULL
DROP VIEW vwEmployee;

IF OBJECT_ID('vwManager') IS NOT NULL
DROP VIEW vwManager;

IF OBJECT_ID('vwAdministrator') IS NOT NULL
DROP VIEW vwAdministrator;

IF OBJECT_ID('tblAdministrator') IS NOT NULL 
DROP TABLE tblAdministrator;

IF OBJECT_ID('tblEditRequest') IS NOT NULL 
DROP TABLE tblEditRequest;

IF OBJECT_ID('tblDailyReport') IS NOT NULL 
DROP TABLE tblDailyReport;

IF OBJECT_ID('tblProject') IS NOT NULL 
DROP TABLE tblProject;

IF OBJECT_ID('tblEmployee') IS NOT NULL 
DROP TABLE tblEmployee;

IF OBJECT_ID('tblManager') IS NOT NULL 
DROP TABLE tblManager;

IF OBJECT_ID('tblUser') IS NOT NULL 
DROP TABLE tblUser;

IF OBJECT_ID('tblGender') IS NOT NULL 
DROP TABLE tblGender;

IF OBJECT_ID('tblMarriageStatus') IS NOT NULL 
DROP TABLE tblMarriageStatus;

IF OBJECT_ID('tblSector') IS NOT NULL 
DROP TABLE tblSector;

IF OBJECT_ID('tblPosition') IS NOT NULL 
DROP TABLE tblPosition;

IF OBJECT_ID('tblProfessionalQualification') IS NOT NULL 
DROP TABLE tblProfessionalQualification;

IF OBJECT_ID('tblAdminType') IS NOT NULL 
DROP TABLE tblAdminType;


CREATE TABLE tblGender (
	genderId INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR (20),
	symbol CHAR(1) UNIQUE NOT NULL,
);

CREATE TABLE tblMarriageStatus(
	marriageStatusId INT IDENTITY(1,1) PRIMARY KEY,
	status VARCHAR(15) not null
);

CREATE TABLE tblUser(
	userId INT IDENTITY(1,1) PRIMARY KEY,
	firstname VARCHAR (20) NOT NULL,
	lastname VARCHAR (20) NOT NULL,
	jmbg VARCHAR (13) UNIQUE NOT NULl,
	genderId INT FOREIGN KEY REFERENCES tblGender(genderId) ON DELETE SET NULL,
	residence VARCHAR (50) NOT NULL,
	marriageStatusId INT FOREIGN KEY REFERENCES tblMarriageStatus(marriageStatusId) ON DELETE SET NULL,
	username VARCHAR (25) UNIQUE NOT NULL,
	password VARCHAR (25) NOT NULL,
);

CREATE TABLE tblSector (
	sectorId INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR (20) UNIQUE NOT NULL,
	description VARCHAR (40)
);

CREATE TABLE tblPosition (
	positionId INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR (40) UNIQUE NOT NULL,
	description VARCHAR (40)
);

CREATE TABLE tblProfessionalQualification (
	qualificationsId INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR (40),
	symbol VARCHAR (3) not null
);
 
CREATE TABLE tblManager (
	managerId INT IDENTITY(1,1) PRIMARY KEY,
	email VARCHAR (40) NOT NULL,
	backupPassword VARCHAR (40)	NOT NULL,
	levelOfResponsibility CHAR,
	successfulProjects INT DEFAULT 0,
	salary NUMERIC,
	officeNumber INT,
	userId INT FOREIGN KEY REFERENCES tblUser(userId) NOT NULL,
);

CREATE TABLE tblEmployee (
	employeeId INT IDENTITY(1,1) PRIMARY KEY,
	userID INT FOREIGN KEY REFERENCES tblUser(userId) NOT NULL,
	sectorId INT FOREIGN KEY REFERENCES tblSector(sectorId) NOT NULL,
	positionID INT FOREIGN KEY REFERENCES tblPosition(positionId),
	yearsOfService INT NOT NULL,
	Salary NUMERIC,
	qualificationsId INT FOREIGN KEY REFERENCES tblProfessionalQualification(qualificationsId) NOT NULL,	
	managerId INT FOREIGN KEY REFERENCES tblManager(managerId),
);

CREATE TABLE tblEditRequest(
	requestId INT IDENTITY(1,1) PRIMARY KEY,
	employeeId INT FOREIGN KEY REFERENCES tblEmployee(employeeId),
	field VARCHAR(20) not null,
	previousValue INT not null,
	newValue INT not null,
	status VARCHAR(20) not null,
	requestDate DATETIME not null
);


CREATE TABLE tblAdminType(
	adminTypeId INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(30) not null
);

CREATE TABLE tblAdministrator(
	administratorId INT IDENTITY(1,1) PRIMARY KEY,
	expiryDate DATE	NOT NULL,
	adminTypeId INT FOREIGN KEY REFERENCES tblAdminType(adminTypeId) NOT NULL,
	userId INT FOREIGN KEY REFERENCES tblUser(userId) NOT NULL,
);

CREATE TABLE tblProject(
	projectId INT IDENTITY(1,1) PRIMARY KEY,
	projectName VARCHAR (25) NOT NULL,
	description VARCHAR (40),
	clientName VARCHAR (40)	NOT NULL,
	contractDate DATE NOT NULL,
	contractManagerId INT FOREIGN KEY REFERENCES tblManager(managerId) NOT NULL,
	startingDate DATE NOT NULL,
	deadline DATE NOT NULL,
	hourlyRate NUMERIC NOT NULL,
	realisation CHAR NOT NULL,
	leaderId INT FOREIGN KEY REFERENCES tblManager(managerId) NOT NULL,
	employee1 INT FOREIGN KEY REFERENCES tblEmployee(employeeId),
	employee2 INT FOREIGN KEY REFERENCES tblEmployee(employeeId),
	employee3 INT FOREIGN KEY REFERENCES tblEmployee(employeeId),
	employee4 INT FOREIGN KEY REFERENCES tblEmployee(employeeId),
	employee5 INT FOREIGN KEY REFERENCES tblEmployee(employeeId)
);

ALTER TABLE tblProject 
  ADD CONSTRAINT uqProject UNIQUE(projectName, clientName);

CREATE TABLE tblDailyReport(
	reportId INT PRIMARY KEY IDENTITY(1,1),
	reportDate  DATE not null,
	description VARCHAR(250) not null,
	workingHours int not null,
	employeeId INT FOREIGN KEY REFERENCES tblEmployee(employeeId) ON DELETE SET NULL,
	projectId INT FOREIGN KEY REFERENCES tblProject(projectId) ON DELETE SET NULL
);  


GO
CREATE VIEW vwEmployee
as
select u.*, e.employeeId, e.managerId, e.positionID, e.qualificationsId, e.Salary, e.sectorId, e.yearsOfService ,m.status, g.symbol as gender, s.name AS sectorName, p.name as positionName, q.symbol as qualification
from tblEmployee e
inner join tblUser u
on u.userId = e.userId
inner join tblMarriageStatus m
on m.marriageStatusId= u.marriageStatusId
inner join tblGender g
on u.genderId= g.genderId
inner join tblSector s
on s.sectorId = e.sectorId
inner join tblPosition p
on p.positionId = e.positionID
inner join tblProfessionalQualification q
on e.qualificationsId = q.qualificationsId

GO
CREATE VIEW vwManager
as
select u.*,m.backupPassword, m.email, m.levelOfResponsibility, m.managerId, m.officeNumber, m.salary, m.successfulProjects ,me.status, g.symbol as gender
from tblManager m
inner join tblUser u
on u.userId = m.userId
inner join tblMarriageStatus me
on me.marriageStatusId= u.marriageStatusId
inner join tblGender g
on u.genderId= g.genderId


GO
CREATE VIEW vwAdministrator
as
select u.*, a.administratorId, a.adminTypeId,a.expiryDate,me.status, g.symbol as gender, t.name as typeName
from tblAdministrator a
inner join tblUser u
on u.userId = a.userId
inner join tblMarriageStatus me
on me.marriageStatusId= u.marriageStatusId
inner join tblGender g
on u.genderId= g.genderId
inner join tblAdminType t
on t.adminTypeId= a.adminTypeId




GO
INSERT INTO tblGender(symbol)
VALUES ('M'), ('F'),('N'),('X');

INSERT INTO tblAdminType(name)
VALUES('Local'),('Team'),('System');

INSERT INTO tblProfessionalQualification(symbol)
VALUES('I'),('II'),('III'),('IV'),('V'),('VI'),('VII');

INSERT INTO tblMarriageStatus(status)
VALUES('single'),('married'),('divorced');

