using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class ReallyGoodBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows flight, super fast running, and extra mobility on ice"
                + "\n10% increased movement speed"
                + "\nProvides the ability to walk on water and lava"
                + "\nGrants immunity to fire blocks and 7 seconds of immunity to lava"
                + "\nAllows the holder to sextuple jump"
                + "\nNegates fall damage"
                + "\nIncreases jump height"
                + "\nReleases bees when damaged");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 24;
            item.rare = 9;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed = 6.75f;
            player.rocketBoots = 3;
            player.moveSpeed += 0.1f;
            player.iceSkate = true;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaMax += 420;
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
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddIngredient(this.mod, "DaddyBloon");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
