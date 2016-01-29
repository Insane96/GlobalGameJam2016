﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016.EnemyList
{
     class Enemy : SpriteObject
    {
        public float Health { get; protected set; }
        public int Speed { get; protected set; }
        public bool isEasy;

        public Enemy(int width, int height ,  bool isEasy, string hitBoxName = "auto") : base (width,height,true,hitBoxName)
        {
            
            Speed = 100;
            this.isEasy = isEasy;
        }

        // da spostare in bullet
        

        public virtual void Moviment()
        {
            
        }
        
    }
}