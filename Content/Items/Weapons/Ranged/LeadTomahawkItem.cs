﻿using AllBeginningsMod.Common.Bases.Items;
using AllBeginningsMod.Content.Projectiles.Ranged;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllBeginningsMod.Content.Items.Weapons.Ranged;

public sealed class LeadTomahawkItem : ModItemBase
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Lead Tomahawk");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
    }

    public override void SetDefaults() {
        Item.consumable = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;

        Item.maxStack = 999;

        Item.DamageType = DamageClass.Ranged;
        Item.damage = 13;
        Item.knockBack = 1f;

        Item.width = 24;
        Item.height = 28;

        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.shoot = ModContent.ProjectileType<LeadTomahawkProjectile>();
        Item.shootSpeed = 11f;

        Item.value = Item.sellPrice(copper: 10);
        Item.rare = ItemRarityID.White;

        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() {
        Recipe recipe = CreateRecipe(50);
        recipe.AddIngredient(ItemID.LeadBar);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}