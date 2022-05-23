using Microsoft.Xna.Framework;
using MissingAccessories.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MissingAccessories.Items.Weapons.ThrowingKnives
{
    class ShadowflameThrowingKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[WIP] Shadowflame Throwing Knives");
            Tooltip.SetDefault("Don't bring those to a goblin invasion");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.useStyle = 1;
            item.shootSpeed = 10f;
            item.shoot = 497;
            item.damage = 9;
            item.width = 18;
            item.height = 20;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.knockBack = 2f;
            item.melee = true;
            item.rare = 2;
        }

        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemID.ThrowingKnife, 100);
        //    recipe.AddTile(TileID.Anvils);
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int amount = Main.rand.Next(1, 3);
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
            return false;
        }
    }
}

