

void GetClosestLight_float(in float3 WorldPos, out float2 closestLight)
{
#ifdef SHADERGRAPH_PREVIEW
    closestLight = 1000;
#else
    float smallestDist=1000;
    for (int i = 0; i < 10; i++)
    {
        float dis = distance(_CrownLightPositions[i].xyz+ _CrownLightRadiuses[i], WorldPos);

        closestLight = lerp(_CrownLightPositions[i].xz, closestLight, step(dis, smallestDist));
        smallestDist = distance(closestLight, WorldPos);
    }

#endif
}