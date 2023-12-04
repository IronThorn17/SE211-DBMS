CREATE TABLE [dbo].[Employees]
(
	[EmployeeID] INT NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [DateOfBirth] DATE NULL, 
    [SSN] VARCHAR(11) NULL, 
    [Address] VARCHAR(100) NULL, 
    [PhoneNumber] VARCHAR(20) NULL
)
