using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidade = 2f;

    private Transform jogador;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            jogador = player.transform;
        }
    }

    void Update()
    {
        if (jogador != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                jogador.position,
                velocidade * Time.deltaTime
            );
        }
    }
}