using System;
using OpenTK;


namespace template
{
	class Sphere : Primitive
    {
		public float radius;      
		public Vector3 pos;

		public Sphere(float radius, Vector3 Color, Vector3 pos)
        {
			this.radius = radius;
			this.pos = pos;
			this.Color = Color;
           }
       
		public override Intersection Intersect(Ray ray)
		{
			Vector3 C = this.pos - ray.O;
			float t = Vector3.Dot(C, ray.D);         
			Vector3 Q = C - t * ray.D;
			float p2 = Vector3.Dot(Q, Q);

			if (p2 > radius * radius) return null;

			float a = Vector3.Dot(ray.D, ray.D);
            float b = 2 * Vector3.Dot(ray.D, ray.O - pos);
            float c = Vector3.Dot(ray.O - pos, ray.O - pos) - radius * radius;

			float x1 = (-b - (float)Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
			float x2 = (-b + (float)Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

			if (x1 < 0 && x2 >0) ray.t = x2;
			else ray.t = x1;
            
			if ((b * b - 4 * a * c) < 0) return null;
            
			Vector3 P = ray.O + ray.t * ray.D;
			Vector3 normal = Vector3.Normalize(P - this.pos);

			return new Intersection(normal, Color, (P - ray.O).Length, this, P);                     
		}
	}
}
