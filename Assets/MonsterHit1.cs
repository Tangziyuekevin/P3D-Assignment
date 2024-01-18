using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit1 : MonoBehaviour {

    public int HitNum;
    bool BHit;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)//如果没有碰撞，就检测主角碰撞，然后扣血
    {
        if (other.tag == "Player"&&!BHit)
        {
            other.GetComponent<PeopleMove>().HP -= HitNum;

            BHit = true;

        }
    }
}
