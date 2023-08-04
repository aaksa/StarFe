using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectShip : MonoBehaviour
{

    public Sprite[] spriteArray;
    private int currentCharacter = 0;
    private const string CurrentCharacterKey = "CurrentCharacter";
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {

        currentCharacter = PlayerPrefs.GetInt(CurrentCharacterKey, 0);
        SetCharacterSprite(currentCharacter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // Public setter method for currentCharacter
    public void SetCurrentCharacter(int characterIndex)
    {
    
        currentCharacter = (characterIndex + spriteArray.Length) % spriteArray.Length;
        PlayerPrefs.SetInt(CurrentCharacterKey, currentCharacter);
        SetCharacterSprite(currentCharacter);
        PlayerPrefs.Save(); // Optional: Save immediately (you can also let Unity handle saving at the end of the frame)
    }

    public void nextCharacter()
    {
        SetCurrentCharacter(currentCharacter+1);
    }

    public void prevCharacter()
    {
        SetCurrentCharacter(currentCharacter-1);
    }



    public void SetCharacterSprite(int characterIndex)
    {
        spriteRenderer.sprite = spriteArray[characterIndex];
    }

    public void gotoMenu()
    {
        SceneManager.LoadScene(0);
    }

}
