namespace MinimalApiDemo.Api.Services.PornStars;

public interface IPornStarService
{
    IEnumerable<PornStar> GetPornStars();

    PornStar GetPornStarById(int id);
}
