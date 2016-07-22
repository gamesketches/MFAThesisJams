Shader "Thesis Jam/Polka dots"
{
	Properties
	{
		_Color ("Main Color", Color) = (1, 0.5, 0.5, 1)
		_Radius ("Radius", float) = 1
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

	        float _Radius;

	        float4 frag(vertexOutput input) : COLOR 
	        {
	        	if (distance(input.posInObjectCoords, float4(0.3, 0.3, 0.3, 0.3)) > _Radius) 
	        		{ return float4(1.0, 0.0, 0.0, 1.0); }

	        	if (distance(input.posInObjectCoords, float4(-0.3, -0.3, -0.3, -0.3)) > _Radius)
	        		{ return float4(1.0, 0.0, 0.0, 1.0); }

	        	return float4(1.0, 1.0, 0.0, 1.0);
	        }
	       
			ENDCG
		}
	}
}
