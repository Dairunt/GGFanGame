﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GGFanGame.Screens.Game.Level.GrumpSpace
{
    class Arin : PlayerCharacter
    {
        public Arin(GGGame game, PlayerIndex playerIndex) : base(game, playerIndex)
        {
            spriteSheet = gameInstance.textureManager.getResource(@"Sprites\Arin");
            drawShadow = false;

            addAnimation(ObjectState.Idle, new Animation(8, Point.Zero, new Point(64, 64), 7));
            addAnimation(ObjectState.Walking, new Animation(6, new Point(0, 64), new Point(64, 64), 5));
            addAnimation(ObjectState.Hurt, new Animation(1, new Point(0, 128), new Point(64, 64), 6));
            addAnimation(ObjectState.HurtFalling, new Animation(5, new Point(0, 128), new Point(64, 64), 7, 5));
            addAnimation(ObjectState.StandingUp, new Animation(5, new Point(256, 128), new Point(64, 64), 9));
            addAnimation(ObjectState.Dead, new Animation(1, new Point(256, 128), new Point(64, 64), 1));

            health = 100;
            playerSpeed = 8f;
        }

        public override void update()
        {
            base.update();

            
        }
    }
}