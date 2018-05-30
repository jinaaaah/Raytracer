using System;
using OpenTK;
using OpenTK.Input;

namespace template
{
    public class Application
    {
		/*TO-DO: call Render Method of Raytracer
		 *       handling keyboard and mouse input
        */
		KeyboardState state;

        public Application()
        {
        }
        
		public void UpdateCam(Camera camera)
		{
			//move and rotate camera
			state = OpenTK.Input.Keyboard.GetState();
			if(state.IsKeyDown(Key.Left))
			{
				camera.viewdir.X -= 0.1f;
			}else if(state.IsKeyDown(Key.Right))
			{
				camera.viewdir.X += 0.1f;
			}else if (state.IsKeyDown(Key.Up))
            {
				camera.viewdir.Y -= 0.1f;
			}else if (state.IsKeyDown(Key.Down))
            {
				camera.viewdir.Y += 0.1f;
			}else if (state.IsKeyDown(Key.W))
            {
				camera.viewdir.Z -= 0.1f;
			}else if (state.IsKeyDown(Key.S))
            {
				camera.viewdir.Z += 0.1f;
            }
		}
    }
}
