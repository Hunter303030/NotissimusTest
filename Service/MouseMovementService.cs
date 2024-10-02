using Newtonsoft.Json;
using NotissimusTest.Dto;
using NotissimusTest.Models;
using NotissimusTest.Repository;
using NotissimusTest.Repository.Interface;
using NotissimusTest.Service.Interface;

namespace NotissimusTest.Service
{
    public class MouseMovementService : IMouseMovementService
    {
        private readonly IMouseMovementRepository _mouseMovementRepository;

        public MouseMovementService(IMouseMovementRepository mouseMovementRepository)
        {
            _mouseMovementRepository = mouseMovementRepository;
        }

        public async Task<bool> Add(string jsonData)
        {
            if (jsonData == null) return false;

            var mouseMovements = JsonConvert.DeserializeObject<List<MouseMovementDto>>(jsonData);


            if (mouseMovements == null || !mouseMovements.Any()) return false;

            List<MouseMovement> movementsList = new List<MouseMovement>();

            foreach (var movement in mouseMovements)
            {
                var mouseMovement = new MouseMovement
                {
                    Id = Guid.NewGuid(),
                    PointX = movement.PointX,
                    PointY = movement.PointY,
                    Time = movement.Time
                };

                movementsList.Add(mouseMovement);
            }

            if (!movementsList.Any()) return false;

            return await _mouseMovementRepository.Add(movementsList);
        }

    }
}
