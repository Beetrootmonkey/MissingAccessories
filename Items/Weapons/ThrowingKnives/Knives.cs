using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Weapons.ThrowingKnives
{
    class Knives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[WIP] Sanguine Knives");
            Tooltip.SetDefault("Rapidly throw lifestealing daggers" +
                "\nBring THOSE to a gun fight");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.useStyle = 1;
            item.shootSpeed = 17f;
            item.shoot = 304;
            //item.shoot = 274;
            item.damage = 35;
            item.width = 18;
            item.height = 20;
            //item.UseSound = SoundID.Item39;
            item.UseSound = SoundID.Item71;
            item.useAnimation = 12;
            item.useTime = 12;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 30, 0, 0);
            item.knockBack = 3f;
            item.melee = true;
            item.rare = 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VampireKnives);
            recipe.AddIngredient(ItemID.DeathSickle);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        // Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
        // See Source code for Star Wrath projectile to see how it passes through tiles.
        //	The following changes to SetDefaults 

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int amount = Main.rand.Next(4, 8);
            for (int i = 0; i < amount; i++)
            {
                Vector2 target = Main.screenPosition
                    + new Vector2((float)Main.mouseX, (float)Main.mouseY)
                    + new Vector2((float)Main.rand.Next(-30, 30), (float)Main.rand.Next(-30, 30));

                position = player.Center
                    + new Vector2(((float)Main.rand.Next(0, 10) * player.direction), ((float)Main.rand.Next(-5, 5)));
                Vector2 heading = target - position;
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)(damage), knockBack, player.whoAmI);
            }
            return false;
        }
    }
}

