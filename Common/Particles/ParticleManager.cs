﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace AllBeginningsMod.Common.Systems.Particles;

[Autoload(Side = ModSide.Client)]
public sealed class ParticleManager : ILoadable
{
    // TODO: Config setting for max particles.
    public const int MaxParticles = 4000;

    public static List<Particle> Particles { get; private set; }

    void ILoadable.Load(Mod mod) {
        Particles = new List<Particle>(MaxParticles);

        On.Terraria.Dust.UpdateDust += UpdateParticles;
        On.Terraria.Main.DrawDust += DrawParticles;
    }

    void ILoadable.Unload() {
        On.Terraria.Dust.UpdateDust -= UpdateParticles;
        On.Terraria.Main.DrawDust -= DrawParticles;

        Particles?.Clear();
        Particles = null;
    }

    public static T Spawn<T>(Vector2 position, Vector2 velocity = default, Color? color = null, Vector2? scale = null, float rotation = 0f, float alpha = 1f) where T : Particle, new() {
        T particle = new();

        if (Particles.Count >= MaxParticles)
            return particle;

        particle.Position = position;
        particle.Velocity = velocity;
        particle.Color = color ?? Color.White;
        particle.Scale = scale ?? Vector2.One;
        particle.Rotation = rotation;
        particle.Alpha = alpha;

        particle.OnSpawn();

        Particles.Add(particle);

        return particle;
    }

    public static bool Kill<T>(T particle) where T : Particle {
        bool success = Particles.Remove(particle);

        if (success)
            particle.OnKill();

        return success;
    }

    private static void UpdateParticles(On.Terraria.Dust.orig_UpdateDust orig) {
        orig();

        for (int i = 0; i < Particles.Count; i++)
            Particles[i]?.Update();
    }

    private static void DrawParticles(On.Terraria.Main.orig_DrawDust orig, Main self) {
        orig(self);

        for (int i = 0; i < Particles.Count; i++)
            Particles[i]?.Draw();
    }
}