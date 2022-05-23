using Microsoft.Xna.Framework;
using MissingAccessories.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MissingAccessories.Items.Weapons.ThrowingKnives
{
    class BoneThrowingKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Rapidly throw piercing bone knives");
        }
        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.useStyle = 1;
            item.shootSpeed = 13f;
            item.shoot = ProjectileType<BoneThrowingKnife>();
            item.damage = 15;
            item.width = 18;
            item.height = 20;
            item.UseSound = SoundID.Item39;
            item.useAnimation = 19;
            item.useTime = 18;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 1, 10, 0);
            item.knockBack = 1.5f;
            item.melee = true;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BoneDagger, 100);
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(this.mod, "ThrowingKnives");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int amount = Main.rand.Next(2, 5);
            for (int i = 0; i < amount; i++)
            {
                Vector2 target = Main.screenPosition
                    + new Vector2((float)Main.mouseX, (float)Main.mouseY)
                    + new Vector2((float)Main.rand.Next(-80, 80), (float)Main.rand.Next(-80, 80));

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

