CREATE DATABASE  IF NOT EXISTS `bd_idrug` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bd_idrug`;
-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: bd_idrug
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetRoleClaims_AspNetRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetUserClaims_AspNetUsers_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `FK_AspNetUserLogins_AspNetUsers_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('b56ab118-cfbb-4b36-8fad-605aa97c7ab4','r@gamil.com','R@GAMIL.COM','r@gamil.com','R@GAMIL.COM',_binary '','AQAAAAEAACcQAAAAEKUZO8eIjwIVqQBZw505R060JilBPPsJ6rYqf8PIsbiDyfenTm+JdzecpCLel9P6NA==','PJ43VZPNDGSXBCFF4FPDRVW6BKUXSOST','7f40841f-46e2-4a76-9d1c-e19e3ba95d24',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('bd5fccfd-539b-4d4e-9ff7-e20a7fc2b27f','rafael@gmail.com','RAFAEL@GMAIL.COM','rafael@gmail.com','RAFAEL@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEBOtClC7sq+HgV/cRPiFXwL0bORK7g02YU6pCkq44H2dGGXSGleTfH3XR1tdYxsTRw==','JVUYQTVO3QV73Y2QDPYGIEH37EBYRX6T','3fa993a9-c807-4127-a717-30af4f3f5b0f',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoriamedicamento`
--

DROP TABLE IF EXISTS `categoriamedicamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoriamedicamento` (
  `idCategoriaMedicamento` int unsigned NOT NULL AUTO_INCREMENT,
  `nomeCategoria` varchar(60) NOT NULL,
  PRIMARY KEY (`idCategoriaMedicamento`),
  UNIQUE KEY `idCategoriaMedicamento_UNIQUE` (`idCategoriaMedicamento`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoriamedicamento`
--

LOCK TABLES `categoriamedicamento` WRITE;
/*!40000 ALTER TABLE `categoriamedicamento` DISABLE KEYS */;
INSERT INTO `categoriamedicamento` VALUES (1,'Infantil'),(2,'Genérico');
/*!40000 ALTER TABLE `categoriamedicamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `farmacia`
--

DROP TABLE IF EXISTS `farmacia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `farmacia` (
  `idFarmacia` int unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(60) NOT NULL,
  `cnpj` varchar(14) NOT NULL,
  `telefone` varchar(13) NOT NULL,
  `cep` varchar(6) NOT NULL,
  `logradouro` varchar(60) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `cidade` varchar(25) NOT NULL,
  `bairro` varchar(25) NOT NULL,
  `status` enum('ATIVA','INATIVA') NOT NULL DEFAULT 'INATIVA',
  PRIMARY KEY (`idFarmacia`),
  UNIQUE KEY `idFarmacia_UNIQUE` (`idFarmacia`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `farmacia`
--

LOCK TABLES `farmacia` WRITE;
/*!40000 ALTER TABLE `farmacia` DISABLE KEYS */;
/*!40000 ALTER TABLE `farmacia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicamento`
--

DROP TABLE IF EXISTS `medicamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicamento` (
  `idMedicamento` int NOT NULL AUTO_INCREMENT,
  `idCategoriaMedicamento` int unsigned NOT NULL,
  `codigoBarras` varchar(20) NOT NULL,
  `nome` varchar(60) NOT NULL,
  `fabricante` varchar(40) NOT NULL,
  PRIMARY KEY (`idMedicamento`),
  UNIQUE KEY `idMedicamento_UNIQUE` (`idMedicamento`),
  KEY `fk_Medicamento_CategoriaMedicamento1_idx` (`idCategoriaMedicamento`),
  CONSTRAINT `idCategoriaMedicamento` FOREIGN KEY (`idCategoriaMedicamento`) REFERENCES `categoriamedicamento` (`idCategoriaMedicamento`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicamento`
--

LOCK TABLES `medicamento` WRITE;
/*!40000 ALTER TABLE `medicamento` DISABLE KEYS */;
INSERT INTO `medicamento` VALUES (1,2,'123','Minoxidil','SANDOZ');
/*!40000 ALTER TABLE `medicamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicamentodisponivel`
--

DROP TABLE IF EXISTS `medicamentodisponivel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicamentodisponivel` (
  `idDisponibilizacaoMedicamento` int unsigned NOT NULL AUTO_INCREMENT,
  `idMedicamento` int NOT NULL,
  `idFarmacia` int unsigned NOT NULL,
  `dataInicioDisponibilizacao` datetime NOT NULL,
  `dataFimDisponibilizacao` datetime NOT NULL,
  `quantidadeDisponibilizacao` int NOT NULL,
  `lote` varchar(45) NOT NULL,
  `quantidade` varchar(45) NOT NULL,
  `validadeMes` varchar(10) NOT NULL,
  `validadeAno` int NOT NULL,
  `statusMedicamento` enum('RESERVADO','DISPONIVEL','INDISPONIVEL') NOT NULL DEFAULT 'DISPONIVEL',
  `dataVencimento` datetime NOT NULL,
  `quantidadeReservada` int NOT NULL,
  `quantidadeEntregue` int NOT NULL,
  `quantidadeDisponivel` int NOT NULL,
  `imagem` blob,
  PRIMARY KEY (`idDisponibilizacaoMedicamento`),
  UNIQUE KEY `idDisponibilizacaoMedicamento_UNIQUE` (`idDisponibilizacaoMedicamento`),
  KEY `fk_TB_FARMACIA_has_TB_MEDICAMENTO_TB_MEDICAMENTO1_idx` (`idMedicamento`),
  KEY `fk_MedicamentoDisponivel_Farmacia1_idx` (`idFarmacia`),
  CONSTRAINT `fk_MedicamentoDisponivel_Farmacia1` FOREIGN KEY (`idFarmacia`) REFERENCES `farmacia` (`idFarmacia`),
  CONSTRAINT `idMedicamento` FOREIGN KEY (`idMedicamento`) REFERENCES `medicamento` (`idMedicamento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicamentodisponivel`
--

LOCK TABLES `medicamentodisponivel` WRITE;
/*!40000 ALTER TABLE `medicamentodisponivel` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicamentodisponivel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitacaomedicamento`
--

DROP TABLE IF EXISTS `solicitacaomedicamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `solicitacaomedicamento` (
  `idSolicitacaoMedicamento` int NOT NULL AUTO_INCREMENT,
  `idDisponibilizacaoMedicamento` int unsigned NOT NULL,
  `idUsuario` int unsigned NOT NULL,
  `quantidadeSolicitada` int NOT NULL,
  `statusSolicitacaoMedicamento` enum('CONCLUIDA','EM ANDAMENTO','CANCELADA') NOT NULL DEFAULT 'EM ANDAMENTO',
  `quantidadeEntregue` int NOT NULL,
  `prazoEntrega` datetime NOT NULL,
  `dataSolicitacao` datetime NOT NULL,
  `dataEntrega` datetime NOT NULL,
  `cpf` varchar(12) NOT NULL,
  PRIMARY KEY (`idSolicitacaoMedicamento`),
  UNIQUE KEY `idSolicitacaoMedicamento_UNIQUE` (`idSolicitacaoMedicamento`),
  KEY `fk_tbDisponibilizaMedicamento_has_tbUsuario_tbUsuario1_idx` (`idUsuario`),
  KEY `fk_tbDisponibilizaMedicamento_has_tbUsuario_tbDisponibiliza_idx` (`idDisponibilizacaoMedicamento`),
  CONSTRAINT `idDisponibilizacaoMedicamento` FOREIGN KEY (`idDisponibilizacaoMedicamento`) REFERENCES `medicamentodisponivel` (`idDisponibilizacaoMedicamento`),
  CONSTRAINT `idUsuario` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`idUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitacaomedicamento`
--

LOCK TABLES `solicitacaomedicamento` WRITE;
/*!40000 ALTER TABLE `solicitacaomedicamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `solicitacaomedicamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `idUsuario` int unsigned NOT NULL AUTO_INCREMENT,
  `idFarmacia` int unsigned NOT NULL,
  `tipoUsuario` enum('ADMINISTRADOR','FARMACEUTICO','SOLICITANTE') NOT NULL DEFAULT 'SOLICITANTE',
  `nome` varchar(45) NOT NULL,
  `cpf` varchar(12) NOT NULL,
  `telefone` varchar(13) DEFAULT NULL,
  `sexo` varchar(1) NOT NULL,
  `logradouro` varchar(60) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `cidade` varchar(25) NOT NULL,
  `bairro` varchar(25) NOT NULL,
  `email` varchar(30) NOT NULL,
  `senha` varchar(12) NOT NULL,
  PRIMARY KEY (`idUsuario`),
  UNIQUE KEY `idUsuario_UNIQUE` (`idUsuario`),
  KEY `fk_TB_USUARIO_TB_FARMACIA1_idx` (`idFarmacia`) /*!80000 INVISIBLE */,
  CONSTRAINT `idFarmacia` FOREIGN KEY (`idFarmacia`) REFERENCES `farmacia` (`idFarmacia`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'bd_idrug'
--

--
-- Dumping routines for database 'bd_idrug'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-13 10:20:57
