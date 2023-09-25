using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   public Image image;
   public Transform parentAfterDrag;
   
   public void OnBeginDrag(PointerEventData eventData)
   {
      Debug.Log("OnBeginDrag");
      parentAfterDrag = transform.parent;
      transform.SetParent(transform.root);
      transform.SetAsLastSibling();
      image.raycastTarget = false;
   }

   public void OnDrag(PointerEventData eventData)
   {
      Debug.Log("On Drag");
      transform.position = Input.mousePosition;
   }

   public void OnEndDrag(PointerEventData eventData)
   {
      Debug.Log("End drag");
      transform.SetParent(parentAfterDrag);
      image.raycastTarget = true;
   }
}
