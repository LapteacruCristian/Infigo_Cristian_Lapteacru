﻿using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.CommentModels;
using CMSPlus.Domain.Models.TopicModels;

namespace CMSPlus.Presentation.AutoMapperProfiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CommentEntity, CommentModel>();
        CreateMap<CommentModel, CommentEntity>();
        CreateMap<CommentEntity, CommentCreateModel>();
        CreateMap<CommentCreateModel, CommentEntity>();
    }
}