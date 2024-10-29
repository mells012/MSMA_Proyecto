CREATE TABLE [dbo].[Cervezas] (
    [IDCerveza] INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]    NVARCHAR (MAX) NOT NULL,
    [Tamaño]    INT            NOT NULL,
	[Precio]    FLOAT (53)     DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    [AVC]       FLOAT (53)     NOT NULL,    
    CONSTRAINT [PK_Cervezas] PRIMARY KEY CLUSTERED ([IDCerveza] ASC)
);

