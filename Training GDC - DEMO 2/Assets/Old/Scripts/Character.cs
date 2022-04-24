using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingProject.Prototype2
{
    public enum CharacterState {PLAYING, DIE}
    public class Character : MonoBehaviour
    {
        public static Character Instance {get; set;}
        [SerializeField] float m_MoveSpeed;
        [SerializeField] float m_JumpForce;
        [SerializeField] float m_AttackDamage;
        [SerializeField] float m_MinMoveSpeed;
        bool m_IsDie;
        CharacterState state;
        float m_InitMoveSpeed;
        public bool IsDie 
        {
            get {return m_IsDie;}
            set 
            {
                m_IsDie = value;
            }
        }
        public float MoveSpeed 
        {
            get {return m_MoveSpeed;}
            set 
            {
                m_MoveSpeed = value;
            }
        }
        public float JumpForce 
        {
            get {return m_JumpForce;}
            set 
            {
                m_JumpForce = value;
            }
        }
        public float AttackDamage
        {
            get {return m_JumpForce;}
            set 
            {
                m_JumpForce = value;
            }
        }
        void Awake()
        {
            Instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            m_InitMoveSpeed = m_MoveSpeed;
            IsDie = false;
        }

        // Update is called once per frame
        void Update()
        {
            switch (state)
            {
                case CharacterState.PLAYING:
                    HandlePlaying();
                    break;
                case CharacterState.DIE:
                    HandleDie();
                    break;
            }
        }
        public void UpdateState(CharacterState newState)
        {
            if (state == newState)
            {
                return;
            }
            state = newState;
        }
        void HandlePlaying()
        {

        }
        void HandleDie()
        {
            IsDie = true;
        }
        public void SlowDown()
        {
            m_MoveSpeed = m_MinMoveSpeed;
        }
        public void ResetSpeed()
        {
            m_MoveSpeed = m_InitMoveSpeed;
        }
    }
}
