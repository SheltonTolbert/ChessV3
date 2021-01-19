using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//varable scale of backboard
//texture pixels


public class LEDBoard : MonoBehaviour
{
    Vector3 startingPosition;

    public float boardSize = 400.0f;
    public float margin = 1;
    float squareWidth;
    float squareHeight;
    float boardHeight;
    float boardWidth;

    float sizeCheck; 

    // Start is called before the first frame update
    void Start()
    {
        squareWidth = boardSize;
        squareHeight = boardSize;
        boardWidth = squareWidth * (8) + (margin * 7);
        boardHeight = squareHeight * (8) + (margin * 7);

        startingPosition = transform.position;
        buildBoard();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void buildBoard() {
        int i = 0;
        for (float z = 0.0f; z < boardHeight; z += (boardHeight / 8.0f) + margin)
        {
            for (float x = 0.0f; x < boardHeight; x += (boardHeight / 8.0f) + margin)
            {
                GameObject empty = new GameObject(i.ToString());
                empty.transform.parent = gameObject.transform;
                buildSquare(x, z, empty);
                i++;
            }
        }

    }

    private void buildSquare(float originX, float originZ, GameObject parent) {
        int zIndex = 0;
        for (float z = 0.0f; z < squareHeight; z += squareHeight / 16.0f)
        {
            int xIndex = 0;
            for (float x = 0.0f; x < squareWidth; x += squareWidth / 16.0f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = new Vector3(x + originX, 1.5f, z + originZ);
                sphere.transform.parent = parent.transform;
                sphere.name = ( "[" +  zIndex + "," + xIndex + "]");
                xIndex++;
            }
            zIndex++;
        }
    }

}
