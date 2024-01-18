using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepen1 : MonoBehaviour
{
    public int HitNum;
    float ShowTime;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ShowTime += Time.deltaTime;
        if (ShowTime >= 1)
        {
            ShowTime = 0;
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)//技能碰撞敌人
    {
        if (other.tag == "Monster")
        {
            var Name = other.name;
            other.GetComponent<Monster>().HP-=HitNum;
           // this.GetComponent<Collider>().enabled = false; 
            
        }
        if (other.tag == "Monster2")
        {
            var Name = other.name;
            other.GetComponent<Monster2>().Hp -= HitNum;
           // this.GetComponent<Collider>().enabled = false;

        }
    }
   
}
