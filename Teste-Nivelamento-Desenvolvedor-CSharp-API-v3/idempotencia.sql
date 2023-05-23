/*
 Navicat Premium Data Transfer

 Source Server         : SQL Local
 Source Server Type    : SQL Server
 Source Server Version : 12002269
 Source Host           : LAPTOP-6F9ISQ9R\SQLEXPRESS:1433
 Source Catalog        : Teste
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 12002269
 File Encoding         : 65001

 Date: 23/05/2023 16:00:45
*/


-- ----------------------------
-- Table structure for idempotencia
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[idempotencia]') AND type IN ('U'))
	DROP TABLE [dbo].[idempotencia]
GO

CREATE TABLE [dbo].[idempotencia] (
  [chave_idempotencia] varchar(50) COLLATE Latin1_General_CI_AS  NOT NULL,
  [requisicao] nvarchar(max) COLLATE Latin1_General_CI_AS  NULL,
  [resultado] nvarchar(max) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[idempotencia] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of idempotencia
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table idempotencia
-- ----------------------------
ALTER TABLE [dbo].[idempotencia] ADD CONSTRAINT [PK__idempote__1BDDF86D33ECAB7E] PRIMARY KEY CLUSTERED ([chave_idempotencia])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

