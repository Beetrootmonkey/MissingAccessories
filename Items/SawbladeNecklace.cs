using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    public class SawbladeNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases armor penetration by 25"
                + "\nIncreases all damage by 12%"
                + "\n'Nevermind safety.'");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.accessory = true;
            item.rare = 9;
            item.value = Item.sellPrice(0, 20, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 25;
            player.meleeDamage += 0.12f;
            player.rangedDamage += 0.12f;
            player.magicDamage += 0.12f;
            player.minionDamage += 0.12f;
            player.thrownDamage += 0.12f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this.mod, "StackedBonetoothNecklace");
            recipe.AddIngredient(this.mod, "RazorbladeNecklace");
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
