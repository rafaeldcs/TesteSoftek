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

 Date: 23/05/2023 16:00:53
*/


-- ----------------------------
-- Table structure for movimento
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[movimento]') AND type IN ('U'))
	DROP TABLE [dbo].[movimento]
GO

CREATE TABLE [dbo].[movimento] (
  [idmovimento] varchar(50) COLLATE Latin1_General_CI_AS  NOT NULL,
  [idcontacorrente] varchar(50) COLLATE Latin1_General_CI_AS  NOT NULL,
  [datamovimento] date  NOT NULL,
  [tipomovimento] char(1) COLLATE Latin1_General_CI_AS  NOT NULL,
  [valor] decimal(10,2)  NOT NULL
)
GO

ALTER TABLE [dbo].[movimento] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of movimento
-- ----------------------------
INSERT INTO [dbo].[movimento] ([idmovimento], [idcontacorrente], [datamovimento], [tipomovimento], [valor]) VALUES (N'1823AB48-AC2B-4AB2-A716-AB82C5E02A7A', N'382D323D-7067-ED11-8866-7D5DFA4A16C9', N'2023-05-23', N'C', N'10.00')
GO

INSERT INTO [dbo].[movimento] ([idmovimento], [idcontacorrente], [datamovimento], [tipomovimento], [valor]) VALUES (N'28E636AF-B3EE-45AC-B0C0-891B696B5A81', N'382D323D-7067-ED11-8866-7D5DFA4A16C9', N'2023-05-23', N'C', N'400.00')
GO

INSERT INTO [dbo].[movimento] ([idmovimento], [idcontacorrente], [datamovimento], [tipomovimento], [valor]) VALUES (N'3FD0D586-04F9-4786-9BB3-98F5365F0B74', N'382D323D-7067-ED11-8866-7D5DFA4A16C9', N'2023-05-23', N'D', N'24.00')
GO

INSERT INTO [dbo].[movimento] ([idmovimento], [idcontacorrente], [datamovimento], [tipomovimento], [valor]) VALUES (N'F28B7417-DBCE-41E7-AB6E-D6D987D18E68', N'382D323D-7067-ED11-8866-7D5DFA4A16C9', N'2023-05-23', N'D', N'300.00')
GO


-- ----------------------------
-- Checks structure for table movimento
-- ----------------------------
ALTER TABLE [dbo].[movimento] ADD CONSTRAINT [CK__movimento__tipom__3D5E1FD2] CHECK ([tipomovimento]='D' OR [tipomovimento]='C')
GO


-- ----------------------------
-- Primary Key structure for table movimento
-- ----------------------------
ALTER TABLE [dbo].[movimento] ADD CONSTRAINT [PK__moviment__55494EF7C8DC4D4C] PRIMARY KEY CLUSTERED ([idmovimento])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table movimento
-- ----------------------------
ALTER TABLE [dbo].[movimento] ADD CONSTRAINT [FK__movimento__idcon__3E52440B] FOREIGN KEY ([idcontacorrente]) REFERENCES [dbo].[contacorrente] ([idcontacorrente]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

