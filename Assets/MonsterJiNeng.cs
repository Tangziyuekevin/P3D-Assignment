using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterJiNeng : MonoBehaviour {

    float KaiShiTime;
    public int HitNum;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        KaiShiTime += Time.deltaTime;
        if (KaiShiTime >= 1)//计时显示子物体
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(0).GetComponent<MonsterHit1>().HitNum = HitNum*2;
        }

    }
}
