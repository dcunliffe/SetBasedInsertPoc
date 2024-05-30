create type dbo.AddressType as table
(
    [UPRN]                    NVARCHAR (MAX)   NULL,
    [UPSN]                    NVARCHAR (MAX)   NULL,
    [OrganisationName]        NVARCHAR (MAX)   NULL,
    [DepartmentName]          NVARCHAR (MAX)   NULL,
    [SubBuildingName]         NVARCHAR (MAX)   NULL,
    [BuildingName]            NVARCHAR (MAX)   NULL,
    [BuildingNumber]          NVARCHAR (MAX)   NULL,
    [DependentThoroughfare]   NVARCHAR (MAX)   NULL,
    [Thoroughfare]            NVARCHAR (MAX)   NULL,
    [DoubleDependentLocality] NVARCHAR (MAX)   NULL,
    [DependentLocality]       NVARCHAR (MAX)   NULL,
    [PostTown]                NVARCHAR (MAX)   NULL,
    [PostalAddress]           NVARCHAR (MAX)   NULL,
    [PostCode]                NVARCHAR (MAX)   NULL,
    [LibPostalData]           NVARCHAR (MAX)   NULL
);
GO
Create Procedure dbo.insertAddress
    @rows AddressType READONLY
as
begin
    insert into Addresses
    select * from @rows;
end
GO
CREATE TABLE [dbo].[Addresses] (
    [Id]                      int IDENTITY(1,1),
    [UPRN]                    NVARCHAR (MAX)   NULL,
    [UPSN]                    NVARCHAR (MAX)   NULL,
    [OrganisationName]        NVARCHAR (MAX)   NULL,
    [DepartmentName]          NVARCHAR (MAX)   NULL,
    [SubBuildingName]         NVARCHAR (MAX)   NULL,
    [BuildingName]            NVARCHAR (MAX)   NULL,
    [BuildingNumber]          NVARCHAR (MAX)   NULL,
    [DependentThoroughfare]   NVARCHAR (MAX)   NULL,
    [Thoroughfare]            NVARCHAR (MAX)   NULL,
    [DoubleDependentLocality] NVARCHAR (MAX)   NULL,
    [DependentLocality]       NVARCHAR (MAX)   NULL,
    [PostTown]                NVARCHAR (MAX)   NULL,
    [PostalAddress]           NVARCHAR (MAX)   NULL,
    [PostCode]                NVARCHAR (MAX)   NULL,
    [LibPostalData]           NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

truncate table Addresses;