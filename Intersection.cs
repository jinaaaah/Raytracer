using System;
using OpenTK;
using template;

namespace template
{
	public class Intersection
    {
		public Vector3 N; //Normal at the Intersection point     
		public float dist; //Intersection Distance
		public Primitive Nearest; //nearest primitive
		public Vector3 P; //p(t)
		public Vector3 Color;

		public Intersection(Vector3 n, Vector3 Color, float dist, Primitive nearest, Vector3 P)
		{
			N = n;
			this.Color = Color;
			this.dist = dist;
			this.Nearest = nearest;
			this.P = P;         
		}

	}
}
