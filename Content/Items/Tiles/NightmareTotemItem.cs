﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using AllBeginningsMod.Content.Tiles;

namespace AllBeginningsMod.Content.Items.Tiles
{
    public sealed class NightmareTotemItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Totem");
            Tooltip.SetDefault("The harbinger of terror");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;

            Item.width = 26;
            Item.height = 64;

            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 10);

            Item.useTime = Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.createTile = ModContent.TileType<NightmareTotemTile>();
        }
    }
}