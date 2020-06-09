using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Textseven : MonoBehaviour, IPointerClickHandler
{
    public static bool textseven_click = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("マウスがクリックされた");
        textseven_click = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
