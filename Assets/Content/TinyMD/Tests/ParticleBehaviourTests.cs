using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace TinyMD.Tests
{
    using Particles.Behaviours;

    public class ParticleBehaviourTests
    {
        [Test]
        public void CreatingAParticleShouldCreateABehaviour()
        {
            var env = TinyMolecularDynamics.CreateEnvironment();
            var behaviourManager = env.gameObject.AddComponent<ParticleBehaviourManager>();
            behaviourManager.EnableManager();

            env.Manager.CreateParticle();
            var behaviours = env.GetComponentsInChildren<ParticleBehaviour>();
            Assert.AreEqual(1, behaviours.Count());

            env.StopEnvironment();
        }

        [Test]
        public void CreatingFiveParticlesShouldCreateFiveBehaviours()
        {
            var env = TinyMolecularDynamics.CreateEnvironment();
            var behaviourManager = env.gameObject.AddComponent<ParticleBehaviourManager>();
            behaviourManager.EnableManager();

            env.Manager.CreateParticles(5);
            var behaviours = env.GetComponentsInChildren<ParticleBehaviour>();
            Assert.AreEqual(5, behaviours.Count());

            env.StopEnvironment();
        }
    }
}
