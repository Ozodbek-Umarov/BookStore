namespace Book.Data.Interfaces;

public interface IUnitOfWork
{
    IAuthorInterface Authors { get; }
    IBookInterface Books { get; }
    IJanrInterface Janrs { get; }
    IUserInterface Users { get; }
    IOrderInterface Orders { get; }
}
