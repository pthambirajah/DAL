﻿
-- MySQL Script generated by MySQL Workbench
-- Mon Oct 28 09:32:14 2019
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

/* SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0; */
/* SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0; */
/* SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION'; */

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS mydb DEFAULT CHARACTER SET utf8 ;
USE [mydb] ;

-- -----------------------------------------------------
-- Table `mydb`.`cities`
-- -----------------------------------------------------
CREATE TABLE mydb.cities (
  [idcities] INT NOT NULL IDENTITY,
  [city] VARCHAR(45) NULL,
  [post_code] VARCHAR(10) NULL,
  PRIMARY KEY ([idcities]))
;


-- -----------------------------------------------------
-- Table `mydb`.`restaurants`
-- -----------------------------------------------------
CREATE TABLE mydb.restaurants (
  [idrestaurants] INT NOT NULL IDENTITY,
  [merchant_name] VARCHAR(45) NULL,
  [createdAt] VARCHAR(45) NULL,
  [cities_idcities] INT NOT NULL,
  PRIMARY KEY ([idrestaurants])
  CREATE INDEX [fk_restaurants_cities1_idx] ON mydb.restaurants ([cities_idcities] ASC) VISIBLE,
  CONSTRAINT [fk_restaurants_cities1]
    FOREIGN KEY ([cities_idcities])
    REFERENCES `mydb`.`cities` ([idcities])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`dishes`
-- -----------------------------------------------------
CREATE TABLE mydb.dishes (
  [iddishes] INT NOT NULL IDENTITY,
  [name] VARCHAR(45) NULL,
  [price] INT NULL,
  [restaurants_idrestaurants] INT NOT NULL,
  [status] VARCHAR(45) NULL,
  PRIMARY KEY ([iddishes])
  CREATE INDEX [fk_dishes_restaurants1_idx] ON mydb.dishes ([restaurants_idrestaurants] ASC) VISIBLE,
  CONSTRAINT [fk_dishes_restaurants1]
    FOREIGN KEY ([restaurants_idrestaurants])
    REFERENCES `mydb`.`restaurants` ([idrestaurants])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`credentials`
-- -----------------------------------------------------
CREATE TABLE mydb.credentials (
  [idcredentials] INT NOT NULL,
  [username] VARCHAR(45) NULL,
  [password] VARCHAR(130) NULL,
  PRIMARY KEY ([idcredentials]))
;


-- -----------------------------------------------------
-- Table `mydb`.`customers`
-- -----------------------------------------------------
CREATE TABLE mydb.customers (
  [idcustomers] INT NOT NULL IDENTITY,
  [firstname] VARCHAR(45) NULL,
  [lastname] VARCHAR(45) NULL,
  [birthday] DATE NULL,
  [address] VARCHAR(45) NULL,
  [cities_idcities] INT NOT NULL,
  [credentials_idcredentials] INT NOT NULL,
  PRIMARY KEY ([idcustomers])
  CREATE INDEX [fk_customers_cities1_idx] ON mydb.customers ([cities_idcities] ASC) VISIBLE,
  INDEX `fk_customers_credentials1_idx` ([credentials_idcredentials] ASC) VISIBLE,
  CONSTRAINT [fk_customers_cities1]
    FOREIGN KEY ([cities_idcities])
    REFERENCES `mydb`.`cities` ([idcities])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_customers_credentials1]
    FOREIGN KEY ([credentials_idcredentials])
    REFERENCES `mydb`.`credentials` ([idcredentials])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`staff`
-- -----------------------------------------------------
CREATE TABLE mydb.staff (
  [idstaff] INT NOT NULL,
  [name] VARCHAR(45) NULL,
  PRIMARY KEY ([idstaff]))
;


-- -----------------------------------------------------
-- Table `mydb`.`availability`
-- -----------------------------------------------------
CREATE TABLE mydb.availability (
  [idavailability] INT NOT NULL,
  [isAvailable] SMALLINT NULL,
  [time] TIME(0) NULL,
  [availabilitycol] VARCHAR(45) NULL,
  [staff_idstaff] INT NOT NULL,
  PRIMARY KEY ([idavailability])
  CREATE INDEX [fk_availability_staff1_idx] ON mydb.availability ([staff_idstaff] ASC) VISIBLE,
  CONSTRAINT [fk_availability_staff1]
    FOREIGN KEY ([staff_idstaff])
    REFERENCES `mydb`.`staff` ([idstaff])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`delivery`
-- -----------------------------------------------------
CREATE TABLE mydb.delivery (
  [iddelivery] INT NOT NULL,
  [time] VARCHAR(45) NULL,
  [delivery] TIME(0) NULL,
  [staff_idstaff] INT NOT NULL,
  PRIMARY KEY ([iddelivery])
  CREATE INDEX [fk_delivery_staff1_idx] ON mydb.delivery ([staff_idstaff] ASC) VISIBLE,
  CONSTRAINT [fk_delivery_staff1]
    FOREIGN KEY ([staff_idstaff])
    REFERENCES `mydb`.`staff` ([idstaff])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`order`
-- -----------------------------------------------------
CREATE TABLE mydb.order (
  [idorder] INT NOT NULL,
  [status] VARCHAR(45) NULL,
  [createdAt] VARCHAR(45) NULL,
  [customers_idcustomers] INT NOT NULL,
  [delivery_iddelivery] INT NOT NULL,
  PRIMARY KEY ([idorder])
  CREATE INDEX [fk_order_customers1_idx] ON mydb.order ([customers_idcustomers] ASC) VISIBLE,
  INDEX `fk_order_delivery1_idx` ([delivery_iddelivery] ASC) VISIBLE,
  CONSTRAINT [fk_order_customers1]
    FOREIGN KEY ([customers_idcustomers])
    REFERENCES `mydb`.`customers` ([idcustomers])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_order_delivery1]
    FOREIGN KEY ([delivery_iddelivery])
    REFERENCES `mydb`.`delivery` ([iddelivery])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`dishes_has_order`
-- -----------------------------------------------------
CREATE TABLE mydb.dishes_has_order (
  [dishes_iddishes] INT NOT NULL,
  [order_idorder] INT NOT NULL,
  PRIMARY KEY ([dishes_iddishes], [order_idorder])
  CREATE INDEX [fk_dishes_has_order_order1_idx] ON mydb.dishes_has_order ([order_idorder] ASC) VISIBLE,
  INDEX `fk_dishes_has_order_dishes_idx` ([dishes_iddishes] ASC) VISIBLE,
  CONSTRAINT [fk_dishes_has_order_dishes]
    FOREIGN KEY ([dishes_iddishes])
    REFERENCES `mydb`.`dishes` ([iddishes])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_dishes_has_order_order1]
    FOREIGN KEY ([order_idorder])
    REFERENCES `mydb`.`order` ([idorder])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


/* SET SQL_MODE=@OLD_SQL_MODE; */
/* SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS; */
/* SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS; */

GO

--Erreur de syntaxe : Syntaxe incorrecte proche de `.
---- MySQL Script generated by MySQL Workbench
---- Mon Oct 28 09:32:14 2019
---- Model: New Model    Version: 1.0
---- MySQL Workbench Forward Engineering
--
--/* SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0; */
--/* SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0; */
--/* SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION'; */
--
---- -----------------------------------------------------
---- Schema mydb
---- -----------------------------------------------------
--
---- -----------------------------------------------------
---- Schema mydb
---- -----------------------------------------------------
--CREATE SCHEMA IF NOT EXISTS mydb DEFAULT CHARACTER SET utf8 ;
--USE [mydb] ;
--
---- -----------------------------------------------------
---- Table `mydb`.`cities`
---- -----------------------------------------------------
--CREATE TABLE mydb.cities (
--  [idcities] INT NOT NULL IDENTITY,
--  [city] VARCHAR(45) NULL,
--  [post_code] VARCHAR(10) NULL,
--  PRIMARY KEY ([idcities]))
--;
--
--
---- -----------------------------------------------------
---- Table `mydb`.`restaurants`
---- -----------------------------------------------------
--CREATE TABLE mydb.restaurants (
--  [idrestaurants] INT NOT NULL IDENTITY,
--  [merchant_name] VARCHAR(45) NULL,
--  [createdAt] VARCHAR(45) NULL,
--  [cities_idcities] INT NOT NULL,
--  PRIMARY KEY ([idrestaurants])
--  CREATE INDEX [fk_restaurants_cities1_idx] ON mydb.restaurants ([cities_idcities] ASC) VISIBLE,
--  CONSTRAINT [fk_restaurants_cities1]
--    FOREIGN KEY ([cities_idcities])
--    REFERENCES `mydb`.`cities` ([idcities])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB;
--
--
---- -----------------------------------------------------
---- Table `mydb`.`dishes`
---- -----------------------------------------------------
--CREATE TABLE mydb.dishes (
--  [iddishes] INT NOT NULL IDENTITY,
--  [name] VARCHAR(45) NULL,
--  [price] INT NULL,
--  [restaurants_idrestaurants] INT NOT NULL,
--  [status] VARCHAR(45) NULL,
--  PRIMARY KEY ([iddishes])
--  CREATE INDEX [fk_dishes_restaurants1_idx] ON mydb.dishes ([restaurants_idrestaurants] ASC) VISIBLE,
--  CONSTRAINT [fk_dishes_restaurants1]
--    FOREIGN KEY ([restaurants_idrestaurants])
--    REFERENCES `mydb`.`restaurants` ([idrestaurants])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB;
--
--
---- -----------------------------------------------------
---- Table `mydb`.`credentials`
---- -----------------------------------------------------
--CREATE TABLE mydb.credentials (
--  [idcredentials] INT NOT NULL,
--  [username] VARCHAR(45) NULL,
--  [password] VARCHAR(130) NULL,
--  PRIMARY KEY ([idcredentials]))
--;
--
--
---- -----------------------------------------------------
---- Table `mydb`.`customers`
---- -----------------------------------------------------
--CREATE TABLE mydb.customers (
--  [idcustomers] INT NOT NULL IDENTITY,
--  [firstname] VARCHAR(45) NULL,
--  [lastname] VARCHAR(45) NULL,
--  [birthday] DATE NULL,
--  [address] VARCHAR(45) NULL,
--  [cities_idcities] INT NOT NULL,
--  [credentials_idcredentials] INT NOT NULL,
--  PRIMARY KEY ([idcustomers])
--  CREATE INDEX [fk_customers_cities1_idx] ON mydb.customers ([cities_idcities] ASC) VISIBLE,
--  INDEX `fk_customers_credentials1_idx` ([credentials_idcredentials] ASC) VISIBLE,
--  CONSTRAINT [fk_customers_cities1]
--    FOREIGN KEY ([cities_idcities])
--    REFERENCES `mydb`.`cities` ([idcities])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION,
--  CONSTRAINT [fk_customers_credentials1]
--    FOREIGN KEY ([credentials_idcredentials])
--    REFERENCES `mydb`.`credentials` ([idcredentials])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB;
--
--
---- -----------------------------------------------------
---- Table `mydb`.`staff`
---- -----------------------------------------------------
--CREATE TABLE mydb.staff (
--  [idstaff] INT NOT NULL,
--  [name] VARCHAR(45) NULL,
--  PRIMARY KEY ([idstaff]))
--;
--
--
---- -----------------------------------------------------
---- Table `mydb`.`availability`
---- -----------------------------------------------------
--CREATE TABLE mydb.availability (
--  [idavailability] INT NOT NULL,
--  [isAvailable] SMALLINT NULL,
--  [time] TIME(0) NULL,
--  [availabilitycol] VARCHAR(45) NULL,
--  [staff_idstaff] INT NOT NULL,
--  PRIMARY KEY ([idavailability])
--  CREATE INDEX [fk_availability_staff1_idx] ON mydb.availability ([staff_idstaff] ASC) VISIBLE,
--  CONSTRAINT [fk_availability_staff1]
--    FOREIGN KEY ([staff_idstaff])
--    REFERENCES `mydb`.`staff` ([idstaff])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB;
--
--
---- -----------------------------------------------------
---- Table `mydb`.`delivery`
---- -----------------------------------------------------
--CREATE TABLE mydb.delivery (
--  [iddelivery] INT NOT NULL,
--  [time] VARCHAR(45) NULL,
--  [delivery] TIME(0) NULL,
--  [staff_idstaff] INT NOT NULL,
--  PRIMARY KEY ([iddelivery])
--  CREATE INDEX [fk_delivery_staff1_idx] ON mydb.delivery ([staff_idstaff] ASC) VISIBLE,
--  CONSTRAINT [fk_delivery_staff1]
--    FOREIGN KEY ([staff_idstaff])
--    REFERENCES `mydb`.`staff` ([idstaff])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB;
--
--
---- -----------------------------------------------------
---- Table `mydb`.`order`
---- -----------------------------------------------------
--CREATE TABLE mydb.order (
--  [idorder] INT NOT NULL,
--  [status] VARCHAR(45) NULL,
--  [createdAt] VARCHAR(45) NULL,
--  [customers_idcustomers] INT NOT NULL,
--  [delivery_iddelivery] INT NOT NULL,
--  PRIMARY KEY ([idorder])
--  CREATE INDEX [fk_order_customers1_idx] ON mydb.order ([customers_idcustomers] ASC) VISIBLE,
--  INDEX `fk_order_delivery1_idx` ([delivery_iddelivery] ASC) VISIBLE,
--  CONSTRAINT [fk_order_customers1]
--    FOREIGN KEY ([customers_idcustomers])
--    REFERENCES `mydb`.`customers` ([idcustomers])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION,
--  CONSTRAINT [fk_order_delivery1]
--    FOREIGN KEY ([delivery_iddelivery])
--    REFERENCES `mydb`.`delivery` ([iddelivery])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB;
--
--
---- -----------------------------------------------------
---- Table `mydb`.`dishes_has_order`
---- -----------------------------------------------------
--CREATE TABLE mydb.dishes_has_order (
--  [dishes_iddishes] INT NOT NULL,
--  [order_idorder] INT NOT NULL,
--  PRIMARY KEY ([dishes_iddishes], [order_idorder])
--  CREATE INDEX [fk_dishes_has_order_order1_idx] ON mydb.dishes_has_order ([order_idorder] ASC) VISIBLE,
--  INDEX `fk_dishes_has_order_dishes_idx` ([dishes_iddishes] ASC) VISIBLE,
--  CONSTRAINT [fk_dishes_has_order_dishes]
--    FOREIGN KEY ([dishes_iddishes])
--    REFERENCES `mydb`.`dishes` ([iddishes])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION,
--  CONSTRAINT [fk_dishes_has_order_order1]
--    FOREIGN KEY ([order_idorder])
--    REFERENCES `mydb`.`order` ([idorder])
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB;
--
--
--/* SET SQL_MODE=@OLD_SQL_MODE; */
--/* SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS; */
--/* SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS; */



GO
