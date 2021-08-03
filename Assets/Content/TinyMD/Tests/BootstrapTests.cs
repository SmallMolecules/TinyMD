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

    public class BootstrapTests
    {
        [Test]
        public void BehaviourBootstrapShouldCreateAParticleBehaviour()
        {
            var env = TinyMolecularDynamics.CreateEnvironment();
            env.Manager.CreateParticle();
            
            Assert.AreEqual(1, env.Manager.Particles.Count);

            var behaviourManager = env.gameObject.AddComponent<ParticleBehaviourManager>();
            behaviourManager.EnableManager();
            var foundParticleBehaviours = GameObject.FindObjectsOfType<ParticleBehaviour>();
            Assert.AreEqual(1, foundParticleBehaviours.Count());

            env.Manager.CreateParticle();
            foundParticleBehaviours = GameObject.FindObjectsOfType<ParticleBehaviour>();
            Assert.AreEqual(2, foundParticleBehaviours.Count());

            env.StopEnvironment();
        }
    }
}