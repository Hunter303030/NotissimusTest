using NotissimusTest.Models;

namespace NotissimusTest.Service.Interface
{
    public interface IMouseMovementService
    {
        public Task<bool> Add(string jsonData);
    }
}
