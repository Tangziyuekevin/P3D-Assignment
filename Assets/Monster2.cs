using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Monster2 : MonoBehaviour {

    public float Hp;
    public bool isBoss;
    public GameObject Player;
    public int ThisState;
    float HitTime;
    public GameObject HitCube;
    public int HitNum;
    bool IsHit;
    float BossHit;
    public GameObject JiNeng;
 
    public Slider slider1;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        slider1.maxValue = Hp;
    }
	
	// Update is called once per frame
	void Update () {
        slider1.value = Hp;
        if (Vector3.Distance(this.transform.position, Player.transform.position) <= 3)//根据距离切换状态
        {
            this.GetComponent<Animator>().SetInteger("State", 0);
            ThisState = 2;
        }
        else if (Vector3.Distance(this.transform.position, Player.transform.position) <=12&& !IsHit)
        {
            this.GetComponent<Animator>().SetInteger("State", 0);
            ThisState = 1;
        }
        else
        {
            ThisState = 0;
        }
        if (ThisState == 0)//站立状态
        {
            this.GetComponent<Animator>().SetInteger("State", 0);
        }
        else if (ThisState == 1)//移动状态
        {
            this.GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
            this.GetComponent<Animator>().SetInteger("State", 1);
        }
        else
        {
            HitTime += Time.deltaTime;
            if (HitTime >= 2.5f&&!IsHit)//计时攻击
            {
                this.GetComponent<AudioSource>().Play();
                HitTime = 0;
                HitCube.SetActive(true);
                HitCube.GetComponent<MonsterHit>().HitNum = HitNum;
                this.GetComponent<Animator>().SetInteger("State", Random.Range(2,4));
                IsHit = true;
                Invoke("EndHit", 1.2f);

            }
        }
        if (isBoss)//如果是Boss
        {
            if (ThisState > 0)
            {
                BossHit += Time.deltaTime;
                if (BossHit >= 3)//计时释放技能
                {
                    BossHit = 0;
                    if (Random.Range(0, 2) == 1)
                    {
                        GameObject gameObject1 = GameObject.Instantiate(JiNeng);
                        gameObject1.transform.position = Player.transform.position;
                        gameObject1.GetComponent<MonsterJiNeng>().HitNum = HitNum*2;
                    }
                }
            }
           
        }
        if (Hp <= 0)//自身死亡
        {
            Destroy(this.gameObject);
            Player.GetComponent<PeopleMove>().Score +=4;
        }
	}
    public void EndHit()
    {
        this.GetComponent<Animator>().SetInteger("State", 0);
        IsHit = false;
    }
}
