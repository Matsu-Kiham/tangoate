using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Textsix : MonoBehaviour, IPointerClickHandler
{
    public static bool textsix_click = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("マウスがクリックされた");
        textsix_click = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
