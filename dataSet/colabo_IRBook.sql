CREATE DATABASE  IF NOT EXISTS `colabo` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `colabo`;

DROP TABLE IF EXISTS `IRBook`;
CREATE TABLE `IRBook` (
  `id` int NOT NULL AUTO_INCREMENT,
  `std_enroll` varchar(45) DEFAULT NULL,
  `std_name` varchar(45) DEFAULT NULL,
  `std_depart` varchar(45) DEFAULT NULL,
  `std_sem` varchar(45) DEFAULT NULL,
  `std_contact` int DEFAULT NULL,
  `std_email` varchar(45) DEFAULT NULL,
  `book_name` varchar(45) DEFAULT NULL,
  `book_issue_date` varchar(45) DEFAULT NULL,
  `book_return_date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

INSERT INTO `IRBook` VALUES (1,'1234','zxcv','zxcv','1',1234,'zxcv@gmail.com','asdf','2023년 9월 21일 목요일','2023년 9월 21일 목요일'),(2,'a3e73efc','zxcv','zxcv','1',1234,'zxcv@gmail.com','asdf','2023년 9월 21일 목요일','2023년 9월 22일 금요일'),(3,'a3e73efc','zxcv','zxcv','1',1234,'zxcv@gmail.com','asdf','2023년 9월 21일 목요일','2023년 9월 22일 금요일'),(4,'a3e73efc','zxcv','zxcv','1',1234,'zxcv@gmail.com','qwer','2023년 9월 21일 목요일','2023년 9월 22일 금요일'),(5,'a3e73efc','zxcv','zxcv','1',1234,'zxcv@gmail.com','asdf','2023년 9월 21일 목요일','2023년 9월 22일 금요일'),(6,'a3e73efc','zxcv','zxcv','1',1234,'zxcv@gmail.com','qwer','2023년 9월 21일 목요일','2023년 9월 22일 금요일'),(7,'a3e73efc','감사해요k','zxcv','1',1234,'zxcv@gmail.com','돌맹이','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(8,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','돌맹이','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(9,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','돌맹이','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(10,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(11,'a3e73efc','감사해요k','zxcv','1',1234,'zxcv@gmail.com','돌맹이','2023년 9월 22일 금요일',NULL),(12,'a3e73efc','감사해요k','zxcv','1',1234,'zxcv@gmail.com','돌맹이','2023년 9월 22일 금요일',NULL),(13,'a3e73efc','감사해요k','zxcv','1',1234,'zxcv@gmail.com','돌맹이','2023년 9월 22일 금요일',NULL),(14,'a3e73efc','감사해요k','zxcv','1',1234,'zxcv@gmail.com','돌맹이','2023년 9월 22일 금요일',NULL),(15,'a3e73efc','감사해요k','zxcv','1',1234,'zxcv@gmail.com','돌맹이','2023년 9월 22일 금요일',NULL),(16,'a3e73efc','감사해요k','zxcv','1',1234,'zxcv@gmail.com','돌맹이','2023년 9월 22일 금요일',NULL),(17,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(18,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(19,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(20,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(21,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(22,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(23,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(24,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(25,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(26,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','가나다라','2023년 9월 22일 금요일','2023년 9월 22일 금요일'),(27,'c0ee5f10','호호호','부산폴리텍','1',123545566,'asdf@naver.com','돌맹이','2023년 9월 22일 금요일',NULL);

