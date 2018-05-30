using System;
using System.Collections.Generic;
using OpenTK;

namespace template
{
    public class Scene
    {
		public List<Primitive> primitives = new List<Primitive>();
		public List<Light> lights = new List<Light>();
        
        public Scene()
        {
			Sphere sphere1 = new Sphere(5f, new Vector3(255, 0, 0), new Vector3(-12f, 0.5f, 25f));
			primitives.Add(sphere1);
            
			Sphere sphere2 = new Sphere(5f, new Vector3(0, 255, 0), new Vector3(0, 0.5f, 25f));
            primitives.Add(sphere2);

			Sphere sphere3 = new Sphere(5f, new Vector3(0, 0, 255), new Vector3(12f, 0.5f, 25f));
            primitives.Add(sphere3);

			Plane plane = new Plane(new Vector3(0, 0, 1), new Vector3(125, 50, 50), 0.5f);
            primitives.Add(plane);

			Light light = new Light(Vector3.Zero, new Vector3(255));
			lights.Add(light);

        }
        
		public Intersection Intersect(Ray ray){
			//loop over the primitives
			//return the closest intersection         
			Intersection nearest = null;
			float shortest = float.PositiveInfinity;
			foreach(Primitive primitive in primitives){
				Intersection intersection = primitive.Intersect(ray);
				if (intersection != null){
					if (intersection.dist < shortest)
                    {
                        shortest = intersection.dist;
                        nearest = intersection;
                    }
				}           
			}
			if (float.IsPositiveInfinity(shortest)) return null;
			return nearest;
		}
    }
}
