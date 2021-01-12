using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PieceCollider : MonoBehaviour
{

    
    BoardManager boardManager;

    public int collidingPiece = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject board = GameObject.Find("Board");
        boardManager = board.GetComponent<BoardManager>();
        //Debug.Log(boardManager.pieceDictionary["BishopLight"]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider piece)
    {
        //enter collision code here.
        try
        {
            collidingPiece = boardManager.pieceDictionary[piece.name];
            boardManager.updateBoardState();
        }
        catch(System.Exception e)
        {
            // Do nothing if the collider is not a game piece
        }
        }

    private void OnTriggerExit(Collider other) {
        collidingPiece = -1;
    }

    
}
