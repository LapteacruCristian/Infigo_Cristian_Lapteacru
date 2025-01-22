﻿namespace CMSPlus.Domain.Models.CommentModels;

public class CommentModel : BaseCommentModel
{
    public CommentModel()
    {
        CreatedOnUtc = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public int TopicId { get; set; }
    public DateTime? CreatedOnUtc { get; set; }
}