﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    [AutoloadEquip(EquipType.Shoes)]
    public class ReallyGoodBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows flight, super fast running, and extra mobility on ice"
                + "\n7 % increased movement speed"
                + "\nProvides the ability to walk on water and lava"
                + "\nGrants immunity to fire blocks and 7 seconds of immunity to lava");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 24;
            item.rare = 7;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed = 6.75f;
            player.rocketBoots = 3;
            player.moveSpeed += 0.07f;
            player.iceSkate = true;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaMax += 420;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
