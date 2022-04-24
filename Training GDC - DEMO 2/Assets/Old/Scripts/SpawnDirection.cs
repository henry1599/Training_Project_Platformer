using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingProject.Prototype2
{
    public class SpawnDirection 
    {
        Vector2 m_MinPosition;
        Vector2 m_MaxPosition;
        Direction m_Direction;
        Vector2 m_InitDirection;
        public Vector2 InitDirection
        {
            get {return m_InitDirection;}
            set {m_InitDirection = value;}
        }
        public Vector2 MinPosition 
        {
            get {return m_MinPosition;}
            set {m_MinPosition = value;}
        }
        public Vector2 MaxPosition 
        {
            get {return m_MaxPosition;}
            set {m_MaxPosition = value;}
        }
        public Direction Direction
        {
            get {return m_Direction;}
            set 
            {
                m_Direction = value;
                switch (m_Direction)
                {
                    case Direction.LEFT:
                        InitDirection = new Vector2(-1, 0);
                        break;
                    case Direction.RIGHT:
                        InitDirection = new Vector2(1, 0);
                        break;
                }
            }
        }
        public SpawnDirection(Vector2 _minPosition, Vector2 _maxPosition, Direction _direction)
        {
            this.MinPosition = _minPosition;
            this.MaxPosition = _maxPosition;
            this.Direction = _direction;
        }
    }
}
