USE [master]
GO
CREATE DATABASE [SUP]
GO
ALTER DATABASE [SUP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SUP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SUP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SUP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SUP] SET ARITHABORT OFF 
GO
ALTER DATABASE [SUP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SUP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SUP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SUP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SUP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SUP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SUP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SUP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SUP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SUP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SUP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SUP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SUP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SUP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SUP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SUP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SUP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SUP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SUP] SET  MULTI_USER 
GO
ALTER DATABASE [SUP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SUP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SUP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SUP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SUP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SUP] SET QUERY_STORE = OFF
GO
USE [SUP]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 01.06.2022 14:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[SecondName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[Type] [uniqueidentifier] NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTypes]    Script Date: 01.06.2022 14:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Salary] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 01.06.2022 14:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectWorks]    Script Date: 01.06.2022 14:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectWorks](
	[Id] [uniqueidentifier] NOT NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NULL,
 CONSTRAINT [PK_ProjectWorks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 01.06.2022 14:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [uniqueidentifier] NOT NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
	[PerformerId] [uniqueidentifier] NULL,
	[TesterId] [uniqueidentifier] NULL,
	[State] [uniqueidentifier] NOT NULL,
	[IsRemoved] [bit] NOT NULL,
	[NumberTask] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskStates]    Script Date: 01.06.2022 14:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStates](
	[Id] [uniqueidentifier] NOT NULL,
	[State] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TaskStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacations]    Script Date: 01.06.2022 14:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacations](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[Comment] [varchar](max) NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Vacations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [SecondName], [LastName], [Type], [IsRemoved]) VALUES (N'e2e2b4e7-d78d-44e9-bbb2-0577100b912d', N'Иван', N'Иванович', N'Петров', N'a4b918f7-b741-430b-92cc-60cdd6c6b4e2', 0)
INSERT [dbo].[Employees] ([Id], [FirstName], [SecondName], [LastName], [Type], [IsRemoved]) VALUES (N'f44d0a5f-83c4-4ccd-8677-11609227b96f', N'Дмитрий', N'Алексеевич', N'Сидоров', N'd3284acd-b013-4749-9dab-76a894dd63c5', 0)
INSERT [dbo].[Employees] ([Id], [FirstName], [SecondName], [LastName], [Type], [IsRemoved]) VALUES (N'0a315c27-4388-4a3a-b20d-224dc0558eb9', N'Александр', N'Александрович', N'Иванов', N'5a90c726-288f-4671-a2c8-a0d626b88688', 0)
INSERT [dbo].[Employees] ([Id], [FirstName], [SecondName], [LastName], [Type], [IsRemoved]) VALUES (N'f1c7fb1c-bea9-4594-b16b-47f3274ee646', N'Иванов', N'Сергеевич', N'Виталий', N'a4b918f7-b741-430b-92cc-60cdd6c6b4e2', 0)
INSERT [dbo].[Employees] ([Id], [FirstName], [SecondName], [LastName], [Type], [IsRemoved]) VALUES (N'5396563d-5fb9-43b5-b50f-9dd372a93b70', N'Андрей', N'Андреевич', N'Пронин', N'a4b918f7-b741-430b-92cc-60cdd6c6b4e2', 0)
INSERT [dbo].[Employees] ([Id], [FirstName], [SecondName], [LastName], [Type], [IsRemoved]) VALUES (N'60980640-5fd7-47d1-9c33-c7fce412332a', N'Антон', N'Михайлович', N'Власов', N'd3284acd-b013-4749-9dab-76a894dd63c5', 0)
GO
INSERT [dbo].[EmployeeTypes] ([Id], [Title], [Salary]) VALUES (N'a4b918f7-b741-430b-92cc-60cdd6c6b4e2', N'Senior Full-Stack', 100000)
INSERT [dbo].[EmployeeTypes] ([Id], [Title], [Salary]) VALUES (N'd3284acd-b013-4749-9dab-76a894dd63c5', N'Junior Full-Stack', 50000)
INSERT [dbo].[EmployeeTypes] ([Id], [Title], [Salary]) VALUES (N'5a90c726-288f-4671-a2c8-a0d626b88688', N'Middle Full-Stack', 70000)
GO
INSERT [dbo].[Projects] ([Id], [Name], [Description], [IsRemoved]) VALUES (N'fcba3e98-4d6e-4320-b2f7-297390c4dfa6', N'ТЭП70БС', N'Программа дисплейного модуля', 0)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [IsRemoved]) VALUES (N'653df8b8-c0b3-4279-adb4-3671b268b16e', N'2ТЭ116У', N'С RAM-диском', 1)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [IsRemoved]) VALUES (N'6fef34f2-8415-480f-a452-636f9c01493f', N'Электровоз', N'С архивом тревожных сообщений', 0)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [IsRemoved]) VALUES (N'49999f6f-abb1-4265-bed4-6c99b8f9d03e', N'2ТЭ70', N'С автоведением', 0)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [IsRemoved]) VALUES (N'693368aa-7555-4514-9bc9-c2cb27cc999a', N'ТЭП70У', N'C "расковыченным" сигналом пустого бака', 0)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [IsRemoved]) VALUES (N'12da80b1-23a5-4cd9-9ae6-e0eae85e86bc', N'2ТЭ116У', N'Функция ночного режима и архивом тревожных сообщений', 1)
GO
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'644c15c8-87d2-4b4b-bb3f-0c6eb943f181', N'fcba3e98-4d6e-4320-b2f7-297390c4dfa6', N'f44d0a5f-83c4-4ccd-8677-11609227b96f', CAST(N'2022-05-13T12:25:11.030' AS DateTime), NULL)
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'c72c86dc-62c2-4bb1-8fd1-1c329329af6c', N'693368aa-7555-4514-9bc9-c2cb27cc999a', N'f44d0a5f-83c4-4ccd-8677-11609227b96f', CAST(N'2022-05-27T18:42:51.957' AS DateTime), NULL)
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'5b2a42e5-59ad-4b1d-9ebf-28fce41333e4', N'49999f6f-abb1-4265-bed4-6c99b8f9d03e', N'f44d0a5f-83c4-4ccd-8677-11609227b96f', CAST(N'2022-05-19T17:08:18.860' AS DateTime), NULL)
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'0026a365-8cce-46a5-b039-4c4b864decfe', N'693368aa-7555-4514-9bc9-c2cb27cc999a', N'5396563d-5fb9-43b5-b50f-9dd372a93b70', CAST(N'2022-05-27T18:33:48.770' AS DateTime), NULL)
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'769c06ef-8645-4fe7-881e-5716049032c9', N'6fef34f2-8415-480f-a452-636f9c01493f', N'5396563d-5fb9-43b5-b50f-9dd372a93b70', CAST(N'2022-06-01T14:00:10.270' AS DateTime), NULL)
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'e29d27a7-0ed0-4660-b5eb-66b9a886ad0b', N'693368aa-7555-4514-9bc9-c2cb27cc999a', N'60980640-5fd7-47d1-9c33-c7fce412332a', CAST(N'2022-05-18T19:20:46.023' AS DateTime), NULL)
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'd4b74ae7-be81-463c-b4cd-772a1f81c629', N'6fef34f2-8415-480f-a452-636f9c01493f', N'f1c7fb1c-bea9-4594-b16b-47f3274ee646', CAST(N'2022-06-01T13:59:55.657' AS DateTime), NULL)
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'a74a53ad-ec55-4b96-bf03-819bcd50ca43', N'fcba3e98-4d6e-4320-b2f7-297390c4dfa6', N'60980640-5fd7-47d1-9c33-c7fce412332a', CAST(N'2022-05-13T12:24:58.727' AS DateTime), NULL)
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'659b29a0-8f40-43f8-ac7e-93f015c5edec', N'49999f6f-abb1-4265-bed4-6c99b8f9d03e', N'0a315c27-4388-4a3a-b20d-224dc0558eb9', CAST(N'2022-05-10T17:51:15.303' AS DateTime), NULL)
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'da68aada-e985-4cb2-b0b4-966686522af3', N'fcba3e98-4d6e-4320-b2f7-297390c4dfa6', N'e2e2b4e7-d78d-44e9-bbb2-0577100b912d', CAST(N'2022-05-27T18:50:31.400' AS DateTime), CAST(N'2022-05-27T18:52:40.050' AS DateTime))
INSERT [dbo].[ProjectWorks] ([Id], [ProjectId], [EmployeeId], [DateStart], [DateEnd]) VALUES (N'4935b2ec-4cdd-4dba-b641-e7c11c12959d', N'12da80b1-23a5-4cd9-9ae6-e0eae85e86bc', N'e2e2b4e7-d78d-44e9-bbb2-0577100b912d', CAST(N'2022-05-10T17:51:21.890' AS DateTime), CAST(N'2022-05-21T12:37:11.863' AS DateTime))
GO
INSERT [dbo].[Tasks] ([Id], [ProjectId], [Title], [Description], [PerformerId], [TesterId], [State], [IsRemoved], [NumberTask]) VALUES (N'95c9d076-a7a1-45e8-80ea-07f0b8461497', N'fcba3e98-4d6e-4320-b2f7-297390c4dfa6', N'Настройка СПТ', N'Настроить систему подогрева тепловоза', N'f44d0a5f-83c4-4ccd-8677-11609227b96f', NULL, N'8d201511-f74a-448a-9b04-3177fb3156c7', 0, 3)
INSERT [dbo].[Tasks] ([Id], [ProjectId], [Title], [Description], [PerformerId], [TesterId], [State], [IsRemoved], [NumberTask]) VALUES (N'1d93c50e-9aa5-407e-b5ef-091216a2dba6', N'fcba3e98-4d6e-4320-b2f7-297390c4dfa6', N'Тестирование', N'Разработать функцию тестирования ПО', N'f44d0a5f-83c4-4ccd-8677-11609227b96f', N'60980640-5fd7-47d1-9c33-c7fce412332a', N'375afdb1-9cbc-428d-848d-75f52f066414', 0, 1)
INSERT [dbo].[Tasks] ([Id], [ProjectId], [Title], [Description], [PerformerId], [TesterId], [State], [IsRemoved], [NumberTask]) VALUES (N'888da602-c267-431c-a98b-2102c9dec488', N'49999f6f-abb1-4265-bed4-6c99b8f9d03e', N'Диагностика неисправностей системы подогрева', N'Разработать диагностику неисправностей системы подогрева', N'f44d0a5f-83c4-4ccd-8677-11609227b96f', N'0a315c27-4388-4a3a-b20d-224dc0558eb9', N'8d201511-f74a-448a-9b04-3177fb3156c7', 0, 2)
INSERT [dbo].[Tasks] ([Id], [ProjectId], [Title], [Description], [PerformerId], [TesterId], [State], [IsRemoved], [NumberTask]) VALUES (N'f79c06b4-0f07-44bd-bb5f-645eabaf88fe', N'693368aa-7555-4514-9bc9-c2cb27cc999a', N'Формирование отчетов о работе СПТ', N'Разработать функцию формирования отчетов о работе системы подогрева тепловоза', N'5396563d-5fb9-43b5-b50f-9dd372a93b70', N'f44d0a5f-83c4-4ccd-8677-11609227b96f', N'de054313-51a5-4215-8ba0-a10bac9f0ff0', 0, 2)
INSERT [dbo].[Tasks] ([Id], [ProjectId], [Title], [Description], [PerformerId], [TesterId], [State], [IsRemoved], [NumberTask]) VALUES (N'b5dc2aed-8b36-4dc8-b981-820964950649', N'12da80b1-23a5-4cd9-9ae6-e0eae85e86bc', N'Тест архива', N'архив', N'e2e2b4e7-d78d-44e9-bbb2-0577100b912d', NULL, N'8d201511-f74a-448a-9b04-3177fb3156c7', 1, 1)
INSERT [dbo].[Tasks] ([Id], [ProjectId], [Title], [Description], [PerformerId], [TesterId], [State], [IsRemoved], [NumberTask]) VALUES (N'8fce4397-60a4-45f7-ba09-831148df8cb8', N'6fef34f2-8415-480f-a452-636f9c01493f', N'Визуальная и речевая информация', N'Разработать функцию выдачи визуальной и речевой информации для локомотивной бригады', N'f1c7fb1c-bea9-4594-b16b-47f3274ee646', N'5396563d-5fb9-43b5-b50f-9dd372a93b70', N'8d201511-f74a-448a-9b04-3177fb3156c7', 0, 1)
INSERT [dbo].[Tasks] ([Id], [ProjectId], [Title], [Description], [PerformerId], [TesterId], [State], [IsRemoved], [NumberTask]) VALUES (N'ec1a845e-7b46-4339-a6a8-8a137829352f', N'fcba3e98-4d6e-4320-b2f7-297390c4dfa6', N'Автоведение', N'Разработать функцию автоведения', N'f44d0a5f-83c4-4ccd-8677-11609227b96f', N'60980640-5fd7-47d1-9c33-c7fce412332a', N'de054313-51a5-4215-8ba0-a10bac9f0ff0', 0, 2)
INSERT [dbo].[Tasks] ([Id], [ProjectId], [Title], [Description], [PerformerId], [TesterId], [State], [IsRemoved], [NumberTask]) VALUES (N'ed223dd1-29d5-4aaf-8679-98b745d03396', N'693368aa-7555-4514-9bc9-c2cb27cc999a', N'Просмотр архивных данных', N'Разработать функцию просмотра архивных данных', N'60980640-5fd7-47d1-9c33-c7fce412332a', N'60980640-5fd7-47d1-9c33-c7fce412332a', N'8d201511-f74a-448a-9b04-3177fb3156c7', 0, 1)
INSERT [dbo].[Tasks] ([Id], [ProjectId], [Title], [Description], [PerformerId], [TesterId], [State], [IsRemoved], [NumberTask]) VALUES (N'19179c53-520d-481c-add0-e488cac35376', N'49999f6f-abb1-4265-bed4-6c99b8f9d03e', N'Просмотр контролируемых параметров', N'Разработать функцию просмотра контролируемых параметров в режиме реального времени', N'f44d0a5f-83c4-4ccd-8677-11609227b96f', N'0a315c27-4388-4a3a-b20d-224dc0558eb9', N'de054313-51a5-4215-8ba0-a10bac9f0ff0', 0, 1)
GO
INSERT [dbo].[TaskStates] ([Id], [State]) VALUES (N'8d201511-f74a-448a-9b04-3177fb3156c7', N'Бэклог')
INSERT [dbo].[TaskStates] ([Id], [State]) VALUES (N'375afdb1-9cbc-428d-848d-75f52f066414', N'Завершено')
INSERT [dbo].[TaskStates] ([Id], [State]) VALUES (N'de054313-51a5-4215-8ba0-a10bac9f0ff0', N'В работе')
GO
INSERT [dbo].[Vacations] ([Id], [EmployeeId], [DateStart], [DateEnd], [Comment], [IsRemoved]) VALUES (N'143ea265-3536-4775-951f-35234ce92fe0', N'f1c7fb1c-bea9-4594-b16b-47f3274ee646', CAST(N'2022-05-24T21:10:35.580' AS DateTime), CAST(N'2022-06-07T21:10:35.580' AS DateTime), N'2-х недельный отпуск', 0)
INSERT [dbo].[Vacations] ([Id], [EmployeeId], [DateStart], [DateEnd], [Comment], [IsRemoved]) VALUES (N'0c15f4b0-ec42-4d9c-906e-7f7cb870ef82', N'60980640-5fd7-47d1-9c33-c7fce412332a', CAST(N'2022-05-24T21:00:21.990' AS DateTime), CAST(N'2022-06-07T21:00:21.990' AS DateTime), N'Учебный отпуск', 0)
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_isremoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[Tasks] ADD  CONSTRAINT [DF_Tasks_isremoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[Vacations] ADD  CONSTRAINT [DF_Vacations_isremoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_EmployeeTypes] FOREIGN KEY([Type])
REFERENCES [dbo].[EmployeeTypes] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_EmployeeTypes]
GO
ALTER TABLE [dbo].[ProjectWorks]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWorks_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[ProjectWorks] CHECK CONSTRAINT [FK_ProjectWorks_Employees]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Performer] FOREIGN KEY([PerformerId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Performer]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Projects]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_TaskStates] FOREIGN KEY([State])
REFERENCES [dbo].[TaskStates] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_TaskStates]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Tester] FOREIGN KEY([TesterId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Tester]
GO
ALTER TABLE [dbo].[Vacations]  WITH CHECK ADD  CONSTRAINT [FK_Vacations_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Vacations] CHECK CONSTRAINT [FK_Vacations_Employees]
GO
USE [master]
GO
ALTER DATABASE [SUP] SET  READ_WRITE 
GO
