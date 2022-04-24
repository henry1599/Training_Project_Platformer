using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingGDC.Platformer
{
    public class CharacterAnimationEvent : MonoBehaviour
    {
        [SerializeField] Controller m_Controller;
        public void AttackEvent()
        {
            m_Controller.AttackPerform();
        }
    }
}