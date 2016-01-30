﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using GlobalGameJam2016.Enviroment;
using OpenTK;
using OpenTK.Input;

namespace GlobalGameJam2016.PlayerList
{
	class PlayerEarth : Player
	{
		private Enviroment.Enviroment enviroment;
		private bool isRight;
		public PlayerEarth(int width, int height, bool autoHitbox, string autoHitboxName) : base(width, height, autoHitbox, autoHitboxName)
		{
			isRight = true;
			X = 1280 / 2;
			Y = -height;
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			base.Update();
			Movement();
			Input();
		}

		private void Input()
		{
			if (Engine.IsKeyDown(keyMap.attack) && Engine.IsKeyDown(keyMap.down) && Game.enviromentEarth.tiles[Utils.GetPos((int)(this.X + this.Height / 2) / 80, (int)(this.Y + (this.Height / 2)) / 80 + 1, 16)].tileType == TileType.DestrWall)
			{
				Game.enviromentEarth.tiles[Utils.GetPos((int)(this.X + this.Height / 2) / 80, (int)(this.Y + (this.Height / 2)) / 80 + 1, 16)].tileType = TileType.None;

			}
			else if (Engine.IsKeyDown(keyMap.attack))
			{
				if (isRight && Game.enviromentEarth.tiles[Utils.GetPos((int)(this.X + this.Height / 2) / 80 + 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType == TileType.DestrWall)
					Game.enviromentEarth.tiles[Utils.GetPos((int)(this.X + this.Height / 2) / 80 + 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType = TileType.None;
				else if(!isRight && Game.enviromentEarth.tiles[Utils.GetPos((int)(this.X + this.Height / 2) / 80 - 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType == TileType.DestrWall)
					Game.enviromentEarth.tiles[Utils.GetPos((int)(this.X + this.Height / 2) / 80 - 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType = TileType.None;


			}
		}

		private void Dig()
		{
			Game.enviromentEarth.tiles[Utils.GetPos((int)(this.X + this.Height / 2) / 80, (int)(this.Y + (this.Height / 2)) / 80 + 1, 16)].tileType = TileType.None;
		}

		private void Movement()
		{
			if (Engine.IsKeyDown(keyMap.left))
			{
				X -= movSpeed * Engine.DeltaTime;
				isRight = false;
			}
			else if (Engine.IsKeyDown(keyMap.right))
			{
				X += movSpeed * Engine.DeltaTime;
				isRight = true;
			}

			if (CheckCollisions().Count == 0)
			{
				this.Y += 200f * Engine.DeltaTime;
				if (this.Y > Engine.Height / 2)
					Engine.Camera.Y = Y - Engine.Height / 2;

				Engine.Camera.Update();

			}
		}
	}
}
