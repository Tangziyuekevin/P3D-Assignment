using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PeopleMove : MonoBehaviour
{

    [Range(0.1f, 10f)]
    public float moveSpeed;
    [Range(.1f, 2.66f)]
    public float jumpHeight;
    [Range(10, 360f)]
    public float rotationSpeed;
    private Animator An;
    private Rigidbody Ri;
    private Transform Chan;
    public Transform CameraforChan;
    private Vector3[] direction;
    private float angle;
    private bool rotating;
    private Matrix4x4 rotate45 = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 45, 0), Vector3.one);
    private AnimatorStateInfo currentBaseState;
    static int jumpState = Animator.StringToHash("Base Layer.jump");
    bool CanJump;
    bool CanAttack;

   

    public GameObject[] WuQi;


   
    public GameObject AllMonster;
  
  
   

    public AudioClip[] audioClips;

    public float JiNTime;
    public Text JiNengtext;


    public float HP;
    public Image HPSlider;

    public GameObject[] EndImg;


    public int Level;
    public int Score;

    public Text LevelText;

    public int jineng;

    public GameObject[] DiTu;
    public GameObject[] Men;

    public GameObject[] WeiZhi;


    public bool YaoShi;
    public bool Jian;
    public GameObject Jianobj;
    void Start()
    {
        An = this.GetComponent<Animator>();
        Ri = this.GetComponent<Rigidbody>();
        Chan = this.transform;
        direction = new Vector3[2];
        rotating = false;
        HP = 100;
        jineng = 0;
        Time.timeScale = 1;

    }
    private void Update()
    {
        if (HP <= 0)//主角血量为零 死亡
        {
            Time.timeScale = 0;
            EndImg[0].SetActive(true);
        }
        if (HP >= 100)//血量最多为100
        {
            HP = 100;
        }
        HPSlider.fillAmount = HP / 100.0f;//血量显示
      
        LevelText.text = Level.ToString();//等级显示
        if (Score == 10)//根据分数改变等级
        {
            Men[0].SetActive(true);
            Level = 2;
        }
        if (Score == 20)
        {
            Men[1].SetActive(true);
            Level = 3;
        }
        if (Score == 30)
        {
            Level = 4;
        }
        JiNTime -= Time.deltaTime;//技能倒计时
        JiNengtext.text = ((int)JiNTime).ToString();
        if (JiNTime <= 0)
        {
            JiNengtext.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            JiNengtext.transform.parent.gameObject.SetActive(true);
        }
    }

    private void LateUpdate()
    {
      
            Movepos(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));//移动
            Jump(Input.GetAxis("Jump"));//跳跃
        if (Jian)
        {
            Jianobj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z) && !CanAttack)//攻击
            {
                this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);//播放音效
                CanAttack = true;
                Attack(1);//攻击
                          // WuQi[0].SetActive(true);
                WuQi[0].GetComponent<Wepen>().HitNum = 5;//伤害值
                Invoke("EndAttack", 1f);//延迟调用结束攻击
                Invoke("Attack1", 0.6f);//延迟调用攻击特效
            }
            if (Input.GetKeyDown(KeyCode.X) && !CanAttack && jineng >= 1)
            {
                this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
                CanAttack = true;
                Attack(2);
                WuQi[1].GetComponent<Wepen>().HitNum = 10;
                Invoke("EndAttack", 1f);
                Invoke("Attack2", 0.4f);

            }
            if (Input.GetKeyDown(KeyCode.C) && !CanAttack && JiNTime <= 0 && jineng >= 2)
            {
                this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
                CanAttack = true;
                Attack(3);
                JiNTime = 10;
                WuQi[2].GetComponent<Wepen>().HitNum = 15;
                Invoke("EndAttack", 1.5f);
                Invoke("Attack3", 0.8f);
            }

        }



    }
    public void Attack3()//攻击特效显示
    {
        WuQi[2].SetActive(true);
        WuQi[2].GetComponent<Collider>().enabled = true;
    }
    public void Attack2()
    {
        WuQi[1].SetActive(true);
        WuQi[1].GetComponent<Collider>().enabled = true;
    }
    public void Attack1()
    {
        WuQi[0].SetActive(true);
        WuQi[0].GetComponent<Collider>().enabled = true;
    }
    public void Attack(int t)//攻击动画播放
    {
        An.SetInteger("Attack", t);
    }
    public void EndAttack()//结束攻击
    {
        CanAttack = false;
        WuQi[0].SetActive(false);
        WuQi[1].SetActive(false);
        WuQi[2].SetActive(false);

        An.SetInteger("Attack", 0);
    }
    private void Jump(float var)
    {
      
        if (var > 0 &&!CanJump)
        {
            An.SetBool("jump", true);
            Ri.velocity = new Vector3(0, Mathf.Sqrt(3 * 9.8f * jumpHeight), 0);
            CanJump = true;
           Invoke("EndJump",1.1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)//碰撞检测
    {
        if (other.tag == "1")//血包加血
        {
            Destroy(other.gameObject);
            HP += Random.Range(5,20);
            if (HP >= 100)
            {
                HP = 100;
            }
        }
        if (other.tag == "Change")//过关
        {
           // Destroy(other.gameObject);
            if (Score == 10)
            {

                this.transform.position = WeiZhi[1].transform.position;
                DiTu[0].SetActive(false);
                DiTu[1].SetActive(true);
            }
            if (Score == 20)
            {

                this.transform.position = WeiZhi[2].transform.position;
                DiTu[1].SetActive(false);
                DiTu[2].SetActive(true);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
       
    }

    public void EndJump()
    {
        An.SetBool("jump", false);
        CanJump = false;
    }
    private void Movepos(float LR, float FB)
    {
        float var = FB != 0 ? FB : LR;
        currentBaseState = An.GetCurrentAnimatorStateInfo(0);
        if (currentBaseState.fullPathHash != jumpState)
        {

            An.SetFloat("Speed", Mathf.Abs(var));
            if (var != 0)
            {
                Calculation(FB > 0 && LR < 0 ? 4 : FB > 0 && LR > 0 ? 5 : FB < 0 && LR < 0 ? 6 : FB < 0 && LR > 0 ? 7
                    : FB > 0 ? 0 : FB < 0 ? 1 : LR < 0 ? 2 : 3);


                if (!rotating)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        Ri.MovePosition(Chan.position + direction[1] * Time.fixedDeltaTime * moveSpeed * 2);
                        An.SetBool("run", true);
                    }
                    else
                    {
                        Ri.MovePosition(Chan.position + direction[1] * Time.fixedDeltaTime * moveSpeed);
                        An.SetBool("run", false);
                    }

                }
                else
                {
                    An.SetBool("run", false);
                }
            }
            else
            {
                An.SetBool("run", false);
            }
        }
    }
    private void Calculation(int LRFB)
    {
        direction[0] = Chan.forward;
        switch (LRFB)
        {
            case 4:
                direction[1] = rotate45.MultiplyPoint3x4(-CameraforChan.right);
                break;
            case 5:
                direction[1] = rotate45.MultiplyPoint3x4(CameraforChan.forward);
                break;
            case 6:
                direction[1] = rotate45.MultiplyPoint3x4(-CameraforChan.forward);
                break;
            case 7:
                direction[1] = rotate45.MultiplyPoint3x4(CameraforChan.right);
                break;
            case 0:
                direction[1] = CameraforChan.forward;
                break;
            case 1:
                direction[1] = -CameraforChan.forward;
                break;
            case 2:
                direction[1] = -CameraforChan.right;
                break;
            case 3:
                direction[1] = CameraforChan.right;
                break;
        }
        angle = (Vector3.Dot(Chan.right, direction[1]) > 0 ? 1 : -1)
                    * Vector2.Angle(new Vector2(direction[0].x, direction[0].z), new Vector2(direction[1].x, direction[1].z));
        if (Mathf.Abs(angle) < 90)
        {
            rotating = false;
        }
        else
        {
            rotating = true;
        }
        if (Mathf.Abs(angle) > 10)
        {
            Ri.MoveRotation(Quaternion.Euler(Chan.rotation.eulerAngles + new Vector3(0, angle * rotationSpeed * Time.fixedDeltaTime, 0)));
        }
    }


    public void Again()//再来
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//加载当前场景
    
    }
    public void ExitGame()
    {
        Application.Quit();//退出游戏
    }
}
