using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using System.Collections;

public class EnemySpawnerSystem : MonoBehaviour
{
    [SerializeField] private float cooldownTime;
    [SerializeField] private float speedValue;
    [SerializeField] private GameObject enemyCollisionPrefab;

    void Start()
    {
        StartCoroutine(MakeEntities());
    }

    IEnumerator MakeEntities()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype archetype = entityManager.CreateArchetype(
            typeof(LocalToWorld),
            typeof(Translation),
            typeof(SpeedComponent)

        );
        while (true)
        {
            Entity entity = entityManager.CreateEntity(archetype);
            entityManager.SetComponentData(entity, new SpeedComponent { speed = speedValue });

            float3 randomPosition = new float3(
                          UnityEngine.Random.Range(10, 11),
                          UnityEngine.Random.Range(5, -5),
                          0f);

            entityManager.SetComponentData(entity, new Translation { Value = randomPosition });

            GameObject entitycollision = Instantiate(enemyCollisionPrefab, randomPosition, Quaternion.identity);
            entitycollision.GetComponent<EnemyCollisionRefrence>().entitycollision = entity;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
