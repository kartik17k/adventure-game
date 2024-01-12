using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;
using TMPro;

public class characterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedcharacter;
    public character[] characters;

    public Button unlockButton;
    public TextMeshProUGUI coins;


    public void Awake()
    {
        selectedcharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
        
        foreach (GameObject player in skins) { 
            player.SetActive(false);
        }

        skins[selectedcharacter].SetActive(true);

        foreach(character c in characters)
        {
            if (c.price == 0)
                c.isunlocked = true;
            else
            {
                if (PlayerPrefs.GetInt(c.name, 0) == 0)
                {
                    c.isunlocked = false;
                }
                else
                    c.isunlocked = true;

               // c.isunlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }

        }
        UpdateUI();

    }

    public void ChangeNext()
    {
        skins[selectedcharacter].SetActive(false);
        selectedcharacter++;

        if (selectedcharacter == skins.Length)
            selectedcharacter = 0;

        skins[selectedcharacter].SetActive(true);
        if (characters[selectedcharacter].isunlocked)
            PlayerPrefs.SetInt("selectedCharacter", selectedcharacter);
        UpdateUI();
    }

    public void ChangePrev()
    {
        skins[selectedcharacter].SetActive(false);
        selectedcharacter--;

        if (selectedcharacter == -1)
            selectedcharacter = skins.Length-1;

        skins[selectedcharacter].SetActive(true);
        if (characters[selectedcharacter].isunlocked)
            PlayerPrefs.SetInt("selectedCharacter", selectedcharacter);
        UpdateUI();
    }
   
    public void UpdateUI()
    {
        coins.text = " :" + PlayerPrefs.GetInt("NumOfCoin", 0);

        if ((characters[selectedcharacter].isunlocked) == true)
            unlockButton.gameObject.SetActive(false);
        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price:" + characters[selectedcharacter].price ;
            if( PlayerPrefs.GetInt("NumOfCoin",0) < characters[selectedcharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
                
        }
    }

    public void Unlock()
    {
        int coins = PlayerPrefs.GetInt("NumOfCoin", 0);
        int Price = characters[selectedcharacter].price;
        PlayerPrefs.SetInt("NumOfCoin",coins - Price);
        PlayerPrefs.SetInt(characters[selectedcharacter].name, 1);
        PlayerPrefs.SetInt("selectedCharacter", selectedcharacter);
        characters[selectedcharacter].isunlocked = true;
        UpdateUI() ;
    }

    public void exit()
    {
        Application.Quit();
    }

}
