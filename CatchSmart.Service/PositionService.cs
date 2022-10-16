using CatchSmart.Core.Models;
using CatchSmart.Core.Services;
using CatchSmart.Db;
using System.Linq;

namespace CatchSmart.Service
{
    public class PositionService : EntityService<Positions>, IPositionService
    {
        public PositionService(CatchSmartDbContext context) : base(context)
        {
        }
        public Positions AddPositions(string title)
        {
            var position = new Positions
            {
                Title = title
            };

            return position;
        }

        public Positions GetPositionByName(string title)
        {
            return _context.Positions.FirstOrDefault(c => c.Title == title);
        }
    }
}