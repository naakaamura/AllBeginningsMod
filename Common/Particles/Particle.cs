﻿using AllBeginningsMod.Utility;
using AllBeginningsMod.Utility.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace AllBeginningsMod.Common.Systems.Particles;

public abstract class Particle
{
    public string TexturePath => GetType().FullName.Replace('.', '/').Replace("Content", "Assets");

    public Color Color = Color.White;

    public SpriteEffects Effects;

    public Rectangle? Frame;
    
    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Origin;
    public Vector2 Scale = Vector2.One;

    public float Alpha = 1f;
    public float Rotation;

    public virtual void OnSpawn() { }

    public virtual void OnKill() { }

    public virtual void Update() {
        Position += Velocity;
    }

    public virtual void Draw() {
        Texture2D texture = ModContent.Request<Texture2D>(TexturePath).Value;
    
        Main.EntitySpriteDraw(texture, Position - Main.screenPosition, Frame, Color, Rotation, Origin, Scale, Effects, 0);
    }

    public bool Kill() {
        return ParticleManager.Kill(this);
    }

    public static T Spawn<T>(Vector2 position, Vector2 velocity = default, Color? color = null, Vector2? scale = null, float rotation = 0f, float alpha = 1f) where T : Particle, new() {
        return ParticleManager.Spawn<T>(position, velocity, color, scale, rotation, alpha);
    }
}