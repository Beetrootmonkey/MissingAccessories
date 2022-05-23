using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Weapons.Other
{
    class CelestialAnnihilation : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("80% chance to not consume ammo" +
                "\nShoots 2 to 4 projectiles at once");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.useStyle = 5;
            item.useAnimation = 6;
            item.useTime = 6;
            item.width = 60;
            item.height = 30;
            item.shoot = 503;
            item.useAmmo = AmmoID.FallenStar;
            item.UseSound = SoundID.Item9;
            item.damage = 180;
            item.shootSpeed = 18f;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = 8;
            item.ranged = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "StarShredder");
            recipe.AddIngredient(ItemID.SDMG);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
		{
            return Main.rand.NextFloat() >= .80f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            float sX, sY;
            Vector2 pos = new Vector2(position.X, position.Y);
            int min = 2;
            int max = 3;
            int amount = Main.rand.Next(min, max + 1);
            for (int i = 1; i < amount + 1; i++)
            {
                Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 70f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    pos = position + muzzleOffset;
                }
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(6));
                sX = perturbedSpeed.X;
                sY = perturbedSpeed.Y;
                if (i < amount)
                {
                    Projectile.NewProjectile(pos.X, pos.Y, sX, sY, type, damage, knockBack, player.whoAmI);
                }
                else
                {
                    speedX = sX;
                    speedY = sY;
                    position = pos;
                }
            }
            return true;
		}



        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}


    }
}

