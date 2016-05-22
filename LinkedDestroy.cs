using UnityEngine;
using System.Collections;

public class LinkedDestroy : MonoBehaviour {

    public Object Link;

    void Start()
    {
        
    }

    void OnDestroy()
    {
        Destroy(Link);
    }
}
