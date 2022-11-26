using System.ComponentModel.DataAnnotations.Schema;
using SS.Domain.Contracts;
using SS.Domain.Users;

namespace SS.Domain.Blog;

public class Comment : AuditableEntity
{
    private string _Author;

    private string _Parent;

    private int _TotAgreeReactions;
    private int _TotComments;

    private int _TotDisagreeReactions;

    private int _TotNeutralReactions;

    private int _TotReactions;

    public Comment(
        string content, 
        Guid? articleId, 
        Guid? commentId,
        string applicationUserId)
    {
        Content = content;
        ArticleId = articleId;
        CommentId = commentId;
        ApplicationUserId = applicationUserId;
    }

    public List<string>? Images { get; set; }
    public string Content { get; set; }
    public Guid? ArticleId { get; set; }
    public Guid? CommentId { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public bool Edited { get; set; }
    public List<string>? Edits { get; set; }
    public ICollection<Comment>? Replies { get; set; }
    public ICollection<Reaction>? Reactions { get; set; }

    [NotMapped]
    public string Parent
    {
        get => (ArticleId ?? CommentId).ToString()!;
        set => _Parent = value;
    }

    [NotMapped]
    public int TotFactReactions
    {
        get
        {
            var count = 0;
            if (Reactions != null)
                for (var fact = 0; fact < Reactions.Count; fact++)
                    if (Reactions.ElementAt(fact).ReactionType.Equals(UserReaction.Disagree))
                        count++;

            return Reactions != null ? count : _TotDisagreeReactions;
        }
        set => _TotDisagreeReactions = value;
    }

    [NotMapped]
    public int TotAgreeReactions
    {
        get
        {
            var count = 0;
            if (Reactions != null)
                for (var fact = 0; fact < Reactions.Count; fact++)
                    if (Reactions.ElementAt(fact).ReactionType.Equals(UserReaction.Agree))
                        count++;

            return Reactions != null ? count : _TotAgreeReactions;
        }
        set => _TotAgreeReactions = value;
    }

    [NotMapped]
    public int TotNeutralReactions
    {
        get
        {
            var count = 0;
            if (Reactions != null)
                for (var fact = 0; fact < Reactions.Count; fact++)
                    if (Reactions.ElementAt(fact).ReactionType.Equals(UserReaction.Neutral))
                        count++;

            return Reactions != null ? count : _TotNeutralReactions;
        }
        set => _TotNeutralReactions = value;
    }

    [NotMapped]
    public int TotComments
    {
        get => Replies != null ? Replies.Count : _TotComments;
        set => _TotComments = value;
    }

    [NotMapped]
    public int TotReactions
    {
        get => Reactions != null ? Reactions.Count : _TotReactions;
        set => _TotReactions = value;
    }
}