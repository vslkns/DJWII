using UnityEngine;

public class Bau : MonoBehaviour

   
   privade void
OnTriggerEnter2D(Collider2D outro)
{
    if(outro.CompareTag("Player"))
    {
        int sorteio = Random.Range(1,4);
        if(sorteio==1)
        {
            vidadejogador vida = outro.GetComponent<vidadejogador>();
            if (vida != null) 
            {
                Debug.Log("Sorteio 1: Recompensa de Vida!");
            }
        }

        else if (sorteio == 2)
        {
            ataquedojogador ataque = outro.GetComponent<ataquedojogador>();
            if (ataque != null)
            {
                Debug.Log("Sorteio 2: Recompensa de ataque");
            }
        }
        
            else if (sorteio == 3)
            {
                movimentojogador movimento = outro.GetComponent<movimentojogador>();
                if (movimento != null)
                {
                    Debug.Log("Sorteio 3: Recompensa de Velocidade!");
                }
            }
        Destroy(gameObject);
    }
}
