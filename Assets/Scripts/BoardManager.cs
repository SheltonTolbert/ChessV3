using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int[] boardState;
    private int width = 8;
    private int height = 8;

    public Dictionary<string, int> pieceDictionary = new Dictionary<string, int>();


    // Start is called before the first frame update
    void Start()
    {
        boardState = new int[64];
        initPieceDictionary();
        updateBoardState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateBoardState() {
        int i = 0;
        foreach (Transform child in transform)
        {
            string location = child.gameObject.name;
            int piece = child.GetComponent<PieceCollider>().collidingPiece;
            if (piece > 0)
            {
                //Debug.Log(pieceNumToString(piece) + " to " + location + " id: " + piece);
                boardState[i] = piece;
            }
            else {
                boardState[i] = -1;
            }
            i++;
        }
        
    }
    
    // Overloaded UpdateBoard state for updating one space at a time
    public void updateBoardState(string piece, bool leaving)
    {
        //Debug.Log(piece);
    }

    // Match piece prefab names to an integer - makes working with the prefabs in the editor much easire. 
    private void initPieceDictionary() {
        pieceDictionary.Add("BishopLight", 1);
        pieceDictionary.Add("BishopDark", 2);
        pieceDictionary.Add("KingDark", 3);
        pieceDictionary.Add("KingLight", 4);
        pieceDictionary.Add("KnightDark", 5);
        pieceDictionary.Add("KnightLight", 6);
        pieceDictionary.Add("PawnLight", 7);
        pieceDictionary.Add("PawnDark", 8);
        pieceDictionary.Add("QueenDark", 9);
        pieceDictionary.Add("QueenLight", 10);
        pieceDictionary.Add("RookDark", 11);
        pieceDictionary.Add("RookLight", 12);
    }

    private string pieceNumToString(int pieceNum)
    {
        // Iterate through dictionary values to return the coorisponding Key Name
        foreach (KeyValuePair<string, int> piece in pieceDictionary)
        {
            if (piece.Value == pieceNum)
            {
                return (piece.Key);
            }
        }
        return ("Invalid Piece Number");
    }
}
