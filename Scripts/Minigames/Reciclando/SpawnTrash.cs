using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{
    [SerializeField]
    private RectTransform rtSpawnpoint;
    [SerializeField]
    private GameObject canvas;
    public List<GameObject> prefabLixos = new List<GameObject>(); // Lista de prefabs de lixos

    private void Start()
    {
        // Adicione os prefabs de lixos na lista
        // Certifique-se de que a ordem dos prefabs na lista corresponda à ordem dos tipos de lixos na lista 'lista_lixo'
        
    }

    public void random_trash()
    {
        int index = Random.Range(0, prefabLixos.Count);
        GameObject lixoSelecionado = prefabLixos[index];
        Debug.Log("Lixo selecionado: " + lixoSelecionado.name);

        // Instanciar o objeto com o Canvas como pai
        GameObject instancia = Instantiate(lixoSelecionado, rtSpawnpoint.position, Quaternion.identity, transform);

        // Definir o objeto Canvas como pai do objeto instanciado
        instancia.transform.SetParent(canvas.transform);

        // Redefinir a escala local do objeto para preservar a escala original do prefab
        instancia.transform.localScale = Vector3.one;
    }
}
