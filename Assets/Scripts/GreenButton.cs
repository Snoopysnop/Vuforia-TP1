using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown() {
        Debug.Log("MouseDown");
    }
    void OnMouseOver() { Debug.Log("OnMouseOver"); }
    void OnMouseUp() { Debug.Log("OnMouseUp"); }
}
