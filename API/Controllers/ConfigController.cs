using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigController : ControllerBase
    {
        private IOptionsMonitor<SampleOptions> _opts;

        private SampleOptions Options
        {
            get
            {
                return _opts.CurrentValue;
            }
        }

        public ConfigController(IOptionsMonitor<SampleOptions> opts)
        {
            _opts = opts;
        }

        [HttpGet]
        public IActionResult GetConfigs()
        {
            var data = new Dictionary<string, string>();
            data["ResolvedPlaceholderFromEnvVariables"] = Options.ResolvedPlaceholderFromEnvVariables;
            data["ResolvedPlaceholderFromJson"] = Options.ResolvedPlaceholderFromJson;
            data["UnresolvedPlaceholder"] = Options.UnresolvedPlaceholder;
            return Ok(data);
        }
    }
}