using System;
using System.Collections.Generic;
using OpenTK;
using Template;

namespace template
{
    public class Raytracer
    {
		public Camera camera;
		public Scene scene;
		public List<Ray> rays;

		public Raytracer()
        {
			camera = new Camera(Vector3.Zero);
			scene = new Scene();
			rays = new List<Ray>();
        }

		public Vector3 Render(float u, float v){         
			Ray ray = camera.cameraRay(u, v);              
			Intersection intersection = scene.Intersect(ray);
			if (intersection == null) return Vector3.Zero;         
            if(Equals(ray.D.Y, 0f)) rays.Add(ray);
			return Trace(intersection);
		}

		public Vector3 Trace(Intersection intersection){
			foreach(Light light in scene.lights)
			{
    			if(IsVisible(intersection, light))
    			{
    				if(intersection.Nearest is Plane) return intersection.Nearest.Color;
					else return DirectIllumination(intersection, light) * intersection.Nearest.Color;
    			}            
			}         
			return Vector3.Zero;
		}

		public bool IsVisible(Intersection intersection, Light light)
        {
			Ray shadowRay = new Ray(intersection.P,Vector3.Normalize(light.pos));         
			if(scene.Intersect(shadowRay) != null) return false;
			return true;
        }
              
		public Vector3 DirectIllumination(Intersection intersection, Light light)
		{
			Vector3 L = light.pos - intersection.P;
			float dist = L.Length;
			L *= (1.0f / dist);

			float attenuation = 1 / (dist * dist);

			return light.intensity * Vector3.Dot(intersection.N, L) * attenuation;
		}
    }
}
