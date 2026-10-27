using UnityEngine;

public class Bau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            int sorteio = Random.Range(1, 5);

            if (sorteio == 1)
            {
                VidaDoJogador vida = outro.GetComponent<VidaDoJogador>();
                if (vida != null)
                {
                    vida.Curar(20);
                    AvisoRecompensa.MostrarAviso("Vida Recuperada (+20)!");
                }
            }
            else if (sorteio == 2)
            {
                AtaquedoJogador ataque = outro.GetComponent<AtaquedoJogador>();
                if (ataque != null)
                {
                    float porcentagemAumento = Random.Range(5f, 35f);
                    int porcentagemExibida = Mathf.RoundToInt(porcentagemAumento);
                    AvisoRecompensa.MostrarAviso("Dano Aumentado (+" + porcentagemExibida + "%)!");
                }
            }
            else if (sorteio == 3)
            {
                MovimentJogador movimento = outro.GetComponent<MovimentJogador>();
                if (movimento != null && GerenciadorDeBuffs.instance != null)
                {
                    GerenciadorDeBuffs.instance.AplicarBuffVelocidade(movimento, 2.5f, 15f);
                    AvisoRecompensa.MostrarAviso("Super Velocidade (15s)!");
                }
            }
            else if (sorteio == 4)
            {
                AtaquedoJogador ataque = outro.GetComponent<AtaquedoJogador>();
                if (ataque != null && GerenciadorDeBuffs.instance != null)
                {
                    float porcentagemCadencia = Random.Range(0f, 100f);

                    float reducaoCalculada = (ataque.attackInterval * 0.5f) * (porcentagemCadencia / 100f);

                    GerenciadorDeBuffs.instance.AplicarBuffCadencia(ataque, reducaoCalculada, 15f);

                    int porcentagemExibida = Mathf.RoundToInt(porcentagemCadencia);
                    AvisoRecompensa.MostrarAviso("Cadência Rápida (+" + porcentagemExibida + "% por 15s)!");
                }
            }

            Destroy(gameObject);
        }
    }
}