using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit2 : MonoBehaviour {
    public int Thisone;
    float ThisTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.forward * Time.deltaTime * 10);//向前移动
        ThisTime += Time.deltaTime;
        if (ThisTime >= 5)//计时销毁自身
        {
            ThisTime = 0;
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)//碰撞检测主角扣血    除了主角敌人外销毁自身
    {
        if (other.tag == "Player")
        {
            
            Destroy(this.gameObject);
            other.GetComponent<PeopleMove>().HP -= Thisone;
        }
        if (other.tag != "Monster")
        {
            Destroy(this.gameObject);
        }
    }
}
