float4 _CrownLightPositions[10];
float _CrownLightRadiuses[10];

void CalculateCrownLight_float(in float3 WorldPos, in float Power, out float value)
{
#ifdef SHADERGRAPH_PREVIEW
    value = 0;
#else
    for (int i = 0; i < 10; i++)
    {
        float dis = distance(_CrownLightPositions[i].xyz, WorldPos);
        dis = dis / _CrownLightRadiuses[i];
        dis = pow(dis, Power);
        dis = 1 - dis;
        dis = saturate(dis);
        value += dis;
    }

    value = saturate(value);
#endif
}