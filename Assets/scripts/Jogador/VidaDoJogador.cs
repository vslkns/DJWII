using UnityEngine;
using UnityEngine.UI; 

public class VidaDoJogador : MonoBehaviour
{
    public GameObject mensagemMorte;
    public GameObject botaoRecomecar;
    public int vidaMaxima = 100;
    public int vidaAtual;


    public Slider barraVida;

    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarBarraVida();
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
        AtualizarBarraVida();

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    public void Curar(int quantidade)
    {
        vidaAtual += quantidade;

        if (vidaAtual > vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }

        AtualizarBarraVida();
    }

    void AtualizarBarraVida()
    {
        if (barraVida != null)
        {
            barraVida.maxValue = vidaMaxima;
            barraVida.value = vidaAtual;
        }
    }

    void Morrer()
    {
        if (mensagemMorte != null) mensagemMorte.SetActive(true);
        if (botaoRecomecar != null) botaoRecomecar.SetActive(true);
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }
}