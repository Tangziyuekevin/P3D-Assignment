using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Men1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (this.transform.localEulerAngles.y == 0&&GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().YaoShi)
        {
            this.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
       
    }

}
