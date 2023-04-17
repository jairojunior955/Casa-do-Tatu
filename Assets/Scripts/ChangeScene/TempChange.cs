using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TempChange : MonoBehaviour
{
    public void TrocarCena()
    {
        SceneManager.LoadScene("Tela de Fases");
    }
}
