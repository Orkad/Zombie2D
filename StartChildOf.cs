using UnityEngine;
using System.Collections;

public class StartChildOf : MonoBehaviour
{
    public string ParentName;
    public bool DestroyIfNotFound;

    void Start()
    {
        GameObject result = GameObject.Find(ParentName);
        if (result != null)
        {
            transform.SetParent(result.transform);
        }
        else if(DestroyIfNotFound)
            Destroy(gameObject);
    }

}
