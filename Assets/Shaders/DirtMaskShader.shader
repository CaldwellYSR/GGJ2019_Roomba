﻿Shader "Sprites/DirtMaskShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MaskTex ("Mask Texture", 2D) = "white" {}
        _MaskColor ("Mask Color", Color) = (1, 0, 0, 1)
        _AltMaskColor ("Alt Mask Color", Color) = (0, 0, 1, 1)
        _MaskReplace ("Mask Replace Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _MaskTex;
            sampler2D _MaskReplace;
            float4 _MaskColor;
            float4 _AltMaskColor;

            fixed4 frag (v2f i) : SV_Target
            {
                float4 albedo = tex2D(_MainTex, i.uv);
                float4 mask = tex2D(_MaskReplace, i.uv);

                float isMask = tex2D(_MaskTex, i.uv) == _MaskColor || tex2D(_MaskTex, i.uv) == _AltMaskColor;

                albedo = (1-isMask)*albedo + isMask*mask;

                float3 rgb = albedo.rgb;

                return fixed4(rgb, 1.0);
            }
            ENDCG
        }
    }
}
