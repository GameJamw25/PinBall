using UnityEngine;

public class TableManager : Singelton<TableManager>
{
    [SerializeField]
    private Transform ballSpawn;
    [SerializeField]
    private Transform gumballSpawn;

    public void SpawnBall()
    {
        Instantiate(Resources.Load("Prefabs/Ball"), ballSpawn.position, Quaternion.identity);
    }
    public void SpawnGumball()
    {
        Instantiate(Resources.Load("Prefabs/Ball"), gumballSpawn.position, Quaternion.identity);
    }
}
