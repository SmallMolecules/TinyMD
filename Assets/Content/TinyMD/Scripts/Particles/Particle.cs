using System.Collections.Generic;
using System.Numerics;

namespace TinyMD.Particles
{
    [System.Serializable]
    public class Particle
    {
        public float mass;
        public Vector3 position;
        public Vector3 velocity;
        public Stack<Vector3> impulseBuffer;

        public Particle()
        {
            mass = 1f;
            position = Vector3.Zero;
            velocity = Vector3.Zero;
            impulseBuffer = new Stack<Vector3>();
        }
    }
}