using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Services.Interfaces;

namespace CMSPlus.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task Create(CommentEntity entity)
    {
        await _commentRepository.Create(entity);
    }

    public async Task<IEnumerable<CommentEntity>> GetByTopicId(int topicId)
    {
        return await _commentRepository.GetByTopicId(topicId);
    }
}
