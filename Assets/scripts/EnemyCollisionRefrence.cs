using UnityEngine;
using Unity.Entities;
using TMPro;

public class EnemyCollisionRefrence : MonoBehaviour
{
    public Entity entitycollision; // The ECS entity this collider belongs to
    private EntityManager entityManager;
    public bool hit = false;
    [SerializeField] private TextMeshPro enemyText;
    

    void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        if (enemyText != null)
        {
            // Set it to "0" or "1" randomly
            enemyText.text = UnityEngine.Random.Range(0, 2) == 0 ? "0" : "1";
        }
    }

    void Update()
    {
        if (entityManager.Exists(entitycollision) && entityManager.HasComponent<Translation>(entitycollision))
        {
            Translation translation = entityManager.GetComponentData<Translation>(entitycollision);
            transform.position = translation.Value;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        int sroe = 0;

        if (collision.CompareTag("Killzone"))
        {
            Debug.Log($"Enemy hit by wall: {entitycollision}");
            DestroyEnemy();
        }
        if (collision.CompareTag("bullet"))
        {
            sroe++;
            Debug.Log("score: " + sroe);
            DestroyEnemy();
        }

    }

    private void DestroyEnemy()
    {
        Debug.Log($"Enemy hit by {entitycollision}");

        // ❌ Destroy the ECS entity
        if (entityManager.Exists(entitycollision))
        {
            entityManager.DestroyEntity(entitycollision);
        }

        // ❌ Destroy the GameObject (collision object)
        Destroy(gameObject);

        if (enemyText != null)
        {
            Destroy(enemyText);  // Make sure this isn't a prefab but an instance
        }
    }
}
