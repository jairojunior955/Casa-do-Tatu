using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class CollisionBins : MonoBehaviour, IDropHandler
{
    private string _name;
    string target = "";
    [SerializeField] 
    private TMP_Text textPoint;
    private int points;
    [SerializeField]
    private GameObject textoOB;
    [SerializeField]
    private GameObject spTrashOB;
    private Points Pontos;
    private SpawnTrash spTrash;
    void Start()
    {
        _name = gameObject.name;
        Pontos = textoOB.GetComponent<Points>();
        spTrash = spTrashOB.GetComponent<SpawnTrash>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        print(eventData.pointerDrag.gameObject.name);
        GameObject go = eventData.pointerDrag.gameObject;
        switch (_name)
        {
            case "lixeira_plastico":
                target = "lixo_plastico";
                DestroyOB(go);
                break; 
            case "lixeira_organica":
                target = "lixo_organico";
                DestroyOB(go);
                break;
            case "lixeira_metal":
                target = "lixo_metal";
                DestroyOB(go);
                break;
            case "lixeira_vidro":
                target = "lixo_vidro";
                DestroyOB(go);
                break;
            case "lixeira_papel":
                target = "lixo_papel";
                DestroyOB(go);
                break;
            case "lixeira_eletronica":
                target = "lixo_eletronico";
                DestroyOB(go);
                break;
        }

        
        
    }

    void DestroyOB(GameObject go)
    {
        print(go.tag);
        if (go.tag == target)
        {
            Destroy(go);
            print("lixo correto");
            Pontos.AdicionarPontos(100);
            spTrash.random_trash();
        }
        else
        {
            Destroy(go);
            print("Lixo incorreto");
            Pontos.SubtrairPontos(50);
            spTrash.random_trash();
        }
    }
}
