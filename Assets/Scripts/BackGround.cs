using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    
    //we zoeken de Image of in dit geval de RawImage en maken een speed voor de background
    [SerializeField]private RawImage backgroundIMG;
    private float ySpeed = 1f;

    void Update()
    {
        //we maken het een rechthoek net rect en zetten daar de sprite op zijn plaat met een vector2 dat de y snelheid aan past maal delta time en maken de image de volle size
        backgroundIMG.uvRect = new  Rect(backgroundIMG.uvRect.position + new Vector2(0,ySpeed) * Time.deltaTime, backgroundIMG.uvRect.size); 
    }
}
