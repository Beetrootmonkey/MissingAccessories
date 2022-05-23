using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Accessories
{
    public class StackedBonetoothNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bonetooth Necklace");
            Tooltip.SetDefault("Increases armor penetration by 12"
                + "\nIncreases damage by 12%");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 28;
            item.rare = 8;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 12;
            player.meleeDamage += 0.12f;
            player.rangedDamage += 0.12f;
            player.magicDamage += 0.12f;
            player.minionDamage += 0.12f;
            player.thrownDamage += 0.12f;
        }
    }
}

