﻿using Terraria.ModLoader;

namespace AllBeginningsMod.Common.Bases.Tiles;

public abstract class ModTileBase : ModTile
{
    public override string Texture => GetType().FullName.Replace('.', '/').Replace("Content", "Assets");
}