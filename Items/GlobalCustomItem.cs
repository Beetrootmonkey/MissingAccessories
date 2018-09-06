using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    class GlobalCustomItem : GlobalItem
    {
        public override bool CanEquipAccessory(Item item, Player player, int slot)
        {
            if (item.type == 216)
            {
                return Chain.CanEquipAccessory(mod, player, slot);
            }
            else
            {
                return base.CanEquipAccessory(item, player, slot);
            }

        }
    }
}
