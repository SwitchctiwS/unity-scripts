using UnityEngine;
using System.Collections;

public class WarpController : MonoBehaviour
{
    public WarpController destination;
    public Vector2 offset = new Vector2 (0, 0);

    private Transform justJumpedSubject;

    void JumpToMe(Transform subject)
    {
        // we get the subject to my platform
        // and prevent it from immediately rejumping
        subject.transform.position = transform.position;
        justJumpedSubject = subject;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Vector2 distanceFromWarpPoint = new Vector2 (Mathf.Abs(other.transform.position.x - transform.position.x), 
            Mathf.Abs(other.transform.position.y - transform.position.y));

        if ( (other.transform != justJumpedSubject) && (distanceFromWarpPoint.x <= offset.x) && (distanceFromWarpPoint.y <= offset.y) )
        {
            // tell the other side to receive subject
            destination.JumpToMe(other.transform);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == justJumpedSubject)
        {
            // stepped off, don't protect subject anymore against
            // accidentally teleports
            justJumpedSubject = null;
        }
    }
}