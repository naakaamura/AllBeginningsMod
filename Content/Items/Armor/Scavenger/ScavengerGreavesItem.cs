﻿using AllBeginningsMod.Common.Bases.Items;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace AllBeginningsMod.Content.Items.Armor.Scavenger;

public sealed class ScavengerGreavesItem : ModItemBase
{
    public override void SetStaticDefaults() {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults() {
        Item.defense = 3;

        Item.width = 30;
        Item.height = 22;

        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 35);
    }

    public override void AddRecipes() {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Silk, 6);
        recipe.AddRecipeGroup(RecipeGroupID.IronBar, 8);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}