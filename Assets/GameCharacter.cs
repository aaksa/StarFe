using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{
    public Sprite[] spriteArray;
    private int currentCharacter = 0;
    private const string CurrentCharacterKey = "CurrentCharacter";
    public SpriteRenderer spriteRenderer;






    private void Start()
    {
        currentCharacter = PlayerPrefs.GetInt(CurrentCharacterKey, 0);
        SetCharacterSprite(currentCharacter);
    }

    public void SetCharacterSprite(int characterIndex)
    {
        spriteRenderer.sprite = spriteArray[characterIndex];
    }
}
