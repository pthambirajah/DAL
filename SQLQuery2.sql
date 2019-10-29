-- Warning: You can generate script only for two tables at a time in your Free plan 
-- 
-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [cities]


CREATE TABLE [staff]
(
 [idStaff] int NOT NULL ,
 [name]    varchar(50) NOT NULL ,


 CONSTRAINT [PK_staff] PRIMARY KEY CLUSTERED ([idStaff] ASC)
);
GO

-- ************************************** [availibility]

CREATE TABLE [availibility]
(
 [idAvailability] int NOT NULL ,
 [isAvailable]    tinyint NOT NULL ,
 [time]           varchar(50) NOT NULL ,
 [idStaff]        int NOT NULL ,


 CONSTRAINT [PK_availibility] PRIMARY KEY CLUSTERED ([idAvailability] ASC),
 CONSTRAINT [FK_85] FOREIGN KEY ([idStaff])  REFERENCES [staff]([idStaff])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_85] ON [availibility] 
 (
  [idStaff] ASC
 )

GO

-- Warning: You can generate script only for two tables at a time in your Free plan 
-- 
-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [credentials]

CREATE TABLE [credentials]
(
 [idCredentials] int NOT NULL ,
 [username]      varchar(50) NOT NULL ,
 [password]      varchar(130) NOT NULL ,


 CONSTRAINT [PK_credentials] PRIMARY KEY CLUSTERED ([idCredentials] ASC)
);
GO


CREATE TABLE [delivery]
(
 [idDelivery]   int NOT NULL ,
 [deliveryTime] time(7) NOT NULL ,
 [idStaff]      int NOT NULL ,


 CONSTRAINT [PK_delivery] PRIMARY KEY CLUSTERED ([idDelivery] ASC),
 CONSTRAINT [FK_82] FOREIGN KEY ([idStaff])  REFERENCES [staff]([idStaff])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_82] ON [delivery] 
 (
  [idStaff] ASC
 )

GO

CREATE TABLE [cities]
(
 [idCity]    int NOT NULL ,
 [city]      varchar(50) NOT NULL ,
 [post_code] varchar(50) NOT NULL ,


 CONSTRAINT [PK_cities] PRIMARY KEY CLUSTERED ([idCity] ASC)
);
GO

-- ************************************** [restaurants]

CREATE TABLE [restaurants]
(
 [idRestaurant]  int NOT NULL ,
 [merchant_name] varchar(50) NOT NULL ,
 [createdAt]     varchar(50) NOT NULL ,
 [idCity]        int NOT NULL ,


 CONSTRAINT [PK_restaurants] PRIMARY KEY CLUSTERED ([idRestaurant] ASC),
 CONSTRAINT [FK_67] FOREIGN KEY ([idCity])  REFERENCES [cities]([idCity])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_67] ON [restaurants] 
 (
  [idCity] ASC
 )

GO

-- ************************************** [customer]

CREATE TABLE [customer]
(
 [idCustomer]    int NOT NULL ,
 [lastname]      nvarchar(50) NOT NULL ,
 [firstname]     nvarchar(50) NOT NULL ,
 [birthdate]     date NOT NULL ,
 [address]       nvarchar(100) NOT NULL ,
 [idCity]        int NOT NULL ,
 [idCredentials] int NOT NULL ,


 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED ([idCustomer] ASC),
 CONSTRAINT [FK_70] FOREIGN KEY ([idCity])  REFERENCES [cities]([idCity]),
 CONSTRAINT [FK_73] FOREIGN KEY ([idCredentials])  REFERENCES [credentials]([idCredentials])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_70] ON [customer] 
 (
  [idCity] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_73] ON [customer] 
 (
  [idCredentials] ASC
 )

GO


-- ************************************** [dishes]

CREATE TABLE [dishes]
(
 [idDishes]     int NOT NULL ,
 [name]         varchar(50) NOT NULL ,
 [price]        int NOT NULL ,
 [status]       varchar(50) NOT NULL ,
 [idRestaurant] int NOT NULL ,


 CONSTRAINT [PK_dishes] PRIMARY KEY CLUSTERED ([idDishes] ASC),
 CONSTRAINT [FK_64] FOREIGN KEY ([idRestaurant])  REFERENCES [restaurants]([idRestaurant])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_64] ON [dishes] 
 (
  [idRestaurant] ASC
 )

GO

-- ************************************** [order]

CREATE TABLE [order]
(
 [idOrder]    int NOT NULL ,
 [status]     varchar(50) NOT NULL ,
 [createdAt]  varchar(50) NOT NULL ,
 [idCustomer] int NOT NULL ,
 [idDelivery] int NOT NULL ,


 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED ([idOrder] ASC),
 CONSTRAINT [FK_76] FOREIGN KEY ([idCustomer])  REFERENCES [customer]([idCustomer]),
 CONSTRAINT [FK_79] FOREIGN KEY ([idDelivery])  REFERENCES [delivery]([idDelivery])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_76] ON [order] 
 (
  [idCustomer] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_79] ON [order] 
 (
  [idDelivery] ASC
 )

GO





-- ************************************** [dishes_order]

CREATE TABLE [dishes_order]
(
 [idDishes]       int NOT NULL ,
 [idDishes_Order] int NOT NULL ,
 [idOrder]        int NOT NULL ,


 CONSTRAINT [PK_dishes_order] PRIMARY KEY CLUSTERED ([idDishes_Order] ASC),
 CONSTRAINT [FK_56] FOREIGN KEY ([idDishes])  REFERENCES [dishes]([idDishes]),
 CONSTRAINT [FK_59] FOREIGN KEY ([idOrder])  REFERENCES [order]([idOrder])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_56] ON [dishes_order] 
 (
  [idDishes] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_59] ON [dishes_order] 
 (
  [idOrder] ASC
 )

GO

