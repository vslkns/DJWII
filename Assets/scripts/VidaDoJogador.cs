using UnityEngine;

public class VidaDoJogador : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaAtual;

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
        Debug.Log("Jogador morreu!");
    }
}