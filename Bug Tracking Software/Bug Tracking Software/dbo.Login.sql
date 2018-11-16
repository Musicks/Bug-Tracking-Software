CREATE TABLE [dbo].[Login] (
    [Username] VARCHAR (50)  NOT NULL,
    [Password] NVARCHAR (50) NULL,
    [CPassword]     NVARCHAR (50) NULL,
    [Role] NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Username] ASC)
);

