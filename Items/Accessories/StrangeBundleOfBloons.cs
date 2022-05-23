using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Accessories
{
    [AutoloadEquip(EquipType.Balloon)]
    public class StrangeBundleOfBloons : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows the holder to triple jump"
                + "\nIncreases jump height"
                + "\nReleases bees when damaged");
            DisplayName.SetDefault("Strange Bundle of Bloons");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 28;
            item.rare = 8;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // TODO: Honey Balloon jump?
            player.doubleJumpFart = true;
            player.doubleJumpSail = true;
            player.jumpBoost = true;
            player.noFallDmg = true;
            player.bee = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SharkronBalloon);
            recipe.AddIngredient(ItemID.FartInABalloon);
            recipe.AddIngredient(ItemID.HoneyBalloon);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}