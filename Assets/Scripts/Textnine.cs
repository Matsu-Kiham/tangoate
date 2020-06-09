using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Textnine : MonoBehaviour, IPointerClickHandler
{
    public static bool textnine_click = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("マウスがクリックされた");
        textnine_click = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
