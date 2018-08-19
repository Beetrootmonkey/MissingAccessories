﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    class TrueBladeBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'I bet you have tiny feet.'");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useAnimation = 30;
            item.knockBack = 8.5f;
            item.width = 70;
            item.height = 80;
            item.damage = 120;
            item.scale = 1.05f;
            item.UseSound = SoundID.Item1;
            item.rare = 4;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.melee = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BreakerBlade);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

