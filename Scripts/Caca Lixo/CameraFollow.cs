using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // o objeto a ser seguido pela câmera
    public float smoothSpeed = 0.125f; // velocidade de suavização do movimento
    public Vector3 offset; // distância da câmera em relação ao objeto
    void Start()
    {
        // obtém a largura e a altura da tela em pixels
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        // exibe a largura e a altura da tela no console
        Debug.Log("Screen width: " + screenWidth + " pixels");
        Debug.Log("Screen height: " + screenHeight + " pixels");
    }
    void LateUpdate()
    {
        // define a posição da câmera para seguir o objeto
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z; // mantém a posição Z atual da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // faz a câmera sempre olhar para o objeto
        transform.LookAt(target);
    }
}
