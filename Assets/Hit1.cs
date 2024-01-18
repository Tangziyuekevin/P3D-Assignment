using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit1 : MonoBehaviour {
    public int Thisone;
    float ThisTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ThisTime += Time.deltaTime;//计时隐藏自身
        if (ThisTime >= 1)
        {
            ThisTime = 0;
            this.gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)//碰撞检测主角扣血
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            other.GetComponent<PeopleMove>().HP -= Thisone;
        }
    }
}
