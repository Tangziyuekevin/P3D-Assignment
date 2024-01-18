using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JieSao : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject show;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        Destroy(this.gameObject);
        show.SetActive(true);
    }
}
