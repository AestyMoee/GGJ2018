using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour {

	public GameObject tile;                // The tile prefab to be spawned.
	public float sizeTile = 1f;            // width of each tile square

	public int numRows = 3;				// num of rows on board
	public int numColumns = 5;			// num of tiles in each row
	public GameObject[,] tiles;			// an array of tiles

	void OnValidate()
	{
		if (tile == null)
			Debug.LogError ("Need to specify tile object");

		this.transform.position = Vector3.zero;

		if (tiles != null) {
			foreach (GameObject t in tiles) {
				Destroy (t);
			}
		}

		tiles = new GameObject[numRows, numColumns];

		// instantiate rows of board
		for (int i = 0; i < numRows; i++) {
			
			// instantiate tiles for a row
			for (int j = 0; j < numColumns; j++) {
				// spawn tile
				tiles [i, j] = Instantiate(tile, new Vector3(j, 0, i), Quaternion.identity, this.transform) as GameObject;
			}
		}

		// center board
		//this.transform.position = Vector3((numColumns * .5f), 0, 0);

	}
}