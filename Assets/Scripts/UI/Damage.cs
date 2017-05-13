using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour 
{ 
    public PlayerStats Char; // чьи статі
    public float DamageCoef = 1;

    void Awake()
    {
       // controller = GetComponent<CharacterController>();
    } 
   
    void RestartLevel()
    {
      //  PlayerStats PlayerSt = (PlayerStats)Char.GetComponent("PlayerStats");
        if (Char.CurHealth <= 0)
        {
            // Что делать после окончания
        }
    }

    public void DamageHealth(int damagePoint)
    {
        // PlayerStats PlayerSt = (PlayerStats)Char.GetComponent("PlayerStats");
        Char.CurHealth = Char.CurHealth - damagePoint;
    }
}
