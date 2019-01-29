using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.NodeServices;
using Newtonsoft.Json;

namespace CarboneAsNodeService.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INodeServices _nodeServices;

        public IndexModel(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }
        public async Task OnGetAsync()
        {
            var result = await _nodeServices.InvokeAsync<object>("carbone.js", JsonConvert.SerializeObject(new { firstname = "Matteo", lastname = "Locher" }));
        }
    }
}
