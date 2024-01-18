using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Begin : MonoBehaviour {

 
   
	// Use this for initialization
	void Start () {
      

    }
	
	// Update is called once per frame
	void Update () {
		
	}
  
    public void PlayGame()//开始游戏
    {
        SceneManager.LoadScene(1);
    }
    public void TuiChu()//退出游戏
    {
        Application.Quit();
    }
}
