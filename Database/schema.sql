-- ================================================================
-- Sindh Bank — Application Tracking
-- Database setup script
-- Run this on the target SQL Server instance to recreate the
-- schema. After running, update the connection string in
-- appsettings.json to point at that server.
-- ================================================================

CREATE DATABASE SindhBankTracking;
GO

USE SindhBankTracking;
GO

CREATE TABLE Applications
(
    TrackingId  NVARCHAR(20)  NOT NULL PRIMARY KEY,
    Status      NVARCHAR(20)  NOT NULL
        CHECK (Status IN ('InProcess', 'Rejected', 'Approved'))
);
GO

INSERT INTO Applications (TrackingId, Status) VALUES
    ('SB-1001', 'InProcess'),
    ('SB-1002', 'Approved'),
    ('SB-1003', 'Rejected');
GO

CREATE PROCEDURE sp_GetApplicationStatus
    @TrackingId NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TrackingId, Status
    FROM Applications
    WHERE TrackingId = @TrackingId;
END
GO