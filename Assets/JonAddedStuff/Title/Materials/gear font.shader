// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "gear font"
{
	Properties
	{
		_TX_Geartitle_D("TX_Geartitle_D", 2D) = "white" {}
		_TX_Geartitle_E("TX_Geartitle_E", 2D) = "white" {}
		_emissionintensity("emission intensity", Range( 0 , 50)) = 3
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _TX_Geartitle_D;
		uniform float4 _TX_Geartitle_D_ST;
		uniform sampler2D _TX_Geartitle_E;
		uniform float4 _TX_Geartitle_E_ST;
		uniform float _emissionintensity;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_TX_Geartitle_D = i.uv_texcoord * _TX_Geartitle_D_ST.xy + _TX_Geartitle_D_ST.zw;
			o.Albedo = tex2D( _TX_Geartitle_D, uv_TX_Geartitle_D ).rgb;
			float2 uv_TX_Geartitle_E = i.uv_texcoord * _TX_Geartitle_E_ST.xy + _TX_Geartitle_E_ST.zw;
			o.Emission = ( tex2D( _TX_Geartitle_E, uv_TX_Geartitle_E ) * _emissionintensity ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=14401
0;485;752;317;1029.53;-253.9532;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;5;-727.0889,458.0188;Float;False;Property;_emissionintensity;emission intensity;2;0;Create;True;3;0;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;3;-959.8862,227.9597;Float;True;Property;_TX_Geartitle_E;TX_Geartitle_E;1;0;Create;True;7bd3cf6875af9994aad8d7642e136113;7bd3cf6875af9994aad8d7642e136113;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;2;-597.9418,-44.72692;Float;True;Property;_TX_Geartitle_D;TX_Geartitle_D;0;0;Create;True;661387f8f31743a4f9579a85ee56c2d0;661387f8f31743a4f9579a85ee56c2d0;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-477.859,279.997;Float;False;2;2;0;COLOR;0.0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;gear font;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;FLOAT;0.0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;4;0;3;0
WireConnection;4;1;5;0
WireConnection;0;0;2;0
WireConnection;0;2;4;0
ASEEND*/
//CHKSM=CCC01980B9C42FDDDD7231FFB0A632DDF6508687