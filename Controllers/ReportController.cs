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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]string firstname, [FromForm] string lastname)
        {
            var result = await _nodeServices.InvokeExportAsync<Document>(
                                    "./node/carbone.js", // Path to our JavaScript file
                                    "create", // Exported function name
                                    JsonConvert.SerializeObject(new { firstname, lastname })); // Arguments, in this case a json string

            return File(result.data, "application/vnd.oasis.opendocument.text");
        }
    }
}


public class Document
{
    public string type { get; set; }
    public byte[] data { get; set; }
}
