using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LvlGen3 : MonoBehaviour {

	[System.Serializable]
	public class TileHolder {
		public int objX;
		public int objY;
		public string obj_tag;
		public GameObject game_obj;
		public int MyNumber;
	} 
	
	public LayerMask unwalkable;
	public int[,] tilemap;
    public int width;
	int height;

	public GameObject tile, wall;
	public Material[] Stone;
	public Material[] Grass;
	public Material[] Water;
	public GameObject tree;
	
	int myX, myY;
		
	Material m;
	List<int> numbers;
	List<TileHolder> allTiles;
	List<GameObject> walls;

	int count;
	int doorCount;
	int doorNumber;
	public GameObject Door, Entrance;
	//public GameObject gwyllgi, gwyllgi1, gwyllgi2;

	public bool allDone = false;
	int smoothCount = 0;

	GameObject wallGate;
	public GameObject player;
	public GameObject[] spawnPoints;

	void Awake() {
		if (BoolStorage.gameCount == 0) {
			BoolStorage.firstTime = true;
		}
	}
	
	void Start() {
		
		height = width;
		numbers = new List<int>();
		allTiles = new List<TileHolder>();
		walls = new List<GameObject>();
		doorNumber = Random.Range(1, (width*4 + 1));
		
		count = 0;
    
		tilemap = new int[width,height];
		MapMaker();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			Scene loadedLevel = SceneManager.GetActiveScene();
     		SceneManager.LoadScene (loadedLevel.buildIndex);
		}
	/*	if (allDone) {
			if (BoolStorage.gameCount == 0) {
				GameObject spawn = spawnPoints[Random.Range(1, 7)];
				gwyllgi.transform.position = spawn.transform.position;
				gwyllgi.SetActive(true);
			}

			if (BoolStorage.gameCount == 1) {
				GameObject spawn = spawnPoints[Random.Range(1, 7)];
				gwyllgi.transform.position = spawn.transform.position;
				gwyllgi.SetActive(true);
				GameObject spawn2 = spawnPoints[Random.Range(1, 7)];
				gwyllgi1.transform.position = spawn2.transform.position;
				gwyllgi1.SetActive(true);
			}

			if (BoolStorage.gameCount >= 2) {
				GameObject spawn = spawnPoints[Random.Range(1, 7)];
				gwyllgi.transform.position = spawn.transform.position;
				gwyllgi.SetActive(true);
				GameObject spawn2 = spawnPoints[Random.Range(1, 7)];
				gwyllgi1.transform.position = spawn2.transform.position;
				gwyllgi1.SetActive(true);
				GameObject spawn3 = spawnPoints[Random.Range(1, 7)];
				gwyllgi2.transform.position = spawn3.transform.position;
				gwyllgi2.SetActive(true);
			}
		}*/

	}


    void MapMaker() {	
		for (int i = 0; i < (width * height); i++) {
			numbers.Add(Random.Range(1, 4));
		}

		for (int x = Mathf.FloorToInt(-(width/2)); x < Mathf.CeilToInt(width/2); x ++) {
            for (int y = Mathf.FloorToInt(-(height/2)); y < Mathf.CeilToInt(height/2); y ++) {
                if (x == -(width/2) || x == (width/2)-1 || y == -(height/2) || y == (height/2)-1) {

					if (x == -(width/2)) {
						if (y == (height/2)-1 || y == -(height/2)) {
							continue;
						} else {
							if (doorCount != doorNumber) {
								GameObject instance = Instantiate(wall, new Vector3(x, 0, y), Quaternion.identity);
								walls.Add(instance);
							//	instance.transform.SetParent(gameObject.transform);
								doorCount++;
							} else {
								GameObject instance = Instantiate(Door, new Vector3(x, 0, y), Quaternion.identity);
							//	instance.transform.SetParent(gameObject.transform);
								doorCount++;
							}
						} 
					}
					
					if (x == (width/2)-1) {
						if (y == (height/2)-1 || y == -(height/2)) {
							continue;
						} else {
							if (doorCount != doorNumber) {
								GameObject instance = Instantiate(wall, new Vector3(x, 0, y), Quaternion.Euler(0,180,0));
								walls.Add(instance);
//								instance.transform.SetParent(gameObject.transform);
								doorCount++;
							} else {
								GameObject instance = Instantiate(Door, new Vector3(x, 0, y), Quaternion.Euler(0,180,0));
						//		instance.transform.SetParent(gameObject.transform);
								doorCount++;
							}
						}
					}
					
					if (y == -(height/2)) {
						if (doorCount != doorNumber) {
							GameObject instance = Instantiate(wall, new Vector3(x, 0, y), Quaternion.Euler(0,270,0));
							walls.Add(instance);
						//	instance.transform.SetParent(gameObject.transform);
							doorCount++;
						} else {
							GameObject instance = Instantiate(Door, new Vector3(x, 0, y), Quaternion.Euler(0,270,0));
						//	instance.transform.SetParent(gameObject.transform);
							doorCount++;
						}
					}
					
					if (y == (height/2)-1) {
						if (doorCount != doorNumber) {
							GameObject instance = Instantiate(wall, new Vector3(x, 0, y), Quaternion.Euler(0,90,0));
							walls.Add(instance);
						//	instance.transform.SetParent(gameObject.transform);
							doorCount++;
						} else {
							GameObject instance = Instantiate(Door, new Vector3(x, 0, y), Quaternion.Euler(0,90,0));
						//	instance.transform.SetParent(gameObject.transform);
							doorCount++;
						}
					}
				} else {
				    GameObject obj = (GameObject)Instantiate(tile, new Vector3(x, 0, y), Quaternion.identity);
				
				    int rnd = numbers[count];

			    	if (rnd == 1) {
			    		obj.GetComponent<MeshRenderer>().material = Grass[Random.Range(1, 4)];
				    	obj.tag = "Grass";
			    	}

				    if (rnd == 2) {
					    obj.GetComponent<MeshRenderer>().material = Water[Random.Range(1, 4)];
					    obj.tag = "Water";
					}

				    if (rnd == 3) {
 						obj.GetComponent<MeshRenderer>().material = Grass[Random.Range(1, 4)];
					    obj.tag = "Obstacle";  
						obj.layer = 8;
				    }  

					obj.transform.SetParent(gameObject.transform);

					TileHolder newHolder = new TileHolder();
					newHolder.objX = x;
					newHolder.objY = y;
					newHolder.obj_tag = obj.tag;
					newHolder.game_obj = obj;

					allTiles.Add(newHolder);
					count++;
				}
			}
		}
 		
		for (int i = 0; i < 5; i ++) {
            smoothCount++;
			SmoothMap();
        }

		CreateGate();
		MakeObstacles();
		PlayerTile();
		allDone = true;
	}

	void SmoothMap() {
      for (int x = Mathf.FloorToInt(-(width/2)+1); x < Mathf.CeilToInt(width/2)-1; x ++) {
            for (int y = Mathf.FloorToInt(-(height/2)+1); y < Mathf.CeilToInt(height/2)-1; y ++) {
				myX = x;
				myY = y;
				
				List<TileHolder> neighbors = allTiles.FindAll(GetNeighbors);
				TileHolder me = allTiles.Find(FindMe);
				
				if (neighbors.Count >= 3) {
					me.game_obj.GetComponent<MeshRenderer>().material = Water[Random.Range(1, 4)];
					me.obj_tag = "Water";
					me.game_obj.tag = "Water";
				}

				if (neighbors.Count == 1) {
					int waterChance = Random.Range(1, 4);
					if (waterChance == 1) {
						me.game_obj.GetComponent<MeshRenderer>().material = Grass[Random.Range(1, 4)];
						me.obj_tag = "Grass";
						me.game_obj.tag = "Grass";
					} 
				}

				if (neighbors.Count == 0) {
					me.game_obj.GetComponent<MeshRenderer>().material = Grass[Random.Range(1, 4)];
					me.obj_tag = "Grass";
					me.game_obj.tag = "Grass";
				}
			} 
		}

		if (smoothCount == 5) {
			for (int x = Mathf.FloorToInt(-(width/2)+1); x < Mathf.CeilToInt(width/2)-1; x ++) {
				for (int y = Mathf.FloorToInt(-(height/2)+1); y < Mathf.CeilToInt(height/2)-1; y ++) {
					myX = x;
					myY = y;
					
					List<TileHolder> neighbors = allTiles.FindAll(GetNeighbors);
					TileHolder me = allTiles.Find(FindMe);
					
					if (neighbors.Count >= 3) {
						me.game_obj.GetComponent<MeshRenderer>().material = Water[Random.Range(1, 4)];
						me.obj_tag = "Water";
						me.game_obj.tag = "Water";
					}

					if (neighbors.Count <= 1) {
						me.game_obj.GetComponent<MeshRenderer>().material = Grass[Random.Range(1, 4)];
						me.obj_tag = "Grass";
						me.game_obj.tag = "Grass";
					}
				} 
			}
		}

		return;
	}

	private bool GetNeighbors(TileHolder obj) {
		if (obj.objX == myX) {
			if (obj.objY == myY - 1) {
				if (obj.obj_tag == "Water") {
					return true;
				}
			}
			if (obj.objY == myY + 1) {
				if (obj.obj_tag == "Water") {
					return true;
				}
			}
		}

		if (obj.objY == myY) {
			if (obj.objX == myX - 1) {
				if (obj.obj_tag == "Water") {
					return true;
				}
			}
			if (obj.objX == myX + 1) {
				if (obj.obj_tag == "Water") {
					return true;
				}
			}
		}
		return false;
	}

	private bool FindMe(TileHolder me) {
		if (me.objX == myX) {
			if (me.objY == myY) {
				return true;
			}
		}
		return false;
	}

	void MakeObstacles() {
		foreach (TileHolder TH in allTiles){
			if (TH.obj_tag == "Obstacle" || TH.game_obj.tag == "Obstacle") {
			//	TH.game_obj.transform.localScale += new Vector3(0, 2f, 0);
			//	TH.game_obj.GetComponent<MeshRenderer>().enabled = false;
				Instantiate(tree, TH.game_obj.transform.position + Vector3.up, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
				TH.game_obj.layer = 8;
			}
		}
		return;
	}

	void CreateGate() {
		wallGate = null;
		if (BoolStorage.firstTime) {
			//wallGate = walls[Random.Range(1, walls.Count)];
			Instantiate(Entrance, new Vector3(0, 0, -(height/2)), Quaternion.Euler(0,270,0));
			foreach (GameObject wall in walls) {
				if (wall.transform.position == new Vector3(0, 0, -(height/2)+1)) {
					wallGate = wall;
				}
			}
			BoolStorage.firstTime = false;
		} else {
			newExitPosition();
			foreach (GameObject wall in walls) {
				if (wall.transform.position.x == newExitPosition().x && wall.transform.position.z == newExitPosition().y) {
					wallGate = wall;
				}
			}
		}
/*		if (wallGate.transform.rotation == Quaternion.Euler(new Vector3(0, 90, 0))) {
			foreach (TileHolder TH in allTiles) {
				if (TH.game_obj.transform.position.x == wallGate.transform.position.x && TH.game_obj.transform.position.z == (wallGate.transform.position.z - 1f )) {
					if (TH.game_obj.tag != "Grass" || TH.obj_tag != "Grass") {
						TH.game_obj.GetComponent<MeshRenderer>().material = Grass[Random.Range(1, 4)];
				    	TH.game_obj.tag = "Grass";
						TH.obj_tag = "Grass";
					}
				}
			}
		} 
		
		else if (wallGate.transform.rotation == Quaternion.Euler(new Vector3(0, 0, 0))) {
			foreach (TileHolder TH in allTiles) {
				if (TH.game_obj.transform.position.x == (wallGate.transform.position.x + 1) && TH.game_obj.transform.position.z == wallGate.transform.position.z) {
					if (TH.game_obj.tag != "Grass" || TH.obj_tag != "Grass") {
						TH.game_obj.GetComponent<MeshRenderer>().material = Grass[Random.Range(1, 4)];
				    	TH.game_obj.tag = "Grass";
						TH.obj_tag = "Grass";
					}
				}
			}
		} 
		
		else if (wallGate.transform.rotation == Quaternion.Euler(new Vector3(0, 180, 0))) {
			foreach (TileHolder TH in allTiles) {
				if (TH.game_obj.transform.position.x == (wallGate.transform.position.x - 1 ) && TH.game_obj.transform.position.z == wallGate.transform.position.z) {
				if (TH.game_obj.tag != "Grass" || TH.obj_tag != "Grass") {
						TH.game_obj.GetComponent<MeshRenderer>().material = Grass[Random.Range(1, 4)];
				    	TH.game_obj.tag = "Grass";
						TH.obj_tag = "Grass";
					}
				}
			}
		} 
		
		else if (wallGate.transform.rotation == Quaternion.Euler(new Vector3(0, 270, 0))) {
			foreach (TileHolder TH in allTiles) {
				if (TH.game_obj.transform.position.x == wallGate.transform.position.x && TH.game_obj.transform.position.z == (wallGate.transform.position.z + 1f )) {
				if (TH.game_obj.tag != "Grass" || TH.obj_tag != "Grass") {
						TH.game_obj.GetComponent<MeshRenderer>().material = Grass[Random.Range(1, 4)];
				    	TH.game_obj.tag = "Grass";
						TH.obj_tag = "Grass";
					}
				}
			}
		}
		*/

//		wallGate.SetActive(false);
		BoolStorage.firstTime = false;
		
		
	}

	void PlayerTile() {

	}	

	private Vector3 newExitPosition() {
		if (!BoolStorage.firstTime) {
			Vector3 exitPosition = player.GetComponent<OpenDoor>().exitPosition;
			Vector3 exitRotation = player.GetComponent<OpenDoor>().exitRotation;
			if (wall.transform.position == exitPosition) {
				if (exitRotation == new Vector3(0, 0, 0)) {
					BoolStorage.gatePosition = new Vector3(exitPosition.x + 49f, 0, exitPosition.z);
					return new Vector3(exitPosition.x + 49f, 0, exitPosition.z);

				} else if (exitRotation == new Vector3(0, 90, 0)) {
					BoolStorage.gatePosition = new Vector3(exitPosition.x, 0, exitPosition.z - 49f);
					return new Vector3(exitPosition.x, 0, exitPosition.z - 49f);

				} else if (exitRotation == new Vector3(0, 180, 0)) {
					BoolStorage.gatePosition = new Vector3(exitPosition.x - 49f, 0, exitPosition.z);
					return new Vector3(exitPosition.x - 49f, 0, exitPosition.z);

 				} else if (exitRotation == new Vector3(0, 270, 0)) {
					BoolStorage.gatePosition = new Vector3(exitPosition.x, 0, exitPosition.z + 49f);
					return new Vector3(exitPosition.x, 0, exitPosition.z + 49f);				
				 }
			}
		}
		return Vector3.zero;
	}
}