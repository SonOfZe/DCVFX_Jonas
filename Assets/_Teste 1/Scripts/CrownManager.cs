using UnityEngine;

[ExecuteInEditMode]
public class CrownManager : MonoBehaviour
{
    CrownLight[] crowns;

    Vector4[] positions = new Vector4[10];
    float[] radiuses = new float[10];

    [SerializeField] Color shadowColor;
    //[SerializeField] Color shadowParticleColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindCrowns();
    }

    private void OnEnable()
    {
        FindCrowns();
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalColor("_ShadowColor", shadowColor);
        //Shader.SetGlobalColor("_ShadowParticleColor", shadowParticleColor);

        Shader.SetGlobalVectorArray("_CrownLightPositions", positions);
        Shader.SetGlobalFloatArray("_CrownLightRadiuses", radiuses);

        for (int i = 0; i < crowns.Length; i++)
        {
            positions[i] = crowns[i].position;
            radiuses[i] = crowns[i].radius;
        }
    }

    void FindCrowns()
    {
        crowns = FindObjectsByType<CrownLight>(FindObjectsSortMode.None);
    }
}
