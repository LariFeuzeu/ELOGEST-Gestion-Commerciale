/*
SQLyog Professional v13.1.1 (64 bit)
MySQL - 10.4.8-MariaDB : Database - elogest
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`elogest` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `elogest`;

/*Table structure for table `achat` */

DROP TABLE IF EXISTS `achat`;

CREATE TABLE `achat` (
  `N_achat` int(11) NOT NULL AUTO_INCREMENT,
  `Idutili` int(11) NOT NULL,
  `Idclient` int(11) NOT NULL,
  `Date` date DEFAULT NULL,
  `MontantTotalAc` float DEFAULT NULL,
  `mtVerse` int(11) DEFAULT NULL,
  PRIMARY KEY (`N_achat`),
  KEY `FK_Association2` (`Idclient`),
  CONSTRAINT `FK_Association2` FOREIGN KEY (`Idclient`) REFERENCES `client` (`Idclient`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4;

/*Data for the table `achat` */

insert  into `achat`(`N_achat`,`Idutili`,`Idclient`,`Date`,`MontantTotalAc`,`mtVerse`) values 
(29,1,7,'2024-04-04',10100,NULL),
(30,4,1,'2024-08-14',500,0),
(31,4,1,'2024-08-14',1000,0);

/*Table structure for table `approvisionnement` */

DROP TABLE IF EXISTS `approvisionnement`;

CREATE TABLE `approvisionnement` (
  `N_appro` int(11) NOT NULL AUTO_INCREMENT,
  `Idutili` int(11) NOT NULL,
  `Idfourni` varchar(8) NOT NULL,
  `Date` date DEFAULT NULL,
  `MontantTotalAPP` float DEFAULT NULL,
  PRIMARY KEY (`N_appro`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4;

/*Data for the table `approvisionnement` */

insert  into `approvisionnement`(`N_appro`,`Idutili`,`Idfourni`,`Date`,`MontantTotalAPP`) values 
(2,1,'1','2024-04-04',1114000),
(3,1,'3','2024-04-04',123250),
(4,1,'3','2024-04-04',27050),
(5,1,'3','2024-04-04',56750),
(6,1,'3','2024-04-04',24350),
(7,1,'3','2024-04-04',27050),
(8,1,'3','2024-04-04',16525),
(9,1,'3','2024-04-04',4125),
(10,1,'3','2024-04-04',16500),
(11,1,'3','2024-04-04',4400),
(12,1,'3','2024-04-04',5525),
(13,1,'3','2024-04-04',28725);

/*Table structure for table `article` */

DROP TABLE IF EXISTS `article`;

CREATE TABLE `article` (
  `N_art` int(11) NOT NULL AUTO_INCREMENT,
  `NomA` varchar(35) DEFAULT NULL,
  `PrixU` float DEFAULT NULL,
  `QuantiteA` int(11) DEFAULT NULL,
  PRIMARY KEY (`N_art`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4;

/*Data for the table `article` */

insert  into `article`(`N_art`,`NomA`,`PrixU`,`QuantiteA`) values 
(2,'bobon',100,NULL),
(7,'brun 100g',10000,NULL),
(8,'naya 700g',500,NULL),
(9,'bonbon',1000,NULL),
(11,'Bonbon TOMTOM',25,NULL),
(12,'broli',1500,NULL),
(13,'Malta',500,NULL),
(14,'pain choco',500,NULL),
(15,'Haricot 100g',5000,NULL),
(16,'mango',1200,NULL),
(17,'Foure',1500,NULL);

/*Table structure for table `client` */

DROP TABLE IF EXISTS `client`;

CREATE TABLE `client` (
  `Idclient` int(11) NOT NULL AUTO_INCREMENT,
  `NomCL` varchar(35) DEFAULT NULL,
  `AdresseCL` varchar(25) DEFAULT NULL,
  `TelCL` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`Idclient`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;

/*Data for the table `client` */

insert  into `client`(`Idclient`,`NomCL`,`AdresseCL`,`TelCL`) values 
(1,'tamo','gni','6548225'),
(7,'nono','gmi','65472254'),
(10,NULL,NULL,NULL),
(11,'Feuzeu','Bastos','657647474'),
(12,'Feuzeu','Soa','67676767');

/*Table structure for table `fontionnalite` */

DROP TABLE IF EXISTS `fontionnalite`;

CREATE TABLE `fontionnalite` (
  `CodeFon` varchar(100) NOT NULL,
  PRIMARY KEY (`CodeFon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `fontionnalite` */

insert  into `fontionnalite`(`CodeFon`) values 
('0'),
('1'),
('2');

/*Table structure for table `fournisseur` */

DROP TABLE IF EXISTS `fournisseur`;

CREATE TABLE `fournisseur` (
  `Idfourni` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(35) DEFAULT NULL,
  `Prenom` varchar(35) DEFAULT NULL,
  `TelFOURNI` varchar(15) DEFAULT NULL,
  `Adresse` varchar(25) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Idfourni`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4;

/*Data for the table `fournisseur` */

insert  into `fournisseur`(`Idfourni`,`Nom`,`Prenom`,`TelFOURNI`,`Adresse`) values 
(1,'sosucam tt',NULL,'6584744','stinga'),
(2,'chococam',NULL,'6587412','dragage'),
(3,'djeuga',NULL,'654565251','nkodon'),
(25,NULL,NULL,NULL,NULL),
(26,NULL,NULL,NULL,NULL),
(27,NULL,NULL,NULL,NULL),
(28,NULL,NULL,NULL,NULL),
(29,NULL,NULL,NULL,NULL),
(30,NULL,NULL,NULL,NULL),
(31,NULL,NULL,NULL,NULL),
(32,NULL,NULL,NULL,NULL),
(33,NULL,NULL,NULL,NULL),
(34,NULL,NULL,NULL,NULL),
(35,NULL,NULL,NULL,NULL);

/*Table structure for table `fusion` */

DROP TABLE IF EXISTS `fusion`;

CREATE TABLE `fusion` (
  `Libelle` varchar(8) NOT NULL,
  `CodeFon` varchar(100) NOT NULL,
  `CodeFUSION` int(11) NOT NULL,
  PRIMARY KEY (`Libelle`,`CodeFon`,`CodeFUSION`),
  KEY `FK_Association7` (`CodeFon`),
  CONSTRAINT `FK_Association7` FOREIGN KEY (`CodeFon`) REFERENCES `fontionnalite` (`CodeFon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `fusion` */

/*Table structure for table `ligneachat` */

DROP TABLE IF EXISTS `ligneachat`;

CREATE TABLE `ligneachat` (
  `N_ligneA` int(11) NOT NULL AUTO_INCREMENT,
  `N_achat` int(11) DEFAULT NULL,
  `QuantiteLAC` int(11) DEFAULT NULL,
  `MontantTotalLac` float DEFAULT NULL,
  `n_art` int(11) NOT NULL,
  `prixU` float NOT NULL,
  PRIMARY KEY (`N_ligneA`),
  KEY `FK_Association4` (`N_achat`),
  CONSTRAINT `FK_Association4` FOREIGN KEY (`N_achat`) REFERENCES `achat` (`N_achat`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4;

/*Data for the table `ligneachat` */

insert  into `ligneachat`(`N_ligneA`,`N_achat`,`QuantiteLAC`,`MontantTotalLac`,`n_art`,`prixU`) values 
(35,29,1,10000,7,10000),
(36,29,1,100,2,100),
(37,30,1,500,8,500),
(38,31,1,1000,9,1000);

/*Table structure for table `ligneappro` */

DROP TABLE IF EXISTS `ligneappro`;

CREATE TABLE `ligneappro` (
  `N_ligne` int(11) NOT NULL AUTO_INCREMENT,
  `N_appro` int(11) DEFAULT NULL,
  `N_art` int(11) NOT NULL,
  `QuantiteAPP` int(11) DEFAULT NULL,
  `MontantAPP` float DEFAULT NULL,
  `DateP` date DEFAULT NULL,
  `dateperemtion` int(11) DEFAULT NULL,
  PRIMARY KEY (`N_ligne`),
  KEY `FK_Association5` (`N_appro`),
  KEY `FK_Association6` (`N_art`),
  CONSTRAINT `FK_Association5` FOREIGN KEY (`N_appro`) REFERENCES `approvisionnement` (`N_appro`),
  CONSTRAINT `FK_Association6` FOREIGN KEY (`N_art`) REFERENCES `article` (`N_art`)
) ENGINE=InnoDB AUTO_INCREMENT=94 DEFAULT CHARSET=utf8mb4;

/*Data for the table `ligneappro` */

insert  into `ligneappro`(`N_ligne`,`N_appro`,`N_art`,`QuantiteAPP`,`MontantAPP`,`DateP`,`dateperemtion`) values 
(24,2,2,100,10000,'0001-01-01',NULL),
(25,2,7,110,1100000,'0001-01-01',NULL),
(26,2,8,8,4000,'0001-01-01',NULL),
(27,3,9,17,17000,'0001-01-01',NULL),
(28,3,11,10,250,'0001-01-01',NULL),
(29,3,12,24,36000,'0001-01-01',NULL),
(30,3,13,10,5000,'0001-01-01',NULL),
(31,3,14,40,20000,'0001-01-01',NULL),
(32,3,15,9,45000,'0001-01-01',NULL),
(33,4,7,2,20000,'0001-01-01',NULL),
(34,4,11,2,50,'0001-01-01',NULL),
(35,4,15,1,5000,'0001-01-01',NULL),
(36,4,14,1,500,'0001-01-01',NULL),
(37,4,8,1,500,'0001-01-01',NULL),
(38,4,9,1,1000,'0001-01-01',NULL),
(39,5,7,3,30000,'0001-01-01',NULL),
(40,5,8,1,500,'0001-01-01',NULL),
(41,5,9,2,2000,'0001-01-01',NULL),
(42,5,11,2,50,'0001-01-01',NULL),
(43,5,12,4,6000,'0001-01-01',NULL),
(44,5,14,2,1000,'0001-01-01',NULL),
(45,5,15,2,10000,'0001-01-01',NULL),
(46,5,16,1,1200,'0001-01-01',NULL),
(47,5,17,4,6000,'0001-01-01',NULL),
(48,6,8,1,500,'0001-01-01',NULL),
(49,6,7,1,10000,'0001-01-01',NULL),
(50,6,2,1,100,'0001-01-01',NULL),
(51,6,9,1,1000,'0001-01-01',NULL),
(52,6,15,2,10000,'0001-01-01',NULL),
(53,6,16,1,1200,'0001-01-01',NULL),
(54,6,17,1,1500,'0001-01-01',NULL),
(55,6,11,2,50,'0001-01-01',NULL),
(56,7,13,1,500,'0001-01-01',NULL),
(57,7,11,2,50,'0001-01-01',NULL),
(58,7,8,1,500,'0001-01-01',NULL),
(59,7,7,2,20000,'0001-01-01',NULL),
(60,7,12,1,1500,'0001-01-01',NULL),
(61,7,14,1,500,'0001-01-01',NULL),
(62,7,17,2,3000,'0001-01-01',NULL),
(63,7,9,1,1000,'0001-01-01',NULL),
(64,8,13,1,500,'0001-01-01',NULL),
(65,8,11,1,25,'0001-01-01',NULL),
(66,8,8,2,1000,'0001-01-01',NULL),
(67,8,7,1,10000,'0001-01-01',NULL),
(68,8,12,1,1500,'0001-01-01',NULL),
(69,8,14,1,500,'0001-01-01',NULL),
(70,8,17,2,3000,'0001-01-01',NULL),
(71,9,2,1,100,'0001-01-01',NULL),
(72,9,8,1,500,'0001-01-01',NULL),
(73,9,11,1,25,'0001-01-01',NULL),
(74,9,13,1,500,'0001-01-01',NULL),
(75,9,17,2,3000,'0001-01-01',NULL),
(76,10,7,1,10000,'0001-01-01',NULL),
(77,10,9,1,1000,'0001-01-01',NULL),
(78,10,14,1,500,'0001-01-01',NULL),
(79,10,15,1,5000,'0001-01-01',NULL),
(80,11,13,1,500,'0001-01-01',NULL),
(81,11,16,2,2400,'0001-01-01',NULL),
(82,11,9,1,1000,'0001-01-01',NULL),
(83,11,14,1,500,'0001-01-01',NULL),
(84,12,15,1,5000,'0001-01-01',NULL),
(85,12,11,1,25,'0001-01-01',NULL),
(86,12,8,1,500,'0001-01-01',NULL),
(87,13,16,3,3600,'0001-01-01',NULL),
(88,13,14,2,1000,'0001-01-01',NULL),
(89,13,11,1,25,'0001-01-01',NULL),
(90,13,7,2,20000,'0001-01-01',NULL),
(91,13,2,1,100,'0001-01-01',NULL),
(92,13,8,2,1000,'0001-01-01',NULL),
(93,13,12,2,3000,'0001-01-01',NULL);

/*Table structure for table `profil` */

DROP TABLE IF EXISTS `profil`;

CREATE TABLE `profil` (
  `Libelle` varchar(15) NOT NULL,
  PRIMARY KEY (`Libelle`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `profil` */

insert  into `profil`(`Libelle`) values 
('A.ENTRETIEN'),
('CAISSIERE'),
('COMPTABLE'),
('DIRECTEUR'),
('G.STOCK'),
('RAYONNISTE'),
('RH'),
('SECURITE');

/*Table structure for table `utilisateur` */

DROP TABLE IF EXISTS `utilisateur`;

CREATE TABLE `utilisateur` (
  `Idutili` int(11) NOT NULL AUTO_INCREMENT,
  `Libelle` varchar(15) NOT NULL,
  `Nom` varchar(35) DEFAULT NULL,
  `Prenom` varchar(35) DEFAULT NULL,
  `TelUT` varchar(15) DEFAULT NULL,
  `MotdePasse` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`Idutili`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

/*Data for the table `utilisateur` */

insert  into `utilisateur`(`Idutili`,`Libelle`,`Nom`,`Prenom`,`TelUT`,`MotdePasse`) values 
(1,'DIRECTEUR','feuzeu','rrrr','657127559','0000'),
(2,'G.STOCK','Tamo',NULL,'698525852','2020'),
(3,'COMPTABLE','BOBO NDOMO',NULL,'697392018','bb08'),
(4,'caissiere','michel',NULL,'658522550','caisse2');

/*Table structure for table `historiqueachats` */

DROP TABLE IF EXISTS `historiqueachats`;

/*!50001 DROP VIEW IF EXISTS `historiqueachats` */;
/*!50001 DROP TABLE IF EXISTS `historiqueachats` */;

/*!50001 CREATE TABLE  `historiqueachats`(
 `N_achat` int(11) ,
 `Date` date ,
 `MontantTotalAc` float ,
 `N_art` int(11) ,
 `NomA` varchar(35) ,
 `Idclient` int(11) ,
 `NomCL` varchar(35) ,
 `AdresseCL` varchar(25) ,
 `TelCL` varchar(15) ,
 `prixU` float ,
 `QuantiteLAC` int(11) ,
 `MontantTotalLac` float ,
 `Nom` varchar(35) 
)*/;

/*Table structure for table `historiqueapppro` */

DROP TABLE IF EXISTS `historiqueapppro`;

/*!50001 DROP VIEW IF EXISTS `historiqueapppro` */;
/*!50001 DROP TABLE IF EXISTS `historiqueapppro` */;

/*!50001 CREATE TABLE  `historiqueapppro`(
 `N_appro` int(11) ,
 `Date` date ,
 `MontantTotalAPP` float ,
 `N_art` int(11) ,
 `NomA` varchar(35) ,
 `Idfourni` int(11) ,
 `NomFOURNISSEUR` varchar(35) ,
 `Adresse` varchar(25) ,
 `TelFOURNI` varchar(15) ,
 `prixU` float ,
 `QuantiteAPP` int(11) ,
 `MontantAPP` float ,
 `NomUTILISQTEUR` varchar(35) 
)*/;

/*View structure for view historiqueachats */

/*!50001 DROP TABLE IF EXISTS `historiqueachats` */;
/*!50001 DROP VIEW IF EXISTS `historiqueachats` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `historiqueachats` AS (select `achat`.`N_achat` AS `N_achat`,`achat`.`Date` AS `Date`,`achat`.`MontantTotalAc` AS `MontantTotalAc`,`article`.`N_art` AS `N_art`,`article`.`NomA` AS `NomA`,`client`.`Idclient` AS `Idclient`,`client`.`NomCL` AS `NomCL`,`client`.`AdresseCL` AS `AdresseCL`,`client`.`TelCL` AS `TelCL`,`ligneachat`.`prixU` AS `prixU`,`ligneachat`.`QuantiteLAC` AS `QuantiteLAC`,`ligneachat`.`MontantTotalLac` AS `MontantTotalLac`,`utilisateur`.`Nom` AS `Nom` from ((((`achat` join `article`) join `client`) join `ligneachat`) join `utilisateur`) where `achat`.`N_achat` = `ligneachat`.`N_achat` and `ligneachat`.`n_art` = `article`.`N_art` and `achat`.`Idclient` = `client`.`Idclient` and `utilisateur`.`Idutili` = `achat`.`Idutili`) */;

/*View structure for view historiqueapppro */

/*!50001 DROP TABLE IF EXISTS `historiqueapppro` */;
/*!50001 DROP VIEW IF EXISTS `historiqueapppro` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `historiqueapppro` AS (select `approvisionnement`.`N_appro` AS `N_appro`,`approvisionnement`.`Date` AS `Date`,`approvisionnement`.`MontantTotalAPP` AS `MontantTotalAPP`,`article`.`N_art` AS `N_art`,`article`.`NomA` AS `NomA`,`fournisseur`.`Idfourni` AS `Idfourni`,`fournisseur`.`Nom` AS `NomFOURNISSEUR`,`fournisseur`.`Adresse` AS `Adresse`,`fournisseur`.`TelFOURNI` AS `TelFOURNI`,`article`.`PrixU` AS `prixU`,`ligneappro`.`QuantiteAPP` AS `QuantiteAPP`,`ligneappro`.`MontantAPP` AS `MontantAPP`,`utilisateur`.`Nom` AS `NomUTILISQTEUR` from ((((`approvisionnement` join `article`) join `fournisseur`) join `ligneappro`) join `utilisateur`) where `approvisionnement`.`N_appro` = `ligneappro`.`N_appro` and `ligneappro`.`N_art` = `article`.`N_art` and `approvisionnement`.`Idfourni` = `fournisseur`.`Idfourni` and `utilisateur`.`Idutili` = `approvisionnement`.`Idutili`) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
