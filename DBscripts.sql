use master
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'VMindTestWebApiApp')
	drop database VMindTestWebApiApp

create database VMindTestWebApiApp
go


use VMindTestWebApiApp
if not exists (select * from sysobjects where name='Usuarios' and xtype='U')
	DROP TABLE [dbo].[Usuarios]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 19/01/2019 21:34:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[id] [varchar](50) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


if (not(exists(select * from [User] where id = 'fvtest')))
	insert into [User] (id, Nombre, Apellido, Email, [Password]) values ('fvTest', 'Federico', 'Vessuri', 'fvtest@gmail.com', 'fvt35t')
