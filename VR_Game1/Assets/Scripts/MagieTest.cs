using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MagieTest : MonoBehaviour
{
    public GameObject wall;
    public GameObject player;
    public float spawnDistance;
    private bool isWallBuilt = false;
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    
    public float newPositionThresholdDistance = 0.5f;
    public GameObject debugCubePrefab;
    
    private bool isMoving = false;
    private List<Vector3> positionsList = new List<Vector3>();
    
    public Transform movementSource;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
       
        //Start The Movement
        if (!isMoving && isPressed)
        {
            StartMovement();
        }
        //Ending The Movement
        else if (isMoving && !isPressed)
        {
            EndMovement();
        }
        else if (isMoving && isPressed)
        {
            UpdateMovement();
        }
        
    }
    
    private void MagicWall()
    {
			
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        // Debug.Log("Grilletto Premuto!!!");
		    
        Instantiate(wall, spawnPos, playerRotation);
        isWallBuilt = true;
        Invoke("ResetWallCounter", 5.0f);
    }
    private void ResetWallCounter()
    {
        isWallBuilt = false;
    }
    
    void StartMovement()
    {
        Debug.Log("Start Movement");
        isMoving = true;
        positionsList.Clear();
        positionsList.Add(movementSource.position);
        if (debugCubePrefab)
        {
            Destroy(Instantiate(debugCubePrefab,movementSource.position,Quaternion.identity),3);
        }
        
    }

    void EndMovement()
    {
        Debug.Log("Update Movement");
        isMoving = false;
    }

    void UpdateMovement()
    {
        Debug.Log("Update Movement");
        Vector3 lastPosition = positionsList[positionsList.Count - 1]; 
        if (Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);
            if (debugCubePrefab)
            {
                Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
            }
        }
    }
}
