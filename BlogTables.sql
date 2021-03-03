CREATE TABLE USER_DETAILS (USER_ID int IDENTITY(1,1) PRIMARY KEY,NAME varchar(100),EMAIL varchar(100))
GO
CREATE TABLE BLOGS (BLOG_ID int IDENTITY(1,1) PRIMARY KEY,BLOG_HEADER varchar(100), CONTENT text)
GO
CREATE TABLE USER_X_BLOGS(USER_ID int, BLOG_ID int, FOREIGN KEY (USER_ID) REFERENCES USER_DETAILS(USER_ID), FOREIGN KEY (BLOG_ID) REFERENCES BLOGS(BLOG_ID) )
GO

INSERT INTO USER_DETAILS(NAME,EMAIL) VALUES('GrapeCity','grape@123.com')