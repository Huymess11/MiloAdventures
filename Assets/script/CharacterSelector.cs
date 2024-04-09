using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] CharacterSelection;
    private int characterIndex;
    public Character[] characters;
    public Button unlockBtn;
    public Text unlockBtnTxt;
    // Start is called before the first frame update
    void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("selectorPlayer", 0);
        foreach (GameObject player in CharacterSelection)
        {
            player.SetActive(false);
        }
        CharacterSelection[characterIndex].SetActive(true);
        foreach (Character c in characters)
        {
            if(c.price == 0)
            {
                c.isUnlock = true;
            }
            else
            {
                c.isUnlock = PlayerPrefs.GetInt(c.name, 0)==0 ? false : true;
            }
        }
        UpdateUI();
        
    }

    public void NextCharacter()
    {
        CharacterSelection[characterIndex].SetActive(false);
        characterIndex++;
        if(characterIndex == CharacterSelection.Length)
        {
            characterIndex = 0;
        }
        CharacterSelection[characterIndex].SetActive(true);
        if (characters[characterIndex].isUnlock)
        {
            PlayerPrefs.SetInt("selectorPlayer", characterIndex);
        }
      
        UpdateUI();
    }
    public void PreviousCharacter()
    {
        CharacterSelection[characterIndex].SetActive(false);
        characterIndex--;
        if (characterIndex == -1)
        {
            characterIndex = CharacterSelection.Length-1;
        }
        CharacterSelection[characterIndex].SetActive(true);
        if (characters[characterIndex].isUnlock)
        {
            PlayerPrefs.SetInt("selectorPlayer", characterIndex);
        }
        UpdateUI();
    }
    public void UpdateUI()
    {
        if (characters[characterIndex].isUnlock == true)
        {
            unlockBtn.gameObject.SetActive(false);
        }
        else
        {
            unlockBtnTxt.text = "Price: "+characters[characterIndex].price;
            if (PlayerPrefs.GetInt("totalCoin", 0) < characters[characterIndex].price)
            {
                unlockBtn.gameObject.SetActive(true);
                unlockBtn.interactable=false;
            }
            else
            {
                unlockBtn.gameObject.SetActive(true);
                unlockBtn.interactable = true;
            }
        }
    }

    public void Unlock()
    {
        PlayerPrefs.SetInt("totalCoin", PlayerPrefs.GetInt("totalCoin", 0) - characters[characterIndex].price);
        PlayerPrefs.SetInt(characters[characterIndex].name, 1);
        PlayerPrefs.SetInt("selectorPlayer",characterIndex);
        characters[characterIndex].isUnlock = true;
        UpdateUI() ;
    }

}
