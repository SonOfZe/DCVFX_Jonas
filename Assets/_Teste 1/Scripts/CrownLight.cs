using UnityEngine;
using UnityEngine.VFX;

[ExecuteInEditMode]
public class CrownLight : MonoBehaviour
{

    public float radius;
    float diameter;
    Vector3 scaleVector;
    [HideInInspector] public Vector3 position;

    [SerializeField] GameObject atmosphereGO;
    [SerializeField] VisualEffect vfx_atmosphere;
    [SerializeField] VisualEffect vfx_shadows;


    Transform atmosphereTr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaleVector = new Vector3(radius, radius, radius);
        atmosphereTr = atmosphereGO.transform;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        diameter = (radius * 2);
        scaleVector.x = diameter;
        scaleVector.y = diameter;
        scaleVector.z = diameter;
        atmosphereTr.localScale = scaleVector;

        vfx_shadows.SetFloat("Radius", radius);
        vfx_atmosphere.SetFloat("Radius", radius);
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
