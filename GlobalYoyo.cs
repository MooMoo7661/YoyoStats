using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace YoyoStats
{
    public class GlobalYoyo : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {

            if (ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99)
            {
                var instance = ModContent.GetInstance<YoyoStatsConfig>();

                Projectile proj = ContentSamples.ProjectilesByType[item.shoot];
                int updates = proj.MaxUpdates;
                if (proj.extraUpdates == 0) { updates = 1; }
                float yoyoSpeed = ProjectileID.Sets.YoyosTopSpeed[item.shoot] * updates;
                float yoyoRange = ProjectileID.Sets.YoyosMaximumRange[item.shoot] / 16f;
                float yoyoLifetime = ProjectileID.Sets.YoyosLifeTimeMultiplier[item.shoot];
                int maxHits = ContentSamples.ProjectilesByType[item.shoot].penetrate;

                int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Crit"));

                if (index == null)
                {
                    return;
                }

                bool nothingEnabled = false;

                if (!instance.YoyoLifetime && !instance.YoyoHits && !instance.YoyoRange && !instance.YoyoSpeed)
                {
                    nothingEnabled = true;
                }

                string colorizeTooltip = "[c/99EEA2:";
                string coloredTooltip = colorizeTooltip + yoyoSpeed.ToString();

                string lifetimeTooltip = colorizeTooltip + yoyoLifetime.ToString() + Language.GetTextValue("LocalizedText.SecondsLifetime") + "]";
                string maxHitsTooltip = colorizeTooltip + maxHits.ToString() + Language.GetTextValue("LocalizedText.MaximumHits") + "]";
                if (yoyoLifetime < 0)
                {
                    lifetimeTooltip = colorizeTooltip + Language.GetTextValue("LocalizedText.InfiniteLifetime") + "]";
                }

                if (instance.YoyoLifetime)
                    tooltips.Insert(index, new TooltipLine(Mod, "YoyoLifetimeInfo", lifetimeTooltip)); //

                if (maxHits < 0)
                {
                    maxHitsTooltip = colorizeTooltip + Language.GetTextValue("LocalizedText.NoMaximumHits") + "]";
                }

                if (instance.YoyoHits)
                    tooltips.Insert(index, new TooltipLine(Mod, "YoyoMaxHitsInfo", maxHitsTooltip)); //

                if (instance.YoyoSpeed)
                    tooltips.Insert(index, new TooltipLine(Mod, "YoyoSpeedInfo", coloredTooltip + Language.GetTextValue("LocalizedText.BaseYoyoSpeed"))); //

                coloredTooltip = colorizeTooltip + yoyoRange.ToString();
                if (instance.YoyoRange)
                tooltips.Insert(index, new TooltipLine(Mod, "YoyoRangeInfo", coloredTooltip + Language.GetTextValue("LocalizedText.TilesBaseRange"))); //

                if (!nothingEnabled)
                {
                    tooltips.Insert(index, new TooltipLine(Mod, "YoyoStatIdentifier", "[c/99EEA2:" + Language.GetTextValue("LocalizedText.YoyoStats" + "]")));
                }

            }

        }
    }
}