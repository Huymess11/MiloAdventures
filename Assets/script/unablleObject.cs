using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unablleObject : MonoBehaviour
{
    // Start is called before the first frame update
    public void setUnActiveObject()
    {
        gameObject.SetActive(false);
    }
    public void setActiveObject()
    {
        gameObject.SetActive(true);
    }
}
