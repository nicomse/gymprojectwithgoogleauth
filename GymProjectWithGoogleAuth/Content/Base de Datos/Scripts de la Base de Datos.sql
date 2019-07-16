USE [master]
GO
/****** Object:  Database [Taller6]    Script Date: 16/07/2019 16:46:35 ******/
CREATE DATABASE [Taller6]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Taller6', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Taller6.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Taller6_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Taller6_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Taller6] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Taller6].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Taller6] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Taller6] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Taller6] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Taller6] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Taller6] SET ARITHABORT OFF 
GO
ALTER DATABASE [Taller6] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Taller6] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Taller6] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Taller6] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Taller6] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Taller6] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Taller6] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Taller6] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Taller6] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Taller6] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Taller6] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Taller6] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Taller6] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Taller6] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Taller6] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Taller6] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Taller6] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Taller6] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Taller6] SET  MULTI_USER 
GO
ALTER DATABASE [Taller6] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Taller6] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Taller6] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Taller6] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Taller6] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Taller6] SET QUERY_STORE = OFF
GO
USE [Taller6]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 16/07/2019 16:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actividades]    Script Date: 16/07/2019 16:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividades](
	[idActividad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Actividades] PRIMARY KEY CLUSTERED 
(
	[idActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 16/07/2019 16:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[idAlumno] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[idAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumnos_Horarios]    Script Date: 16/07/2019 16:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos_Horarios](
	[idAlumno] [int] NOT NULL,
	[idHorario] [int] NOT NULL,
	[idCredito] [int] NOT NULL,
	[asistencia] [varchar](10) NOT NULL,
	[horaReserva] [datetime] NOT NULL,
	[fechaActividad] [datetime] NOT NULL,
 CONSTRAINT [PK_Alumnos_Horarios] PRIMARY KEY CLUSTERED 
(
	[idAlumno] ASC,
	[idHorario] ASC,
	[fechaActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 16/07/2019 16:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 16/07/2019 16:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 16/07/2019 16:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 16/07/2019 16:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Creditos]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Creditos](
	[idCredito] [int] IDENTITY(1,1) NOT NULL,
	[idAlumno] [int] NOT NULL,
	[idPack] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaCompra] [datetime] NOT NULL,
	[fechaExpiracion] [datetime] NOT NULL,
 CONSTRAINT [PK_Packs] PRIMARY KEY CLUSTERED 
(
	[idCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horarios]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horarios](
	[idHorario] [int] IDENTITY(1,1) NOT NULL,
	[idActividad] [int] NOT NULL,
	[idProfesor] [int] NOT NULL,
	[nroSucursal] [int] NOT NULL,
	[horaInicio] [time](0) NOT NULL,
	[horaFin] [time](0) NOT NULL,
	[dia] [varchar](10) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Horarios] PRIMARY KEY CLUSTERED 
(
	[idHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packs]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packs](
	[idPack] [int] IDENTITY(1,1) NOT NULL,
	[nroSucursal] [int] NOT NULL,
	[cantCreditos] [int] NOT NULL,
	[diasVigencia] [int] NOT NULL,
	[precio] [decimal](8, 2) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Packs_1] PRIMARY KEY CLUSTERED 
(
	[idPack] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[telefono] [varchar](255) NOT NULL,
	[rol] [varchar](25) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[idProfesor] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
 CONSTRAINT [PK_Profesores] PRIMARY KEY CLUSTERED 
(
	[idProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursales](
	[nroSucursal] [int] IDENTITY(1,1) NOT NULL,
	[barrio] [varchar](100) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[telefono] [varchar](255) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED 
(
	[nroSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Indice_Actividades_Nombre]    Script Date: 16/07/2019 16:46:36 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Indice_Actividades_Nombre] ON [dbo].[Actividades]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 16/07/2019 16:46:36 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 16/07/2019 16:46:36 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 16/07/2019 16:46:36 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Indice_Personas_Email]    Script Date: 16/07/2019 16:46:36 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Indice_Personas_Email] ON [dbo].[Personas]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Indice_Sucursales_Direccion]    Script Date: 16/07/2019 16:46:36 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Indice_Sucursales_Direccion] ON [dbo].[Sucursales]
(
	[direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [FK_Alumnos_Personas]
GO
ALTER TABLE [dbo].[Alumnos_Horarios]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Horarios_Alumnos] FOREIGN KEY([idAlumno])
REFERENCES [dbo].[Alumnos] ([idAlumno])
GO
ALTER TABLE [dbo].[Alumnos_Horarios] CHECK CONSTRAINT [FK_Alumnos_Horarios_Alumnos]
GO
ALTER TABLE [dbo].[Alumnos_Horarios]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Horarios_Creditos] FOREIGN KEY([idCredito])
REFERENCES [dbo].[Creditos] ([idCredito])
GO
ALTER TABLE [dbo].[Alumnos_Horarios] CHECK CONSTRAINT [FK_Alumnos_Horarios_Creditos]
GO
ALTER TABLE [dbo].[Alumnos_Horarios]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Horarios_Horarios] FOREIGN KEY([idHorario])
REFERENCES [dbo].[Horarios] ([idHorario])
GO
ALTER TABLE [dbo].[Alumnos_Horarios] CHECK CONSTRAINT [FK_Alumnos_Horarios_Horarios]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Creditos]  WITH CHECK ADD  CONSTRAINT [FK_Creditos_Alumnos] FOREIGN KEY([idAlumno])
REFERENCES [dbo].[Alumnos] ([idAlumno])
GO
ALTER TABLE [dbo].[Creditos] CHECK CONSTRAINT [FK_Creditos_Alumnos]
GO
ALTER TABLE [dbo].[Creditos]  WITH CHECK ADD  CONSTRAINT [FK_Creditos_Packs] FOREIGN KEY([idPack])
REFERENCES [dbo].[Packs] ([idPack])
GO
ALTER TABLE [dbo].[Creditos] CHECK CONSTRAINT [FK_Creditos_Packs]
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD  CONSTRAINT [FK_Horarios_Actividades] FOREIGN KEY([idActividad])
REFERENCES [dbo].[Actividades] ([idActividad])
GO
ALTER TABLE [dbo].[Horarios] CHECK CONSTRAINT [FK_Horarios_Actividades]
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD  CONSTRAINT [FK_Horarios_Profesores] FOREIGN KEY([idProfesor])
REFERENCES [dbo].[Profesores] ([idProfesor])
GO
ALTER TABLE [dbo].[Horarios] CHECK CONSTRAINT [FK_Horarios_Profesores]
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD  CONSTRAINT [FK_Horarios_Sucursales] FOREIGN KEY([nroSucursal])
REFERENCES [dbo].[Sucursales] ([nroSucursal])
GO
ALTER TABLE [dbo].[Horarios] CHECK CONSTRAINT [FK_Horarios_Sucursales]
GO
ALTER TABLE [dbo].[Packs]  WITH CHECK ADD  CONSTRAINT [FK_Packs_Sucursales] FOREIGN KEY([nroSucursal])
REFERENCES [dbo].[Sucursales] ([nroSucursal])
GO
ALTER TABLE [dbo].[Packs] CHECK CONSTRAINT [FK_Packs_Sucursales]
GO
ALTER TABLE [dbo].[Profesores]  WITH CHECK ADD  CONSTRAINT [FK_Profesores_Personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Profesores] CHECK CONSTRAINT [FK_Profesores_Personas]
GO
/****** Object:  StoredProcedure [dbo].[altaActividad]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[altaActividad]
	@nombre varchar(100)
AS
BEGIN
	INSERT INTO dbo.Actividades (nombre, estado)
	VALUES (@nombre, '1')
END
GO
/****** Object:  StoredProcedure [dbo].[altaAdministrador]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[altaAdministrador]
	@email varchar(255)
AS
BEGIN
	INSERT INTO dbo.Personas (nombre, apellido, email, telefono, rol, estado)
	VALUES ('Administrador', 'HomersGym', @email, '', 'ADMINISTRADOR', '1')
END
GO
/****** Object:  StoredProcedure [dbo].[altaAlumno]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[altaAlumno]
	@nombre varchar(100),
	@apellido varchar(100),
	@email varchar(255),
	@telefono varchar(255)
AS
BEGIN
	INSERT INTO dbo.Personas (nombre, apellido, email, telefono, rol, estado)
	VALUES (@nombre, @apellido, @email, @telefono, 'ALUMNO', '1')

	INSERT INTO dbo.Alumnos (idPersona)
		SELECT TOP 1 idPersona
		FROM dbo.Personas
		ORDER BY idPersona DESC
END
GO
/****** Object:  StoredProcedure [dbo].[altaCredito]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[altaCredito]
	@idAlumno int,
	@idPack int,
	@cantidad int
AS
BEGIN
	INSERT INTO dbo.Creditos (idAlumno, idPack, cantidad, fechaCompra, fechaExpiracion)
	VALUES (@idAlumno, @idPack, @cantidad, GETDATE(), DATEADD(DAY, (SELECT diasVigencia FROM dbo.Packs WHERE idPack = @idPack), GETDATE()))
END
GO
/****** Object:  StoredProcedure [dbo].[altaHorario]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[altaHorario]
	@idActividad int,
	@idProfesor int,
	@nroSucursal int,
	@horaInicio time(0),
	@horaFin time(0),
	@dia varchar(10)
AS
BEGIN
	INSERT INTO dbo.Horarios (idActividad, idProfesor, nroSucursal, horaInicio, horaFin, dia, estado)
	VALUES (@idActividad, @idProfesor, @nroSucursal, @horaInicio, @horaFin, @dia, '1')
END
GO
/****** Object:  StoredProcedure [dbo].[altaPack]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[altaPack]
	@nroSucursal int,
	@cantCreditos int,
	@diasVigencia int,
	@precio decimal(8, 2)
AS
BEGIN
	INSERT INTO dbo.Packs (nroSucursal, cantCreditos, diasVigencia, precio, estado)
	VALUES (@nroSucursal, @cantCreditos, @diasVigencia, @precio, '1')
END
GO
/****** Object:  StoredProcedure [dbo].[altaProfesor]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[altaProfesor]
	@nombre varchar(100),
	@apellido varchar(100),
	@email varchar(255),
	@telefono varchar(255)
AS
BEGIN
	INSERT INTO dbo.Personas (nombre, apellido, email, telefono, rol, estado)
	VALUES (@nombre, @apellido, @email, @telefono, 'PROFESOR', '1')

	INSERT INTO dbo.Profesores (idPersona)
		SELECT TOP 1 idPersona
		FROM dbo.Personas
		ORDER BY idPersona DESC
END
GO
/****** Object:  StoredProcedure [dbo].[altaSucursal]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[altaSucursal]
	@barrio varchar(100),
	@direccion varchar(100),
	@telefono varchar(255)
AS
BEGIN
	INSERT INTO dbo.Sucursales (barrio, direccion, telefono, estado)
	VALUES (@barrio, @direccion, @telefono, '1')
END
GO
/****** Object:  StoredProcedure [dbo].[aumentarCredito]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[aumentarCredito] 
	@idCredito int,
	@cantidad int
AS
	UPDATE dbo.Creditos
	SET cantidad = @cantidad + 1 
	WHERE idCredito = @idCredito

GO
/****** Object:  StoredProcedure [dbo].[bajaActividad]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[bajaActividad]
		@idActividad int
AS
UPDATE dbo.Actividades SET
		estado = '0'
WHERE idActividad = @idActividad
GO
/****** Object:  StoredProcedure [dbo].[bajaAlumno]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[bajaAlumno] 
	@idAlumno int
AS
	UPDATE personas SET
		estado = '0'
	FROM dbo.Personas as personas
		INNER JOIN dbo.Alumnos as alus ON personas.idPersona = alus.idPersona
	WHERE alus.idAlumno = @idAlumno

GO
/****** Object:  StoredProcedure [dbo].[bajaHorario]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[bajaHorario] 
	@idHorario int
AS
	UPDATE Horarios SET
		estado = '0'
	WHERE idHorario = @idHorario
GO
/****** Object:  StoredProcedure [dbo].[bajaPack]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[bajaPack] 
	@idPack int
AS
	UPDATE Packs SET
		estado = '0'
	WHERE idPack = @idPack
GO
/****** Object:  StoredProcedure [dbo].[bajaProfesor]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[bajaProfesor] 
	@idProfesor int
AS
	UPDATE personas SET
		estado = '0'
	FROM dbo.Personas as personas
		INNER JOIN dbo.Profesores as profes ON personas.idPersona = profes.idPersona
	WHERE profes.idProfesor = @idProfesor

GO
/****** Object:  StoredProcedure [dbo].[bajaSucursal]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[bajaSucursal] 
	@nroSucursal int
AS
	UPDATE Sucursales SET
		estado = '0'
	WHERE nroSucursal = @nroSucursal

GO
/****** Object:  StoredProcedure [dbo].[buscarPersonaPorMail]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[buscarPersonaPorMail]
	@email varchar(255)
AS
BEGIN
	SELECT nombre, apellido, email, telefono, idPersona, rol, estado
	FROM dbo.Personas
	WHERE email = @email
END
GO
/****** Object:  StoredProcedure [dbo].[cambiarEstadoAlumno]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cambiarEstadoAlumno]
	@idAlumno int,
	@idHorario int,
	@fechaActividad datetime,
	@estado varchar(10)

AS
	UPDATE AH
	SET AH.asistencia = @estado
	FROM dbo.Alumnos_Horarios AH
	WHERE AH.idAlumno = @idAlumno AND AH.idHorario = @idHorario AND AH.fechaActividad = @fechaActividad
GO
/****** Object:  StoredProcedure [dbo].[dameCreditoAlumnoHorario]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[dameCreditoAlumnoHorario]
@idAlumno int,
@idHorario int,
@fechaActividad datetime

AS
BEGIN
	SELECT CR.idCredito, CR.idAlumno, CR.idPack, CR.cantidad, CR.fechaCompra, CR.fechaExpiracion
	FROM dbo.Alumnos_Horarios AS AH
	INNER JOIN dbo.Creditos AS CR ON CR.idCredito = AH.idCredito
	WHERE AH.idAlumno =  @idAlumno AND AH.idHorario = @idHorario AND AH.fechaActividad = @fechaActividad
END

GO
/****** Object:  StoredProcedure [dbo].[descontarCredito]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[descontarCredito] 
	@idCredito int,
	@cantidad int
AS
	UPDATE dbo.Creditos
	SET cantidad = @cantidad - 1 
	WHERE idCredito = @idCredito

GO
/****** Object:  StoredProcedure [dbo].[desuscribirAlumno]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[desuscribirAlumno]
	@idAlumno int,
	@idHorario int,
	@fechaActividad datetime
AS
BEGIN
	UPDATE dbo.Alumnos_Horarios
	SET asistencia = 'Cancelado'
	WHERE idAlumno = @idAlumno AND idHorario = @idHorario AND fechaActividad = @fechaActividad
END
GO
/****** Object:  StoredProcedure [dbo].[getActividadesDeAlumno]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getActividadesDeAlumno] 
	@idAlumno int
AS
BEGIN
	SELECT	H.idHorario,
			ACT.nombre + ' - ' + SUC.Barrio AS Actividad,
			(CONVERT(VARCHAR(10), AH.fechaActividad, 23)) + 'T' + (CONVERT(VARCHAR(10), H.horaInicio, 8)) AS HoraInicio,
			(CONVERT(VARCHAR(10), AH.fechaActividad, 23)) + 'T' + (CONVERT(VARCHAR(10), H.horaFin, 8)) AS HoraFin
	FROM dbo.Alumnos_Horarios AS AH
		INNER JOIN dbo.Horarios AS H ON AH.idHorario = H.idHorario
		INNER JOIN dbo.Actividades AS ACT ON ACT.idActividad = H.idActividad
		INNER JOIN dbo.Sucursales AS SUC ON SUC.nroSucursal = H.nroSucursal
	WHERE AH.idAlumno = @idAlumno AND (AH.asistencia = 'Reservado' OR AH.asistencia = 'Presente')
END
GO
/****** Object:  StoredProcedure [dbo].[getActividadPorId]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getActividadPorId] 

@idActividad int
AS
SELECT idActividad, nombre, estado
FROM dbo.Actividades
WHERE idActividad = @idActividad
GO
/****** Object:  StoredProcedure [dbo].[getActividadPorNombre]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getActividadPorNombre] 

@nombre varchar(100)
AS
SELECT idActividad, nombre, estado
FROM dbo.Actividades
WHERE nombre = @nombre
GO
/****** Object:  StoredProcedure [dbo].[getAlumnoPorEmail]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getAlumnoPorEmail]
	@emailAlumno varchar(255)
AS
BEGIN
	SELECT nombre, apellido, email, telefono, idAlumno, personas.idPersona as idPersona, rol, estado
	FROM dbo.Personas as personas
		INNER JOIN dbo.Alumnos as alus ON personas.idPersona = alus.idPersona
	WHERE email = @emailAlumno and estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[getAlumnoPorId]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getAlumnoPorId]
	@idAlumno int
AS
BEGIN
	SELECT nombre, apellido, email, telefono, idAlumno, personas.idPersona as idPersona, rol, estado
	FROM dbo.Personas as personas
		INNER JOIN dbo.Alumnos as alus ON personas.idPersona = alus.idPersona
	WHERE idAlumno = @idAlumno
END
GO
/****** Object:  StoredProcedure [dbo].[getAlumnosHorario]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getAlumnosHorario] 
	@idHorario int,
	@fechaActividad datetime

AS
BEGIN
	SELECT nombre, apellido, email, telefono, ALU.idAlumno, PER.idPersona as idPersona, rol, estado
	FROM dbo.Alumnos_Horarios AS AH
		INNER JOIN dbo.Alumnos AS ALU ON ALU.idAlumno = AH.idAlumno
		INNER JOIN dbo.Personas AS PER ON PER.idPersona = ALU.idPersona
	WHERE AH.idHorario = @idHorario AND AH.fechaActividad = @fechaActividad AND AH.asistencia != 'Cancelado'
END
GO
/****** Object:  StoredProcedure [dbo].[getCreditoPorId]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[getCreditoPorId]
@idCredito int
AS
BEGIN
	SELECT idCredito, idAlumno, idPack, cantidad, fechaCompra, fechaExpiracion
	FROM dbo.Creditos
	WHERE idCredito = @idCredito
END


GO
/****** Object:  StoredProcedure [dbo].[getCreditosAlumno]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getCreditosAlumno] 
@idAlumno int
AS
BEGIN
	SELECT idCredito, idAlumno, idPack, cantidad, fechaCompra, fechaExpiracion
	FROM dbo.Creditos
	WHERE idAlumno = @idAlumno
END
GO
/****** Object:  StoredProcedure [dbo].[getCreditoSucursalMasProximoAExpirar]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getCreditoSucursalMasProximoAExpirar]
@idSucursal int,
@idAlumno int
AS
BEGIN
	SELECT TOP 1
		c.idCredito, c.idAlumno, c.idPack, c.cantidad, c.fechaCompra, c.fechaExpiracion
	FROM dbo.Creditos AS c
		INNER JOIN dbo.Packs AS p ON p.idPack = c.idPack
	WHERE c.idAlumno = @idAlumno AND p.nroSucursal = @idSucursal
	ORDER BY c.fechaExpiracion ASC
END

GO
/****** Object:  StoredProcedure [dbo].[getDetalleCredito]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getDetalleCredito]
@idCredito int
AS
BEGIN
	SELECT ACT.nombre AS Actividad, PERS.nombre + ' ' + PERS.apellido AS Profesor, SUC.barrio AS Sucursal,
		   H.dia AS Dia, (CONVERT(VARCHAR(10), AH.fechaActividad, 103)) AS Fecha, AH.asistencia AS Asistencia
	FROM dbo.Alumnos_Horarios AS AH
			INNER JOIN dbo.Horarios AS H ON AH.idHorario = H.idHorario
			INNER JOIN dbo.Actividades AS ACT ON H.idActividad = ACT.idActividad
			INNER JOIN dbo.Profesores AS PROF ON H.idProfesor = PROF.idProfesor
			INNER JOIN dbo.Personas AS PERS ON PROF.idPersona = PERS.idPersona
			INNER JOIN dbo.Sucursales AS SUC ON H.nroSucursal = SUC.nroSucursal
	WHERE AH.idCredito = @idCredito
END
GO
/****** Object:  StoredProcedure [dbo].[getHorarioPorId]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getHorarioPorId]
@idHorario int
AS
SELECT idHorario, idActividad, idProfesor, nroSucursal, horaInicio, horaFin, dia, estado
FROM dbo.Horarios
WHERE idHorario = @idHorario
GO
/****** Object:  StoredProcedure [dbo].[getPackPorId]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getPackPorId] 
@idPack int
AS
SELECT idPack,nroSucursal,cantCreditos,diasVigencia,precio, estado
FROM dbo.Packs
WHERE idPack = @idPack
GO
/****** Object:  StoredProcedure [dbo].[getProfesorPorEmail]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getProfesorPorEmail]
	@emailProfesor varchar(255)
AS
BEGIN
	SELECT nombre, apellido, email, telefono, idProfesor, personas.idPersona as idPersona, rol, estado
	FROM dbo.Personas as personas
		INNER JOIN dbo.Profesores as profes ON personas.idPersona = profes.idPersona
	WHERE email = @emailProfesor and estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[getProfesorPorId]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getProfesorPorId]
@idProfesor int
AS
SELECT nombre,apellido,email,telefono,idProfesor, personas.idPersona as idPersona, rol, estado
	FROM dbo.Personas as personas
		INNER JOIN dbo.Profesores as profes ON personas.idPersona = profes.idPersona
	WHERE profes.idProfesor = @idProfesor
GO
/****** Object:  StoredProcedure [dbo].[getRolPersona]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getRolPersona]
@email varchar(255)
AS
SELECT rol
FROM dbo.Personas
WHERE email = @email
GO
/****** Object:  StoredProcedure [dbo].[getSucursalPorDireccion]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getSucursalPorDireccion]
@direccion varchar(100)
AS
SELECT
		barrio,
		direccion,
		telefono,
		nroSucursal,
		estado
FROM dbo.Sucursales
WHERE   direccion = @direccion

GO
/****** Object:  StoredProcedure [dbo].[getSucursalPorId]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getSucursalPorId]
@nroSucursal int
AS
SELECT
		barrio,
		direccion,
		telefono,
		nroSucursal,
		estado
FROM dbo.Sucursales
WHERE   nroSucursal = @nroSucursal

GO
/****** Object:  StoredProcedure [dbo].[getTodasLasActividades]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[getTodasLasActividades] 
AS
BEGIN
	SELECT idActividad, nombre, estado
	FROM dbo.Actividades
	WHERE estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[getTodasLasActividadesDeUnProfesorEnUnaSucursal]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodasLasActividadesDeUnProfesorEnUnaSucursal] 
	@idSucursal int,
	@idProfesor int
AS
BEGIN
	SELECT DISTINCT a.idActividad, a.nombre, a.estado
	FROM dbo.Actividades as a
		INNER JOIN dbo.Horarios as h ON a.idActividad = h.idActividad
		INNER JOIN dbo.Profesores as p ON p.idProfesor = h.idProfesor
	WHERE a.estado = 1 AND h.nroSucursal = @idSucursal AND h.idProfesor = @idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[getTodasLasFechasDeUnHorario]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodasLasFechasDeUnHorario]
	@idHorario int

AS
BEGIN
	SELECT DISTINCT (CONVERT(VARCHAR(10), fechaActividad, 103)) AS fechaActividad
	FROM dbo.Alumnos_Horarios
	WHERE idHorario = @idHorario
END
GO
/****** Object:  StoredProcedure [dbo].[getTodasLasSucursales]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodasLasSucursales] 
AS
BEGIN
	SELECT nroSucursal, barrio, direccion, telefono, estado
	FROM dbo.Sucursales
	WHERE estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[getTodasLasSucursalesDeUnAlumno]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodasLasSucursalesDeUnAlumno]
	@idAlumno int
AS
BEGIN
	SELECT DISTINCT s.nroSucursal, s.barrio, s.direccion, s.telefono, s.estado
	FROM dbo.Sucursales as s 
		INNER JOIN dbo.Packs as p ON s.nroSucursal = p.nroSucursal 
		INNER JOIN dbo.Creditos as c ON c.idPack = p.idPack
	WHERE c.idAlumno = @idAlumno
		AND c.cantidad > 0
		AND DATEDIFF(SECOND, GETDATE(), c.fechaExpiracion) > 0
END
GO
/****** Object:  StoredProcedure [dbo].[getTodasLasSucursalesDeUnProfesor]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodasLasSucursalesDeUnProfesor]
	@idProfesor int
AS
BEGIN
	SELECT DISTINCT S.nroSucursal, S.barrio, S.direccion, S.telefono, S.estado
	FROM dbo.Sucursales as S
		INNER JOIN dbo.Horarios as H ON s.nroSucursal = H.nroSucursal
	WHERE H.idProfesor = @idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[getTodosLosAlumnos]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[getTodosLosAlumnos]
AS
SELECT p.nombre,p.apellido,p.email,p.telefono,a.idAlumno, p.idPersona, p.rol, p.estado
	FROM dbo.Personas as p
		INNER JOIN dbo.Alumnos as a ON p.idPersona = a.idPersona
	WHERE estado = 1
GO
/****** Object:  StoredProcedure [dbo].[getTodosLosDiasDeLaActividadDeUnProfesorEnUnaSucursal]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodosLosDiasDeLaActividadDeUnProfesorEnUnaSucursal] 
	@idSucursal int,
	@idProfesor int,
	@idActividad int
AS
BEGIN
	SELECT DISTINCT h.dia
	FROM dbo.Horarios as h
		INNER JOIN dbo.Actividades as a ON a.idActividad = h.idActividad
		INNER JOIN dbo.Profesores as p ON p.idProfesor = h.idProfesor
	WHERE a.estado = 1 AND h.nroSucursal = @idSucursal AND h.idProfesor = @idProfesor AND a.idActividad = @idActividad
END
GO
/****** Object:  StoredProcedure [dbo].[getTodosLosHorarios]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodosLosHorarios] 
AS
BEGIN
	SELECT idHorario, idActividad, idProfesor, nroSucursal, horaInicio, horaFin, dia, estado
	FROM dbo.Horarios
	WHERE estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[getTodosLosHorariosDelDiaDeLaActividadDeUnProfesorEnUnaSucursal]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodosLosHorariosDelDiaDeLaActividadDeUnProfesorEnUnaSucursal] 
	@idSucursal int,
	@idProfesor int,
	@idActividad int,
	@dia varchar(10)
AS
BEGIN
	SELECT DISTINCT h.idHorario, h.idActividad, h.idProfesor, h.nroSucursal, h.horaInicio, h.horaFin, h.dia, h.estado
	FROM dbo.Horarios as h
		INNER JOIN dbo.Actividades as a ON a.idActividad = h.idActividad
		INNER JOIN dbo.Profesores as p ON p.idProfesor = h.idProfesor
	WHERE a.estado = 1 AND h.nroSucursal = @idSucursal AND h.idProfesor = @idProfesor AND a.idActividad = @idActividad AND h.dia = @dia
END
GO
/****** Object:  StoredProcedure [dbo].[getTodosLosHorariosDeSucursal]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodosLosHorariosDeSucursal] 
	@idSucursal int
AS
BEGIN
	SELECT h.idHorario, h.idActividad, h.idProfesor, h.nroSucursal, h.horaInicio, h.horaFin, h.dia, h.estado
	FROM dbo.Horarios as h
		INNER JOIN dbo.Sucursales as s ON s.nroSucursal = h.nroSucursal
	WHERE h.estado = 1 AND h.nroSucursal = @idSucursal
END
GO
/****** Object:  StoredProcedure [dbo].[getTodosLosPacks]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getTodosLosPacks] 
AS
BEGIN
	SELECT idPack, nroSucursal, cantCreditos, diasVigencia, precio, estado
	FROM dbo.Packs
	WHERE estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[getTodosLosProfesores]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[getTodosLosProfesores]
AS
SELECT nombre,apellido,email,telefono,idProfesor, personas.idPersona, rol, estado
	FROM dbo.Personas as personas
		INNER JOIN dbo.Profesores as profesores ON personas.idPersona = profesores.idPersona
	WHERE estado = 1
GO
/****** Object:  StoredProcedure [dbo].[insertarAlumnoAHorario]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[insertarAlumnoAHorario]
	@idAlumno int,
	@idHorario int,
	@idCredito int,
	@fechaActividad datetime
AS
BEGIN
	INSERT INTO dbo.Alumnos_Horarios (idAlumno, idHorario, idCredito, asistencia, horaReserva, fechaActividad)
	VALUES (@idAlumno, @idHorario, @idCredito, 'Reservado', GETDATE(), @fechaActividad)
END
GO
/****** Object:  StoredProcedure [dbo].[modificarActividad]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[modificarActividad]
		@idActividad int,
		@nombre varchar(100)
AS
UPDATE dbo.Actividades SET
		nombre = @nombre
WHERE idActividad = @idActividad
GO
/****** Object:  StoredProcedure [dbo].[modificarAlumno]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[modificarAlumno] 
	@nombre varchar(100),
	@apellido varchar(100),
	@email varchar(255),
	@telefono varchar(255),
	@idAlumno int
AS
	UPDATE personas SET
		nombre = @nombre,
		apellido = @apellido,
		email = @email,
		telefono = @telefono
	FROM dbo.Personas as personas
		INNER JOIN dbo.Alumnos as alumnos ON personas.idPersona = alumnos.idPersona
	WHERE alumnos.idAlumno = @idAlumno

GO
/****** Object:  StoredProcedure [dbo].[modificarHorario]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[modificarHorario]
		@idHorario int,
		@idActividad int,
		@idProfesor int,
		@nroSucursal int,
		@horaInicio time(0),
		@horaFin time(0),
		@dia varchar(10)
AS
UPDATE dbo.Horarios SET
	idActividad = @idActividad,
	idProfesor = @idProfesor,
	nroSucursal = @nroSucursal,
	horaInicio = @horaInicio,
	horaFin = @horaFin,
	dia = @dia
WHERE idHorario = @idHorario
GO
/****** Object:  StoredProcedure [dbo].[modificarPack]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[modificarPack]
		@idPack int,
		@nroSucursal int,
		@cantCreditos int,
		@diasVigencia int,
		@precio decimal(8, 2)
AS
UPDATE dbo.Packs SET
		nroSucursal = @nroSucursal,
		cantCreditos = @cantCreditos,
		diasVigencia = @diasVigencia,
		precio = @precio
WHERE idPack = @idPack
GO
/****** Object:  StoredProcedure [dbo].[modificarProfesor]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modificarProfesor] 
	@nombre varchar(100),
	@apellido varchar(100),
	@email varchar(255),
	@telefono varchar(255),
	@idProfesor int
AS
	UPDATE personas SET
		nombre = @nombre,
		apellido = @apellido,
		email = @email,
		telefono = @telefono
	FROM dbo.Personas as personas
		INNER JOIN dbo.Profesores as profes ON personas.idPersona = profes.idPersona
	WHERE profes.idProfesor = @idProfesor

GO
/****** Object:  StoredProcedure [dbo].[modificarSucursal]    Script Date: 16/07/2019 16:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[modificarSucursal]
		@nroSucursal int,
		@barrio varchar(100),
		@direccion varchar(100),
		@telefono varchar(255)
AS
UPDATE dbo.Sucursales SET
		barrio = @barrio,
		direccion = @direccion,
		telefono = @telefono
WHERE   nroSucursal = @nroSucursal
GO
USE [master]
GO
ALTER DATABASE [Taller6] SET  READ_WRITE 
GO
