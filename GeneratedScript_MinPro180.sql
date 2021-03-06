USE [XBC_180]
GO
/****** Object:  Table [dbo].[t_assignment]    Script Date: 12/3/2018 4:14:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_assignment](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[biodata_id] [bigint] NOT NULL,
	[title] [varchar](255) NOT NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NOT NULL,
	[description] [varchar](255) NULL,
	[realization_date] [datetime] NULL,
	[notes] [varchar](255) NULL,
	[is_hold] [bit] NULL,
	[is_done] [bit] NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[deleted_by] [bigint] NULL,
	[deleted_on] [datetime] NULL,
	[is_delete] [bit] NOT NULL,
 CONSTRAINT [PK_t_assignment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_audit_log]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_audit_log](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[type] [varchar](10) NOT NULL,
	[json_insert] [varchar](5000) NULL,
	[json_before] [varchar](5000) NULL,
	[json_after] [varchar](5000) NULL,
	[json_delete] [varchar](5000) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
 CONSTRAINT [PK_t_audit_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_batch]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_batch](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[technology_id] [bigint] NOT NULL,
	[trainer_id] [bigint] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[period_from] [datetime] NULL,
	[period_to] [datetime] NULL,
	[room_id] [bigint] NULL,
	[bootcamp_type_id] [bigint] NULL,
	[notes] [varchar](255) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[deleted_by] [bigint] NULL,
	[deleted_on] [datetime] NULL,
	[is_delete] [bit] NOT NULL,
 CONSTRAINT [PK_t_batch] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_biodata]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_biodata](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[gender] [varchar](255) NULL,
	[last_education] [varchar](100) NOT NULL,
	[graduation_year] [varchar](5) NOT NULL,
	[educational_level] [varchar](5) NOT NULL,
	[majors] [varchar](100) NOT NULL,
	[gpa] [varchar](5) NOT NULL,
	[bootcamp_test_type] [bigint] NULL,
	[iq] [int] NULL,
	[du] [varchar](10) NULL,
	[arithmetic] [int] NULL,
	[nested_logic] [int] NULL,
	[join_table] [int] NULL,
	[tro] [varchar](50) NULL,
	[notes] [varchar](100) NULL,
	[interviewer] [varchar](100) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_biodata] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_bootcamp_test_type]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_bootcamp_test_type](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[notes] [varchar](255) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_bootcamp_test_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_bootcamp_type]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_bootcamp_type](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[notes] [varchar](255) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_bootcamp_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_category]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_category](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_clazz]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_clazz](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[batch_id] [bigint] NOT NULL,
	[biodata_id] [bigint] NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
 CONSTRAINT [PK_t_clazz] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_feedback]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_feedback](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[test_id] [bigint] NOT NULL,
	[version_id] [bigint] NOT NULL,
	[json_feedback] [varchar](5000) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[deleted_by] [bigint] NULL,
	[deleted_on] [datetime] NULL,
	[is_delete] [bit] NOT NULL,
 CONSTRAINT [PK_t_feedback] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_idle_news]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_idle_news](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[test_id] [bigint] NOT NULL,
	[category_id] [bigint] NOT NULL,
	[title] [varchar](255) NOT NULL,
	[content] [varchar](5000) NULL,
	[is_publish] [bit] NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[deleted_by] [bigint] NULL,
	[deleted_on] [datetime] NULL,
	[is_delete] [bit] NOT NULL,
 CONSTRAINT [PK_t_idle_news] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_menu]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_menu](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[image_url] [varchar](100) NOT NULL,
	[menu_order] [int] NOT NULL,
	[menu_parent] [bigint] NULL,
	[menu_url] [varchar](100) NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_menu_access]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_menu_access](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[menu_id] [bigint] NOT NULL,
	[role_id] [bigint] NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
 CONSTRAINT [PK_t_menu_access] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_monitoring]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_monitoring](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[biodata_id] [bigint] NOT NULL,
	[idle_date] [datetime] NOT NULL,
	[last_project] [varchar](50) NULL,
	[idle_reason] [varchar](255) NULL,
	[placement_date] [datetime] NOT NULL,
	[placement_at] [varchar](50) NULL,
	[notes] [varchar](255) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[deleted_by] [bigint] NULL,
	[deleted_on] [datetime] NULL,
	[is_delete] [bit] NOT NULL,
 CONSTRAINT [PK_t_monitoring] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_office]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_office](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[phone] [varchar](50) NULL,
	[email] [varchar](255) NULL,
	[address] [varchar](500) NULL,
	[notes] [varchar](500) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_office] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_question]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_question](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[question] [varchar](255) NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[deleted_by] [bigint] NULL,
	[deleted_on] [datetime] NULL,
	[is_delete] [bit] NOT NULL,
 CONSTRAINT [PK_t_question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_role]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_role](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_room]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_room](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[capacity] [int] NOT NULL,
	[any_projector] [bit] NOT NULL,
	[notes] [varchar](500) NULL,
	[office_id] [bigint] NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_room] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_technology]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_technology](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[notes] [varchar](255) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_technology] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_technology_trainer]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_technology_trainer](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[technology_id] [bigint] NOT NULL,
	[trainer_id] [bigint] NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
 CONSTRAINT [PK_t_technology_trainer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_test]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_test](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[notes] [varchar](255) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_testimony]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_testimony](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NOT NULL,
	[content] [varchar](5000) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[deleted_by] [bigint] NULL,
	[deleted_on] [datetime] NULL,
	[is_delete] [bit] NOT NULL,
 CONSTRAINT [PK_t_testimony] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_trainer]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_trainer](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[notes] [varchar](255) NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_trainer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_user]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_user](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role_id] [bigint] NOT NULL,
	[mobile_flag] [bit] NOT NULL,
	[mobile_token] [bigint] NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [nchar](10) NULL,
	[modified_on] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_t_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_version]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_version](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[version] [int] NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
	[modified_by] [bigint] NULL,
	[modified_on] [datetime] NULL,
	[deleted_by] [bigint] NULL,
	[deleted_on] [datetime] NULL,
	[is_delete] [bit] NOT NULL,
 CONSTRAINT [PK_t_version] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_version_detail]    Script Date: 12/3/2018 4:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_version_detail](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[question_id] [bigint] NOT NULL,
	[version_id] [bigint] NOT NULL,
	[created_by] [bigint] NOT NULL,
	[created_on] [datetime] NOT NULL,
 CONSTRAINT [PK_t_version_detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_assignment]  WITH CHECK ADD  CONSTRAINT [FK_t_assignment_t_biodata] FOREIGN KEY([biodata_id])
REFERENCES [dbo].[t_biodata] ([id])
GO
ALTER TABLE [dbo].[t_assignment] CHECK CONSTRAINT [FK_t_assignment_t_biodata]
GO
ALTER TABLE [dbo].[t_batch]  WITH CHECK ADD  CONSTRAINT [FK_t_batch_t_bootcamp_type] FOREIGN KEY([bootcamp_type_id])
REFERENCES [dbo].[t_bootcamp_type] ([id])
GO
ALTER TABLE [dbo].[t_batch] CHECK CONSTRAINT [FK_t_batch_t_bootcamp_type]
GO
ALTER TABLE [dbo].[t_batch]  WITH CHECK ADD  CONSTRAINT [FK_t_batch_t_room] FOREIGN KEY([room_id])
REFERENCES [dbo].[t_room] ([id])
GO
ALTER TABLE [dbo].[t_batch] CHECK CONSTRAINT [FK_t_batch_t_room]
GO
ALTER TABLE [dbo].[t_batch]  WITH CHECK ADD  CONSTRAINT [FK_t_batch_t_technology] FOREIGN KEY([technology_id])
REFERENCES [dbo].[t_technology] ([id])
GO
ALTER TABLE [dbo].[t_batch] CHECK CONSTRAINT [FK_t_batch_t_technology]
GO
ALTER TABLE [dbo].[t_batch]  WITH CHECK ADD  CONSTRAINT [FK_t_batch_t_trainer] FOREIGN KEY([trainer_id])
REFERENCES [dbo].[t_trainer] ([id])
GO
ALTER TABLE [dbo].[t_batch] CHECK CONSTRAINT [FK_t_batch_t_trainer]
GO
ALTER TABLE [dbo].[t_biodata]  WITH CHECK ADD  CONSTRAINT [FK_t_biodata_t_bootcamp_test_type] FOREIGN KEY([bootcamp_test_type])
REFERENCES [dbo].[t_bootcamp_test_type] ([id])
GO
ALTER TABLE [dbo].[t_biodata] CHECK CONSTRAINT [FK_t_biodata_t_bootcamp_test_type]
GO
ALTER TABLE [dbo].[t_clazz]  WITH CHECK ADD  CONSTRAINT [FK_t_clazz_t_batch] FOREIGN KEY([batch_id])
REFERENCES [dbo].[t_batch] ([id])
GO
ALTER TABLE [dbo].[t_clazz] CHECK CONSTRAINT [FK_t_clazz_t_batch]
GO
ALTER TABLE [dbo].[t_clazz]  WITH CHECK ADD  CONSTRAINT [FK_t_clazz_t_biodata] FOREIGN KEY([biodata_id])
REFERENCES [dbo].[t_biodata] ([id])
GO
ALTER TABLE [dbo].[t_clazz] CHECK CONSTRAINT [FK_t_clazz_t_biodata]
GO
ALTER TABLE [dbo].[t_feedback]  WITH CHECK ADD  CONSTRAINT [FK_t_feedback_t_test] FOREIGN KEY([test_id])
REFERENCES [dbo].[t_test] ([id])
GO
ALTER TABLE [dbo].[t_feedback] CHECK CONSTRAINT [FK_t_feedback_t_test]
GO
ALTER TABLE [dbo].[t_feedback]  WITH CHECK ADD  CONSTRAINT [FK_t_feedback_t_version] FOREIGN KEY([version_id])
REFERENCES [dbo].[t_version] ([id])
GO
ALTER TABLE [dbo].[t_feedback] CHECK CONSTRAINT [FK_t_feedback_t_version]
GO
ALTER TABLE [dbo].[t_idle_news]  WITH CHECK ADD  CONSTRAINT [FK_t_idle_news_t_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[t_category] ([id])
GO
ALTER TABLE [dbo].[t_idle_news] CHECK CONSTRAINT [FK_t_idle_news_t_category]
GO
ALTER TABLE [dbo].[t_idle_news]  WITH CHECK ADD  CONSTRAINT [FK_t_idle_news_t_test] FOREIGN KEY([test_id])
REFERENCES [dbo].[t_test] ([id])
GO
ALTER TABLE [dbo].[t_idle_news] CHECK CONSTRAINT [FK_t_idle_news_t_test]
GO
ALTER TABLE [dbo].[t_menu_access]  WITH CHECK ADD  CONSTRAINT [FK_t_menu_access_t_menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[t_menu] ([id])
GO
ALTER TABLE [dbo].[t_menu_access] CHECK CONSTRAINT [FK_t_menu_access_t_menu]
GO
ALTER TABLE [dbo].[t_menu_access]  WITH CHECK ADD  CONSTRAINT [FK_t_menu_access_t_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[t_role] ([id])
GO
ALTER TABLE [dbo].[t_menu_access] CHECK CONSTRAINT [FK_t_menu_access_t_role]
GO
ALTER TABLE [dbo].[t_monitoring]  WITH CHECK ADD  CONSTRAINT [FK_t_monitoring_t_biodata] FOREIGN KEY([biodata_id])
REFERENCES [dbo].[t_biodata] ([id])
GO
ALTER TABLE [dbo].[t_monitoring] CHECK CONSTRAINT [FK_t_monitoring_t_biodata]
GO
ALTER TABLE [dbo].[t_room]  WITH CHECK ADD  CONSTRAINT [FK_t_room_t_office] FOREIGN KEY([office_id])
REFERENCES [dbo].[t_office] ([id])
GO
ALTER TABLE [dbo].[t_room] CHECK CONSTRAINT [FK_t_room_t_office]
GO
ALTER TABLE [dbo].[t_technology_trainer]  WITH CHECK ADD  CONSTRAINT [FK_t_technology_trainer_t_technology] FOREIGN KEY([technology_id])
REFERENCES [dbo].[t_technology] ([id])
GO
ALTER TABLE [dbo].[t_technology_trainer] CHECK CONSTRAINT [FK_t_technology_trainer_t_technology]
GO
ALTER TABLE [dbo].[t_technology_trainer]  WITH CHECK ADD  CONSTRAINT [FK_t_technology_trainer_t_trainer] FOREIGN KEY([trainer_id])
REFERENCES [dbo].[t_trainer] ([id])
GO
ALTER TABLE [dbo].[t_technology_trainer] CHECK CONSTRAINT [FK_t_technology_trainer_t_trainer]
GO
ALTER TABLE [dbo].[t_user]  WITH CHECK ADD  CONSTRAINT [FK_t_user_t_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[t_role] ([id])
GO
ALTER TABLE [dbo].[t_user] CHECK CONSTRAINT [FK_t_user_t_role]
GO
ALTER TABLE [dbo].[t_version_detail]  WITH CHECK ADD  CONSTRAINT [FK_t_version_detail_t_question] FOREIGN KEY([question_id])
REFERENCES [dbo].[t_question] ([id])
GO
ALTER TABLE [dbo].[t_version_detail] CHECK CONSTRAINT [FK_t_version_detail_t_question]
GO
ALTER TABLE [dbo].[t_version_detail]  WITH CHECK ADD  CONSTRAINT [FK_t_version_detail_t_version] FOREIGN KEY([version_id])
REFERENCES [dbo].[t_version] ([id])
GO
ALTER TABLE [dbo].[t_version_detail] CHECK CONSTRAINT [FK_t_version_detail_t_version]
GO
