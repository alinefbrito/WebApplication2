USE [db_Biblioteca]
GO
/****** Object:  Table [dbo].[tbl_autores]    Script Date: 07/06/2023 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_autores](
	[ID_Autor] [smallint] IDENTITY(1,1) NOT NULL,
	[Nome_Autor] [varchar](50) NULL,
	[Sobrenome_Autor] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_editoras]    Script Date: 07/06/2023 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_editoras](
	[ID_Editora] [smallint] IDENTITY(1,1) NOT NULL,
	[Nome_Editora] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Editora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_livros]    Script Date: 07/06/2023 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_livros](
	[ID_Livro] [smallint] IDENTITY(100,1) NOT NULL,
	[Nome_Livro] [varchar](50) NOT NULL,
	[ISBN] [varchar](30) NOT NULL,
	[ID_Autor] [smallint] NOT NULL,
	[Data_Pub] [date] NOT NULL,
	[Preco_Livro] [money] NOT NULL,
	[ID_Editora] [smallint] NOT NULL,
 CONSTRAINT [pk_id_livro] PRIMARY KEY CLUSTERED 
(
	[ID_Livro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_autores] ON 
GO
INSERT [dbo].[tbl_autores] ([ID_Autor], [Nome_Autor], [Sobrenome_Autor]) VALUES (1, N'Daniel', N'Barret')
GO
INSERT [dbo].[tbl_autores] ([ID_Autor], [Nome_Autor], [Sobrenome_Autor]) VALUES (2, N'Gerald', N'Carter')
GO
INSERT [dbo].[tbl_autores] ([ID_Autor], [Nome_Autor], [Sobrenome_Autor]) VALUES (3, N'Mark', N'Sobell')
GO
INSERT [dbo].[tbl_autores] ([ID_Autor], [Nome_Autor], [Sobrenome_Autor]) VALUES (4, N'William', N'Stanek')
GO
INSERT [dbo].[tbl_autores] ([ID_Autor], [Nome_Autor], [Sobrenome_Autor]) VALUES (5, N'Richard', N'Blum')
GO
SET IDENTITY_INSERT [dbo].[tbl_autores] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_editoras] ON 
GO
INSERT [dbo].[tbl_editoras] ([ID_Editora], [Nome_Editora]) VALUES (1, N'Prentice Hall')
GO
INSERT [dbo].[tbl_editoras] ([ID_Editora], [Nome_Editora]) VALUES (2, N'O´Reilly')
GO
INSERT [dbo].[tbl_editoras] ([ID_Editora], [Nome_Editora]) VALUES (3, N'Microsoft Press')
GO
INSERT [dbo].[tbl_editoras] ([ID_Editora], [Nome_Editora]) VALUES (4, N'Wiley')
GO
SET IDENTITY_INSERT [dbo].[tbl_editoras] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_livros] ON 
GO
INSERT [dbo].[tbl_livros] ([ID_Livro], [Nome_Livro], [ISBN], [ID_Autor], [Data_Pub], [Preco_Livro], [ID_Editora]) VALUES (100, N'Linux Command Line and Shell Scripting', N'143856969', 5, CAST(N'2009-12-21' AS Date), 68.3500, 4)
GO
INSERT [dbo].[tbl_livros] ([ID_Livro], [Nome_Livro], [ISBN], [ID_Autor], [Data_Pub], [Preco_Livro], [ID_Editora]) VALUES (101, N'SSH, the Secure Shell', N'127658789', 1, CAST(N'2009-12-21' AS Date), 58.3000, 2)
GO
INSERT [dbo].[tbl_livros] ([ID_Livro], [Nome_Livro], [ISBN], [ID_Autor], [Data_Pub], [Preco_Livro], [ID_Editora]) VALUES (102, N'Using Samba', N'123856789', 2, CAST(N'2000-12-21' AS Date), 61.4500, 2)
GO
INSERT [dbo].[tbl_livros] ([ID_Livro], [Nome_Livro], [ISBN], [ID_Autor], [Data_Pub], [Preco_Livro], [ID_Editora]) VALUES (103, N'Fedora and Red Hat Linux', N'123346789', 3, CAST(N'2010-11-01' AS Date), 62.2400, 1)
GO
INSERT [dbo].[tbl_livros] ([ID_Livro], [Nome_Livro], [ISBN], [ID_Autor], [Data_Pub], [Preco_Livro], [ID_Editora]) VALUES (104, N'Windows Server 2012 Inside Out', N'123356789', 4, CAST(N'2004-05-17' AS Date), 66.8000, 3)
GO
INSERT [dbo].[tbl_livros] ([ID_Livro], [Nome_Livro], [ISBN], [ID_Autor], [Data_Pub], [Preco_Livro], [ID_Editora]) VALUES (105, N'Microsoft Exchange Server 2010', N'123366789', 4, CAST(N'2000-12-21' AS Date), 45.3000, 3)
GO
SET IDENTITY_INSERT [dbo].[tbl_livros] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbl_livr__447D36EA3E234585]    Script Date: 07/06/2023 22:25:51 ******/
ALTER TABLE [dbo].[tbl_livros] ADD UNIQUE NONCLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_livros]  WITH CHECK ADD  CONSTRAINT [fk_ID_Autor] FOREIGN KEY([ID_Autor])
REFERENCES [dbo].[tbl_autores] ([ID_Autor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_livros] CHECK CONSTRAINT [fk_ID_Autor]
GO
ALTER TABLE [dbo].[tbl_livros]  WITH CHECK ADD  CONSTRAINT [fk_ID_Editora] FOREIGN KEY([ID_Editora])
REFERENCES [dbo].[tbl_editoras] ([ID_Editora])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_livros] CHECK CONSTRAINT [fk_ID_Editora]
GO
