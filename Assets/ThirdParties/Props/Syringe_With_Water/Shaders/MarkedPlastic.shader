Shader "Syringe/Marked Plastic URP" {
 Properties { _BaseMap("Color and opacity",2D)="white"{} _BaseColor("Tint",Color)=(1,1,1,1) _MetallicGlossMap("Metallic / smoothness",2D)="black"{} }
 SubShader {
  Tags { "RenderPipeline"="UniversalPipeline" "Queue"="Transparent+4" "RenderType"="Transparent" }
  Pass {
   Tags { "LightMode"="UniversalForward" }
   Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Back
   HLSLPROGRAM
   #pragma vertex Vert
   #pragma fragment Frag
   #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
   #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
   TEXTURE2D(_BaseMap);SAMPLER(sampler_BaseMap);TEXTURE2D(_MetallicGlossMap);SAMPLER(sampler_MetallicGlossMap);
   CBUFFER_START(UnityPerMaterial)
   float4 _BaseMap_ST;half4 _BaseColor;
   CBUFFER_END
   struct A {float4 p:POSITION;float3 n:NORMAL;float2 uv:TEXCOORD0;};
   struct V {float4 p:SV_POSITION;float3 w:TEXCOORD0;half3 n:TEXCOORD1;float2 uv:TEXCOORD2;};
   V Vert(A a){V o;o.w=TransformObjectToWorld(a.p.xyz);o.p=TransformWorldToHClip(o.w);o.n=TransformObjectToWorldNormal(a.n);o.uv=TRANSFORM_TEX(a.uv,_BaseMap);return o;}
   half4 Frag(V i):SV_Target {half4 c=SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,i.uv)*_BaseColor;half ink=saturate((c.a-.16h)/.36h);c.rgb=_BaseColor.rgb*pow(1-ink,2.2h);c.a=lerp(.16h,1.0h,ink)*_BaseColor.a;half s=SAMPLE_TEXTURE2D(_MetallicGlossMap,sampler_MetallicGlossMap,i.uv).a;Light l=GetMainLight();half3 n=normalize(i.n);half diffuse=.45+.55*saturate(dot(n,l.direction));half3 v=normalize(GetWorldSpaceViewDir(i.w));half spec=pow(saturate(dot(reflect(-l.direction,n),v)),lerp(16,96,s))*.18*(1-c.a);return half4(c.rgb*diffuse+spec*l.color,c.a);}
   ENDHLSL
  }
 }
}
