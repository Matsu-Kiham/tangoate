using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Texttwo : MonoBehaviour, IPointerClickHandler
{
    public static bool texttwo_click = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //　マウスがクリックされた時
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("マウスがクリックされた");
        texttwo_click = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
