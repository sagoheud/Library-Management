CREATE DATABASE  IF NOT EXISTS `colabo` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `colabo`;

DROP TABLE IF EXISTS `NewStudent`;
CREATE TABLE `NewStudent` (
  `stuId` int NOT NULL AUTO_INCREMENT,
  `stuName` varchar(50) NOT NULL,
  `stuEnroll` varchar(45) NOT NULL,
  `studepart` varchar(45) NOT NULL,
  `stuSem` varchar(45) NOT NULL,
  `stuContact` int NOT NULL,
  `stuEmail` varchar(45) NOT NULL,
  PRIMARY KEY (`stuId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

INSERT INTO `NewStudent` VALUES (1,'감사해요k','a3e73efc','zxcv','1',1234,'zxcv@gmail.com'),(3,'호호호','c0ee5f10','부산폴리텍','1',123545566,'asdf@naver.com');