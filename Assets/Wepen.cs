using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepen : MonoBehaviour
{
    public int HitNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)//主角武器碰撞敌人
    {
        if (other.tag == "Monster")
        {
            var Name = other.name;
            other.GetComponent<Monster>().HP-=HitNum;
            this.GetComponent<Collider>().enabled = false; 
            
        }
        if (other.tag == "Monster2")
        {
            var Name = other.name;
            other.GetComponent<Monster2>().Hp -= HitNum;
            this.GetComponent<Collider>().enabled = false;

        }
    }
  
}
