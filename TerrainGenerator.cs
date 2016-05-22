using UnityEngine;
using System.Collections.Generic;

public class TerrainGenerator : MonoBehaviour {


	public float TileXSize = 1f;
	public float TileYSize = 1f;
	public List<Biome> Biomes;

	void Start(){
		
	}
}

[System.Serializable]
public struct Biome{
	public string Nom;
	public List<SpriteGeneration> FloorTiles;
	public List<SpriteGeneration> WallTiles;
}

[System.Serializable]
public struct SpriteGeneration{
	public Sprite Sprite;
	[Range(0,100)]
	public float Percent;
}
