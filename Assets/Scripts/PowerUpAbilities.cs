using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAbilities : MonoBehaviour
{
    public bool isCollected = false;
    public int value = 1;
    //public GameObject objectPowerUp;

    [SerializeField] private Player pc;
    [SerializeField] private int fadeTime;
   

    public static PowerUpAbilities instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void speedPowerUp(int ammount)
    {
        NormalizeStats();
        Debug.Log("Powered up");
        pc._speed *= ammount;
        ChangeColor(Color.green);
        StartCoroutine(PowerFade());
    }
    public void jumpPowerUp(float ammount)
    {
        NormalizeStats();
        Debug.Log("Powered up");
        pc._jumpForce *= ammount;
        ChangeColor(Color.blue);
        StartCoroutine(PowerFade());
    }
    public void inmortalPowerUp()
    {
        NormalizeStats();
        Debug.Log("Powered up");
        StartCoroutine(PowerFade());
    }
    public IEnumerator PowerFade()
    {
        yield return new WaitForSeconds(fadeTime);

        NormalizeStats();
        ChangeColor(Color.white);
    }
    public void NormalizeStats()
    {
       
        pc._speed = pc._defaultSpeed;
        pc._jumpForce = pc._defaultJump;
        //HealthSystem.Get().inmortal = false;
    }

    public static PowerUpAbilities Get()
    {
        return instance;
    }

    public void ChangeColor (Color color)
    {
        pc.GetComponent<Renderer>().material.color = color;
    }

}
