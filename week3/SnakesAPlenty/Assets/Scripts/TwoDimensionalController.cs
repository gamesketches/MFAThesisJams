using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwoDimensionalController : MonoBehaviour
{
    public float speed = 3f;
    public float upTurnTime = 3.0f;
    public float leftTurnTime = 3.0f;
    public float downTurnTime = 3.0f;
    public float rightTurnTime = 3.0f;
    public KeyCode upKey;
    public KeyCode leftKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    Rigidbody2D _rigidBody;
    public float anglarSpeed = 90f; //degree per seconds
    List<int> inputStack;

    string debugStarter, debugEnder;

    public int player = 0;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = transform.up;
        inputStack = new List<int>();
        inputStack.Add(0);

        debugEnder = "</color>";
        if (player == 0)
        {
            debugStarter = "<color=red>";
        }
        else if (player == 1)
            debugStarter = "<color=purple>";
        else if (player == 2)
            debugStarter = "<color=yellow>";
        else if (player == 3)
            debugStarter = "<color=blue>";
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log (_rigidBody.velocity);


        Vector3 direction = Vector3.zero;
        int currentDirect = inputStack[inputStack.Count - 1];
        if (Input.GetKeyDown(leftKey))
        {
            if (currentDirect != 1)
            {
                Debug.Log(debugStarter + "player" + player + " add left!" + debugEnder);
                inputStack.Add(1);
            }
        }
        else if (Input.GetKeyDown(rightKey))
        {
            if (currentDirect != 2)
            {
                Debug.Log(debugStarter + "player" + player + " add right!" + debugEnder);
                inputStack.Add(2);
            }
        }
        else if (Input.GetKeyDown(upKey))
        {
            if (currentDirect != 3)
            {
                Debug.Log(debugStarter + "player" + player + " add up!" + debugEnder);
                inputStack.Add(3);
            }
        }
        else if (Input.GetKeyDown(downKey))
        {
            if (currentDirect != 4)
            {
                Debug.Log(debugStarter + "player" + player + " add down!" + debugEnder);
                inputStack.Add(4);
            }
        }

        while (inputStack.Count > 1)
        {
            currentDirect = inputStack[inputStack.Count - 1];
            if (currentDirect == 1)
            {
                if (!Input.GetKey(leftKey))
                    inputStack.RemoveAt(inputStack.Count - 1);
                else
                    break;
            }
            if (currentDirect == 2)
            {
                if (!Input.GetKey(rightKey))
                    inputStack.RemoveAt(inputStack.Count - 1);
                else
                    break;
            }
            if (currentDirect == 3)
            {
                if (!Input.GetKey(upKey))
                    inputStack.RemoveAt(inputStack.Count - 1);
                else
                    break;
            }
            if (currentDirect == 4)
            {
				if (!Input.GetKey(downKey))
                    inputStack.RemoveAt(inputStack.Count - 1);
                else
                    break;
            }

        }
        currentDirect = inputStack[inputStack.Count - 1];

        if (currentDirect == 0)
            direction = Vector2.zero;
        else if (currentDirect == 1 && leftTurnTime > 0){
            direction = Vector2.left;
            leftTurnTime -= Time.deltaTime;
            }
		else if (currentDirect == 2 && rightTurnTime > 0) {
            direction = Vector2.right;
            rightTurnTime -= Time.deltaTime;
            }
        else if (currentDirect == 3 && upTurnTime > 0) {
            direction = Vector2.up;
            upTurnTime -= Time.deltaTime;
            }
        else if (currentDirect == 4 && downTurnTime > 0) {
            direction = Vector2.down;
            downTurnTime -= Time.deltaTime;
            }

        _rigidBody.velocity = Quaternion.Euler(0f, 0f, isTurnLeft(_rigidBody.velocity, direction) * anglarSpeed * Time.deltaTime * 75f) * _rigidBody.velocity.normalized * speed;

    }

    private int isTurnLeft(Vector2 vec1, Vector2 vec2)
    {
        Vector3 _vec1 = vec1.normalized;
        Vector3 _vec2 = vec2.normalized;
        Vector3 _cross = Vector3.Cross(_vec1, _vec2);
        if (_cross.z > 0.01f)
            return 1;
        else if (_cross.z < -0.01f)
            return -1;
        else return 0;
    }
}
