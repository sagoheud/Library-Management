CREATE DATABASE  IF NOT EXISTS `colabo` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `colabo`;

DROP TABLE IF EXISTS `Login`;
CREATE TABLE `Login` (
  `username` varchar(50) NOT NULL,
  `pass` varchar(255) NOT NULL,
  `card` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;


INSERT INTO `Login` VALUES ('1234','1234',NULL);