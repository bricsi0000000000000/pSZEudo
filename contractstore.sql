-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Jan 31. 10:41
-- Kiszolgáló verziója: 10.4.22-MariaDB
-- PHP verzió: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `contractstore`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `people`
--

CREATE TABLE `people` (
  `ID` int(11) NOT NULL,
  `WornName` longtext NOT NULL,
  `NamePrefix` longtext NOT NULL,
  `LastName` longtext NOT NULL,
  `FirstName` longtext NOT NULL,
  `BirthName` longtext NOT NULL,
  `MotherName` longtext NOT NULL,
  `Nationality` longtext NOT NULL,
  `BirthPlace` longtext NOT NULL,
  `BirthDate` datetime(6) NOT NULL,
  `Gender` longtext NOT NULL,
  `PhoneNumber` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `PostCode` int(11) NOT NULL,
  `City` longtext NOT NULL,
  `Street` longtext NOT NULL,
  `HouseNumber` int(11) NOT NULL,
  `PersonalID` int(11) NOT NULL,
  `TaxNumber` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `people`
--

INSERT INTO `people` (`ID`, `WornName`, `NamePrefix`, `LastName`, `FirstName`, `BirthName`, `MotherName`, `Nationality`, `BirthPlace`, `BirthDate`, `Gender`, `PhoneNumber`, `Email`, `PostCode`, `City`, `Street`, `HouseNumber`, `PersonalID`, `TaxNumber`) VALUES
(1, 'Bálint', '', 'Bálint', 'Valamilyen', 'Bálint', 'Virág', 'magyar', 'Győr', '1998-01-02 00:00:00.000000', 'Férfi', '0620123456', 'balint@gmail.com', 1234, 'Győr', 'Nagy', 2, 4, 213213),
(2, 'Ádám', 'Dr.', 'Ádám', 'Valamekkora', 'Ádám', 'Evelin', 'német', 'Győr', '1996-02-04 00:00:00.000000', 'Férfi', '0620789123', 'adam@gmail.com', 2345, 'Tiszalök', 'Kis', 3, 6, 543453),
(3, 'Zsolt', '', 'Zsolt', 'Kovács', 'Zsolt', 'Lilla', 'magyar', 'Budapest', '1993-05-08 00:00:00.000000', 'Férfi', '0620123456', 'zsolt@gmail.com', 1234, 'Győr', 'Kovács', 26, 4, 213213),
(4, '', 'Ifj.', 'Benedek', 'Zsolt', '', 'Anna Mária', 'Magyar', 'Brassó', '1978-01-28 00:00:00.000000', 'Férfi', '+36205261456', 'benedek-zsolt@valami.com', 9184, 'Mosonszentmiklós', 'József Attila u.', 1, 0, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `PasswordHash` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`ID`, `Name`, `Email`, `PasswordHash`) VALUES
(1, 'Ricsi', 'ricsi@bolya.eu', 'NJSAj6vUdXexj54gYy+4DYmLpK1JNIno2W6P14JwMtccurNK'),
(2, 'kekszi', 'kekszi@gmail.com', 'u3bqCr8woUN6j3HS4qCobe1NE/EFR4GdY8m+uXY579blptAT');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vehicles`
--

CREATE TABLE `vehicles` (
  `ID` int(11) NOT NULL,
  `VehicleType` longtext NOT NULL,
  `Manufacturer` longtext NOT NULL,
  `ManuType` longtext NOT NULL,
  `ProductYear` int(11) NOT NULL,
  `Category` longtext NOT NULL,
  `ValidityBegin` datetime(6) NOT NULL,
  `Mass` int(11) NOT NULL,
  `TransportablePeople` int(11) NOT NULL,
  `NumberOfSeats` int(11) NOT NULL,
  `NumberOfStandingPlaces` int(11) NOT NULL,
  `RateOfPerformance` double NOT NULL,
  `TractionData` longtext NOT NULL,
  `TechnicalValidity` datetime(6) NOT NULL,
  `RegisterDate` datetime(6) NOT NULL,
  `PlacedInTrafficDate` datetime(6) NOT NULL,
  `ChassisNumber` longtext NOT NULL,
  `EngineNumber` longtext NOT NULL,
  `Capacity` double NOT NULL,
  `Performance` double NOT NULL,
  `Propellant` longtext NOT NULL,
  `EnvironmentProtectionClass` longtext NOT NULL,
  `GearBoxType` longtext NOT NULL,
  `EngineData` longtext NOT NULL,
  `Color` longtext NOT NULL,
  `LicencePlate` longtext NOT NULL,
  `ProhibitionOfSelling` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `vehicles`
--

INSERT INTO `vehicles` (`ID`, `VehicleType`, `Manufacturer`, `ManuType`, `ProductYear`, `Category`, `ValidityBegin`, `Mass`, `TransportablePeople`, `NumberOfSeats`, `NumberOfStandingPlaces`, `RateOfPerformance`, `TractionData`, `TechnicalValidity`, `RegisterDate`, `PlacedInTrafficDate`, `ChassisNumber`, `EngineNumber`, `Capacity`, `Performance`, `Propellant`, `EnvironmentProtectionClass`, `GearBoxType`, `EngineData`, `Color`, `LicencePlate`, `ProhibitionOfSelling`) VALUES
(1, 'BMW 1', 'bmw', 'type1', 2014, 'category1', '2021-02-02 00:00:00.000000', 1000, 5, 4, 0, 98.9, 'good', '2222-04-06 00:00:00.000000', '2016-03-07 00:00:00.000000', '2018-04-09 00:00:00.000000', 'lx123456', '123456678', 100, 1200, 'no', 'class1', 'automatic', 'abc122', 'kék', 'abc123', 'yes'),
(2, 'audi 1', 'audi', 'type2', 2014, 'category2', '2021-02-02 00:00:00.000000', 1000, 5, 4, 0, 98.9, 'good', '2222-04-06 00:00:00.000000', '2016-03-07 00:00:00.000000', '2018-04-09 00:00:00.000000', 'lr123456', '123456678', 100, 1200, 'no', 'class2', 'manual', 'abc134', 'piros', 'abc444', 'yes'),
(3, 'w12', 'mercedes', 'type3', 2014, 'category3', '2021-02-02 00:00:00.000000', 1000, 5, 4, 0, 98.9, 'good', '2222-04-06 00:00:00.000000', '2016-03-07 00:00:00.000000', '2018-04-09 00:00:00.000000', 'lj123456', '123456678', 100, 1200, 'no', 'class3', 'fél automata', 'abc552', 'narancs', 'abc555', 'yes');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20210311144241_AddPeopleDatabase', '3.1.11'),
('20210311155442_UpdateDatabaseNameToContractStore', '3.1.11'),
('20210328083800_AddUsers', '3.1.11'),
('20210328084537_UpdateUser', '3.1.11'),
('20210420145952_AddVehicles', '3.1.11');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `people`
--
ALTER TABLE `people`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `vehicles`
--
ALTER TABLE `vehicles`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `people`
--
ALTER TABLE `people`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `vehicles`
--
ALTER TABLE `vehicles`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
