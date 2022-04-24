using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingGDC.Platformer
{
    public class Character : MonoBehaviour
    {
        [SerializeField] float m_Health;
        [SerializeField] int m_AttackDamage;
        [SerializeField] float m_MoveSpeed;
        [SerializeField] float m_JumpForce;
        [SerializeField] float m_MinMoveSpeed;
        float m_InitMoveSpeed;
        public float Health 
        {
            get {return m_Health;}
            set {m_Health = value;}
        }
        public int AttackDamage
        {
            get {return m_AttackDamage;}
            set {m_AttackDamage = value;}
        }
        public float MoveSpeed
        {
            get {return m_MoveSpeed;}
            set {m_MoveSpeed = value;}
        }
        public float MinMoveSpeed
        {
            get {return m_MinMoveSpeed;}
            set {m_MinMoveSpeed = value;}
        }
        public float JumpForce
        {
            get {return m_JumpForce;}
            set {m_JumpForce = value;}
        }
        public void SlowDown()
        {
            m_InitMoveSpeed = MoveSpeed;
            MoveSpeed = MinMoveSpeed;
        }
        public void SpeedUp()
        {
            MoveSpeed = m_InitMoveSpeed;
        }
        // public float GetHealth()
        // {
        //     return m_Health;
        // }
        // public void SetHealth(float value)
        // {
        //     m_Health = value;
        // }
    }
}
