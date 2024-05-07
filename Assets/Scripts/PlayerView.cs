using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerView : NetworkBehaviour
{
    //[SerializeField] private ParticleSystem _shootingParticles;

    private NetworkMecanimAnimator _mecanim;
    private Player Player;
    //Animator _animator;

    public override void Spawned()
    {
        if (!HasStateAuthority) return;

        _mecanim = GetComponentInChildren<NetworkMecanimAnimator>();

        if (!_mecanim) return;



    }

    public override void FixedUpdateNetwork()
    {
        if (IsProxy == true)
            return;

        if (Runner.IsForward == false)
            return;

        if (Player._jumpPressed == true)
        {
            _mecanim.SetTrigger("Attack", true);
        }

        if (Player._rgbd.velocity.sqrMagnitude < 0.01f)
        {
            _mecanim.Animator.SetFloat("Speed", 0);
        }
        else
        {
            _mecanim.Animator.SetFloat("Speed", Player._speed);

        }

    }

    private void Awake()
    {
        Player = GetComponentInChildren<Player>();
        _mecanim = GetComponentInChildren<NetworkMecanimAnimator>();
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    void RPC_TriggerShootingParticles()
    {
        //_shootingParticles.Play();
    }
}
