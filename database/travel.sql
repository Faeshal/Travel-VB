-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.3.16-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for travel
CREATE DATABASE IF NOT EXISTS `travel` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `travel`;

-- Dumping structure for table travel.login
CREATE TABLE IF NOT EXISTS `login` (
  `user` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table travel.login: ~2 rows (approximately)
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` (`user`, `password`) VALUES
	('admin', 'admin'),
	('fae', 'fae');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;

-- Dumping structure for table travel.travel
CREATE TABLE IF NOT EXISTS `travel` (
  `noktp` varchar(50) NOT NULL DEFAULT '',
  `nama` varchar(50) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  `postcode` varchar(50) DEFAULT NULL,
  `phone` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `departure` varchar(50) DEFAULT NULL,
  `destination` varchar(50) DEFAULT NULL,
  `accomodation` varchar(50) DEFAULT NULL,
  `airlines` varchar(50) DEFAULT NULL,
  `ket` varchar(50) DEFAULT NULL,
  `flight` date DEFAULT NULL,
  `class` varchar(50) DEFAULT NULL,
  `ticket` varchar(50) DEFAULT NULL,
  `classify` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table travel.travel: ~11 rows (approximately)
/*!40000 ALTER TABLE `travel` DISABLE KEYS */;
INSERT INTO `travel` (`noktp`, `nama`, `address`, `postcode`, `phone`, `email`, `departure`, `destination`, `accomodation`, `airlines`, `ket`, `flight`, `class`, `ticket`, `classify`) VALUES
	('714', 'Khalid', 'serang', '456', '087547878963', 'zaid@mail.com', 'Husein Sastranegara - BDO', 'Jeddah , Saudi Arabia', 'Double', 'FLY EMIRATES', '-', '2019-07-23', 'Economy', 'Return', 'Child'),
	('191', 'Abdurahman', 'bandung', '193', '085695412365', 'abdullah@mail.com', 'Adi Sucipto - JOG', 'Dubai, UAE', 'Double', 'GARUDA INDONESIA', '-', '2019-07-23', 'Economy', 'Return', 'Child'),
	('214', 'Anas', 'Manokwari', '693', '085414142536', 'anas@gmail.com', 'Juanda - SUB', 'Medina, Saudi Arabia', 'Extra', 'SAUDIA', '-', '2019-07-27', 'First Class', 'Return', 'Adult'),
	('999', 'abdullah', 'serang', '159', '085694569885', 'fahad@Mail.com', 'Husein Sastranegara - BDO', 'Medina, Saudi Arabia', 'Extra', 'FLY EMIRATES', '-', '2019-07-27', 'Standard', 'Return', 'Dissability'),
	('456', 'candra', 'medan', '454', '084758585693', 'can@mail.com', 'Ngurah Rai - DPS', 'Medina, Saudi Arabia', 'Extra', 'FLY EMIRATES', '-', '2019-07-25', 'First Class', 'Single', 'Child'),
	('888', 'zainal', 'semarang', '789', '081365478996', 'zainal@yahoo.com', 'Juanda - SUB', 'Medina, Saudi Arabia', 'Extra', 'FLY EMIRATES', '-', '2019-07-27', 'Economy', 'Return', 'Dissability'),
	('777', 'saima', 'jogjakarta', '456', '085693757554', 'saima@mail.com', 'Adi Sucipto - JOG', 'Medina, Saudi Arabia', 'Extra', 'GARUDA INDONESIA', '-', '2019-07-27', 'Standard', 'Return', 'Dissability'),
	('555', 'hasan', 'jakarta', '789', '085412563227', 'hasan@yahoo.com', 'Adi Sucipto - JOG', 'Medina, Saudi Arabia', 'Extra', 'FLY EMIRATES', '-', '2019-08-08', 'Standard', 'Single', 'Dissability'),
	('966', 'rafi', 'surabaya', '456', '084563203255', 'rafi@mail.com', 'Juanda - SUB', 'Dubai, UAE', 'Extra', 'FLY EMIRATES', '-', '2019-08-08', 'Standard', 'Return', 'Dissability'),
	('169', 'Husen', 'Jakarta', '789', '085693656665', 'hus@mail.com', 'Juanda - SUB', 'Cairo,Egypt', 'Extra', 'SAUDIA', '-', '2019-08-02', 'Standard', 'Single', 'Dissability'),
	('363', 'Abdulaziz', 'Jakarta', '456', '085632122565', 'aziz@mail.com', 'Husein Sastranegara - BDO', 'Dubai, UAE', 'Single', 'FLY EMIRATES', '-', '2019-08-06', 'First Class', 'Return', 'Dissability');
/*!40000 ALTER TABLE `travel` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
