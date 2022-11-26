using System.ComponentModel.DataAnnotations.Schema;
using SS.Domain.Contracts;
using SS.Domain.Users;

namespace SS.Domain.Blog;

public class Article : AuditableEntity
{
    private int _totAgreeReactions;
    private int _totComments;
    private int _totDisagreeReactions;
    private int _totNeutralReactions;
    private int _totReactions;

    public Article() { }

    public string Title { get; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public bool AllowComments { get; set; } = true;
    public ArticleType ArticleType { get; set; }
    public PublishedStatus PublishedStatus { get; set; }
    public int PostViews { get; set; }
    public double Rating { get; set; }
    public bool IsFeatured { get; set; }
    public bool Selected { get; set; }
    public DateTime Published { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public bool Edited { get; set; }
    public List<string>? Edits { get; set; }
    public List<string>? Images { get; set; }
    public ICollection<Reaction>? Reactions { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<ArticleCategory> ArticleCategories { get; set; }

    [NotMapped]
    public int TotDisagreeReactions
    {
        get
        {
            var count = 0;
            if (Reactions != null)
                for (var fact = 0; fact < Reactions.Count; fact++)
                    if (Reactions.ElementAt(fact).ReactionType.Equals(UserReaction.Disagree))
                        count++;

            return Reactions != null ? count : _totAgreeReactions;
        }
        set => _totDisagreeReactions = value;
    }

    [NotMapped]
    public int TotAgreeReactions
    {
        get
        {
            var count = 0;
            if (Reactions != null)
                for (var reactionCount = 0; reactionCount < Reactions.Count; reactionCount++)
                    if (Reactions.ElementAt(reactionCount).ReactionType.Equals(UserReaction.Agree))
                        count++;

            return Reactions != null ? count : _totDisagreeReactions;
        }
        set => _totAgreeReactions = value;
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

            return Reactions != null ? count : _totNeutralReactions;
        }
        set => _totNeutralReactions = value;
    }

    [NotMapped]
    public int TotComments
    {
        get => Comments?.Count ?? _totComments;
        set => _totComments = value;
    }

    [NotMapped]
    public int TotReactions
    {
        get => Reactions?.Count ?? _totReactions;
        set => _totReactions = value;
    }
}