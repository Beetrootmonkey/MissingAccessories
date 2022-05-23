using Terraria;
using MissingAccessories;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.World
{
    class ModPlayer : Terraria.ModLoader.ModPlayer
    {
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(item, target, damage, knockback, crit);
            if (Utils.HasAccessory(player.armor, this.mod, "IcebornGauntlet"))
            {
                target.AddBuff(44, 5 * 60);
            }
        }
    }
}
