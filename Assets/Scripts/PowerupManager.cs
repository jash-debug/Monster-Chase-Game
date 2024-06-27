using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private bool indestructible;

    public void SetIndestructible (bool state)
    {
        indestructible = state;
    }

    public bool isIndestructible()
    {
        return indestructible;
    }

    private void Start()
    {
        indestructible = false;
    }

}
