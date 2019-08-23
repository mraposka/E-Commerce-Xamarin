-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost
-- Üretim Zamanı: 23 Ağu 2019, 09:49:27
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
-- Tablo için tablo yapısı `products`
--

CREATE TABLE `products` (
  `p_id` int(11) NOT NULL,
  `p_name` varchar(255) CHARACTER SET utf8 NOT NULL,
  `p_cat` int(255) NOT NULL,
  `p_price` float NOT NULL DEFAULT '0',
  `p_imgsrc` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `p_descript` varchar(2555) COLLATE utf8_turkish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `products`
--

INSERT INTO `products` (`p_id`, `p_name`, `p_cat`, `p_price`, `p_imgsrc`, `p_descript`) VALUES
(1, 'DeğişimPiliç Tavuk Baget 1KG', 7, 12.5, 'tavuk.jpg', 'Tavuk Baget Tavuk Baget Tavuk Baget Tavuk Baget '),
(2, 'Pringles Classic 135gr', 8, 8.85, 'pringles.jpg', 'Pringles Classic Pringles Classic Pringles Classic '),
(4, 'Coca Cola 1Lt', 9, 5.5, 'cola.jpg', 'Coca Cola Coca Cola Coca Cola '),
(5, 'Nescafe Gold 250gr', 10, 14, 'nescafe.jpg', 'Nescafe Gold Nescafe Gold Nescafe Gold Nescafe Gold '),
(6, 'DeğişimPiliç Tavuk Baget 1KG', 7, 12.5, 'tavuk.jpg', 'Tavuk Baget Tavuk Baget Tavuk Baget Tavuk Baget '),
(7, 'Pringles Classic 135gr', 8, 8.85, 'pringles.jpg', 'Pringles Classic Pringles Classic Pringles Classic '),
(8, 'Coca Cola 1Lt', 9, 5.5, 'cola.jpg', 'Coca Cola Coca Cola Coca Cola '),
(9, 'Nescafe Gold 250gr', 10, 14, 'nescafe.jpg', 'Nescafe Gold Nescafe Gold Nescafe Gold Nescafe Gold '),
(10, 'DeğişimPiliç Tavuk Baget 1KG', 7, 12.5, 'tavuk.jpg', 'Tavuk Baget Tavuk Baget Tavuk Baget Tavuk Baget '),
(11, 'Pringles Classic 135gr', 8, 8.85, 'pringles.jpg', 'Pringles Classic Pringles Classic Pringles Classic '),
(12, 'Coca Cola 1Lt', 9, 5.5, 'cola.jpg', 'Coca Cola Coca Cola Coca Cola '),
(14, 'Nescafe Gold 250gr', 10, 14, 'nescafe.jpg', 'Nescafe Gold Nescafe Gold Nescafe Gold Nescafe Gold '),
(15, 'DeğişimPiliç Tavuk Baget 1KG', 7, 12.5, 'tavuk.jpg', 'Tavuk Baget Tavuk Baget Tavuk Baget Tavuk Baget '),
(16, 'Pringles Classic 135gr', 8, 8.85, 'pringles.jpg', 'Pringles Classic Pringles Classic Pringles Classic '),
(17, 'Coca Cola 1Lt', 9, 5.5, 'cola.jpg', 'Coca Cola Coca Cola Coca Cola ');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`p_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `products`
--
ALTER TABLE `products`
  MODIFY `p_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
