﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GGFanGame.Game.Level.Enemies
{
    /// <summary>
    /// A dummy enemy.
    /// </summary>
    class Dummy : Enemy
    {
        public Dummy(GGGame game) : base(game)
        {
            spriteSheet = game.textureManager.getResource(@"Sprites\Dummy");
            drawShadow = true;
            shadowSize = 0.9d;
            strength = 0f;
            weigth = 6f;
            state = ObjectState.Idle;
            size = new Vector3(60, 60, 10);

            addAnimation(ObjectState.Idle, new Animation(3, Point.Zero, new Point(64, 64), 15));
            addAnimation(ObjectState.Hurt, new Animation(1, new Point(0, 64), new Point(64, 64), 20, 1));
            addAnimation(ObjectState.HurtFalling, new Animation(1, new Point(0, 64), new Point(64, 64), 20, 1));
            addAnimation(ObjectState.Dead, new Animation(4, new Point(0, 128), new Point(64, 64), 6));

            health = 50;
        }

        public override void update()
        {
            base.update();

            if (state == ObjectState.Idle)
            {
                if (Stage.activeStage().onePlayer.X < X)
                {
                    facing = ObjectFacing.Left;
                }
                else
                {
                    facing = ObjectFacing.Right;
                }
            }
        }
    }
}