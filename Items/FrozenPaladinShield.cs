using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    [AutoloadEquip(EquipType.Shield)]
    public class FrozenPaladinShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("While above 25% life: Absorbs 25% of damage done to players on your team" +
                "\nUnder 25% life: Puts a shell around the owner that reduces damage by 25%");
            DisplayName.SetDefault("Frozen Paladin's Shield");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.accessory = true;
            item.rare = 8;
            item.defense = 6;
            item.value = 300000;
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

            if ((double)player.statLife <= (double)player.statLifeMax2 * 0.5) {
                player.AddBuff(62, 5, true);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrozenTurtleShell);
            recipe.AddIngredient(ItemID.PaladinsShield);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}