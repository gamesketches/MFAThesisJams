//Red at _Multiplier = 0
//Yellow appears, and red shrinks, as _Multiplier increases

Shader "Thesis Jam/Vertical stripes"
{
	Properties
	{
		_Yellow ("Yellow", Color) = (1.0, 1.0, 0.0, 1.0)
		_Red ("Red", Color) = (1.0, 0.0, 0.0, 1.0)
		_Multiplier ("Multiplier", float) = 20
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

	        float _Multiplier;
	        float4 _Yellow;
	        float4 _Red;

	        float4 frag(vertexOutput input) : COLOR 
	        {
	        	if (2 * sin(_Multiplier * input.posInObjectCoords.x) > 1.0) { return _Yellow; }

	        	return _Red;
	        }
	       
			ENDCG
		}
	}
}
