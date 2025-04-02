namespace TestBoomBit.Application.Interface.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        IActivitiesRepository Activities { get; }
        ICountryRepository Countries { get; }        
    }
}
