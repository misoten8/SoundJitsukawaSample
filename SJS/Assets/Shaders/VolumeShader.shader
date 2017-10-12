// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/VolumeShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("Base color", Color) = (1, 1, 1, 1)
		_Volume("Volume", Float) = 0.5
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		//Cull Front
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
				float4 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _Color;
			float  _Volume;

			v2f vert(appdata v)
			{
				v2f o;
				//v.vertex.xyz += normalize(v.normal.xyz);
				//v.vertex.w -= _Volume * 0.01;
				//v.vertex.w *= 1.5f;
				o.vertex = UnityObjectToClipPos(v.vertex *= 1.0f + _Volume * 0.01);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				return tex2D(_MainTex, i.uv);
				//return float4(_Color.xyz, 1.0);
			}
			ENDCG
		}
	}
}
