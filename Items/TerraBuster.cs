using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    class TerraBuster : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Terra Blade's big brother.'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.useStyle = 1;
            item.damage = 100;
            item.useAnimation = 20;
            item.useTime = 20;
            item.width = 86;
            item.height = 100;
            item.shoot = 132;
            item.scale = 1.3f;
            item.shootSpeed = 16f;
            item.melee = true;
            item.value = Item.sellPrice(0, 30, 0, 0);
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TrueBladeBreaker");
            recipe.AddIngredient(ItemID.TerraBlade);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        // Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
        // See Source code for Star Wrath projectile to see how it passes through tiles.
        //	The following changes to SetDefaults 

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int amount = Main.rand.Next(1, 3);
            for (int i = 0; i < amount; i++)
            {
                Vector2 target = Main.screenPosition
                    + new Vector2((float)Main.mouseX, (float)Main.mouseY)
                    + new Vector2((float)Main.rand.Next(-20, 20), (float)Main.rand.Next(-20, 20));

                position = player.Center
                    + new Vector2(((float)Main.rand.Next(0, 10) * player.direction), ((float)Main.rand.Next(-20, 20)));
                Vector2 heading = target - position;
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)(damage * 1.2), knockBack, player.whoAmI);
            }
            return false;
        }
    }
}

