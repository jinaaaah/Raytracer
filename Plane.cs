using System;
using System.IO;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace template
{
	class Plane : Primitive
    {
		public Vector3 normal;
		public float d;

		public Plane(Vector3 normal, Vector3 color, float d)
        {
			this.normal = normal;         
			this.d = d;
			Color = color;
        }
        
		public override Intersection Intersect(Ray ray)
        {
			float dot = Vector3.Dot(normal, ray.D);
			float t = -(Vector3.Dot(ray.O, normal) + d) / dot;
			if (dot > 0) return null;

			Vector3 P = ray.O + t * ray.D;
         
			return new Intersection(normal, Color, (P - ray.O).Length, this, P);
        }
        
    }
}
