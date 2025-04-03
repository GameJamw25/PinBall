using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    [Header("PowerUp Audio")]
    public AudioClip powerup;

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.Instance.abilityCharge == 1000)
        //{
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.abilityCharge = 0;
                if (GameManager.Instance.selectedCharacter.powerType == CharacterPowerType.Kandi)
                {
                    AudioManager.Instance.playClip(powerup);
                    TableManager.Instance.SpawnGumball();
                    TableManager.Instance.SpawnGumball();
                }
            }
        //}
    }
}
