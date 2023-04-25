using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public int Pontos = 0;
    [SerializeField]
    private TMP_Text texto;
    private bool trocarCor = false;
    // Método para adicionar pontos
    public void AdicionarPontos(int quantidade)
    {
        Pontos += quantidade;
        IniciarCoroutineTrocarCorTexto(true);
    }

    // Método para subtrair pontos
    public void SubtrairPontos(int quantidade)
    {
        Pontos -= quantidade;
        IniciarCoroutineTrocarCorTexto(false);
    }
    private void Update()
    {
        texto.text = "" + Pontos;
    }
   private void IniciarCoroutineTrocarCorTexto(bool acertou)
    {
        StartCoroutine(TrocarCorTextoVermelho(acertou));
    }

    // Coroutine para trocar a cor do texto para vermelho durante 1 segundo
    private IEnumerator TrocarCorTextoVermelho(bool acertou)
    {
        if (acertou)
        {
            texto.color = Color.green;
        }
        else 
        {
            texto.color = Color.red;
        }  
        trocarCor = true;

        yield return new WaitForSeconds(1.0f);

        texto.color = Color.white;
        trocarCor = false;
    }


}
