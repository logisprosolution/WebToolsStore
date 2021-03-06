USE WebToolsStore
GO
/****** Object:  Table [dbo].[DOC_Detail]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOC_Detail](
	[detail_id] [int] IDENTITY(1,1) NOT NULL,
	[header_id] [int] NULL,
	[product_id] [int] NULL,
	[product_price_id] [int] NULL,
	[product_price_name] [nvarchar](100) NULL,
	[unit_id] [int] NULL,
	[unit_name] [nvarchar](50) NULL,
	[detail_qty] [int] NULL,
	[detail_price] [decimal](18, 2) NULL,
	[detail_discount] [nchar](10) NULL,
	[detail_total] [nchar](10) NULL,
	[detail_status] [int] NULL,
	[detail_remark] [nvarchar](300) NULL,
	[is_del] [bit] NULL,
 CONSTRAINT [PK_DOC_Detail] PRIMARY KEY CLUSTERED 
(
	[detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DOC_Doctype]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOC_Doctype](
	[doctype_id] [int] IDENTITY(1,1) NOT NULL,
	[doctype_code] [nvarchar](20) NULL,
	[doctype_name] [nvarchar](100) NULL,
	[descrription] [nvarchar](max) NULL,
	[is_del] [bit] NULL,
	[is_enabled] [bit] NULL,
 CONSTRAINT [PK_DOC_Doctype] PRIMARY KEY CLUSTERED 
(
	[doctype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DOC_Header]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOC_Header](
	[header_id] [int] IDENTITY(1,1) NOT NULL,
	[header_code] [nvarchar](20) NULL,
	[header_date] [date] NULL,
	[header_date_from] [date] NULL,
	[header_date_to] [date] NULL,
	[header_supplier] [int] NULL,
	[header_customer] [int] NULL,
	[header_remark] [nvarchar](max) NULL,
	[header_status] [int] NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
	[doctype_id] [int] NULL,
 CONSTRAINT [PK_DOC_Header] PRIMARY KEY CLUSTERED 
(
	[header_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DOC_Product_Move]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOC_Product_Move](
	[detail_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[unit_id] [int] NULL,
	[unit_value] [int] NULL,
	[detail_qty] [int] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [PK_DOC_Product_Move] PRIMARY KEY CLUSTERED 
(
	[detail_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DOC_Status]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOC_Status](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[status_name] [nvarchar](100) NULL,
	[status_value] [int] NULL,
	[is_del] [bit] NULL,
	[is_enabled] [bit] NULL,
 CONSTRAINT [PK_DOC_Status] PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MAS_Categories]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAS_Categories](
	[categories_id] [int] IDENTITY(1,1) NOT NULL,
	[categories_code] [nvarchar](20) NULL,
	[categories_name] [nvarchar](100) NOT NULL,
	[categories_index] [float] NULL,
	[descrription] [nvarchar](max) NULL,
	[is_del] [bit] NULL,
	[is_enabled] [bit] NULL,
 CONSTRAINT [PK_MAS_Categories] PRIMARY KEY CLUSTERED 
(
	[categories_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MAS_Customer]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAS_Customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_code] [nvarchar](20) NULL,
	[customer_name] [nvarchar](200) NULL,
	[customer_tel1] [nvarchar](10) NULL,
	[customer_tel2] [nvarchar](max) NULL,
	[customer_fax] [nvarchar](20) NULL,
	[customer_email] [nvarchar](50) NULL,
	[customer_address] [nvarchar](max) NULL,
	[customer_subdistict] [int] NULL,
	[customer_distict] [int] NULL,
	[customer_province] [int] NULL,
	[customer_zipcode] [nvarchar](6) NULL,
	[descrription] [nvarchar](max) NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_MAS_Customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MAS_Product]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAS_Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_code] [nvarchar](50) NULL,
	[product_name] [nvarchar](200) NULL,
	[product_pic] [image] NULL,
	[descrription] [nvarchar](max) NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
	[subcategories_id] [int] NULL,
 CONSTRAINT [PK_MAS_Product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MAS_Product_Price]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAS_Product_Price](
	[product_price_id] [int] IDENTITY(1,1) NOT NULL,
	[product_price_code] [nvarchar](20) NULL,
	[product_price_name] [nvarchar](100) NULL,
	[unit_id] [int] NULL,
	[cost] [decimal](18, 2) NULL,
	[price_Cash] [decimal](18, 2) NULL,
	[price_Credit] [decimal](18, 2) NULL,
	[descrription] [nvarchar](max) NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
	[product_id] [int] NULL,
 CONSTRAINT [PK_MAS_Product_Price] PRIMARY KEY CLUSTERED 
(
	[product_price_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MAS_Subcategories]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAS_Subcategories](
	[subcategories_id] [int] IDENTITY(1,1) NOT NULL,
	[subcategories_code] [nvarchar](20) NULL,
	[subcategories_name] [nvarchar](100) NULL,
	[subcategories_index] [float] NULL,
	[descrription] [nvarchar](max) NULL,
	[is_del] [bit] NULL,
	[is_enabled] [bit] NULL,
	[categories_id] [int] NULL,
 CONSTRAINT [PK_MAS_Subcategories] PRIMARY KEY CLUSTERED 
(
	[subcategories_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MAS_Supplier]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAS_Supplier](
	[supplier_id] [int] IDENTITY(1,1) NOT NULL,
	[supplier_code] [nvarchar](20) NULL,
	[supplier_name] [nvarchar](200) NULL,
	[supplier_tel1] [nvarchar](10) NULL,
	[supplier_tel2] [nvarchar](10) NULL,
	[supplier_fax] [nvarchar](20) NULL,
	[supplier_email] [nvarchar](50) NULL,
	[supplier_address] [nvarchar](max) NULL,
	[supplier_subdistict] [int] NULL,
	[supplier_distict] [int] NULL,
	[supplier_province] [int] NULL,
	[supplier_zipcode] [nvarchar](6) NULL,
	[descrription] [nvarchar](max) NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_MAS_Supplier] PRIMARY KEY CLUSTERED 
(
	[supplier_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MAS_Unit]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAS_Unit](
	[unit_id] [int] IDENTITY(1,1) NOT NULL,
	[unit_name] [nvarchar](50) NULL,
	[unit_value] [int] NULL,
	[is_del] [bit] NULL,
	[is_enabled] [bit] NULL,
 CONSTRAINT [PK_MAS_Unit] PRIMARY KEY CLUSTERED 
(
	[unit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USR_Menu]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_Menu](
	[menu_id] [int] IDENTITY(1,1) NOT NULL,
	[menu_name_eng] [nvarchar](100) NULL,
	[menu_name_thai] [nvarchar](100) NULL,
	[menu_value] [int] NULL,
	[menu_index] [int] NULL,
	[is_del] [bit] NULL,
	[is_enabled] [bit] NULL,
 CONSTRAINT [PK_USR_Menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USR_Role]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](100) NULL,
	[role_value] [int] NULL,
	[is_del] [bit] NULL,
	[is_enabled] [bit] NULL,
 CONSTRAINT [PK_USR_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USR_Role_Submenu]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_Role_Submenu](
	[role_id] [int] NOT NULL,
	[submenu_id] [int] NOT NULL,
	[is_view] [bit] NULL,
	[is_add] [bit] NULL,
	[is_edit] [bit] NULL,
	[is_delete] [bit] NULL,
	[is_search] [bit] NULL,
 CONSTRAINT [PK_USR_Role_Submenu] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC,
	[submenu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USR_Submenu]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_Submenu](
	[submenu_id] [int] IDENTITY(1,1) NOT NULL,
	[submenu_name_eng] [nvarchar](100) NULL,
	[submenu_name_thai] [nvarchar](100) NULL,
	[submenu_value] [int] NULL,
	[submenu_index] [int] NULL,
	[is_del] [bit] NULL,
	[is_enabled] [bit] NULL,
	[menu_id] [int] NULL,
 CONSTRAINT [PK_USR_Submenu] PRIMARY KEY CLUSTERED 
(
	[submenu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USR_Title]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_Title](
	[title_id] [int] IDENTITY(1,1) NOT NULL,
	[title_name] [nvarchar](50) NULL,
	[is_del] [bit] NULL,
	[is_enabled] [bit] NULL,
 CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED 
(
	[title_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USR_User]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NULL,
	[user_password] [nvarchar](50) NULL,
	[user_type] [int] NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USR_User_Profile]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_User_Profile](
	[user_profile_id] [int] IDENTITY(1,1) NOT NULL,
	[title_id] [int] NULL,
	[name] [nvarchar](100) NULL,
	[lastname] [nvarchar](100) NULL,
	[age] [int] NULL,
	[bithdate] [date] NULL,
	[tel] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[address] [nvarchar](max) NULL,
	[subdistict] [int] NULL,
	[distict] [int] NULL,
	[province] [int] NULL,
	[zipcode] [nvarchar](6) NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
	[descrription] [nvarchar](max) NULL,
	[card] [nchar](10) NULL,
 CONSTRAINT [PK_User_Profile] PRIMARY KEY CLUSTERED 
(
	[user_profile_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USR_User_Role]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_User_Role](
	[role_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_USR_User_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WEB_Book]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WEB_Book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[book_name] [nvarchar](100) NULL,
	[book_email] [nvarchar](20) NULL,
	[book_tel] [nvarchar](10) NULL,
	[book_address] [nvarchar](300) NULL,
	[book_district] [int] NULL,
	[book_subdistrict] [int] NULL,
	[book_province] [int] NULL,
 CONSTRAINT [PK_WEB_Book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WEB_Company]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WEB_Company](
	[comany_id] [int] IDENTITY(1,1) NOT NULL,
	[company_name] [nvarchar](100) NULL,
	[company_info] [nvarchar](max) NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_WEB_Company] PRIMARY KEY CLUSTERED 
(
	[comany_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WEB_Contact_Us]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WEB_Contact_Us](
	[contact_id] [int] IDENTITY(1,1) NOT NULL,
	[contact_name] [nvarchar](100) NULL,
	[contact_surname] [nvarchar](100) NULL,
	[contact_email] [nvarchar](50) NULL,
	[contact_tel] [nvarchar](20) NULL,
	[contact_remark] [nvarchar](max) NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[isRead] [bit] NULL,
 CONSTRAINT [PK_WEB_Contact_Us] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WEB_Products]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WEB_Products](
	[wProduct_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[unit_id] [int] NULL,
	[unit_name] [nvarchar](50) NULL,
	[wProduct_qty] [int] NULL,
	[wProduct_price] [decimal](18, 2) NULL,
	[wProduct_detail] [nvarchar](max) NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_WEB_Products] PRIMARY KEY CLUSTERED 
(
	[wProduct_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WEB_Promotion]    Script Date: 2/11/2560 15:56:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WEB_Promotion](
	[promotion_id] [int] IDENTITY(1,1) NOT NULL,
	[promotion_name] [nvarchar](100) NULL,
	[promotion_detail] [nvarchar](max) NULL,
	[promotion_image] [image] NULL,
	[promotion_index] [int] NULL,
	[is_enabled] [bit] NULL,
	[is_del] [bit] NULL,
	[create_date] [datetime] NULL,
	[create_by] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_WEB_Promotion] PRIMARY KEY CLUSTERED 
(
	[promotion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[DOC_Detail]  WITH CHECK ADD  CONSTRAINT [FK_DOC_Detail_DOC_Header] FOREIGN KEY([header_id])
REFERENCES [dbo].[DOC_Header] ([header_id])
GO
ALTER TABLE [dbo].[DOC_Detail] CHECK CONSTRAINT [FK_DOC_Detail_DOC_Header]
GO
ALTER TABLE [dbo].[DOC_Detail]  WITH CHECK ADD  CONSTRAINT [FK_DOC_Detail_MAS_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[MAS_Product] ([product_id])
GO
ALTER TABLE [dbo].[DOC_Detail] CHECK CONSTRAINT [FK_DOC_Detail_MAS_Product]
GO
ALTER TABLE [dbo].[DOC_Detail]  WITH CHECK ADD  CONSTRAINT [FK_DOC_Detail_MAS_Product_Price] FOREIGN KEY([product_price_id])
REFERENCES [dbo].[MAS_Product_Price] ([product_price_id])
GO
ALTER TABLE [dbo].[DOC_Detail] CHECK CONSTRAINT [FK_DOC_Detail_MAS_Product_Price]
GO
ALTER TABLE [dbo].[DOC_Header]  WITH CHECK ADD  CONSTRAINT [FK_DOC_Header_DOC_Doctype] FOREIGN KEY([doctype_id])
REFERENCES [dbo].[DOC_Doctype] ([doctype_id])
GO
ALTER TABLE [dbo].[DOC_Header] CHECK CONSTRAINT [FK_DOC_Header_DOC_Doctype]
GO
ALTER TABLE [dbo].[MAS_Product]  WITH CHECK ADD  CONSTRAINT [FK_MAS_Product_MAS_Subcategories] FOREIGN KEY([subcategories_id])
REFERENCES [dbo].[MAS_Subcategories] ([subcategories_id])
GO
ALTER TABLE [dbo].[MAS_Product] CHECK CONSTRAINT [FK_MAS_Product_MAS_Subcategories]
GO
ALTER TABLE [dbo].[MAS_Product_Price]  WITH CHECK ADD  CONSTRAINT [FK_MAS_Product_Price_MAS_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[MAS_Product] ([product_id])
GO
ALTER TABLE [dbo].[MAS_Product_Price] CHECK CONSTRAINT [FK_MAS_Product_Price_MAS_Product]
GO
ALTER TABLE [dbo].[MAS_Product_Price]  WITH CHECK ADD  CONSTRAINT [FK_MAS_Product_Price_MAS_Unit] FOREIGN KEY([unit_id])
REFERENCES [dbo].[MAS_Unit] ([unit_id])
GO
ALTER TABLE [dbo].[MAS_Product_Price] CHECK CONSTRAINT [FK_MAS_Product_Price_MAS_Unit]
GO
ALTER TABLE [dbo].[MAS_Subcategories]  WITH CHECK ADD  CONSTRAINT [FK_MAS_Subcategories_MAS_Categories] FOREIGN KEY([categories_id])
REFERENCES [dbo].[MAS_Categories] ([categories_id])
GO
ALTER TABLE [dbo].[MAS_Subcategories] CHECK CONSTRAINT [FK_MAS_Subcategories_MAS_Categories]
GO
ALTER TABLE [dbo].[USR_Role_Submenu]  WITH CHECK ADD  CONSTRAINT [FK_USR_Role_Submenu_USR_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[USR_Role] ([role_id])
GO
ALTER TABLE [dbo].[USR_Role_Submenu] CHECK CONSTRAINT [FK_USR_Role_Submenu_USR_Role]
GO
ALTER TABLE [dbo].[USR_Role_Submenu]  WITH CHECK ADD  CONSTRAINT [FK_USR_Role_Submenu_USR_Submenu] FOREIGN KEY([submenu_id])
REFERENCES [dbo].[USR_Submenu] ([submenu_id])
GO
ALTER TABLE [dbo].[USR_Role_Submenu] CHECK CONSTRAINT [FK_USR_Role_Submenu_USR_Submenu]
GO
ALTER TABLE [dbo].[USR_Submenu]  WITH CHECK ADD  CONSTRAINT [FK_USR_Submenu_USR_Menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[USR_Menu] ([menu_id])
GO
ALTER TABLE [dbo].[USR_Submenu] CHECK CONSTRAINT [FK_USR_Submenu_USR_Menu]
GO
ALTER TABLE [dbo].[USR_User_Profile]  WITH CHECK ADD  CONSTRAINT [FK_USR_User_Profile_USR_Title] FOREIGN KEY([title_id])
REFERENCES [dbo].[USR_Title] ([title_id])
GO
ALTER TABLE [dbo].[USR_User_Profile] CHECK CONSTRAINT [FK_USR_User_Profile_USR_Title]
GO
ALTER TABLE [dbo].[USR_User_Profile]  WITH CHECK ADD  CONSTRAINT [FK_USR_User_Profile_USR_User] FOREIGN KEY([user_profile_id])
REFERENCES [dbo].[USR_User] ([user_id])
GO
ALTER TABLE [dbo].[USR_User_Profile] CHECK CONSTRAINT [FK_USR_User_Profile_USR_User]
GO
ALTER TABLE [dbo].[USR_User_Role]  WITH CHECK ADD  CONSTRAINT [FK_USR_User_Role_USR_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[USR_Role] ([role_id])
GO
ALTER TABLE [dbo].[USR_User_Role] CHECK CONSTRAINT [FK_USR_User_Role_USR_Role]
GO
ALTER TABLE [dbo].[USR_User_Role]  WITH CHECK ADD  CONSTRAINT [FK_USR_User_Role_USR_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[USR_User] ([user_id])
GO
ALTER TABLE [dbo].[USR_User_Role] CHECK CONSTRAINT [FK_USR_User_Role_USR_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'detail_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หัวไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'header_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีราคาสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'product_price_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อราคาสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'product_price_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'unit_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'unit_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ราคา' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'detail_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ส่วนลด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'detail_discount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'detail_total'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'detail_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'detail_remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Detail', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภทไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Doctype', @level2type=N'COLUMN',@level2name=N'doctype_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Doctype', @level2type=N'COLUMN',@level2name=N'doctype_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภทชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Doctype', @level2type=N'COLUMN',@level2name=N'doctype_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Doctype', @level2type=N'COLUMN',@level2name=N'descrription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Doctype', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Doctype', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'header_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'header_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'header_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่จาก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'header_date_from'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่ถึง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'header_date_to'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'คู่ค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'header_supplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'header_customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'header_remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'header_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สร้างโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทวันที่เท่าไหร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'update_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชนิดไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Header', @level2type=N'COLUMN',@level2name=N'doctype_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Product_Move', @level2type=N'COLUMN',@level2name=N'detail_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Product_Move', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Product_Move', @level2type=N'COLUMN',@level2name=N'unit_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Product_Move', @level2type=N'COLUMN',@level2name=N'unit_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Product_Move', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Product_Move', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Status', @level2type=N'COLUMN',@level2name=N'status_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Status', @level2type=N'COLUMN',@level2name=N'status_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Status', @level2type=N'COLUMN',@level2name=N'status_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Status', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DOC_Status', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Categories', @level2type=N'COLUMN',@level2name=N'categories_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Categories', @level2type=N'COLUMN',@level2name=N'categories_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Categories', @level2type=N'COLUMN',@level2name=N'categories_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หน้าcategories' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Categories', @level2type=N'COLUMN',@level2name=N'categories_index'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Categories', @level2type=N'COLUMN',@level2name=N'descrription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Categories', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Categories', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลหมวดสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Categories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีลูกต้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์โทร1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_tel1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์โทร2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_tel2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'fax' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_fax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อีเมลลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'แขวง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_subdistict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เขต' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_distict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_province'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสไปรษณีย์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'customer_zipcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'descrription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สร้างโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทวันที่เท่าไหร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'update_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'product_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'product_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รูปสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'product_pic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'descrription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สร้างโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทวันที่เท่าไหร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'update_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีราคาสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'product_price_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสราคาสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'product_price_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อราคาสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'product_price_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'unit_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ราคา' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'cost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เงินสด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'price_Cash'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เครดิต' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'price_Credit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'descrription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สร้างโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทวันที่เท่าไหร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'update_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เพิ่มรหัสซื้อขายสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Product_Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Subcategories', @level2type=N'COLUMN',@level2name=N'subcategories_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Subcategories', @level2type=N'COLUMN',@level2name=N'subcategories_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Subcategories', @level2type=N'COLUMN',@level2name=N'subcategories_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมาบเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Subcategories', @level2type=N'COLUMN',@level2name=N'descrription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Subcategories', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Subcategories', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Subcategories', @level2type=N'COLUMN',@level2name=N'categories_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลประเภทสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Subcategories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีคู่ค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสคู่ค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อคู่ค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์โทร1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_tel1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์โทร2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_tel2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'fax' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_fax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อีเมลคู่ค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่คู่ค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'แขวง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_subdistict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เขต' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_distict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_province'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสไปรษณีย์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'supplier_zipcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'descrription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สร้างโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทวันที่เท่าไหร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'update_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลคู่ค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Supplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Unit', @level2type=N'COLUMN',@level2name=N'unit_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Unit', @level2type=N'COLUMN',@level2name=N'unit_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Unit', @level2type=N'COLUMN',@level2name=N'unit_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Unit', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MAS_Unit', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เมนูไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Menu', @level2type=N'COLUMN',@level2name=N'menu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เมนูชื่ออังกฤษ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Menu', @level2type=N'COLUMN',@level2name=N'menu_name_eng'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เมนูชื่อไทย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Menu', @level2type=N'COLUMN',@level2name=N'menu_name_thai'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เมนูสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Menu', @level2type=N'COLUMN',@level2name=N'menu_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หน้าเมนู' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Menu', @level2type=N'COLUMN',@level2name=N'menu_index'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Menu', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Menu', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'แถวไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role', @level2type=N'COLUMN',@level2name=N'role_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role', @level2type=N'COLUMN',@level2name=N'role_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role_Submenu', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เมนูไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role_Submenu', @level2type=N'COLUMN',@level2name=N'submenu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ดู' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role_Submenu', @level2type=N'COLUMN',@level2name=N'is_view'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เพิ่ม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role_Submenu', @level2type=N'COLUMN',@level2name=N'is_add'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'แก้ไข' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role_Submenu', @level2type=N'COLUMN',@level2name=N'is_edit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ลบ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role_Submenu', @level2type=N'COLUMN',@level2name=N'is_delete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ค้นหา' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Role_Submenu', @level2type=N'COLUMN',@level2name=N'is_search'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Submenu', @level2type=N'COLUMN',@level2name=N'submenu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เมนูชื่ออังกฤษ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Submenu', @level2type=N'COLUMN',@level2name=N'submenu_name_eng'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เมนูชื่อไทย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Submenu', @level2type=N'COLUMN',@level2name=N'submenu_name_thai'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เมนูสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Submenu', @level2type=N'COLUMN',@level2name=N'submenu_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หน้าเมนู' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Submenu', @level2type=N'COLUMN',@level2name=N'submenu_index'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Submenu', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Submenu', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เมนูไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Submenu', @level2type=N'COLUMN',@level2name=N'menu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Title', @level2type=N'COLUMN',@level2name=N'title_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Title', @level2type=N'COLUMN',@level2name=N'title_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Title', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_Title', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'พาสเวิร์ดลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'user_password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภทลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'user_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สร้างโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทวันที่เท่าไหร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'update_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'user_profile_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภทไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'title_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'นามสกุล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'lastname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อายุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'age'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเกิด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'bithdate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อีเมล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'แขวง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'subdistict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เขต' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'distict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'province'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสไปรษณีย์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'zipcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สร้างโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทวันที่เท่าไหร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'update_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หผายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'descrription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'บัตรประชาขน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile', @level2type=N'COLUMN',@level2name=N'card'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลพนักงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Profile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'แถวไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Role', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีลูกค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USR_User_Role', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Book', @level2type=N'COLUMN',@level2name=N'book_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Book', @level2type=N'COLUMN',@level2name=N'book_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อีเมล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Book', @level2type=N'COLUMN',@level2name=N'book_email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์โทร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Book', @level2type=N'COLUMN',@level2name=N'book_tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Book', @level2type=N'COLUMN',@level2name=N'book_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เขต' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Book', @level2type=N'COLUMN',@level2name=N'book_district'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'แขวง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Book', @level2type=N'COLUMN',@level2name=N'book_subdistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Book', @level2type=N'COLUMN',@level2name=N'book_province'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดีบริษัท' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Company', @level2type=N'COLUMN',@level2name=N'comany_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อบริษัท' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Company', @level2type=N'COLUMN',@level2name=N'company_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลบริษัท' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Company', @level2type=N'COLUMN',@level2name=N'company_info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Company', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Company', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สร้างโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Company', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทวันที่เท่าไหร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Company', @level2type=N'COLUMN',@level2name=N'update_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัปเดทโดยใคร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Company', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ไอดี' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'contact_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'contact_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'นามสกุล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'contact_surname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อีเมล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'contact_email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'contact_tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'หมายเหตุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'contact_remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดการใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'is_enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิด/ลบ การใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'is_del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ่านแล้ว' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEB_Contact_Us', @level2type=N'COLUMN',@level2name=N'isRead'
GO
