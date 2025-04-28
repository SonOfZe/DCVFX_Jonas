using UnityEngine;

[ExecuteInEditMode]
public class CrownLight : MonoBehaviour
{

    public float radius;
    [HideInInspector] public Vector3 position;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
    }

    public void UpdateRange(float v)
    {
        radius = v;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.white;
        Gizmos.color = Color.blue;

        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, radius);
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.right, radius);
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);


    }

#endif
}
