-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th4 01, 2024 lúc 10:23 AM
-- Phiên bản máy phục vụ: 10.4.28-MariaDB
-- Phiên bản PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `dotnet-7-dapper-crud-api1`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `author`
--

CREATE TABLE `author` (
  `author_id` int(11) NOT NULL,
  `author_name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `author`
--

INSERT INTO `author` (`author_id`, `author_name`) VALUES
(1, 'Author1'),
(2, 'Author2'),
(3, 'author_Gay Haag'),
(4, 'author_Rylan Kris'),
(5, 'author_Rosie Kautzer'),
(6, 'author_Tristin Bode'),
(7, 'author_Amy Collins'),
(8, 'author_Providenci Osinski DDS'),
(9, 'author_Vicky Flatley IV'),
(10, 'author_Margaret Torp'),
(11, 'author_Birdie Rippin III'),
(12, 'author_Joany Buckridge');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `category`
--

CREATE TABLE `category` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `category`
--

INSERT INTO `category` (`category_id`, `category_name`) VALUES
(1, 'Category1'),
(2, 'Category2'),
(3, 'Category3'),
(4, 'category_alias'),
(5, 'category_quibusdam'),
(6, 'category_possimus'),
(7, 'category_necessitatibus'),
(8, 'category_in'),
(9, 'category_aut'),
(10, 'category_recusandae'),
(11, 'category_tempora'),
(12, 'category_repellendus'),
(13, 'category_ut');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `orderdetail`
--

CREATE TABLE `orderdetail` (
  `order_detail_id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `order_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `orderdetail`
--

INSERT INTO `orderdetail` (`order_detail_id`, `product_id`, `order_id`) VALUES
(1, 2, 1),
(2, 3, 1),
(3, 3, 2),
(4, 43, 5),
(5, 24, 1),
(6, 21, 9),
(7, 38, 7),
(8, 45, 12),
(9, 18, 6),
(10, 8, 2),
(11, 49, 7),
(12, 36, 1),
(13, 42, 7),
(14, 27, 9),
(15, 10, 11),
(16, 16, 6),
(17, 23, 8),
(18, 52, 6),
(19, 12, 4),
(20, 13, 11),
(21, 23, 4),
(22, 19, 12),
(23, 34, 11),
(24, 50, 6),
(25, 22, 3),
(26, 42, 10),
(27, 26, 1),
(28, 21, 3),
(29, 45, 9),
(30, 3, 12),
(31, 43, 11),
(32, 42, 6),
(33, 48, 6),
(34, 15, 1),
(35, 16, 10),
(36, 32, 10),
(37, 14, 10),
(38, 32, 11),
(39, 25, 9),
(40, 20, 11),
(41, 52, 2),
(42, 44, 12),
(43, 53, 2),
(44, 40, 1),
(45, 27, 1),
(46, 32, 9),
(47, 7, 12),
(48, 21, 4),
(49, 38, 1),
(50, 3, 3),
(51, 16, 8),
(52, 26, 9),
(53, 5, 9);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `orders`
--

INSERT INTO `orders` (`order_id`, `user_id`, `order_date`) VALUES
(1, 4, '2024-04-01 09:26:51'),
(2, 3, '2024-04-01 09:26:51'),
(3, 2, '2024-01-22 03:43:18'),
(4, 6, '2024-03-06 08:36:35'),
(5, 2, '2024-03-22 13:55:30'),
(6, 14, '2024-01-10 21:33:07'),
(7, 6, '2024-03-19 03:15:23'),
(8, 13, '2024-01-10 09:38:56'),
(9, 2, '2024-02-19 01:08:55'),
(10, 4, '2024-03-15 14:31:20'),
(11, 4, '2024-02-11 04:08:48'),
(12, 12, '2024-02-28 22:13:38');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `product`
--

CREATE TABLE `product` (
  `product_id` int(11) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `author_id` int(11) DEFAULT NULL,
  `product_name` varchar(255) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `product`
--

INSERT INTO `product` (`product_id`, `category_id`, `author_id`, `product_name`, `price`, `description`) VALUES
(2, 2, 2, 'Product2', 888.88, 'Product2\'s description'),
(3, 3, 2, 'Product 3', 996.69, 'Description fo Product 3'),
(4, 11, 2, 'Id sit sit.', 237891.98, 'Odio delectus excepturi occaecati non nemo doloremque omnis et eum totam ex est.'),
(5, 4, 11, 'At autem repudiandae magni.', 377111.58, 'Consequatur magni nemo modi ut earum non omnis possimus aut impedit.'),
(6, 10, 11, 'Aliquam molestiae doloremque.', 544182.29, 'Voluptatem est repellat harum aut incidunt veritatis minus commodi similique voluptates beatae.'),
(7, 3, 10, 'Assumenda expedita ducimus.', 139123.21, 'Totam architecto in in labore et non expedita harum tempore commodi et.'),
(8, 9, 11, 'Iste pariatur qui placeat.', 664146.86, 'Exercitationem dolores ipsum eligendi quibusdam aperiam et sint.'),
(9, 6, 10, 'Minus ut aut eligendi.', 204734.37, 'Est ducimus debitis non voluptatem iure asperiores maxime vitae et provident est sunt.'),
(10, 11, 7, 'Quaerat pariatur enim.', 639490.31, 'Voluptatibus nesciunt voluptatibus aut accusamus deleniti culpa et quo aspernatur nostrum dolore earum perferendis.'),
(11, 4, 3, 'Dolorum voluptatem eos.', 700854.00, 'Veniam exercitationem quas est dolorum rerum facilis qui fuga perferendis sed beatae voluptate beatae.'),
(12, 7, 2, 'Accusantium consequuntur ut.', 351849.55, 'Id illum voluptatibus error doloremque corporis placeat.'),
(13, 2, 5, 'Cumque saepe unde officiis.', 193580.46, 'Veritatis est laboriosam eos sit id laborum omnis accusamus sit et veniam aut.'),
(14, 10, 1, 'Labore consequatur aliquid.', 276429.73, 'Odio sit itaque quam et molestiae repellat numquam rerum eos.'),
(15, 3, 8, 'Id rerum aut cupiditate.', 360999.16, 'Deleniti molestiae aut veniam aspernatur illum ut.'),
(16, 7, 12, 'Inventore consequuntur ut adipisci.', 697729.49, 'Eum quam iusto in molestias nihil quae quis est quia officia non beatae.'),
(17, 1, 4, 'Aut dolore.', 772372.91, 'Quod molestias voluptatem unde rerum qui quia.'),
(18, 2, 10, 'Mollitia velit ad.', 155432.24, 'Sit qui exercitationem consectetur et voluptate ea esse occaecati ut doloribus.'),
(19, 10, 5, 'Omnis est inventore magni.', 605055.00, 'Repellat maxime dolores rerum error velit perferendis necessitatibus et qui.'),
(20, 2, 5, 'Deleniti omnis et aut.', 829345.11, 'Vitae ab delectus minima et fuga libero facere.'),
(21, 9, 1, 'Ipsum consequuntur.', 801396.44, 'Deserunt aperiam deleniti eos qui repellendus vel.'),
(22, 6, 4, 'Placeat ab rem illo.', 19858.92, 'Tempora laborum cum voluptas odit velit est omnis et officia.'),
(23, 2, 6, 'Necessitatibus rerum enim sed.', 34231.36, 'Est aliquid adipisci quam autem omnis officiis ipsa voluptatem.'),
(24, 7, 6, 'Consequatur est ut.', 961852.76, 'Impedit itaque voluptatum ut dolores vitae modi sapiente quod ut.'),
(25, 10, 4, 'Perferendis illo quaerat repellendus.', 73818.34, 'Qui eos officia aliquid sequi eligendi laudantium a cum earum natus et.'),
(26, 10, 10, 'Voluptas ut numquam.', 188012.56, 'Eum neque ea nisi fugit omnis dolor aut nihil qui ut at earum.'),
(27, 13, 2, 'Cupiditate eos illo nemo.', 416051.95, 'Sunt exercitationem eaque mollitia ab nam et est tempore libero labore et voluptas.'),
(28, 11, 10, 'Et est distinctio.', 654041.95, 'Culpa aliquam id a quis eius in earum eum ratione dolor aut.'),
(29, 6, 12, 'Qui atque minus qui.', 389890.44, 'Omnis cupiditate cupiditate et consequatur necessitatibus dolorem architecto nulla et.'),
(30, 12, 12, 'Cumque molestias blanditiis.', 945908.66, 'Qui et cupiditate minima enim praesentium quaerat et aut laudantium et qui nihil.'),
(31, 10, 1, 'Maiores eaque nisi et qui.', 532876.24, 'Vel nesciunt enim omnis quidem reiciendis eveniet quidem doloribus dolor sed similique.'),
(32, 6, 9, 'Voluptate autem deserunt officiis.', 230246.15, 'Cum quo dolore dolorem dolore rerum assumenda.'),
(33, 3, 11, 'Hic qui vitae.', 631368.97, 'Ipsum cupiditate voluptas enim et ipsum cum necessitatibus earum voluptatibus dolorem facere vero voluptatibus.'),
(34, 11, 2, 'Recusandae quos ut suscipit.', 522735.46, 'Est ut cumque nemo eos soluta hic.'),
(35, 11, 1, 'Eum impedit iste.', 222502.67, 'Voluptatem nobis autem explicabo qui rerum pariatur esse.'),
(36, 2, 11, 'Iusto incidunt voluptatibus ex.', 845454.54, 'Ab neque voluptatem cupiditate numquam autem saepe aut.'),
(37, 13, 11, 'Quos nostrum tenetur amet.', 789217.41, 'Sunt et maxime consequatur impedit in placeat.'),
(38, 1, 11, 'Itaque quibusdam incidunt ab.', 309555.14, 'Suscipit aut illo est alias veniam quis mollitia asperiores quas perspiciatis mollitia ad.'),
(39, 10, 6, 'Ut error sit unde.', 950618.43, 'Cupiditate autem laboriosam inventore earum et fuga unde esse impedit natus.'),
(40, 3, 12, 'Nihil quis eveniet.', 975192.26, 'Dolorem possimus asperiores ea quas molestiae rerum perspiciatis nobis fugiat sit earum.'),
(41, 11, 12, 'Necessitatibus quidem aliquam est.', 539183.33, 'Velit earum cum ipsa odit dolores aliquam natus libero.'),
(42, 4, 10, 'Omnis eos.', 348422.71, 'Aut tenetur veritatis similique reprehenderit adipisci maiores est.'),
(43, 12, 6, 'Culpa sunt quas incidunt.', 82034.02, 'Qui nobis necessitatibus exercitationem ut quia sed aut sint sit amet quasi autem.'),
(44, 6, 7, 'Ea consectetur vel.', 185225.62, 'Eos vel consectetur a repellat ipsa nostrum ex nostrum quia id.'),
(45, 3, 7, 'Ut sed debitis aliquam.', 451513.66, 'Ea sapiente velit soluta ut nesciunt in tenetur reiciendis rerum accusantium et in.'),
(46, 5, 8, 'Non est itaque.', 486342.47, 'Voluptatem ipsum ut iste fuga deleniti inventore corrupti eum molestiae quia quos ut.'),
(47, 1, 1, 'Aliquid quas doloribus et.', 183876.40, 'Alias qui sed et vitae et dolor odio est eos laborum nulla.'),
(48, 13, 10, 'Error sunt ad.', 817280.88, 'Quia consequuntur architecto consequuntur aliquid laboriosam sit praesentium velit dolorem.'),
(49, 2, 10, 'Sit expedita vero ipsum.', 197613.65, 'Est voluptatibus nulla qui provident eos excepturi repellendus omnis modi officiis dolor rerum.'),
(50, 13, 3, 'Sint dolorem architecto nobis.', 741579.30, 'Quia commodi odit incidunt accusamus modi aperiam veritatis eligendi sed autem alias excepturi occaecati.'),
(51, 11, 10, 'Odit amet voluptatibus.', 60995.11, 'Corporis dolores iusto maxime veritatis voluptatem velit sit nesciunt omnis eveniet impedit blanditiis rem architecto.'),
(52, 10, 11, 'Esse sit corporis.', 222107.60, 'Sunt optio aut labore atque molestiae eligendi non quia corrupti veniam repellendus.'),
(53, 11, 12, 'Eius ullam ea excepturi.', 431122.53, 'Omnis corrupti voluptatibus unde nobis nisi temporibus impedit neque facilis facilis.');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `productimage`
--

CREATE TABLE `productimage` (
  `image_id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `image_url` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `productimage`
--

INSERT INTO `productimage` (`image_id`, `product_id`, `image_url`) VALUES
(4, 2, 'https://i.ytimg.com/vi/AnzCuOiuLBI/maxresdefault.jpg'),
(8, 2, 'https://i.pinimg.com/736x/11/8c/d4/118cd4868c2a0c32f41c88d3ffa18a46.jpg'),
(9, 3, 'https://upload.wikimedia.org/wikipedia/vi/2/26/Dragon_Ball_GT_Volume_1.jpg'),
(10, 3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6Rdl5PmfRL8Vz_0PXhsEWZpT7s6lQcC0heuayskk1s1cUCVDSQwSwBHxvZA-nl5kbmds&usqp=CAU'),
(11, 2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4L7p3KY0RE3cIxwwPpK1N-uoeDo0NQ7-awNcSYOJ-0Q&s'),
(12, 39, 'https://tranh3dntp.com/wp-content/uploads/2023/04/1-1.jpg'),
(13, 34, 'https://i.pinimg.com/736x/11/8c/d4/118cd4868c2a0c32f41c88d3ffa18a46.jpg'),
(14, 49, 'https://tranhsondau79.com/wp-content/uploads/2021/09/tranh-phong-canh-dong-que-1.jpeg'),
(15, 40, 'https://tranhsondau79.com/wp-content/uploads/2021/09/tranh-phong-canh-dong-que-1.jpeg'),
(16, 21, 'https://i.pinimg.com/736x/11/8c/d4/118cd4868c2a0c32f41c88d3ffa18a46.jpg'),
(17, 14, 'https://tranhsondau79.com/wp-content/uploads/2021/09/tranh-phong-canh-dong-que-1.jpeg'),
(18, 8, 'https://tranhsondau79.com/wp-content/uploads/2021/09/tranh-phong-canh-dong-que-1.jpeg'),
(19, 20, 'https://bizweb.dktcdn.net/100/460/952/articles/hoa-si-vicent-van-gogh.jpeg?v=1688554091337'),
(20, 9, 'https://kenh14cdn.com/thumb_w/660/2018/7/24/mu925-1000x1000-15324091401971245330638.jpg'),
(21, 40, 'https://tranhsondau79.com/wp-content/uploads/2021/09/tranh-phong-canh-dong-que-1.jpeg'),
(22, 16, 'https://tranhphongthuyvietnam.com/wp-content/uploads/2022/03/tranh-ruong-bac-thang-dep-y-nghia.jpg'),
(23, 32, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYmTqRj3r81UYe5gQWEgkoFYkDqBGQLGOmBOG3ginJfg&s'),
(24, 11, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYmTqRj3r81UYe5gQWEgkoFYkDqBGQLGOmBOG3ginJfg&s'),
(25, 40, 'https://imagev3.vietnamplus.vn/w1000/Uploaded/2024/tpuohuo/2021_09_22/hanoirong.jpeg.webp'),
(26, 53, 'https://tranh3dntp.com/wp-content/uploads/2023/04/1-1.jpg'),
(27, 25, 'https://tranhsondau79.com/wp-content/uploads/2021/09/tranh-phong-canh-dong-que-1.jpeg'),
(28, 28, 'https://kenh14cdn.com/thumb_w/660/2018/7/24/mu925-1000x1000-15324091401971245330638.jpg'),
(29, 30, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4L7p3KY0RE3cIxwwPpK1N-uoeDo0NQ7-awNcSYOJ-0Q&s'),
(30, 10, 'https://hoanghamobile.com/tin-tuc/wp-content/uploads/2023/08/tranh-phong-canh-16.jpg'),
(31, 50, 'https://tranhphongthuyvietnam.com/wp-content/uploads/2022/03/tranh-ruong-bac-thang-dep-y-nghia.jpg'),
(32, 48, 'https://kenh14cdn.com/thumb_w/660/2018/7/24/mu925-1000x1000-15324091401971245330638.jpg'),
(33, 47, 'https://upload.wikimedia.org/wikipedia/vi/2/26/Dragon_Ball_GT_Volume_1.jpg'),
(34, 45, 'https://tranhphongthuyvietnam.com/wp-content/uploads/2022/03/tranh-ruong-bac-thang-dep-y-nghia.jpg'),
(35, 51, 'https://i.pinimg.com/736x/11/8c/d4/118cd4868c2a0c32f41c88d3ffa18a46.jpg'),
(36, 5, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYmTqRj3r81UYe5gQWEgkoFYkDqBGQLGOmBOG3ginJfg&s'),
(37, 18, 'https://i.pinimg.com/736x/11/8c/d4/118cd4868c2a0c32f41c88d3ffa18a46.jpg'),
(38, 5, 'https://tranhphongthuyvietnam.com/wp-content/uploads/2022/03/tranh-ruong-bac-thang-dep-y-nghia.jpg'),
(39, 25, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6Rdl5PmfRL8Vz_0PXhsEWZpT7s6lQcC0heuayskk1s1cUCVDSQwSwBHxvZA-nl5kbmds&usqp=CAU'),
(40, 45, 'https://imagev3.vietnamplus.vn/w1000/Uploaded/2024/tpuohuo/2021_09_22/hanoirong.jpeg.webp'),
(41, 25, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6Rdl5PmfRL8Vz_0PXhsEWZpT7s6lQcC0heuayskk1s1cUCVDSQwSwBHxvZA-nl5kbmds&usqp=CAU'),
(42, 18, 'https://tranh3dntp.com/wp-content/uploads/2023/04/1-1.jpg'),
(43, 10, 'https://kenh14cdn.com/thumb_w/660/2018/7/24/mu925-1000x1000-15324091401971245330638.jpg'),
(44, 10, 'https://imagev3.vietnamplus.vn/w1000/Uploaded/2024/tpuohuo/2021_09_22/hanoirong.jpeg.webp'),
(45, 34, 'https://bizweb.dktcdn.net/100/460/952/articles/hoa-si-vicent-van-gogh.jpeg?v=1688554091337'),
(46, 34, 'https://tranhphongthuyvietnam.com/wp-content/uploads/2022/03/tranh-ruong-bac-thang-dep-y-nghia.jpg'),
(47, 50, 'https://kenh14cdn.com/thumb_w/660/2018/7/24/mu925-1000x1000-15324091401971245330638.jpg'),
(48, 36, 'https://i.ytimg.com/vi/AnzCuOiuLBI/maxresdefault.jpg'),
(49, 48, 'https://i.pinimg.com/736x/11/8c/d4/118cd4868c2a0c32f41c88d3ffa18a46.jpg'),
(50, 7, 'https://i.ytimg.com/vi/AnzCuOiuLBI/maxresdefault.jpg'),
(51, 18, 'https://tranhphongthuyvietnam.com/wp-content/uploads/2022/03/tranh-ruong-bac-thang-dep-y-nghia.jpg'),
(52, 13, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYmTqRj3r81UYe5gQWEgkoFYkDqBGQLGOmBOG3ginJfg&s'),
(53, 4, 'https://hoanghamobile.com/tin-tuc/wp-content/uploads/2023/08/tranh-phong-canh-16.jpg'),
(54, 32, 'https://upload.wikimedia.org/wikipedia/vi/2/26/Dragon_Ball_GT_Volume_1.jpg'),
(55, 18, 'https://upload.wikimedia.org/wikipedia/vi/2/26/Dragon_Ball_GT_Volume_1.jpg'),
(56, 16, 'https://hoanghamobile.com/tin-tuc/wp-content/uploads/2023/08/tranh-phong-canh-16.jpg'),
(57, 40, 'https://upload.wikimedia.org/wikipedia/vi/2/26/Dragon_Ball_GT_Volume_1.jpg'),
(58, 45, 'https://i.pinimg.com/736x/11/8c/d4/118cd4868c2a0c32f41c88d3ffa18a46.jpg'),
(59, 3, 'https://hoanghamobile.com/tin-tuc/wp-content/uploads/2023/08/tranh-phong-canh-16.jpg'),
(60, 28, 'https://hoanghamobile.com/tin-tuc/wp-content/uploads/2023/08/tranh-phong-canh-16.jpg'),
(61, 5, 'https://bizweb.dktcdn.net/100/460/952/articles/hoa-si-vicent-van-gogh.jpeg?v=1688554091337');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `producttag`
--

CREATE TABLE `producttag` (
  `product_tag_id` int(11) NOT NULL,
  `tag_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `producttag`
--

INSERT INTO `producttag` (`product_tag_id`, `tag_id`, `product_id`) VALUES
(4, 2, 2),
(5, 3, 2),
(6, 4, 2),
(7, 2, 3),
(8, 4, 3),
(9, 2, 32),
(10, 6, 10),
(11, 13, 30),
(12, 7, 15),
(13, 10, 39),
(14, 13, 12),
(15, 4, 50),
(16, 13, 44),
(17, 14, 43),
(18, 9, 42),
(19, 9, 2),
(20, 14, 48),
(21, 1, 45),
(22, 1, 13),
(23, 2, 24),
(24, 7, 34),
(25, 13, 43),
(26, 7, 16),
(27, 11, 4),
(28, 3, 37),
(29, 5, 43),
(30, 3, 9),
(31, 1, 3),
(32, 8, 7),
(33, 13, 12),
(34, 11, 39),
(35, 14, 24),
(36, 14, 34),
(37, 10, 32),
(38, 11, 47),
(39, 5, 7),
(40, 5, 8),
(41, 4, 38),
(42, 14, 38),
(43, 2, 2),
(44, 6, 51),
(45, 10, 29),
(46, 2, 35),
(47, 12, 51),
(48, 5, 49),
(49, 12, 47),
(50, 14, 19),
(51, 5, 39),
(52, 5, 33),
(53, 7, 27),
(54, 10, 46),
(55, 7, 20),
(56, 10, 2),
(57, 2, 31),
(58, 2, 32);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tag`
--

CREATE TABLE `tag` (
  `tag_id` int(11) NOT NULL,
  `tag_name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `tag`
--

INSERT INTO `tag` (`tag_id`, `tag_name`) VALUES
(1, 'Tag1'),
(2, 'Tag2'),
(3, 'Tag3'),
(4, 'Tag4'),
(5, 'tag_quae'),
(6, 'tag_id'),
(7, 'tag_dolor'),
(8, 'tag_nihil'),
(9, 'tag_distinctio'),
(10, 'tag_rerum'),
(11, 'tag_quis'),
(12, 'tag_reprehenderit'),
(13, 'tag_corrupti'),
(14, 'tag_officiis');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `group_id` int(11) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `user`
--

INSERT INTO `user` (`user_id`, `group_id`, `username`, `password`) VALUES
(2, 1, 'Admin1', '123'),
(3, 2, 'User1', '123'),
(4, 2, 'Test123', '$2a$11$ENRaJBIZ7EArRJn4zlLHZ.t7Idl3tBQQ.BJeMv76QRwYxOuSV4OU.'),
(5, 2, 'roob.deanna', '9fa(&g~yen,*@{IoR2'),
(6, 1, 'jillian63', '01P|Co'),
(7, 3, 'phoebe.schmidt', 'kcFas4EIm'),
(8, 1, 'jessica83', 'erm9:q%u'),
(9, 3, 'ernestine89', 's5\'YX9);IyJ'),
(10, 2, 'collins.keagan', 'J24Hk0IsO+9bJpi73'),
(11, 2, 'yfeil', 'uEJq2IVP?4M/02~'),
(12, 2, 'tyrique19', 'mRlJ||0|\\sR=70|aBO'),
(13, 3, 'ashley.gerhold', 'fC.={P9='),
(14, 2, 'steve.wilderman', '0qj5CdgSUC*163');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `usergroup`
--

CREATE TABLE `usergroup` (
  `group_id` int(11) NOT NULL,
  `group_name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `usergroup`
--

INSERT INTO `usergroup` (`group_id`, `group_name`) VALUES
(1, 'Admin'),
(2, 'User'),
(3, 'Modifier');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `userprofile`
--

CREATE TABLE `userprofile` (
  `profile_id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fullname` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `userprofile`
--

INSERT INTO `userprofile` (`profile_id`, `user_id`, `fullname`, `phone`, `email`, `address`) VALUES
(1, 2, 'Administrator', '0123456789', 'admin1@mini.com', 'London'),
(2, 3, 'Unknown User 1', '0123456788', 'user1@unknown.com', 'Anonymous'),
(3, 2, 'Lula Renner', '+1 (938) 318-7985', 'rowland.flatley@yahoo.com', '97899 Chadd Loop\nConnfort, AZ 18885-9868'),
(4, 3, 'Deangelo Hammes', '727-434-1761', 'blick.brock@heathcote.biz', '25942 Boehm Park Suite 368\nAlveramouth, KY 87089'),
(5, 4, 'Kaleigh Crooks PhD', '480-647-6721', 'helene.gislason@murphy.com', '146 Talon Hills Apt. 521\nSouth Miguel, TN 13466-3500'),
(6, 5, 'Nathen Homenick', '+1-772-696-7780', 'osborne97@white.com', '876 Boyer Rapid\nBergeport, ME 30710'),
(7, 6, 'Prof. Cecilia Beahan MD', '253-483-5793', 'nathan86@hotmail.com', '8569 Vicente Ports Suite 659\nBrooklynfurt, AK 75437'),
(8, 7, 'Prof. Pablo Schowalter I', '+1-458-447-6047', 'rosella75@hotmail.com', '870 Richie Lakes\nPort Tyshawnville, VT 33032'),
(9, 8, 'Lilyan Beer', '1-586-630-5536', 'windler.haylee@damore.com', '931 Jaleel Forges\nRueckerville, DC 40001'),
(10, 9, 'Julien Ryan', '351-213-0722', 'watsica.norma@gmail.com', '565 Ryder Walks\nNew Hillary, VA 82318-1031'),
(11, 10, 'Queenie Fadel IV', '+1-216-454-1850', 'bstoltenberg@kunde.com', '650 Meta Islands Apt. 352\nSouth Dawnfurt, KS 56315-4310'),
(12, 11, 'Shawn Crooks', '1-385-518-7704', 'berge.florence@gmail.com', '525 Roxane Meadows Suite 931\nMarjoriemouth, AR 76700-1357'),
(13, 12, 'Prof. Leonardo McKenzie Jr.', '+1-210-746-9153', 'warren.langworth@gottlieb.info', '63525 Franco Manors Apt. 501\nPort Jodie, UT 82766-3276'),
(14, 13, 'Kyleigh Block', '(949) 828-3956', 'stokes.winona@hotmail.com', '3155 Jenkins Lane\nJarentown, AZ 00443'),
(15, 14, 'Herbert Hansen IV', '+1-559-584-9096', 'raegan.bogan@bahringer.info', '805 Mckayla Villages\nMichaelamouth, NV 85852-4634');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `author`
--
ALTER TABLE `author`
  ADD PRIMARY KEY (`author_id`);

--
-- Chỉ mục cho bảng `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`category_id`);

--
-- Chỉ mục cho bảng `orderdetail`
--
ALTER TABLE `orderdetail`
  ADD PRIMARY KEY (`order_detail_id`),
  ADD KEY `order_id` (`order_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Chỉ mục cho bảng `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Chỉ mục cho bảng `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `category_id` (`category_id`),
  ADD KEY `author_id` (`author_id`);

--
-- Chỉ mục cho bảng `productimage`
--
ALTER TABLE `productimage`
  ADD PRIMARY KEY (`image_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Chỉ mục cho bảng `producttag`
--
ALTER TABLE `producttag`
  ADD PRIMARY KEY (`product_tag_id`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `tag_id` (`tag_id`);

--
-- Chỉ mục cho bảng `tag`
--
ALTER TABLE `tag`
  ADD PRIMARY KEY (`tag_id`);

--
-- Chỉ mục cho bảng `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`),
  ADD KEY `group_id` (`group_id`);

--
-- Chỉ mục cho bảng `usergroup`
--
ALTER TABLE `usergroup`
  ADD PRIMARY KEY (`group_id`);

--
-- Chỉ mục cho bảng `userprofile`
--
ALTER TABLE `userprofile`
  ADD PRIMARY KEY (`profile_id`),
  ADD KEY `user_id` (`user_id`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `author`
--
ALTER TABLE `author`
  MODIFY `author_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT cho bảng `category`
--
ALTER TABLE `category`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT cho bảng `orderdetail`
--
ALTER TABLE `orderdetail`
  MODIFY `order_detail_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT cho bảng `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT cho bảng `product`
--
ALTER TABLE `product`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT cho bảng `productimage`
--
ALTER TABLE `productimage`
  MODIFY `image_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;

--
-- AUTO_INCREMENT cho bảng `producttag`
--
ALTER TABLE `producttag`
  MODIFY `product_tag_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;

--
-- AUTO_INCREMENT cho bảng `tag`
--
ALTER TABLE `tag`
  MODIFY `tag_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT cho bảng `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT cho bảng `usergroup`
--
ALTER TABLE `usergroup`
  MODIFY `group_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `userprofile`
--
ALTER TABLE `userprofile`
  MODIFY `profile_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `orderdetail`
--
ALTER TABLE `orderdetail`
  ADD CONSTRAINT `orderdetail_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `orderdetail_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `product_ibfk_2` FOREIGN KEY (`author_id`) REFERENCES `author` (`author_id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `productimage`
--
ALTER TABLE `productimage`
  ADD CONSTRAINT `productimage_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `producttag`
--
ALTER TABLE `producttag`
  ADD CONSTRAINT `producttag_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `producttag_ibfk_2` FOREIGN KEY (`tag_id`) REFERENCES `tag` (`tag_id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`group_id`) REFERENCES `usergroup` (`group_id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `userprofile`
--
ALTER TABLE `userprofile`
  ADD CONSTRAINT `userprofile_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
