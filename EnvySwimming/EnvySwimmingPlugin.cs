using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Core.Utils;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace EnvySwimming
{
    public class EnvySwimmingPlugin : RocketPlugin<EnvySwimmingConfiguration>
    {
        public static EnvySwimmingPlugin Instance { get; set; }
        protected override void Load()
        {
            Instance = this;
            Logger.LogWarning("Creado Por Margarita#8172");

        }


        public void FixedUpdate()
        {
            TaskDispatcher.QueueOnMainThread(() =>
            {
                foreach (var item in Provider.clients)
                {
                    UnturnedPlayer player = UnturnedPlayer.FromSteamPlayer(item);
                    if(player.Player.stance.isSubmerged || player.Player.stance.isBodyUnderwater)
                    {
                        if (!player.HasPermission(Configuration.Instance.PermissionByPass)){

                            //player.Teleport(new Vector3(player.Position.x, player.Position.y, player.Position.z), player.Rotation);
                            player.Damage(1, player.Position, EDeathCause.WATER, ELimb.SKULL, player.CSteamID);
                        }
                    }
                }
            });
        }
        protected override void Unload()
        {
            base.Unload();
        }
    }
}
