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
                return BadRequest("��� ������ ��� ����������.");
            }

            try
            {
                bool isAdd = await _mouseMovementService.Add(jsonData);

                if (!isAdd)
                {
                    return BadRequest("������ �� �����������.");
                }

                return Ok(new { message = "������ ������� ���������"});
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"������ ���������� ������.");
                return BadRequest($"������ ���������� ������.");
            }
        }

    }
}
