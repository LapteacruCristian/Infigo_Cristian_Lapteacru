namespace CMSPlus.Domain.Models.CommentModels;

public class CommentCreateModel : BaseCommentModel
{
    public int TopicId { get; set; }
    public string? TopicSystemName { get; set; }
}