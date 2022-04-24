using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingGDC.Platformer
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] Rigidbody2D m_Rigidbody2D;
        [SerializeField] Animator m_Animator;
        [SerializeField] Character m_Character;

        [Header("Ground Check Value")]
        [SerializeField] Transform m_GroundCheck;
        [SerializeField] float m_GroundCheckRadius;
        [SerializeField] LayerMask m_JumpableLayerMask;

        [Header("Attack Value")]
        [SerializeField] Transform m_AttackPoint;
        [SerializeField] float m_AttackRadius;
        [SerializeField] LayerMask m_AttackableLayerMask;
        float m_MoveFactor;
        bool m_IsGrounded;
        
        void Update()
        {
            Move();
            Jump();
            Attack();
            GroundCheck();
        }
        void Move()
        {
            // * Play animation move
            // * Move
            
            m_MoveFactor = Input.GetAxisRaw("Horizontal");
            // * = 1 => RIGHT Key
            // * = -1 => LEFT Key
            // * = 0 => STAND
            // TODO: m_Rigidbody2D.velocity = (Vector2)transform.right * m_MoveFactor * m_Character.MoveSpeed;
            transform.Translate((Vector2)transform.right * m_MoveFactor * m_Character.MoveSpeed * Time.deltaTime);
            Flip();

            m_Animator?.SetFloat("speed", Mathf.Abs(m_MoveFactor));
        }
        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && m_IsGrounded)
            {
                m_Rigidbody2D.velocity = Vector2.up * m_Character.JumpForce;
            }
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                m_Animator?.SetTrigger("attack");
            }
        }
        public void AttackPerform()
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(m_AttackPoint.position, m_AttackRadius, m_AttackableLayerMask);
            foreach (Collider2D col in cols)
            {
                if (col.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
                {
                    obstacle.TakeDamage(m_Character.AttackDamage);
                }
            }
        }
        void Flip()
        {
            if (m_MoveFactor != 0)
            {
                transform.localScale = new Vector3(m_MoveFactor, 1, 1);
            }
        }
        void GroundCheck()
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(m_GroundCheck.position, m_GroundCheckRadius, m_JumpableLayerMask);
            m_IsGrounded = cols.Length > 0;
        }
        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(m_GroundCheck.position, m_GroundCheckRadius);
            Gizmos.DrawWireSphere(m_AttackPoint.position, m_AttackRadius);
        }
    }
}
