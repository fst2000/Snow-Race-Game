Shader "Unlit/PineHeightShader"
{
    Properties
    {
        _UpTex ("Up Texture", 2D) = "white" {}
        _DownTex ("Down Texture", 2D) = "white" {}
        _Height ("Height", Float) = 5
        _BlendStart ("Blend Start", Float) = 3
        _BlendLength ("Blend Length", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float textureBlend : TEXCOORD2;
            };

            sampler2D _UpTex;
            sampler2D _DownTex;
            float _Height;
            float _BlendStart;
            float _BlendLength;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.textureBlend = clamp((v.vertex.z * _BlendLength + _BlendStart), 0, 1);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 upCol = tex2D(_UpTex, i.uv);
                fixed4 downCol = tex2D(_DownTex, i.uv);
                fixed4 col = lerp(downCol,upCol,i.textureBlend);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
