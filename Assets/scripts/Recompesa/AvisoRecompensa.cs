using UnityEngine;
using TMPro;

public class AvisoRecompensa : MonoBehaviour
{
    public static TextMeshProUGUI textoUI;
    private static float tempoParaSumir = 0f;

    void Start()
    {
        textoUI = GetComponent<TextMeshProUGUI>();
        textoUI.text = ""; 
    }

    void Update()
    {

        if (tempoParaSumir > 0)
        {
            tempoParaSumir -= Time.deltaTime;
            if (tempoParaSumir <= 0)
            {
                textoUI.text = "";
            }
        }
    }

    public static void MostrarAviso(string mensagem)
    {
        if (textoUI != null)
        {
            textoUI.text = mensagem;
            tempoParaSumir = 2f; 
        }
    }
}