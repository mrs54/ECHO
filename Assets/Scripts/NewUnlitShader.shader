Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_LitTex("Lit Texture", 2D) = "white" {}
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
				float2 lit_uv : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _LitTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				float2 pixelcoords = ComputeScreenPos(o.vertex);
				o.lit_uv = ((o.vertex.xy / o.vertex.w) + 1)/2;
				o.lit_uv.y = 1 - o.lit_uv.y;

				
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 litcol = tex2D(_LitTex, i.lit_uv);
				fixed4 col = tex2D(_MainTex, i.uv);
				
				//return litcol;
				//litcol.rgb = 1 - litcol.rgb;
				//litcol.a = 1;
				return lerp(col,litcol,col.a);
				//return fixed4(i.lit_uv.x,i.lit_uv.y, 0, 1);
			}
			ENDCG
		}
	}
}
