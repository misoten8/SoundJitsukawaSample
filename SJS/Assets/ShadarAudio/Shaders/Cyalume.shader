// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Cyalume" 
{
	Properties
	{
		_BaseColor("Base Color", Color) = (0.0, 1.0, 0.0)
		_MainTex("Base (RGB)", 2D) = "white" {}
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
		}

		Blend SrcAlpha One
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#define PI 3.14159

			#include "UnityCG.cginc"

			uniform float4 _BaseColor;
			uniform sampler2D _MainTex;

			struct v2f
			{
				float4 position : SV_POSITION;
				fixed4 color	: COLOR;
				float2 uv       : TEXCOORD0;
			};

			v2f vert(appdata_full v)
			{
				// Parameters given to fragment shader
				v2f o;
				o.position = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				o.color = v.color;
				return o;
			}

			fixed4 frag(v2f i) : COLOR
			{
				fixed4 tex = tex2D(_MainTex, i.uv);
				tex.rgb *= _BaseColor * i.color.rgb;
				//tex.a *= i.color.a;
				tex.a = 0.5;
				return tex;
			}
			ENDCG
		}
	}
	Fallback "VertexLit"
}