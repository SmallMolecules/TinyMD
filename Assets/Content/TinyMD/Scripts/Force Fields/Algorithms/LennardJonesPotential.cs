using System;

namespace TinyMD.ForceFields.Algorithms
{
    using Particles;

    public static class LennardJonesPotential
    {
        // We're going to use the computationally-favourable form of the potential:
        
        // V = A/r^12 - B/r^6
        
        // where:
        //  V = the Lennard-Jones potential energy
        //  A = 4eo^12
        //  B = 4eo^6
        //  e = depth of the potential well
        //  o = size of the particle
        //  r = distance between the particles

        public class PairConstants
        {
            public ParticlePair particles;
            public double A, B;

            public PairConstants (float potentialWellDepth, float particleSize)
            {
                A = 4 * potentialWellDepth * Math.Pow(particleSize, 12);
                B = 4 * potentialWellDepth * Math.Pow(particleSize, 6);
            }
        }

        public static double CalculateImpulseMagnitude (PairConstants pair, float timeStep)
        {
            double potential = CalculatePotential(pair);
            // convert to force
            // convert to impulse
            // convert to vector

            throw new System.NotImplementedException();
        }

        private static double CalculatePotential (PairConstants pair)
        {
            double r6 = Math.Pow(pair.particles.distance, 6);
            double r12 = Math.Pow(pair.particles.distance, 2);
            return (pair.A / r12) - (pair.B / r6);
        }
    }
}