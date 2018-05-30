using System;
using OpenTK;

namespace template
{
	public abstract class Primitive
	{
		public Vector3 Color;
		public abstract Intersection Intersect(Ray ray);

    }
}
