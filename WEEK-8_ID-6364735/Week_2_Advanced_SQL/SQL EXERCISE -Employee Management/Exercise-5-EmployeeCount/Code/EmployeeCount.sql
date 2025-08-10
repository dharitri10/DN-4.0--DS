-- Use the same database
USE [EmployeeManagementSystem];
GO

-- Drop existing procedure if any
DROP PROCEDURE IF EXISTS sp_GetEmployeeCountByDepartment;
GO

-- Create stored procedure with OUTPUT parameter
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT,
    @EmployeeCount INT OUTPUT
AS
BEGIN
    SELECT @EmployeeCount = COUNT(*)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- Test with DepartmentID = 1 (HR)
DECLARE @CountHR INT;
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 1, @EmployeeCount = @CountHR OUTPUT;
SELECT @CountHR AS HR_EmployeeCount;
GO

-- Test with DepartmentID = 2 (Finance)
DECLARE @CountFinance INT;
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 2, @EmployeeCount = @CountFinance OUTPUT;
SELECT @CountFinance AS Finance_EmployeeCount;
GO

-- Test with DepartmentID = 3 (IT)
DECLARE @CountIT INT;
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 3, @EmployeeCount = @CountIT OUTPUT;
SELECT @CountIT AS IT_EmployeeCount;
GO

-- Test with DepartmentID = 4 (Marketing)
DECLARE @CountMarketing INT;
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 4, @EmployeeCount = @CountMarketing OUTPUT;
SELECT @CountMarketing AS Marketing_EmployeeCount;
GO

-- Optional: Display all employees with department names
SELECT 
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName,
    e.Salary,
    e.JoinDate
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
ORDER BY d.DepartmentName, e.EmployeeID;
GO
