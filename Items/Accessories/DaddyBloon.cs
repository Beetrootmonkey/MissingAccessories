using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Accessories
{
    [AutoloadEquip(EquipType.Balloon)]
    public class DaddyBloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows the holder to sextuple jump"
                + "\nNegates fall damage"
                + "\nIncreases jump height"
                + "\nReleases bees when damaged"
                + "\nGrants immunity to fire blocks");
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
            player.doubleJumpBlizzard = true;
            player.doubleJumpCloud = true;
            player.doubleJumpSandstorm = true;
            player.doubleJumpFart = true;
            player.doubleJumpSail = true;
            player.jumpBoost = true;
            player.noFallDmg = true;
            player.autoJump = true;
            player.jumpSpeedBoost += 2.4f;
            player.extraFall += 15;
            player.bee = true;
            player.fireWalk = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this.mod, "StrangeBundleOfBloons");
            recipe.AddIngredient(ItemID.BundleofBalloons);
            recipe.AddIngredient(ItemID.FrogLeg);
            recipe.AddIngredient(ItemID.ObsidianHorseshoe);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
