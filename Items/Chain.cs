using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    [AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
    public abstract class Chain : ModItem
    {
        public override bool CanEquipAccessory(Player player, int slot)
        {
            return Chain.CanEquipAccessory(mod, player, slot);
        }

        public static bool CanEquipAccessory(Mod mod, Player player, int slot)
        {
            return !Utils.HasAccessory(player.armor, 216, slot)
                && !Utils.HasAccessory(player.armor, mod.GetItem("Chain2").item.type, slot)
                && !Utils.HasAccessory(player.armor, mod.GetItem("Chain3").item.type, slot)
                && !Utils.HasAccessory(player.armor, mod.GetItem("Chain4").item.type, slot);
        }
    }
}
