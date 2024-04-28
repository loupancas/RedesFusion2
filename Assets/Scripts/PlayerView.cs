using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerView : NetworkBehaviour
{
    //[SerializeField] private ParticleSystem _shootingParticles;

    private NetworkMecanimAnimator _mecanim;

    public override void Spawned()
    {
        if (!HasStateAuthority) return;

        _mecanim = GetComponentInChildren<NetworkMecanimAnimator>();
            
        //var m = GetComponentInParent<PlayerMovement>();

        //if (!m || !_mecanim) return;

        //m.OnMovement += MoveAnimation;
        //m.OnShooting += RPC_TriggerShootingParticles;

    }

    void MoveAnimation(float xAxi)
    {
        _mecanim.Animator.SetFloat("axi", Mathf.Abs(xAxi));
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    void RPC_TriggerShootingParticles()
    {
        //_shootingParticles.Play();
    }
}
