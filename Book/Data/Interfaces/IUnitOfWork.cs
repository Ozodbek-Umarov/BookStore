namespace Book.Data.Interfaces;

public interface IUnitOfWork
{
    IAuthorInterface Authors { get; }
    IBookInterface Books { get; }
/*    IGenreInterface Genres { get; }
    IReviewInterface Reviews { get; }
    IUserInterface Users { get; }*/
}
