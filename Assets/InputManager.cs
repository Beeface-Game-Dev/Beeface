using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.AI;

//This Script handles basic user input. It should be attached to the player object
public class InputManager : MonoBehaviour
{
    public ActionList AL; //ActionList Reference

    public static List<ObjectInfo> selectedObjects = new List<ObjectInfo>(); //Currently selected objects
    public static List<ObjectInfo> Objectehold = new List<ObjectInfo>();

    public int populations;

    public Canvas canvas; //canvas reference

    public GameObject PauseMenu;
    public GameObject SaveFilePanel;
    // public PauseMenu menu
    public Image selectionBox; //Selection box

    [SerializeField] LayerMask mask; //The layer we want our Raycast to hit

    public bool hasPrimary; //Does the player have a primary selected object?
    public bool canClickGround = true;

    public CanvasGroup UnitPanel; //The unit information panel

    public GameObject primaryObject; //The primary selected game object

    public ObjectInfo selectedInfo; //The primary object's information
                                    // public ObjectInfo selectedInfoc;
    public ObjectInfo Objectshold;

    private GameObject[] units; //An array of units

    private Vector3 startPos; //Box start position

    private BoxCollider worldCollider; //Collider for the selection box

    private RectTransform RT; //Transform for the box selector

    private bool isSelecting; //Is the player selecting?

    public bool paused = false;
    public NavMeshAgent navA;
    //public Rigidbody beefaces;
    int count = 0;
    int popneg = 0;
    public float foods;
    public int popcap;
    public int maxfoods;
    public int maxmushroom;

    public Text objctiv1;
    public Text objctiv2;
    public Text objctiv3;
    public int wirmps;
    public int wirmk;
    GameObject[] selct;

    ResourceManager RM = new ResourceManager();

    public List<GameObject> Colonistlist = new List<GameObject>(); // using colonist(3)
    public GameObject Colonist;
    public GameObject wirm;
    private static InputManager manInstance = null;

    public static InputManager Instance
    {
        get
        {
            if (manInstance == null)
            {
                manInstance = (InputManager)FindObjectOfType(typeof(InputManager));
            }
            return manInstance;
        }
    }

    //Called before start
    void Awake()
    {
        //Retrieves the canvas reference
        if (canvas == null)
        {
            canvas = FindObjectOfType<Canvas>();
        }

        //Creates the selection box
        if (selectionBox != null)
        {
            RT = selectionBox.GetComponent<RectTransform>();
            RT.pivot = Vector2.one * .5f;
            RT.anchorMin = Vector2.one * .5f;
            RT.anchorMax = Vector2.one * .5f;
            selectionBox.gameObject.SetActive(false);
        }
        RM = GameObject.Find("Player").GetComponent<ResourceManager>();
        foods = gameObject.GetComponent<ResourceManager>().food;
    }

    private void Start()
    {
        AL = GetComponent<ActionList>(); //Retrieves the ActionList reference
        PauseMenu.gameObject.SetActive(false);

        populations = 3;
        RM.population = populations;
        popcap = 20;
        maxfoods = 1000;
        maxmushroom = 100;
    //Colonist = GetComponent<Colonist>();
    }
    void BtnSelectall()
    { 
        
    }
     // Update is called once per frame
    void Update()
    {
        hasPrimary = primaryObject; //If there is a primary object, hasPrimary is true

        if (primaryObject != null) //Is there a primary object?
        {
            UnitPanel.alpha = 1; //Sets the unit panel to be visible
            UnitPanel.blocksRaycasts = true; //Sets the unit panel to block raycasts
            UnitPanel.interactable = true; //Sets the unit panel to be interactable
            //Debug.Log("blockraycast true");
        }
        else
        {
            UnitPanel.alpha = 0; //Sets the unit panel to be invisible
            UnitPanel.blocksRaycasts = false; //Sets the unit panel to not block raycasts
            UnitPanel.interactable = false; //Sets the unit panel to be not interactable
                                            // Debug.Log("blockraycast false");
        }

        //Did the player left click while being able to click the ground and while the move button is not active?
        if (Input.GetMouseButtonDown(0) && canClickGround && !AL.moveButtonActive)
        {
            /*block colonist from selectable and use button to make them gather 
             *set number of gatherrs and resources
            */
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Did the raycast hit something?
            if (Physics.Raycast(ray, out hit))
            {
                ObjectInfo OI = hit.collider.GetComponent<ObjectInfo>();
                //Is there anything currently selected?
                if (OI != null)
                {
                    //Is the player holding left shift?
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        UpdateSelection(OI, !OI.isSelected); //Add the clicked object to selected units
                        Debug.Log("shift selected " + OI);
                        Objectshold = OI;
                    }
                    else
                    {
                        //Replace selected units with the clicked object
                        ClearSelected();
                        UpdateSelection(OI, true);
                        Debug.Log("selected " + OI);
                        Objectshold = OI;
                    }
                }
                if (hit.collider.tag == "Ground")
                {
                    UpdateSelection(Objectshold, false);
                    ClearSelected();
                    // Debug.Log("selected false OH "+ Objectshold);
                }
            }
            startPos = Input.mousePosition; //Set the start position
            isSelecting = true; //The player is now selecting
        }
        if(foods >= 5)
        {
            objctiv2.text = "* foods collected";
            objctiv2.color = Color.green;
        }

        //Did the player release the left mouse button?
        /*if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;
            Debug.Log("realease click iselect " + isSelecting);
        }*/

        //Toggle the selection box based on if the player is selecting
        selectionBox.gameObject.SetActive(isSelecting);


        //Is the player selecting?
        /*if (isSelecting)
        {
            //Define new bounds based on current selection box
            Bounds bounds = new Bounds();
            bounds.center = Vector3.Lerp(startPos, Input.mousePosition, 0.5f);
            bounds.size = new Vector3(Mathf.Abs(startPos.x - Input.mousePosition.x), Mathf.Abs(startPos.y - Input.mousePosition.y), 0);

            //Adjust the selection bos image to match the bounds
            RT.position = bounds.center;
            RT.sizeDelta = canvas.transform.InverseTransformVector(bounds.size);

            //For each selectable object
            foreach (ObjectInfo selectable in selectedObjects)
            {
                //If it's a unit owned by the player
                if (selectable.isUnit && selectable.isPlayerObject)
                {
                    Vector3 screenPos = Camera.main.WorldToScreenPoint(selectable.transform.position); //Get the unit's position on the screen
                    screenPos.z = 0; //Set the screen position z to 0
                    UpdateSelection(selectable, (bounds.Contains(screenPos))); //Update selection based on if the selected object is inside selection box bounds
                }
            }
              //Debug.Log("werk2");
        }*/
        wirmps = GameObject.FindGameObjectsWithTag("enemywirm").Length;
        wirmk = GameObject.FindGameObjectsWithTag("WirmKing").Length;
        if (wirmps == 0 && wirmk == 0)
        {
            objctiv3.text = "* Worms are defeated";
            objctiv3.color = Color.green;
        }
        if (Input.GetKeyDown("*"))
        {
            //Colonist.GetComponent<NavMeshAgent>().enable = false;
            //Debug.Log("colonist " + Colonist);
            // Rigidbody beefaces;
            // GameObject beeface = PrefabUtility.InstantiatePrefab(Colonist as GameObject) as GameObject;
            Vector3 cor = new Vector3();
            cor = GameObject.Find("queenbee").transform.position;
            float x;
            float y;
            float z;
            x = GameObject.Find("queenbee").transform.position.x;
            y = GameObject.Find("queenbee").transform.position.y;
            z = GameObject.Find("queenbee").transform.position.z;
            Debug.Log("x " + x + " y " + y + " z " + z);

            Vector3 pos = new Vector3(x - 30, y, z);
            Colonist.SetActive(true);
            Instantiate(InputManager.Instance.Colonist);
            GameObject beeface = Instantiate(Colonist, pos, transform.rotation) as GameObject;
            Colonistlist.Add(beeface);

            // GameObject loc;
            /* if (Colonistlist != null)
             {
                 beeface.transform.position = new Vector3(200, -48, 180);
             }*/
            /* navA = GetComponent<NavMeshAgent>();

            if (navA.enabled && !navA.isOnNavMesh)
            {
                var position = transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(position, out hit, 10.0f, NavMesh.AllAreas);
                position = hit.position; // usually this barely changes, if at all
                navA.Warp(position);
            }*/
            // loc.position = new Vector3(200, -48, 180);
            //NavMeshAgent.Warp(loc);
            //beeface.transform.rotation = new Vector3();   

            /* NavMeshAgent agent = GetComponent("NavMeshAgent") as NavMeshAgent;
             NavMeshHit closestHit;
             if (NavMesh.SamplePosition(transform.position, out closestHit, 100f, NavMesh.AllAreas))
             {
                 transform.position = closestHit.position;
                 agent.enabled = true;
             }*/

            /* NavMeshHit closestHit;
             if (NavMesh.SamplePosition(gameObject.transform.position, out closestHit, 500f, NavMesh.AllAreas))
             { gameObject.transform.position = closestHit.position; }
             else
             {  Debug.LogError("Could not find position on NavMesh!");
                                                                          }*/
            // clone = Instantiate(beeface, transform.position, transform.rotation);
        } 
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("eas");
            if (paused == false)
            {
                Debug.Log("pause T");
                Time.timeScale = 0f;
                PauseMenu.gameObject.SetActive(true);
                SaveFilePanel.gameObject.SetActive(false);
                paused = true;
            }
            else   //if(paused == true)
            {
                Debug.Log("pause F");
                Time.timeScale = 1f;
                PauseMenu.gameObject.SetActive(false);
                paused = false;
            }
            Debug.Log("ps " + paused);
        }
        /* if(Input.GetButtonDown("Resume"))
         {
             Debug.Log("pause F");
             Time.timeScale = 1f;
             PauseMenu.gameObject.SetActive(false);
             paused = false;
         }*/

        //VOORBEELD CODE VIR PAUSE MENU
        /*   public class Pause : MonoBehaviour
         {

          public GameObject Canvas;
          public GameObject Camera;
          bool Paused = false;

          void Start()
          {
              Canvas.gameObject.SetActive(false);
          }

          void Update()
          {
              if (Input.GetKey("escape"))
              {
                  if (Paused == true)
                  {
                      Time.timeScale = 1.0f;
                      Canvas.gameObject.SetActive(false);
                      Screen.showCursor = false;
                      Screen.lockCursor = true;
                      Camera.audio.Play();
                      Paused = false;
                  }
                  else
                  {
                      Time.timeScale = 0.0f;
                      Canvas.gameObject.SetActive(true);
                      Screen.showCursor = true;
                      Screen.lockCursor = false;
                      Camera.audio.Pause();
                      Paused = true;
                  }
              }
          }
          public void Resume()
          {
              Time.timeScale = 1.0f;
              Canvas.gameObject.SetActive(false);
              Screen.showCursor = false;
              Screen.lockCursor = true;
              Camera.audio.Play();
          }*/
    }
    public void BtnSave(ResourceManager RM)
    {
        Debug.Log("****saved****jggj");
        Save.SaveF(RM);
        Debug.Log("****saved****");
    }
    public void BtnLoad()
    {
        //Save.Load();
        Debug.Log("****loaded****");
    }
    public void BTNbuildstorage()
    {
        foods = gameObject.GetComponent<ResourceManager>().food;
        if(foods >= 1000)
        {
            popcap = popcap + 10;
            foods = 0;
            maxfoods = maxfoods + 500;
            maxmushroom = maxmushroom + 50;
            Debug.Log("popcap "+popcap + " foods "+ foods + " maxfood "+maxfoods);
            objctiv1.text = "* Hive upgraded";
            objctiv1.color = Color.green;
            WormSpawn();
        }
    }
    public void BtnSpawn()
    {
        foods = gameObject.GetComponent<ResourceManager>().food;
        if (foods >= 10)
        {
            if (populations <= popcap)
            {
                Vector3 cor = new Vector3();
                cor = GameObject.Find("queenbee").transform.position;
                float x;
                float y;
                float z;
                x = GameObject.Find("queenbee").transform.position.x;
                y = GameObject.Find("queenbee").transform.position.y;
                z = GameObject.Find("queenbee").transform.position.z;
                Debug.Log("x " + x + " y " + y + " z " + z);

                Vector3 pos = new Vector3(x - 30, y, z);
                Colonist.SetActive(true);
                Instantiate(InputManager.Instance.Colonist);
                GameObject beeface = Instantiate(Colonist, pos, transform.rotation) as GameObject;
                Colonistlist.Add(beeface);

                count = count + 1;
                populations = GameObject.FindGameObjectsWithTag("Selectable").Length;
                populations = populations - 1 - count;
                popneg = GameObject.Find("Colonist").gameObject.GetComponent<ObjectInfo>().populationneg;
                RM.population = populations;
                Debug.Log("pop " + populations + " c " + count);
                RM.food = RM.food - 10;
            }
        }
    }
        public void WormSpawn()
        {
              wirmk = GameObject.FindGameObjectsWithTag("WirmKing").Length;
            if (wirmk > 0)
            {
                Vector3 cor = new Vector3();
                cor = GameObject.Find("WormKing").transform.position;
                float x;
                float y;
                float z;
                x = GameObject.Find("WormKing").transform.position.x;
                y = GameObject.Find("WormKing").transform.position.y;
                z = GameObject.Find("WormKing").transform.position.z;
                Debug.Log("x " + x + " y " + y + " z " + z);

                Vector3 pos = new Vector3(x - 90, y+30, z);
                wirm.SetActive(true);
                Instantiate(InputManager.Instance.wirm);
                GameObject wirmface = Instantiate(wirm, pos, transform.rotation) as GameObject;
                // Colonistlist.Add(beeface);
            }
        }
    allButtons abtn = new allButtons();
    public void ObjectivePanel()
    {
        Debug.Log("panel objective");
        abtn.btnObjectiveAnim();
    }

    float telling;
    int beefaces;
    //Game GM = new Game();
    public void saveSpawn()
    {
        if (telling < populations)
        {
            Vector3 cor = new Vector3();
            cor = GameObject.Find("queenbee").transform.position;
            float x;
            float y;
            float z;
            x = GameObject.Find("queenbee").transform.position.x;
            y = GameObject.Find("queenbee").transform.position.y;
            z = GameObject.Find("queenbee").transform.position.z;
            Debug.Log("x " + x + " y " + y + " z " + z);

            Vector3 pos = new Vector3(x - 30, y, z);
            Colonist.SetActive(true);
            Instantiate(InputManager.Instance.Colonist);
            GameObject beeface = Instantiate(Colonist, pos, transform.rotation) as GameObject;
            Colonistlist.Add(beeface);

            telling = telling + 1;
        }
    }
    //Updates the current selection
    /* void Deselect(ObjectInfo selectedObject, bool value)
     {
         if (value == false)
         {
             Debug.Log("kak deselect");
             //Does the player have a primary selected object?
             //if (hasPrimary)
             // {
             //removes this object from the primary if applicable
             selectedObject.isPrimary = value;
             primaryObject = null;
             hasPrimary = value;
             AL.actions = null;
             //  Debug.Log("werk3");
             Debug.Log("updateselection value " + value);
             // }
         }
     }*/
    void UpdateSelection(ObjectInfo selectedObject, bool value)
    {
      //  Debug.Log("kiesvoorwerp " + selectedObject);
           //Does the selected object's selected value equal the passed in value?
         if (selectedObject.isSelected != value)
         {
              //Is the value false?
             if (value == false)
             {
                // Debug.Log("value");
                 //Does the player have a primary selected object?
                 //if (hasPrimary)
                 //{
                     //removes this object from the primary if applicable
                     selectedObject.isPrimary = value;
                     primaryObject = null;
                     hasPrimary = value;
                     AL.actions = null;
                    // Debug.Log("panel nulle ");
                 //}
             }
             else
             {
                 //Does the player not have a primary?
                 //if (!hasPrimary)
                 //{
                     //Assigns this object to be the primary object
                     selectedObject.isPrimary = value;
                     primaryObject = selectedObject.gameObject;
                     //Debug.Log("primere foorwerp " + primaryObject);
                     hasPrimary = value;
                     //selectedInfoc = primaryObject.GetComponent<ObjectInfo>();
                     selectedInfo = primaryObject.GetComponent<ObjectInfo>(); //Sets the selected info
                     //AL.actions = selectedInfoc.actions;
                     AL.actions = selectedInfo.actions;
                     selectedObject.isSelected = value; //Selects or deselects the object based on passed value
                    // Debug.Log("UpdateSelection !primary value " + value);
                 //}
             }
                selectedObject.isSelected = value; //Selects or deselects the object based on passed value
                //Debug.Log("val " + value);
         }
    }

    //Populates the list with selected objects
    List<ObjectInfo> GetSelected()
    {
       return new List<ObjectInfo>(selectedObjects.Where(x => x.isSelected));
       // return new List<ObjectInfo>(selectedObjects);
       // Debug.Log("die selected list ");{unreachable code vir debug}
    }

    //Clears the selected objects
    void ClearSelected()
    {
       // Debug.Log("select objct" + selectedObjects);
        selectedObjects.ForEach(x => x.isSelected = false);
        selectedObjects.ForEach(x => x.isPrimary = false);
       //Debug.Log("select objct" + selectedObjects.);
    }       

}
