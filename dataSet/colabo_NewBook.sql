CREATE DATABASE  IF NOT EXISTS `colabo` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `colabo`;

DROP TABLE IF EXISTS `NewBook`;
CREATE TABLE `NewBook` (
  `bId` int NOT NULL DEFAULT '0',
  `bName` varchar(50) NOT NULL,
  `bAuthor` varchar(45) NOT NULL,
  `bPublic` varchar(45) NOT NULL,
  `bPDate` varchar(45) NOT NULL,
  `bPrice` decimal(10,0) NOT NULL,
  `bQty` int NOT NULL,
  PRIMARY KEY (`bId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

INSERT INTO `NewBook` VALUES (0,'돌맹이','가','나','2023년 9월 21일 목요일',10,1),(1,'가나다라','a','b','2023년 9월 19일 화요일',10000,-8);
