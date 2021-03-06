USE [master]
GO
/****** Object:  Database [JefferiesWebsite]    Script Date: 3/23/2016 12:31:30 PM ******/
CREATE DATABASE [JefferiesWebsite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JefferiesWebsite', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\JefferiesWebsite.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JefferiesWebsite_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\JefferiesWebsite_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JefferiesWebsite] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JefferiesWebsite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JefferiesWebsite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET ARITHABORT OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [JefferiesWebsite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JefferiesWebsite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JefferiesWebsite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JefferiesWebsite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JefferiesWebsite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET RECOVERY FULL 
GO
ALTER DATABASE [JefferiesWebsite] SET  MULTI_USER 
GO
ALTER DATABASE [JefferiesWebsite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JefferiesWebsite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JefferiesWebsite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JefferiesWebsite] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'JefferiesWebsite', N'ON'
GO
USE [JefferiesWebsite]
GO
/****** Object:  StoredProcedure [dbo].[DeleteComment]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CReate PROCEDURE [dbo].[DeleteComment] 
	-- Add the parameters for the stored procedure here
	@CommentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Comments]
		  WHERE [CommentId] = @CommentId
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteCourse]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCourse] 
	-- Add the parameters for the stored procedure here
	@CourseId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Courses]
		  WHERE [CourseId] = @CourseId
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteReply]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[DeleteReply] 
	-- Add the parameters for the stored procedure here
	@ReplyId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Replies]
			   WHERE [ReplyId]= @ReplyId
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteResource]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[DeleteResource] 
	-- Add the parameters for the stored procedure here
	@ResourceId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Resources]
		  WHERE [ResourceId] = @ResourceId

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudent]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[DeleteStudent] 
	-- Add the parameters for the stored procedure here
	@StudentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Students]
		  WHERE [StudentId] = @StudentId 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteVBlog]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[DeleteVBlog] 
	-- Add the parameters for the stored procedure here
	@VBlogId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[VBlogs]
		  WHERE [VBlogId]  = @VBlogId 
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllComments]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetAllComments] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [CommentId]
      ,[CourseId]
      ,[Text]
      ,[Name]
      ,[DatePosted]
	  FROM [dbo].[Comments]
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllCourses]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllCourses] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [CourseId]
		  ,[Title]
		  ,[Description]
	  FROM [dbo].[Courses]
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllReplies]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetAllReplies] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ReplyId]
      ,[CommentId]
      ,[Name]
      ,[Text]
      ,[DateReplied]
	  FROM [dbo].[Replies]
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllResources]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetAllResources] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ResourceId]
      ,[CourseId]
      ,[FileName]
      ,[FileType]
      ,[FileBinary]
  FROM [dbo].[Resources]
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllStudents]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetAllStudents] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


	SELECT [StudentId]
      ,[CourseId]
      ,[LastName]
      ,[FirstName]
      ,[Campus]
      ,[Email]
  FROM [dbo].[Students]
END




GO
/****** Object:  StoredProcedure [dbo].[GetAllVBlogs]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CReate PROCEDURE [dbo].[GetAllVBlogs] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [VBlogId]
      ,[Title]
      ,[Description]
      ,[FileName]
      ,[FileType]
      ,[FileBinary]
      ,[DatePosted]
      ,[IndexOrder]
  FROM [dbo].[VBlogs]
END


GO
/****** Object:  StoredProcedure [dbo].[GetCommentById]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetCommentById]
	-- Add the parameters for the stored procedure here
	@CommentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [CommentId]
      ,[CourseId]
      ,[Text]
      ,[Name]
      ,[DatePosted]
	FROM [dbo].[Comments]
	WHERE [CommentId] = @CommentId

	End
GO
/****** Object:  StoredProcedure [dbo].[GetCourseById]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCourseById]
	-- Add the parameters for the stored procedure here
	@CourseId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [CourseId]
      ,[Title]
      ,[Description]
	FROM [dbo].[Courses]
	WHERE [CourseId] = @CourseId
END


GO
/****** Object:  StoredProcedure [dbo].[GetReplyById]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetReplyById]
	-- Add the parameters for the stored procedure here
	@ReplyId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [ReplyId]
      ,[CommentId]
      ,[Name]
      ,[Text]
      ,[DateReplied]
	   FROM [dbo].[Replies]
	WHERE [ReplyId]= @ReplyId
END


GO
/****** Object:  StoredProcedure [dbo].[GetResourceById]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetResourceById]
	-- Add the parameters for the stored procedure here
	@ResourceId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ResourceId]
      ,[CourseId]
      ,[FileName]
      ,[FileType]
      ,[FileBinary]
  FROM [dbo].[Resources]
	WHERE [ResourceId] = @ResourceId
END


GO
/****** Object:  StoredProcedure [dbo].[GetStudentById]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStudentById]
	-- Add the parameters for the stored procedure here
	@StudentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
     StudentId, CourseId, LastName, FirstName, Campus, Email
	FROM [dbo].[Students]
	WHERE [StudentId] = @StudentId
END



GO
/****** Object:  StoredProcedure [dbo].[GetVBlogById]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVBlogById]
	-- Add the parameters for the stored procedure here
	@VBlogId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	   [VBlogId]
       ,[Title]
      ,[Description]
      ,[FileName]
      ,[FileType]
      ,[FileBinary]
      ,[DatePosted]
      ,[IndexOrder]
  FROM [dbo].[VBlogs]
	WHERE [VBlogId] = @VBlogId
END


GO
/****** Object:  StoredProcedure [dbo].[InsertComment]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[InsertComment] 
	-- Add the parameters for the stored procedure here
		   @CourseId int,
           @Text varchar(1000),
		   @Name varchar(50),
           @DatePosted datetime,
           @NewCommentId int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [dbo].[Comments]
           ([CourseId]
           ,[Text]
           ,[Name]
           ,[DatePosted])
     VALUES
           (@CourseId,
           @Text,
		   @Name,
           @DatePosted)

SELECT @NewCommentId = SCOPE_IDENTITY()


END


GO
/****** Object:  StoredProcedure [dbo].[InsertCourse]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCourse] 
	-- Add the parameters for the stored procedure here
	@Title varchar(200),
	@Description varchar(2000),
	@NewCourseId int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [dbo].[Courses]
           ([Title]
           ,[Description])
     VALUES
           (@Title,
           @Description)

SELECT @NewCourseId = SCOPE_IDENTITY()


END


GO
/****** Object:  StoredProcedure [dbo].[InsertReply]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[InsertReply] 
	-- Add the parameters for the stored procedure here
	       @CommentId int,
           @Name varchar (50),
		   @Text varchar(1000),
           @DateReplied datetime,
	       @NewReplyId int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [dbo].[Replies]
           ([CommentId]
           ,[Name]
           ,[Text]
           ,[DateReplied])
     VALUES
           (@CommentId,
            @Name,
		    @Text,
            @DateReplied)

SELECT   @NewReplyId= SCOPE_IDENTITY()


END


GO
/****** Object:  StoredProcedure [dbo].[InsertResource]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[InsertResource] 
	-- Add the parameters for the stored procedure here
      @CourseId int,
      @FileName varchar(200),
      @FileType varchar(3),
      @FileBinary varbinary(max),
	  @NewResourceId int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

  INSERT INTO  [dbo].[Resources]
		  ([CourseId],
		  [FileName],
		  [FileType],
		  [FileBinary])
		
  VALUES
		  
		   (@CourseId,
            @FileName,
            @FileType,
            @FileBinary
            )
		  
		  
		   

SELECT  @NewResourceId= SCOPE_IDENTITY()


END


GO
/****** Object:  StoredProcedure [dbo].[InsertStudent]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertStudent] 
	-- Add the parameters for the stored procedure here
			@CourseId int,
            @LastName varchar(50),
            @FirstName varchar(50),
            @Campus tinyint,
            @Email varchar(100),
			@NewStudentId int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	--NSERT INTO [dbo].[Students]
INSERT INTO  [dbo].[Students]
		  ([CourseId],
		  [LastName],
		  [FirstName],
		  [Campus],
		  [Email])
     VALUES
		  
		   (@CourseId,
            @LastName,
            @FirstName,
            @Campus,
            @Email)
      
SELECT @NewStudentId = SCOPE_IDENTITY()


END



GO
/****** Object:  StoredProcedure [dbo].[InsertVBlog]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertVBlog] 
	-- Add the parameters for the stored procedure here
	       @Title varchar(50),
	       @Description varchar(2000),
		   @FileName varchar(50),
		   @FileType varchar(3),
		   @FileBinary Varbinary(max),
		   @DatePosted datetime,
		   @IndexOrder int,
	       @NewVBlogId int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [dbo].[VBlogs]
              ([Title]
              ,[Description]
			  ,[FileName]
			  ,[FileType]
			  ,[FileBinary]
			  ,[DatePosted]
			  ,[IndexOrder])
     VALUES
			 ( @Title,
			   @Description,
			   @FileName,
			   @FileType,
			   @FileBinary,
			   @DatePosted,
			   @IndexOrder )

SELECT @NewVBlogId = SCOPE_IDENTITY()


END


GO
/****** Object:  StoredProcedure [dbo].[UpdateComment]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[UpdateComment] 
	-- Add the parameters for the stored procedure here
			@CommentId int,
			@CourseId int,
            @Text varchar(1000),
		    @Name varchar(50),
            @DatePosted datetime
          
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Comments]
  SET [CourseId] =@CourseId
      ,[Text] = @Text
      ,[Name] = @Name
      ,[DatePosted] = @DatePosted
	 WHERE [CommentId] = @CommentId
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateCourse]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCourse] 
	-- Add the parameters for the stored procedure here
	@CourseId int,
	@Title varchar(200),
	@Description varchar(2000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Courses]
	   SET [Title] = @Title,
		   [Description] = @Description
	 WHERE [CourseId] = @CourseId
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateReply]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[UpdateReply] 
	-- Add the parameters for the stored procedure here
			@ReplyId int,
	        @CommentId int,
            @Name varchar (50),
		    @Text varchar(1000),
            @DateReplied datetime

	    
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Replies]
	   SET [CommentId]= @CommentId,
		   [Name] = @Name,
		   [Text] = @Text ,
		   [DateReplied]= @DateReplied 
	   WHERE [ReplyId]= @ReplyId
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateResource]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[UpdateResource]
	-- Add the parameters for the stored procedure here

	   @ResourceId int,
	   @CourseId int,
       @FileName varchar(200),
       @FileType varchar(3),
       @FileBinary  varbinary(max)
 

AS


BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Resources]
	   SET 
	   CourseId = @CourseId,
        FileName = @FileName,
        FileType = @FileType ,
      FileBinary = @FileBinary 
    
	 WHERE [ResourceId] = @ResourceId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudent]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[UpdateStudent]
	-- Add the parameters for the stored procedure here

	   @StudentId int,
	   @CourseId int,
       @LastName varchar(50),
       @FirstName varchar(50),
       @Campus  tinyint,
       @Email varchar(100)
AS


BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Students]
	   SET CourseId = @CourseId,
        LastName =@LastName,
        FirstName= @FirstName ,
        Campus=@Campus,
        Email= @Email 
	 WHERE [StudentId] = @StudentId
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateVBlog]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[UpdateVBlog] 
	-- Add the parameters for the stored procedure here
		   @VBlogId int,
	       @Title varchar(50),
	       @Description varchar(2000),
		   @FileName varchar(50),
		   @FileType varchar(3),
		   @FileBinary Varbinary(max),
		   @DatePosted datetime,
		   @IndexOrder int
	  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[VBlogs]
			 SET 
			  [Title] =  @Title,
			  [Description]= @Description, 
			  [FileName] = @FileName,
			  [FileType] = @FileType,
			  [FileBinary] = @FileBinary,
			  [DatePosted] = @DatePosted ,
			  [IndexOrder] = @IndexOrder
	 WHERE [VBlogId] = @VBlogId
END


GO
/****** Object:  Table [dbo].[Comments]    Script Date: 3/23/2016 12:31:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[Text] [varchar](1000) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DatePosted] [datetime] NOT NULL,
 CONSTRAINT [PK_comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 3/23/2016 12:31:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Replies]    Script Date: 3/23/2016 12:31:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Replies](
	[ReplyId] [int] IDENTITY(1,1) NOT NULL,
	[CommentId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Text] [varchar](1000) NOT NULL,
	[DateReplied] [datetime] NOT NULL,
 CONSTRAINT [PK_Replies] PRIMARY KEY CLUSTERED 
(
	[ReplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 3/23/2016 12:31:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Resources](
	[ResourceId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[FileName] [varchar](200) NOT NULL,
	[FileType] [varchar](3) NOT NULL,
	[FileBinary] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[ResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/23/2016 12:31:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[Campus] [tinyint] NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VBlogs]    Script Date: 3/23/2016 12:31:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VBlogs](
	[VBlogId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[FileName] [varchar](50) NOT NULL,
	[FileType] [varchar](3) NOT NULL,
	[FileBinary] [varbinary](max) NOT NULL,
	[DatePosted] [datetime] NOT NULL,
	[IndexOrder] [int] NOT NULL,
 CONSTRAINT [PK_VBlog] PRIMARY KEY CLUSTERED 
(
	[VBlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([CommentId], [CourseId], [Text], [Name], [DatePosted]) VALUES (5, 3, N'dd', N'dd', CAST(0x0000A56C00000000 AS DateTime))
INSERT [dbo].[Comments] ([CommentId], [CourseId], [Text], [Name], [DatePosted]) VALUES (6, 22, N'xzbc', N'zxcv', CAST(0x0000A58E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [Title], [Description]) VALUES (1, N'test55566666677778888', N'test5')
INSERT [dbo].[Courses] ([CourseId], [Title], [Description]) VALUES (2, N'qq', N'zzbbbb')
INSERT [dbo].[Courses] ([CourseId], [Title], [Description]) VALUES (3, N'mahilet', N'doug ')
INSERT [dbo].[Courses] ([CourseId], [Title], [Description]) VALUES (5, N'Psychology', N'I like psychology')
INSERT [dbo].[Courses] ([CourseId], [Title], [Description]) VALUES (6, N'Asp.net', N'I like asp')
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Replies] ON 

INSERT [dbo].[Replies] ([ReplyId], [CommentId], [Name], [Text], [DateReplied]) VALUES (2, 4, N'maholet', N'nice comment', CAST(0x0000A5BC00000000 AS DateTime))
INSERT [dbo].[Replies] ([ReplyId], [CommentId], [Name], [Text], [DateReplied]) VALUES (3, 1, N'kkk', N'iiii', CAST(0x00007C4A00000000 AS DateTime))
INSERT [dbo].[Replies] ([ReplyId], [CommentId], [Name], [Text], [DateReplied]) VALUES (4, 1, N'doug', N'i made it', CAST(0x0000A5BC00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Replies] OFF
SET IDENTITY_INSERT [dbo].[Resources] ON 

INSERT [dbo].[Resources] ([ResourceId], [CourseId], [FileName], [FileType], [FileBinary]) VALUES (1, 8, N'l', N'1', 0x00000000)
INSERT [dbo].[Resources] ([ResourceId], [CourseId], [FileName], [FileType], [FileBinary]) VALUES (2, 4, N'vcnxfj', N'', 0x)
SET IDENTITY_INSERT [dbo].[Resources] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [CourseId], [LastName], [FirstName], [Campus], [Email]) VALUES (7, 1, N'mahilet', N'dereje', 2, N'mahilet@hotmail.com')
INSERT [dbo].[Students] ([StudentId], [CourseId], [LastName], [FirstName], [Campus], [Email]) VALUES (9, 0, N'mark', N'rich', 2, N'rmch@gmail.com')
INSERT [dbo].[Students] ([StudentId], [CourseId], [LastName], [FirstName], [Campus], [Email]) VALUES (10, 2, N'Gorge', N'Micke', 2, N'mmmm@gmail.com')
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[VBlogs] ON 

INSERT [dbo].[VBlogs] ([VBlogId], [Title], [Description], [FileName], [FileType], [FileBinary], [DatePosted], [IndexOrder]) VALUES (1, N'yyyyyy', N'hhhhhhhhhhhhh', N'fffff', N'5', 0x, CAST(0x0000A43D00000000 AS DateTime), 0)
INSERT [dbo].[VBlogs] ([VBlogId], [Title], [Description], [FileName], [FileType], [FileBinary], [DatePosted], [IndexOrder]) VALUES (2, N'oooo', N'ppppppppppppppp', N'lllllll', N'2', 0x, CAST(0x0000A5AA00000000 AS DateTime), 0)
INSERT [dbo].[VBlogs] ([VBlogId], [Title], [Description], [FileName], [FileType], [FileBinary], [DatePosted], [IndexOrder]) VALUES (3, N'i like asp', N'alot', N'ggggggggggg', N'fff', 0x, CAST(0x0000500F00000000 AS DateTime), 0)
INSERT [dbo].[VBlogs] ([VBlogId], [Title], [Description], [FileName], [FileType], [FileBinary], [DatePosted], [IndexOrder]) VALUES (4, N'4', N'222', N'', N'', 0x, CAST(0x0000A43D00000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[VBlogs] OFF
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_Text]  DEFAULT ('') FOR [Text]
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_DatePosted]  DEFAULT (getdate()) FOR [DatePosted]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Course_Title]  DEFAULT ('') FOR [Title]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Course_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Replies] ADD  CONSTRAINT [DF_Replies_DateReplied]  DEFAULT (getdate()) FOR [DateReplied]
GO
ALTER TABLE [dbo].[Resources] ADD  CONSTRAINT [DF_Resources_FileName]  DEFAULT ('') FOR [FileName]
GO
ALTER TABLE [dbo].[Resources] ADD  CONSTRAINT [DF_Resources_FileType]  DEFAULT ('') FOR [FileType]
GO
ALTER TABLE [dbo].[Resources] ADD  CONSTRAINT [DF_Resources_FileBinary]  DEFAULT ((0)) FOR [FileBinary]
GO
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Student_LastName]  DEFAULT ('') FOR [LastName]
GO
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Student_FirstName]  DEFAULT ('') FOR [FirstName]
GO
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Student_Campus]  DEFAULT ((0)) FOR [Campus]
GO
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Student_Email]  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[VBlogs] ADD  CONSTRAINT [DF_vblog_Title]  DEFAULT (getdate()) FOR [Title]
GO
ALTER TABLE [dbo].[VBlogs] ADD  CONSTRAINT [DF_vblog_FileType]  DEFAULT ('') FOR [FileType]
GO
ALTER TABLE [dbo].[VBlogs] ADD  CONSTRAINT [DF_VBlogs_FileBinary]  DEFAULT ((0)) FOR [FileBinary]
GO
ALTER TABLE [dbo].[VBlogs] ADD  CONSTRAINT [DF_vblog_IndexOrder]  DEFAULT ((0)) FOR [IndexOrder]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0=None;1=Central;2=GreenRiver' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Students', @level2type=N'COLUMN',@level2name=N'Campus'
GO
USE [master]
GO
ALTER DATABASE [JefferiesWebsite] SET  READ_WRITE 
GO
