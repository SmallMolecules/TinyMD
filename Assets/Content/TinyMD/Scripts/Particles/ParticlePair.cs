using System.Numerics;

namespace TinyMD.Particles
{
    public class ParticlePair
    {
        public Particle a { get; private set; }
        public Particle b { get; private set; }

        public float distance { get; private set; }
        public Vector3 direction_ab { get; private set; }

        public ParticlePair(Particle a, Particle b)
        {
            this.a = a;
            this.b = b;
        }

        public void UpdateDerivedVariables()
        {
            Vector3 displacement = b.position - a.position;
            
            distance = displacement.Length();
            direction_ab = Vector3.Normalize(displacement);
        }
    }
}