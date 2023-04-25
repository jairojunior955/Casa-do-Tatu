using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;

public class ChangeLevels : MonoBehaviour
{
    public GameObject Level;

    public void MudarLevel()
    {
        SceneManager.LoadScene(""+Level.name);
    }

}
