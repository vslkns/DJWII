using UnityEngine;

public class VidaDoInimigo : MonoBehaviour
{
    public int vidaMaxima = 20;
    public int vidaAtual;


    public GameObject bauPrefab;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
  
        if (bauPrefab != null)
        {
            Instantiate(bauPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}