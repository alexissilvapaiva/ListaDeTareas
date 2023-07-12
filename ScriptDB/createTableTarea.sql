
USE [DB_Tasks]
GO

/******  Table [dbo].[Tarea]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tarea](
	[IdTarea] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tarea] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO

/* 
   ------Insert------
insert into Tarea(Descripcion) values ('Primeros pasos en React JS mas C#')

-----Query-----
select IdTarea, Descripcion, FechaRegistro from Tarea
*/