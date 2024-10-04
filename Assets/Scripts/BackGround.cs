using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    

    [SerializeField]private RawImage backgroundIMG;
    private float ySpeed = 1f;

    void Update()
    {
        backgroundIMG.uvRect = new  Rect(backgroundIMG.uvRect.position + new Vector2(0,ySpeed) * Time.deltaTime, backgroundIMG.uvRect.size); 
    }
}
