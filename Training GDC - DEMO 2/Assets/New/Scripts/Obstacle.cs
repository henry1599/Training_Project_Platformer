using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingGDC.Platformer
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] int m_Health;
        public void TakeDamage(int damage)
        {
            print("Take Dame");
            m_Health -= damage;
            if (m_Health <= 0)
            {
                Die();
            }
        }
        void Die()
        {
            Destroy(gameObject);
        }
    }
}
