using Microsoft.Xna.Framework;
using MissingAccessories.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MissingAccessories.Items.Weapons.ThrowingKnives
{
    class PoisonedThrowingKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Rapidly throw poisoned knives" +
                "\nOccasionally throw a bee");
        }
        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.useStyle = 1;
            item.shootSpeed = 12f;
            item.shoot = ProjectileType<PoisonedThrowingKnife>();
            item.damage = 12;
            item.width = 18;
            item.height = 20;
            item.UseSound = SoundID.Item39;
            item.useAnimation = 20;
            item.useTime = 19;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 1, 40, 0);
            item.knockBack = 2.4f;
            item.melee = true;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PoisonedKnife, 100);
            recipe.AddIngredient(ItemID.JungleSpores, 7);
            recipe.AddIngredient(ItemID.Stinger, 12);
            recipe.AddIngredient(this.mod, "ThrowingKnives");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        // Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
        // See Source code for Star Wrath projectile to see how it passes through tiles.
        //	The following changes to SetDefaults 

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int amount = Main.rand.Next(2, 4);
            for (int i = 0; i < amount; i++)
            {
                Vector2 target = Main.screenPosition
                    + new Vector2((float)Main.mouseX, (float)Main.mouseY)
                    + new Vector2((float)Main.rand.Next(-60, 60), (float)Main.rand.Next(-60, 60));

                position = player.Center
                    + new Vector2(((float)Main.rand.Next(0, 10) * player.direction), ((float)Main.rand.Next(-5, 5)));
                Vector2 heading = target - position;
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)(damage), knockBack, player.whoAmI);
            }

            if (Main.rand.Next(0, 5) == 0)
            {
                Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);

                position = player.Center + new Vector2(((float)Main.rand.Next(0, 10) * player.direction), ((float)Main.rand.Next(-5, 5)));
                Vector2 heading = target - position;
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 181, (int)(damage / 2), knockBack, player.whoAmI);
            }

            return false;
        }
    }
}

