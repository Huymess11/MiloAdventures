using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] levelBtn;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for(int i = 0; i< levelBtn.Length; i++) 
        {
            if (i + 2 > levelAt)
            {
                levelBtn[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
}
