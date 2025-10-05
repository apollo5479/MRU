using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    private Transform playerTransform;
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
        RaycastHit hit;

        // If ray hit something
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 worldPosition = hit.point;

            worldPosition.y = 0;
            Vector3 playerNormal = new Vector3(playerTransform.position.x, 0, playerTransform.position.z);

            Quaternion lookAt = Quaternion.LookRotation(worldPosition - playerNormal);

            // Smoothly rotate towards the target rotation quaternion.
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, lookAt, playerData.rotateSpeed * Time.deltaTime);
        }
    }

}
