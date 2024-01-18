using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XianShi : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] gameObjects;
    public KeyCode[] keyCodes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                if (gameObjects[i].activeSelf)
                {
                    gameObjects[i].SetActive(false);
                }
                else
                {
                    gameObjects[i].SetActive(true);
                }
            
            }
        }
        
    }
}
