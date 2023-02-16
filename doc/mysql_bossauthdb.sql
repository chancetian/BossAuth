/*
 Navicat Premium Data Transfer

 Source Server         : 127.0.0.1
 Source Server Type    : MySQL
 Source Server Version : 80029
 Source Host           : localhost:3306
 Source Schema         : bossauthdb

 Target Server Type    : MySQL
 Target Server Version : 80029
 File Encoding         : 65001

 Date: 17/01/2023 14:59:54
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sysappsecret
-- ----------------------------
DROP TABLE IF EXISTS `sysappsecret`;
CREATE TABLE `sysappsecret`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AppId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '应用Id',
  `AppSecret` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '应用密钥',
  `AppCode` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '应用Code(唯一值)',
  `AppName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '应用名',
  `IsDeleted` tinyint NOT NULL DEFAULT 0 COMMENT '否已删除',
  `Status` int NOT NULL DEFAULT 1 COMMENT '状态(1:启用;0禁用)',
  `CreatorId` int NULL DEFAULT NULL COMMENT '创建人Id',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `ModifyTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `ModifierId` int NULL DEFAULT NULL COMMENT '修改人Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysappsecret
-- ----------------------------
INSERT INTO `sysappsecret` VALUES (1, 'CA6D50S9', '0cc773086abb599f38432fca96c767c621200694', 'BOSSAUTH', 'BOSS权限', 0, 1, 0, '2022-12-05 10:40:05', NULL, NULL);
INSERT INTO `sysappsecret` VALUES (2, 'G786AJJY', 'e9f9a24f1c0348765184417a99ea0548df079033', 'CRM', 'CRM', 0, 1, 0, '2022-09-30 09:32:50', '2022-11-18 11:43:13', 0);

-- ----------------------------
-- Table structure for sysdepartment
-- ----------------------------
DROP TABLE IF EXISTS `sysdepartment`;
CREATE TABLE `sysdepartment`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DepartmentName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '部门名称',
  `ParentId` int NOT NULL COMMENT '父部门Id(0表示是根部门)',
  `Telephone` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '电话/手机',
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '邮箱',
  `QQ` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'QQ',
  `Leader` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '负责人ID',
  `IsDeleted` tinyint NOT NULL DEFAULT 0 COMMENT '否已删除',
  `Status` int NOT NULL DEFAULT 1 COMMENT '状态(1:启用;0禁用)',
  `CreatorId` int NULL DEFAULT NULL COMMENT '创建人Id',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `ModifyTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `ModifierId` int NULL DEFAULT NULL COMMENT '修改人Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysdepartment
-- ----------------------------
INSERT INTO `sysdepartment` VALUES (1, 'Boss科技', 0, '15888888888', 'boss@qq.com', NULL, NULL, 0, 1, 0, '2022-09-26 11:05:59', NULL, NULL);
INSERT INTO `sysdepartment` VALUES (2, '深圳总公司', 1, '15888888888', 'boss@qq.com', NULL, NULL, 0, 1, 0, '2022-09-26 11:06:00', NULL, NULL);
INSERT INTO `sysdepartment` VALUES (3, '长沙分公司', 1, '15888888888', 'boss@qq.com', NULL, NULL, 0, 1, 0, '2022-09-26 11:06:00', NULL, NULL);
INSERT INTO `sysdepartment` VALUES (4, '研发部门', 3, '15888888888', 'boss@qq.com', NULL, NULL, 0, 1, 0, '2022-09-26 11:06:00', NULL, NULL);
INSERT INTO `sysdepartment` VALUES (5, '市场部门', 3, '15888888888', 'boss@qq.com', NULL, NULL, 0, 1, 0, '2022-09-26 11:06:00', NULL, NULL);
INSERT INTO `sysdepartment` VALUES (6, '测试部门', 3, '15888888888', 'boss@qq.com', NULL, NULL, 0, 1, 0, '2022-09-26 11:06:00', NULL, NULL);
INSERT INTO `sysdepartment` VALUES (7, '财务部门', 3, '15888888888', 'boss@qq.com', NULL, NULL, 0, 1, 0, '2022-09-26 11:06:00', NULL, NULL);
INSERT INTO `sysdepartment` VALUES (8, '运维部门', 3, '15888888888', 'boss@qq.com', NULL, NULL, 0, 1, 0, '2022-09-26 11:06:00', NULL, NULL);

-- ----------------------------
-- Table structure for sysdicdata
-- ----------------------------
DROP TABLE IF EXISTS `sysdicdata`;
CREATE TABLE `sysdicdata`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DicName` varchar(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '名称',
  `DicCode` varchar(25) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '字典Key',
  `DicValue` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '字典值',
  `Sort` int NULL DEFAULT NULL COMMENT '排序',
  `IsDeleted` tinyint NOT NULL DEFAULT 0 COMMENT '否已删除',
  `Status` int NOT NULL DEFAULT 1 COMMENT '状态(1:启用;0禁用)',
  `CreatorId` int NULL DEFAULT NULL COMMENT '创建人Id',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `ModifyTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `ModifierId` int NULL DEFAULT NULL COMMENT '修改人Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysdicdata
-- ----------------------------

-- ----------------------------
-- Table structure for sysmenu
-- ----------------------------
DROP TABLE IF EXISTS `sysmenu`;
CREATE TABLE `sysmenu`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AppCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '应用Code',
  `MenuName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '菜单名称',
  `ParentId` int NOT NULL DEFAULT 0 COMMENT '父菜单Id(0表示是根菜单)',
  `MenuIcon` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单图标',
  `Path` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '路由地址',
  `MenuUrl` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单Url',
  `MenuType` int NULL DEFAULT NULL COMMENT '菜单类型(1目录 2页面 3按钮)',
  `Authorize` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单权限标识',
  `Remark` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `Sort` int NULL DEFAULT NULL COMMENT '排序',
  `IsDeleted` tinyint NOT NULL DEFAULT 0 COMMENT '否已删除',
  `Status` int NOT NULL DEFAULT 1 COMMENT '状态(1:启用;0禁用)',
  `CreatorId` int NULL DEFAULT NULL COMMENT '创建人Id',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `ModifyTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `ModifierId` int NULL DEFAULT NULL COMMENT '修改人Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysmenu
-- ----------------------------
INSERT INTO `sysmenu` VALUES (1, 'BOSSAUTH', '系统管理', 0, 'system', 'system', '', 1, NULL, NULL, 1, 0, 1, 0, '2022-09-26 14:56:09', '2022-12-26 16:53:40', 1);
INSERT INTO `sysmenu` VALUES (2, 'BOSSAUTH', '用户管理', 1, 'user', 'user', 'system/user/index', 2, 'system:user:list', NULL, 1, 0, 1, 0, '2022-09-26 15:09:01', '2022-12-26 16:53:55', 1);
INSERT INTO `sysmenu` VALUES (3, 'BOSSAUTH', '角色管理', 1, 'peoples', 'role', 'system/role/index', 2, 'system:role:list', NULL, 2, 0, 1, 0, '2022-09-26 15:10:37', '2022-12-26 16:54:36', 1);
INSERT INTO `sysmenu` VALUES (4, 'BOSSAUTH', '菜单管理', 1, 'tree-table', 'menu', 'system/menu/index', 2, 'system:menu:list', NULL, 3, 0, 1, NULL, '2022-09-26 15:11:14', '2022-12-26 16:54:45', 1);
INSERT INTO `sysmenu` VALUES (5, 'BOSSAUTH', '部门管理', 1, 'tree', 'dept', 'system/dept/index', 2, 'system:dept:list', NULL, 4, 0, 1, NULL, '2022-09-26 15:12:26', '2022-12-26 16:54:52', 1);
INSERT INTO `sysmenu` VALUES (6, 'BOSSAUTH', '岗位管理', 1, 'post', 'post', 'system/post/index', 2, 'system:post:list', NULL, 5, 0, 1, NULL, '2022-09-26 15:13:20', '2022-12-26 16:54:59', 1);
INSERT INTO `sysmenu` VALUES (7, 'CRM', '系统管理', 0, 'system', NULL, '', 1, NULL, NULL, 1, 0, 1, 0, '2022-09-26 14:56:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (8, 'BOSSAUTH', '应用管理', 1, 'system', 'app', 'system/app/index', 1, NULL, NULL, 1, 0, 1, 0, '2022-09-26 14:56:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (9, 'BOSSAUTH', '应用查询', 8, '#', NULL, '#', 3, 'system:app:list', NULL, 1, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (10, 'BOSSAUTH', '应用新增', 8, '#', NULL, '#', 3, 'system:app:add', NULL, 2, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (11, 'BOSSAUTH', '应用修改', 8, '#', NULL, '#', 3, 'system:app:edit', NULL, 3, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (12, 'BOSSAUTH', '应用删除', 8, '#', NULL, '#', 3, 'system:app:remove', NULL, 4, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1000, 'BOSSAUTH', '用户查询', 2, '#', NULL, '#', 3, 'system:user:list', NULL, 1, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1001, 'BOSSAUTH', '用户新增', 2, '#', NULL, '#', 3, 'system:user:add', NULL, 2, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1002, 'BOSSAUTH', '用户修改', 2, '#', NULL, '#', 3, 'system:user:edit', NULL, 3, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1003, 'BOSSAUTH', '用户删除', 2, '#', NULL, '#', 3, 'system:user:remove', NULL, 4, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1004, 'BOSSAUTH', '用户导出', 2, '#', NULL, '#', 3, 'system:user:export', NULL, 5, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1005, 'BOSSAUTH', '用户导入', 2, '#', NULL, '#', 3, 'system:user:import', NULL, 6, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1006, 'BOSSAUTH', '重置密码', 2, '#', NULL, '#', 3, 'system:user:resetPwd', NULL, 7, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1007, 'BOSSAUTH', '角色查询', 3, '#', NULL, '#', 3, 'system:role:list', NULL, 1, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1008, 'BOSSAUTH', '角色新增', 3, '#', NULL, '#', 3, 'system:role:add', NULL, 2, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1009, 'BOSSAUTH', '角色修改', 3, '#', NULL, '#', 3, 'system:role:edit', NULL, 3, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1010, 'BOSSAUTH', '角色删除', 3, '#', NULL, '#', 3, 'system:role:remove', NULL, 4, 0, 1, NULL, '2022-09-26 15:48:09', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1011, 'BOSSAUTH', '角色导出', 3, '#', NULL, '#', 3, 'system:role:export', NULL, 5, 0, 1, NULL, '2022-09-26 15:48:10', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1012, 'BOSSAUTH', '菜单查询', 4, '#', NULL, '#', 3, 'system:menu:list', NULL, 1, 0, 1, NULL, '2022-09-26 15:48:10', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1013, 'BOSSAUTH', '菜单新增', 4, '#', NULL, '#', 3, 'system:menu:add', NULL, 2, 0, 1, NULL, '2022-09-26 15:48:10', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1014, 'BOSSAUTH', '菜单修改', 4, '#', NULL, '#', 3, 'system:menu:edit', NULL, 3, 0, 1, NULL, '2022-09-26 15:48:10', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1015, 'BOSSAUTH', '菜单删除', 4, '#', NULL, '#', 3, 'system:menu:remove', NULL, 4, 0, 1, NULL, '2022-09-26 15:48:10', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1016, 'BOSSAUTH', '部门查询', 5, '#', NULL, '#', 3, 'system:dept:list', NULL, 1, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1017, 'BOSSAUTH', '部门新增', 5, '#', NULL, '#', 3, 'system:dept:add', NULL, 2, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1018, 'BOSSAUTH', '部门修改', 5, '#', NULL, '#', 3, 'system:dept:edit', NULL, 3, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1019, 'BOSSAUTH', '部门删除', 5, '#', NULL, '#', 3, 'system:dept:remove', NULL, 4, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1020, 'BOSSAUTH', '岗位查询', 6, '#', NULL, '#', 3, 'system:post:list', NULL, 1, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1021, 'BOSSAUTH', '岗位新增', 6, '#', NULL, '#', 3, 'system:post:add', NULL, 2, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1022, 'BOSSAUTH', '岗位修改', 6, '#', NULL, '#', 3, 'system:post:edit', NULL, 3, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);
INSERT INTO `sysmenu` VALUES (1023, 'BOSSAUTH', '岗位删除', 6, '#', NULL, '#', 3, 'system:post:remove', NULL, 4, 0, 1, NULL, '2022-09-26 15:50:31', NULL, NULL);

-- ----------------------------
-- Table structure for sysmenuauth
-- ----------------------------
DROP TABLE IF EXISTS `sysmenuauth`;
CREATE TABLE `sysmenuauth`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MenuId` int NOT NULL COMMENT '菜单Id',
  `AuthorizeId` int NOT NULL COMMENT '授权Id(角色Id或者用户Id)',
  `AuthorizeType` int NULL DEFAULT NULL COMMENT '授权类型(1角色 2用户)',
  `CreatorId` int NULL DEFAULT NULL COMMENT '创建人Id',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 131 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysmenuauth
-- ----------------------------
INSERT INTO `sysmenuauth` VALUES (106, 1, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (107, 2, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (108, 1000, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (109, 1001, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (110, 1002, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (111, 1003, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (112, 1004, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (113, 1005, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (114, 1006, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (115, 3, 7, 1, 0, '2022-12-05 16:50:54');
INSERT INTO `sysmenuauth` VALUES (116, 1007, 7, 1, 0, '2022-12-05 16:50:55');
INSERT INTO `sysmenuauth` VALUES (117, 1008, 7, 1, 0, '2022-12-05 16:50:55');
INSERT INTO `sysmenuauth` VALUES (118, 1009, 7, 1, 0, '2022-12-05 16:50:55');
INSERT INTO `sysmenuauth` VALUES (119, 1010, 7, 1, 0, '2022-12-05 16:50:55');
INSERT INTO `sysmenuauth` VALUES (120, 1011, 7, 1, 0, '2022-12-05 16:50:55');
INSERT INTO `sysmenuauth` VALUES (121, 1, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (122, 5, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (123, 1016, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (124, 1017, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (125, 1018, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (126, 1019, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (127, 6, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (128, 1020, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (129, 1021, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (130, 1022, 2, 1, 1, '2022-12-27 15:44:54');
INSERT INTO `sysmenuauth` VALUES (131, 1023, 2, 1, 1, '2022-12-27 15:44:54');

-- ----------------------------
-- Table structure for sysposition
-- ----------------------------
DROP TABLE IF EXISTS `sysposition`;
CREATE TABLE `sysposition`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PositionName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '职位名称',
  `Remark` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `Sort` int NULL DEFAULT NULL COMMENT '排序',
  `IsDeleted` tinyint NOT NULL DEFAULT 0 COMMENT '否已删除',
  `Status` int NOT NULL DEFAULT 1 COMMENT '状态(1:启用;0禁用)',
  `CreatorId` int NULL DEFAULT NULL COMMENT '创建人Id',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `ModifyTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `ModifierId` int NULL DEFAULT NULL COMMENT '修改人Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 15 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysposition
-- ----------------------------
INSERT INTO `sysposition` VALUES (1, '董事长', NULL, 1, 0, 1, NULL, '2022-11-08 13:56:35', NULL, NULL);
INSERT INTO `sysposition` VALUES (2, '项目经理', NULL, 2, 0, 1, NULL, '2022-11-08 13:56:56', NULL, NULL);
INSERT INTO `sysposition` VALUES (3, '人力资源', NULL, 3, 0, 1, NULL, '2022-11-08 13:57:24', NULL, NULL);
INSERT INTO `sysposition` VALUES (4, '普通员工', '111', 4, 0, 1, NULL, '2022-11-08 13:57:48', '2022-11-16 16:27:21', 1);

-- ----------------------------
-- Table structure for sysrole
-- ----------------------------
DROP TABLE IF EXISTS `sysrole`;
CREATE TABLE `sysrole`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '角色名',
  `Sort` int NULL DEFAULT 1 COMMENT '排序',
  `IsDeleted` tinyint NOT NULL DEFAULT 0 COMMENT '否已删除',
  `Status` int NOT NULL DEFAULT 1 COMMENT '状态(1:启用;0禁用)',
  `CreatorId` int NULL DEFAULT NULL COMMENT '创建人Id',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `ModifyTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `ModifierId` int NULL DEFAULT NULL COMMENT '修改人Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysrole
-- ----------------------------
INSERT INTO `sysrole` VALUES (1, '超级管理员', 1, 0, 1, 0, '2022-11-08 11:26:24', NULL, NULL);
INSERT INTO `sysrole` VALUES (2, '普通角色', 2, 0, 1, 0, '2022-11-17 08:58:18', '2022-12-27 15:44:53', 1);

-- ----------------------------
-- Table structure for sysuser
-- ----------------------------
DROP TABLE IF EXISTS `sysuser`;
CREATE TABLE `sysuser`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '登录名',
  `Password` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '密码',
  `Salt` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '密码加盐',
  `RealName` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '真实姓名',
  `DepartmentId` int NULL DEFAULT NULL COMMENT '部门',
  `PositionId` int NULL DEFAULT NULL COMMENT '岗位',
  `Sex` int NULL DEFAULT NULL COMMENT '性别(1:男 0:女)',
  `Birthday` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '生日',
  `Portrait` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '头像',
  `Mobile` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '手机',
  `Email` varchar(25) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '邮箱 ',
  `QQ` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'QQ',
  `WeChat` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '微信',
  `IsAdmin` tinyint NULL DEFAULT 0 COMMENT '是否超级管理员(1:是 0:否)',
  `Remark` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `Sort` int NULL DEFAULT NULL COMMENT '排序',
  `IsDeleted` tinyint NOT NULL DEFAULT 0 COMMENT '否已删除',
  `Status` int NOT NULL DEFAULT 1 COMMENT '状态(1:启用;0禁用)',
  `CreatorId` int NULL DEFAULT NULL COMMENT '创建人Id',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `ModifyTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `ModifierId` int NULL DEFAULT NULL COMMENT '修改人Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysuser
-- ----------------------------
INSERT INTO `sysuser` VALUES (1, 'admin', '5794620ce8325bc4e7b67677da3daeaa', 'c5fc028a23cd41c696a004f9dba65bff', 'ADMIN', 1, NULL, 1, NULL, NULL, '13400000001', NULL, NULL, NULL, 1, NULL, NULL, 0, 1, NULL, '2022-09-27 16:07:39', NULL, NULL);
INSERT INTO `sysuser` VALUES (24, 'txc', '1481014461a80b0d4724c0cd37950b0c', 'fbcc9d4e6e76449ea9a92b6ef082a687', 'txc', 1, 2, 1, NULL, NULL, '13411111111', '', NULL, NULL, NULL, '', NULL, 0, 1, 1, '2022-12-26 16:13:18', '2022-12-26 16:15:03', 24);

-- ----------------------------
-- Table structure for sysuserrole
-- ----------------------------
DROP TABLE IF EXISTS `sysuserrole`;
CREATE TABLE `sysuserrole`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL COMMENT '用户ID',
  `RoleId` int NOT NULL COMMENT '角色ID',
  `CreatorId` int NULL DEFAULT NULL COMMENT '创建人Id',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysuserrole
-- ----------------------------
INSERT INTO `sysuserrole` VALUES (3, 24, 2, 1, '2022-12-26 16:13:18');
INSERT INTO `sysuserrole` VALUES (4, 1, 1, 1, '2022-12-26 17:17:36');

SET FOREIGN_KEY_CHECKS = 1;
