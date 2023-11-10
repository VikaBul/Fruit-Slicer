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
            int vegetableRandomIdx = Random.Range(0, Vegetables.Length); //������ ���������� �����
            int obstacleSpawnLimit = Random.Range(1, 3); //����� ��������� �����������

            if (obstacleSpawnLimit == 2)
            {
                if (vegetableSpawnCounterForObstacle > 6) //���� �����=2, �� ����������� ������� ������� 6 ������
                {
                    Instantiate(metalObstacle, spawnPoint.position, Quaternion.identity); //��������� ��������� �����������
                    vegetableSpawnCounterForObstacle = 0; // ������� ������, ���. ��� = 6, ���������� �� 0
                }
                else
                {
                    SpawnVegetable(vegetableRandomIdx); //� ��������� ������ ������������ ���� � ������������� ������� ��������� ������
                }
            }
            else
            {
                SpawnVegetable(vegetableRandomIdx); //���� ��� �� ����� ������������ �����������, �.� ����� ��=2, �� ������ ������������ ���� � ������������� ������� ������ ������
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
