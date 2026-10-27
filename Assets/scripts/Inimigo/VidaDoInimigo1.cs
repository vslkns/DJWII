using UnityEngine;

public class VidaDoInimigo1 : MonoBehaviour
{
    public int vidaMaxima = 40;
    public int vidaAtual;
    
    public GameObject bauPrefab;

    public static int inimigosDerrotados = 0;
    
    public int inimigosParaGerarBau = 1;

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
        inimigosDerrotados++;
        Debug.Log("Inimigos derrotados: " + inimigosDerrotados);

       
        if (inimigosDerrotados >= inimigosParaGerarBau)
        {
            if (bauPrefab != null)
            {
                Instantiate(bauPrefab, transform.position, Quaternion.identity);
                Debug.Log("Baú gerado após " + inimigosParaGerarBau + " inimigos!");
            }

            inimigosDerrotados = 0;
        }

        Destroy(gameObject);
    }
}