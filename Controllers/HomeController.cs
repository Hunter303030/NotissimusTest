using Microsoft.AspNetCore.Mvc;
using NotissimusTest.Service.Interface;

namespace NotissimusTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMouseMovementService _mouseMovementService;

        public HomeController(ILogger<HomeController> logger, IMouseMovementService mouseMovementService)
        {
            _logger = logger;
            _mouseMovementService = mouseMovementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveMouseData([FromForm] string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
            {
                return BadRequest("Нет данных для сохранения.");
            }

            try
            {
                bool isAdd = await _mouseMovementService.Add(jsonData);

                if (!isAdd)
                {
                    return BadRequest("Данные не сохранились.");
                }

                return Ok(new { message = "Данные успешно сохранены"});
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"Ошибка сохранения данных.");
                return BadRequest($"Ошибка сохранения данных.");
            }
        }

    }
}
