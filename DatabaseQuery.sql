USE [IndividualProject]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[userlevel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessagesId] [int] IDENTITY(1,1) NOT NULL,
	[TimeSent] [datetime] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[SenderName] [varchar](50) NOT NULL,
	[ReceiverName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessagesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Accounts] FOREIGN KEY([SenderName])
REFERENCES [dbo].[Accounts] ([username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Accounts]
GO
/****** Object:  StoredProcedure [dbo].[AddMessage]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddMessage]
@sender varchar(50),
@receiver varchar(50),
@message varchar(max)
as
insert into Messages (TimeSent,Message,SenderName,ReceiverName)
VALUES (GETDATE(), @message,@sender,@receiver);
GO
/****** Object:  StoredProcedure [dbo].[AssignRoleBySuperAdmin]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[AssignRoleBySuperAdmin]
@userlevel int,
@username nvarchar(50)
as
update Accounts
set userlevel = @userlevel
where username = @username
GO
/****** Object:  StoredProcedure [dbo].[ChooseMessage]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ChooseMessage]
@SenderName varchar(50)
as
Select MessagesId , Message, ReceiverName,TimeSent
from Messages
where SenderName= @SenderName
GO
/****** Object:  StoredProcedure [dbo].[CreateNewPassword]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[CreateNewPassword]
@password varchar(50),
@username varchar(50)
as
update Accounts
set password = hashbytes('sha1',@password+@username)
where username = @username
GO
/****** Object:  StoredProcedure [dbo].[DeleteMessagesById]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteMessagesById]
@MessagesId int
as
delete Messages
where MessagesId = @MessagesId
GO
/****** Object:  StoredProcedure [dbo].[GetUserAccess]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetUserAccess]
@Username varchar(50),
@Password varchar(50)
as
begin
select userlevel
from Accounts
where username = @username and password = HASHBYTES('sha1', @password+@username)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertAccount]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertAccount]
@Username varchar(50),
@Password varchar(50),
@PersonAccess int
as
insert into Accounts Values (@Username,hashbytes('sha1',@Password+@Username),@PersonAccess)
GO
/****** Object:  StoredProcedure [dbo].[RemoveAccountByUsername]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RemoveAccountByUsername]
@username varchar(50)
as
delete from Accounts
where username = @username
GO
/****** Object:  StoredProcedure [dbo].[RemoveMessagesByUsername]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RemoveMessagesByUsername]
@username varchar(50)
as
delete from Messages
where ReceiverName = @username
GO
/****** Object:  StoredProcedure [dbo].[SelectAccounts]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectAccounts]
as
select username,userlevel from Accounts
GO
/****** Object:  StoredProcedure [dbo].[SelectMessageByID]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectMessageByID]
@messageid int
as
select message
from Messages
where MessagesId = @messageid
GO
/****** Object:  StoredProcedure [dbo].[SelectUserlevelByUsername]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectUserlevelByUsername]
@username nvarchar(50)
as
select userlevel 
from Accounts
where username = @username
GO
/****** Object:  StoredProcedure [dbo].[UpdateMessages]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateMessages]
@messsage varchar(max),
@MessagesId int
as
update Messages
set Message = @messsage
where MessagesId=@MessagesId
GO
/****** Object:  StoredProcedure [dbo].[Validate_Account]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Validate_Account]
@username varchar(50),
@password varchar(50)
as
select count(*) from Accounts
where username = @username and password = HASHBYTES('sha1', @password+@username)
GO
/****** Object:  StoredProcedure [dbo].[Validate_Username]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Validate_Username]
@username varchar(50)
as
select count(*) from Accounts
where username = @username
GO
/****** Object:  StoredProcedure [dbo].[ViewMessage]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ViewMessage]
@sendername varchar(50),
@receivername varchar(50)
as
select Timesent , Message ,MessagesId ,SenderName , ReceiverName
from Messages 
where (SenderName = @sendername and ReceiverName = @receivername) or (SenderName = @receivername and ReceiverName = @sendername)
GO
/****** Object:  StoredProcedure [dbo].[ViewMessages2]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[ViewMessages2]
@receivername varchar(50)
as
select Timesent , Message ,MessagesId , SenderName
from Messages 
where ReceiverName = @receivername
GO
/****** Object:  StoredProcedure [dbo].[ViewMessagesByName]    Script Date: 9/1/2019 8:18:14 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ViewMessagesByName]
@name varchar(50)
as
select Timesent , Message ,MessagesId , SenderName ,ReceiverName
from Messages 
where SenderName = @name or ReceiverName = @name
GO
