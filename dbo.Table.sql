CREATE TABLE [dbo].[Livres]
(
	[LId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LNom] NCHAR(150) NULL, 
    [LAuteur] INT NOT NULL, 
    [LCategorie] INT NOT NULL,
    [LQuantite] INT NOT NULL, 
    [LPrix] INT NOT NULL
)
