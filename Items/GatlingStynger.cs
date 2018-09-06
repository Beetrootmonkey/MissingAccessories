using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    class GatlingStynger : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots explosive bolts" +
                "\n Only the first shot onconsumes ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 30;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useAnimation = 12;
			item.useTime = 3;
			item.reuseDelay = 14;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 9, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item31;
            item.autoReuse = true;
            item.shoot = 246;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.StyngerBolt;

            // Stynger
            //this.useAnimation = 22;
            //this.useTime = 22;
            //this.width = 50;
            //this.height = 18;
            //this.shoot = 246;
            //this.useAmmo = AmmoID.StyngerBolt;
            //this.UseSound = SoundID.Item11;
            //this.damage = 45;
            //this.knockBack = 5f;
            //this.shootSpeed = 9f;
            //this.noMelee = true;
            //this.value = 350000;
            //this.rare = 7;
            //this.ranged = true;

            // Chain Gun
            //this.useAnimation = 4;
            //this.useTime = 4;
            //this.width = 50;
            //this.height = 18;
            //this.shoot = 10;
            //this.useAmmo = AmmoID.Bullet;
            //this.UseSound = SoundID.Item41;
            //this.damage = 31;
            //this.shootSpeed = 14f;
            //this.noMelee = true;
            //this.value = Item.sellPrice(0, 5, 0, 0);
            //this.rare = 8;
            //this.knockBack = 1.75f;
            //this.ranged = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stynger);
            recipe.AddIngredient(ItemID.ChainGun);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
		{
            return !(player.itemAnimation < item.useAnimation - 2);
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}



        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}


    }
}

