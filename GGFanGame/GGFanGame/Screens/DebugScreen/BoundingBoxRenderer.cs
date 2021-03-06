﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GGFanGame.Screens.Debug
{
    /// <summary>
    /// A class to render a bounding box outline in 3D space.
    /// </summary>
    class BoundingBoxRenderer
    {
        static VertexPositionColor[] verts = new VertexPositionColor[8];
        static short[] indices = new short[] { 0, 1, 1, 2, 2, 3, 3, 0, 0, 4, 1, 5, 2, 6, 3, 7, 4, 5, 5, 6, 6, 7, 7, 4 };
        static BasicEffect effect;

        /// <summary>
        /// Renders a bounding box as line list.
        /// </summary>
        public static void Render(BoundingBox box, GraphicsDevice graphicsDevice, Matrix view, Matrix projection, Color color)
        {
            if (effect == null)
            {
                effect = new BasicEffect(graphicsDevice);
                effect.VertexColorEnabled = true;
                effect.LightingEnabled = false;
            }

            Vector3[] corners = box.GetCorners();

            for (int i = 0; i < 8; i++)
            {
                verts[i].Position = corners[i];
                verts[i].Color = color;
            }

            effect.View = view;
            effect.Projection = projection;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.LineList, verts, 0, 8, indices, 0, indices.Length / 2);
            }
        }
    }
}