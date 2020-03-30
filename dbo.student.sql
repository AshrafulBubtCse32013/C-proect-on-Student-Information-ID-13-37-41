CREATE TABLE [dbo].[student] (
    [sname]  VARCHAR (MAX) NOT NULL,
    [sadd]   VARCHAR(MAX) NULL,
    [phone]  INT          NULL,
    [sem]    INT          NULL,
    [branch] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([sname] ASC)
);

