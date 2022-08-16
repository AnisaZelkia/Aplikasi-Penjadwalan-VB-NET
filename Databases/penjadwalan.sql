-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 19, 2020 at 06:27 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `penjadwalan`
--

-- --------------------------------------------------------

--
-- Stand-in structure for view `jadwal`
-- (See below for the actual view)
--
CREATE TABLE `jadwal` (
`Prodi` varchar(100)
,`Kode_Matakuliah` varchar(10)
,`Matakuliah` varchar(40)
,`SKS` varchar(4)
,`Kelas` varchar(4)
,`Hari` varchar(20)
,`Mulai` time
,`Selesai` time
,`Ruangan` varchar(20)
,`Nama_Dosen` varchar(40)
);

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `user` varchar(20) NOT NULL,
  `pass` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`user`, `pass`) VALUES
('admin', 'root');

-- --------------------------------------------------------

--
-- Table structure for table `matkul`
--

CREATE TABLE `matkul` (
  `Kode_Matakuliah` varchar(10) NOT NULL,
  `Matakuliah` varchar(40) NOT NULL,
  `SKS` varchar(4) NOT NULL,
  `Nama_Dosen` varchar(40) NOT NULL,
  `Prodi` varchar(100) NOT NULL,
  `Semester` int(11) NOT NULL,
  `Kelas` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `matkul`
--

INSERT INTO `matkul` (`Kode_Matakuliah`, `Matakuliah`, `SKS`, `Nama_Dosen`, `Prodi`, `Semester`, `Kelas`) VALUES
('MI2-A000', 'Bahasa Inggris I', '4', 'Anisa Zelkia', 'Manajemen Informasi', 2, 'A'),
('MI2-B010', 'Pendidikan Agama Budha', '2', 'Ghazali', 'Manajemen Informasi', 2, 'B'),
('MI4-A000', 'Bahasa Inggris I', '4', 'Rokhana', 'Manajemen Informasi', 4, 'A'),
('MI4-G000', 'Bahasa Inggris I', '4', 'Nadia Stefani', 'Manajemen Informasi', 4, 'G'),
('RPL3-H050', 'Elektronika Analog', '4', 'Heri Saputra', 'Rekayasa Perangkat Lunak', 3, 'H'),
('RPL3-I012', 'Interaksi Manusia dan komputer', '4', 'Nova Febriana', 'Rekayasa Perangkat Lunak', 3, 'I'),
('RPL5-G090', 'Statistika', '4', 'Nova Febriana', 'Rekayasa Perangkat Lunak', 5, 'G'),
('SI1-A002', 'Matematika Komputer', '4', 'Anisa Zelkia', 'Sistem Informasi', 1, 'A');

-- --------------------------------------------------------

--
-- Table structure for table `pegawai`
--

CREATE TABLE `pegawai` (
  `NIDN` varchar(10) NOT NULL,
  `Nama_Dosen` varchar(40) NOT NULL,
  `Alamat` varchar(100) NOT NULL,
  `Telp` double NOT NULL,
  `Email` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pegawai`
--

INSERT INTO `pegawai` (`NIDN`, `Nama_Dosen`, `Alamat`, `Telp`, `Email`) VALUES
('181260', 'Nova Febriana', 'jln.Perintis Kemerdekaan No.9', 8210212122, 'nova@gmail.com'),
('181266', 'Rokhana', 'Jln.Pesona Bukit Magrifa No.6B, Bung', 85243001211, 'hana@gmail.com'),
('181269', 'Diana Isabella', 'jln.Baru Batu indah', 89566754432, 'dian@gmail.com'),
('181270', 'Anisa Zelkia', 'Jln.Perintis Kemerdekaan KM.7 Tamalanrea Indah', 85342556288, 'zelkiaanisa@gmail.com'),
('181274', 'Heri Saputra', 'jln.Merdeka Raya No.4', 80820182012, 'heri@gmail.com'),
('181276', 'Ghazali', 'jln.Pros Sebrang', 82182121213, 'cali@gmail.com'),
('181278', 'Nadia Stefani', 'jln.Pros Sebrang', 821212134432, 'nadia@gmail.com'),
('181279', 'Rian Andri', 'jln.Pros Makassar', 81233312137, 'rian@gmail.com'),
('181287', 'Rahmayanti', 'jln. Pahlawan No.02B', 82121233312, 'ahma@gmail.com'),
('181293', 'Chaesar', 'jln. Abu Bakar No.3', 85332311121, 'eshar@gmail.com'),
('181299', 'Andriani Stevi', 'jln.Poros Makassar', 85444326545, 'fani@gmail.com'),
('181311', 'Syahrul', 'jln. Gatot Subroto', 81212121334, 'arul@gmail.com'),
('181313', 'Rahma', 'jln.Jendral Sudirman NO.66', 82122121213, 'rahma@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `ruangan`
--

CREATE TABLE `ruangan` (
  `Ruangan` varchar(20) NOT NULL,
  `Kode_Matakuliah` varchar(40) NOT NULL,
  `Hari` varchar(20) NOT NULL,
  `Mulai` time NOT NULL,
  `Selesai` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ruangan`
--

INSERT INTO `ruangan` (`Ruangan`, `Kode_Matakuliah`, `Hari`, `Mulai`, `Selesai`) VALUES
('101', 'RPL3-I012', 'Senin', '13:40:00', '15:40:00'),
('112', 'MI2-A000', 'Selasa', '07:30:00', '09:30:00'),
('112', 'RPL3-H050', 'Senin', '15:40:00', '17:20:00'),
('112B', 'SI1-A002', 'Senin', '11:20:00', '12:40:00'),
('113', 'RPL5-G090', 'Jumat', '09:20:00', '11:40:00'),
('113', 'MI4-A000', 'Kamis', '11:20:00', '12:40:00'),
('114', 'MI2-B010', 'Jumat', '13:40:00', '15:40:00'),
('115', 'MI4-G000', 'Kamis', '11:20:00', '12:40:00');

-- --------------------------------------------------------

--
-- Structure for view `jadwal`
--
DROP TABLE IF EXISTS `jadwal`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `jadwal`  AS  select `matkul`.`Prodi` AS `Prodi`,`matkul`.`Kode_Matakuliah` AS `Kode_Matakuliah`,`matkul`.`Matakuliah` AS `Matakuliah`,`matkul`.`SKS` AS `SKS`,`matkul`.`Kelas` AS `Kelas`,`ruangan`.`Hari` AS `Hari`,`ruangan`.`Mulai` AS `Mulai`,`ruangan`.`Selesai` AS `Selesai`,`ruangan`.`Ruangan` AS `Ruangan`,`matkul`.`Nama_Dosen` AS `Nama_Dosen` from (`ruangan` join `matkul`) where `ruangan`.`Kode_Matakuliah` = `matkul`.`Kode_Matakuliah` ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`user`);

--
-- Indexes for table `matkul`
--
ALTER TABLE `matkul`
  ADD PRIMARY KEY (`Kode_Matakuliah`),
  ADD KEY `relasi2` (`Nama_Dosen`),
  ADD KEY `Kelas` (`Kelas`),
  ADD KEY `SKS` (`SKS`),
  ADD KEY `Prodi` (`Prodi`);

--
-- Indexes for table `pegawai`
--
ALTER TABLE `pegawai`
  ADD PRIMARY KEY (`NIDN`),
  ADD KEY `Nama_Dosen` (`Nama_Dosen`),
  ADD KEY `Nama_Dosen_2` (`Nama_Dosen`);

--
-- Indexes for table `ruangan`
--
ALTER TABLE `ruangan`
  ADD PRIMARY KEY (`Ruangan`,`Hari`,`Mulai`),
  ADD KEY `Ruangan` (`Ruangan`,`Hari`,`Mulai`),
  ADD KEY `Selesai` (`Selesai`),
  ADD KEY `matkul` (`Kode_Matakuliah`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `matkul`
--
ALTER TABLE `matkul`
  ADD CONSTRAINT `relasi2` FOREIGN KEY (`Nama_Dosen`) REFERENCES `pegawai` (`Nama_Dosen`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `ruangan`
--
ALTER TABLE `ruangan`
  ADD CONSTRAINT `matkul` FOREIGN KEY (`Kode_Matakuliah`) REFERENCES `matkul` (`Kode_Matakuliah`) ON DELETE CASCADE ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
