 using UnityEngine;

public class Codigoinimigos:
MonoBehaviour

{
    public GameObject inimigo;
    public float tempoEntreInimigos = 2f;

    private float tempo = 0f;

    void Update()
    {
        tempo+= Time.deltaTime;

        if(tempo >= tempoEntreInimigos)
        {
            CriarInimigo();
            tempo = 0f;
        }
    }

    void CriarInimigo()
    {
        float x = Random.Range(-8f,8f);
        float y = Random.Range(-4f,4f);

        Vector2 posicao = new Vector2(x,y);

        Instantiate(inimigo, posicao, Quaternion.identity);
    }
}