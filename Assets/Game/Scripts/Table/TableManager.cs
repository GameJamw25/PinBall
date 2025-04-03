using UnityEngine;

public class TableManager : Singelton<TableManager>
{
    [SerializeField]
    private Transform ballSpawn;
    [SerializeField]
    private Transform[] gumballSpawns;

    public void SpawnBall()
    {
        Instantiate(Resources.Load("Prefabs/Ball"), ballSpawn.position, Quaternion.identity);
    }
    public void SpawnGumball()
    {
        AudioManager.Instance.playClip(GameManager.Instance.selectedCharacter.powerSound);
        foreach (Transform gumballSpawn in gumballSpawns)
        Instantiate(Resources.Load("Prefabs/Gumball"), gumballSpawn.position, Quaternion.identity);
    }
}
