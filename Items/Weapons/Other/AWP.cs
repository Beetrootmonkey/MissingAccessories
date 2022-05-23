using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Weapons.Other
{
    class AWP: ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Makes every shot count, as long as you aim properly" +
                "\nConverts any bullet used to Luminite Bullets" +
                "\nEnemies are less likely to target you");
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.useAnimation = 100;
            item.useTime = 100;
            item.crit += 25;
            item.width = 44;
            item.height = 14;
            item.shoot = 638;
            item.useAmmo = AmmoID.Bullet;
            item.UseSound = SoundID.Item40;
            item.damage = 500;
            item.shootSpeed = 20f;
            item.noMelee = true;
            item.value = 200000;
            item.knockBack = 12f;
            item.rare = 8;
            item.ranged = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SniperRifle);
            recipe.AddIngredient(ItemID.SniperScope);
            recipe.AddIngredient(ItemID.LunarBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        //public override bool ConsumeAmmo(Player player)
        //{
        //    return Main.rand.NextFloat() >= .50f;
        //}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float sX, sY;
            Vector2 pos = new Vector2(position.X, position.Y);
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                pos = position + muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            sX = perturbedSpeed.X;
            sY = perturbedSpeed.Y;
            Projectile.NewProjectile(pos.X, pos.Y, sX, sY, 638, damage, knockBack, player.whoAmI);
            return false;
        }



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override void HoldItem(Player player)
        {
            base.HoldItem(player);
            player.aggro -= 400;
            player.scope = true;
        }

        //if (player.inventory[player.selectedItem].type == 1254 && player.scope)
        //        zoom = 0.8f;
        //      else if (player.inventory[player.selectedItem].type == 1254)
        //        zoom = 0.6666667f;

    }
}
