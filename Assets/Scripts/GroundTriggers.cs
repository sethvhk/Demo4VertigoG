using UnityEngine;
using UnityEngine.EventSystems;

public class GroundTriggers : MonoBehaviour, IPointerClickHandler 
{
    public PlayerController player;

    public void OnPointerClick(PointerEventData eventData)
    {
        player.SetMoveTowardsPoint(eventData.pointerCurrentRaycast.worldPosition);
    }
}