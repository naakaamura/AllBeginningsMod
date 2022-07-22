﻿using AllBeginningsMod.Common.Config;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace AllBeginningsMod.Common.Systems.Rendering.Primitives
{
    [Autoload(Side = ModSide.Client)]
    public sealed class PrimitiveRenderingSystem : ModSystem
    {
        public static int MaxPrimitives => ModContent.GetInstance<ClientSideConfig>().MaxPrimitives;

        public static VertexBuffer VertexBuffer { get; private set; }
        public static RenderTarget2D PrimitiveTarget { get; private set; }

        public static PrimitiveBase[] Primitives { get; private set; }

        public override void OnModLoad() {
            Main.QueueMainThreadAction(() => {
                VertexBuffer = new VertexBuffer(Main.graphics.GraphicsDevice, VertexPositionColorTexture.VertexDeclaration, MaxPrimitives * 3, BufferUsage.WriteOnly);
                PrimitiveTarget = new RenderTarget2D(Main.graphics.GraphicsDevice, Main.screenWidth / 2, Main.screenHeight / 2);
            });

            Primitives = new PrimitiveBase[MaxPrimitives * 3];

            Main.OnResolutionChanged += ResizeTarget;
            Main.OnPreDraw += CachePrimitiveDraw;

            On.Terraria.Main.DrawDust += DrawTarget;
        }

        public override void OnModUnload() {
            Main.QueueMainThreadAction(() => {
                VertexBuffer?.Dispose();
                VertexBuffer = null;

                PrimitiveTarget?.Dispose();
                PrimitiveTarget = null;
            });

            Primitives = null;

            Main.OnPreDraw -= CachePrimitiveDraw;
            Main.OnResolutionChanged -= ResizeTarget;

            On.Terraria.Main.DrawDust -= DrawTarget;
        }

        private static void CachePrimitiveDraw(GameTime gameTime) {
            SpriteBatch spriteBatch = Main.spriteBatch;
            GraphicsDevice device = spriteBatch.GraphicsDevice;
            RenderTargetBinding[] oldTargets = device.GetRenderTargets();

            device.SetRenderTarget(PrimitiveTarget);
            device.SetVertexBuffer(VertexBuffer);
            device.Clear(Color.Transparent);

            device.RasterizerState = RasterizerState.CullNone;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, default, default, default, Main.GameViewMatrix.TransformationMatrix);

            for (int i = 0; i < MaxPrimitives; i++) {
                PrimitiveBase primitive = Primitives[i];

                if (primitive == null) {
                    return;
                }

                primitive.SetPositions();
                primitive.SetVertices();

                VertexBuffer.SetData(primitive.Vertices);

                foreach (EffectPass pass in primitive.Effect.CurrentTechnique.Passes) {
                    pass.Apply();
                    device.DrawPrimitives(primitive.Type, 0, VertexBuffer.VertexCount / 3);
                }
            }

            spriteBatch.End();

            device.SetRenderTargets(oldTargets);
        }

        private static void DrawTarget(On.Terraria.Main.orig_DrawDust orig, Main self) {
            orig(self);

            SpriteBatch spriteBatch = Main.spriteBatch;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, default, default, default, Main.GameViewMatrix.TransformationMatrix);
            spriteBatch.Draw(PrimitiveTarget, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.White);
            spriteBatch.End();
        }

        private static void ResizeTarget(Vector2 resolution) {
            Main.QueueMainThreadAction(() => {
                PrimitiveTarget = new RenderTarget2D(Main.graphics.GraphicsDevice, (int)(resolution.X / 2f), (int)(resolution.Y / 2f));
            });
        }
    }
}