using System;
using OpenTK;

namespace template
{
	public class Ray
	{
		public Vector3 O;//ray origin
		public Vector3 D;//ray direction
		public float t { get; set; }//distance
        
		public Ray(Vector3 O, Vector3 D)
        {
			this.O = O;
			this.D = Vector3.Normalize(D);      
        }
    }
}
