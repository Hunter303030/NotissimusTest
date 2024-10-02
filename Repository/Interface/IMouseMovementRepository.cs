using NotissimusTest.Models;

namespace NotissimusTest.Repository.Interface
{
    public interface IMouseMovementRepository
    {
        public Task<bool> Add(IEnumerable<MouseMovement> movements);
    }
}
