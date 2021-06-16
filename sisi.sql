/*
Navicat MySQL Data Transfer

Source Server         : mysql_135
Source Server Version : 50539
Source Host           : 103.75.237.4:3306
Source Database       : sisi

Target Server Type    : MYSQL
Target Server Version : 50539
File Encoding         : 65001

Date: 2021-06-16 17:55:37
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tm_anggota`
-- ----------------------------
DROP TABLE IF EXISTS `tm_anggota`;
CREATE TABLE `tm_anggota` (
  `anggota_no` varchar(6) NOT NULL,
  `anggota_nipp` varchar(8) DEFAULT NULL,
  `anggota_nama` varchar(255) DEFAULT NULL,
  `anggota_jab` varchar(255) DEFAULT NULL,
  `anggota_dept` varchar(3) NOT NULL,
  `tm_anggotaup` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `userid` int(3) NOT NULL,
  PRIMARY KEY (`anggota_no`),
  KEY `anggota_dept` (`anggota_dept`),
  KEY `anggota_index` (`userid`,`anggota_dept`) USING BTREE,
  CONSTRAINT `tm_anggota_ibfk_1` FOREIGN KEY (`anggota_dept`) REFERENCES `tr_dept` (`dept_id`),
  CONSTRAINT `tm_anggota_ibfk_2` FOREIGN KEY (`userid`) REFERENCES `user` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of tm_anggota
-- ----------------------------
INSERT INTO `tm_anggota` VALUES ('000001', '15030530', 'Yogi Misbahudin', 'Pelaksana', '115', '2021-03-23 08:55:20', '111');
INSERT INTO `tm_anggota` VALUES ('000002', '15070537', 'Birda Ariyadi Septian', 'Pelaksana Perangkat Lunak', '115', '2021-03-30 11:04:57', '111');
INSERT INTO `tm_anggota` VALUES ('000003', '15080540', 'Asep Suprapto', 'Pelaksana', '116', '2021-04-06 08:37:23', '111');
INSERT INTO `tm_anggota` VALUES ('000004', '15080541', 'Tika Sumarti', 'Pelaksana GIS', '118', '2021-04-21 11:52:40', '112');
INSERT INTO `tm_anggota` VALUES ('000005', '15080542', 'Rikman Kartono', 'Pelaksana', '114', '2021-04-06 08:43:53', '113');
INSERT INTO `tm_anggota` VALUES ('000006', '16050621', 'Sahar Rubi', 'Pelaksana PL', '131', '2021-04-21 11:48:18', '112');
INSERT INTO `tm_anggota` VALUES ('000007', '16050622', 'Zambrud Hilal', 'Pelaksana Gudang', '136', '2021-04-21 11:51:08', '112');
INSERT INTO `tm_anggota` VALUES ('000008', '15096728', 'Salman', 'Pelaksana Kas', '121', '2021-04-21 20:27:17', '111');

-- ----------------------------
-- Table structure for `tm_angsur`
-- ----------------------------
DROP TABLE IF EXISTS `tm_angsur`;
CREATE TABLE `tm_angsur` (
  `angsur_no` varchar(11) NOT NULL,
  `angsur_id` varchar(11) NOT NULL,
  `angsur_tggl` date DEFAULT NULL,
  `angsur_ke` varchar(4) DEFAULT NULL,
  `angsur_jumlah` double DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  `tm_angsurup` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`angsur_no`),
  KEY `angsur_index` (`angsur_id`) USING BTREE,
  CONSTRAINT `tm_angsur_ibfk_1` FOREIGN KEY (`angsur_id`) REFERENCES `tm_pinjaman` (`pjm_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of tm_angsur
-- ----------------------------
INSERT INTO `tm_angsur` VALUES ('20210614001', '217071', '2021-04-15', '1', '2525000', '0', '2021-06-16 16:34:19');
INSERT INTO `tm_angsur` VALUES ('20210614002', '217071', '2021-05-15', '2', '2525000', '0', '2021-06-16 16:34:20');
INSERT INTO `tm_angsur` VALUES ('20210614003', '217071', '2021-06-15', '3', '2525000', '0', '2021-06-16 16:34:24');
INSERT INTO `tm_angsur` VALUES ('20210614004', '217071', '2021-07-15', '4', '2525000', '0', '2021-06-14 08:22:15');
INSERT INTO `tm_angsur` VALUES ('20210614005', '217071', '2021-08-15', '5', '2525000', '0', '2021-06-14 08:22:15');
INSERT INTO `tm_angsur` VALUES ('20210614006', '217071', '2021-09-15', '6', '2525000', '0', '2021-06-14 08:22:15');
INSERT INTO `tm_angsur` VALUES ('20210614007', '039320', '2021-04-15', '1', '1683333', '1', '2021-06-16 15:21:58');
INSERT INTO `tm_angsur` VALUES ('20210614008', '039320', '2021-05-15', '2', '1683333', '1', '2021-06-16 15:21:58');
INSERT INTO `tm_angsur` VALUES ('20210614009', '039320', '2021-06-15', '3', '1683333', '1', '2021-06-16 15:21:58');

-- ----------------------------
-- Table structure for `tm_pinjaman`
-- ----------------------------
DROP TABLE IF EXISTS `tm_pinjaman`;
CREATE TABLE `tm_pinjaman` (
  `pjm_no` varchar(6) NOT NULL,
  `pjm_id` varchar(6) NOT NULL,
  `pjm_tggl` date DEFAULT NULL,
  `pjm_tenor` varchar(4) DEFAULT '',
  `pjm_tgglend` date DEFAULT NULL,
  `pjm_pokok` double DEFAULT NULL,
  `pjm_keperluan` varchar(255) DEFAULT NULL,
  `cicilan_pokok` double DEFAULT NULL,
  `cicilan_bunga` double DEFAULT NULL,
  `cicilan_total` double DEFAULT NULL,
  `pjm_total` double DEFAULT NULL,
  `pjm_stat` int(1) NOT NULL,
  `tm_pinjamanup` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `userid` int(3) NOT NULL,
  `ket` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`pjm_no`),
  KEY `userid` (`userid`),
  KEY `pinjam_index` (`pjm_id`,`userid`) USING BTREE,
  CONSTRAINT `tm_pinjaman_ibfk_1` FOREIGN KEY (`userid`) REFERENCES `user` (`userid`),
  CONSTRAINT `tm_pinjaman_ibfk_2` FOREIGN KEY (`pjm_id`) REFERENCES `tm_anggota` (`anggota_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of tm_pinjaman
-- ----------------------------
INSERT INTO `tm_pinjaman` VALUES ('039320', '000003', '2021-03-14', '3', '2021-06-15', '5000000', 'pendidikan', '1666667', '16667', '1683333', '5050000', '1', '2021-06-14 08:26:09', '112', null);
INSERT INTO `tm_pinjaman` VALUES ('217071', '000001', '2021-03-14', '6', '2021-09-15', '15000000', 'pendidikan', '2500000', '25000', '2525000', '15150000', '1', '2021-06-14 08:22:15', '112', null);

-- ----------------------------
-- Table structure for `tm_simpanan`
-- ----------------------------
DROP TABLE IF EXISTS `tm_simpanan`;
CREATE TABLE `tm_simpanan` (
  `simpanan_id` varchar(6) NOT NULL,
  `simpanan_tipe` int(2) NOT NULL,
  `simpanan_jumlah` double DEFAULT NULL,
  `simpanan_tggl` date DEFAULT NULL,
  `tm_simpananup` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `userid` int(3) NOT NULL,
  `uuid` binary(16) NOT NULL,
  PRIMARY KEY (`simpanan_id`,`uuid`),
  KEY `userid` (`userid`),
  KEY `simpanan_tipe` (`simpanan_tipe`),
  KEY `simpan_index` (`simpanan_id`,`simpanan_tipe`,`userid`) USING BTREE,
  CONSTRAINT `tm_simpanan_ibfk_1` FOREIGN KEY (`userid`) REFERENCES `user` (`userid`),
  CONSTRAINT `tm_simpanan_ibfk_2` FOREIGN KEY (`simpanan_id`) REFERENCES `tm_anggota` (`anggota_no`),
  CONSTRAINT `tm_simpanan_ibfk_3` FOREIGN KEY (`simpanan_tipe`) REFERENCES `tr_simpanan` (`js_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of tm_simpanan
-- ----------------------------
INSERT INTO `tm_simpanan` VALUES ('000001', '2', '50000', '2021-04-01', '2021-04-05 11:26:23', '111', 0x31343663646562302D393563372D3131);
INSERT INTO `tm_simpanan` VALUES ('000001', '2', '50000', '2021-04-06', '2021-04-05 13:28:32', '111', 0x32346435636438392D393564382D3131);
INSERT INTO `tm_simpanan` VALUES ('000001', '1', '1000000', '2021-04-01', '2021-04-05 11:25:08', '111', 0x65376239393538312D393563362D3131);
INSERT INTO `tm_simpanan` VALUES ('000002', '2', '50000', '2021-04-01', '2021-04-05 13:22:50', '111', 0x35393032346266392D393564372D3131);
INSERT INTO `tm_simpanan` VALUES ('000002', '1', '1000000', '2021-04-01', '2021-04-05 13:18:07', '111', 0x61666637653361632D393564362D3131);
INSERT INTO `tm_simpanan` VALUES ('000008', '1', '100000', '2021-04-21', '2021-04-21 20:29:01', '111', 0x38386263616666622D613261352D3131);

-- ----------------------------
-- Table structure for `tr_dept`
-- ----------------------------
DROP TABLE IF EXISTS `tr_dept`;
CREATE TABLE `tr_dept` (
  `dept_id` varchar(3) NOT NULL,
  `dept_nama` varchar(255) DEFAULT NULL,
  `tr_deptup` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`dept_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of tr_dept
-- ----------------------------
INSERT INTO `tr_dept` VALUES ('111', 'SPI', '2021-03-19 13:32:01');
INSERT INTO `tr_dept` VALUES ('112', 'Litbang', '2021-04-09 13:30:25');
INSERT INTO `tr_dept` VALUES ('114', 'SDM', '2021-03-19 13:32:01');
INSERT INTO `tr_dept` VALUES ('115', 'Teknologi Informasi', '2021-04-09 13:28:40');
INSERT INTO `tr_dept` VALUES ('116', 'Keuangan', '2021-04-09 13:30:36');
INSERT INTO `tr_dept` VALUES ('117', 'Produksi', '2021-04-09 13:31:04');
INSERT INTO `tr_dept` VALUES ('118', 'Perencanaan', '2021-04-09 13:30:52');
INSERT INTO `tr_dept` VALUES ('119', 'Umum', '2021-04-09 13:30:58');
INSERT INTO `tr_dept` VALUES ('121', 'KP. Soreang', '2021-04-09 13:31:14');
INSERT INTO `tr_dept` VALUES ('122', 'KP. Banjaran', '2021-04-09 13:31:20');
INSERT INTO `tr_dept` VALUES ('123', 'KP. Pangalengan', '2021-04-09 13:31:26');
INSERT INTO `tr_dept` VALUES ('126', 'KP. Ciparay', '2021-04-09 13:31:32');
INSERT INTO `tr_dept` VALUES ('127', 'KP. Baleendah', '2021-04-09 13:31:39');
INSERT INTO `tr_dept` VALUES ('130', 'KP. Majalaya', '2021-04-09 13:31:45');
INSERT INTO `tr_dept` VALUES ('131', 'KP. Rancaekek', '2021-04-09 13:31:53');
INSERT INTO `tr_dept` VALUES ('133', 'KP. Cileunyi', '2021-04-09 13:32:02');
INSERT INTO `tr_dept` VALUES ('134', 'KP. Cicalengka', '2021-04-09 13:32:09');
INSERT INTO `tr_dept` VALUES ('136', 'KP. Padalarang', '2021-04-09 13:32:17');
INSERT INTO `tr_dept` VALUES ('138', 'KP. Cisarua', '2021-04-09 13:32:24');
INSERT INTO `tr_dept` VALUES ('140', 'KP. Lembang', '2021-04-09 13:32:30');
INSERT INTO `tr_dept` VALUES ('142', 'KP. Cililin', '2021-04-09 13:32:41');
INSERT INTO `tr_dept` VALUES ('144', 'KP. Batujajar', '2021-04-09 13:32:50');
INSERT INTO `tr_dept` VALUES ('146', 'KP. Cimahi', '2021-04-09 13:32:57');
INSERT INTO `tr_dept` VALUES ('148', 'IPA Cikoneng', '2021-04-09 13:33:08');
INSERT INTO `tr_dept` VALUES ('149', 'IPA Sukamaju', '2021-04-09 13:33:16');
INSERT INTO `tr_dept` VALUES ('152', 'Distribusi & ATR', '2021-04-09 13:33:31');
INSERT INTO `tr_dept` VALUES ('154', 'Laboratorium', '2021-04-09 13:33:44');
INSERT INTO `tr_dept` VALUES ('155', 'SEKPER', '2021-04-09 13:34:06');
INSERT INTO `tr_dept` VALUES ('156', 'IPA Sadu', '2021-04-09 13:34:12');

-- ----------------------------
-- Table structure for `tr_simpanan`
-- ----------------------------
DROP TABLE IF EXISTS `tr_simpanan`;
CREATE TABLE `tr_simpanan` (
  `js_id` int(2) NOT NULL AUTO_INCREMENT,
  `js_nama` varchar(255) DEFAULT NULL,
  `tr_simpananup` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`js_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of tr_simpanan
-- ----------------------------
INSERT INTO `tr_simpanan` VALUES ('1', 'Pokok', '2021-03-19 13:14:08');
INSERT INTO `tr_simpanan` VALUES ('2', 'Wajib', '2021-03-19 13:14:18');

-- ----------------------------
-- Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `userid` int(3) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `pwd` varchar(255) DEFAULT NULL,
  `userup` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('111', 'Administrator', '33354741122871651676713774147412831195', '2021-04-21 10:42:33');
INSERT INTO `user` VALUES ('112', 'Ibrohim', '33354741122871651676713774147412831195', '2021-03-30 11:06:26');
INSERT INTO `user` VALUES ('113', 'Salman', '33354741122871651676713774147412831195', '2021-03-30 11:06:32');

-- ----------------------------
-- View structure for `v_anggota`
-- ----------------------------
DROP VIEW IF EXISTS `v_anggota`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `v_anggota` AS select `tm_anggota`.`anggota_no` AS `anggota_no`,`tm_anggota`.`anggota_nipp` AS `anggota_nipp`,`tm_anggota`.`anggota_nama` AS `anggota_nama`,`tm_anggota`.`anggota_jab` AS `anggota_jab`,`tr_dept`.`dept_nama` AS `dept_nama`,`tr_dept`.`dept_id` AS `dept_id` from (`tm_anggota` join `tr_dept` on((`tm_anggota`.`anggota_dept` = `tr_dept`.`dept_id`))) ;

-- ----------------------------
-- View structure for `v_bayarangsur`
-- ----------------------------
DROP VIEW IF EXISTS `v_bayarangsur`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `v_bayarangsur` AS select `tm_angsur`.`angsur_no` AS `angsur_no`,`tm_angsur`.`angsur_id` AS `angsur_id`,date_format(`tm_angsur`.`angsur_tggl`,'%d %M %Y') AS `angsur_tggl`,`tm_angsur`.`angsur_ke` AS `angsur_ke`,format(`tm_angsur`.`angsur_jumlah`,2,'de_DE') AS `angsur_jumlah`,`tm_angsur`.`status` AS `status`,`tm_angsur`.`tm_angsurup` AS `tm_angsurup`,`tm_pinjaman`.`pjm_id` AS `pjm_id`,`tm_anggota`.`anggota_no` AS `anggota_no`,`tm_anggota`.`anggota_nipp` AS `anggota_nipp`,`tm_anggota`.`anggota_nama` AS `anggota_nama`,`tm_anggota`.`anggota_jab` AS `anggota_jab`,`tr_dept`.`dept_nama` AS `dept_nama`,`tm_angsur`.`angsur_jumlah` AS `tmp_angsur` from (((`tm_angsur` join `tm_pinjaman` on((`tm_angsur`.`angsur_id` = `tm_pinjaman`.`pjm_no`))) join `tm_anggota` on((`tm_pinjaman`.`pjm_id` = `tm_anggota`.`anggota_no`))) join `tr_dept` on((`tm_anggota`.`anggota_dept` = `tr_dept`.`dept_id`))) where ((`tm_angsur`.`angsur_tggl` <= curdate()) and (`tm_angsur`.`status` = 0)) ;

-- ----------------------------
-- View structure for `v_cekangsur`
-- ----------------------------
DROP VIEW IF EXISTS `v_cekangsur`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `v_cekangsur` AS select `tm_angsur`.`angsur_no` AS `angsur_no`,`tm_angsur`.`angsur_ke` AS `angsur_ke`,date_format(`tm_angsur`.`angsur_tggl`,'%d %M %Y') AS `angsur_tggl`,format(`tm_angsur`.`angsur_jumlah`,2,'de_DE') AS `angsur_jumlah`,if((`tm_angsur`.`status` = 0),'Belum Dibayar','Lunas') AS `status`,`tm_angsur`.`angsur_id` AS `angsur_id` from `tm_angsur` ;

-- ----------------------------
-- View structure for `v_dashboard`
-- ----------------------------
DROP VIEW IF EXISTS `v_dashboard`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `v_dashboard` AS select (select format(count(`tm_anggota`.`anggota_no`),0) from `tm_anggota`) AS `jmlh_anggota`,(select sum(`tm_simpanan`.`simpanan_jumlah`) from `tm_simpanan`) AS `jmlh_simpanan`,(select sum(`tm_pinjaman`.`pjm_pokok`) from `tm_pinjaman`) AS `jmlh_pinjaman` ;

-- ----------------------------
-- View structure for `v_pinjaman`
-- ----------------------------
DROP VIEW IF EXISTS `v_pinjaman`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `v_pinjaman` AS select `tm_pinjaman`.`pjm_no` AS `pjm_no`,`tm_anggota`.`anggota_nipp` AS `anggota_nipp`,`tm_anggota`.`anggota_nama` AS `anggota_nama`,`tm_anggota`.`anggota_jab` AS `anggota_jab`,`tr_dept`.`dept_nama` AS `dept_nama`,date_format(`tm_pinjaman`.`pjm_tggl`,'%d %M %Y') AS `pjm_tggl`,`tm_pinjaman`.`pjm_tenor` AS `pjm_tenor`,date_format(`tm_pinjaman`.`pjm_tgglend`,'%d %M %Y') AS `pjm_tgglend`,format(`tm_pinjaman`.`pjm_pokok`,2,'de_DE') AS `pjm_pokok`,format(`tm_pinjaman`.`cicilan_total`,2,'de_DE') AS `cicilan_total`,`tm_pinjaman`.`pjm_keperluan` AS `pjm_keperluan`,`tm_pinjaman`.`pjm_stat` AS `pjm_stat` from ((`tm_pinjaman` join `tm_anggota` on((`tm_pinjaman`.`pjm_id` = `tm_anggota`.`anggota_no`))) join `tr_dept` on((`tm_anggota`.`anggota_dept` = `tr_dept`.`dept_id`))) where (`tm_pinjaman`.`pjm_stat` = 1) order by `tm_pinjaman`.`tm_pinjamanup` desc ;

-- ----------------------------
-- View structure for `v_simpanan`
-- ----------------------------
DROP VIEW IF EXISTS `v_simpanan`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `v_simpanan` AS select `tm_anggota`.`anggota_no` AS `anggota_no`,`tm_anggota`.`anggota_nipp` AS `anggota_nipp`,`tm_anggota`.`anggota_nama` AS `anggota_nama`,`tr_simpanan`.`js_nama` AS `js_nama`,format(`tm_simpanan`.`simpanan_jumlah`,2,'de_DE') AS `simpanan_jumlah`,date_format(`tm_simpanan`.`simpanan_tggl`,'%d %M %Y') AS `simpanan_tggl` from ((`tm_simpanan` join `tm_anggota` on((`tm_simpanan`.`simpanan_id` = `tm_anggota`.`anggota_no`))) join `tr_simpanan` on((`tm_simpanan`.`simpanan_tipe` = `tr_simpanan`.`js_id`))) order by `tm_simpanan`.`tm_simpananup` desc ;

-- ----------------------------
-- Function structure for `getanggotano`
-- ----------------------------
DROP FUNCTION IF EXISTS `getanggotano`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getanggotano`() RETURNS varchar(6) CHARSET utf8mb4
BEGIN
    
	DECLARE inc_number VARCHAR(6);
	
	select (substring(anggota_no,1,6)+1) into inc_number from tm_anggota order by anggota_no desc limit 1;
	
	IF(inc_number IS NULL) then
		return '000001';
ELSEIF(LENGTH(inc_number) = 1) then
		RETURN CONCAT('00000',inc_number);
ELSEIF(LENGTH(inc_number) = 2) then
		RETURN CONCAT('0000',inc_number);
ELSEIF(LENGTH(inc_number) = 3) then
		RETURN CONCAT('000',inc_number);
ELSEIF(LENGTH(inc_number) = 4) then
		RETURN CONCAT('00',inc_number);
ELSEIF(LENGTH(inc_number) = 5) then
		RETURN CONCAT('0',inc_number);
ELSEIF(LENGTH(inc_number) = 6) then
		RETURN inc_number;
	END IF;

END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for `getangsurno`
-- ----------------------------
DROP FUNCTION IF EXISTS `getangsurno`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` FUNCTION `getangsurno`() RETURNS varchar(11) CHARSET latin1
BEGIN
    
	declare tanggal varchar(8);
	DECLARE inc_number VARCHAR(11);
	
	set tanggal = CURDATE()+0;
	
	SELECT (SUBSTRING(angsur_no,9)+1) into inc_number FROM tm_angsur WHERE DATE(tm_angsurup) = DATE(NOW()) ORDER BY angsur_no DESC limit 1;
	
	IF(inc_number IS NULL) then
		return concat(tanggal,'001');
	ELSEif (LENgth(inc_number) = 1) then
		RETURN CONCAT(tanggal,'00',inc_number);
	elseif (LENGTH(inc_number) = 2) THEN	
		RETURN CONCAT(tanggal,'0',inc_number);
	ELSEIF LENGTH(inc_number) = 3 THEN	
		RETURN CONCAT(tanggal,inc_number);
	end if;
	
    END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for `getpinjamanno`
-- ----------------------------
DROP FUNCTION IF EXISTS `getpinjamanno`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` FUNCTION `getpinjamanno`() RETURNS varchar(6) CHARSET latin1
BEGIN
	DECLARE inc_number VARCHAR(6);
	
	SELECT LPAD(FLOOR(RAND() * 999999.99), 6, '0') into inc_number;

	RETURN inc_number;
 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `pinjamno`;
DELIMITER ;;
CREATE TRIGGER `pinjamno` AFTER INSERT ON `tm_pinjaman` FOR EACH ROW BEGIN
  declare x INT;

  SET x = 0;

  WHILE x < new.pjm_tenor DO
    SET x = x+1;

		insert into tm_angsur (angsur_no, angsur_id, angsur_tggl, angsur_ke, angsur_jumlah, status  ) values (getangsurno(), new.pjm_no, (SELECT DATE_FORMAT(DATE_ADD(new.pjm_tggl,INTERVAL x MONTH),"%Y-%m-15")), x, new.cicilan_total, 0);
  END WHILE;
END
;;
DELIMITER ;
