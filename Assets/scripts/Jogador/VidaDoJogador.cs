using UnityEngine;

public class VidaDoJogador : MonoBehaviour
{
    public GameObject mensagemMorte;
    public GameObject botaoRecomecar;
    public int vidaMaxima = 100;
    private int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;

        Debug.Log("Vida do Jogador: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Jogador morreu!");

        mensagemMorte.SetActive(true);
        botaoRecomecar.SetActive(true);

        Time.timeScale = 0;

        gameObject.SetActive(false);
    }
}