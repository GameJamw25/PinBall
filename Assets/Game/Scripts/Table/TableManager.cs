using UnityEngine;

public class TableManager : Singelton<TableManager> {
  [SerializeField]
  private Transform ballSpawn;
  public void SpawnBall() {
    Instantiate(Resources.Load("Prefabs/Ball"), ballSpawn.position, Quaternion.identity);
  }
}
