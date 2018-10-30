using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadClicked : MonoBehaviour {

    POE_RTS poe_rts;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        poe_rts.LoadAll();
    }
}
