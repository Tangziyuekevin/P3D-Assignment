using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Monster : MonoBehaviour {
    public int thisone;
    public int ThisState;
    public GameObject Player;
    public float AttackTime;
    public GameObject[] Bullet;
    public float[] AllDis;
    public float HP;
    float MAxHP;
    public Slider slider1;
    public AudioClip[] audioClips;
     public GameObject jian;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
      
        MAxHP = HP;
        slider1.maxValue = MAxHP;
    }
	
	// Update is called once per frame
	void Update () {
        slider1.value = HP;//血条显示
        if (HP <= 0)//死亡
        {
            Destroy(this.gameObject);
            Player.GetComponent<PeopleMove>().Score += 1;
            
                if (Random.Range(0, 2) == 1)//随机生成道具
            {
                    GameObject.Instantiate(jian, this.transform.position, Quaternion.identity);
                }
            
        }
        if (thisone == 0)
        {
            if (ThisState == 0)//站立状态
            {
                this.GetComponent<NavMeshAgent>().enabled = false;
            }
            else if (ThisState == 1)//移动状态  追主角
            {
                this.GetComponent<NavMeshAgent>().enabled = true;
                this.GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
            }
            else if (ThisState == 2)//攻击状态
            {
                this.GetComponent<Animator>().SetInteger("State", 0);
                this.GetComponent<NavMeshAgent>().enabled = false;
                AttackTime += Time.deltaTime;
                if (AttackTime >= 1.5f)//计时攻击
                {
                    this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
                    ThisState = 3;
                    if (Random.Range(0, 2) == 1)//随机看向主角
                    {
                        this.transform.LookAt(new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z));
                    }
                    AttackTime = 0;
                    this.GetComponent<Animator>().SetInteger("State", 1);//播放动画
                    Bullet[0].SetActive(true);
                    Invoke("EndAttack", 1);
                }
            }
            else
            {

            }
            float Dis = Vector3.Distance(this.transform.position, Player.transform.position);//根据自身与主角距离切换状态
            if (Dis < AllDis[0] && Dis > AllDis[1])
            {
                ThisState = 1;
                this.GetComponent<Animator>().SetInteger("State", 2);
            }
            else if (Dis <= AllDis[1])
            {
                if(ThisState != 3)
                ThisState = 2;
               
            }
            else
            {
                ThisState = 0;
                this.GetComponent<Animator>().SetInteger("State", 0);
            }
        }
        if (thisone == 1)//如果可以射击
        {
            float Dis = Vector3.Distance(this.transform.position, Player.transform.position);
            if (Dis < AllDis[0] )
            {
                AttackTime += Time.deltaTime;
                if (AttackTime >= 1.5f)//进入射程发射子弹
                {
                    
                    this.transform.LookAt(new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z));
                    
                    AttackTime = 0;

                    GameObject gameObject1 = GameObject.Instantiate(Bullet[0], Bullet[1].transform.position, Quaternion.identity);
                    Vector3 dis1= new Vector3(Player.transform.position.x, Bullet[1].transform.position.y, Player.transform.position.z) - gameObject1.transform.position;
                    gameObject1.transform.forward = dis1;
                }
            }
        }
	}
    public void EndAttack()//结束攻击动画
    {
        ThisState = 0;
        this.GetComponent<Animator>().SetInteger("State", 0);
    }
}
