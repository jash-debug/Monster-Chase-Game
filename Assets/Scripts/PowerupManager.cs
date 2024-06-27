using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private bool indestructible;

    public bool IsIndestructible()
    {
        return indestructible;
    }

    public void SetIndestructible(bool value)
    {
        indestructible = value;
    }

    private void Start()
    {
        indestructible = false;
    }

}
