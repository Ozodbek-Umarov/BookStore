namespace Book.Data.Interfaces;

public interface IUnitOfWork
{
    IAuthorInterface Authors { get; }
    IBookInterface Books { get; }
    IImageInterface imageInterface { get; }
    IJanrInterface Janrs { get; }
    IOrderInterface Orders { get; }
    IUserInterface Users { get; }
}
