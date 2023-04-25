using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public CanvasGroup canvasGroup;
    Transform parentAfterDrag;
    private float lerpSpeed=30;

    void Start()
    {
        //canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 targetPosition = touch.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed); 
        }
        else
        {
            Vector3 targetPosition = Input.mousePosition; 
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed); 
        }
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}  
