using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Accessories
{
    class ShinyCarapace : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("While above 25% life: Absorbs 25% of damage done to players on your team" +
                "\nUnder 50% life: Grants 'Icy Barrier'" +
                "\nConstantly applies 'Icy Barrier' to nearby teammates" +
                "\nGrants immunity to knockback" +
                "\nEnemies are more likely to target you" +
                "\nStriking enemies has a change to chill them" +
                "\nReduces damage taken by 25% (stacks with 'Icy Barrier')" +
                "\nGreatly increases life regen when not moving" +
                "\nAttackers also take full damage" +
                "\n\nIcy Barrier: Grants 25% damage reduction");
            DisplayName.SetDefault("Shiny Carapace");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.accessory = true;
            item.rare = 9;
            item.defense = 25;
            item.value = Item.sellPrice(0, 40, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            player.turtleThorns = true;
            player.shinyStone = true;
            player.aggro += 400;
            player.endurance += 0.25f;

            if ((double)player.statLife > (double)player.statLifeMax2 * 0.25)
            {
                player.hasPaladinShield = true;
                int i = Utils.GetIndexInArray(Main.player, player);
                if (i != Main.myPlayer && player.miscCounter % 10 == 0)
                {
                    int p = Main.myPlayer;
                    if (Main.player[p].team == player.team && player.team != 0)
                    {
                        float num1 = player.position.X - Main.player[p].position.X;
                        float num2 = player.position.Y - Main.player[p].position.Y;
                        if (System.Math.Sqrt((double)num1 * (double)num1 + (double)num2 * (double)num2) < 800.0)
                            Main.player[p].AddBuff(62, 20, true);
                            Main.player[p].AddBuff(95, 20, true);
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
            recipe.AddIngredient(ItemID.ShinyStone);
            recipe.AddIngredient(ItemID.TurtleShell, 5);
            recipe.AddIngredient(ItemID.BeetleHusk, 20);
            recipe.AddIngredient(ItemID.WormScarf);
            recipe.AddIngredient(this.mod, "IcebornGauntlet");
            recipe.AddIngredient(this.mod, "Chain4");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
