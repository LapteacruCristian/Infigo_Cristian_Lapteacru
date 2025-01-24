using CMSPlus.Domain.Models.CommentModels;
using FluentValidation;

namespace CMSPlus.Presentation.Validations;
public class CommentCreateModelValidator:AbstractValidator<CommentCreateModel>
{
    public CommentCreateModelValidator()
    {
        RuleFor(comment => comment.FullName)
            .NotEmpty().WithMessage("Full name is required")
            .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters")
            .Matches(@"^[a-zA-z\s]+$").WithMessage("Full name can only contain letters and spaces.");

        RuleFor(comment => comment.CommentText)
           .NotEmpty().WithMessage("Comment Text cannot be empty")
           .MaximumLength(1000).WithMessage("Comment text cannot exceed 1000 characters");
    }
}
