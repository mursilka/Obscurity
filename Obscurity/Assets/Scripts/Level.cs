using UnityEngine;

namespace Obscuity
{
    public class Level : MonoBehaviour

    {
        [SerializeField] private Transform spawnPointEnemy;
        [SerializeField] private GameObject enemyPrefab;

        public Vector3 SpawnPointEnemy => spawnPointEnemy.position;

    }
}