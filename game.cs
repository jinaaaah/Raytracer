using System;
using System.IO;
using OpenTK;
using template;

namespace Template {

class Game
{
		// member variables
        public Surface screen;

		Raytracer raytracer;
		Application application;

		int CUBE_SIZE = 5;
        int SCREEN_SIZE = 512;
        // initialize
        public void Init()
        {
			raytracer = new Raytracer();
            application = new Application();         
        }
        // tick: renders one frame
        public void Tick()
        {
			//clear
			screen.Clear(0);
			raytracer.rays.Clear();

			int DEFAULT_COLOR = convertColor(new Vector3(255));

			for (int i = 0; i < SCREEN_SIZE; i++)
			{
				for (int j = 0; j < SCREEN_SIZE; j++)
				{
					//Render Screen
					int location = i + j * SCREEN_SIZE * 2;               
					Vector3 Color = raytracer.Render(i / (SCREEN_SIZE * 1.0f), j / (SCREEN_SIZE * 1.0f));               
					screen.pixels[location] = convertColor(Color); 

					//Debug Screen Default
					screen.pixels[i + SCREEN_SIZE + j * SCREEN_SIZE * 2] = 0;        
				}
			}
            //Debug View
            //Draw Sphere
			foreach(Primitive primitive in raytracer.scene.primitives)
            {
                if(primitive is Sphere)
                {
                    Sphere sphere = (Sphere)primitive;
					for (int degree = 0; degree < 360; degree++)
                    {
						int coordX = (int)(CUBE_SIZE * (sphere.radius * Math.Cos(degree) + sphere.pos.X));
						int coordY = (int)(CUBE_SIZE * (sphere.radius * Math.Sin(degree) - sphere.pos.Z));
                        screen.Plot(coordX+ 768, coordY + 350, convertColor(sphere.Color));                        
                    }
                }                
            }              
			//Draw Camera point                 
			screen.Box((int)raytracer.camera.pos.X + 767, (int)raytracer.camera.pos.Z * -1 + 349, (int)raytracer.camera.pos.X + 769, (int)raytracer.camera.pos.Z * -1 + 351, DEFAULT_COLOR);

            //Draw Rays
			foreach(Ray ray in raytracer.rays)
			{
				float coordX = CUBE_SIZE * (ray.O.X + 40 * ray.D.X);
				float coordY = CUBE_SIZE * (ray.O.Z + 40 * ray.D.Z);            
				screen.Line((int)ray.O.X + 768, (int)ray.O.Z * -1 + 350, (int)coordX + 768, (int)coordY * -1 + 350, DEFAULT_COLOR);
			}
			//Dividing Line
			screen.Line(SCREEN_SIZE, 0, SCREEN_SIZE, SCREEN_SIZE, DEFAULT_COLOR);
            //User Input
			application.UpdateCam(raytracer.camera);         
        }

		public int convertColor(Vector3 Color){         
			return ((int)Color.X << 16) + ((int)Color.Y << 8) + (int)Color.Z;
		}
    }   
} // namespace Template