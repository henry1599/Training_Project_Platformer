using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingProject.Prototype2
{
    public class SetupParticle : MonoBehaviour
    {
        [SerializeField] ParticleSystem[] pars;
        public void Setup(Color initColor)
        {
            foreach (ParticleSystem par in pars)
            {
                ParticleSystem.MainModule main = par.main;
                main.startColor = initColor;
            }
        }
    }
}
