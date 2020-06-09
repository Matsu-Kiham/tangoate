using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Texteight : MonoBehaviour, IPointerClickHandler
{
    public static bool texteight_click = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("マウスがクリックされた");
        texteight_click = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
