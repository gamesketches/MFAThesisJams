Shader "Thesis Jam/Fill"
{
	Properties
	{
		_Color ("Main Color", Color) = (1, 0.5, 0.5, 1)
		_Breakpoint ("Breakpoint", float) = 0.1
	}

	Subshader
	{
		Pass
		{
			Cull Off

			CGPROGRAM

			#pragma vertex vert  
	        #pragma fragment frag 
	 
	        struct vertexInput {
	        	float4 vertex : POSITION;
	        };
	        struct vertexOutput {
	        	float4 pos : SV_POSITION;
	        	float4 posInObjectCoords : TEXCOORD0;
	        };
	 
	        vertexOutput vert(vertexInput input) 
	        {
		        vertexOutput output;
		 
		        output.pos =  mul(UNITY_MATRIX_MVP, input.vertex);
		        output.posInObjectCoords = input.vertex; 
	 
	        	return output;
	        }

	        float _Breakpoint;

	        float4 frag(vertexOutput input) : COLOR 
	        {
	        	if (input.posInObjectCoords.y + 0.5 > _Breakpoint) { return float4(1.0, 1.0, 0.0, 1.0); }

	        	return float4(1.0, 0.0, 0.0, 1.0);
	        }
	       
			ENDCG
		}
	}
}
