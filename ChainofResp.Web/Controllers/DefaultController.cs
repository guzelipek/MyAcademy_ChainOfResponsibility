using ChainofResp.Web.ChainOfResponsibilityPattern;
using ChainofResp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainofResp.Web.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Treasurer _treasurer;
        private readonly Manager _manager;
        private readonly AssistantManager _assistantManager;
        private readonly RegionalManager _regionalManager;

        public DefaultController(Treasurer treasurer, Manager manager, AssistantManager assistantManager, RegionalManager regionalManager)
        {
            _treasurer = treasurer;
            _manager = manager;
            _assistantManager = assistantManager;
            _regionalManager = regionalManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            _treasurer.SetNextApprover(_assistantManager);
            _assistantManager.SetNextApprover(_manager);
            _manager.SetNextApprover(_regionalManager);
            _treasurer.ProcessRequest(model);
            return NoContent();
        }
    }
}
