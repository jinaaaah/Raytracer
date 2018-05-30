using System;
using OpenTK;

namespace template
{
    public class Light
    {
		public Vector3 pos, intensity;

		public Light(Vector3 pos, Vector3 intensity)
        {
			this.pos = pos;
			this.intensity = intensity;
        }
    }
}
