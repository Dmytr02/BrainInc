Shader "Custom/RotatedIntersection"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" {}
        _IntersectTex ("Intersection Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _IntersectTex;
            float4x4 _SecondWorldMatrix;
            float4 _MainTex_ST;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 worldPos : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 worldXY = i.worldPos.xy;
                float2 localPos = mul(_SecondWorldMatrix, float4(worldXY, 0, 1)).xy;

                bool inIntersection = abs(localPos.x) <= 0.5 && abs(localPos.y) <= 0.5;


                return inIntersection ? tex2D(_IntersectTex, i.uv) : tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}