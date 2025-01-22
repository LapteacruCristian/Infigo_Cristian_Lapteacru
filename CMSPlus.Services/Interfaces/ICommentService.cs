using CMSPlus.Domain.Entities;

namespace CMSPlus.Services.Interfaces;

public interface ICommentService
{
    public Task Create(CommentEntity entity);
    public Task<IEnumerable<CommentEntity>> GetByTopicId(int topicId);
}
