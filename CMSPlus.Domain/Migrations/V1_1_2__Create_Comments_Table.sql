USE [CMSPlus]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 21/01/2025 6:31:26 PM ******/
CREATE TABLE [dbo].[Comments] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [TopicId] [int] NOT NULL,
    [FullName] [varchar](255) NOT NULL,
    [CommentText] [varchar](3000) NOT NULL,
    [CreatedOnUtc] [datetime] NOT NULL,
    [UpdatedOnUtc] [datetime] NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY];
    GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [CreatedOnUtc]
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [UpdatedOnUtc]
    GO
ALTER TABLE [dbo].[Comments] WITH CHECK ADD CONSTRAINT [FK_Comments_Topics_TopicId] FOREIGN KEY ([TopicId]) 
    REFERENCES [dbo].[Topics] ([Id])
    ON DELETE CASCADE;
    GO
