-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 182.50.133.92:3306
-- Generation Time: Oct 03, 2019 at 01:52 AM
-- Server version: 5.5.51-38.1-log
-- PHP Version: 7.1.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ph16787236639_`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL DEFAULT '0',
  `username` varchar(100) DEFAULT NULL,
  `PASSWORD` varchar(100) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `username`, `PASSWORD`) VALUES
(1, 'iamonit@nation.com', 'supercool123#@!');

-- --------------------------------------------------------

--
-- Table structure for table `HRTVIK_events`
--

CREATE TABLE `HRTVIK_events` (
  `id` int(11) NOT NULL,
  `title` varchar(100) NOT NULL,
  `image_url` varchar(140) NOT NULL,
  `Createdon` datetime DEFAULT NULL,
  `createdby` varchar(100) DEFAULT NULL,
  `description` varchar(1000) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `HRTVIK_events`
--

INSERT INTO `HRTVIK_events` (`id`, `title`, `image_url`, `Createdon`, `createdby`, `description`) VALUES
(1, 'Logo Launch', '/dynamicPic/image_976183.JPG', '2019-09-14 04:48:39', NULL, 'I Stand for the Nation Logo Launched on 06-09-2019, by Sri. JAYADEV RAJWAL\r\n(BJP Jammu State In charge).\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `HRTVIK_gallery`
--

CREATE TABLE `HRTVIK_gallery` (
  `id` int(11) NOT NULL,
  `eventid` int(11) NOT NULL,
  `image_url` varchar(140) NOT NULL,
  `Createdon` datetime DEFAULT NULL,
  `createdby` varchar(100) DEFAULT NULL,
  `eventtype` varchar(25) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `HRTVIK_gallery`
--

INSERT INTO `HRTVIK_gallery` (`id`, `eventid`, `image_url`, `Createdon`, `createdby`, `eventtype`) VALUES
(13, 1, '/dynamicPic/1 (1)_81026.jpeg', '2019-09-14 07:18:29', NULL, 'Image'),
(14, 1, '/dynamicPic/1 (2)_684052.jpeg', '2019-09-14 07:18:29', NULL, 'Image'),
(15, 1, '/dynamicPic/1 (3)_39556.jpeg', '2019-09-14 07:18:29', NULL, 'Image'),
(16, 1, '/dynamicPic/1 (4)_199874.jpeg', '2019-09-14 07:18:30', NULL, 'Image'),
(17, 1, '/dynamicPic/1 (5)_360192.jpeg', '2019-09-14 07:18:30', NULL, 'Image'),
(18, 1, '/dynamicPic/1 (6)_161706.jpeg', '2019-09-14 07:18:30', NULL, 'Image'),
(19, 1, '/dynamicPic/1 (7)_322024.jpeg', '2019-09-14 07:18:31', NULL, 'Image'),
(20, 1, '/dynamicPic/1 (8)_482342.jpeg', '2019-09-14 07:18:31', NULL, 'Image'),
(21, 1, '/dynamicPic/1 (9)_642660.jpeg', '2019-09-14 07:18:31', NULL, 'Image'),
(22, 1, '/dynamicPic/1 (10)_802979.jpeg', '2019-09-14 07:18:31', NULL, 'Image'),
(23, 1, '/dynamicPic/1 (11)_604492.jpeg', '2019-09-14 07:18:32', NULL, 'Image'),
(24, 1, '/dynamicPic/1 (12)_764810.jpeg', '2019-09-14 07:18:32', NULL, 'Image'),
(27, 1, '/video/LogoISFTNsakshi.mp4', '2019-09-14 07:31:30', NULL, 'Video');

-- --------------------------------------------------------

--
-- Table structure for table `HRTVIK_OurTeam`
--

CREATE TABLE `HRTVIK_OurTeam` (
  `id` int(11) NOT NULL,
  `img_url` varchar(250) NOT NULL,
  `createdon` datetime NOT NULL,
  `link` varchar(250) NOT NULL,
  `title` varchar(250) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `HRTVIK_OurTeam`
--

INSERT INTO `HRTVIK_OurTeam` (`id`, `img_url`, `createdon`, `link`, `title`) VALUES
(11, '/dynamicPic/weave-logo-png_577323.png', '2019-10-01 12:44:25', 'https://istandforthenation.org', 'WEAVE'),
(10, '/dynamicPic/Logo_393490.jpg', '2019-10-01 12:43:43', 'https://istandforthenation.org', 'MINDIFY'),
(9, '/dynamicPic/Icon_142647.png', '2019-10-01 02:25:52', 'https://annamrajudesigns.com/', 'Annamraju Designs and Technologies'),
(8, '/dynamicPic/0_220357.png', '2019-10-01 02:23:38', 'http://tenxbranding.in/', 'TENX Branding'),
(12, '/dynamicPic/SWI - Very Final LOGO - high resolution_231085.png', '2019-10-01 12:45:05', 'https://istandforthenation.org', 'Super Women India'),
(13, '/dynamicPic/AVM logo_514224.jpg', '2019-10-02 02:20:43', 'https://istandforthenation.org', 'AVM'),
(19, '/dynamicPic/bnk-01_734096.jpg', '2019-10-02 02:25:20', 'https://istandforthenation.org', 'BEJAGAM NITHIN KUMAR'),
(15, '/dynamicPic/DumMatka Logo_889110.jpg', '2019-10-02 02:21:38', 'https://istandforthenation.org', 'DumMatka'),
(16, '/dynamicPic/MIDLAND LOGO_669444.jpg', '2019-10-02 02:22:23', 'https://istandforthenation.org', 'MIDLAND'),
(17, '/dynamicPic/Logo New_353440.jpg', '2019-10-02 02:22:43', 'https://istandforthenation.org', 'V Team'),
(18, '/dynamicPic/NRI logo_393731.jpg', '2019-10-02 02:23:53', 'https://istandforthenation.org', 'NRI Media Wings'),
(20, '/dynamicPic/v3 logo png_846998.jpg', '2019-10-02 02:25:58', 'https://istandforthenation.org', 'V3 News'),
(21, '/dynamicPic/photofina-01_709499.jpg', '2019-10-02 02:27:07', 'https://istandforthenation.org', 'PHOTOFINA'),
(22, '/dynamicPic/VIZAG Car Bazar_391197.jpg', '2019-10-02 02:28:34', 'https://istandforthenation.org', 'VIZAG CAR BAZAR');

-- --------------------------------------------------------

--
-- Table structure for table `People`
--

CREATE TABLE `People` (
  `Id` int(11) NOT NULL DEFAULT '0',
  `Name` varchar(45) DEFAULT NULL,
  `Email` varchar(320) DEFAULT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `State` varchar(25) DEFAULT NULL,
  `Country` varchar(25) DEFAULT NULL,
  `Createdon` datetime DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT NULL,
  `isactive` tinyint(1) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `People`
--

INSERT INTO `People` (`Id`, `Name`, `Email`, `Phone`, `State`, `Country`, `Createdon`, `isdeleted`, `isactive`) VALUES
(629048, 'Annamraju Bharadwaj', 'annamrajubharadwaj@gmail.com', '9989174249', 'Telangana', 'India', '2019-09-16 17:39:59', 0, 1),
(645887, 'Raupathireddy Karka', 'raghu.reddy017@gmail.com', '9989642899', 'telangana', 'india', '2019-09-16 07:03:37', 0, 0),
(240864, 'K Nagaraj ', 'nagarajkanajikar4@gmail.com', '9164175677', 'Karnataka ', 'India', '2019-09-16 07:20:56', 0, 1),
(341623, 'Madhumita Mishra', 'madhumitamishra03@gmail.com', '9989238935', 'Telangana', 'India', '2019-09-16 10:16:56', 0, 1),
(471350, 'Sampath Kumar Jella', 'sampath.life7@gmail.com', '8464815572', 'Telangana', 'India', '2019-09-16 10:43:30', 0, 1),
(584096, 'Arunkumar bandi', 'aruncreations1@gmail.com', '8523043214', 'Telangana', 'india', '2019-09-16 22:22:52', 0, 1),
(884967, 'Shiva Velchuri', 'velchuri@gmail.com', '8499935007', 'Andhrapradesh', 'India', '2019-09-17 02:07:45', 0, 0),
(470406, 'G SANGAMESHWAR', 'teamindia2030@gmail.com', '9515287180', 'TELANGANA', 'INDIA', '2019-09-17 02:08:42', 0, 1),
(638772, 'SRI DIVYA', 'annamrajubharadwaj@gmail.com', '9866166461', 'Telangana', 'India', '2019-09-17 09:49:23', 0, 0),
(702734, 'Eppalapalli Ramesh', 'eppalapalleeramesha@gmail.com', '9849598649', 'Telangana', 'India', '2019-09-17 20:41:04', 0, 1),
(230297, 'BVL NAVAKANTH', 'bvlnavakanth@gmail.com', '9392576777', 'Telangana', 'India', '2019-09-17 22:23:45', 0, 0),
(35367, 'Sowjanya Kariveda', 'sowjanya.kariveda@gmail.com', '9951202188', 'Telangana', 'India', '2019-09-17 22:38:03', 0, 1),
(364497, 'P V NARAYANA', 'pvny999@gmail.com', '9848899972', 'Telangana ', 'Indian', '2019-09-18 00:24:39', 0, 1),
(717196, 'Leelaprasaad Rao b', 'lprbangla@gmail.com', '9948812326', 'Telangana', 'India', '2019-09-18 02:32:15', 0, 1),
(266312, 'Deepak Kumar Gadde', 'gaddedeepakk@gmail.com', '0425103231', 'Victoria ', 'Australia ', '2019-09-18 05:19:25', 0, 1),
(280905, 'V.sharath Kumar', 'v.sharath143@gmail.com', '7981117030', 'Telangana', 'India', '2019-09-18 05:56:51', 0, 1),
(147673, 'Nitin', 'nitin.kunjir@gmail.com', '9920401226', 'MAHARASHTRA', 'India', '2019-09-18 10:38:53', 0, 0),
(715013, 'Karimilla Venkateshwar rao', 'karimilla3473@gmail.com', '9550589517', 'Telangana', 'India', '2019-09-19 01:11:09', 0, 1),
(459201, 'Krishnareddy kadenti ', 'kadentikrishnareddy@gmail.com', '9535455366', 'Karnataka ', 'India ', '2019-09-19 06:51:10', 0, 1),
(625149, 'S VAGEESH', 'lionvagi@gmail.com', '9444966789', 'Tamilnadu', 'India ', '2019-09-19 06:57:39', 0, 1),
(635258, 'Yannamsetty Suresh ', 'sritarunidesigns@gmail.com', '9440150875', 'Andhra Pradesh ', 'India ', '2019-09-19 15:17:39', 0, 1),
(479750, 'INDRAKANTI MURALI DHAR', 'imdavm@gmail.com', '9848067013', 'Telangana', 'India', '2019-09-19 20:33:21', 0, 1),
(561927, 'Prasad Babu K', NULL, '7013528143', 'Andhra pradesh', 'India', '2019-09-19 22:10:25', 0, 1),
(988405, 'Vikhil Prabha', 'mailtovikhilprabha@gmail.com', '7331175316', 'Telangana', 'India', '2019-09-19 23:49:43', 0, 1),
(620857, 'Harikrishna Inturu', 'harinturu@gmail.com', '9989696654', 'Telangana', 'India', '2019-09-20 05:04:52', 0, 1),
(701302, 'Rajashekar ', 'rajashekarsmeily@gmail.com', '9059383413', 'Telangana ', 'India ', '2019-09-20 07:47:21', 0, 0),
(786972, 'Badri Narayana Malla', 'Badrin.malla@gmail.com', '8885511555', 'Telangana', 'India', '2019-09-21 04:25:17', 0, 1),
(618519, 'S.Naveen Reddy ', 'naveensidgar@gmail.com', '8008923088', 'Telangana', 'India ', '2019-09-21 04:31:00', 0, 0),
(574468, 'Kota Srikanth', 'kotasrikanth76@yahoo.com', '9437258598', 'Orissa', 'India', '2019-09-21 23:49:55', 0, 1),
(134565, 'Naveen Bachu', 'bnk7ski@gmail.com', '7013398207', 'Telangana', 'Indi', '2019-09-22 07:05:22', 0, 1),
(704438, 'Pratima jaidev', 'jupratima@gmail.com', '9949722955', 'Telangana', 'India', '2019-09-22 12:26:27', 0, 0),
(638463, 'Harikishan Eppanapally', 'heppanap@yahoo.com', '9734229090', 'NEW JERSEY', 'United States', '2019-09-22 18:25:32', 0, 0),
(281992, 'SHANTI S EPPANAPALLY', 'heppanap@yahoo.com', '9734221155', 'NJ', 'United States', '2019-09-22 18:26:55', 0, 0),
(177391, 'Joshi podili', 'joshipodili@gmail.com', '6303223006', 'Andhra Pradesh', 'India', '2019-09-24 05:25:49', 0, 1),
(563066, 'Shinu', 'Shipr01@gmail.com ', '9000456193', 'Telangana ', 'India', '2019-09-24 18:58:59', 0, 1),
(318558, 'K.durga bhavani ', 'bhavani_yd@yahoo.com ', '9052374235', 'Andhra pradesh ', 'India ', '2019-09-25 19:35:49', 0, 0),
(274656, 'K.durga bhavani ', 'bhavani_yd@yahoo.com ', '9515423535', 'Andhra pradesh ', 'India ', '2019-09-25 19:36:37', 0, 1),
(696551, 'P Kishore Babu Mudiraj', 'kishoremudiraj00@gmail.com', '8309752088', 'Telangana', 'India', '2019-09-26 19:43:06', 0, 1),
(510209, 'Dr. K. Venkat Satish', 'kodhmuri.satish72@gmail.com', '9912878008', 'Telangana', 'India', '2019-09-26 19:43:14', 0, 1),
(62131, 'JAVAJI KUMAR SWAMY', 'jkyadav123@gmail.com', '9440579952', 'telangana', 'india', '2019-09-26 22:41:24', 0, 1),
(764173, 'Geetha chowdhary ', 'geethachowdharyindia3@gmail.com', '8247527389', 'Telangana ', 'India', '2019-09-27 02:36:18', 0, 0),
(145556, 'Sudheer Jalagam', 'sudheerjalagam@gmail.com', '9515755476', 'Telangana ', 'India', '2019-09-27 05:41:29', 0, 0),
(297472, 'Arpitha Amancharla', 'aamancharla@gmail.com', '9949815308', 'Telangana', 'India', '2019-09-27 16:36:39', 0, 1),
(604298, 'Dr Anand Kumar', 'anandaalochanalu@gmail.com', '9818016299', 'Delhi', 'India', '2019-09-27 21:24:18', 0, 1),
(505874, 'Dr Poornima', 'banjaramahilango@gmail.com', '9717934959', 'Hyderabad', 'India', '2019-09-27 21:25:15', 0, 1),
(531298, 'PRAGYA NAGORI', 'yeoorja@gmail.com', '9394441431', 'Telangana', 'India', '2019-09-27 22:20:19', 0, 1),
(15438, 'Vavilala Raju ', 'rajsv39@gmail.com', '9949390101', 'Telangana', 'India ', '2019-09-28 03:03:41', 0, 1),
(848110, 'B. Harikrishna ', 'Baganwarharikrishna@gmail.com ', '7013881983', 'Telangana', 'India ', '2019-09-28 03:04:25', 0, 1),
(232244, 'Sunil varma', 'Sunil123.nani@gmail.com', '8465888788', 'Telangana', 'India', '2019-09-28 03:04:44', 0, 1),
(515383, 'Anudeep patel', 'Patelanudeep999@gmail.com', '9948643669', 'Telangana', 'India', '2019-09-28 03:08:07', 0, 1),
(411474, 'Thirupathi', NULL, '9177619809', 'Telangana', 'India', '2019-09-28 03:12:47', 0, 1),
(430693, 'S. Venkatapathi Raju', 'svdigitalspg@gmail.com', '9848071482', 'Telangana', 'India', '2019-09-28 03:39:00', 0, 1),
(526752, 'Rajashekar Chelmatikari', 'rajrajshekar43@gmail.com', '9652988843', 'Telangana', 'India', '2019-09-28 03:45:32', 0, 1),
(407317, 'Mohammad Javed Pasha', 'javeedpashamail@gmail.com', '9701822092', 'Telengana', 'India', '2019-09-28 04:10:16', 0, 1),
(280958, 'Rohith', 'parvathirohith3@gmail.com', '7730880137', 'Telangana', 'India', '2019-09-28 04:10:27', 0, 1),
(909976, 'Putta rajender', 'rajenderrajender856@emil.com', '9666552712', 'Telangana', 'India', '2019-09-28 05:16:23', 0, 0),
(802213, 'Gundam Ravi', 'gundamravi3416@gmail.com', '9502073416', 'Telangana ', 'India ', '2019-09-28 05:48:23', 0, 1),
(448885, 'Eraveni Praveen', 'eravenapraveen@gmail.com', '8328007940', 'Telangana', 'India', '2019-09-28 07:23:41', 0, 1),
(443718, 'Jadi Manoj Kumar ', 'manu.kumar687@gmail.com', '9959391958', 'Telangana', 'India', '2019-09-28 08:08:28', 0, 1),
(804141, 'Gandam sathyanarayana', 'padmalablxpt@gmail.com', '9849184646', 'Telngana', 'India', '2019-09-28 09:39:27', 0, 1),
(850029, 'Kotaru Kiran', 'Kotaru.kiran@gmail.com', '8008729110', 'Telangana', 'India', '2019-09-28 18:30:55', 0, 1),
(443883, 'kokkula nagesh', 'kokkula.nagesh@gmail.com', '8328021620', 'Telangana', 'india', '2019-09-28 20:55:16', 0, 1),
(206101, 'Manchala Nareshcharan ', 'mannaresh82@gmail.com ', '9032016205', 'Talangana ', 'India ', '2019-09-28 21:37:04', 0, 1),
(88277, 'Vidhyasagar', 'vidhyasagar20.thota@gmail.com', '8555076365', 'Telagana', 'India', '2019-09-29 00:14:44', 0, 1),
(922142, 'Dr Sajida Khan', 'sajidakhan111@gmail.com ', '9059695714', 'Telangana ', 'India ', '2019-09-29 02:22:40', 0, 0),
(374016, 'Rajender Sanadi', 'suryarajsanadi009@gmail.com', '8074715050', 'Telangana ', 'India ', '2019-09-29 03:55:56', 0, 1),
(728311, 'Sahil kajani', 'sahilkajani121@gmail.com', '8511306232', 'Telangana', 'India', '2019-09-29 06:28:17', 0, 1),
(14735, 'kiran rathod', 'kiran3.smaat@gmail.com', '7032346802', 'Telangana', 'India', '2019-09-29 23:14:36', 0, 1),
(563084, 'Rajesh Pershad ', 'pershad.rajesh@gmail.com', '8897089371', 'Telangana ', 'India', '2019-09-30 01:20:15', 0, 0),
(454232, 'Atargu manoj kumar reddy', 'reddymanoj034@gmail.com', '9030708854', 'Telangana', 'India', '2019-09-30 01:59:50', 0, 1),
(385656, 'RAM', 'jabiliram@gmail.com', '9849595440', 'Telangana', 'India', '2019-09-30 04:21:09', 0, 1),
(571533, 'Suresh jetti', 'Sureshjetti47@gmail.com', '9705780578', 'Telangana', 'India ', '2019-09-30 04:22:57', 0, 1),
(338055, 'M.sandeep', 'Sandeepmadaraboina@gmail.com', '9966469377', 'Telagana ', 'India', '2019-09-30 06:52:49', 0, 1),
(137301, 'K NAGARAJU', 'naga.raju576@gmail.com', '9346620336', 'Telangana', 'India', '2019-09-30 09:57:06', 0, 1),
(114416, 'Venkat ', 'gvramana77@gmail.com ', '1234567890', NULL, NULL, '2019-09-30 19:45:40', 0, 1),
(105666, 'Lakshmi', 'k.lakshmi.sg@gmail.com', '7702024368', 'Singapore ', 'Singapore ', '2019-09-30 22:10:29', 0, 1),
(658759, 'Madishetty Rakesh ', 'Rakeshmadishetty96@gmail.com', '8500857906', 'Telangana ', 'India ', '2019-10-01 01:49:23', 0, 1),
(263242, 'Archana', 'karchana962@gmail.com', '9885666427', 'Telangana', 'India', '2019-10-01 02:35:29', 0, 1),
(656162, 'S KIRAN', 'siripurikiran@gmail.com', '9533555553', 'TELANGANA ', 'INDIA', '2019-10-01 03:08:56', 0, 1),
(538419, 'Jyothi s', 'blsjyothi@gmail.com', '7093991100', 'Telangana', 'India', '2019-10-01 04:32:52', 0, 0),
(349850, 'Jayasree Pavani', 'pavani_jayasree@yahoo.co.in', '9052835123', 'Telangana', 'India', '2019-10-01 04:55:51', 0, 1),
(908053, 'Mukesh siripangi', 'Mukesh.Siripangi@gmail.com', '7075715926', 'Telangana', 'India', '2019-10-01 05:44:00', 0, 1),
(551654, 'Sankara V Krishna Prasad', 'svkrishnaprasad@gmail.com', '9948664080', 'Telangana', 'India ', '2019-10-01 06:44:00', 0, 1),
(26632, 'Rajendar Reddy Karne', 'rajendharreddy.karne@gmail.com', '9959234208', 'TELANGANA', 'India', '2019-10-01 07:47:00', 0, 1),
(81527, 'Ashok chakra', '3gstudioshyd@gmail.com', '9573202082', 'Telangana ', 'India', '2019-10-01 09:08:51', 0, 1),
(814637, 'Dasarath KJ', 'kjdasarath@gmail.com', '8978216795', 'Telagana ', 'India', '2019-10-01 09:09:07', 0, 1),
(322559, 'Gopi krishna kalluru', 'gk800@engineer.com', '9652652800', 'Andhra Pradesh', 'India', '2019-10-01 09:48:13', 0, 1),
(549719, 'Harish p', 'Harishguptha94@gmail.com', '8686066152', 'Telangana', 'India', '2019-10-01 10:02:35', 0, 1),
(756786, 'Rj abhilash', 'abhilash5908@gmail.com', '9502230300', 'telangana', 'india', '2019-10-01 10:46:55', 0, 1),
(968529, 'Prathap ', 'Chinnasri556@gmail.com ', '9059788467', 'Telangana ', 'India ', '2019-10-01 10:52:14', 0, 0),
(985095, 'Rj abhilash', 'abhilash5908@gmail.com', '8328229754', 'telangana', 'India', '2019-10-01 10:52:26', 0, 0),
(592819, 'Moin', 'Khwajamoin999@gmail.com', '8978971248', 'Andhra Pradesh ', 'India ', '2019-10-01 11:39:54', 0, 0),
(269945, 'SobiyaJuveriya', 'sobiyajuveriya@gmail.com', '9912483818', 'Telangana', 'India', '2019-10-01 11:56:18', 0, 1),
(671114, 'Shafi mohammed', 'Sh_tab2004@yahoo.com', '7097593749', 'Telangana', 'India', '2019-10-01 12:43:08', 0, 1),
(206833, 'Sridhar Kavuri', 'sridharkavuri@yahoo.com', '9849965036', 'ANDHRA PRADESH', 'India', '2019-10-01 16:03:04', 0, 1),
(745041, 'P V S BHAGAVAN TEJA', 'pteja977@gmail.com', '7093352024', 'ANDHRA PRADESH', 'INDIA', '2019-10-01 20:34:30', 0, 1),
(841463, 'JANGA SOMAYYA', 'somuphotographer@gmail.com', '9885697379', 'Telangana', 'India', '2019-10-01 20:46:27', 0, 1),
(306312, 'Konda kavitha reddy', 'kr_konda@yahoo.co.in', '9393484068', 'Telangana ', 'India ', '2019-10-01 21:26:12', 0, 1),
(826589, 'mrsnreddy', 'mrsnreddy1963@gmail.com', '9849287389', 'Andhra Pradesh', 'India', '2019-10-01 21:45:31', 0, 1),
(161475, 'mrsnreddy', 'mrsnreddy1963@gmail.com', '9849287389', 'Andhra Pradesh', 'India', '2019-10-01 21:45:31', 0, 1),
(223775, 'N Gopi Krishna Reddy', 'meghalayadigital@gmail.com', '9848568155', 'Andhra Pradesh', 'India', '2019-10-01 21:45:42', 0, 1),
(426512, 'John testing', NULL, '9989000000', NULL, NULL, '2019-10-01 22:36:23', 0, 1),
(902942, 'GK KISHOORE', 'gkkishoore@gmail.com', '9160246789', 'Andhra Pradesh', 'India', '2019-10-01 23:17:03', 0, 1),
(190362, 'Jayanarayana Kureti', 'ceo@ethree.in', '9293929292', 'Andhra Pradesh', 'India', '2019-10-02 00:02:08', 0, 0),
(779592, 'Durga Utpala Mirthivada', 'utpala.mirthivada@gmail.com', '7702705353', 'Telangana', 'India', '2019-10-02 00:30:32', 0, 1),
(537215, 'Laxman Vallakati', 'lucky_overseas@rediffmail.com', '9500028438', 'TELANGANA', 'India', '2019-10-02 00:37:49', 0, 1),
(133676, 'N Darga Anjaneyulu', 'anjineerukattu222@gmail.com', '9177868222', 'Telangana', 'India', '2019-10-02 02:42:23', 0, 1),
(202205, 'Razak Nadeem', 'razaknadeem786@gmail.com', '9440304725', 'Andhra Pradesh', 'India', '2019-10-02 02:51:01', 0, 0),
(733854, 'Sainath chary gannoji', 'sainathcharygannoji@gmail.com', '9398051569', 'Telangana', 'India', '2019-10-02 05:49:45', 0, 1),
(330902, 'MADHU KONERU', 'madhuscoops@gmail.com', '9951073000', 'Andhra Pradesh', 'India', '2019-10-02 07:29:30', 0, 1),
(133571, 'Sadhana Kashinath ', 'hulsoore@gmail.com', '9849069908', 'Telegana ', 'Indua', '2019-10-02 10:47:47', 0, 1),
(394085, 'Sadhana Kashinath ', 'hulsoore@gmail.com', '9000225355', 'Telegana ', 'India', '2019-10-02 10:48:59', 0, 1),
(707808, 'Prema', 'pari_cherry@gmail.com', '9343576719', 'Karnataka ', 'Indis', '2019-10-02 10:51:04', 0, 1),
(683555, 'Veera Suman Batchu', 'svrfnlr@gmail.com', '7702094268', 'Andhra Pradesh', 'India', '2019-10-02 11:30:13', 0, 1),
(640966, 'Veera Suman Batchu', 'svrfnlr@gmail.com', '7702094268', 'Andhra Pradesh', 'India', '2019-10-02 11:30:13', 0, 0),
(317946, 'Sushobhan Pandey', 'pandeysushobhan7@gmail.com', '8759595977', 'TELANGANA', 'India', '2019-10-02 11:56:33', 0, 1),
(204431, 'Dharma Nanda Reddy Talugula', NULL, '9676939616', 'Andhrapradesh', 'India', '2019-10-02 19:12:26', 0, 0),
(290263, 'JAKKULA GOPALA RAO', 'gopalaraojgr@gmail.com', '7569808828', 'Telangana', 'India', '2019-10-02 19:14:38', 0, 1),
(72603, 'srinu vasulu', 'npdoIndia@gmail.com', '9440360507', 'Telangana', 'India', '2019-10-02 20:11:04', 0, 1),
(20276, 'Gampa Nageshwer Rao', 'gamparao@gmail.com', '9849000026', 'Telangana', 'India', '2019-10-02 20:17:26', 0, 1),
(243947, 'Akondi NVSS Pavan Kumar', 'pavanbhai82@gmail.com', '9885450524', 'ANDHRA PRADESH', 'Bhaarath', '2019-10-02 23:23:09', 0, 1),
(265488, 'Rachuri Srilekha', 'shree27997@gmail.com', '8121250170', 'Telangana', 'Indian', '2019-10-03 00:01:02', 0, 1),
(612965, 'T vijay kumar', 'vijaykumarsksecil@gmail.com', '9963906815', 'Telangana', 'India', '2019-10-03 00:14:31', 0, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `HRTVIK_events`
--
ALTER TABLE `HRTVIK_events`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `HRTVIK_gallery`
--
ALTER TABLE `HRTVIK_gallery`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Fk_eventid` (`eventid`);

--
-- Indexes for table `HRTVIK_OurTeam`
--
ALTER TABLE `HRTVIK_OurTeam`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `People`
--
ALTER TABLE `People`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `HRTVIK_events`
--
ALTER TABLE `HRTVIK_events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `HRTVIK_gallery`
--
ALTER TABLE `HRTVIK_gallery`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `HRTVIK_OurTeam`
--
ALTER TABLE `HRTVIK_OurTeam`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;