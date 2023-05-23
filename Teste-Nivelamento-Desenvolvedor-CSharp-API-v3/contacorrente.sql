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

 Date: 23/05/2023 16:00:37
*/


-- ----------------------------
-- Table structure for contacorrente
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[contacorrente]') AND type IN ('U'))
	DROP TABLE [dbo].[contacorrente]
GO

CREATE TABLE [dbo].[contacorrente] (
  [idcontacorrente] varchar(50) COLLATE Latin1_General_CI_AS  NOT NULL,
  [numero] int  NOT NULL,
  [nome] nvarchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [ativo] bit DEFAULT ((0)) NOT NULL
)
GO

ALTER TABLE [dbo].[contacorrente] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of contacorrente
-- ----------------------------
INSERT INTO [dbo].[contacorrente] ([idcontacorrente], [numero], [nome], [ativo]) VALUES (N'382D323D-7067-ED11-8866-7D5DFA4A16C9', N'789', N'Tevin Mcconnell', N'1')
GO

INSERT INTO [dbo].[contacorrente] ([idcontacorrente], [numero], [nome], [ativo]) VALUES (N'B6BAFC09-6967-ED11-A567-055DFA4A16C9', N'123', N'Katherine Sanchez', N'1')
GO

INSERT INTO [dbo].[contacorrente] ([idcontacorrente], [numero], [nome], [ativo]) VALUES (N'BCDACA4A-7067-ED11-AF81-825DFA4A16C9', N'852', N'Jarrad Mckee', N'0')
GO

INSERT INTO [dbo].[contacorrente] ([idcontacorrente], [numero], [nome], [ativo]) VALUES (N'D2E02051-7067-ED11-94C0-835DFA4A16C9', N'963', N'Elisha Simons', N'0')
GO

INSERT INTO [dbo].[contacorrente] ([idcontacorrente], [numero], [nome], [ativo]) VALUES (N'F475F943-7067-ED11-A06B-7E5DFA4A16C9', N'741', N'Ameena Lynn', N'0')
GO

INSERT INTO [dbo].[contacorrente] ([idcontacorrente], [numero], [nome], [ativo]) VALUES (N'FA99D033-7067-ED11-96C6-7C5DFA4A16C9', N'456', N'Eva Woodward', N'1')
GO


-- ----------------------------
-- Uniques structure for table contacorrente
-- ----------------------------
ALTER TABLE [dbo].[contacorrente] ADD CONSTRAINT [UQ__contacor__FC77F211D40D1BA7] UNIQUE NONCLUSTERED ([numero] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Checks structure for table contacorrente
-- ----------------------------
ALTER TABLE [dbo].[contacorrente] ADD CONSTRAINT [CK__contacorr__ativo__3A81B327] CHECK ([ativo]=(1) OR [ativo]=(0))
GO


-- ----------------------------
-- Primary Key structure for table contacorrente
-- ----------------------------
ALTER TABLE [dbo].[contacorrente] ADD CONSTRAINT [PK__contacor__416E0CBD570C2010] PRIMARY KEY CLUSTERED ([idcontacorrente])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

