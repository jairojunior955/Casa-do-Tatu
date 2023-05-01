using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTrash : MonoBehaviour
{
    public GameObject[] prefabs; // array de prefabs para instanciar
    public int numberOfObjects = 30; // número de objetos a serem instanciados
    public int spawnHeight = 45; // altura em Y acima do qual os objetos serão instanciados
    public float spawnRange = 1.5f; // faixa de distância X em que os objetos serão instanciados
    public Transform player;
    void Start()
    {
        // itera sobre o número de objetos a serem instanciados
        for (int i = 0; i < numberOfObjects; i++)
        {
            // escolhe aleatoriamente um dos prefabs para instanciar
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            // define a posição aleatória do objeto a ser instanciado
            float xPos = Random.Range(-spawnRange, spawnRange);
            float yPos = Random.Range(player.transform.position.y+5, spawnHeight);
            Vector3 position = new Vector3(xPos, yPos, 0.0f);

            // instanciar o objeto
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
