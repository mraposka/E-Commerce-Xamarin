-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost
-- Üretim Zamanı: 23 Ağu 2019, 09:49:39
-- Sunucu sürümü: 5.5.56-MariaDB
-- PHP Sürümü: 5.6.37

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `admin_aposkadb`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `siparisler`
--

CREATE TABLE `siparisler` (
  `s_id` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `adresBasligi` varchar(255) NOT NULL,
  `adres` varchar(255) NOT NULL,
  `sehir` varchar(255) NOT NULL,
  `AdSoyad` varchar(255) NOT NULL,
  `sonKullanma` varchar(255) NOT NULL,
  `cvc` varchar(255) NOT NULL,
  `urunler_id` varchar(255) NOT NULL,
  `kartNo` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `siparisler`
--

INSERT INTO `siparisler` (`s_id`, `email`, `adresBasligi`, `adres`, `sehir`, `AdSoyad`, `sonKullanma`, `cvc`, `urunler_id`, `kartNo`) VALUES
(1, 'q', 'qwe', 'zxc', 'dfgh', 'cvbn', 'sfg', 'cgb', '1.2.3.4.5', 'rty'),
(2, 'w', 's', 's', 'a', 's', '4', '4', '1.', '4'),
(3, 'q', 's', 'c', 'f', 'd', '5', '6', '5.', '4');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `siparisler`
--
ALTER TABLE `siparisler`
  ADD PRIMARY KEY (`s_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `siparisler`
--
ALTER TABLE `siparisler`
  MODIFY `s_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
