using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToweringMages.Classes.Character
{
    class Character
    {
        Texture2D texture;
        Rectangle rectangle;
        Vector2 position;
        Vector2 velocity;
        bool hasJumped;

        public Character(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            rectangle = texture.Bounds;
            hasJumped = true;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            if (Keyboard.GetState().IsKeyDown(Keys.D)) velocity.X = 4f;
            else if (Keyboard.GetState().IsKeyDown(Keys.A)) velocity.X = -4f;
            else velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                hasJumped = true;
            }

            if(hasJumped == true)
            {
                float i = 2f;
                velocity.Y += 0.15f * i;
            }

            if(position.Y + texture.Height >= 450)
            {
                hasJumped = false;
            }

            if(hasJumped == false)
            {
                velocity.Y = 0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
        }
    }
}
