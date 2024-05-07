using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;


public class PowerUp : NetworkBehaviour
{
    public float jump = 10f;
    public float Radius = 1f;
    public float Cooldown = 25f;
    public LayerMask LayerMask;
    public GameObject IsActive;
    //public GameObject Desactivated;
    public Player player;

    public bool Active => _activationTimer.ExpiredOrNotRunning(Runner);

    private TickTimer _activationTimer { get; set; }

    
    private static Collider[] _colliders = new Collider[4];
    public override void Spawned()
    {
        
        

    }

    public override void FixedUpdateNetwork()
    {
        if (IsActive == false) return;

        //se ejecutara el power up
        
        int collisions = Runner.GetPhysicsScene().OverlapSphere(transform.position + Vector3.up, Radius, _colliders, LayerMask, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < collisions; i++)
        {
            
            var pickUp = _colliders[i].GetComponentInParent<PowerUpAbilities>();
            if (pickUp != null  )
            {
                PowerUpAbilities.instance.jumpPowerUp(jump);

                // Pickup was successful, activating timer.
                _activationTimer = TickTimer.CreateFromSeconds(Runner, Cooldown);
                break;
            }
        }

       

    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + Vector3.up, Radius);
    }

}
