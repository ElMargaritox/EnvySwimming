using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvySwimming
{
    public class EnvySwimmingConfiguration : IRocketPluginConfiguration
    {
        public string PermissionByPass { get; set; }
        public void LoadDefaults()
        {
            PermissionByPass = "underwater";
        }
    }
}
