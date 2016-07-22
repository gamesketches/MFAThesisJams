//Red at _Breakpoint = 0.5
//Red shrinks, and is surrounded by yellow, as _Breakpoint approaches 0

Shader "Thesis Jam/Vertical line"
{
	Properties
	{
		_Yellow ("Yellow", Color) = (1.0, 1.0, 0.0, 1.0)
		_Red ("Red", Color) = (1.0, 0.0, 0.0, 1.0)
		_Breakpoint ("Breakpoint", float) = 0.3
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
	        float4 _Yellow;
	        float4 _Red;

	        float4 frag(vertexOutput input) : COLOR 
	        {
	        	if (input.posInObjectCoords.x > _Breakpoint || input.posInObjectCoords.x < -_Breakpoint) 
	       		{
	        		return _Yellow;
	            }
	            return _Red;
	        }
	       
			ENDCG
		}
	}
}
