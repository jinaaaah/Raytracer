using System;
using OpenTK;

namespace template
{
    public class Camera
    {
		public Vector3 pos = Vector3.Zero; //camera position
		public Vector3 viewdir = new Vector3(0, 0, 1); //view direction
		Vector3 c; //screen center
		public Vector3 p0, p1, p2; //screen corner
      
		float FOV = 1f;

		public Camera(Vector3 pos)
        {
			this.pos = pos;
			c = pos + FOV * viewdir;
			p0 = c + new Vector3(-1, -1, 0);
			p1 = c + new Vector3(1, -1, 0);
			p2 = c + new Vector3(-1, 1, 0);   
        }
        
		public Ray cameraRay(float u, float v)
		{
			Vector3 p = p0 + u * (p1 - p0) + v * (p2 - p0);
			Vector3 rayDir = p;
			Vector3 rayOrigin = pos;
			return new Ray(rayOrigin, Vector3.Normalize(rayDir));
		}

    }
}
