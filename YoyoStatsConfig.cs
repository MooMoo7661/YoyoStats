using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace YoyoStats
{
    public class YoyoStatsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool YoyoSpeed { get; set; }

        [DefaultValue(true)]
        public bool YoyoRange { get; set; }

        [DefaultValue(true)]
        public bool YoyoLifetime { get; set; }

        [DefaultValue(true)]
        public bool YoyoHits { get; set; }
    }
}