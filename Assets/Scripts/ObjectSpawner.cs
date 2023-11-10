using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Vegetables;
    public Transform spawnPoint;
    public float intervalBetweenSpawn; //interval between spawn of vegetables

    private float spawnBetweenTime; //variable to reset the timer
    //public float maxLifeTime = 5f; //Vegetables life time

    public GameObject metalObstacle;
    private int vegetableSpawnCounterForObstacle;

    void FixedUpdate()
    {
        if (spawnBetweenTime <= 0)
        {
            int vegetableRandomIdx = Random.Range(0, Vegetables.Length); //индекс случайного овоща
            int obstacleSpawnLimit = Random.Range(1, 3); //лимит появления препятствий

            if (obstacleSpawnLimit == 2)
            {
                if (vegetableSpawnCounterForObstacle > 6) //если лимит=2, то проверяется наличие минимум 6 овощей
                {
                    Instantiate(metalObstacle, spawnPoint.position, Quaternion.identity); //создается экземпляр препятствия
                    vegetableSpawnCounterForObstacle = 0; // счетчик лимита, кот. был = 6, установить на 0
                }
                else
                {
                    SpawnVegetable(vegetableRandomIdx); //в противном случае генерируется овощ и увеличивается счетчик появления овощей
                }
            }
            else
            {
                SpawnVegetable(vegetableRandomIdx); //если еще не время генерировать препятствие, т.е лимит не=2, то просто генерируется овощ и увеличивается счетчик лимита овощей
            }
            spawnBetweenTime = intervalBetweenSpawn;
        }
        else
        {
            spawnBetweenTime -= Time.deltaTime;
        }
        
    }
    private void SpawnVegetable(int index)
    {
        /*GameObject vegetables = */
        Instantiate(Vegetables[index], spawnPoint.position, Quaternion.identity);
        vegetableSpawnCounterForObstacle++;
        //Destroy(vegetables, maxLifeTime);
    }
}
