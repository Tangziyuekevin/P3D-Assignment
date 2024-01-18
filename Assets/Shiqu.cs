using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiqu : MonoBehaviour
{
    // Start is called before the first frame update
    public int temp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        if (temp == 0)
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().YaoShi = true;
        }
        if (temp ==1)
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().Jian = true;
        }
    }
}
