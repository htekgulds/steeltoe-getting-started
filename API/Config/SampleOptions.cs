using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Config
{
    public class SampleOptions
    {
          public string ResolvedPlaceholderFromEnvVariables { get; set; }
          public string UnresolvedPlaceholder { get; set; }
          public string ResolvedPlaceholderFromJson { get; set; }
    }
}