using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour {

    public int HitNum;
    float TheTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TheTime += Time.deltaTime;
        if (TheTime >= 1.5f)//计时销毁
        {
            TheTime = 0;
            this.gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)//碰撞检测主角
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PeopleMove>().HP -= HitNum;
            TheTime = 0;
            this.gameObject.SetActive(false);
        }
    }

}
