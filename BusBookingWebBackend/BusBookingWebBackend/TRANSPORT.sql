

USE TRANSPORT

/****** Object:  Table [dbo].[Bus]    Script Date: 11/17/2022 11:12:24 PM ******/
CREATE TABLE [dbo].[Bus](
	[B_ID] [int] NOT NULL,
	[No_Plate] [varchar](25) NULL,
	[color] [varchar](10) NULL,
	[type] [varchar](10) NULL,
PRIMARY KEY  
(
	[B_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FUEL]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[FUEL](
	[F_ID] [int] NOT NULL,
	[LITER] [int] NULL,
	[B_ID] [int] NULL,
PRIMARY KEY  
(
	[F_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[FUEL_CHECKER]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE VIEW [dbo].[FUEL_CHECKER] AS
    SELECT 
       B.B_ID, 
       B.No_Plate,
       F.liter
    FROM
        BUS B
        Join
        FUEL F
        On B.B_ID=F.B_ID;
   

GO
/****** Object:  Table [dbo].[PAYMENT]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[PAYMENT](
	[P_ID] [int] NOT NULL,
	[Amount] [int] NULL,
	[Date] [date] NULL,
	[PA_ID] [int] NULL,
PRIMARY KEY  
(
	[P_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TICKET_Payments]    Script Date: 11/17/2022 11:12:24 PM ******/

   CREATE VIEW [dbo].[TICKET_Payments] AS
    SELECT 
     sum(Amount) as 'Today Sales'
    FROM Payment

GO
/****** Object:  Table [dbo].[BUS_DRIVER]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[BUS_DRIVER](
	[B_ID] [int] NOT NULL,
	[D_ID] [int] NOT NULL,
 CONSTRAINT [PK_BUS_DRIVER] PRIMARY KEY  
(
	[B_ID] ASC,
	[D_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BUS_ROUTE]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[BUS_ROUTE](
	[BR_ID] [int] IDENTITY(1,1) NOT NULL,
	[R_ID] [int] NOT NULL,
	[B_ID] [int] NOT NULL,
 CONSTRAINT [PK_BUS_ROUTE] PRIMARY KEY  
(
	[BR_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CARD]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[CARD](
	[CID] [int] NOT NULL,
	[TYPE] [varchar](20) NULL,
	[AMOUNT] [int] NULL,
PRIMARY KEY  
(
	[CID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[Driver](
	[D_ID] [int] NOT NULL,
	[Name] [varchar](25) NULL,
	[Address] [varchar](10) NULL,
PRIMARY KEY  
(
	[D_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DRIVER_CONTACT]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[DRIVER_CONTACT](
	[D_ID] [int] NOT NULL,
	[CONTACTS] [int] NULL,
PRIMARY KEY  
(
	[D_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DRIVER_EMAIL]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[DRIVER_EMAIL](
	[D_ID] [int] NOT NULL,
	[EMAILS] [varchar](25) NULL,
PRIMARY KEY  
(
	[D_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DRIVER_FULL_TIME]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[DRIVER_FULL_TIME](
	[FID] [int] NOT NULL,
	[SALARY] [int] NULL,
	[BONUS] [int] NULL,
PRIMARY KEY  
(
	[FID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DRIVER_PART_TIME]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[DRIVER_PART_TIME](
	[PID] [int] NOT NULL,
	[NUM_HOURS] [int] NULL,
	[RATE] [int] NULL,
PRIMARY KEY  
(
	[PID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Identity]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[Identity](
	[IdentityID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](250) NULL,
	[Lastname] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](250) NULL,
	[IdentityTypeID] [int] NOT NULL,
	[IsArchived] [bit] NULL,
 CONSTRAINT [PK_Identity] PRIMARY KEY  
(
	[IdentityID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LISENCE]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[LISENCE](
	[L_ID] [int] NOT NULL,
	[L_Type] [varchar](25) NULL,
	[Expiry_Date] [date] NULL,
	[D_ID] [int] NULL,
PRIMARY KEY  
(
	[L_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[Passenger](
	[PA_ID] [int] NOT NULL,
	[Name] [varchar](25) NULL,
	[Gender] [varchar](10) NULL,
	[Password] [nvarchar](250) NULL,
 CONSTRAINT [PK__Passenge__28E0060BF1951BA4] PRIMARY KEY  
(
	[PA_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PASSENGER_CONTACT]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[PASSENGER_CONTACT](
	[PA_ID] [int] NOT NULL,
	[CONTACTS] [int] NULL,
PRIMARY KEY  
(
	[PA_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PASSENGER_EMAIL]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[PASSENGER_EMAIL](
	[PA_ID] [int] NOT NULL,
	[EMAILS] [varchar](25) NULL,
PRIMARY KEY 
(
	[PA_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PASSENGER_Member]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[PASSENGER_Member](
	[M_ID] [int] NOT NULL,
	[EXP_DATE] [date] NULL,
	[CID] [int] NULL,
PRIMARY KEY  
(
	[M_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PASSENGER_NON_MEMBER]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[PASSENGER_NON_MEMBER](
	[NMID] [int] NOT NULL,
PRIMARY KEY  
(
	[NMID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passenger_Ticket]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[Passenger_Ticket](
	[PT_ID] [int] IDENTITY(1,1) NOT NULL,
	[PN_ID] [int] NOT NULL,
	[T_ID] [int] NOT NULL,
 CONSTRAINT [PK_Passenger_Ticket] PRIMARY KEY  
(
	[PT_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROUTES]    Script Date: 11/17/2022 11:12:24 PM ******/


CREATE TABLE [dbo].[ROUTES](
	[R_ID] [int] NOT NULL,
	[LOCATION] [varchar](30) NULL,
	[STATUS] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[R_ID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TICKET]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[TICKET](
	[TID] [int] NOT NULL,
	[T_NUM] [int] NULL,
	[DATE] [date] NULL,
	[AMOUNT] [int] NULL,
	[R_ID] [int] NULL,
	[P_ID] [int] NULL,
PRIMARY KEY  
(
[TID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TICKETS]    Script Date: 11/17/2022 11:12:24 PM ******/

CREATE TABLE [dbo].[TICKETS](
	[T_ID] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
	[R_ID] [int] NOT NULL,
 CONSTRAINT [PK_TICKETS] PRIMARY KEY
(
	[T_ID] ASC
)
) ON [PRIMARY]
GO
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (1, N'8c5cbb', N'Mauve', N'BMW X3')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (2, N'64e1cc6', N'Lime', N'Fiat Tipo')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (4, N'f45d4', N'Lavender', N'Audi A8')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (5, N'a14fb0', N'Cadet blue', N'Audi R8')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (6, N'4ea65', N'Orange', N'Citroen')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (7, N'd468d', N'Turquoise', N'Cabriolet')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (8, N'9c83b', N'Pink', N'Hyunda')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (9, N'8803bf3', N'Orange', N'Sportage')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (10, N'fc7ecf2', N'Purple', N'BMW M3')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (11, N'cc9cd1', N'Azure', N'Fiesta')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (12, N'5a640', N'coral', N'Audi Q7')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (13, N'5054', N'Salmon', N'Mondeo')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (14, N'5a640', N'coral', N'Audi Q7')
INSERT [dbo].[Bus] ([B_ID], [No_Plate], [color], [type]) VALUES (15, N'5054', N'Salmon', N'Ford')
GO
INSERT [dbo].[BUS_DRIVER] ([B_ID], [D_ID]) VALUES (1, 2)
INSERT [dbo].[BUS_DRIVER] ([B_ID], [D_ID]) VALUES (2, 3)
INSERT [dbo].[BUS_DRIVER] ([B_ID], [D_ID]) VALUES (4, 5)
INSERT [dbo].[BUS_DRIVER] ([B_ID], [D_ID]) VALUES (6, 7)
INSERT [dbo].[BUS_DRIVER] ([B_ID], [D_ID]) VALUES (8, 9)
INSERT [dbo].[BUS_DRIVER] ([B_ID], [D_ID]) VALUES (9, 10)
INSERT [dbo].[BUS_DRIVER] ([B_ID], [D_ID]) VALUES (10, 12)
INSERT [dbo].[BUS_DRIVER] ([B_ID], [D_ID]) VALUES (11, 13)
INSERT [dbo].[BUS_DRIVER] ([B_ID], [D_ID]) VALUES (12, 14)
GO
SET IDENTITY_INSERT [dbo].[BUS_ROUTE] ON 

INSERT [dbo].[BUS_ROUTE] ([BR_ID], [R_ID], [B_ID]) VALUES (1, 1, 1)
INSERT [dbo].[BUS_ROUTE] ([BR_ID], [R_ID], [B_ID]) VALUES (2, 2, 2)
INSERT [dbo].[BUS_ROUTE] ([BR_ID], [R_ID], [B_ID]) VALUES (3, 2, 1)
SET IDENTITY_INSERT [dbo].[BUS_ROUTE] OFF
GO
INSERT [dbo].[CARD] ([CID], [TYPE], [AMOUNT]) VALUES (1, N'Student', 200)
INSERT [dbo].[CARD] ([CID], [TYPE], [AMOUNT]) VALUES (2, N'Employee', 400)
INSERT [dbo].[CARD] ([CID], [TYPE], [AMOUNT]) VALUES (3, N'Business', 1000)
GO
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (1, N'Adeline', N'Liberia')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (2, N'Ilona', N'Argentina')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (3, N'Harry', N'Latvia')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (4, N'Javier', N'Sweden')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (5, N'Alba', N'Kazakhstan')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (7, N'Alison', N'Ghana')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (9, N'Jayden', N'Paraguay')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (10, N'Daron', N'Guyana')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (11, N'Jacob', N'Ireland')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (12, N'Abdul', N'Turkey')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (13, N'Catherine', N'Bahamas')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (14, N'Hailey', N'Zambia')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (15, N'Esmeralda', N'Bahamas')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (16, N'Aiden', N'Nevis')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (17, N'Deborah', N'Liechten')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (18, N'Celia', N'Nether')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (19, N'Harvey', N'Lithuania')
INSERT [dbo].[Driver] ([D_ID], [Name], [Address]) VALUES (20, N'Esmeralda', N'Mongolia')
GO
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (1, 34567873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (2, 542873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (3, 2667873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (4, 334367873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (5, 397367873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (9, 343367873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (10, 3567873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (11, 34567873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (12, 542873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (13, 2667873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (14, 334367873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (15, 397367873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (16, 337837873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (18, 3453573)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (19, 343367873)
INSERT [dbo].[DRIVER_CONTACT] ([D_ID], [CONTACTS]) VALUES (20, 3567873)
GO
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (1, N'ville151@fuliss.net')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (2, N'iver2956@bauros.biz')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (3, N'ins1974@muall.tech')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (4, N'lay4745@gembat.biz')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (5, N'n6310@bretoux.com')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (7, N'Js932@twipet.com')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (9, N'Eno11@naiker.biz')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (10, N'Ge8@yahoo.com')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (11, N'Cr90@naiker.biz')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (12, N'Li7@extex.org')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (13, N'Ru46@gembat.biz')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (14, N'Gege9170@ovock.tech')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (15, N'Cl78@deavo.com')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (16, N'Da2@gmail.com')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (17, N'Be3@corti.com')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (18, N'Wi097@cispeto.com')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (19, N'Da@vetan.org')
INSERT [dbo].[DRIVER_EMAIL] ([D_ID], [EMAILS]) VALUES (20, N'Me5380@twace.org')
GO
INSERT [dbo].[DRIVER_FULL_TIME] ([FID], [SALARY], [BONUS]) VALUES (11, 1000, 200)
INSERT [dbo].[DRIVER_FULL_TIME] ([FID], [SALARY], [BONUS]) VALUES (12, 100, 400)
INSERT [dbo].[DRIVER_FULL_TIME] ([FID], [SALARY], [BONUS]) VALUES (14, 1400, 800)
INSERT [dbo].[DRIVER_FULL_TIME] ([FID], [SALARY], [BONUS]) VALUES (15, 1100, 1200)
INSERT [dbo].[DRIVER_FULL_TIME] ([FID], [SALARY], [BONUS]) VALUES (16, 1000, 200)
INSERT [dbo].[DRIVER_FULL_TIME] ([FID], [SALARY], [BONUS]) VALUES (17, 100, 400)
INSERT [dbo].[DRIVER_FULL_TIME] ([FID], [SALARY], [BONUS]) VALUES (18, 1400, 800)
INSERT [dbo].[DRIVER_FULL_TIME] ([FID], [SALARY], [BONUS]) VALUES (19, 1100, 1200)
GO
INSERT [dbo].[DRIVER_PART_TIME] ([PID], [NUM_HOURS], [RATE]) VALUES (1, 10, 200)
INSERT [dbo].[DRIVER_PART_TIME] ([PID], [NUM_HOURS], [RATE]) VALUES (2, 10, 400)
INSERT [dbo].[DRIVER_PART_TIME] ([PID], [NUM_HOURS], [RATE]) VALUES (4, 14, 800)
INSERT [dbo].[DRIVER_PART_TIME] ([PID], [NUM_HOURS], [RATE]) VALUES (5, 11, 1200)
GO
INSERT [dbo].[FUEL] ([F_ID], [LITER], [B_ID]) VALUES (2, 10, 2)
INSERT [dbo].[FUEL] ([F_ID], [LITER], [B_ID]) VALUES (3, 2, 2)
INSERT [dbo].[FUEL] ([F_ID], [LITER], [B_ID]) VALUES (4, 16, 7)
INSERT [dbo].[FUEL] ([F_ID], [LITER], [B_ID]) VALUES (5, 12, 1)
GO
SET IDENTITY_INSERT [dbo].[Identity] ON 

INSERT [dbo].[Identity] ([IdentityID], [Firstname], [Lastname], [Email], [Password], [Phone], [IdentityTypeID], [IsArchived]) VALUES (1, N'admin', N'last', N'admin@super', N'123456', NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Identity] OFF
GO
INSERT [dbo].[LISENCE] ([L_ID], [L_Type], [Expiry_Date], [D_ID]) VALUES (1, N'LTV', CAST(N'2022-01-09' AS Date), 1)
INSERT [dbo].[LISENCE] ([L_ID], [L_Type], [Expiry_Date], [D_ID]) VALUES (2, N'HTV', CAST(N'2022-02-09' AS Date), 2)
INSERT [dbo].[LISENCE] ([L_ID], [L_Type], [Expiry_Date], [D_ID]) VALUES (3, N'LTV', CAST(N'2022-03-09' AS Date), 3)
INSERT [dbo].[LISENCE] ([L_ID], [L_Type], [Expiry_Date], [D_ID]) VALUES (6, N'HTV', CAST(N'2022-06-09' AS Date), 10)
INSERT [dbo].[LISENCE] ([L_ID], [L_Type], [Expiry_Date], [D_ID]) VALUES (7, N'LTV', CAST(N'2022-07-09' AS Date), 11)
INSERT [dbo].[LISENCE] ([L_ID], [L_Type], [Expiry_Date], [D_ID]) VALUES (8, N'HTV', CAST(N'2022-08-09' AS Date), 12)
INSERT [dbo].[LISENCE] ([L_ID], [L_Type], [Expiry_Date], [D_ID]) VALUES (9, N'LTV', CAST(N'2022-09-09' AS Date), 13)
INSERT [dbo].[LISENCE] ([L_ID], [L_Type], [Expiry_Date], [D_ID]) VALUES (10, N'LTV', CAST(N'2022-11-09' AS Date), 15)
GO
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (0, N'Tim', N'male', N'asdf')
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (1, N'Dana Schaefer', N'Male', N'123456')
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (2, N'Diana Mayer', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (3, N'Caleb Friesen', N'Female', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (4, N'Parker Okuneva', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (5, N'Caden Wilderman', N'Female', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (6, N'Tiana Hyatt', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (7, N'Joaquin Cummings', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (8, N'Odessa Steuber', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (9, N'Shaun Bode', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (10, N'Retha Kohler', N'Female', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (11, N'Foster Boehm', N'Female', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (12, N'Al Hane', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (13, N'Marcelino Moris', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (14, N'Aidan Pacocha', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (15, N'Jaycee Brekke', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (16, N'Jeromy Lynch', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (17, N'Jensen Barton', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (18, N'Josh Mann', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (19, N'Albin Rice', N'Female', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (20, N'Chadd Swift', N'Male', NULL)
INSERT [dbo].[Passenger] ([PA_ID], [Name], [Gender], [Password]) VALUES (771179120, N'Test', N'male', N'12345')
GO
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (1, 34567873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (2, 542873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (3, 2667873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (4, 3343678)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (5, 3973678)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (6, 3378373)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (7, 34377873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (8, 3453573)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (9, 3433673)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (10, 3567873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (11, 34567873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (12, 542873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (13, 2667873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (14, 3347873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (15, 7367873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (16, 337837873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (17, 35377873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (18, 345573)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (19, 3437873)
INSERT [dbo].[PASSENGER_CONTACT] ([PA_ID], [CONTACTS]) VALUES (20, 3567873)
GO
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (0, N'tim2345@gmail.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (1, N'ville151@fuliss.net')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (2, N'iver2956@bauros.biz')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (3, N'ins1974@muall.tech')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (4, N'lay4745@gembat.biz')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (5, N'n6310@bretoux.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (6, N'4777@corti.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (7, N'Js932@twipet.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (8, N'Macrs6680@nickia.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (9, N'Eno11@naiker.biz')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (10, N'Ge8@yahoo.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (11, N'Cr90@naiker.biz')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (12, N'Li7@extex.org')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (13, N'Ru46@gembat.biz')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (14, N'Gege9170@ovock.tech')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (15, N'Cl78@deavo.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (16, N'Da2@gmail.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (17, N'Be3@corti.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (18, N'Wi097@cispeto.com')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (19, N'Da@vetan.org')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (20, N'Me5380@twace.org')
INSERT [dbo].[PASSENGER_EMAIL] ([PA_ID], [EMAILS]) VALUES (771179120, N'test@gmail.com')
GO
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (1, CAST(N'2022-01-09' AS Date), 1)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (2, CAST(N'2022-02-02' AS Date), 2)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (3, CAST(N'2022-05-05' AS Date), 1)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (4, CAST(N'2022-01-08' AS Date), 3)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (5, CAST(N'2022-07-02' AS Date), 2)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (6, CAST(N'2022-02-04' AS Date), 1)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (7, CAST(N'2022-04-03' AS Date), 2)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (8, CAST(N'2022-02-02' AS Date), 1)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (9, CAST(N'2022-08-10' AS Date), 3)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (10, CAST(N'2022-07-19' AS Date), 1)
INSERT [dbo].[PASSENGER_Member] ([M_ID], [EXP_DATE], [CID]) VALUES (771179120, CAST(N'2022-11-16' AS Date), 1)
GO
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (10)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (11)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (12)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (13)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (14)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (15)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (16)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (17)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (18)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (19)
INSERT [dbo].[PASSENGER_NON_MEMBER] ([NMID]) VALUES (20)
GO
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (1, 5455, CAST(N'2021-01-02' AS Date), 1)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (2, 1590, CAST(N'2022-02-02' AS Date), 2)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (3, 7379, CAST(N'2032-05-02' AS Date), 3)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (4, 880, CAST(N'2032-06-02' AS Date), 4)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (5, 575, CAST(N'2022-02-02' AS Date), 5)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (6, 438, CAST(N'2002-05-02' AS Date), 6)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (7, 746, CAST(N'2002-01-02' AS Date), 7)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (8, 6894, CAST(N'2002-01-02' AS Date), 8)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (9, 797, CAST(N'2002-01-02' AS Date), 9)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (10, 914, CAST(N'2002-01-02' AS Date), 10)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (11, 971, CAST(N'2002-01-02' AS Date), 11)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (12, 9390, CAST(N'2002-01-02' AS Date), 12)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (13, 223, CAST(N'2002-01-02' AS Date), 13)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (14, 3783, CAST(N'2002-01-02' AS Date), 14)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (15, 721, CAST(N'2002-01-02' AS Date), 1)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (16, 240, CAST(N'2022-11-12' AS Date), 13)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (17, 320, CAST(N'2022-11-12' AS Date), 14)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (18, 270, CAST(N'2022-11-13' AS Date), 1)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (19, 320, CAST(N'2022-10-12' AS Date), 14)
INSERT [dbo].[PAYMENT] ([P_ID], [Amount], [Date], [PA_ID]) VALUES (20, 270, CAST(N'2022-10-13' AS Date), 1)
GO
INSERT [dbo].[ROUTES] ([R_ID], [LOCATION], [STATUS]) VALUES (1, N'Boston', N'Avaliable')
INSERT [dbo].[ROUTES] ([R_ID], [LOCATION], [STATUS]) VALUES (2, N'Dallas', N'Avaliable')
INSERT [dbo].[ROUTES] ([R_ID], [LOCATION], [STATUS]) VALUES (3, N'Houston', N'Avaliable')
INSERT [dbo].[ROUTES] ([R_ID], [LOCATION], [STATUS]) VALUES (4, N'New Orleans', N'Avaliable')
GO
INSERT [dbo].[TICKET] ([TID], [T_NUM], [DATE], [AMOUNT], [R_ID], [P_ID]) VALUES (941891936, 52, NULL, 20, 1, 771179120)
INSERT [dbo].[TICKET] ([TID], [T_NUM], [DATE], [AMOUNT], [R_ID], [P_ID]) VALUES (1395482507, 59, CAST(N'2022-11-17' AS Date), 20, 1, 771179120)
INSERT [dbo].[TICKET] ([TID], [T_NUM], [DATE], [AMOUNT], [R_ID], [P_ID]) VALUES (1473913595, 4, NULL, 20, 2, 771179120)
INSERT [dbo].[TICKET] ([TID], [T_NUM], [DATE], [AMOUNT], [R_ID], [P_ID]) VALUES (2085497962, 14, CAST(N'2022-11-17' AS Date), 20, 2, 771179120)
GO
SET IDENTITY_INSERT [dbo].[TICKETS] ON 

INSERT [dbo].[TICKETS] ([T_ID], [Amount], [R_ID]) VALUES (1, 20, 2)
SET IDENTITY_INSERT [dbo].[TICKETS] OFF
GO
ALTER TABLE [dbo].[BUS_DRIVER]  WITH CHECK ADD FOREIGN KEY([B_ID])
REFERENCES [dbo].[Bus] ([B_ID])
GO
ALTER TABLE [dbo].[BUS_DRIVER]  WITH CHECK ADD FOREIGN KEY([D_ID])
REFERENCES [dbo].[Driver] ([D_ID])
GO
ALTER TABLE [dbo].[BUS_ROUTE]  WITH CHECK ADD  CONSTRAINT [FK_BUS_ROUTE_Bus] FOREIGN KEY([B_ID])
REFERENCES [dbo].[Bus] ([B_ID])
GO
ALTER TABLE [dbo].[BUS_ROUTE] CHECK CONSTRAINT [FK_BUS_ROUTE_Bus]
GO
ALTER TABLE [dbo].[BUS_ROUTE]  WITH CHECK ADD  CONSTRAINT [FK_BUS_ROUTE_ROUTES] FOREIGN KEY([R_ID])
REFERENCES [dbo].[ROUTES] ([R_ID])
GO
ALTER TABLE [dbo].[BUS_ROUTE] CHECK CONSTRAINT [FK_BUS_ROUTE_ROUTES]
GO
ALTER TABLE [dbo].[DRIVER_CONTACT]  WITH CHECK ADD FOREIGN KEY([D_ID])
REFERENCES [dbo].[Driver] ([D_ID])
GO
ALTER TABLE [dbo].[DRIVER_EMAIL]  WITH CHECK ADD FOREIGN KEY([D_ID])
REFERENCES [dbo].[Driver] ([D_ID])
GO
ALTER TABLE [dbo].[DRIVER_FULL_TIME]  WITH CHECK ADD FOREIGN KEY([FID])
REFERENCES [dbo].[Driver] ([D_ID])
GO
ALTER TABLE [dbo].[DRIVER_PART_TIME]  WITH CHECK ADD FOREIGN KEY([PID])
REFERENCES [dbo].[Driver] ([D_ID])
GO
ALTER TABLE [dbo].[FUEL]  WITH CHECK ADD FOREIGN KEY([B_ID])
REFERENCES [dbo].[Bus] ([B_ID])
GO
ALTER TABLE [dbo].[LISENCE]  WITH CHECK ADD FOREIGN KEY([D_ID])
REFERENCES [dbo].[Driver] ([D_ID])
GO
ALTER TABLE [dbo].[PASSENGER_CONTACT]  WITH CHECK ADD  CONSTRAINT [FK__PASSENGER__PA_ID__35BCFE0A] FOREIGN KEY([PA_ID])
REFERENCES [dbo].[Passenger] ([PA_ID])
GO
ALTER TABLE [dbo].[PASSENGER_CONTACT] CHECK CONSTRAINT [FK__PASSENGER__PA_ID__35BCFE0A]
GO
ALTER TABLE [dbo].[PASSENGER_EMAIL]  WITH CHECK ADD  CONSTRAINT [FK__PASSENGER__PA_ID__32E0915F] FOREIGN KEY([PA_ID])
REFERENCES [dbo].[Passenger] ([PA_ID])
GO
ALTER TABLE [dbo].[PASSENGER_EMAIL] CHECK CONSTRAINT [FK__PASSENGER__PA_ID__32E0915F]
GO
ALTER TABLE [dbo].[PASSENGER_Member]  WITH CHECK ADD  CONSTRAINT [FK__PASSENGER___M_ID__412EB0B6] FOREIGN KEY([M_ID])
REFERENCES [dbo].[Passenger] ([PA_ID])
GO
ALTER TABLE [dbo].[PASSENGER_Member] CHECK CONSTRAINT [FK__PASSENGER___M_ID__412EB0B6]
GO
ALTER TABLE [dbo].[PASSENGER_Member]  WITH CHECK ADD FOREIGN KEY([CID])
REFERENCES [dbo].[CARD] ([CID])
GO
ALTER TABLE [dbo].[PASSENGER_NON_MEMBER]  WITH CHECK ADD  CONSTRAINT [FK__PASSENGER___NMID__440B1D61] FOREIGN KEY([NMID])
REFERENCES [dbo].[Passenger] ([PA_ID])
GO
ALTER TABLE [dbo].[PASSENGER_NON_MEMBER] CHECK CONSTRAINT [FK__PASSENGER___NMID__440B1D61]
GO
ALTER TABLE [dbo].[Passenger_Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Passenger_Ticket_PASSENGER_NON_MEMBER] FOREIGN KEY([PN_ID])
REFERENCES [dbo].[PASSENGER_NON_MEMBER] ([NMID])
GO
ALTER TABLE [dbo].[Passenger_Ticket] CHECK CONSTRAINT [FK_Passenger_Ticket_PASSENGER_NON_MEMBER]
GO
ALTER TABLE [dbo].[Passenger_Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Passenger_Ticket_TICKETS] FOREIGN KEY([T_ID])
REFERENCES [dbo].[TICKETS] ([T_ID])
GO
ALTER TABLE [dbo].[Passenger_Ticket] CHECK CONSTRAINT [FK_Passenger_Ticket_TICKETS]
GO
ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK__PAYMENT__PA_ID__2A4B4B5E] FOREIGN KEY([PA_ID])
REFERENCES [dbo].[Passenger] ([PA_ID])
GO
ALTER TABLE [dbo].[PAYMENT] CHECK CONSTRAINT [FK__PAYMENT__PA_ID__2A4B4B5E]
GO
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD FOREIGN KEY([R_ID])
REFERENCES [dbo].[ROUTES] ([R_ID])
GO
ALTER TABLE [dbo].[TICKETS]  WITH CHECK ADD  CONSTRAINT [FK_TICKETS_ROUTES] FOREIGN KEY([R_ID])
REFERENCES [dbo].[ROUTES] ([R_ID])
GO
ALTER TABLE [dbo].[TICKETS] CHECK CONSTRAINT [FK_TICKETS_ROUTES]
GO
select * from ticket
