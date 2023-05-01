using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
    private Points points;
    private void Start()
    {
        points = GameObject.Find("PointSystem").GetComponent<Points>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // verifica se o bot�o esquerdo do mouse foi clicado
        {
            Debug.Log("Click");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // converte a posi��o do clique na tela para uma posi��o no mundo

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // lan�a um raio para verificar se acertou um objeto

            if (hit.collider != null) // verifica se o raio atingiu um objeto
            {
                
                GameObject hitObject = hit.collider.gameObject; // obt�m o objeto atingido
                points.AdicionarPontos(50);
                print(hitObject);
                Destroy(hitObject); // destr�i o objeto atingido
            }
            else
            {
                points.SubtrairPontos(50);
            }
        }
    }
}
