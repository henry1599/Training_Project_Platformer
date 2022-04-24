using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingProject.Prototype2
{
    public class Controller : MonoBehaviour
    {
        public static Controller Instance {get; set;}
        [SerializeField] Animator m_Animator;
        [SerializeField] Rigidbody2D m_Rigidbody2D;
        [SerializeField] Transform m_GroundCheck;
        [SerializeField] float m_GroundCheckRadius;
        [SerializeField] Transform m_AttackPoint;
        [SerializeField] float m_AttackRange;
        [SerializeField] LayerMask m_GroundLayer;
        float m_MoveFactor;
        bool m_IsGrounded;
        void Awake()
        {
            Instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Idle();
            Move();
            Jump();
            Attack();
            GroundCheck();

            m_Animator?.SetFloat("speed", Mathf.Abs(m_MoveFactor));
            m_Animator?.SetBool("grounded", m_IsGrounded);
        }
        void Move()
        {
            m_MoveFactor = Input.GetAxisRaw("Horizontal");
            transform.Translate(transform.right * m_MoveFactor * Time.deltaTime * Character.Instance.MoveSpeed);
            Flip();
        }
        void Jump()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }
            if (!m_IsGrounded)
            {
                return;
            }
            m_Rigidbody2D.velocity = Vector2.up * Character.Instance.JumpForce;
        }
        void Attack()
        {
            if (!Input.GetKeyDown(KeyCode.C))
            {
                return;
            }
            m_Animator?.SetTrigger("attack");
            StartCoroutine(AttackCoroutine());
        }
        void Idle()
        {
            // * Play animation;
        }
        void GroundCheck()
        {
            m_IsGrounded = Physics2D.OverlapCircle(m_GroundCheck.position, m_GroundCheckRadius, m_GroundLayer);
        }
        void Flip()
        {
            if (m_MoveFactor < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (m_MoveFactor > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(m_GroundCheck.position, m_GroundCheckRadius);
            Gizmos.DrawWireSphere(m_AttackPoint.position, m_AttackRange);
        }
        IEnumerator AttackCoroutine()
        {
            Character.Instance.SlowDown();
            yield return new WaitForSeconds(m_Animator.GetCurrentAnimatorClipInfo(0).Length * 0.5f);
            Character.Instance.ResetSpeed();
        }
        public void AttackDetection()
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(m_AttackPoint.position, m_AttackRange);
            foreach (Collider2D col in cols)
            {
                if (!col.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
                {
                    continue;
                }
                obstacle.TakeDamage(10);
            }
        }
    }
}
