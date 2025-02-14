CREATE TABLE [dbo].[TypeProduct] (
    [typeProduct] NCHAR (10)    NOT NULL,
    [value]       NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([typeProduct] ASC)
);

CREATE TABLE [dbo].[TypeUser] (
    [type]  NCHAR (10)    NOT NULL,
    [value] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([type] ASC)
);

CREATE TABLE [dbo].[TYPESTATUS] (
    [typeStatus] NCHAR (10)    NOT NULL,
    [value]      NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([typeStatus] ASC)
);

CREATE TABLE [dbo].[Product] (
    [ProductId]   INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (MAX) NULL,
    [description] NVARCHAR (MAX) NULL,
    [price]       FLOAT (53)     NULL,
    [quanlity]    INT            NULL,
    [image]       NVARCHAR (MAX) NULL,
    [typeProduct] NCHAR (10)     NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_TypeProduct] FOREIGN KEY ([typeProduct]) REFERENCES [dbo].[TypeProduct] ([typeProduct])
);

CREATE TABLE [dbo].[NGUOIDUNG] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [email]       NVARCHAR (50)  NOT NULL,
    [password]    NVARCHAR (50)  NULL,
    [name]        NVARCHAR (MAX) NULL,
    [address]     NVARCHAR (MAX) NOT NULL,
    [phoneNumber] NVARCHAR (MAX) NULL,
    [typeUser]    NCHAR (10)     NULL,
    [DateOfBirth] DATE           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_NGUOIDUNG_TypeUser] FOREIGN KEY ([typeUser]) REFERENCES [dbo].[TypeUser] ([type])
);

CREATE TABLE [dbo].[DONHANG] (
    [userId]      INT        NOT NULL,
    [productId]   INT        NOT NULL,
    [typeStatus]  NCHAR (10) NOT NULL,
    [quanlityBuy] INT        NULL,
    [date]        DATETIME   NULL,
    CONSTRAINT [PK_DONHANG] PRIMARY KEY CLUSTERED ([userId] ASC, [productId] ASC, [typeStatus] ASC),
    CONSTRAINT [FK_DONHANG_ToTable] FOREIGN KEY ([productId]) REFERENCES [dbo].[Product] ([ProductId]),
    CONSTRAINT [FK_DONHANG_NGUOIDUNG] FOREIGN KEY ([userId]) REFERENCES [dbo].[NGUOIDUNG] ([Id]),
    CONSTRAINT [FK_DONHANG_TYPESTATUS] FOREIGN KEY ([typeStatus]) REFERENCES [dbo].[TYPESTATUS] ([typeStatus])
);