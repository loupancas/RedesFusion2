using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Unity.VisualScripting;

public class PowerUp : NetworkBehaviour
{
    public float jump = 10f;
    public LayerMask LayerMask;
    public GameObject IsActive;
    public GameObject Desactivated;

    public override void Spawned()
    {
        IsActive.SetActive(IsActive);
        Desactivated.SetActive(IsActive == false);

    }

    public override void FixedUpdateNetwork()
    {
        if (IsActive == false) return;

        //funcion para saltar
    }
}
