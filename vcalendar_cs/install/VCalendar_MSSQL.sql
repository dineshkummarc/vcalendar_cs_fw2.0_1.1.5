

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[categories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[categories]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[categories_langs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[categories_langs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[config]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[config]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[config_langs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table 
[dbo].[config_langs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[contents]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[contents]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[contents_langs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[contents_langs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[custom_fields]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[custom_fields]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[custom_fields_langs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[custom_fields_langs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[email_templates]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[email_templates]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[email_templates_lang]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[email_templates_lang]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[event_remind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[event_remind]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[events]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[events]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[permissions]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[permissions]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[permissions_langs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[permissions_langs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[users]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
drop table [dbo].[users]
GO




CREATE TABLE categories (
	category_id     int          IDENTITY PRIMARY KEY,
	category_name   varchar(50)  NULL,
	category_image  varchar(100) NULL 
)
GO

CREATE TABLE categories_langs (
	category_lang_id  int          IDENTITY PRIMARY KEY,
	category_id       int          NOT NULL ,
	language_id       varchar(2)   NOT NULL ,
	category_name     varchar(50)  NULL 
)
GO


CREATE TABLE config (
	config_id       int          IDENTITY PRIMARY KEY,
	config_var      varchar(32)  NOT NULL ,
	config_desc     varchar(255) NULL ,
	config_value    text         NULL ,
	config_type     smallint     NULL ,
	config_category smallint     NULL ,
	config_listbox  varchar(250) NULL 
)
GO

CREATE TABLE config_langs (
	config_lang_id  int          IDENTITY PRIMARY KEY,
	language_id     varchar(2)   NULL ,
	config_id       int          NULL ,
	config_desc     varchar(250) NULL ,
	config_listbox  varchar(250) NULL 
)
GO


CREATE TABLE contents (
	content_id     int           IDENTITY PRIMARY KEY,
	content_type   varchar (32)  NOT NULL ,
	content_desc   varchar (255) NULL ,
	content_value  text          NULL 
)
GO

CREATE TABLE contents_langs (
	content_lang_id  int           IDENTITY PRIMARY KEY,
	content_id       int           NULL ,
	language_id      varchar (2)   NOT NULL ,
	content_desc     varchar (255) NULL ,
	content_value    text          NULL 
)
GO


CREATE TABLE custom_fields (
	field_id        int          IDENTITY PRIMARY KEY,
	field_name      varchar (50) NULL ,
	field_label     varchar (50) NULL ,
	field_is_active smallint     NULL 
)
GO


CREATE TABLE custom_fields_langs (
	field_lang_id  int          IDENTITY PRIMARY KEY,
	language_id    varchar (2)  NOT NULL ,
	field_id       int          NOT NULL ,
	field_label    varchar (50) NULL 
)
GO

CREATE TABLE email_templates (
	email_template_id      int           IDENTITY PRIMARY KEY,
	email_template_type    varchar (50)  NULL ,
	email_template_desc    varchar (255) NULL ,
	email_template_from    varchar (50)  NULL ,
	email_template_subject varchar (255) NULL ,
	email_template_body    text          NULL 
)
GO

CREATE TABLE email_templates_lang (
	email_template_lang_id int           IDENTITY PRIMARY KEY,
	language_id            varchar (2)   NOT NULL ,
	email_template_id      int           NULL ,
	email_template_desc    varchar (255) NULL ,
	email_template_subject varchar (255) NULL ,
	email_template_body    text          NULL 
)
GO

CREATE TABLE event_remind (
	remind_id    int       IDENTITY PRIMARY KEY,
	event_id     int       NULL ,
	user_id      int       NULL ,
	remind_date  datetime  NULL ,
	remind_time  datetime  NULL 
)
GO

CREATE TABLE events (
	event_id           int           IDENTITY PRIMARY KEY,
	event_parent_id    int           NULL ,
	user_id            int           NULL ,
	category_id        int           NULL ,
	event_title        varchar (100) NOT NULL ,
	event_desc         text          NULL ,
	event_date         datetime      NULL ,
	event_time         datetime      NULL ,
	event_time_end     datetime      NULL ,
	event_date_add     datetime      NULL ,
	event_user_add     int           NULL ,
	event_is_public    smallint      NULL ,
	event_is_approved  smallint      NULL ,
	event_location     text          NULL ,
	event_cost         varchar (50)  NULL ,
	event_url          varchar (250) NULL ,
	custom_TextBox1    varchar (250) NULL ,
	custom_TextBox2    varchar (250) NULL ,
	custom_TextBox3    varchar (250) NULL ,
	custom_TextArea1   text          NULL ,
	custom_TextArea2   text          NULL ,
	custom_TextArea3   text          NULL ,
	custom_CheckBox1   smallint      NULL ,
	custom_CheckBox2   smallint      NULL ,
	custom_CheckBox3   smallint      NULL 
)
GO

CREATE TABLE permissions (
	permission_id        int           IDENTITY PRIMARY KEY,
	permission_var       varchar (30)  NULL ,
	permission_desc      varchar (250) NULL ,
	permission_value     int           NULL ,
	permission_type      int           NULL ,
	permission_category  smallint      NULL 
)
GO

CREATE TABLE permissions_langs (
	permission_lang_id int           IDENTITY PRIMARY KEY,
	permission_id      int           NOT NULL ,
	language_id        varchar (2)   NOT NULL ,
	permission_desc    varchar (255) NULL 
)
GO

CREATE TABLE users (
	user_id           int           IDENTITY PRIMARY KEY,
	user_login        varchar (25)  NULL ,
	user_password     varchar (25)  NULL ,
	user_level        smallint      NULL ,
	user_email        varchar (100) NULL ,
	user_first_name   varchar (50)  NULL ,
	user_last_name    varchar (50)  NULL ,
	user_is_approved  smallint      NULL ,
	user_access_code  int           NULL ,
	user_date_add     datetime      NULL ,
	user_last_login   datetime      NULL , 
	user_hash	  varchar(32)      NULL
) 
GO




SET IDENTITY_INSERT categories ON
go
INSERT INTO categories (category_id, category_name, category_image) 
 VALUES  (1, 'Main category', NULL);
SET IDENTITY_INSERT categories OFF
go


SET IDENTITY_INSERT categories_langs ON
go
INSERT INTO categories_langs (category_lang_id, category_id, language_id, category_name) 
 VALUES  (1, 1, 'en', 'Main category');
INSERT INTO categories_langs (category_lang_id, category_id, language_id, category_name) 
 VALUES  (2, 1, 'ru', 'Основная категория');
INSERT INTO categories_langs (category_lang_id, category_id, language_id, category_name) 
 VALUES  (3, 1, 'de', 'Hauptkategorie');
SET IDENTITY_INSERT categories_langs OFF
go



SET IDENTITY_INSERT config ON
go
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (3,'info_calendar','Calendar Snapshot Mode','Selected',4,1,'None;Don''t show at all;Current;Show current month;Selected;Show selected month;UserSelected;User-selected');
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (4,'change_style','Allow users to select a style','1',1,3,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (5,'change_language','Allow users to select a language','1',1,3,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (6,'default_style','Default Style','Pine',4,5,'Basic;Basic;Blueprint;Blueprint;CoffeeBreak;CoffeeBreak;Compact;Compact;GreenApple;GreenApple;Innovation;Innovation;None;None;Pine;Pine;SandBeach;SandBeach;School;School');
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (7,'default_language','Default Language','en',4,5,'en;English;de;German;ru;Russian');
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (8,'menu_type','Menu type','Horizontal',4,5,'None;None;Vertical;Vertical;Horizontal;Horizontal');
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (9,'html_header','Page header','<h1>VCalendar</h1>',3,5,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (10,'html_footer','Page footer','<hr>',3,5,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (11,'registration_type','Registration type','1',4,3,'0;Disable registration;1;Registration without a confirmation;4;New registration confirmed by E-Mail;8;New user addition requires the administrator approval');
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (12,'site_email','E-Mail to be shown in the From field','some@email.com',2,4,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (13,'email_setting','Email sending mode','CDO',4,4,'CDO;CDO;CDOnts;CDOnts');
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (14,'SMTP','SMTP Server name',NULL,2,4,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (15,'year_week_icon','Display  the week icon in the year calendar',NULL,1,2,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (16,'info_in_views','Show Calendar Snapshot in views','4',4,1,'2;Monthly, Weekly, Daily;4;Weekly, Daily');
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (17,'info_week_icon','Display the week icon in the Calendar Snapshot',NULL,1,1,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (18,'popup_events','Open the pop-up window for the events','1',1,2,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (19,'info_navigator','Display the navigator in the Calendar Snapshot',NULL,1,1,NULL);
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES
  (20,'time_format','Time Format','1',4,2,'1;Predefined (depends from locale);2;Military (14:20);3;US Standard (2:20 PM)');
INSERT INTO config (config_id, config_var, config_desc, config_value, config_type, config_category, config_listbox) VALUES 
  (21,'event_day_style','Style for days containing events','font-weight: bold;color:#FF0000', 2, 2, '');
SET IDENTITY_INSERT config OFF
go





SET IDENTITY_INSERT config_langs ON
go
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (5,'en',3,'Calendar Snapshot mode', 'None;Don''t show at all;Current;Show current month;Selected;Show selected month');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (6,'ru',3,'Вид малого календаря','None;Не показывать вообще;Current;Показывать текущий месяц;Selected;Показывать выбранный месяц');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (7,'en',4,'Allow users to select a style', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (8,'ru',4,'Пользователь может менять стиль', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (9,'en',5,'Allow users to select a language', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (10,'ru',5,'Пользователь может менять язык', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (11,'en',6,'Default Style', 'Basic;Basic;Blueprint;Blueprint;CoffeeBreak;CoffeeBreak;Compact;Compact;GreenApple;GreenApple;Innovation;Innovation;None;None;Pine;Pine;SandBeach;SandBeach;School;School');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (12,'ru',6,'Стиль по умолчанию','Basic;Basic;Blueprint;Blueprint;CoffeeBreak;CoffeeBreak;Compact;Compact;GreenApple;GreenApple;Innovation;Innovation;None;None;Pine;Pine;SandBeach;SandBeach;School;School');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (13,'en',7,'Default Language', 'en;English;de;German;ru;Russian');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (14,'ru',7,'Язык по умолчанию','en;Английский;de;Немецкий;ru;Русский');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (15,'en',8,'Menu type', 'None;None;Vertical;Vertical;Horizontal;Horizontal');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (16,'ru',8,'Вид меню','None;Не показывать;Vertical;Вертикальное;Horizontal;Горизонтальное');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (17,'en',9,'Page header', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (18,'ru',9,'Заголовок страницы', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (19,'en',10,'Page footer', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (20,'ru',10,'Нижний колонтитул страницы', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (21,'en',11,'Registration type','0;Disable registration;1;Registration without a confirmation;4;New registration confirmed by E-Mail;8;New user addition requires the administrator approval');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (22,'ru',11,'Вид регистрации','0;Регистрация запрещена;1;Регистрация без подтверждения;4;Требует подтверждение по E-mail;8;Регистрация требует утверждения администратором');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (23,'en',12,'E-Mail to be shown in the From field', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (24,'ru',12,'E-Mail в поле От:', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (25,'en',13,'Email sending mode','CDO;CDO;CDOnts;CDOnts');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (26,'ru',13,'Режим отправки писем','CDO;CDO;CDOnts;CDOnts');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (27,'en',14,'SMTP Server name', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (28,'ru',14,'Имя сервера SMTP', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (29,'en',15,'Display  the week icon in the year calendar', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (30,'ru',15,'Показывать иконку недели в годовом календаре', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (31,'en',16,'Show Calendar Snapshot in views', '2;Monthly, Weekly, Daily;4;Weekly, Daily');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (32,'ru',16,'Показывать малый календарь в режимах','2;Месячный, Недельный, Дневной;4;Недельный, Дневной');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (33,'en',17,'Display the week icon in the Calendar Snapshot', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (34,'ru',17,'Показывать иконку недели в малом календаре', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (35,'en',18,'Open the pop-up window for the events', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (36,'ru',18,'Показывать события во всплывающем окне', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (37,'en',19,'Display the navigator in the Calendar Snapshot', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (38,'ru',19,'Показывать навигатор в малом календаре', NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (39,'en',20,'Time Format', '1;Predefined (depends from locale);2;Military (14:20);3;US Standard (2:20 PM)');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (40,'ru',20,'Формат отображения времени', '1;Предопределённый (зависит от локали);2;24 часовой (14:20);3;Американский (2:20 PM)');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (41,'de',1,'Benutze Kurzansicht in der Wochenansicht',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (42,'de',2,'Benutze Kurzansicht in der Tagesansicht',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (43,'de',3,'Kalender Snapshot Modus','None;Nicht anzeigen;Current;Zeige aktuellen Monat;Selected;Ausgewahler Monat');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (44,'de',4,'Benutzer konnen Stil auswahlen',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (45,'de',5,'Benutzer konnen Sprache auswahlen',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (46,'de',6,'Vorgabestil','Basic;Basic;Blueprint;Blueprint;CoffeeBreak;CoffeeBreak;Compact;Compact;GreenApple;GreenApple;Innovation;Innovation;None;None;Pine;Pine;SandBeach;SandBeach;School;School');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (47,'de',7,'Vorgabesprache','en;English;de;Deutsch;ru;Russian');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (48,'de',8,'Menu-Typ','None;None;Vertical;Vertical;Horizontal;Horizontal');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (49,'de',9,'Seiten-Header',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (50,'de',10,'Seiten-Footer',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (51,'de',11,'Registrierungs-Typ','0;Keine Registrierung;1;Registrierung ohne Bestatigung;4;Registrierung mit Bestatigung per E-Mail;8;Registrierung mit Bestatigung durch einen Administrator');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (52,'de',12,'E-Mail fur das Von-Feld',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (53,'de',13,'Email sending mode','CDO;CDO;CDOnts;CDOnts');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (54,'de',14,'Name des SMTP-Servers',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (55,'de',15,'Zeige Wochen-Icon in der Jahresubersicht',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (56,'de',16,'Zeige Kalendar-Snapshot in den Ansichten','2;Monat, Woche, Tag;4;Woche, Tag');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (57,'de',17,'Zeige Wochen-Icon im Kalender-Snapshot',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (58,'de',18,'Offne Popup-Fenster fur die Events',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (59,'de',19,'Zeige Navigation im Kalender-Snapshot',NULL);
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (60,'de',20,'Zeit-Format','1;Vordefiniert (abhangig von der System-Locale);2;Militarisch (14:20);3;US-Standard (2:20 PM)');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (61,'en',21,'Style for days containing events','');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (62,'de',21,'Style fur die Tage Falle enthalten','');
INSERT INTO config_langs (config_lang_id, language_id, config_id, config_desc, config_listbox)
  VALUES (63,'ru',21,'Стиль для дней, содержащих события','');

SET IDENTITY_INSERT config_langs OFF
go




SET IDENTITY_INSERT contents ON
go
INSERT INTO contents (content_id, content_type, content_desc, content_value) VALUES
  (1,'registration_need_confirm','Displayed for the user after registration if confiramtion by E-Mail is required','<h3>{user_login}</h3><h4>Thank you for your registaration.</h4><p>You should receive confirmation instructions by email shortly.</p><p>Email was sent to {user_email}</p>');
INSERT INTO contents (content_id, content_type, content_desc, content_value) VALUES
  (2,'registration_need_approve','Displayed after registration if new user need admin approval','<h3>{user_login}</h3><h4>Thank you for your registaration.</h4><h5>Your account must be approved by Administrator.</h5>');
INSERT INTO contents (content_id, content_type, content_desc, content_value) VALUES
  (3,'registration_message','Displayed after registration if confirmation by E-Mail isn''t required','<h3>{user_login}</h3><h4>Thank you for your registaration.</h4>');
INSERT INTO contents (content_id, content_type, content_desc, content_value) VALUES
  (4,'password_changed','Displayed after the changing password','<h3>{user_login}</h3><p>Your password was&nbsp;changed successfully.</p><p><a href="{profile_url}">Back to profile</a></p>');
INSERT INTO contents (content_id, content_type, content_desc, content_value) VALUES
  (5,'verification_message','Displayed for the user after verification','<h3>{user_login}</h3><h2>Your account is now active.</h2>');
INSERT INTO contents (content_id, content_type, content_desc, content_value) VALUES
  (6,'password_was_sent','Displayed after the new password was sent','<h2>Email was sent</h2><p>If you supplied the correct username or email address for your account,  the confirmation  will be sent to the specified email address.</p><p>Please check your mailbox.</p><a href=".\">Back to main page</a>.</p>');
INSERT INTO contents (content_id, content_type, content_desc, content_value) VALUES
  (7,'lost_password','Displayed in the lost pasword page','<h2>Welcome, {user_login}</h2><p>You may now change your password.');
SET IDENTITY_INSERT contents OFF
go




SET IDENTITY_INSERT contents_langs ON
go
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (1,1,'en','Displayed for the user after registration if confiramtion by E-Mail is required','<h3>{user_login}</h3><h4>Thank you for your registaration.</h4><p>You should receive confirmation instructions by email shortly.</p><p>Email was sent to {user_email}</p>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (2,1,'ru','Показывается после регистрации если требуется подверждение по E-mail','<h3>{user_login}</h3><h4>Спасибо за регистрацию.</h4><p>Вы получите инструкцию по подтверждению регистрации по email в ближайшее время.</p><p>Email был послан по адресу {user_email}</p>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (3,2,'en','Displayed after registration if new user need admin approval','<h3>{user_login}</h3><h4>Thank you for your registaration.</h4><h5>Your account must be approved by Administrator.</h5>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (4,2,'ru','Показывается после регистрации если требуется утверждение администратора','<h3>{user_login}</h3><h4>Спасибо за регистрацию.</h4><h5>Ваш аккаунт должен быть утвержден администратором.</h5>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (5,3,'en','Displayed after registration if confirmation isn''t required','<h3>{user_login}</h3><h4>Thank you for your registaration.</h4>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (6,3,'ru','Показывается после регистрации если не требуется потдверждения','<h3>{user_login}</h3><h4>Спасибо за регистрацию.</h4>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (7,4,'en','Displayed after the changing password','<h3>{user_login}</h3><p>Your password was&nbsp;changed successfully.</p><p><a href="{profile_url}">Back to profile</a></p>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (8,4,'ru','Показывается после изменения пароля','<h3>{user_login}</h3><p>Ваш пароль был успешно измененн.</p><p><a href="{profile_url}">Вернутся в профиль</a></p>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (9,5,'en','Displayed for the user after verification','<h3>{user_login}</h3><h2>Your account is now active.</h2>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (10,5,'ru','Показывается после авторизации пользователя','<h3>{user_login}</h3><h2>Ваш аккаунт теперь активирован.</h2>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (11,6,'en','Displayed after the new password was sent','<h2>Email was sent</h2><p>If you supplied the correct username or email address for your account,  the confirmation  will be sent to the specified email address.</p><p>Please check your mailbox.</p><a href=".\">Back to main page</a>.</p>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (12,6,'ru','Показывается после отсылки нового пароля','<h2>Письмо было отослано.</h2>Если имя пользователя и электронный адрес укзаны верно, письмо подтверждения пароля будет выслано в указанный адрес.<a href=".\">Вернуться на главную страницу</a>.</p>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (13,7,'en','Displayed in the lost pasword page','<h2>Welcome, {user_login}</h2><p>You may now change your password.');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES 
  (14,7,'ru','Показывается на странице восстановления пароля','<h2>Здравствуйте, {user_login}</h2><p>Вы можете поменять свой пароль.');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES
  (15,1,'de','Wird dem Benutzer nach der Registrierung angezeigt, wenn diese noch per E-Mail bestatigt werden muss','<h3>{user_login}</h3>\r\n<h4>Vielen Dank fur Ihre Registrierung.</h4>\r\n<p>Sie erhalten in Kurze eine Bestatigungs-E-Mail mit weiteren Anleitungen zur Aktivierung.</p>\r\n<p>Die E-Mail wurde an {user_email} gesendet.</p>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES
  (16,2,'de','Wird dem Benutzer nach der Registrierung angezeigt, wenn diese vom Administrator noch bestatigt werden muss','<h3>{user_login}</h3>\r\n<h4>Vielen Dank fur Ihre Registrierung.</h4>\r\n<h5>Ihr Account muss von einem Adminstrator noch bestatigt werden, bevor er gultig wird.</h5>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES
  (17,3,'de','Wird dem Benutzer nach der Registrierung angezeigt, wenn keine weitere Bestatigung erfolgen muss','<h3>{user_login}</h3>\r\n<h4>Vielen Dank fur Ihre Registrierung.</h4>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES
  (18,4,'de','Wird nach dem Andern des Passworts angezeigt','<h3>{user_login}</h3>\r\n<p>Ihr Passwort wurde ergolgreich geandert.</p>\r\n<p><a href="profile.php">Zuruck zum Profil</a></p>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES
  (19,5,'de','Wird nach der Bestatigung des Accounts angezeigt','<h3>{user_login}</h3>\r\n<h2>Ihr Account in nun aktiv.</h2>\r\n');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES
  (20,6,'de','Wird angezeigt, nachdem das Passwort versendet wurde','<h2>E-Mail gesendet</h2>\r\n<p>Wenn Sie den korrekten Benutzernamen oder die korrekte E-Mail-Adresse fur den Account angegeben haben, wird eine Bestatigung an die angegebene E-Mail-Adresse versendet.</p><p>Bitte prufen Sie Ihren Posteingang.</p><a href=".">Zuruck zur Hauptseite</a>.</p>');
INSERT INTO contents_langs (content_lang_id, content_id, language_id, content_desc,content_value) VALUES
  (21,7,'de','Wird in der "Passwort vergessen"-Seite angezeigt','<h2>Willkommen, {user_login}</h2>\r\n<p>Sie konnen Ihr Passwort jetzt andern.</p>\r\n');

SET IDENTITY_INSERT contents_langs OFF
go


SET IDENTITY_INSERT custom_fields ON
go
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (1,'Location','Location',1);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (2,'Cost','Cost',1);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (3,'URL','URL',1);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (4,'TextBox1','TextBox 1',0);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (5,'TextBox2','TextBox 2',0);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (6,'TextBox3','TextBox 3',0);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (7,'TextArea1','TextArea 1',0);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (8,'TextArea2','TextArea 2',0);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (9,'TextArea3','TextArea 3 EN',0);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (10,'CheckBox1','CheckBox 1',0);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (11,'CheckBox2','CheckBox 2',0);
INSERT INTO custom_fields (field_id, field_name, field_label, field_is_active) VALUES (12,'CheckBox3','CheckBox 3',0);
SET IDENTITY_INSERT custom_fields OFF
go


SET IDENTITY_INSERT custom_fields_langs ON
go
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (1,'en',1,'Location');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (2,'ru',1,'Расположение');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (3,'en',2,'Cost');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (4,'ru',2,'Стоимость');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (5,'en',3,'URL');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (6,'ru',3,'URL');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (7,'en',4,'TextBox 1');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (8,'ru',4,'Поле ввода 1');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (9,'en',5,'TextBox 2');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (10,'ru',5,'Поле ввода 2');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (11,'en',6,'TextBox 3');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (12,'ru',6,'Поле ввода 3');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (13,'en',7,'TextArea 1');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (14,'ru',7,'Область текста 1');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (15,'en',8,'TextArea 2');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (16,'ru',8,'Область текста  2');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (17,'en',9,'TextArea 3');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (18,'ru',9,'Область текста  3');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (19,'en',10,'CheckBox 1');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (20,'ru',10,'Поле выбора 1');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (21,'en',11,'CheckBox 2');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (22,'ru',11,'Поле выбора 2');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (23,'en',12,'CheckBox 3');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (24,'ru',12,'Поле выбора 3');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (25,'de',1,'Ort');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (26,'de',2,'Preis');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (27,'de',3,'URL');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (28,'de',4,'TextBox 1');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (29,'de',5,'TextBox 2');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (30,'de',6,'TextBox 3');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (31,'de',7,'TextArea 1');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (32,'de',8,'TextArea 2');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (33,'de',9,'TextArea 3');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (34,'de',10,'CheckBox 1');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (35,'de',11,'CheckBox 2');
INSERT INTO custom_fields_langs (field_lang_id, language_id, field_id, field_label) VALUES (36,'de',12,'CheckBox 3');
SET IDENTITY_INSERT custom_fields_langs OFF
go



SET IDENTITY_INSERT permissions ON
go
INSERT INTO permissions (permission_id, permission_var, permission_desc, permission_value, permission_type, permission_category)
  VALUES (1,'new_event','Who can add new events',100,2,1);
INSERT INTO permissions (permission_id, permission_var, permission_desc, permission_value, permission_type, permission_category)
  VALUES (2,'public_update','Who can UPDATE public events',50,1,2);
INSERT INTO permissions (permission_id, permission_var, permission_desc, permission_value, permission_type, permission_category)
  VALUES (3,'public_delete','Who can DELETE public events',50,1,2);
INSERT INTO permissions (permission_id, permission_var, permission_desc, permission_value, permission_type, permission_category)
  VALUES (4,'private_read','Who can READ private events',50,1,3);
INSERT INTO permissions (permission_id, permission_var, permission_desc, permission_value, permission_type, permission_category)
  VALUES (5,'private_update','Who can UPDATE private events',100,1,3);
INSERT INTO permissions (permission_id, permission_var, permission_desc, permission_value, permission_type, permission_category)
  VALUES (6,'private_delete','Who can DELETE private events',100,1,3);
SET IDENTITY_INSERT permissions OFF
go


SET IDENTITY_INSERT permissions_langs ON
go
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES (1,1,'en','Who can add new events');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (2,1,'ru','Кто может добавлять новые события');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (3,2,'en','Who can UPDATE public events');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (4,2,'ru','Кто может ИЗМЕНЯТЬ события доступные всем');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (5,3,'en','Who can DELETE public events');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (6,3,'ru','Кто может УДАЛЯТЬ события доступные всем');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (7,4,'en','Who can READ private events');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (8,4,'ru','Кто может ЧИТАТЬ личные события');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (9,5,'en','Who can UPDATE private events');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (10,5,'ru','Кто может ИЗМЕНЯТЬ личные события');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (11,6,'en','Who can DELETE private events');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES  (12,6,'ru','Кто может УДАЛЯТЬ личные события');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES (13,1,'de','Wer kann neue Events einfugen');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES (14,2,'de','Wer kann offentliche Events aktualisieren');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES (15,3,'de','Wer kann offentliche Events loschen');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES (16,4,'de','Wer kann offentliche Events loschen');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES (17,5,'de','Wer kann private Events lesen');
INSERT INTO permissions_langs (permission_lang_id, permission_id, language_id, permission_desc) VALUES (18,6,'de','Wer kann private Events lesen loschen');

SET IDENTITY_INSERT permissions_langs OFF
go



SET IDENTITY_INSERT email_templates ON
go
INSERT INTO email_templates (email_template_id, email_template_type, email_template_desc, email_template_subject,email_template_body) VALUES
  (1,'confirm_registration','Body of confirmation message sent after registration.<br>Use predefined tags:<br> {user_login} for login,<br>{user_email} for user e-mail, <br>{date_time} for reristration date,<br>{activate_url} for activation URL.', 'Confirmation message', 'Welcome {user_login},\r\nOn {date_time} we''ve received a request of registration to our online calendar for {user_email} email address.\r\nIf you want to confirm the registration, visit {activate_url} page.\r\n\r\nIf you received this email as an error, ignore and delete it.\r\n\r\nThis registration will expire in 24 hours.');
INSERT INTO email_templates (email_template_id, email_template_type, email_template_desc, email_template_subject,email_template_body) VALUES
  (2,'approval_message','Message sent after the administrator approval. <br>Use the predefined tags:<br> {user_login} as login,<br>{site_url} as site URL.', 'Your account was approved', 'Welcome {user_login},\r\n\r\nYour account  was approved by the administrator\r\n\r\nLink:  {site_url}.');
INSERT INTO email_templates (email_template_id,email_template_type, email_template_desc,email_template_subject,email_template_body) VALUES
  (3,'forgot_password','Email sent to users who forgot password<br>Use predefined tags:<br>{activate_url} for activation URL.','Forgot password', 'Someone (presumably you) requested a password change. If this was not you, ignore this message, your data will be left unchanged.\r\n\r\nOtherwise, please visit the following URL to change your password:  \r\n\r\n {activate_url}');
SET IDENTITY_INSERT email_templates OFF
go


SET IDENTITY_INSERT email_templates_lang ON
go
INSERT INTO email_templates_lang (email_template_lang_id,language_id,email_template_id,email_template_desc,email_template_subject,email_template_body) 
 VALUES (1,'en',1,'Сonfirmation message sent after registration.<br>Use predefined tags:<br> {user_login} for login,<br>{user_email} for user e-mail, <br>{date_time} for registration date,<br>{activate_url} for activation URL.','confirmation message','Welcome {user_login},\r\nOn {date_time} we''ve received a request of registration to our online calendar for {user_email} email address.\r\nIf you want to confirm the registration, visit {activate_url} page.\r\n\r\nIf you received this email as an error, ignore and delete it.\r\n\r\nThis registration will expire in 24 hours.');
INSERT INTO email_templates_lang (email_template_lang_id,language_id,email_template_id,email_template_desc,email_template_subject,email_template_body) 
 VALUES (2,'ru',1,'Регистрация.<br>Используемые теги:<br> {user_login} для логина,<br>{user_email} для e-mail, <br>{date_time} для даты регистрации,<br>{activate_url} ссылка для активации.','Подтверждение регистрации','Здравствуйте, {user_login},\r\n{date_time} Вы зарегистрировались в системе VCalendar используя email {user_email}.\r\n\r\nЕсли вы хотите подтвердить регистрацию зайдите по ссылке {activate_url}.\r\n\r\nЕсли Вы получили письмо по ошибке, удалите его.\r\n\r\nНе подтвержденная регистрация будет удалена через 24 часа.');
INSERT INTO email_templates_lang (email_template_lang_id,language_id,email_template_id,email_template_desc,email_template_subject,email_template_body) 
 VALUES (3,'en',2,'Message sent after the administrator approval. <br>Use the predefined tags:<br> {user_login} as login,<br>{site_url} as site URL.','Your account was approved','Welcome {user_login},\r\n\r\nYour account  was approved by the administrator\r\n\r\nLink:  {site_url}.');
INSERT INTO email_templates_lang (email_template_lang_id,language_id,email_template_id,email_template_desc,email_template_subject,email_template_body) 
 VALUES (4,'ru',2,'Подтвердения администратором. <br>Используемые теги:<br> {user_login} для логин,<br>{site_url} URL сайта.','Ваш аккаунт подтвержден','Здравствуйте, {user_login}.\r\n\r\nВаш аккаунт был утвержден администратором\r\n\r\nСайт:  {site_url}.');
INSERT INTO email_templates_lang (email_template_lang_id,language_id,email_template_id,email_template_desc,email_template_subject,email_template_body) 
 VALUES (5,'en',3,'Email sent to users who forgot password<br>Use predefined tags:<br>{activate_url} for activation URL.','Forgot password','Someone (presumably you) requested a password change. If this was not you, ignore this message, your data will be left unchanged.\r\n\r\nOtherwise, please visit the following URL to change your password:  \r\n\r\n {activate_url}');
INSERT INTO email_templates_lang (email_template_lang_id,language_id,email_template_id,email_template_desc,email_template_subject,email_template_body) 
 VALUES (6,'ru',3,'Письмо пользователю, который забыл пароль<br>Используемые теги {activate_url} URL для изменения пароля.','Забыли пароль?','Кто-то (предположительно, Вы) запросили изменение пароля. Если это были не Вы, проигнорируйте это письмо, иноформация останется без изменения. \r\n\r\n В  противном случае, откройте следующую страницу для изменения Вашего пароля: \r\n\r\n{activate_url}');
INSERT INTO email_templates_lang (email_template_lang_id,language_id,email_template_id,email_template_desc,email_template_subject,email_template_body)
  VALUES (7,'de',1,'Bestatigungs-E-Mail nach der Registrierung','Bestatigung','Willkommen {user_login},\r\n\r\nam {date_time} wurde in unserem Online-Veranstaltungkalender ein Account fur die E-Mail-Adresse {user_email} beantragt. Wenn Sie diesen Account bestatigen mochten, dann besuchen Sie bitte die Aktivierungsseite {activate_url}.\r\n\r\nWenn Sie diese E-Mail nicht angefordert haben, so loschen Sie sie bitte.\r\n\r\nDie Bestatigung der Registrierung ist nur innerhalb von 24 Stunden moglich.\r\n');
INSERT INTO email_templates_lang (email_template_lang_id,language_id,email_template_id,email_template_desc,email_template_subject,email_template_body)
  VALUES (8,'de',2,'Nachricht nach Bestatigung durch den Administrator','Ihr Account wurde bestatigt','Willkommen {user_login},\r\n\r\nIhr Account wurde durch den Administrator bestatigt. und ist ab sofort gultig.\r\n\r\nLink:  {site_url}.\r\n');
INSERT INTO email_templates_lang (email_template_lang_id,language_id,email_template_id,email_template_desc,email_template_subject,email_template_body)
  VALUES (9,'de',3,'E-Mail fur Benutzer, die ihr Passwort vergessen haben','Passwort vergessen','Jemand (vermutlich Sie) hat eine Passwort-Anderung veranlasst. Falls Sie dies nicht waren, so loschen Sie bitte diese E-Mail; Ihre Daten bleiben weiterhin gultig.\r\n\r\nAnsonsten folgen Sie bitte dem untenstehenden Link und andern Sie Ihr Passwort:  \r\n\r\n{activate_url}\r\n');
SET IDENTITY_INSERT email_templates_lang OFF
go



SET IDENTITY_INSERT users ON
go
INSERT INTO users (user_id, user_login, user_password, user_level, user_email, user_first_name, user_last_name, user_is_approved, user_access_code) VALUES 
  (1,'admin','admin',100,'admin@company.com','Admin','Admin',1,0);
INSERT INTO users (user_id, user_login, user_password, user_level, user_email, user_first_name, user_last_name, user_is_approved, user_access_code) VALUES 
  (2,'user','user',10,'user@company.com','user','user',1,0);
SET IDENTITY_INSERT users OFF
go
