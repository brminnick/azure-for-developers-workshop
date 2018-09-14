USE Hotels;
GO

CREATE TABLE Hotels(
  [Name] nvarchar(max),
  City nvarchar(max),
  Country nvarchar(max),
  [Description] nvarchar(max),
  [Address] nvarchar(max),
  Rating INT,
  StarterPricePerNight INT,
  Visits INT,
  [Year] nvarchar(max)
);
GO