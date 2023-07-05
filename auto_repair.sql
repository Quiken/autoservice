-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Июн 05 2023 г., 17:33
-- Версия сервера: 5.7.24
-- Версия PHP: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `auto_repair`
--

DELIMITER $$
--
-- Процедуры
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `summa` ()  Select w.`Код заказа`, y.ФИО as `ФИО клиента`, u.Марка, u.`Регистрационный знак`, q.`Вид работы`, e.`Наименование оборудования`, r.`Наименование запчасти`, t.`ФИО` as `ФИО сотрудника`, w.`Дата поступления`, CEILING((r.Стоимость + q.Стоимость) - (r.Стоимость + q.Стоимость) / 100 * i.Скидка)  as `Стоимость работы` FROM `ordering_services` as w JOIN `client` as y ON y.`Код клиента` = w.`Код клиента` JOIN `auto` as u ON u.`Код автомобиля` = w.`Код автомобиля` JOIN `rabota` as q ON q.`Код работы` = w.`Код работы` JOIN oborud as e ON e.`Код оборудования` = w.`Код оборудования` JOIN zapt as r ON r.`Код запчасти` = w.`Код запчасти` JOIN employee as t ON t.`Код сотрудника` = w.`Код сотрудника` JOIN discont as i ON i.`Код карты` = y.`Код клиента` ORDER BY w.`Код заказа` ASC$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `summa_obsh` ()  NO SQL
Select SUM(CEILING((r.Стоимость + q.Стоимость) - (r.Стоимость + q.Стоимость) / 100 * i.Скидка))  as `Общая сумма` FROM `ordering_services` as w JOIN `client` as y ON y.`Код клиента` = w.`Код клиента` JOIN `auto` as u ON u.`Код автомобиля` = w.`Код автомобиля` JOIN `rabota` as q ON q.`Код работы` = w.`Код работы` JOIN oborud as e ON e.`Код оборудования` = w.`Код оборудования` JOIN zapt as r ON r.`Код запчасти` = w.`Код запчасти` JOIN employee as t ON t.`Код сотрудника` = w.`Код сотрудника` JOIN discont as i ON i.`Код карты` = y.`Код клиента`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `summa_sotrudnik` ()  NO SQL
Select t.`ФИО` as `ФИО сотрудника`, q.`Вид работы`, SUM(CEILING((r.Стоимость + q.Стоимость) - (r.Стоимость + q.Стоимость) / 100 * i.Скидка))  as `Стоимость работы`, COUNT(w.`Код работы`) as `Количество работ`, MONTH(w.`Дата поступления`) as `Номер месяца` FROM `ordering_services` as w JOIN `client` as y ON y.`Код клиента` = w.`Код клиента` JOIN `auto` as u ON u.`Код автомобиля` = w.`Код автомобиля` JOIN `rabota` as q ON q.`Код работы` = w.`Код работы` JOIN oborud as e ON e.`Код оборудования` = w.`Код оборудования` JOIN zapt as r ON r.`Код запчасти` = w.`Код запчасти` JOIN employee as t ON t.`Код сотрудника` = w.`Код сотрудника` JOIN discont as i ON i.`Код карты` = y.`Код клиента` GROUP BY t.`ФИО`, w.`Код работы`, q.`Вид работы`, MONTH(w.`Дата поступления`)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `summa_sotrudnik_mesac` ()  NO SQL
Select t.`ФИО` as `ФИО сотрудника`, SUM(CEILING((r.Стоимость + q.Стоимость) - (r.Стоимость + q.Стоимость) / 100 * i.Скидка))  as `Стоимость работы`, MONTH(w.`Дата поступления`) as `Номер месяца` FROM `ordering_services` as w JOIN `client` as y ON y.`Код клиента` = w.`Код клиента` JOIN `auto` as u ON u.`Код автомобиля` = w.`Код автомобиля` JOIN `rabota` as q ON q.`Код работы` = w.`Код работы` JOIN oborud as e ON e.`Код оборудования` = w.`Код оборудования` JOIN zapt as r ON r.`Код запчасти` = w.`Код запчасти` JOIN employee as t ON t.`Код сотрудника` = w.`Код сотрудника` JOIN discont as i ON i.`Код карты` = y.`Код клиента` GROUP BY t.`ФИО`, MONTH(w.`Дата поступления`)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `zarplata` ()  NO SQL
Select t.`ФИО` as `ФИО сотрудника`, 
SUM(CEILING((r.Стоимость + q.Стоимость) - (r.Стоимость + q.Стоимость) / 100 * i.Скидка))  as `Стоимость работы`, MONTH(w.`Дата поступления`) as `Номер месяца`,
CASE 
WHEN SUM(CEILING((r.Стоимость + q.Стоимость) - (r.Стоимость + q.Стоимость) / 100 * i.Скидка)) > 5000 THEN '10000'
WHEN SUM(CEILING((r.Стоимость + q.Стоимость) - (r.Стоимость + q.Стоимость) / 100 * i.Скидка)) <= 5000 THEN '5000'
End as `Зарплата`
FROM `ordering_services` as w 
JOIN `client` as y ON y.`Код клиента` = w.`Код клиента` 
JOIN `auto` as u ON u.`Код автомобиля` = w.`Код автомобиля` 
JOIN `rabota` as q ON q.`Код работы` = w.`Код работы` 
JOIN oborud as e ON e.`Код оборудования` = w.`Код оборудования` 
JOIN zapt as r ON r.`Код запчасти` = w.`Код запчасти` 
JOIN employee as t ON t.`Код сотрудника` = w.`Код сотрудника` 
JOIN discont as i ON i.`Код карты` = y.`Код клиента` 
GROUP BY t.`ФИО`, MONTH(w.`Дата поступления`)$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `auto`
--

CREATE TABLE `auto` (
  `Код автомобиля` int(10) UNSIGNED NOT NULL,
  `Марка` varchar(50) NOT NULL,
  `Регистрационный знак` varchar(50) NOT NULL,
  `Год выпуска` int(11) NOT NULL,
  `Технический паспорт` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `auto`
--

INSERT INTO `auto` (`Код автомобиля`, `Марка`, `Регистрационный знак`, `Год выпуска`, `Технический паспорт`) VALUES
(1, 'BMW M3', 'А244ОС35', 2018, '88ХР 985243'),
(2, 'Ford Explorer', 'Р444КК77', 2015, '25ТУ 589180'),
(3, 'Citroen C2', 'Е564ЕС72', 2009, '80ЕО 696511'),
(4, 'Ford Focus Active', 'Т141КР09', 2020, '43АВ 879711'),
(5, 'Daewoo Leganza', 'Р866МА62', 1999, '23НТ 882770'),
(6, 'Ford Freestyle', 'В058ЕХ89', 2004, '63НР 196408'),
(7, 'Volvo S70', 'У679ВМ40', 2000, '64НО 533211'),
(8, 'Audi A3', 'У576МХ62', 2002, '54НТ 425145'),
(9, 'Honda Civic', 'М715СО56', 2008, '60УН 776907'),
(10, 'Fiat Panda 4x4', 'А971ХА67', 2011, '46МР 106349');

-- --------------------------------------------------------

--
-- Структура таблицы `client`
--

CREATE TABLE `client` (
  `Код клиента` int(10) UNSIGNED NOT NULL,
  `ФИО` varchar(100) NOT NULL,
  `Номер телефона` varchar(20) NOT NULL,
  `Дата рождения` date NOT NULL,
  `Водительское удостоверение` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `client`
--

INSERT INTO `client` (`Код клиента`, `ФИО`, `Номер телефона`, `Дата рождения`, `Водительское удостоверение`) VALUES
(1, 'Грибов М. А.', '+7-952-565-02-03', '1985-12-26', '4028 136335'),
(2, 'Евдокимов Д. П.', '+7-987-654-32-12', '1987-12-14', '4897 987745'),
(3, 'Андреев И. М.', '+7-965-302-12-78', '1974-11-02', '4255 785070'),
(4, 'Воронцов М. М.', '+7-932-568-02-04', '1975-02-02', '4784 848003'),
(5, 'Крылов А. М.', '+7-905-895-05-08', '1990-10-12', '4258 891063'),
(6, 'Колесников П. М.', '+7-907-963-85-25', '1983-09-08', '4512 506062'),
(7, 'Голубева В. В.', '+7-908-078-09-08', '1986-08-07', '4320 480317'),
(8, 'Степанова М. М.', '+7-909-951-15-59', '1982-05-06', '4615 150876'),
(9, 'Суботина А.Л.', '+7-905-852-78-98', '1989-11-09', '4345 705014'),
(10, 'Лоськов Я.В.', '+7-987-456-20-03', '1997-09-08', '4849 857830'),
(11, 'Донцов Д.В.', '+7-896-874-65-89', '1993-05-04', '4922 229453'),
(12, 'Антонович Н.И.', '+7-910-986-89-78', '1989-06-07', '4998 495313'),
(15, 'Иванов И.И.', '+7-985-985-96-89', '2021-12-10', '4545 454545');

-- --------------------------------------------------------

--
-- Структура таблицы `cli_dis`
--

CREATE TABLE `cli_dis` (
  `Код клиента` int(10) UNSIGNED NOT NULL,
  `Код карты` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `cli_dis`
--

INSERT INTO `cli_dis` (`Код клиента`, `Код карты`) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(11, 11),
(12, 12),
(15, 15);

-- --------------------------------------------------------

--
-- Структура таблицы `discont`
--

CREATE TABLE `discont` (
  `Код карты` int(10) UNSIGNED NOT NULL,
  `Дата приобретения` date NOT NULL,
  `Количество бонусов` int(11) NOT NULL,
  `Скидка` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `discont`
--

INSERT INTO `discont` (`Код карты`, `Дата приобретения`, `Количество бонусов`, `Скидка`) VALUES
(1, '2021-12-06', 110, 25),
(2, '2021-12-06', 60, 10),
(3, '2021-12-06', 40, 5),
(4, '2021-12-06', 10, 0),
(5, '2021-12-06', 0, 0),
(6, '2021-12-06', 0, 0),
(7, '2021-12-06', 0, 0),
(8, '2021-12-06', 0, 0),
(9, '2021-12-06', 0, 0),
(10, '2021-12-06', 0, 0),
(11, '2021-12-06', 0, 0),
(12, '2021-12-06', 0, 0),
(15, '2021-12-10', 0, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `employee`
--

CREATE TABLE `employee` (
  `Код сотрудника` int(10) UNSIGNED NOT NULL,
  `ФИО` varchar(100) NOT NULL,
  `Дата рождения` date NOT NULL,
  `Адрес` varchar(200) NOT NULL,
  `Номер телефона` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `employee`
--

INSERT INTO `employee` (`Код сотрудника`, `ФИО`, `Дата рождения`, `Адрес`, `Номер телефона`) VALUES
(1, 'Жбанов Анатолий Сергеевич', '1965-07-12', 'г. Москва, ул. Вялова д.5 кв.35', '8-956-454-78-12'),
(2, 'Захаров Матвей Михайлович', '1984-06-13', 'г. Москва, ул. Гирина д.3 кв.45', '8-988-987-56-56'),
(3, 'Семенов Владимир Львович', '1984-06-14', 'г. Москва, ул. Вязова д.3 кв.1', '8-945-656-23-12'),
(4, 'Мещеряков Егор Алексеевич', '1977-09-20', 'г. Москва, ул. Жекина д.7 кв.3', '8-989-456-92-98'),
(5, 'Ефимов Павел Ярославович', '1989-01-05', 'г. Москва, ул. Лесная д.6 кв. 65', '8-972-985-36-65'),
(6, 'Кариев Серафим Афанасьевич', '1987-05-12', ' г. Москва, Чкалова ул., д. 9 кв.80', '8-963-852-90-98');

-- --------------------------------------------------------

--
-- Структура таблицы `oborud`
--

CREATE TABLE `oborud` (
  `Код оборудования` int(10) UNSIGNED NOT NULL,
  `Наименование оборудования` varchar(200) NOT NULL,
  `Дата изготовления` date NOT NULL,
  `Стоимость` decimal(10,2) NOT NULL,
  `Срок гарантии` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `oborud`
--

INSERT INTO `oborud` (`Код оборудования`, `Наименование оборудования`, `Дата изготовления`, `Стоимость`, `Срок гарантии`) VALUES
(1, 'Двухстоечный подъемник 3.2 тонны TS-1112', '2021-12-01', '144900.00', '3 года');

-- --------------------------------------------------------

--
-- Структура таблицы `ordering_services`
--

CREATE TABLE `ordering_services` (
  `Код заказа` int(10) UNSIGNED NOT NULL,
  `Код работы` int(10) UNSIGNED NOT NULL,
  `Код оборудования` int(10) UNSIGNED NOT NULL,
  `Код запчасти` int(10) UNSIGNED NOT NULL,
  `Код сотрудника` int(10) UNSIGNED NOT NULL,
  `Код автомобиля` int(10) UNSIGNED NOT NULL,
  `Код клиента` int(10) UNSIGNED NOT NULL,
  `Дата поступления` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `ordering_services`
--

INSERT INTO `ordering_services` (`Код заказа`, `Код работы`, `Код оборудования`, `Код запчасти`, `Код сотрудника`, `Код автомобиля`, `Код клиента`, `Дата поступления`) VALUES
(1, 1, 1, 1, 1, 1, 4, '2023-05-06'),
(2, 2, 1, 2, 1, 1, 1, '2023-05-06'),
(9, 3, 1, 3, 1, 2, 2, '2023-05-06'),
(14, 8, 1, 10, 3, 3, 3, '2023-05-06'),
(15, 4, 1, 4, 4, 4, 4, '2023-05-06'),
(20, 8, 1, 10, 6, 1, 1, '2023-05-07'),
(21, 6, 1, 8, 5, 1, 1, '2023-05-08'),
(22, 2, 1, 6, 3, 1, 1, '2023-05-10'),
(24, 1, 1, 1, 1, 1, 1, '2023-05-07'),
(25, 1, 1, 1, 1, 1, 1, '2023-05-07'),
(26, 2, 1, 2, 2, 2, 2, '2023-05-10'),
(27, 3, 1, 3, 5, 2, 2, '2023-05-08'),
(28, 5, 1, 7, 6, 2, 2, '2023-05-10'),
(29, 4, 1, 3, 3, 2, 2, '2023-05-08'),
(30, 1, 1, 1, 6, 2, 2, '2023-05-08'),
(31, 4, 1, 7, 3, 3, 3, '2023-05-10'),
(32, 7, 1, 7, 2, 3, 3, '2023-05-10'),
(33, 8, 1, 10, 4, 3, 3, '2023-05-12'),
(34, 1, 1, 3, 4, 1, 1, '2023-05-10'),
(35, 1, 1, 3, 1, 1, 1, '2023-05-31'),
(36, 1, 1, 1, 1, 1, 1, '2023-05-31'),
(42, 1, 1, 1, 1, 1, 1, '2023-06-05'),
(43, 1, 1, 1, 1, 1, 1, '2023-06-05');

--
-- Триггеры `ordering_services`
--
DELIMITER $$
CREATE TRIGGER `update` AFTER INSERT ON `ordering_services` FOR EACH ROW BEGIN
declare id int;
set id = (Select e.`Код клиента` FROM `ordering_services` as w JOIN `client` as e ON e.`Код клиента` = w.`Код клиента` ORDER BY w.`Код заказа` DESC LIMIT 1);
UPDATE `discont` SET `Количество бонусов`=`Количество бонусов`+10 WHERE `Код карты`= id;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `update_1` AFTER INSERT ON `ordering_services` FOR EACH ROW BEGIN
declare client int UNSIGNED;
set client=(select `Код клиента` from `ordering_services` ORDER BY `Код заказа` DESC LIMIT 1);
UPDATE `discont` SET `Скидка`=`Скидка`+5 WHERE `Количество бонусов`= 40 AND `Код карты` = client;
UPDATE `discont` SET `Скидка`=`Скидка`+5 WHERE `Количество бонусов`= 60 AND `Код карты` = client;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `update_2` AFTER INSERT ON `ordering_services` FOR EACH ROW BEGIN
declare productid int UNSIGNED;
set productid=(select `Код запчасти` from `ordering_services` ORDER BY `Код заказа` DESC LIMIT 1);
UPDATE `zapt` SET `Количество`=`Количество`-1 WHERE `Код запчасти`= productid;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `provider`
--

CREATE TABLE `provider` (
  `Код поставщика` int(10) UNSIGNED NOT NULL,
  `Наименование поставщика` varchar(50) NOT NULL,
  `Телефон` varchar(20) NOT NULL,
  `ИНН` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `provider`
--

INSERT INTO `provider` (`Код поставщика`, `Наименование поставщика`, `Телефон`, `ИНН`) VALUES
(1, 'ООО \"Орион\"', '989-89-16', '45451212'),
(2, 'ОАО \"Перфект\"', '856-45-56', '45654512'),
(3, 'ООО \"Сибирь\"', '265-56-45', '26566226'),
(4, 'ООО \"Эра\"', '889-56-65', '65654545'),
(5, 'ОАО \"Скорпион\"', '121-34-34', '52326545'),
(6, 'ОАО \"Дефекта\"', '985-45-56', '23654512'),
(7, 'ООО \"Чек\"', '654-56-23', '23564512'),
(8, 'ООО \"Вымпел\"', '652-89-56', '26594878'),
(9, 'ООО \"Стринг\"', '565-03-04', '89024934');

-- --------------------------------------------------------

--
-- Структура таблицы `rabota`
--

CREATE TABLE `rabota` (
  `Код работы` int(10) UNSIGNED NOT NULL,
  `Вид работы` varchar(50) NOT NULL,
  `Стоимость` decimal(10,2) NOT NULL,
  `Срок выполнения` varchar(50) NOT NULL,
  `Гарантия` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `rabota`
--

INSERT INTO `rabota` (`Код работы`, `Вид работы`, `Стоимость`, `Срок выполнения`, `Гарантия`) VALUES
(1, 'Замена поршневого кольца №12', '800.00', '1 день', '6 месяцев'),
(2, 'Замена клапана ускорительного Wabco', '900.00', '1 день', '12 месяцев'),
(3, 'Замена натяжителя приводного ремня RENAULT', '2500.00', '1 день', '6 месяцев'),
(4, 'Замена поршневых поршеней для Газель', '3000.00', '2 дня', '12 месяцев'),
(5, 'Замена клапана редукционного Wabco', '1500.00', '2 дня', '6 месяцев'),
(6, 'Установка прокладки ресивера', '1200.00', '1 день', '6 месяцев'),
(7, 'Замена поршеня Volvo FH/FM', '3500.00', '2 дня', '12 месяцев'),
(8, 'Установка шарнира угловых скоростей', '3700.00', '2 дня', '12 месяцев');

-- --------------------------------------------------------

--
-- Структура таблицы `zapt`
--

CREATE TABLE `zapt` (
  `Код запчасти` int(10) UNSIGNED NOT NULL,
  `Наименование запчасти` varchar(2000) NOT NULL,
  `Стоимость` decimal(10,2) NOT NULL,
  `Гарантия` varchar(50) NOT NULL,
  `Код поставщика` int(10) UNSIGNED NOT NULL,
  `Дата поступления` date NOT NULL,
  `Количество` smallint(11) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `zapt`
--

INSERT INTO `zapt` (`Код запчасти`, `Наименование запчасти`, `Стоимость`, `Гарантия`, `Код поставщика`, `Дата поступления`, `Количество`) VALUES
(1, 'Поршневое кольцо №12', '400.00', '1 год', 1, '2021-12-01', 0),
(2, 'Клапан ускорительный Wabco', '300.00', '2 года', 2, '2021-12-01', 4),
(3, 'Натяжитель приводного ремня REAULT', '3000.00', '1 год', 3, '2021-12-02', 0),
(4, 'Кольца поршневые моторные 92 мм', '1400.00', '2 года', 4, '2021-12-02', 4),
(5, 'Группа поршневая поршень для Газель', '5000.00', '3 года', 5, '2021-12-02', 0),
(6, 'Втулка коленчатого вала', '500.00', '1 год', 6, '2021-12-03', 4),
(7, 'Клапан редукционный Wabco', '1100.00', '2 года', 7, '2021-12-03', 5),
(8, 'Прокладка ресивера', '100.00', '1 год', 8, '2021-12-03', 3),
(9, 'Поршень Volvo FH/FM', '5500.00', '2 года', 2, '2021-12-03', 5),
(10, 'Шарнир угловых скоростей', '900.00', '1 год', 5, '2021-12-06', 3);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `auto`
--
ALTER TABLE `auto`
  ADD PRIMARY KEY (`Код автомобиля`);

--
-- Индексы таблицы `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`Код клиента`);

--
-- Индексы таблицы `cli_dis`
--
ALTER TABLE `cli_dis`
  ADD KEY `Код карты` (`Код карты`),
  ADD KEY `Код клиента` (`Код клиента`);

--
-- Индексы таблицы `discont`
--
ALTER TABLE `discont`
  ADD UNIQUE KEY `Код карты_2` (`Код карты`),
  ADD KEY `Код карты` (`Код карты`);

--
-- Индексы таблицы `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`Код сотрудника`);

--
-- Индексы таблицы `oborud`
--
ALTER TABLE `oborud`
  ADD PRIMARY KEY (`Код оборудования`);

--
-- Индексы таблицы `ordering_services`
--
ALTER TABLE `ordering_services`
  ADD PRIMARY KEY (`Код заказа`),
  ADD KEY `Код автомобиля` (`Код автомобиля`),
  ADD KEY `Код запчасти` (`Код запчасти`),
  ADD KEY `id_zap` (`Код запчасти`),
  ADD KEY `Код работы` (`Код работы`,`Код оборудования`,`Код сотрудника`,`Код клиента`),
  ADD KEY `Код оборудования` (`Код оборудования`),
  ADD KEY `Код клиента` (`Код клиента`),
  ADD KEY `Код сотрудника` (`Код сотрудника`);

--
-- Индексы таблицы `provider`
--
ALTER TABLE `provider`
  ADD PRIMARY KEY (`Код поставщика`);

--
-- Индексы таблицы `rabota`
--
ALTER TABLE `rabota`
  ADD PRIMARY KEY (`Код работы`);

--
-- Индексы таблицы `zapt`
--
ALTER TABLE `zapt`
  ADD PRIMARY KEY (`Код запчасти`),
  ADD KEY `Код поставщика` (`Код поставщика`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `auto`
--
ALTER TABLE `auto`
  MODIFY `Код автомобиля` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `client`
--
ALTER TABLE `client`
  MODIFY `Код клиента` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT для таблицы `employee`
--
ALTER TABLE `employee`
  MODIFY `Код сотрудника` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `oborud`
--
ALTER TABLE `oborud`
  MODIFY `Код оборудования` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `ordering_services`
--
ALTER TABLE `ordering_services`
  MODIFY `Код заказа` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT для таблицы `provider`
--
ALTER TABLE `provider`
  MODIFY `Код поставщика` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `rabota`
--
ALTER TABLE `rabota`
  MODIFY `Код работы` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `zapt`
--
ALTER TABLE `zapt`
  MODIFY `Код запчасти` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `cli_dis`
--
ALTER TABLE `cli_dis`
  ADD CONSTRAINT `cli_dis_ibfk_1` FOREIGN KEY (`Код карты`) REFERENCES `discont` (`Код карты`),
  ADD CONSTRAINT `cli_dis_ibfk_2` FOREIGN KEY (`Код клиента`) REFERENCES `client` (`Код клиента`);

--
-- Ограничения внешнего ключа таблицы `ordering_services`
--
ALTER TABLE `ordering_services`
  ADD CONSTRAINT `ordering_services_ibfk_1` FOREIGN KEY (`Код автомобиля`) REFERENCES `auto` (`Код автомобиля`),
  ADD CONSTRAINT `ordering_services_ibfk_2` FOREIGN KEY (`Код запчасти`) REFERENCES `zapt` (`Код запчасти`),
  ADD CONSTRAINT `ordering_services_ibfk_3` FOREIGN KEY (`Код работы`) REFERENCES `rabota` (`Код работы`),
  ADD CONSTRAINT `ordering_services_ibfk_4` FOREIGN KEY (`Код оборудования`) REFERENCES `oborud` (`Код оборудования`),
  ADD CONSTRAINT `ordering_services_ibfk_5` FOREIGN KEY (`Код клиента`) REFERENCES `client` (`Код клиента`),
  ADD CONSTRAINT `ordering_services_ibfk_6` FOREIGN KEY (`Код сотрудника`) REFERENCES `employee` (`Код сотрудника`);

--
-- Ограничения внешнего ключа таблицы `zapt`
--
ALTER TABLE `zapt`
  ADD CONSTRAINT `zapt_ibfk_1` FOREIGN KEY (`Код поставщика`) REFERENCES `provider` (`Код поставщика`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
