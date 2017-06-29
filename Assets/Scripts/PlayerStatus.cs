using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public bool poo = false;

    [SerializeField]
    private bool withGarbage = false;

    public bool GetPoo()
    {
        return poo;
    }

    public void SetPoo(bool b)
    {
        poo = b;
    }

    public void SetGarbageAttached (bool b)
    {
        withGarbage = b;
    }

    public bool GetGarbageAttached()
    {
        return withGarbage;
    }





}
