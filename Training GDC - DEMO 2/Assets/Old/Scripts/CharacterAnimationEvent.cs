using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingProject.Prototype2
{
    public class CharacterAnimationEvent : MonoBehaviour
    {
        public void Attack()
        {
            Controller.Instance.AttackDetection();
        }
    }
}
