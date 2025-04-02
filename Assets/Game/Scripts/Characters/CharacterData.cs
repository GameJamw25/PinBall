using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName= "CharacterData")]
public class CharacterData : ScriptableObject {
  public CharacterPowerType powerType;
  public Sprite characterSprite;
  public string characterName;
  public string characterDescription;
}
