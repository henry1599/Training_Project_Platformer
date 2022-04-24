using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingProject.Prototype2
{
    public enum Direction {LEFT, RIGHT}
    public class ObstacleGeneration : MonoBehaviour
    {
        [SerializeField] List<Obstacle> m_Obstacles;
        [SerializeField] Vector2 m_MinSpawnPointLeft, m_MaxSpawnPointLeft;
        [SerializeField] Vector2 m_MinSpawnPointRight, m_MaxSpawnPointRight;
        [SerializeField] float m_TimeBetweenSpawn;
        [SerializeField] Color[] colors;
        List<SpawnDirection> m_RandomDirections = new List<SpawnDirection>();
        bool m_IsInit = false;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Init());
            StartCoroutine(SpawnCoroutine());   
        }
        void Spawn()
        {
            SpawnDirection randomSpawnDirection = m_RandomDirections[Random.Range(0, m_RandomDirections.Count)];
            Vector2 randomPosition = new Vector2(Random.Range(randomSpawnDirection.MinPosition.x, randomSpawnDirection.MaxPosition.x), Random.Range(randomSpawnDirection.MinPosition.y, randomSpawnDirection.MaxPosition.y));
            Obstacle randomObstacle = m_Obstacles[Random.Range(0, m_Obstacles.Count)];

            GameObject obstacleObject = Instantiate(randomObstacle.gameObject, randomPosition, Quaternion.identity);
            if (!obstacleObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                return;
            }
            Vector2 randomDirection = randomSpawnDirection.InitDirection;
            obstacle.Setup(randomDirection, colors[Random.Range(0, colors.Length)]);
        }
        IEnumerator SpawnCoroutine()
        {
            yield return new WaitUntil(() => m_IsInit == true);
            while (Character.Instance.IsDie == false)
            {
                Spawn();
                yield return new WaitForSeconds(m_TimeBetweenSpawn);
            }
        }
        IEnumerator Init()
        {
            yield return new WaitUntil(() => 
                m_MinSpawnPointLeft != null &&
                m_MaxSpawnPointLeft != null &&
                m_MinSpawnPointRight != null &&
                m_MaxSpawnPointRight != null
            );
            m_RandomDirections.Add
            (
                new SpawnDirection
                (
                    m_MinSpawnPointLeft, m_MaxSpawnPointLeft, Direction.RIGHT
                )
            );
            m_RandomDirections.Add
            (
                new SpawnDirection
                (
                    m_MinSpawnPointRight, m_MaxSpawnPointRight, Direction.LEFT
                )
            );
            m_IsInit = true;
        }
    }
}
