using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class PowerUpManager : MonoBehaviour
{
    public Transform powerUpParent;
    public List<GameObject> powerUps = new List<GameObject>();
    public Text notificationText; 
    public float interactionRange = 5f; 

    void Start()
    {
        PopulatePowerUpsList();
    }

    private void Update()
    {
        
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

   
    public void InteractWithClosestPowerUp(Vector3 playerPosition)
    {
        GameObject closestPowerUp = FindClosestPowerUp(playerPosition);
        if (closestPowerUp != null && Vector3.Distance(closestPowerUp.transform.position, playerPosition) <= interactionRange)
        {
            
            notificationText.text = "Closest power-up found!";
        }
        else
        {
            Debug.Log("No power-up found nearby or out of range.");
            
            notificationText.text = "";
        }
    }
}

