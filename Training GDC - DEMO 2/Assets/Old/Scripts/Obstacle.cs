using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingProject.Prototype2
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] Rigidbody2D m_Rigidbody2D;
        [SerializeField] GameObject m_VfxExplostion;
        [SerializeField] int m_Health;
        [SerializeField] float m_MinForce, m_MaxForce;
        [SerializeField] float m_MinRotate, m_MaxRotate;
        SpriteRenderer m_SpriteRenderer;
        int[] m_RotateDirections = new int[2] {-1, 1};
        bool m_IsRotate = false;
        int m_RotateDirection;
        float m_RotateForce;
        public void Setup(Vector2 initialDirection, Color initColor)
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.color = initColor;

            m_VfxExplostion.GetComponent<SetupParticle>().Setup(initColor);

            m_Rigidbody2D?.AddForce(initialDirection * Random.Range(m_MinForce, m_MaxForce), ForceMode2D.Impulse);
            m_RotateDirection = m_RotateDirections[Random.Range(0, m_RotateDirections.Length)];
            m_RotateForce = Random.Range(m_MinRotate, m_MaxRotate);
            m_IsRotate = true;
        }
        void Update()
        {
            if (m_IsRotate)
            {
                Rotate(m_RotateDirection, m_RotateForce);
            }
        }
        void Rotate(int _direction, float _force)
        {
            transform.Rotate(0, 0, _force * _direction * Time.deltaTime);
        }
        public void TakeDamage(int _damage)
        {
            m_Health -= _damage;
            if (m_Health <= 0)
            {
                Die();
            }
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            m_IsRotate = false;
        }
        void Die()
        {
            Instantiate(m_VfxExplostion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
