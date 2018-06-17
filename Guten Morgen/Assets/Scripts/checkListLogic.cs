using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkListLogic : MonoBehaviour
{
    public Animator animator;
    public Canvas crosshair;
    public GameObject checkmark;
    private List<task> tasks;
    private string[] taskDescriptions = { "Brush teeth", "Eat an apple", "This is an example", "What else is there really?", "Drink some sweet OJ", "How 'bout sum coffee", "Crumpets sound nice?", "*incoherent singing*" };
    public List<GameObject> listpoints;

    public struct task
    {
        public bool isDone;
        public string description;

        public task(bool done, string desc)
        {
            isDone = done;
            description = desc;
        }
    }

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        foreach (GameObject o in listpoints)
        {
            o.GetComponent<TextMesh>().text = "";
        }
        listpoints[0].GetComponent<TextMesh>().text = "Read Me!";
        instantiateTasks();
        crosshair.enabled = true;
        animator.Play("runaway");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        crosshair.enabled = false;
        Debug.Log("reached OnEnable with isCaught");
        task[] chosen = findTasks();
        for (int i = 0; i < 5; i++)
        {
            listpoints[i].GetComponent<TextMesh>().text = chosen[i].description;
        }
    }
    private void OnDisable()
    {
        crosshair.enabled = true;
    }

    private task[] findTasks()
    {
        task[] chosenTasks = new task[5];
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("This is i: " + i + ".");
            int next = (int)Random.Range(0.0f, (float)taskDescriptions.Length);
            Debug.Log("Next is: " + next + ".");
            chosenTasks[i] = tasks[next];
        }
        return chosenTasks;
    }

    private void instantiateTasks()
    {
        tasks = new List<task>();
        for (int i = 0; i < taskDescriptions.Length; i++)
        {
            Debug.Log("Instantiated task " + i + " with desc " + taskDescriptions[i]);
            tasks.Add(new task(false, taskDescriptions[i]));
        }
        foreach (task t in tasks)
        {
            Debug.Log("Desc:" + t.description + ", isDone = " + t.isDone);
        }
    }
}
