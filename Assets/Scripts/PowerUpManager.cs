using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PowerUpManager : MonoBehaviour
{
    public Transform powerUpParent;
    public List<GameObject> powerUps = new List<GameObject>();
    public Text notificationText;
    public float interactionRange = 5f;
    public Player player;

    void Start()
    {
        PopulatePowerUpsList();
    }

    private void Update()
    {
        if (player != null)
        {
            StartCoroutine(InteractWithClosestPowerUpCoroutine(player.transform.position));
        }
    }

    void PopulatePowerUpsList()
    {
        powerUps = powerUpParent.Cast<Transform>()
            .Select(child => child.gameObject)
            .ToList();
    }

    public GameObject FindClosestPowerUp(Vector3 position)
    {
        return powerUps.OrderBy(p => Vector3.Distance(p.transform.position, position)).FirstOrDefault();
    }

    IEnumerator InteractWithClosestPowerUpCoroutine(Vector3 playerPosition)
    {
        GameObject closestPowerUp = FindClosestPowerUp(playerPosition);
        if (closestPowerUp != null && Vector3.Distance(closestPowerUp.transform.position, playerPosition) <= interactionRange)
        {
            notificationText.text = "Power Up cerca";
            yield return new WaitForSeconds(5f); 
            
        }
       
    }
}

