using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class BackGround : MonoBehaviour
{
    [SerializeField] GameObject[] bg;
    float speed = 2f;

    [SerializeField]float offSet = 15f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Screen.height);
        for (int i = 0; i < bg.Length; i++) 
        { 
            bg[i].transform.position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
            if (bg[i].transform.position.y > offSet)
            {
                Debug.Log("hallo");
                bg[i].transform.position = new Vector3(0,-offSet, 0);
            }
        }
    }
}
