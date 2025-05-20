#ifndef CUSTOM_LIGHTNING_INCLUDED
#define CUSTOM_LIGHTNING_INCLUDED
#define _SPECULAR_COLOR
#pragma multi_compile
#pragma shader_feature _FORWARD_PLUS
#pragma shader_feature_fragment _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
#pragma shader_feature_fragment _ADDITIONAL_LIGHT_SHADOWS _ADDITIONAL_LIGHT_SHADOWS_CASCADE
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

#ifndef SHADERGRAPH_PREVIEW
	#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
	#if (SHADERPASS != SHADERPASS_FORWARD)
		#undef REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR
	#endif
#endif



void CalculateCustomLighting_float(float3 WorldPos, float3 Normal, float3 Albedo, float3 ViewDirection, float Smoothness, out float3 Color) {


	InputData lighting = (InputData)0;
	lighting.positionWS = WorldPos;
	lighting.normalWS = Normal;
	lighting.viewDirectionWS = ViewDirection;
	lighting.shadowCoord = TransformWorldToShadowCoord(WorldPos);

	SurfaceData surface = (SurfaceData)0;
	surface.albedo = Albedo;
	surface.alpha = 1;
	surface.smoothness = Smoothness;
	surface.specular = 1;

	Color = UniversalFragmentBlinnPhong(lighting, surface) + unity_AmbientSky;

}

#endif