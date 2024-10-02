using NotissimusTest.Data;
using NotissimusTest.Models;
using NotissimusTest.Repository.Interface;

namespace NotissimusTest.Repository
{
    public class MouseMovementRepository: IMouseMovementRepository
    {
        private readonly DataContext _context;

        public MouseMovementRepository( DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(IEnumerable<MouseMovement> movements)
        {
            if (movements == null) return false;

            await _context.MouseMovement.AddRangeAsync(movements);
            
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
