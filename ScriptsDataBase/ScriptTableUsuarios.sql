USE [VendaLivrosBase]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 25/09/2024 12:51:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Sobrenome] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[SenhaHash] [varbinary](max) NOT NULL,
	[SenhaSalt] [varbinary](max) NOT NULL,
	[DataAtualizãcao] [datetime2](7) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Perfil] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DataCadastro]
GO

ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (N'') FOR [Login]
GO

ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [Perfil]
GO

