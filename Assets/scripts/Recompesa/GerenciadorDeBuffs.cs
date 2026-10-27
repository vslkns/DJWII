using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDeBuffs : MonoBehaviour
{
    public static GerenciadorDeBuffs instance;


    public Slider barraTempo;

    private float tempoRestante = 0f;
    private float duracaoTotal = 15f;
    private bool buffAtivo = false;

 
    private float velocidadeOriginal;
    private float cadenciaOriginal;
    
    private MovimentJogador movimento;
    private AtaquedoJogador ataque;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (barraTempo != null)
        {
            barraTempo.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (buffAtivo)
        {
            tempoRestante -= Time.deltaTime;

            if (barraTempo != null)
            {
                barraTempo.value = tempoRestante / duracaoTotal;
            }

            if (tempoRestante <= 0)
            {
                RemoverBuff();
            }
        }
    }

    public void AplicarBuffVelocidade(MovimentJogador playerMov, float aumento, float duracao)
    {
        movimento = playerMov;
        if (!buffAtivo) velocidadeOriginal = movimento.velocidade;

        movimento.velocidade += aumento;
        IniciarTemporizador(duracao);
    }

    public void AplicarBuffCadencia(AtaquedoJogador playerAtaque, float reducaoIntervalo, float duracao)
    {
        ataque = playerAtaque;
        if (!buffAtivo) cadenciaOriginal = ataque.attackInterval;

        ataque.attackInterval -= reducaoIntervalo;
        if (ataque.attackInterval < 0.15f) ataque.attackInterval = 0.15f;

        IniciarTemporizador(duracao);
    }

    private void IniciarTemporizador(float duracao)
    {
        duracaoTotal = duracao;
        tempoRestante = duracao;
        buffAtivo = true;

        if (barraTempo != null)
        {
            barraTempo.gameObject.SetActive(true);
            barraTempo.value = 1f;
        }
    }

    private void RemoverBuff()
    {
        buffAtivo = false;

      
        if (movimento != null && velocidadeOriginal > 0)
        {
            movimento.velocidade = velocidadeOriginal;
        }

        if (ataque != null && cadenciaOriginal > 0)
        {
            ataque.attackInterval = cadenciaOriginal;
        }

        if (barraTempo != null)
        {
            barraTempo.gameObject.SetActive(false); 
        }

        AvisoRecompensa.MostrarAviso("O efeito do Buff acabou!");
    }
}