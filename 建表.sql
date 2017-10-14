CREATE TABLE [dbo].[Cars] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (200) NOT NULL,
    [CarBrandId] INT            NOT NULL,
    [Deleted]    BIT            NULL,
    [UpdatedAt]  DATETIME       NULL,
    CONSTRAINT [PK__Cars__3214EC076E9BAA63] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 1)
);

 
CREATE TABLE [dbo].[CarBrands] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);