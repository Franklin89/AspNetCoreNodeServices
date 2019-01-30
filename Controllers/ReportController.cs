using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Newtonsoft.Json;

namespace CarboneAsNodeService.Controllers
{
    public class ReportController : Controller
    {
        private readonly INodeServices _nodeServices;

        public ReportController(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await _nodeServices.InvokeExportAsync<byte[]>("./node/carbone.js", "create",
                                    JsonConvert.SerializeObject(new { firstname = "Matteo", lastname = "Locher" }));

            return File(result, "odt");
        }
    }
}