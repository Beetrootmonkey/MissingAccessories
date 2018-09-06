using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    class StarShredder : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("50% chance to not consume ammo" +
                "\nShoots 1 to 2 projectiles at once");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.useStyle = 5;
            item.useAnimation = 10;
            item.useTime = 10;
            item.width = 60;
            item.height = 30;
            item.shoot = 92;
            item.useAmmo = AmmoID.FallenStar;
            item.UseSound = SoundID.Item9;
            item.damage = 70;
            item.shootSpeed = 16f;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 5;
            item.ranged = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StarCannon);
            recipe.AddIngredient(ItemID.Megashark);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .50f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float sX, sY;
            Vector2 pos = new Vector2(position.X, position.Y);
            int min = 1;
            int max = 2;
            int amount = Main.rand.Next(min, max + 1);
            for (int i = 1; i < amount + 1; i++)
            {
                Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    pos = position + muzzleOffset;
                }
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
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

