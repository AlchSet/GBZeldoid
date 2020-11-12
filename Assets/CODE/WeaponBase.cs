using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {

    public bool Equipped;

    public bool inAttack;



    public abstract void OnButtonDown();
    public abstract void OnButtonUp();
    public abstract bool GetInUse();
    public abstract void Dispose();

}
