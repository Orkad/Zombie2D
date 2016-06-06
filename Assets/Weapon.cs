using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.Networking;

public abstract class Weapon : NetworkBehaviour,IUsable
{
    public abstract void Use();

}
