using UnityEngine;

[ExecuteInEditMode]
public class CrownManager : MonoBehaviour
{
    CrownLight crown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindCrown();
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_CrownPos",crown.position);
        Shader.SetGlobalFloat("_CrownRadius",crown.radius);
    }

    void FindCrown()
    {
        crown = FindAnyObjectByType<CrownLight>();
    }
}
