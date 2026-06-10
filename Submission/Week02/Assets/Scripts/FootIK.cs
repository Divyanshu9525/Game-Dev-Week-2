using UnityEngine;

public class FootIK : MonoBehaviour
{
    public Transform body;
    public float footSpacing = 0.15f;
    public LayerMask terrain;

    public float rayDistance = 2f;
    public float smoothSpeed = 10f;

    void Update()
    {
        Vector3 origin = body.position + body.right * footSpacing + Vector3.up * 0.5f;

        if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, rayDistance, terrain))
        {
            Vector3 targetPos = hit.point;

            transform.position = Vector3.Lerp(
                transform.position,
                targetPos,
                smoothSpeed * Time.deltaTime
            );
        }
    }
}
