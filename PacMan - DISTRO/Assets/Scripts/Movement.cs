using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Animator animator;

	public enum Direction{
		still,
		up,
		down,
		left,
		right

	}
	public TextAsset inputMap;
	public string[] Map;
	public Direction _dir = Direction.still;
    public Graph graph;

	public float MSpeed = 2f;

	private Vector2 direc= new Vector2(0f,0f);
	private static Vector2 none= new Vector2(0f,0f);
	private static Vector2 up = new Vector2(0f,1f);
	private static Vector2 down = new Vector2(0f,-1f);
	private static Vector2 right = new Vector2(1f,0f);
	private static Vector2 left = new Vector2(-1f,0f);

	// Use this for initialization
	void Start () {
		string text = inputMap.text;
		string[] lines = text.Split('\n');
		Map = lines;
		animator = GetComponent<Animator> ();
        graph = new Graph();
        Node node1 = new Node(1, -29);
        Node node2 = new Node(12, -29);
        Node node3 = new Node(15, -29);
        Node node4 = new Node(26, -29);
        Node node5 = new Node(1, -26);
        Node node6 = new Node(3, -26);
        Node node7 = new Node(6, -26);
        Node node8 = new Node(9, -26);
        Node node9 = new Node(12, -26);
        Node node10 = new Node(15, -26);
        Node node11 = new Node(18, -26);
        Node node12 = new Node(21, -26);
        Node node13 = new Node(24, -26);
        Node node14 = new Node(26, -26);
        Node node15 = new Node(1, -23);
        Node node16 = new Node(3, -23);
        Node node17 = new Node(6, -23);
        Node node18 = new Node(9, -23);
        Node node19 = new Node(12, -23);
        Node node20 = new Node(15, -23);
        Node node21 = new Node(18, -23);
        Node node22 = new Node(21, -23);
        Node node23 = new Node(24, -23);
        Node node24 = new Node(26, -23);
        Node node25 = new Node(1, -20);
        Node node26 = new Node(6, -20);
        Node node27 = new Node(9, -20);
        Node node28 = new Node(12, -20);
        Node node29 = new Node(15, -20);
        Node node30 = new Node(18, -20); 
        Node node31 = new Node(21, -20);
        Node node32 = new Node(26, -20);
        Node node33 = new Node(6, -17);
        Node node34 = new Node(9, -17);
        Node node35 = new Node(18, -17);
        Node node36 = new Node(21, -17);
        Node node37 = new Node(1, -14);
        Node node38 = new Node(6, -14);
        Node node39 = new Node(9, -14);
        Node node40 = new Node(18, -14);
        Node node41 = new Node(21, -14);
        Node node42 = new Node(26, -14);
        Node node43 = new Node(6, -11);
        Node node44 = new Node(9, -11);
        Node node45 = new Node(12, -11);
        Node node46 = new Node(15, -11);
        Node node47 = new Node(18, -11);
        Node node48 = new Node(21, -11);
        Node node49 = new Node(1, -8);
        Node node50 = new Node(6, -8);
        Node node51 = new Node(9, -8);
        Node node52 = new Node(12, -8);
        Node node53 = new Node(15, -8);
        Node node54 = new Node(18, -8);
        Node node55 = new Node(21, -8);
        Node node56 = new Node(26, -8);
        Node node57 = new Node(1, -5);
        Node node58 = new Node(6, -5);
        Node node59 = new Node(9, -5);
        Node node60 = new Node(12, -5);
        Node node61 = new Node(15, -5);
        Node node62 = new Node(18, -5);
        Node node63 = new Node(21, -5);
        Node node64 = new Node(26, -5);
        Node node65 = new Node(1, -1);
        Node node66 = new Node(6, -1);
        Node node67 = new Node(12, -1);
        Node node68 = new Node(15, -1);
        Node node69 = new Node(21, -1);
        Node node70 = new Node(26, -1);

        //Node 1 connections
        graph.AddConnection(node1, node2);
        graph.AddConnection(node1, node5);

        //Node 2 connections
        graph.AddConnection(node2, node3);
        graph.AddConnection(node2, node9);

        //node 3 connections
        graph.AddConnection(node3, node4);
        graph.AddConnection(node3, node10);

        //node 4 connections
        graph.AddConnection(node4, node14);

        //node 5 connections
        graph.AddConnection(node5, node6);

        //node 6 connections
        graph.AddConnection(node6, node7);
        graph.AddConnection(node6, node16);

        //node 7 connections
        graph.AddConnection(node7, node17);

        //node 8 connections
        graph.AddConnection(node8, node9);
        graph.AddConnection(node8, node18);

        //node 9 connections (done from previous connections)

        //node 10 connections
        graph.AddConnection(node10, node11);

        //node 11 connections
        graph.AddConnection(node11, node21);

        //node 12 connections
        graph.AddConnection(node12, node13);
        graph.AddConnection(node12, node22);

        //node 13 connections
        graph.AddConnection(node13, node14);
        graph.AddConnection(node13, node23);

        //node 14 connections (done from previous connections)

        //node 15 connections
        graph.AddConnection(node15, node16);
        graph.AddConnection(node15, node25);

        //node 16 connections (done)

        //node 17 connections
        graph.AddConnection(node17, node18);
        graph.AddConnection(node17, node26);

        //node 18 connections
        graph.AddConnection(node18, node19);

        //node 19 connections
        graph.AddConnection(node19, node20);
        graph.AddConnection(node19, node28);

        //node 20 connections
        graph.AddConnection(node20, node29);
        graph.AddConnection(node20, node21);

        //node 21 connections
        graph.AddConnection(node21, node22);

        //node 22 connections
        graph.AddConnection(node22, node31);

        //node 23 connections
        graph.AddConnection(node23, node24);

        //node 24 connections
        graph.AddConnection(node24, node32);

        //node 25 connections
        graph.AddConnection(node25, node26);

        //node 26 connections
        graph.AddConnection(node26, node27);
        graph.AddConnection(node26, node38);

        //node 27 connections
        graph.AddConnection(node27, node28);
        graph.AddConnection(node27, node34);

        //node28 connections (done)

        //node 29 connections
        graph.AddConnection(node29, node30);

        //node 30 connections
        graph.AddConnection(node30, node31);
        graph.AddConnection(node30, node35);

        //node 31 connections
        graph.AddConnection(node31, node32);
        graph.AddConnection(node31, node41);

        //node 32 connections (done)

        //node 33 connecions
        graph.AddConnection(node33, node38);

        //node 34 connections
        graph.AddConnection(node34, node35);
        graph.AddConnection(node34, node39);

        //node 35 connections
        graph.AddConnection(node35, node40);

        //node 36 connections
        graph.AddConnection(node36, node41);

        //node 37 connections
        graph.AddConnection(node37, node38);

        //node 38 connections
        graph.AddConnection(node38, node39);
        graph.AddConnection(node38, node50);

        //node 39 connections
        graph.AddConnection(node39, node44);

        //node 40 connections
        graph.AddConnection(node40, node41);
        graph.AddConnection(node40, node47);

        //node 41 connections
        graph.AddConnection(node41, node42);
        graph.AddConnection(node41, node55);

        //node42 connection (done)

        //node 43 connections (node 43 shouldnt be a node)

        //node 44 connections
        graph.AddConnection(node44, node45);

        //node 45 connections
        graph.AddConnection(node45, node46);
        graph.AddConnection(node45, node52);

        //node 46 connections
        graph.AddConnection(node46, node47);
        graph.AddConnection(node46, node53);

        //node 47 connections (done)

        //node 48 connections (node 48 shouldnt be a node)

        //node 49 connections
        graph.AddConnection(node49, node50);
        graph.AddConnection(node49, node57);

        // node 50 connections
        graph.AddConnection(node50, node58);

        // node 51 connections
        graph.AddConnection(node51, node52);
        graph.AddConnection(node51, node59);

        //node 52 connections (done)

        //node 53 connections
        graph.AddConnection(node53, node54);

        //node 54 connections 
        graph.AddConnection(node54, node62);

        //node 55 connections
        graph.AddConnection(node55, node56);
        graph.AddConnection(node55, node63);

        //node 56 connections
        graph.AddConnection(node56, node64);

        //node 57 connections
        graph.AddConnection(node57, node58);
        graph.AddConnection(node57, node65);

        //node 58 connections
        graph.AddConnection(node58, node59);
        graph.AddConnection(node58, node66);

        //node 59 connections
        graph.AddConnection(node59, node60);

        //node 60 connections
        graph.AddConnection(node60, node61);
        graph.AddConnection(node60, node67);

        //node 61 connections
        graph.AddConnection(node61, node62);
        graph.AddConnection(node61, node68);

        //node 62 connections
        graph.AddConnection(node62, node63);

        //node 63 connections
        graph.AddConnection(node63, node64);
        graph.AddConnection(node63, node69);

        //node 64 connections
        graph.AddConnection(node64, node70);

        //node 65 connections
        graph.AddConnection(node65, node66);

        //node 66 connections
        graph.AddConnection(node66, node67);

        //node 67  connections(done)

        //node 68 connections
        graph.AddConnection(node68, node69);

        //node 69  connections
        graph.AddConnection(node69, node70);

        //node 70 connections (done)

   



    }
	
	// Update is called once per frame
	void Update () {

		switch (_dir) {
		case Direction.still:
			direc = none;
			break;
		case Direction.down:
			animator.SetInteger ("Direction", 2);
			direc = down;
			break;
		case Direction.up:
			animator.SetInteger ("Direction", 0);
			direc = up;
			break;
		case Direction.left:
			animator.SetInteger ("Direction", 3);
			direc = left;
			break;
		case Direction.right:
			animator.SetInteger ("Direction", 1);
			direc = right;
			break;

		}

		move (direc);

	}

	public void move(Vector2 direc){
		if (checkDirectionClear (direc)) {
			if (direc.x != 0) {
				transform.position = new Vector3 (transform.position.x, Mathf.Round (transform.position.y), transform.position.z);
			}
			if (direc.y != 0) {
				transform.position = new Vector3 (Mathf.Round (transform.position.x), transform.position.y, transform.position.z);
			}
			transform.position = new Vector3 (transform.position.x + direc.x * MSpeed * Time.deltaTime, transform.position.y + direc.y * MSpeed * Time.deltaTime, transform.position.z);
	
		} else {
			_dir = Direction.still;
		}
	}

	public bool checkDirectionClear(Vector2 direction){
		int y =-1 * Mathf.RoundToInt( transform.position.y);
		int x = Mathf.RoundToInt (transform.position.x);



		if (direction.x == 0 && direction.y == 1) {
			y =-1 * Mathf.FloorToInt( transform.position.y);
			if(Map[y-1][x] == '-'|| Map[y-1][x]  == '#'){
				return false;
			}
		} else if(direction.x == 1 && direction.y == 0){
			if (x == Map [0].Length - 1) {
				transform.position = new Vector3 (1, transform.position.y, transform.position.z);
			}

			x = Mathf.FloorToInt (transform.position.x);
			if(Map[y][x+1] == '-' || Map[y][x+1] == '#'){
				return false;
			}
		} else if(direction.x == 0 && direction.y == -1){
			y =-1 * Mathf.CeilToInt( transform.position.y);
			if(Map[y+1][x] == '-'|| Map[y+1][x] == '#'){
				return false;
			}
		} else if(direction.x == -1 && direction.y == 0){
			if (x == 0) {
				transform.position = new Vector3 (Map [0].Length - 2, transform.position.y, transform.position.z);
			}

			x = Mathf.CeilToInt (transform.position.x);
			if(Map[y][x-1] == '-'|| Map[y][x-1] == '#'){
				return false;
			}
		}
		return true;
	}

    public bool HasVector(int y, int x,ArrayList vectors)
    {
        for (int i=0; i < vectors.Count; i++)
        {
            Vector2 vector = (Vector2) vectors[i];
            if(vector.x == y && vector.y == x)
            {
                return true;
            }

        }
        return false;
    }

    //Attempt pathfinding using dijkstras
    public Direction pathFind(Transform ghostTransform, float pacmanX, float pacmanY)
    {

        //Get the closest node to the ghost this is the start node for Djikstras
        float min_distance = float.MaxValue;
        Node start_node = null;
        Node current_node = null;
        for (int i = 0; i < graph.nodes.Count; i++)
        {
            if (Mathf.Sqrt(Mathf.Pow(((Node)graph.nodes[i]).positionX - pacmanX, 2) + Mathf.Pow(((Node)graph.nodes[i]).positionY - pacmanY, 2)) < min_distance)
            {
                min_distance = Mathf.Sqrt(Mathf.Pow(((Node)graph.nodes[i]).positionX - pacmanX, 2) + Mathf.Pow(((Node)graph.nodes[i]).positionY - pacmanY, 2));
                current_node = (Node)graph.nodes[i];
                start_node = (Node)graph.nodes[i];
            }

        }

        // Make the distance of every node infinity
        for (int i =0; i < graph.nodes.Count; i++)
        {
            ((Node) graph.nodes[i]).distance = float.MaxValue;
            ((Node)graph.nodes[i]).processed = false;
            
        }

        // Do it for the first node
        current_node.distance = 0;
        for(int i = 0; i < current_node.children.Count; i++)
        {
            float temp_distance = getDistance((Node)current_node.children[i], current_node);
            if(temp_distance < ((Node)current_node.children[i]).distance)
            {
                ((Node)current_node.children[i]).distance = temp_distance + current_node.distance;
            }
        }
        current_node.processed = true;

        // Get next node
        min_distance = float.MaxValue;
        current_node = null;
        for (int i = 0; i < graph.nodes.Count; i++)
        {
            if (((Node)graph.nodes[i]).distance < min_distance)
            {
                min_distance = ((Node)graph.nodes[i]).distance;
                current_node = (Node)graph.nodes[i];
            }
                
        }

        //Repeat the process for every node
        while (current_node!=null)
        {
            for (int i = 0; i < current_node.children.Count; i++)
            {
                float temp_distance = getDistance((Node)current_node.children[i], current_node);
                if (temp_distance < ((Node)current_node.children[i]).distance)
                {
                    ((Node)current_node.children[i]).distance = temp_distance + current_node.distance;
                }
            }
            current_node.processed = true;

            // Get next node
            min_distance = float.MaxValue;
            current_node = null;
            for (int i = 0; i < graph.nodes.Count; i++)
            {
                if (((Node)graph.nodes[i]).distance < min_distance && ((Node)graph.nodes[i]).processed == false)
                {
                    min_distance = ((Node)graph.nodes[i]).distance;
                    current_node = (Node)graph.nodes[i];
                }

            }
        }

        //After calculating distance find closest node to pacman
        min_distance = float.MaxValue;
        current_node = null;
        for (int i = 0; i < graph.nodes.Count; i++)
        {
            if (Mathf.Sqrt(Mathf.Pow(((Node)graph.nodes[i]).positionX - ghostTransform.position.x, 2) + Mathf.Pow(((Node)graph.nodes[i]).positionY - ghostTransform.position.y, 2)) < min_distance)
            {
                min_distance = Mathf.Sqrt(Mathf.Pow(((Node)graph.nodes[i]).positionX - ghostTransform.position.x, 2) + Mathf.Pow(((Node)graph.nodes[i]).positionY - ghostTransform.position.y, 2));
                current_node = (Node)graph.nodes[i];
            }

        }


        //return direction relative to path
        Node next_node = null;
        min_distance = float.MaxValue;
        for (int i = 0; i < current_node.children.Count; i++)
        {
            if(((Node)current_node.children[i]).distance < min_distance)
            {
                min_distance = ((Node)current_node.children[i]).distance;
                next_node = (Node)current_node.children[i];
            }
        }


        if (next_node.positionY > current_node.positionY)
        {
            return Direction.up;
        }
        if (next_node.positionX < current_node.positionX)
        {
            return Direction.left;
        }
        if(next_node.positionX > current_node.positionX)
        {
            return Direction.right;
        }
        if (next_node.positionY < current_node.positionY)
        {
            return Direction.down;
        }
        
        return Direction.still;
    }

    public float getDistance(Node node1, Node node2)
    {
        return Mathf.Sqrt(Mathf.Pow(node1.positionX - node2.positionX, 2) + Mathf.Pow(node1.positionY - node2.positionY, 2));
    }



 
}

public class Graph
{
    public ArrayList nodes;

    public Graph()
    {
        this.nodes = new ArrayList();
    }

    public void AddNode(Node node)
    {
        nodes.Add(node);
    }

    public void AddConnection(Node node1, Node node2)
    {
        if (!nodes.Contains(node1))
        {
            nodes.Add(node1);
        }
        if (!nodes.Contains(node2))
        {
            nodes.Add(node2);
        }
        node1.AddChild(node2);
        node2.AddChild(node1);
    }

    public bool onNode(Transform ghost)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            if(Mathf.Abs(ghost.transform.position.x - ((Node)nodes[i]).positionX) < 0.1 && Mathf.Abs(ghost.transform.position.y - ((Node)nodes[i]).positionY) < 0.1)
            {
                return true;
            }

        }
        return false;
    }

}

public class Node
{
    public float positionX;
    public float positionY;
    public float distance;
    public bool processed;
    public ArrayList children;
    public Node(float positionx, float positiony)
    {
        this.positionX = positionx;
        this.positionY = positiony;
        this.children = new ArrayList();
    }

    public void AddChild(Node child)
    {
        children.Add(child);
    }
}
