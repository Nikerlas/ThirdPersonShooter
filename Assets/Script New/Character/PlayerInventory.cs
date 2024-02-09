using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Bow bowScript;

    public void getArrow()
    {
        bowScript.bowSettings.arrowCount += 5;
    }
}
