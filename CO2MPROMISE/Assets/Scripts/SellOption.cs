using UnityEngine;

public class SellOption : MonoBehaviour {

    public LayerMask layerMask;
    public float zValue = 15;
    public AudioClip deleteSound;
    AudioSource deleteSource;
    public static GameObject soldBuilding;
    public static bool isSold =false;
    public float mouseZ;
    void Awake() 
    {
        deleteSource = GetComponent<AudioSource>();
    }
    void Update () {

        // 1. Test for mouse click
        if (Input.GetMouseButtonDown (1)) {
            
            // 2. get mouse position in world space
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Mathf.Clamp(zValue, 15,50)));
            Debug.DrawLine (Camera.main.transform.position, worldMousePosition, Color.red, 2f);

            //3. get direction vector from camera position to mouse position in world space
            Vector3 direction = worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;
            mouseZ = worldMousePosition.z;
            //4. cast a ray from the camera in the given direction
            if (Physics.Raycast (Camera.main.transform.position, direction, out hit, 1000f)) {
                
                Debug.DrawLine (Camera.main.transform.position, hit.point, Color.green, 0.5f);

                // 5. Destroy game object
                if (hit.collider.gameObject.tag == "Building") {
                    Destroy (hit.collider.gameObject);

                    soldBuilding=gameObject;
                    isSold=true;
                    ResourceManager.Instance.AddStandardC(30);
                     deleteSource.clip = deleteSound;
            deleteSource.PlayOneShot(deleteSource.clip);    
                    
               
                
            } else {
                Debug.DrawLine (Camera.main.transform.position, worldMousePosition, Color.red, 0.5f);
            }
        }
       isSold=false;
                   
    }
} }
