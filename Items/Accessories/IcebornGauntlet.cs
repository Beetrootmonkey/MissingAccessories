using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Accessories
{
    class IcebornGauntlet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("While above 25% life: Absorbs 25% of damage done to players on your team" +
                "\nUnder 50% life: Puts a shell around the owner that reduces damage by 25%" +
                "\nGrants immunity to knockback" +
                "\nEnemies are more likely to target you" +
                "\nStriking enemies has a change to chill them" +
                "\nReduces damage taken by 17%");
            DisplayName.SetDefault("Iceborn Gauntlet");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 30;
            item.accessory = true;
            item.rare = 8;
            item.defense = 15;
            item.value = Item.sellPrice(0, 30, 0, 0);
        }

        private int GetIndexInArray(object[] arr, object obj)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(obj))
                {
                    return i;
                }
            }

            return -1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            player.aggro += 400;
            player.endurance += 0.17f;
            if ((double)player.statLife > (double)player.statLifeMax2 * 0.25)
            {
                player.hasPaladinShield = true;
                int i = GetIndexInArray(Main.player, player);
                if (i != Main.myPlayer && player.miscCounter % 10 == 0)
                {
                    int p = Main.myPlayer;
                    if (Main.player[p].team == player.team && player.team != 0)
                    {
                        float num1 = player.position.X - Main.player[p].position.X;
                        float num2 = player.position.Y - Main.player[p].position.Y;
                        if (System.Math.Sqrt((double)num1 * (double)num1 + (double)num2 * (double)num2) < 800.0)
                            Main.player[p].AddBuff(43, 20, true);
                    }
                }
            }

            if ((double)player.statLife <= (double)player.statLifeMax2 * 0.5)
            {
                player.AddBuff(62, 5, true);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this.mod, "FrozenPaladinShield");
            recipe.AddIngredient(ItemID.FleshKnuckles);
            recipe.AddIngredient(ItemID.FrostCore, 3);
            recipe.AddIngredient(ItemID.WormScarf);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
