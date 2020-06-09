using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Textfour : MonoBehaviour, IPointerClickHandler
{
    public static bool textfour_click = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("マウスがクリックされた");
        textfour_click = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
