using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Textone : MonoBehaviour, IPointerClickHandler
{
    public static bool textone_click = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //　マウスがクリックされた時
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("マウスがクリックされた");
        textone_click = true;
    }

    //public void Pushed()
    //{
    // デバッグログに「test」と出力
    //    Debug.Log("test");
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
