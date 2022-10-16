using CatchSmart.Core.Models;

namespace CatchSmart.Core.Services
{
    public interface IPositionService : IEntityService<Positions>
    {
        Positions AddPositions(string title);
        Positions GetPositionByName(string title);
    }
}