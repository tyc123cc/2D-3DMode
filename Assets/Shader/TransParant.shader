
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/OutlineShader1"
{
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_OutLineWidth("width", float) = 1.2//定义一个变量
		_Color("Main Color",Color) = (0.6,0.6,0.6,1)
		_Color1("Main Color1",Color) = (0.6,0.6,0.6,1)
		_AlphaRange("Alpha Range",Range(0,1)) = 0
		_RimColor("Rim Color",Color) = (1,1,1,1)
		_RimColor1("Rim Color1",Color) = (1,1,1,1)
	}
		SubShader{
			Tags{"RenderType" = "Transparent" "Queue" = "Transparent" }
			LOD 200

			Pass
			{
				Tags{"LightMode" = "ForwardBase"}
				Cull back
				Blend SrcAlpha OneMinusSrcAlpha
				ZWrite OFF
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				struct appdata {
					float4 vertex:POSITION;
					float2 uv:TEXCOORD0;
					float3 normal : NORMAL;
				};

				struct v2f
				{
					float2 uv :TEXCOORD0;
					float4 vertex:SV_POSITION;
					float3 normalDir : Texcoord1;
					float3 worldPos : TEXCOORD2;
				};

				fixed4 _Color1;
				float _AlphaRange;
				fixed4 _RimColor1;
				float _OutLineWidth;//设置变量
				v2f vert(appdata v)
				{
					v2f o;
					//设置一下xy
					//v.vertex.xy *= 1.1;
					v.vertex.xy *= _OutLineWidth;//乘上变量
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					// 获取世界空间法线向量
					o.normalDir = mul(float4(v.normal, 0), unity_WorldToObject).xyz;
					// 获取世界坐标系顶点位置
					o.worldPos = mul(unity_ObjectToWorld, v.vertex);
					return o;
				}

				sampler2D _MainTex;

				fixed4 frag(v2f v) :SV_Target
				{
					// 法线标准化
				float3 normal = normalize(v.normalDir);
				// 视角方向标准化
				float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - v.worldPos.xyz);
				// 点积
				float NdotV = saturate(dot(normal,viewDir));
				// 漫反射
				fixed3 diffuse = NdotV * _Color1 + UNITY_LIGHTMODEL_AMBIENT.rgb;
				float alpha = 1 - NdotV;
				// 边缘色
				fixed3 rim = _RimColor1 * alpha;
				// 混合输出
				fixed4 col1 = fixed4(diffuse + rim ,alpha * (1 - _AlphaRange) + _AlphaRange);

					fixed4 col = tex2D(_MainTex, v.uv);
				return col1;
				//return fixed4(0, 0, 1, 1);
			}
			ENDCG
		}


		Pass
			{
				Tags{"LightMode" = "ForwardBase"}
				Cull back
				Blend SrcAlpha OneMinusSrcAlpha
				ZWrite OFF
				ZTest Always
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				struct appdata {
				float4 vertex:POSITION;
				float2 uv:TEXCOORD0;
				//float4 vertex : POSITION;
				float3 normal : NORMAL;
			};


			struct v2f
			{
				float2 uv :TEXCOORD0;
				float4 vertex:SV_POSITION;
				//float4 pos : SV_POSITION;
				float3 normalDir : Texcoord1;
				float3 worldPos : TEXCOORD2;
			};


			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				// 转化顶点位置
				//o.vertex = UnityObjectToClipPos(v.vertex);
				// 获取世界空间法线向量
				o.normalDir = mul(float4(v.normal, 0), unity_WorldToObject).xyz;
				// 获取世界坐标系顶点位置
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				return o;
			}
			sampler2D _MainTex;
			fixed4 _Color;
			float _AlphaRange;
			fixed4 _RimColor;

			fixed4 frag(v2f v) :SV_Target
			{
				// 法线标准化
				float3 normal = normalize(v.normalDir);
				// 视角方向标准化
				float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - v.worldPos.xyz);
				// 点积
				float NdotV = saturate(dot(normal,viewDir));
				// 漫反射
				fixed3 diffuse = NdotV * _Color + UNITY_LIGHTMODEL_AMBIENT.rgb;
				float alpha = 1 - NdotV;
				// 边缘色
				fixed3 rim = _RimColor * alpha;
				// 混合输出
				fixed4 col2 = fixed4(diffuse + rim ,alpha * (1 - _AlphaRange) + _AlphaRange);

				fixed4 col = tex2D(_MainTex, v.uv);
				//return fixed4(0, 0, 1, 1);//返回蓝色，因为再次渲染会把第一个颜色覆盖掉
				return col2;
			}
				ENDCG
			}
		}
			FallBack "Diffuse"
}
