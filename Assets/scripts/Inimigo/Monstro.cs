using UnityEngine;

public class monstro : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if
        (collision.gameObject.CompareTag("Player"))
        {
            VidaDoJogador vida =
            collision.gameObject.GetComponent<VidaDoJogador>();

            if (vida != null)
            {
                vida.ReceberDano(10);
            }
        }
        
    }
}