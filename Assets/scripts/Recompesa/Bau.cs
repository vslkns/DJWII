using UnityEngine;

public class Bau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            int sorteio = Random.Range(1, 4);

            if (sorteio == 1)
            {
                // Aumenta a vida atual / máxima do jogador
                VidaDoJogador vida = outro.GetComponent<VidaDoJogador>();
                if (vida != null)
                {
                    vida.vidaMaxima += 20;
                    Debug.Log("Sorteio 1: Vida máxima aumentada!");
                }
            }
            else if (sorteio == 2)
            {
                // Diminui o tempo entre ataques (ataca mais rápido)
                AtaquedoJogador ataque = outro.GetComponent<AtaquedoJogador>();
                if (ataque != null)
                {
                    if (ataque.attackInterval > 0.2f)
                    {
                        ataque.attackInterval -= 0.1f;
                    }
                    Debug.Log("Sorteio 2: Velocidade de ataque aumentada!");
                }
            }
            else if (sorteio == 3)
            {
                // Aumenta a velocidade de movimento do jogador
                MovimentJogador movimento = outro.GetComponent<MovimentJogador>();
                if (movimento != null)
                {
                    movimento.velocidade += 1.5f;
                    Debug.Log("Sorteio 3: Velocidade de movimento aumentada!");
                }
            }

            Destroy(gameObject);
        }
    }
}