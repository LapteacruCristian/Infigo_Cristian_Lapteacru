using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using CMSPlus.Domain.Models.CommentModels;
using CMSPlus.Domain.Models.TopicModels;
using CMSPlus.Services.Services;

namespace CMSPlus.Presentation.Controllers;

public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    private readonly ITopicService _topicService;
    private readonly IMapper _mapper;
    private readonly IValidator<CommentCreateModel> _createModelValidator;

    public CommentController(ICommentService commentService, ITopicService topicService, IMapper mapper, IValidator<CommentCreateModel> createModelValidator)
    {
        _commentService = commentService;
        _topicService = topicService;
        _mapper = mapper;
        _createModelValidator = createModelValidator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CommentCreateModel model)
    {
        var validationCommentResult = await _createModelValidator.ValidateAsync(model);
        if (!validationCommentResult.IsValid)
        {

            var topic = await _topicService.GetBySystemName(model.TopicSystemName);
            if (topic == null)
            {
                throw new ArgumentException($"Item with system name: {model.TopicSystemName} wasn't found!");
            }
            var comments = await _commentService.GetByTopicId(topic.Id);

            var topicDto = _mapper.Map<TopicEntity, TopicDetailsModel>(topic);

            topicDto.Comments = comments.Select(comment => _mapper.Map<CommentEntity, CommentModel>(comment)).ToList();

            validationCommentResult.AddToModelState(this.ModelState);
            return View("../Topic/Details", topicDto);
        }

        var commentEntity = _mapper.Map<CommentCreateModel, CommentEntity>(model);

        await _commentService.Create(commentEntity);
        return RedirectToAction("Details", "Topic", new { SystemName = model.TopicSystemName });
    }
}