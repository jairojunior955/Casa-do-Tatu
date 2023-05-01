using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // o objeto a ser seguido pela c�mera
    public float smoothSpeed = 0.125f; // velocidade de suaviza��o do movimento
    public Vector3 offset; // dist�ncia da c�mera em rela��o ao objeto
    void Start()
    {
        // obt�m a largura e a altura da tela em pixels
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        // exibe a largura e a altura da tela no console
        Debug.Log("Screen width: " + screenWidth + " pixels");
        Debug.Log("Screen height: " + screenHeight + " pixels");
    }
    void LateUpdate()
    {
        // define a posi��o da c�mera para seguir o objeto
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z; // mant�m a posi��o Z atual da c�mera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // faz a c�mera sempre olhar para o objeto
        transform.LookAt(target);
    }
}
